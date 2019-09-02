// Decompiled with JetBrains decompiler
// Type: DevIL.Unmanaged.IL
// Assembly: DevILNet, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 52632D74-10FE-43BD-BAF1-03372C249855
// Assembly location: C:\Users\IcyTeck\Desktop\GShopUtils\GShopUtils\lib\DevILNet.dll

using System;
using System.IO;
using System.Runtime.InteropServices;

namespace DevIL.Unmanaged
{
  public static class IL
  {
    private static bool _init = false;
    private static object s_sync = new object();
    private static int s_ref = 0;
    private const string ILDLL = "DeviL.dll";

    public static bool IsInitialized
    {
      get
      {
        return IL._init;
      }
    }

    internal static void AddRef()
    {
      lock (IL.s_sync)
      {
        if (IL.s_ref == 0)
        {
          IL.Initialize();
          ILU.Initialize();
        }
        ++IL.s_ref;
      }
    }

    internal static void Release()
    {
      lock (IL.s_sync)
      {
        if (IL.s_ref == 0)
          return;
        --IL.s_ref;
        if (IL.s_ref != 0)
          return;
        IL.Shutdown();
      }
    }

    public static bool ActiveFace(int faceNum)
    {
      if (faceNum >= 0)
        return IL.ilActiveFace((uint) faceNum);
      return false;
    }

    public static bool ActiveImage(int imageNum)
    {
      if (imageNum >= 0)
        return IL.ilActiveImage((uint) imageNum);
      return false;
    }

    public static bool ActiveLayer(int layerNum)
    {
      if (layerNum >= 0)
        return IL.ilActiveLayer((uint) layerNum);
      return false;
    }

    public static bool ActiveMipMap(int mipMapNum)
    {
      if (mipMapNum >= 0)
        return IL.ilActiveMipmap((uint) mipMapNum);
      return false;
    }

    [DllImport(ILDLL, EntryPoint = "ilApplyPal", CallingConvention = CallingConvention.StdCall)]
    [return: MarshalAs(UnmanagedType.U1)]
    public static extern bool ApplyPalette([MarshalAs(UnmanagedType.LPStr), In] string FileName);

    public static void BindImage(ImageID imageID)
    {
      if (imageID.ID < 0)
        return;
      IL.ilBindImage((uint) imageID.ID);
    }

    public static bool Blit(ImageID srcImageID, int destX, int destY, int destZ, int srcX, int srcY, int srcZ, int width, int height, int depth)
    {
      if (srcImageID.ID >= 0)
        return IL.ilBlit((uint) srcImageID.ID, destX, destY, destZ, (uint) srcX, (uint) srcY, (uint) srcZ, (uint) width, (uint) height, (uint) depth);
      return false;
    }

    [DllImport(ILDLL, EntryPoint = "ilClampNTSC", CallingConvention = CallingConvention.StdCall)]
    [return: MarshalAs(UnmanagedType.U1)]
    public static extern bool ClampNTSC();

    [DllImport(ILDLL, EntryPoint = "ilClearColour", CallingConvention = CallingConvention.StdCall)]
    public static extern void ClearColor(float red, float green, float blue, float alpha);

    [DllImport(ILDLL, EntryPoint = "ilClearImage", CallingConvention = CallingConvention.StdCall)]
    [return: MarshalAs(UnmanagedType.U1)]
    public static extern bool ClearImage();

    public static int CloneCurrentImage()
    {
      return (int) IL.ilCloneCurImage();
    }

    public static bool ConvertImage(DataFormat destFormat, DataType destType)
    {
      return IL.ilConvertImage((uint) destFormat, (uint) destType);
    }

    public static bool ConvertPalette(PaletteType palType)
    {
      return IL.ilConvertPal((uint) palType);
    }

    public static bool CopyImage(ImageID srcImageID)
    {
      return IL.ilCopyImage((uint) srcImageID.ID);
    }

    public static unsafe byte[] CopyPixels(int xOffset, int yOffset, int zOffset, int width, int height, int depth, DataFormat format, DataType dataType)
    {
      byte[] numArray = new byte[MemoryHelper.GetDataSize(width, height, depth, format, dataType)];
      fixed (byte* numPtr = numArray)
      {
        if ((int) IL.ilCopyPixels((uint) xOffset, (uint) yOffset, (uint) zOffset, (uint) width, (uint) height, (uint) depth, (uint) format, (uint) dataType, new IntPtr((void*) numPtr)) == 0)
          return (byte[]) null;
      }
      return numArray;
    }

    public static bool CopyPixels(int xOffset, int yOffset, int zOffset, int width, int height, int depth, DataFormat format, DataType dataType, IntPtr data)
    {
      if (data == IntPtr.Zero)
        return false;
      return IL.ilCopyPixels((uint) xOffset, (uint) yOffset, (uint) zOffset, (uint) width, (uint) height, (uint) depth, (uint) format, (uint) dataType, data) > 0U;
    }

    public static bool CreateSubImage(SubImageType subImageType, int subImageCount)
    {
      return (int) IL.ilCreateSubImage((uint) subImageType, (uint) subImageCount) != 0;
    }

    [DllImport(ILDLL, EntryPoint = "ilDefaultImage", CallingConvention = CallingConvention.StdCall)]
    [return: MarshalAs(UnmanagedType.U1)]
    public static extern bool DefaultImage();

    public static void DeleteImage(ImageID imageID)
    {
      if (imageID > (ImageID) 0)
        return;
      IL.ilDeleteImage((uint) imageID.ID);
    }

    public static void DeleteImages(ImageID[] imageIDs)
    {
      uint[] Images = new uint[imageIDs.Length];
      for (int index = 0; index < imageIDs.Length; ++index)
        Images[index] = (uint) imageIDs[index].ID;
      IL.ilDeleteImages(new UIntPtr((uint) Images.Length), Images);
    }

    public static ImageType DetermineImageType(string fileName)
    {
      if (string.IsNullOrEmpty(fileName))
        return ImageType.Unknown;
      return (ImageType) IL.ilDetermineType(fileName);
    }

    public static unsafe ImageType DetermineImageType(byte[] lump)
    {
      if (lump == null || lump.Length == 0)
        return ImageType.Unknown;
      uint length = (uint) lump.Length;
      fixed (byte* numPtr = lump)
        return (ImageType) IL.ilDetermineTypeL(new IntPtr((void*) numPtr), length);
    }

    public static ImageType DetermineImageTypeFromExtension(string extension)
    {
      if (string.IsNullOrEmpty(extension))
        return ImageType.Unknown;
      return (ImageType) IL.ilTypeFromExt(extension);
    }

    public static bool Disable(ILEnable mode)
    {
      return IL.ilDisable((uint) mode);
    }

    [DllImport(ILDLL, EntryPoint = "ilDxtcDataToImage", CallingConvention = CallingConvention.StdCall)]
    [return: MarshalAs(UnmanagedType.U1)]
    public static extern bool DxtcDataToImage();

    [DllImport(ILDLL, EntryPoint = "ilDxtcDataToSurface", CallingConvention = CallingConvention.StdCall)]
    [return: MarshalAs(UnmanagedType.U1)]
    public static extern bool DxtcDataToSurface();

    public static bool Enable(ILEnable mode)
    {
      return IL.ilEnable((uint) mode);
    }

    [DllImport(ILDLL, EntryPoint = "ilFlipSurfaceDxtcData", CallingConvention = CallingConvention.StdCall)]
    public static extern void FlipSurfaceDxtcData();

    public static ImageID GenerateImage()
    {
      return new ImageID((int) IL.ilGenImage());
    }

    public static ImageID[] GenerateImages(int count)
    {
      UIntPtr Num = new UIntPtr((uint) count);
      uint[] Images = new uint[count];
      IL.ilGenImages(Num, Images);
      ImageID[] imageIdArray = new ImageID[count];
      for (int index = 0; index < count; ++index)
        imageIdArray[index] = new ImageID((int) Images[index]);
      return imageIdArray;
    }

    public static bool GetBoolean(ILBooleanMode mode)
    {
      return IL.ilGetInteger((uint) mode) != 0;
    }

    public static int GetInteger(ILIntegerMode mode)
    {
      return IL.ilGetInteger((uint) mode);
    }

    public static unsafe byte[] GetDxtcData(CompressedDataFormat dxtcFormat)
    {
      uint dxtcData1 = IL.ilGetDXTCData(IntPtr.Zero, 0U, (uint) dxtcFormat);
      if ((int) dxtcData1 == 0)
        return (byte[]) null;
      byte[] numArray = new byte[dxtcData1];
      fixed (byte* numPtr = numArray)
      {
        int dxtcData2 = (int) IL.ilGetDXTCData(new IntPtr((void*) numPtr), dxtcData1, (uint) dxtcFormat);
      }
      return numArray;
    }

    public static ErrorType GetError()
    {
      return (ErrorType) IL.ilGetError();
    }

    public static byte[] GetImageData()
    {
      IntPtr data = IL.ilGetData();
      if (data == IntPtr.Zero)
        return (byte[]) null;
      int integer = IL.ilGetInteger(3559U);
      return MemoryHelper.ReadByteBuffer(data, integer);
    }

    public static IntPtr GetData()
    {
      return IL.ilGetData();
    }

    public static byte[] GetPaletteData()
    {
      return MemoryHelper.ReadByteBuffer(IL.ilGetPalette(), MemoryHelper.GetPaletteComponentCount((PaletteType) IL.ilGetInteger(3564U)) * IL.ilGetInteger(3567U));
    }

    public static DataFormat GetDataFormat()
    {
      return (DataFormat) IL.ilGetInteger(1553U);
    }

    public static CompressedDataFormat GetDxtcFormat()
    {
      return (CompressedDataFormat) IL.ilGetInteger(1797U);
    }

    public static DataType GetDataType()
    {
      return (DataType) IL.ilGetInteger(1555U);
    }

    public static JpgSaveFormat GetJpgSaveFormat()
    {
      return (JpgSaveFormat) IL.ilGetInteger(1825U);
    }

    public static OriginLocation GetOriginLocation()
    {
      return (OriginLocation) IL.ilGetInteger(1539U);
    }

    public static string GetString(ILStringMode mode)
    {
      IntPtr ptr = IL.ilGetString((uint) mode);
      if (ptr != IntPtr.Zero)
        return Marshal.PtrToStringAnsi(ptr);
      return string.Empty;
    }

    public static ImageInfo GetImageInfo()
    {
      return new ImageInfo()
      {
        Format = (DataFormat) IL.ilGetInteger(3562U),
        DxtcFormat = (CompressedDataFormat) IL.ilGetInteger(1805U),
        DataType = (DataType) IL.ilGetInteger(3563U),
        PaletteType = (PaletteType) IL.ilGetInteger(3564U),
        PaletteBaseType = (DataFormat) IL.ilGetInteger(3568U),
        CubeFlags = (CubeMapFace) IL.ilGetInteger(3581U),
        Origin = (OriginLocation) IL.ilGetInteger(3582U),
        Width = IL.ilGetInteger(3556U),
        Height = IL.ilGetInteger(3557U),
        Depth = IL.ilGetInteger(3558U),
        BitsPerPixel = IL.ilGetInteger(3561U),
        BytesPerPixel = IL.ilGetInteger(3560U),
        Channels = IL.ilGetInteger(3583U),
        Duration = IL.ilGetInteger(3576U),
        SizeOfData = IL.ilGetInteger(3559U),
        OffsetX = IL.ilGetInteger(3579U),
        OffsetY = IL.ilGetInteger(3580U),
        PlaneSize = IL.ilGetInteger(3577U),
        FaceCount = IL.ilGetInteger(3553U) + 1,
        ImageCount = IL.ilGetInteger(3569U) + 1,
        LayerCount = IL.ilGetInteger(3571U) + 1,
        MipMapCount = IL.ilGetInteger(3570U) + 1,
        PaletteBytesPerPixel = IL.ilGetInteger(3566U),
        PaletteColumnCount = IL.ilGetInteger(3567U)
      };
    }

    public static Quantization GetQuantization()
    {
      return (Quantization) IL.ilGetInteger(1600U);
    }

    [DllImport(ILDLL, EntryPoint = "ilInvertSurfaceDxtcDataAlpha", CallingConvention = CallingConvention.StdCall)]
    [return: MarshalAs(UnmanagedType.U1)]
    public static extern bool InvertSurfaceDxtcDataAlpha();

    public static void Initialize()
    {
      if (IL._init)
        return;
      IL.ilInit();
      IL._init = true;
    }

    public static bool IsDisabled(ILEnable mode)
    {
      return IL.ilIsDisabled((uint) mode);
    }

    public static bool IsEnabled(ILEnable mode)
    {
      return IL.ilIsEnabled((uint) mode);
    }

    public static bool ImageToDxtcData(CompressedDataFormat format)
    {
      return IL.ilImageToDxtcData((uint) format);
    }

    public static bool IsImage(ImageID imageID)
    {
      if (imageID.ID < 0)
        return false;
      return IL.ilIsImage((uint) imageID.ID);
    }

    public static bool IsValid(ImageType imageType, string filename)
    {
      if (imageType == ImageType.Unknown || string.IsNullOrEmpty(filename))
        return false;
      return IL.ilIsValid((uint) imageType, filename);
    }

    public static unsafe bool IsValid(ImageType imageType, byte[] data)
    {
      if (imageType == ImageType.Unknown || data == null || data.Length == 0)
        return false;
      fixed (byte* numPtr = data)
        return IL.ilIsValidL((uint) imageType, new IntPtr((void*) numPtr), (uint) data.Length);
    }

    [DllImport(ILDLL, EntryPoint = "ilLoadImage", CallingConvention = CallingConvention.StdCall)]
    [return: MarshalAs(UnmanagedType.U1)]
    public static extern bool LoadImage([MarshalAs(UnmanagedType.LPStr), In] string FileName);

    public static bool LoadImage(ImageType imageType, string filename)
    {
      return IL.ilLoad((uint) imageType, filename);
    }

    public static unsafe bool LoadImageFromStream(ImageType imageType, Stream stream)
    {
      if (imageType == ImageType.Unknown || stream == null || !stream.CanRead)
        return false;
      byte[] numArray = MemoryHelper.ReadStreamFully(stream, 0);
      uint length = (uint) numArray.Length;
      bool flag;
      fixed (byte* numPtr = numArray)
        flag = IL.ilLoadL((uint) imageType, new IntPtr((void*) numPtr), length);
      return flag;
    }

    public static unsafe bool LoadImageFromStream(Stream stream)
    {
      if (stream == null || !stream.CanRead)
        return false;
      byte[] lump = MemoryHelper.ReadStreamFully(stream, 0);
      uint length = (uint) lump.Length;
      ImageType imageType = IL.DetermineImageType(lump);
      bool flag;
      fixed (byte* numPtr = lump)
        flag = IL.ilLoadL((uint) imageType, new IntPtr((void*) numPtr), length);
      return flag;
    }

    [DllImport(ILDLL, EntryPoint = "ilLoadPal", CallingConvention = CallingConvention.StdCall)]
    [return: MarshalAs(UnmanagedType.U1)]
    public static extern bool LoadPalette([MarshalAs(UnmanagedType.LPStr), In] string fileName);

    public static bool LoadRawData(string filename, int width, int height, int depth, int componentCount)
    {
      if (string.IsNullOrEmpty(filename) || width < 1 || (height < 1 || depth < 1) || (componentCount != 1 || componentCount != 3 || componentCount != 4))
        return false;
      return IL.ilLoadData(filename, (uint) width, (uint) height, (uint) depth, (byte) componentCount);
    }

    public static unsafe bool LoadRawData(byte[] data, int width, int height, int depth, int componentCount)
    {
      if (width < 1 || height < 1 || (depth < 1 || componentCount != 1) || (componentCount != 3 || componentCount != 4))
        return false;
      uint length = (uint) data.Length;
      fixed (byte* numPtr = data)
        return IL.ilLoadDataL(new IntPtr((void*) numPtr), length, (uint) width, (uint) height, (uint) depth, (byte) componentCount);
    }

    [DllImport(ILDLL, EntryPoint = "ilModAlpha", CallingConvention = CallingConvention.StdCall)]
    public static extern void ModulateAlpha(double alphaValue);

    public static bool OverlayImage(ImageID srcImageID, int destX, int destY, int destZ)
    {
      if (srcImageID.ID < 0)
        return false;
      return IL.ilOverlayImage((uint) srcImageID.ID, destX, destY, destZ);
    }

    [DllImport(ILDLL, EntryPoint = "ilPopAttrib", CallingConvention = CallingConvention.StdCall)]
    public static extern void PopAttribute();

    public static void PushAttribute(AttributeBits bits)
    {
      IL.ilPushAttrib((uint) bits);
    }

    [DllImport(ILDLL, EntryPoint = "ilSaveImage", CallingConvention = CallingConvention.StdCall)]
    public static extern bool SaveImage([MarshalAs(UnmanagedType.LPStr), In] string fileName);

    public static bool SaveImage(ImageType type, string filename)
    {
      return IL.ilSave((uint) type, filename);
    }

    public static unsafe bool SaveImageToStream(ImageType imageType, Stream stream)
    {
      if (imageType == ImageType.Unknown || stream == null || !stream.CanWrite)
        return false;
      uint Size = IL.ilSaveL((uint) imageType, IntPtr.Zero, 0U);
      if ((int) Size == 0)
        return false;
      byte[] buffer = new byte[Size];
      fixed (byte* numPtr = buffer)
      {
        if ((int) IL.ilSaveL((uint) imageType, new IntPtr((void*) numPtr), Size) == 0)
          return false;
      }
      stream.Write(buffer, 0, buffer.Length);
      return true;
    }

    [DllImport(ILDLL, EntryPoint = "ilSaveData", CallingConvention = CallingConvention.StdCall)]
    [return: MarshalAs(UnmanagedType.U1)]
    public static extern bool SaveRawData([MarshalAs(UnmanagedType.LPStr), In] string FileName);

    [DllImport(ILDLL, EntryPoint = "ilSavePal", CallingConvention = CallingConvention.StdCall)]
    [return: MarshalAs(UnmanagedType.U1)]
    public static extern bool SavePalette([MarshalAs(UnmanagedType.LPStr), In] string FileName);

    [DllImport(ILDLL, EntryPoint = "ilSetAlpha", CallingConvention = CallingConvention.StdCall)]
    [return: MarshalAs(UnmanagedType.U1)]
    public static extern bool SetAlpha(double alphaValue);

    public static void SetBoolean(ILBooleanMode mode, bool value)
    {
      IL.ilSetInteger((uint) mode, value ? 1 : 0);
    }

    public static bool SetCompressionAlgorithm(CompressionAlgorithm compressAlgorithm)
    {
      return IL.ilCompressFunc((uint) compressAlgorithm);
    }

    public static bool SetDataFormat(DataFormat dataFormat)
    {
      return IL.ilFormatFunc((uint) dataFormat);
    }

    public static unsafe bool SetImageData(byte[] data)
    {
      fixed (byte* numPtr = data)
        return IL.ilSetData(new IntPtr((void*) numPtr));
    }

    public static bool SetDuration(int duration)
    {
      if (duration < 0)
        return false;
      return IL.ilSetDuration((uint) duration);
    }

    public static void SetDxtcFormat(CompressedDataFormat format)
    {
      IL.ilSetInteger(1797U, (int) format);
    }

    public static bool SetDataType(DataType dataType)
    {
      return IL.ilTypeFunc((uint) dataType);
    }

    [DllImport(ILDLL, EntryPoint = "ilKeyColour", CallingConvention = CallingConvention.StdCall)]
    public static extern void SetKeyColor(float red, float green, float blue, float alpha);

    public static void SetKeyColor(Color color)
    {
      IL.SetKeyColor(color.R, color.G, color.B, color.A);
    }

    public static void SetMemoryHint(MemoryHint hint)
    {
      IL.ilHint(1637U, (uint) hint);
    }

    public static void SetCompressionHint(CompressionHint hint)
    {
      IL.ilHint(1640U, (uint) hint);
    }

    public static void SetJpgSaveFormat(JpgSaveFormat format)
    {
      IL.ilSetInteger(1825U, (int) format);
    }

    public static void SetInteger(ILIntegerMode mode, int value)
    {
      IL.ilSetInteger((uint) mode, value);
    }

    public static void SetOriginLocation(OriginLocation origin)
    {
      IL.ilOriginFunc((uint) origin);
    }

    public static void SetString(ILStringMode mode, string value)
    {
      if (value == null)
        value = string.Empty;
      IL.ilSetString((uint) mode, value);
    }

    public static void SetQuantization(Quantization mode)
    {
      IL.ilSetInteger(1600U, (int) mode);
    }

    public static unsafe bool SetPixels(int xOffset, int yOffset, int zOffset, int width, int height, int depth, DataFormat format, DataType dataType, byte[] data)
    {
      if (data == null || data.Length == 0 || (xOffset < 0 || yOffset < 0) || (zOffset < 0 || width < 1 || (height < 1 || depth < 1)))
        return false;
      fixed (byte* numPtr = data)
        IL.ilSetPixels(xOffset, yOffset, zOffset, (uint) width, (uint) height, (uint) depth, (uint) format, (uint) dataType, new IntPtr((void*) numPtr));
      return true;
    }

    public static void Shutdown()
    {
      if (!IL._init)
        return;
      IL.ilShutDown();
      IL._init = false;
    }

    public static bool SurfaceToDxtcData(CompressedDataFormat format)
    {
      return IL.ilSurfaceToDxtcData((uint) format);
    }

    public static unsafe bool SetTexImage(int width, int height, int depth, DataFormat format, DataType dataType, byte[] data)
    {
      if (data == null || data.Length == 0)
        return false;
      byte formatComponentCount = (byte) MemoryHelper.GetFormatComponentCount(format);
      fixed (byte* numPtr = data)
        return IL.ilTexImage((uint) width, (uint) height, (uint) depth, formatComponentCount, (uint) format, (uint) dataType, new IntPtr((void*) numPtr));
    }

    public static unsafe bool SetTexImageDxtc(int width, int height, int depth, CompressedDataFormat format, byte[] data)
    {
      if (data == null || data.Length == 0)
        return false;
      fixed (byte* numPtr = data)
        return IL.ilTexImageDxtc(width, height, depth, (uint) format, new IntPtr((void*) numPtr));
    }

    public static string GetVendorName()
    {
      IntPtr ptr = IL.ilGetString(7936U);
      if (ptr != IntPtr.Zero)
        return Marshal.PtrToStringAnsi(ptr);
      return "DevIL";
    }

    public static string GetVersion()
    {
      IntPtr ptr = IL.ilGetString(3554U);
      if (ptr != IntPtr.Zero)
        return Marshal.PtrToStringAnsi(ptr);
      return "Unknown Version";
    }

    public static string[] GetImportExtensions()
    {
      IntPtr ptr = IL.ilGetString(7937U);
      if (!(ptr != IntPtr.Zero))
        return new string[0];
      string[] strArray = Marshal.PtrToStringAnsi(ptr).Split(new char[1]
      {
        ' '
      }, StringSplitOptions.RemoveEmptyEntries);
      for (int index = 0; index < strArray.Length; ++index)
      {
        string str = strArray[index];
        if (str.Equals("dcmdds"))
          str = str.Substring(0, "dcm".Length);
        strArray[index] = "." + str;
      }
      return strArray;
    }

    public static string[] GetExportExtensions()
    {
      IntPtr ptr = IL.ilGetString(7938U);
      if (!(ptr != IntPtr.Zero))
        return new string[0];
      string[] strArray = Marshal.PtrToStringAnsi(ptr).Split(new char[1]
      {
        ' '
      }, StringSplitOptions.RemoveEmptyEntries);
      for (int index = 0; index < strArray.Length; ++index)
        strArray[index] = "." + strArray[index];
      return strArray;
    }

    [DllImport(ILDLL, CallingConvention = CallingConvention.StdCall)]
    [return: MarshalAs(UnmanagedType.U1)]
    private static extern bool ilActiveFace(uint Number);

    [DllImport(ILDLL, CallingConvention = CallingConvention.StdCall)]
    [return: MarshalAs(UnmanagedType.U1)]
    private static extern bool ilActiveImage(uint Number);

    [DllImport(ILDLL, CallingConvention = CallingConvention.StdCall)]
    [return: MarshalAs(UnmanagedType.U1)]
    private static extern bool ilActiveLayer(uint Number);

    [DllImport(ILDLL, CallingConvention = CallingConvention.StdCall)]
    [return: MarshalAs(UnmanagedType.U1)]
    private static extern bool ilActiveMipmap(uint Number);

    [DllImport(ILDLL, CallingConvention = CallingConvention.StdCall)]
    [return: MarshalAs(UnmanagedType.U1)]
    private static extern bool ilApplyProfile(IntPtr InProfile, IntPtr OutProfile);

    [DllImport(ILDLL, CallingConvention = CallingConvention.StdCall)]
    private static extern void ilBindImage(uint Image);

    [DllImport(ILDLL, CallingConvention = CallingConvention.StdCall)]
    [return: MarshalAs(UnmanagedType.U1)]
    private static extern bool ilBlit(uint Source, int DestX, int DestY, int DestZ, uint SrcX, uint SrcY, uint SrcZ, uint Width, uint Height, uint Depth);

    [DllImport(ILDLL, CallingConvention = CallingConvention.StdCall)]
    private static extern uint ilCloneCurImage();

    [DllImport(ILDLL, CallingConvention = CallingConvention.StdCall)]
    private static extern IntPtr ilCompressDXT(IntPtr Data, uint Width, uint Height, uint Depth, uint DXTCFormat, ref uint DXTCSize);

    [DllImport(ILDLL, CallingConvention = CallingConvention.StdCall)]
    [return: MarshalAs(UnmanagedType.U1)]
    private static extern bool ilCompressFunc(uint Mode);

    [DllImport(ILDLL, CallingConvention = CallingConvention.StdCall)]
    [return: MarshalAs(UnmanagedType.U1)]
    private static extern bool ilConvertImage(uint DestFormat, uint DestType);

    [DllImport(ILDLL, CallingConvention = CallingConvention.StdCall)]
    [return: MarshalAs(UnmanagedType.U1)]
    private static extern bool ilConvertPal(uint DestFormat);

    [DllImport(ILDLL, CallingConvention = CallingConvention.StdCall)]
    [return: MarshalAs(UnmanagedType.U1)]
    private static extern bool ilCopyImage(uint Src);

    [DllImport(ILDLL, CallingConvention = CallingConvention.StdCall)]
    private static extern uint ilCopyPixels(uint XOff, uint YOff, uint ZOff, uint Width, uint Height, uint Depth, uint Format, uint Type, IntPtr Data);

    [DllImport(ILDLL, CallingConvention = CallingConvention.StdCall)]
    private static extern uint ilCreateSubImage(uint Type, uint Num);

    [DllImport(ILDLL, CallingConvention = CallingConvention.StdCall)]
    private static extern void ilDeleteImage(uint Num);

    [DllImport(ILDLL, CallingConvention = CallingConvention.StdCall)]
    private static extern void ilDeleteImages(UIntPtr Num, uint[] Images);

    [DllImport(ILDLL, CallingConvention = CallingConvention.StdCall)]
    private static extern uint ilDetermineType([MarshalAs(UnmanagedType.LPStr), In] string FileName);

    [DllImport(ILDLL, CallingConvention = CallingConvention.StdCall)]
    private static extern uint ilDetermineTypeL(IntPtr Lump, uint Size);

    [DllImport(ILDLL, CallingConvention = CallingConvention.StdCall)]
    [return: MarshalAs(UnmanagedType.U1)]
    private static extern bool ilDisable(uint Mode);

    [DllImport(ILDLL, CallingConvention = CallingConvention.StdCall)]
    [return: MarshalAs(UnmanagedType.U1)]
    private static extern bool ilEnable(uint Mode);

    [DllImport(ILDLL, CallingConvention = CallingConvention.StdCall)]
    [return: MarshalAs(UnmanagedType.U1)]
    private static extern bool ilFormatFunc(uint Mode);

    [DllImport(ILDLL, CallingConvention = CallingConvention.StdCall)]
    private static extern void ilGenImages(UIntPtr Num, uint[] Images);

    [DllImport(ILDLL, CallingConvention = CallingConvention.StdCall)]
    private static extern uint ilGenImage();

    [DllImport(ILDLL, CallingConvention = CallingConvention.StdCall)]
    private static extern IntPtr ilGetAlpha(uint Type);

    [DllImport(ILDLL, CallingConvention = CallingConvention.StdCall)]
    private static extern IntPtr ilGetData();

    [DllImport(ILDLL, CallingConvention = CallingConvention.StdCall)]
    private static extern uint ilGetDXTCData(IntPtr Buffer, uint BufferSize, uint DXTCFormat);

    [DllImport(ILDLL, CallingConvention = CallingConvention.StdCall)]
    private static extern uint ilGetError();

    [DllImport(ILDLL, CallingConvention = CallingConvention.StdCall)]
    internal static extern int ilGetInteger(uint Mode);

    [DllImport(ILDLL, CallingConvention = CallingConvention.StdCall)]
    private static extern IntPtr ilGetPalette();

    [DllImport(ILDLL, CallingConvention = CallingConvention.StdCall)]
    private static extern IntPtr ilGetString(uint StringName);

    [DllImport(ILDLL, CallingConvention = CallingConvention.StdCall)]
    private static extern void ilHint(uint Target, uint Mode);

    [DllImport(ILDLL, CallingConvention = CallingConvention.StdCall)]
    private static extern void ilInit();

    [DllImport(ILDLL, CallingConvention = CallingConvention.StdCall)]
    [return: MarshalAs(UnmanagedType.U1)]
    private static extern bool ilImageToDxtcData(uint Format);

    [DllImport(ILDLL, CallingConvention = CallingConvention.StdCall)]
    [return: MarshalAs(UnmanagedType.U1)]
    private static extern bool ilIsDisabled(uint Mode);

    [DllImport(ILDLL, CallingConvention = CallingConvention.StdCall)]
    [return: MarshalAs(UnmanagedType.U1)]
    private static extern bool ilIsEnabled(uint Mode);

    [DllImport(ILDLL, CallingConvention = CallingConvention.StdCall)]
    [return: MarshalAs(UnmanagedType.U1)]
    private static extern bool ilIsImage(uint Image);

    [DllImport(ILDLL, CallingConvention = CallingConvention.StdCall)]
    [return: MarshalAs(UnmanagedType.U1)]
    private static extern bool ilIsValid(uint Type, [MarshalAs(UnmanagedType.LPStr), In] string FileName);

    [DllImport(ILDLL, CallingConvention = CallingConvention.StdCall)]
    [return: MarshalAs(UnmanagedType.U1)]
    private static extern bool ilIsValidL(uint Type, IntPtr Lump, uint Size);

    [DllImport(ILDLL, CallingConvention = CallingConvention.StdCall)]
    [return: MarshalAs(UnmanagedType.U1)]
    private static extern bool ilLoad(uint Type, [MarshalAs(UnmanagedType.LPStr), In] string FileName);

    [DllImport(ILDLL, CallingConvention = CallingConvention.StdCall)]
    [return: MarshalAs(UnmanagedType.U1)]
    private static extern bool ilLoadL(uint Type, IntPtr Lump, uint Size);

    [DllImport(ILDLL, CallingConvention = CallingConvention.StdCall)]
    [return: MarshalAs(UnmanagedType.U1)]
    private static extern bool ilOriginFunc(uint Mode);

    [DllImport(ILDLL, CallingConvention = CallingConvention.StdCall)]
    [return: MarshalAs(UnmanagedType.U1)]
    private static extern bool ilOverlayImage(uint Source, int XCoord, int YCoord, int ZCoord);

    [DllImport(ILDLL, CallingConvention = CallingConvention.StdCall)]
    private static extern void ilPushAttrib(uint Bits);

    [DllImport(ILDLL, CallingConvention = CallingConvention.StdCall)]
    [return: MarshalAs(UnmanagedType.U1)]
    private static extern bool ilSave(uint Type, [MarshalAs(UnmanagedType.LPStr), In] string FileName);

    [DllImport(ILDLL, CallingConvention = CallingConvention.StdCall)]
    [return: MarshalAs(UnmanagedType.U1)]
    private static extern bool ilSaveImage([MarshalAs(UnmanagedType.LPStr), In] string FileName);

    [DllImport(ILDLL, CallingConvention = CallingConvention.StdCall)]
    private static extern uint ilSaveL(uint Type, IntPtr Lump, uint Size);

    [DllImport(ILDLL, CallingConvention = CallingConvention.StdCall)]
    [return: MarshalAs(UnmanagedType.U1)]
    private static extern bool ilSetData(IntPtr Data);

    [DllImport(ILDLL, CallingConvention = CallingConvention.StdCall)]
    [return: MarshalAs(UnmanagedType.U1)]
    private static extern bool ilSetDuration(uint Duration);

    [DllImport(ILDLL, CallingConvention = CallingConvention.StdCall)]
    private static extern void ilSetInteger(uint Mode, int Param);

    [DllImport(ILDLL, CallingConvention = CallingConvention.StdCall)]
    private static extern void ilSetPixels(int XOff, int YOff, int ZOff, uint Width, uint Height, uint Depth, uint Format, uint Type, IntPtr Data);

    [DllImport(ILDLL, CallingConvention = CallingConvention.StdCall)]
    private static extern void ilSetString(uint Mode, [MarshalAs(UnmanagedType.LPStr), In] string String);

    [DllImport(ILDLL, CallingConvention = CallingConvention.StdCall)]
    private static extern void ilShutDown();

    [DllImport(ILDLL, CallingConvention = CallingConvention.StdCall)]
    [return: MarshalAs(UnmanagedType.U1)]
    private static extern bool ilSurfaceToDxtcData(uint Format);

    [DllImport(ILDLL, CallingConvention = CallingConvention.StdCall)]
    [return: MarshalAs(UnmanagedType.U1)]
    private static extern bool ilTexImage(uint Width, uint Height, uint Depth, byte Bpp, uint Format, uint Type, IntPtr Data);

    [DllImport(ILDLL, CallingConvention = CallingConvention.StdCall)]
    [return: MarshalAs(UnmanagedType.U1)]
    private static extern bool ilTexImageDxtc(int Width, int Height, int Depth, uint DxtFormat, IntPtr Data);

    [DllImport(ILDLL, CallingConvention = CallingConvention.StdCall)]
    private static extern uint ilTypeFromExt([MarshalAs(UnmanagedType.LPStr), In] string FileName);

    [DllImport(ILDLL, CallingConvention = CallingConvention.StdCall)]
    [return: MarshalAs(UnmanagedType.U1)]
    private static extern bool ilTypeFunc(uint Mode);

    [DllImport(ILDLL, CallingConvention = CallingConvention.StdCall)]
    [return: MarshalAs(UnmanagedType.U1)]
    private static extern bool ilLoadData([MarshalAs(UnmanagedType.LPStr), In] string FileName, uint Width, uint Height, uint Depth, byte Bpp);

    [DllImport(ILDLL, CallingConvention = CallingConvention.StdCall)]
    [return: MarshalAs(UnmanagedType.U1)]
    private static extern bool ilLoadDataL(IntPtr Lump, uint Size, uint Width, uint Height, uint Depth, byte Bpp);
  }
}
