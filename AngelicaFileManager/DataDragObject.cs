using Gpckx;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Permissions;
using System.Text;
using System.Windows.Forms;

namespace Pck_Guy_View
{
    public class DataDragObject : DataObject, System.Runtime.InteropServices.ComTypes.IDataObject
    {
        public PckEntry[] datax = null;
        public DataDragObject(PckEntry[] selectedItems)
        {
            datax = selectedItems;
        }
        private Int32 m_lindex;

        private static readonly TYMED[] ALLOWED_TYMEDS =
            new TYMED[] {
                TYMED.TYMED_HGLOBAL,
                TYMED.TYMED_ISTREAM,
                TYMED.TYMED_ENHMF,
                TYMED.TYMED_MFPICT,
                TYMED.TYMED_GDI};

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        struct FILEDESCRIPTOR
        {
            public UInt32 dwFlags;
            public Guid clsid;
            public System.Drawing.Size sizel;
            public System.Drawing.Point pointl;
            public UInt32 dwFileAttributes;
            public System.Runtime.InteropServices.ComTypes.FILETIME ftCreationTime;
            public System.Runtime.InteropServices.ComTypes.FILETIME ftLastAccessTime;
            public System.Runtime.InteropServices.ComTypes.FILETIME ftLastWriteTime;
            public UInt32 nFileSizeHigh;
            public UInt32 nFileSizeLow;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public String cFileName;
        }
        
        public override object GetData(string format, bool autoConvert)
        {
            if (String.Compare(format, NativeMethods.CFSTR_FILEDESCRIPTORW, StringComparison.OrdinalIgnoreCase) == 0 && datax != null)
            {
                base.SetData(NativeMethods.CFSTR_FILEDESCRIPTORW, GetFileDescriptor(datax));
            }
            else if (String.Compare(format, NativeMethods.CFSTR_FILECONTENTS, StringComparison.OrdinalIgnoreCase) == 0)
            {
                base.SetData(NativeMethods.CFSTR_FILECONTENTS, GetFileContents(datax, m_lindex));
            }
            else if (String.Compare(format, NativeMethods.CFSTR_PERFORMEDDROPEFFECT, StringComparison.OrdinalIgnoreCase) == 0)
            {
                //TODO: Cleanup routines after paste has been performed
                GC.Collect();
            }
            return base.GetData(format, autoConvert);
        }
        

        private MemoryStream GetFileContents(PckEntry[] SelectedItems, Int32 FileNumber)
        {
            MemoryStream FileContentMemoryStream = null;
            if (SelectedItems != null && FileNumber < SelectedItems.Length)
            {
                FileContentMemoryStream = SelectedItems[FileNumber].memory;
            }
            return FileContentMemoryStream;
        }

        private MemoryStream GetFileDescriptor(PckEntry[] SelectedItems)
        {
            MemoryStream FileDescriptorMemoryStream = new MemoryStream();
            FileDescriptorMemoryStream.Write(BitConverter.GetBytes(SelectedItems.Length), 0, sizeof(UInt32));
            FILEDESCRIPTOR FileDescriptor = new FILEDESCRIPTOR();
            foreach (PckEntry si in SelectedItems)
            {
                FileDescriptor.cFileName = Path.GetFileName(si.filePath);
                Int64 FileWriteTimeUtc = DateTime.Now.Millisecond;
                FileDescriptor.ftLastWriteTime.dwHighDateTime = (Int32)(FileWriteTimeUtc >> 32);
                FileDescriptor.ftLastWriteTime.dwLowDateTime = (Int32)(FileWriteTimeUtc & 0xFFFFFFFF);
                FileDescriptor.nFileSizeHigh = (UInt32)(si.decompressedSize >> 32);
                FileDescriptor.nFileSizeLow = (UInt32)(si.compressedSize & 0xFFFFFFFF);
                FileDescriptor.dwFlags =  NativeMethods.FD_PROGRESSUI;

                // Marshal the FileDescriptor structure into a byte array and write it to the MemoryStream.
                Int32 FileDescriptorSize = Marshal.SizeOf(FileDescriptor);
                IntPtr FileDescriptorPointer = Marshal.AllocHGlobal(FileDescriptorSize);
                Marshal.StructureToPtr(FileDescriptor, FileDescriptorPointer, true);
                Byte[] FileDescriptorByteArray = new Byte[FileDescriptorSize];
                Marshal.Copy(FileDescriptorPointer, FileDescriptorByteArray, 0, FileDescriptorSize);
                Marshal.FreeHGlobal(FileDescriptorPointer);
                FileDescriptorMemoryStream.Write(FileDescriptorByteArray, 0, FileDescriptorByteArray.Length);
            }
            return FileDescriptorMemoryStream;
        }

        [SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        void GetData(ref FORMATETC formatetc, out STGMEDIUM medium)
        {
            if (formatetc.cfFormat == (Int16)DataFormats.GetFormat(NativeMethods.CFSTR_FILECONTENTS).Id)
                m_lindex = formatetc.lindex;

            medium = new System.Runtime.InteropServices.ComTypes.STGMEDIUM();
            if (GetTymedUseable(formatetc.tymed))
            {
                if ((formatetc.tymed & TYMED.TYMED_HGLOBAL) != TYMED.TYMED_NULL)
                {
                    medium.tymed = TYMED.TYMED_HGLOBAL;
                    medium.unionmember = NativeMethods.GlobalAlloc(NativeMethods.GHND | NativeMethods.GMEM_DDESHARE, 1);
                    if (medium.unionmember == IntPtr.Zero)
                    {
                        throw new OutOfMemoryException();
                    }
                    try
                    {
                        ((System.Runtime.InteropServices.ComTypes.IDataObject)this).GetDataHere(ref formatetc, ref medium);
                        return;
                    }
                    catch
                    {
                        NativeMethods.GlobalFree(new HandleRef((STGMEDIUM)medium, medium.unionmember));
                        medium.unionmember = IntPtr.Zero;
                        throw;
                    }
                }
                medium.tymed = formatetc.tymed;
                ((System.Runtime.InteropServices.ComTypes.IDataObject)this).GetDataHere(ref formatetc, ref medium);
            }
            else
            {
                Marshal.ThrowExceptionForHR(NativeMethods.DV_E_TYMED);
            }
        }

        private static Boolean GetTymedUseable(TYMED tymed)
        {
            for (Int32 i = 0; i < ALLOWED_TYMEDS.Length; i++)
            {
                if ((tymed & ALLOWED_TYMEDS[i]) != TYMED.TYMED_NULL)
                {
                    return true;
                }
            }
            return false;
        }
    }
    public class NativeMethods
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GlobalAlloc(int uFlags, int dwBytes);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GlobalFree(HandleRef handle);

        // Clipboard formats used for cut/copy/drag operations
        public const string CFSTR_PREFERREDDROPEFFECT = "Preferred DropEffect";
        public const string CFSTR_PERFORMEDDROPEFFECT = "Performed DropEffect";
        public const string CFSTR_FILEDESCRIPTORW = "FileGroupDescriptorW";
        public const string CFSTR_FILECONTENTS = "FileContents";

        // File Descriptor Flags
        public const Int32 FD_CLSID = 0x00000001;
        public const Int32 FD_SIZEPOINT = 0x00000002;
        public const Int32 FD_ATTRIBUTES = 0x00000004;
        public const Int32 FD_CREATETIME = 0x00000008;
        public const Int32 FD_ACCESSTIME = 0x00000010;
        public const Int32 FD_WRITESTIME = 0x00000020;
        public const Int32 FD_FILESIZE = 0x00000040;
        public const Int32 FD_PROGRESSUI = 0x00004000;
        public const Int32 FD_LINKUI = 0x00008000;

        // Global Memory Flags
        public const Int32 GMEM_MOVEABLE = 0x0002;
        public const Int32 GMEM_ZEROINIT = 0x0040;
        public const Int32 GHND = (GMEM_MOVEABLE | GMEM_ZEROINIT);
        public const Int32 GMEM_DDESHARE = 0x2000;

        // IDataObject constants
        public const Int32 DV_E_TYMED = unchecked((Int32)0x80040069);
    }

}
