using Microsoft.Win32;
using System;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Net;
using PWDataEditorPaied.Properties;
using PWDataEditorPaied.Classes;
using JHUI.Utils;
using PWDataEditorPaied.Database;
using NSUpdateManager;
using ElementEditor;

public enum LICSTATUS
{
    INITIATING,
    READY,
    UNACTIVATED
}

public enum LICENCETYPE
{
    TIMED,
    ADMIN,
    PERMANENT
}

public class LicenceManager
{
    #region PROTECTED
    protected readonly string keyName = "AABBGJHS"; // SENSITIVE VAR
    protected readonly string URL = "http://licence.jhsoftware.pro/PWTOOL/index.php"; // SENSITIVE VAR
    #endregion

    #region VARS
    internal static int TimeLeft = 0;
    protected static string msg = "";
    internal static string message
    {
        get
        {
            try
            {
                return Encoding.ASCII.GetString(Convert.FromBase64String(msg));
            }
            catch
            {
                return msg;
            }
        }
        set
        {
            msg = value;
        }

    }
    protected static readonly LicenceManager instance = new LicenceManager();
    internal LICSTATUS status = LICSTATUS.INITIATING;
    protected const long ONE_MINUTE_MILISECOND = 60000;
    protected bool isActivated;
    internal static LicenceManager Instance
    {
        get
        {
            return instance;
        }
    }
    internal string Cn { get; private set; }
    internal readonly string Xp = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Activate");
    internal string LicenceName = "0";
    internal static LICENCETYPE type = LICENCETYPE.TIMED;
    internal static volatile int[] Products;
    #endregion

    #region CONSTRUCTOR
    protected LicenceManager() { status = LICSTATUS.INITIATING; }
    #endregion

    #region REGISTRY
    internal string getValue(bool save = false)
    {
        string val = "";
        try
        {

            if (save)
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\WIN32VALUES2");
                if (key != null)
                {
                    val = key.GetValue(keyName).ToString();
                    key.Close();
                    if (save)
                    {
                        if (val.Length < 10)
                        {
                            val = Iu.Value();
                            SetValue(val);
                        }
                    }
                }
                else
                {
                    val = Iu.Value();
                    SetValue(val);
                }
            }
            else
            {
                if (val.Length < 10)
                {
                    val = Iu.Value();
                    if (save)
                    {
                        SetValue(val);
                    }
                }
            }
        }
        catch { }
        return val;
    }

    internal void SetValue(string val)
    {
        RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\WIN32VALUES2");
        if (key != null)
        {
            //Set
        }
        else
        {
            key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\WIN32VALUES2");
            if (key != null)
            {
                key.SetValue(keyName, val);
            }
        }
        try { key.Close(); } catch (Exception) { }
    }
    #endregion

    #region COMMUNICATE WITH SERVER
    internal byte[] FromBase64String(string str)
    {
        var decbuff = Convert.FromBase64String(str);
        return decbuff;
    }

    internal string DecryptRJ256(byte[] cypher, string KeyString, string IVString)
    {
        var sRet = "";
        var encoding = new UTF8Encoding();
        var Key = encoding.GetBytes(KeyString);
        var IV = encoding.GetBytes(IVString);
        using (var rj = new RijndaelManaged())
        {
            try
            {
                rj.Padding = PaddingMode.PKCS7;
                rj.Mode = CipherMode.CBC;
                rj.KeySize = 256;
                rj.BlockSize = 256;
                rj.Key = Key;
                rj.IV = IV;
                var ms = new MemoryStream(cypher);

                using (var cs = new CryptoStream(ms, rj.CreateDecryptor(Key, IV), CryptoStreamMode.Read))
                {
                    using (var sr = new StreamReader(cs))
                    {
                        sRet = sr.ReadLine();
                    }
                }
            }
            finally
            {
                rj.Clear();
            }
        }

        return sRet;
    }

    protected string tobase64(string ddata)
    {
        return Convert.ToBase64String(Encoding.ASCII.GetBytes(ddata));
    }

    protected string frombase64(string ddata)
    {
        return Encoding.ASCII.GetString(Convert.FromBase64String(ddata));
    }

    private string CreateMD5(string input)
    {
        // Use input string to calculate MD5 hash
        using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
        {
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            // Convert the byte array to hexadecimal string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }

    internal Licence GetFromPath(string path)
    {
        return JsonConvert.DeserializeObject<Licence>(frombase64(File.ReadAllText(path)));
    }

    internal void SaveToPath(string path, Licence data)
    {
        string jsonText = tobase64(JsonConvert.SerializeObject(data));
        File.WriteAllText(path, jsonText);


    }

    internal void SaveLicence(Licence data)
    {
        Preferences pref = PreferencesManager.Instance.Get();
        pref.Data = data;
        PreferencesManager.Instance.Set(pref);
    }

    internal Licence GetLicence()
    {
        Preferences pref = PreferencesManager.Instance.Get();
        if (pref.Data != null)
        {
            try
            {
                Licence licence = pref.Data;
                if(licence == null)
                {
                    return null;
                }
                if (
                    licence.RecheckTime < Time.timeStampMilisecond //IS TIME TO RECHECK LICENCE
                    || 1519026394394 > Time.timeStampMilisecond //USER MODIFIED THE TIMEDATE
                 )
                {
                    return null;
                }
                else
                {
                    if (
                        licence.OpenTimes >= licence.MaxTimes //TIME TO RECHECK
                        || licence.MaxTimes > 5 //USER MODIFIED THE SETTING
                        )
                    {
                        return null;
                    }
                }
                return licence;
            }
            catch { }
        }
        return null;
    }

    private async Task<string> GetResponse(string url)
    {
        try
        {
            using (WebClient httpClient = new WebClient())
            {
                string response = await httpClient.DownloadStringTaskAsync(new Uri(url));
                return response;
            }
        }
        catch
        {

        }
        return null;
    }
    #endregion

    #region CHECK
        
    internal async Task<bool> CheckLicenceAsync(bool increment = true)
    {
        #region SEE IF NEEDS TO CHECK ONLINE
        string iO = getValue(false);
        Cn = CreateMD5(Environment.MachineName);
        if (iO.Length < 2)
        {
            status = LICSTATUS.UNACTIVATED;
            return false;
        }
        Licence licence = GetLicence();
        bool checkOn = false;
        if (licence == null)
        {
            checkOn = true;
            if (VirtualMachineDetector.Assert())
            {
                status = LICSTATUS.UNACTIVATED;
                return false;
            }
        }
        #endregion
        #region CHECK ONLINE
        if (checkOn)
        {
            try
            {
                Dictionary<string, Object> datax = new Dictionary<string, Object>();
                datax["user"] = tobase64(iO);
                datax["ruser"] = tobase64(Cn);
                datax["computer"] = tobase64(Iu.MotherBoard);
                string datapost = tobase64(JsonConvert.SerializeObject(datax));
                string url = URL + "?par=" + datapost;


                string json = await GetResponse(url).ConfigureAwait(false);
                if (json != null)
                {
                    Dictionary<string, Object> dataen = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
                    var keyper = dataen["value"].ToString();
                    var iv = "45287112549354892144548565451985";
                    var key = "hexdiez822443idx";
                    string ms = DecryptRJ256(FromBase64String(keyper), key, iv);
                    Dictionary<string, object> response = JsonConvert.DeserializeObject<Dictionary<string, object>>(ms);
                    string dkey = response["u"].ToString();
                    LicenceName = response["x"].ToString();
                    bool isNew = bool.Parse(response["b"].ToString());
                    LicenceManager.TimeLeft = int.Parse(response["a"].ToString());
                    bool a = LicenceManager.TimeLeft > 0;
                    int max = int.Parse(response["r"].ToString());
                    if (response["z"].ToString() == "PERMANENT")
                    {
                        type = LICENCETYPE.PERMANENT;
                        a = true;
                    }
                    else if (response["z"].ToString() == "ADMIN")
                    {
                        type = LICENCETYPE.ADMIN;
                        a = true;
                    }
                    else
                    {
                        type = LICENCETYPE.TIMED;
                    }

                    LicenceManager.message = response["m"].ToString();
                    isActivated = iO.Equals(dkey) && a;
                    if(!File.Exists(Xp))
                        File.WriteAllText(Xp, iO.Substring(0, iO.Length - 5)+"%");

                    if (isActivated)
                    {
                        Products = JsonConvert.DeserializeObject<int[]>(frombase64(response["p"].ToString()));
                        Licence Licence = new Licence
                        {
                            LicenceName = LicenceName,
                            HardwereHash = iO,
                            HardwereName = Cn,
                            Products = Products,
                            MaxTimes = max,
                            OpenTimes = 0,
                            Msg = LicenceManager.message,
                            Type = (int)type
                        };
                        if (a)
                        {
                            Licence.RecheckTime = Time.timeStampMilisecond + ONE_MINUTE_MILISECOND * 60; //1 hour
                            SaveLicence(Licence);
                            status = LICSTATUS.READY;
                            return true;
                        }
                        else
                        {
                            status = LICSTATUS.UNACTIVATED;
                        }
                        return true;
                    }
                    else
                    {
                        status = LICSTATUS.UNACTIVATED;
                    }
                }
                else
                {
                    status = LICSTATUS.UNACTIVATED;
                }

                return false;

            }
            catch { status = LICSTATUS.UNACTIVATED; return false; }
        }
        #endregion
        #region OFFLINE
        else
        {
            if (licence == null)
            {
                status = LICSTATUS.UNACTIVATED;
                return false;
            }
            else
            {
                isActivated = true;
                Products = licence.Products;
                LicenceManager.message = licence.Msg;
                LicenceName = licence.LicenceName;
                type = (LICENCETYPE)licence.Type;
                if (increment)
                    licence.OpenTimes++; //Increment OpenTimes

                SaveLicence(licence);
                status = LICSTATUS.READY;
                return true;
            }
        }
        #endregion
    }
    #endregion
}

