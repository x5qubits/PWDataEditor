using JHUI;
using Newtonsoft.Json;
using PWDataEditorPaied.Classes;
using PWDataEditorPaied.helper_classes;
using PWDataEditorPaied.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PWDataEditorPaied.Database
{
    public class PreferencesManager
    {
        public static DialogResult XMessageBox = DialogResult.No;
        private static readonly PreferencesManager instance = new PreferencesManager();
        public static PreferencesManager Instance
        {
            get
            {
                return instance;
            }
        }

        public string DATA_FILENAME { get; private set; }
        public string Data2 { get; private set; }
        public Licence Data {
            get
            {
                return Get().Data;
            }
            set
            {
                Preferences pref = Get();
                pref.Data = value;
            }
        }

        private PreferencesManager() {}

        private string tobase64(string ddata)
        {
            return Convert.ToBase64String(Encoding.ASCII.GetBytes(ddata));
        }

        private string frombase64(string ddata)
        {
            return Encoding.ASCII.GetString(Convert.FromBase64String(ddata));
        }

        public void Set(Preferences data)
        {
            var encoding = new UTF8Encoding();
            string keyper = JsonConvert.SerializeObject(data);
            var iv = Iu.IV;
            var key = "hexdiez822443idx";
            PK pk = new PK(encoding.GetBytes(iv));
            string ms = pk.Eside(keyper, key);
            string final = tobase64(ms);
            File.WriteAllText(DATA_FILENAME, final, Encoding.ASCII);
        }

        public Preferences Get(LICENCETYPE type = LICENCETYPE.TIMED)
        {
            DATA_FILENAME = Path.GetDirectoryName(Application.ExecutablePath) + Path.DirectorySeparatorChar + "preferences.pwde";
            if (File.Exists(DATA_FILENAME))
            {

                try
                {
                    string file = File.ReadAllText(DATA_FILENAME, Encoding.ASCII);
                    this.Data2 = file;
                }
                catch
                {
                    try
                    {
                        File.WriteAllText(DATA_FILENAME, "", Encoding.ASCII); //ZERO THE FILE
                    }
                    catch { }
                }

            }
            //LIGHT SKIN
            JThemeStyle[] teme = new JThemeStyle[] {
            JThemeStyle.Dark, //Profile Editor
            JThemeStyle.Dark, //Admin Editor
            JThemeStyle.Dark, //Element Editor
            JThemeStyle.Dark, //Task Editor
            JThemeStyle.Dark,//DOmain Editor
            JThemeStyle.Dark, //AI
            JThemeStyle.Dark,//PK EDITOR
            JThemeStyle.Dark,//REGION
            JThemeStyle.Dark,//PRE
            JThemeStyle.Dark,//World
            JThemeStyle.Dark,//World
            JThemeStyle.Dark,//World
            JThemeStyle.Dark,//World
            JThemeStyle.Dark,//World
            JThemeStyle.Dark,//World
            JThemeStyle.Dark,//World
            JThemeStyle.Dark,//World
            JThemeStyle.Dark,//World
            JThemeStyle.Dark,//World
            JThemeStyle.Dark,//World
            JThemeStyle.Dark,//World
            JThemeStyle.Dark,//World
            JThemeStyle.Dark,//World
            JThemeStyle.Dark,//World
            JThemeStyle.Dark,//World
            JThemeStyle.Dark,//World
            JThemeStyle.Dark,//World
            JThemeStyle.Dark,//World
            JThemeStyle.Dark,//World
            JThemeStyle.Dark//Dyin
            };
            JColorStyle[] color = new JColorStyle[] {
            JColorStyle.White, //EL EDITOR
            JColorStyle.White, //EL EDITOR
            JColorStyle.White, //EL EDITOR
            JColorStyle.White, //EL EDITOR
            JColorStyle.White, //EL EDITOR
            JColorStyle.White, //EL EDITOR
            JColorStyle.White, //EL EDITOR
            JColorStyle.White, //EL EDITOR
            JColorStyle.White, //EL EDITOR
            JColorStyle.White, //EL EDITOR
            JColorStyle.White, //EL EDITOR
            JColorStyle.White, //EL EDITOR
            JColorStyle.White, //EL EDITOR
            JColorStyle.White, //EL EDITOR
            JColorStyle.White, //EL EDITOR
            JColorStyle.White, //EL EDITOR
            JColorStyle.White, //EL EDITOR
            JColorStyle.White, //EL EDITOR
            JColorStyle.White, //EL EDITOR
            JColorStyle.White, //EL EDITOR
            JColorStyle.White, //EL EDITOR
            JColorStyle.White, //EL EDITOR
            JColorStyle.White, //EL EDITOR
            JColorStyle.White, //EL EDITOR
            JColorStyle.White, //EL EDITOR
            JColorStyle.White, //EL EDITOR
            JColorStyle.White, //EL EDITOR
            JColorStyle.White, //EL EDITOR
            JColorStyle.White, //EL EDITOR
            JColorStyle.White
            };
            if (Data2 != null && Data2.Length > 0)
            {
                try
                {
                    var encoding = new UTF8Encoding();
                    string keyper = frombase64(Data2);
                    var iv = Iu.IV;
                    var key = "hexdiez822443idx";
                    PK pk = new PK(encoding.GetBytes(iv));
                    string ms = pk.Deside(keyper, key);
                    Preferences prefx = JsonConvert.DeserializeObject<Preferences>(ms);
                    if(prefx.teme.Length != teme.Length)
                    {
                        prefx.teme = teme;
                    }
                    if (prefx.color.Length != color.Length)
                    {
                        prefx.color = color;
                    }
                    return prefx;
                }
                catch { }
            }
            return new Preferences(2);
        }
    }

    [Serializable]
    public class Preferences
    {
        public bool autonewId { get; set; } = false;
        public bool autoPack { get; set; } = false;
        public bool registerDataExtension { get; set; } = false;
        public bool registerPckExtension { get; set; } = false;
        public bool allTimeOntop { get; set; } = true;
        public bool RememberLastLocation { get; set; } = true;
        public int type { get; set; }
        public JColorStyle[] color { get; set; }
        public JThemeStyle[] teme { get; set; }
        public bool DisplayMinimize { get; set; } = false;
        public bool HideFormCompleatlyOnClose { get; set; } = false;
        public Point LastLocation { get; set; } = Point.Empty;
        public bool ShowElementOnStart { get; set; } = true;
        public Licence Data { get; set; } = new Licence();
        public HashSet<BookMark> bookmarks { get; set; } = new HashSet<BookMark>();

        public Preferences(int type)
        {
            this.type = type;
            Constructor();
        }

        private void Constructor()
        {
            teme = new JThemeStyle[] {
            JThemeStyle.Dark, //Profile Editor
            JThemeStyle.Dark, //Admin Editor
            JThemeStyle.Dark, //Element Editor
            JThemeStyle.Dark, //Task Editor
            JThemeStyle.Dark,//DOmain Editor
            JThemeStyle.Dark, //AI
            JThemeStyle.Dark,//PK EDITOR
            JThemeStyle.Dark,//REGION
            JThemeStyle.Dark,//PRE
            JThemeStyle.Dark,//World
            JThemeStyle.Dark,//World
            JThemeStyle.Dark,//World
            JThemeStyle.Dark,//World
            JThemeStyle.Dark,//World
            JThemeStyle.Dark,//World
            JThemeStyle.Dark,//World
            JThemeStyle.Dark,//World
            JThemeStyle.Dark,//World
            JThemeStyle.Dark,//World
            JThemeStyle.Dark,//World
            JThemeStyle.Dark,//World
            JThemeStyle.Dark,//World
            JThemeStyle.Dark,//World
            JThemeStyle.Dark,//World
            JThemeStyle.Dark,//World
            JThemeStyle.Dark,//World
            JThemeStyle.Dark,//World
            JThemeStyle.Dark,//World
            JThemeStyle.Dark,//World
            JThemeStyle.Dark//Dyin
            };
            color = new JColorStyle[] {
            JColorStyle.White, //EL EDITOR
            JColorStyle.White, //EL EDITOR
            JColorStyle.White, //EL EDITOR
            JColorStyle.White, //EL EDITOR
            JColorStyle.White, //EL EDITOR
            JColorStyle.White, //EL EDITOR
            JColorStyle.White, //EL EDITOR
            JColorStyle.White, //EL EDITOR
            JColorStyle.White, //EL EDITOR
            JColorStyle.White, //EL EDITOR
            JColorStyle.White, //EL EDITOR
            JColorStyle.White, //EL EDITOR
            JColorStyle.White, //EL EDITOR
            JColorStyle.White, //EL EDITOR
            JColorStyle.White, //EL EDITOR
            JColorStyle.White, //EL EDITOR
            JColorStyle.White, //EL EDITOR
            JColorStyle.White, //EL EDITOR
            JColorStyle.White, //EL EDITOR
            JColorStyle.White, //EL EDITOR
            JColorStyle.White, //EL EDITOR
            JColorStyle.White, //EL EDITOR
            JColorStyle.White, //EL EDITOR
            JColorStyle.White, //EL EDITOR
            JColorStyle.White, //EL EDITOR
            JColorStyle.White, //EL EDITOR
            JColorStyle.White, //EL EDITOR
            JColorStyle.White, //EL EDITOR
            JColorStyle.White, //EL EDITOR
            JColorStyle.White
            };         
        }
    }
}
