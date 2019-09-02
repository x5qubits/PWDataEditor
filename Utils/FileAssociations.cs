using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public class FileAssociation
{
    public string Extension { get; set; }
    public string ProgId { get; set; }
    public string FileTypeDescription { get; set; }
    public string ExecutableFilePath { get; set; }
    public bool IsAdd { get; set; }
    public int AppId { get; set; }
}

public class FileAssociations
{
    // needed so that Explorer windows get refreshed after the registry is updated
    [System.Runtime.InteropServices.DllImport("Shell32.dll")]
    private static extern int SHChangeNotify(int eventId, int flags, IntPtr item1, IntPtr item2);

    private const int SHCNE_ASSOCCHANGED = 0x8000000;
    private const int SHCNF_FLUSH = 0x1000;

    public static void EnshurePckAssociations()
    {
        FileAssociation fa = new FileAssociation();
        fa.ExecutableFilePath = Application.ExecutablePath;
        fa.FileTypeDescription = "Test";
        fa.IsAdd = true;
        fa.Extension = ".pck";
        fa.ProgId = "Perfect World Editor By JHS.";
        FileAssociations.EnsureAssociationsSet(fa);
    }

    public static void EnsureAssociationsSet(params FileAssociation[] associations)
    {
        bool madeChanges = false;
        foreach (FileAssociation association in associations)
        {

            madeChanges = true;
            if (association.IsAdd)
                SetAssociation(association.Extension, association.ProgId, association.FileTypeDescription, association.ExecutableFilePath, association.AppId);
            else
                DelAssociation(association.Extension, association.ProgId, association.FileTypeDescription, association.ExecutableFilePath, association.AppId);
        }
        if (madeChanges)
        {
            SHChangeNotify(SHCNE_ASSOCCHANGED, SHCNF_FLUSH, IntPtr.Zero, IntPtr.Zero);
        }
    }

    public static bool SetAssociation(string extension, string progId, string fileTypeDescription, string applicationFilePath, int AppId)
    {
        bool madeChanges = false;
        madeChanges |= SetKeyDefaultValue(@"Software\Classes\" + extension, progId);
        madeChanges |= SetKeyDefaultValue(@"Software\Classes\" + progId, progId);
        madeChanges |= SetKeyDefaultValue($@"Software\Classes\{progId}\shell\open\command", "\"" + applicationFilePath + "\"\"-start "+ AppId+" -path %1\"");
        return madeChanges;
    }

    public static bool DelAssociation(string extension, string progId, string fileTypeDescription, string applicationFilePath, int AppId)
    {
        bool madeChanges = false;
        madeChanges |= RemoveKeyDefaultValue(@"Software\Classes\" + extension, progId);
        madeChanges |= RemoveKeyDefaultValue(@"Software\Classes\" + progId, progId);
        madeChanges |= RemoveKeyDefaultValue($@"Software\Classes\{progId}\shell\open\command", "\"" + applicationFilePath + "\"\"-start " + AppId + " -path %1\"");
        return madeChanges;
    }

    private static bool SetKeyDefaultValue(string keyPath, string value)
    {
        try
        {
            using (var key = Registry.CurrentUser.CreateSubKey(keyPath))
            {
                if (key.GetValue(null) as string != value)
                {
                    key.SetValue(null, value);
                    return true;
                }
            }
        }
        catch
        {
            MessageBox.Show("Please run program as administrator!");
        }

        return false;
    }

    private static bool RemoveKeyDefaultValue(string keyPath, string value)
    {

            try
            {
                Registry.CurrentUser.DeleteSubKey(keyPath);
            }
            catch { MessageBox.Show("Please run program as administrator!"); }

        return false;
    }
}