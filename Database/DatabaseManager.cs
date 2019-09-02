using PWDataEditorPaied.Properties;
using PWDataEditorPaied.PW_Admin_classes;
using sTASKedit;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevIL;
using Ultimate_Editor.Clases.AngelicaFileManager;
using PWDataEditorPaied.AngelicaFileManager;
using Gpckx;
using System.Linq;
using System.Threading;
using System.Drawing.Imaging;
using PWDataEditorPaied.helper_classes;
using Newtonsoft.Json;
using PWDataEditorPaied.Classes;

namespace PWDataEditorPaied.Database
{
    public class DatabaseManager
    {
        public class FilePref
        {
            public LoadedElementConfigs loadedElementConfigs { get; set; } = new LoadedElementConfigs();
        }
        private Preferences pref;
        public static string DEFAULT_NAME = "JHSDEF";
        private static DatabaseManager instance;
        private DatabaseManager() { }
        public static DatabaseManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DatabaseManager();
                }
                return instance;
            }
        }

        public string DATA_FILENAME { get; private set; }

        private static Session DEFAULT_SESSION = new Session();
        private static Session CURRENT_SESSION = new Session();
        private static FilePref filePref = new FilePref();
        private PackHelper configspckManager;
        private PackHelper surfacespckManager;
        private string NNAME = "";
        public string _NAME
        {
            set
            {
                if (DATA_FILENAME != null && DATA_FILENAME.Length > 0)
                    SaveAll();
                pref = PreferencesManager.Instance.Get();
                DATA_FILENAME = Path.Combine(Application.StartupPath, "History", Iu.GetHash(value));
                 
                 loadAll();
                NNAME = value;
            }
            get
            {
                return NNAME;
            }
        }
        private CancellationTokenSource cts;
        private CancellationToken ct;
        public static bool Loaded = false;

        public bool AutoLoadPck
        {
            set
            {
                pref.autoPack = value;
            }
            get
            {
               return pref.autoPack;
            }
        }

        public int nextId
        {
            get
            {
                return filePref.loadedElementConfigs.nextId;
            }
            set
            {
                filePref.loadedElementConfigs.nextId = value;
            }
        }

        public int maxId
        {
            get
            {
                return filePref.loadedElementConfigs.maxId;
            }
            set
            {
                filePref.loadedElementConfigs.maxId = value;
            }
        }

        public bool autonewId
        {
            get
            {
                return pref.autonewId;
            }
            set
            {
                pref.autonewId = value;
            }
        }

        public HashSet<BookMark> BookMars
        {
            get
            {
                return pref.bookmarks;
            }
            set
            {
                pref.bookmarks = value;
            }
        }

        private void loadAll()
        {
            if (File.Exists(DATA_FILENAME))
            {

                try
                {
                    string file = File.ReadAllText(DATA_FILENAME, Encoding.ASCII);
                    filePref = JsonConvert.DeserializeObject<FilePref>(file);
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
        }

        public void SaveAll()
        {
            try
            {
                string json = JsonConvert.SerializeObject(filePref);
                File.WriteAllText(DATA_FILENAME, json, Encoding.ASCII);
            }
            catch
            {
            }
        }

        public void LoadDefault()
        {
            cts = new CancellationTokenSource();
            ct = cts.Token;
            DatabaseManager.Loaded = false;
            DEFAULT_SESSION = new Session();
            Task<bool>[] taskList = {
                    Task.Factory.StartNew(() => LoadAddonList()),
                    Task.Factory.StartNew(() => LoadLocalizationText()),
                    Task.Factory.StartNew(() => LoadInstanceList()),
                    Task.Factory.StartNew(() => LoadSkillList()),
                    Task.Factory.StartNew(() => LoadBuffList()),
                    Task.Factory.StartNew(() => LoadItemDescription()),
                    Task.Factory.StartNew(() => LoadRelayStationList()),
                    Task.Factory.StartNew(() => loadItem_color()),
                    Task.Factory.StartNew(() => loadSurfaces()),
                    Task.Factory.StartNew(() => loadItemList())
            };
            Task.WaitAll(taskList);
            DatabaseManager.Loaded = true;
        }

        public Session getDatabase(string path)
        {
            if (path != null && !path.Equals(DEFAULT_NAME))
            {
                return CURRENT_SESSION.Isready ? CURRENT_SESSION : DEFAULT_SESSION;
            }
            else
            {
                return DEFAULT_SESSION;
            }
        }

        public void updateSetting(bool AutoNextId, bool AutoLoadPck, int minNextId, int lastnextId)
        {
            pref.autonewId = AutoNextId;
            pref.autoPack = AutoLoadPck;
            PreferencesManager.Instance.Set(pref);
            filePref.loadedElementConfigs.nextId = minNextId;
            filePref.loadedElementConfigs.maxId = lastnextId;
            SaveAll();
        }

        #region BOOKMARKS
        public void AddBook(BookMark path)
        {
            pref.bookmarks.Add(path);
            PreferencesManager.Instance.Set(pref);
        }

        public void DelBook(BookMark path)
        {
            pref.bookmarks.Remove(path);
            PreferencesManager.Instance.Set(pref);
        }
        #endregion

        #region CREATE DATABASE
        public void CreateNewDatabase(string ElementEditorPath, int version)
        {
            _NAME = ElementEditorPath.ToLower();
            string surfacespck = Directory.GetParent(Path.GetDirectoryName(ElementEditorPath)).FullName + Path.DirectorySeparatorChar + "surfaces.pck";
            string configspck = Directory.GetParent(Path.GetDirectoryName(ElementEditorPath)).FullName + Path.DirectorySeparatorChar + "configs.pck";
            string world_targets = Directory.GetParent(Path.GetDirectoryName(ElementEditorPath)).FullName + Path.DirectorySeparatorChar + "maps" + Path.DirectorySeparatorChar + "world" + Path.DirectorySeparatorChar + "world_targets.txt";


            //GET FILES
            if (!File.Exists(surfacespck))
            {
                PackDatabase.Instance.Clear();
                return;
            }
            if (!File.Exists(configspck))
            {
                PackDatabase.Instance.Clear();
                return;
            }
            if (!File.Exists(world_targets))
            {
                PackDatabase.Instance.Clear();
                return;
            }
            cts.Cancel();
            cts = new CancellationTokenSource();
            ct = cts.Token;
            PackDatabase.Instance.Clear();
            CURRENT_SESSION.Clear();
            CURRENT_SESSION = null;

            GC.Collect();
            CURRENT_SESSION = new Session();
            CURRENT_SESSION.Version = version;
            CURRENT_SESSION.isredyC1 = CURRENT_SESSION.isredyC2 = CURRENT_SESSION.hasJustBecomeReady = false;

            configspckManager = PackDatabase.Instance.getManager("configs.pck", configspck, configsLoaded, true);
            surfacespckManager = PackDatabase.Instance.getManager("surfaces.pck", surfacespck, SurfacesLoaded, true);

            Task<bool>[] taskList = {
                    Task.Factory.StartNew(() => LoadAddonList(_NAME), ct), //LOAD FROM DEFAULT
                    Task.Factory.StartNew(() => LoadLocalizationText(_NAME), ct), //LOAD FROM DEFAULT
                    Task.Factory.StartNew(() => LoadInstanceList(_NAME), ct), //LOAD FROM DEFAULT
                    Task.Factory.StartNew(() => LoadRelayStationList(_NAME, new MemoryStream(File.ReadAllBytes(world_targets))), ct),
                    Task.Factory.StartNew(() => loadItemList(_NAME), ct) //item_list_index.txt
            };
            Task.WaitAll(taskList);

        }

        private void SurfacesLoaded()
        {
            string iconlist_ivtrmdds = @"surfaces\iconset\iconlist_ivtrm.dds".Replace('\\', Path.DirectorySeparatorChar).Replace('/', Path.DirectorySeparatorChar).ToLower();
            string iconlist_ivtrmtxt = @"surfaces\iconset\iconlist_ivtrm.txt".Replace('\\', Path.DirectorySeparatorChar).Replace('/', Path.DirectorySeparatorChar).ToLower();
            List<PckEntry> dd = surfacespckManager.getDirectory(Path.GetDirectoryName(iconlist_ivtrmdds), true, Path.GetFileName(iconlist_ivtrmdds));
            List<PckEntry> dd2 = surfacespckManager.getDirectory(Path.GetDirectoryName(iconlist_ivtrmtxt), true, Path.GetFileName(iconlist_ivtrmtxt));

            Task<bool>[] taskList = {
                    Task.Factory.StartNew(() => loadSurfaces(_NAME, new MemoryStream(dd[0].bytes),new MemoryStream(dd2[0].bytes)), ct) // iconlist_ivtrm.dds // txt
            };
            Task.WaitAll(taskList);
            CURRENT_SESSION.isredyC1 = true;
            CURRENT_SESSION.hasJustBecomeReady = CURRENT_SESSION.isredyC2;
            if (CURRENT_SESSION.hasJustBecomeReady)
            {
                PackDatabase.Instance.Clear();
            }
        }

        private void configsLoaded()
        {
            string skillstr = @"Configs\skillstr.txt";
            string buff_str = @"Configs\buff_str.txt";
            string item_ext_desc = @"Configs\item_ext_desc.txt";
            string item_color = @"Configs\item_color.txt";
            List<PckEntry> dd1 = configspckManager.getDirectory(Path.GetDirectoryName(skillstr), true, Path.GetFileName(skillstr));
            List<PckEntry> dd2 = configspckManager.getDirectory(Path.GetDirectoryName(buff_str), true, Path.GetFileName(buff_str));
            List<PckEntry> dd3 = configspckManager.getDirectory(Path.GetDirectoryName(item_ext_desc), true, Path.GetFileName(item_ext_desc));
            List<PckEntry> dd4 = configspckManager.getDirectory(Path.GetDirectoryName(item_color), true, Path.GetFileName(item_color));
            Task<bool>[] taskList = {
                    Task.Factory.StartNew(() => LoadSkillList(_NAME, new MemoryStream(dd1[0].bytes)), ct), //Configs//skillstr.txt
                    Task.Factory.StartNew(() => LoadBuffList(_NAME, new MemoryStream(dd2[0].bytes)), ct), //buff_str.txt
                    Task.Factory.StartNew(() => LoadItemDescription(_NAME, new MemoryStream(dd3[0].bytes)), ct), //item_ext_desc.txt
                    Task.Factory.StartNew(() => loadItem_color(_NAME, new MemoryStream(dd4[0].bytes)), ct),//item_color.txt
            };
            Task.WaitAll(taskList);
            CURRENT_SESSION.isredyC2 = true;
            CURRENT_SESSION.hasJustBecomeReady = CURRENT_SESSION.isredyC2;
            if (CURRENT_SESSION.hasJustBecomeReady)
            {
                PackDatabase.Instance.Clear();
            }
        }
        #endregion

        #region LOAD OTHERSESSION
        private bool loadItemList(string _NAME)
        {
            CURRENT_SESSION.task_items_list = DEFAULT_SESSION.task_items_list;
            return true;
        }
        private bool loadSurfaces(string _NAME, MemoryStream FileDDS, MemoryStream FileTXT)
        {
            string iconlist_ivtrm_img = Path.GetDirectoryName(Application.ExecutablePath) + "\\Configs\\Element\\Default\\iconlist_ivtrm.dds";
            return InconPacker.Instance.LoadFiles(iconlist_ivtrm_img);

        }
        public bool loadItem_color(string _NAME, MemoryStream File)
        {
            string line;
            Encoding enc = Encoding.GetEncoding("GBK");
            StreamReader file = new StreamReader(File, enc);
            CURRENT_SESSION.item_color = new SortedList<int, int>();
            int count = 0;
            while ((line = file.ReadLine()) != null)
            {
                string[] data = line.Split(null);
                try
                {
                    if (data.Length == 2)
                    {
                        String v1 = data[0].ToString();
                        String v2 = data[1].ToString();
                        if (v1.Length > 0 && v2.Length > 0)
                        {
                            CURRENT_SESSION.item_color.Add(Int32.Parse(v1), Int32.Parse(v2));
                        }
                        else
                        {
                            if (v1.Length > 0)
                            {
                                CURRENT_SESSION.item_color.Add(Int32.Parse(v1), 0);
                            }
                            if (v2.Length > 0)
                            {
                                CURRENT_SESSION.item_color.Add(0, Int32.Parse(v2));
                            }
                        }
                    }
                }
                catch (Exception) { }
                count++;
            }
            file.Close();
            return true;
        }
        private bool LoadAddonList(string _NAME)
        {
            CURRENT_SESSION.addonslist = new SortedList<string, string>(DEFAULT_SESSION.addonslist);
            return true;
        }
        public bool LoadRelayStationList(string _NAME, MemoryStream File)
        {
            try
            {
                StreamReader sr = new StreamReader(File, Encoding.Unicode);
                CURRENT_SESSION.world_targets = sr.ReadToEnd().Split(new char[2] { '\"', '\n' });

                sr.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR LOADING RELAY STATION LIST\n" + e.Message);
            }
            return true;
        }
        private bool LoadItemDescription(string _NAME, MemoryStream File)
        {
            string line;
            CURRENT_SESSION.item_desc = new SortedList<int, string>();
            Encoding enc = Encoding.GetEncoding("GBK");
            StreamReader file = new StreamReader(File, enc);
            int count = 0;

            while ((line = file.ReadLine()) != null)
            {
                if (line != null && line.Length > 0 && !line.StartsWith("#") && !line.StartsWith("/"))
                {
                    String[] data = line.Split('"');
                    try
                    {
                        CURRENT_SESSION.item_desc[Int32.Parse(data[0])] = data[1].ToString().Replace('"', ' ');
                    }
                    catch (Exception) { }
                }
                count++;
            }
            file.Close();
            return true;
        }
        public bool LoadBuffList(string _NAME, MemoryStream File)
        {
            try
            {
                StreamReader sr = new StreamReader(File, Encoding.Unicode);
                CURRENT_SESSION.buff_str = sr.ReadToEnd().Split(new char[] { '\"' });
                string[] temp = CURRENT_SESSION.buff_str[0].Split(new char[] { '\n' });
                CURRENT_SESSION.buff_str[0] = temp[temp.Length - 1];

                sr.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR LOADING BUFF LIST\n" + e.Message);
            }
            return true;
        }
        private bool LoadInstanceList(string _NAME)
        {
            CURRENT_SESSION.defaultMapsTemplate = new SortedList<int, Map>();
            CURRENT_SESSION.defaultMapsTemplate = new SortedList<int, Map>(DEFAULT_SESSION.defaultMapsTemplate);
            return true;
        }
        public bool LoadLocalizationText(string _NAME)
        {
            CURRENT_SESSION.LocalizationText = new SortedList<string, string>();
            CURRENT_SESSION.LocalizationText = new SortedList<string, string>(DEFAULT_SESSION.LocalizationText);
            return true;
        }
        public bool LoadSkillList(string _NAME, MemoryStream File)
        {
            try
            {
                StreamReader sr = new StreamReader(File, Encoding.Unicode);
                CURRENT_SESSION.skillstr = sr.ReadToEnd().Split(new char[] { '\"' });
                string[] temp = CURRENT_SESSION.skillstr[0].Split(new char[] { '\n' });
                CURRENT_SESSION.skillstr[0] = temp[temp.Length - 1];
                sr.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR LOADING SKILL LIST\n" + e.Message);
            }
            return true;
        }
        #endregion

        #region DEFAULT LOAD
        static public Bitmap getSkillIcon(int skillid)
        {
            Bitmap img = Properties.Resources.ResourceManager.GetObject("_" + skillid) as Bitmap;
            return img != null ? img : new Bitmap(new Bitmap(Resources.blank));
        }
        public Bitmap LoadImage(DevIL.ImageImporter ImImport, MemoryStream mStream, int width = 128, int height = 128)
        {
            try
            {
                Bitmap img2 = null;
                using (DevIL.Image IconImg = ImImport.LoadImageFromStream(mStream))
                {
                    IconImg.Bind();
                    using (var img = new Bitmap(IconImg.Width, IconImg.Height, PixelFormat.Format32bppArgb))
                    {
                        Rectangle rect = new Rectangle(0, 0, IconImg.Width, IconImg.Height);
                        BitmapData data = img.LockBits(rect, ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
                        DevIL.Unmanaged.IL.CopyPixels(0, 0, 0, IconImg.Width, IconImg.Height, 1, DevIL.DataFormat.BGRA, DevIL.DataType.UnsignedByte, data.Scan0);
                        img.UnlockBits(data);
                        img2 = (Bitmap)img.Clone();
                    }
                }
                return img2;
            }
            catch
            {
                return new Bitmap(width, height);
            }

        }
        private bool loadItemList()
        {
            string path = Path.GetDirectoryName(Application.ExecutablePath) + "\\Configs\\item_list_index.txt";
            if (File.Exists(path))
            {
                StreamReader sr = new StreamReader(path, Encoding.Unicode);
                DEFAULT_SESSION.task_items_list = sr.ReadToEnd().Split(new char[3] { '\t', '\n', ' ' });
                sr.Close();
            }
            path = Path.GetDirectoryName(Application.ExecutablePath) + "\\Configs\\item_list_index_191.txt";
            if (File.Exists(path))
            {
                StreamReader sr = new StreamReader(path, Encoding.Unicode);
                DEFAULT_SESSION.task_items_list191 = sr.ReadToEnd().Split(new char[3] { '\t', '\n', ' ' });
                sr.Close();
            }
            return true;
        }

        private bool loadSurfaces()
        {
            string surface = Path.GetDirectoryName(Application.ExecutablePath) + "\\Configs\\Gshop\\Images\\";
            DEFAULT_SESSION.gshopSurfaces = Directory.GetFiles(surface, "*.dds").Select(Path.GetFileName).ToArray();
            string iconlist_ivtrm_img = Path.GetDirectoryName(Application.ExecutablePath) + "\\Configs\\Element\\Default\\iconlist_ivtrm.dds";
            return InconPacker.Instance.LoadFiles(iconlist_ivtrm_img);

        }
        public bool loadItem_color()
        {
            string line;
            string iconlist_ivtrm = Path.GetDirectoryName(Application.ExecutablePath) + "\\Configs\\Element\\Default\\item_color.txt";
            Encoding enc = Encoding.GetEncoding("GBK");
            StreamReader file = new StreamReader(iconlist_ivtrm, enc);
            int count = 0;
            while ((line = file.ReadLine()) != null)
            {
                String[] data = line.Split(null);
                try
                {
                    if (data.Length == 2)
                    {
                        String v1 = data[0].ToString();
                        String v2 = data[1].ToString();
                        if (v1.Length > 0 && v2.Length > 0)
                        {
                            DEFAULT_SESSION.item_color.Add(Int32.Parse(v1), Int32.Parse(v2));
                        }
                        else
                        {
                            if (v1.Length > 0)
                            {
                                DEFAULT_SESSION.item_color.Add(Int32.Parse(v1), 0);
                            }
                            if (v2.Length > 0)
                            {
                                DEFAULT_SESSION.item_color.Add(0, Int32.Parse(v2));
                            }
                        }
                    }
                }
                catch (Exception) { }
                count++;
            }
            file.Close();
            return true;
        }

        public bool LoadAddonList()
        {
            DEFAULT_SESSION.addonslist = new SortedList<string, string>();//<string, string>();
            if (File.Exists(Application.StartupPath + "\\Configs\\Element\\Default\\item_ext_prop.txt"))
            {
                try
                {
                    StreamReader streamReader = new StreamReader(Application.StartupPath + "\\Configs\\Element\\Default\\item_ext_prop.txt", Encoding.GetEncoding("GBK"));
                    while (!streamReader.EndOfStream)
                    {
                        string str1 = streamReader.ReadLine();
                        if (str1.StartsWith("type:"))
                        {
                            int int32 = Convert.ToInt32(str1.Substring(5).Trim());
                            if (streamReader.ReadLine().StartsWith("{"))
                            {
                                string str2;
                                while (!(str2 = streamReader.ReadLine()).StartsWith("}"))
                                {
                                    string[] strArray = str2.Split(',');
                                    for (int index = 0; index < strArray.Length; ++index)
                                    {
                                        strArray[index] = strArray[index].Trim();
                                        if (strArray[index] != "")
                                            ///GlobalProgramData.addonslist.Add(strArray[index], int32);
                                            DEFAULT_SESSION.addonslist.Add(strArray[index], int32.ToString());
                                    }
                                }
                            }
                        }
                    }
                    streamReader.Close();
                }
                catch (Exception ex)
                {
                    int num = (int)MessageBox.Show("ERROR LOADING ADDON LIST\n" + ex.Message);
                }
            }
            else
            {
                int num1 = (int)MessageBox.Show("NOT FOUND item_ext_prop.txt!");
            }
            return true;
        }
/*
        private bool LoadAddonList()
        {
            String path = Path.GetDirectoryName(Application.ExecutablePath) + "\\Configs\\Element\\Default\\addon_table.txt";
            if (File.Exists(path))
            {
                try
                {
                    StreamReader sr = new StreamReader(path, Encoding.Unicode);

                    char[] seperator = new char[] { '\t' };
                    string line;
                    string[] split;
                    while (!sr.EndOfStream)
                    {
                        line = sr.ReadLine();
                        if (line.Contains("\t") && line != "" && !line.StartsWith("/") && !line.StartsWith("#"))
                        {
                            split = line.Split(seperator);
                            DEFAULT_SESSION.addonslist.Add(split[0], split[1]);
                        }
                    }

                    sr.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show("ERROR LOADING ADDON LIST\n" + e.Message);
                }
            }
            else
            {
                MessageBox.Show("NOT FOUND! " + path);
            }
            return true;
        }
        */
        public bool LoadRelayStationList()
        {
            String path = Path.GetDirectoryName(Application.ExecutablePath) + "\\Configs\\Element\\Default\\world_targets.txt";
            if (File.Exists(path))
            {
                try
                {
                    StreamReader sr = new StreamReader(path, Encoding.Unicode);
                    DEFAULT_SESSION.world_targets = sr.ReadToEnd().Split(new char[2] { '\"', '\n' });

                    sr.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show("ERROR LOADING RELAY STATION LIST\n" + e.Message);
                }
            }
            else
            {
                MessageBox.Show("NOT FOUND " + path);
            }
            return true;
        }
        private bool LoadItemDescription()
        {
            string line;
            DEFAULT_SESSION.item_desc = new SortedList<int, string>();
            string iconlist_ivtrm = Path.GetDirectoryName(Application.ExecutablePath) + @"\\Configs\\Element\\Default\\item_ext_desc.txt";
            Encoding enc = Encoding.GetEncoding("GBK");
            int lines = File.ReadAllLines(iconlist_ivtrm).Length;
            StreamReader file = new StreamReader(iconlist_ivtrm, enc);
            int count = 0;

            while ((line = file.ReadLine()) != null)
            {
                if (line != null && line.Length > 0 && !line.StartsWith("#") && !line.StartsWith("/"))
                {
                    String[] data = line.Split('"');
                    try
                    {
                        int index = 0;
                        bool ddd = int.TryParse(data[0], out index);
                        if(ddd)
                        DEFAULT_SESSION.item_desc[index] = data[1].ToString().Length > 0 ? data[1].ToString().Replace('"', ' '):"";
                    }
                    catch (Exception) { }
                }
                count++;
            }
            file.Close();
            return true;
        }
        public bool LoadBuffList()
        {
            String path = Path.GetDirectoryName(Application.ExecutablePath) + "\\Configs\\Element\\Default\\buff_str.txt";
            if (File.Exists(path))
            {
                try
                {
                    StreamReader sr = new StreamReader(path, Encoding.Unicode);
                    DEFAULT_SESSION.buff_str = sr.ReadToEnd().Split(new char[] { '\"' });
                    string[] temp = DEFAULT_SESSION.buff_str[0].Split(new char[] { '\n' });
                    DEFAULT_SESSION.buff_str[0] = temp[temp.Length - 1];

                    sr.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show("ERROR LOADING BUFF LIST\n" + e.Message);
                }
            }
            else
            {
                MessageBox.Show("NOT FOUND localization\\buff_str.txt!");
            }
            return true;
        }
        private bool LoadInstanceList()
        {
            DEFAULT_SESSION.defaultMapsTemplate = new SortedList<int, Map>();
            String path = Path.GetDirectoryName(Application.ExecutablePath) + "\\Configs\\instance_en.txt";
            if (File.Exists(path))
            {
                try
                {
                    StreamReader sr = new StreamReader(path, Encoding.Unicode);
                    char[] seperator = new char[] { '\t' };
                    string line;
                    string[] split;
                    while (!sr.EndOfStream)
                    {
                        line = sr.ReadLine();
                        if (line.Contains("\t") && line != "" && !line.StartsWith("/") && !line.StartsWith("#"))
                        {
                            split = line.Split(seperator);
                            if (split.Length > 2)
                            {
                                Map map = new Map();
                                map.name = split[3];
                                map.realName = split[2];
                                DEFAULT_SESSION.defaultMapsTemplate.Add(Int32.Parse(split[0]), map);
                            }
                        }
                    }
                    sr.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show("ERROR LOADING INSTANCE LIST\n" + e.Message);
                }
            }
            else
            {
                MessageBox.Show("ERROR LOADING INSTANCE LIST:" + path + "!");
            }
            return true;
        }
        public string[] getbuffList(string path)
        {
            if (path != null && !path.Equals(DEFAULT_NAME))
            {
                return CURRENT_SESSION.Isready ? CURRENT_SESSION.buff_str : DEFAULT_SESSION.buff_str;
            }
            else
            {
                return DEFAULT_SESSION.buff_str;
            }
        }
        public string[] getSkillList(string path)
        {
            if (path != null && !path.Equals(DEFAULT_NAME))
            {
                return CURRENT_SESSION.Isready ? CURRENT_SESSION.skillstr : DEFAULT_SESSION.skillstr;
            }
            else
            {
                return DEFAULT_SESSION.skillstr;
            }
        }
        public SortedList<int, Map> getInstanceList()
        {
            return DEFAULT_SESSION.defaultMapsTemplate;
        }
        public bool LoadLocalizationText()
        {
            DEFAULT_SESSION.LocalizationText = new SortedList<string, string>();

            using (StreamReader sr = new StreamReader(new MemoryStream(Encoding.UTF8.GetBytes(Resources.language_en))))
            {
                char[] seperator = new char[] { '"' };
                string line;
                string[] split;
                while (!sr.EndOfStream)
                {
                    line = sr.ReadLine();
                    if (line != "" && !line.StartsWith("/") && !line.StartsWith("#"))
                    {
                        split = line.Split(seperator);
                        DEFAULT_SESSION.LocalizationText.Add(split[0].Trim(), split[1]);
                    }
                }
            }

            return true;
        }
        public SortedList<string, string> GetLocalizationText()
        {
            return DEFAULT_SESSION.LocalizationText;
        }
        public bool LoadSkillList()
        {
            String path = Path.GetDirectoryName(Application.ExecutablePath) + "\\Configs\\Element\\Default\\skillstr.txt";
            if (File.Exists(path))
            {
                try
                {
                    StreamReader sr = new StreamReader(path, Encoding.Unicode);
                    DEFAULT_SESSION.skillstr = sr.ReadToEnd().Split(new char[] { '\"' });
                    string[] temp = DEFAULT_SESSION.skillstr[0].Split(new char[] { '\n' });
                    DEFAULT_SESSION.skillstr[0] = temp[temp.Length - 1];
                    sr.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show("ERROR LOADING SKILL LIST\n" + e.Message);
                }
            }
            else
            {
                MessageBox.Show("NOT FOUND localization\\skillstr.txt!");
            }
            return true;
        }

        private SortedList<string, Bitmap> images = new SortedList<string, Bitmap>();
        

        public Bitmap getShopImage(string surface)
        {
            Bitmap sourceBitmap = Properties.Resources.blank;
            string key = surface.ToLower();
            if (images.ContainsKey(key))
                return images[key];

            if(!File.Exists(surface))
            {
                return sourceBitmap;
            }
            try
            {
                using (DevIL.ImageImporter imImport = new DevIL.ImageImporter())
                {
                    sourceBitmap = images[key] = LoadImage(imImport, new MemoryStream(File.ReadAllBytes(surface)));
                    return sourceBitmap;
                }
            }
            catch { }
            return sourceBitmap;
        }

        public string[] GetShopImageName()
        {
            if (_NAME != null && !_NAME.Equals(DEFAULT_NAME))
            {
                return CURRENT_SESSION.Isready ? CURRENT_SESSION.gshopSurfaces.Length > 0 ? CURRENT_SESSION.gshopSurfaces : DEFAULT_SESSION.gshopSurfaces : DEFAULT_SESSION.gshopSurfaces;
            }
            else
            {
                return DEFAULT_SESSION.gshopSurfaces;
            }
        }

        public void SetVersion(short version)
        {
            if (_NAME != null && !_NAME.Equals(DEFAULT_NAME))
            {
                CURRENT_SESSION.Version = version;
            }
            else
            {
                DEFAULT_SESSION.Version = version;
            }
        }
        #endregion
    }
}
