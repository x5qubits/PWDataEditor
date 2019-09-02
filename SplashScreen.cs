using DomainEditors;
using JHUI;
using JHUI.Animation;
using JHUI.Forms;
using NSUpdateManager;
using Pck_Guy_View;
using PWDataEditorPaied;
using PWDataEditorPaied.Database;
using PWnpcEditor;
using sTASKedit;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ElementEditor
{
    public partial class SplashScreen : JForm
    {
        private MainProgram mainForm =null;
        static public ElementsEditor elementsEditor;
        static public GameShopEditor gameShopEditor;
        static public TaskEditor taskEditor;
        static public NpcEditor npcEditor;
        static public DomainEditor domainEditor;
        static public AiPolicyEditor aiPolicyEditor;
        static public PackView packView;
        static public RegionEditor regionEditor;
        static public PrecinctEditor precinctEditor;
        static public WorldTargetsEditor worldTargetsEditor;
        static public DynObjectsEditor dynObjectsEditor;
        static public ExtraDropSave ExtraDropEditor;

        static public string[] args = null;
        public SplashScreen(string[] args)
        {
            SplashScreen.args = args;
            InitializeComponent();
            this.Opacity = 0;
            new JAnimate().FadeInForm(this, 10, SplashScreen_Shown);
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                //WS_EX_TOOLWINDOW = 0x80
                cp.ExStyle |= 0x80;
                return cp;
            }
        }

       

        private async void SplashScreen_Shown()
        {
#if !COMMUNITYEDITION
            await LicenceManager.Instance.CheckLicenceAsync();
            while (LicenceManager.Instance.status == LICSTATUS.INITIATING)
            {
                Thread.Sleep(100);
            }
#else
            PWDataEditorPaied.Classes.Licence Licence = new PWDataEditorPaied.Classes.Licence
            {
                LicenceName = "CM",
                HardwereHash = "AAAA",
                HardwereName = "BBBB",
                Products = new int[] {
0, //Profile Editor
0, //Admin Editor
1, //Element Editor
1, //Task Editor
1, //Shop Editor
1, //NPC Editor
0, //Policy Editor
1, //Pck Editor
0, //Domain Editor
0, //Region Editor
0, //Precinct Editor
0, //DynTask Editor
0, //DynObject Editor
0, //Fashion Rip
1, //SkinChanger
0, //WorldTargetsev
0, //ExtraDropSev
0  //AdminTool
                },
                MaxTimes = 999,
                OpenTimes = 0,
                Msg = "Your licence will never expire, but you can get a lot more futures if for just 10 Euro/Month contact me (Skype or Gmail): icyteck01@gmail.com",
                Type = 2
            };
            LicenceManager.Instance.status = LICSTATUS.READY;
            LicenceManager.Instance.LicenceName = "CM";
            LicenceManager.Products = Licence.Products;
            LicenceManager.message = Licence.Msg;
            LicenceManager.Instance.SaveLicence(Licence);
#endif
            switch (LicenceManager.Instance.status)
            {
                case LICSTATUS.READY:
                    Thread th = new Thread(() => { DatabaseManager.Instance.LoadDefault(); })
                    {
                        IsBackground = true
                    };
                    th.Start();

                    break;
                case LICSTATUS.UNACTIVATED:
                    File.WriteAllText(LicenceManager.Instance.Xp, LicenceManager.Instance.Cn);
                    Environment.Exit(0);
                    Application.Exit();
                    break;
            }

            if (LicenceManager.type == LICENCETYPE.TIMED && UpdateManager.instance.isNewUpdate())
            {
                this.Hide();
                DownloadForm download = new DownloadForm(UpdateManager.server_verion);
                download.ShowDialog(this);
            }
            if (LicenceManager.Instance.status == LICSTATUS.READY)
            {
                LICENCETYPE lictype = LicenceManager.type;
                Preferences pref = PreferencesManager.Instance.Get();
                lictype = LicenceManager.type;
                pref = PreferencesManager.Instance.Get();
                Program.SHOWMINIMIZEBUTTON = pref.DisplayMinimize;
                Program.HIDEINTASKBAR = pref.HideFormCompleatlyOnClose;
                mainForm = new MainProgram();
                bool load_elementsEditor = true;
                bool load_gameShopEditor = false;
                bool load_taskEditor = false;
                bool load_npcEditor = false;
                bool load_aiPolicyEditor = false;
                bool load_domainEditor = false;
                bool load_packView = false;
                bool isShowMainForm = true;

                bool load_Precinct_Editor = false;
                bool load_Region_Editor = false;
                bool load_WorldTargets_Editor = false;
                bool load_extraDrop_Editor = false;
                bool load_DynObjects_Editor = false;

                string start = "";
                string path = "";
                SplashScreen.args = System.Environment.GetCommandLineArgs();
                if (SplashScreen.args != null && SplashScreen.args.Length > 0)
                {

                    int id = -2;

                    
                    for (int r = 0; r < SplashScreen.args.Length; r++)
                    {
                        string[] split = SplashScreen.args[r].Split(' ');
                        for (int i = 0; i < split.Length; i++)
                        {
                            if (split[i] == "-start")
                            {
                                start = split[i + 1];
                            }
                            if (split[i] == "-path")
                            {
                                path = split[i + 1];
                            }
                        }
                    }

                    if (start.Length > 0)
                    {
                        bool isInt = int.TryParse(start, out id);
                        if (isInt)
                        {
                            try
                            {
                                load_elementsEditor = load_gameShopEditor = load_taskEditor = load_npcEditor = load_aiPolicyEditor = load_domainEditor = load_packView = false;
                                bool canShow = true;
                                EditorsColors editor = EditorsColors.Elements_Editor;
                                if (1985 != id)
                                {
                                    editor = (EditorsColors)id;
                                    switch (editor)
                                    {
                                        case EditorsColors.Elements_Editor:
                                            load_elementsEditor = true;
                                            break;
                                        case EditorsColors.Domain_Editor:
                                            load_domainEditor = true;
                                            break;
                                        case EditorsColors.NPC_Editor:
                                            load_npcEditor = true;
                                            break;
                                        case EditorsColors.Pck_Editor:
                                            load_packView = true;
                                            break;
                                        case EditorsColors.Policy_Editor:
                                            load_aiPolicyEditor = true;
                                            break;
                                        case EditorsColors.Shop_Editor:
                                            load_gameShopEditor = true;
                                            break;
                                        case EditorsColors.Tasks_Editor:
                                            load_taskEditor = true;
                                            break;

                                        case EditorsColors.Precinct_Editor:
                                            load_Precinct_Editor = true;
                                            break;
                                        case EditorsColors.Region_Editor:
                                            load_Region_Editor = true;
                                            break;
                                        case EditorsColors.WorldTargets_Editor:
                                            load_WorldTargets_Editor = true;
                                            break;
                                        case EditorsColors.DynObjects_Editor:
                                            load_DynObjects_Editor = true;
                                            break;

                                        default:
                                            canShow = false;
                                            break;
                                    }
                                }else
                                {
                                    if(path != null && path.Length > 0)
                                    {
                                        if (id == 1985)
                                        {
                                            string file = Path.GetFileName(path);
                                            if (file.ToLower().Contains("element"))
                                            {
                                                canShow = load_elementsEditor = true;
                                                editor = EditorsColors.Elements_Editor;
                                            }
                                            else if (file.ToLower().Contains("task"))
                                            {
                                                canShow = load_taskEditor = true;
                                                editor = EditorsColors.Tasks_Editor;
                                            }
                                            else if (file.ToLower().Contains("npcge"))
                                            {
                                                canShow = load_npcEditor = true;
                                                editor = EditorsColors.NPC_Editor;
                                            }
                                            else if (file.ToLower().Contains("shop"))
                                            {
                                                canShow = load_gameShopEditor = true;
                                                editor = EditorsColors.Shop_Editor;
                                            }
                                            else if (file.ToLower().Contains("policy"))
                                            {
                                                canShow = load_aiPolicyEditor = true;
                                                editor = EditorsColors.Policy_Editor;
                                            }
                                            else if (file.ToLower().Contains("domain"))
                                            {
                                                canShow = load_domainEditor = true;
                                                editor = EditorsColors.Domain_Editor;
                                            }
                                            else if (file.ToLower().Contains("dynamicobjects"))
                                            {
                                                canShow = load_DynObjects_Editor = true;
                                                editor = EditorsColors.DynObjects_Editor;
                                            }
                                            else if (file.ToLower().Contains("region"))
                                            {
                                                canShow = load_Region_Editor = true;
                                                editor = EditorsColors.Region_Editor;
                                            }
                                            else if (file.ToLower().Contains("precinct"))
                                            {
                                                canShow = load_Precinct_Editor = true;
                                                editor = EditorsColors.Precinct_Editor;
                                            }
                                            else if (file.ToLower().Contains("world_targets"))
                                            {
                                                canShow = load_WorldTargets_Editor = true;
                                                editor = EditorsColors.WorldTargets_Editor;
                                            }
                                            else if (file.ToLower().Contains("extra_drops"))
                                            {
                                                canShow = load_extraDrop_Editor = true;
                                                editor = EditorsColors.ExtraDropSev;
                                            }
                                        }
                                    }
                                }
                                if (canShow)
                                {
                                    isShowMainForm = false;
                                    mainForm.BecomeVisible = isShowMainForm;
                                    mainForm.callonShow = editor;
                                }else
                                {
                                     isShowMainForm = load_WorldTargets_Editor = load_Precinct_Editor = load_Region_Editor = load_DynObjects_Editor = load_elementsEditor = load_gameShopEditor = load_taskEditor = load_npcEditor = load_aiPolicyEditor = load_domainEditor = load_packView = true;
                                }
                            }
                            catch {
                                isShowMainForm = load_WorldTargets_Editor = load_Precinct_Editor = load_Region_Editor = load_DynObjects_Editor = load_elementsEditor = load_gameShopEditor = load_taskEditor = load_npcEditor = load_aiPolicyEditor = load_domainEditor = load_packView = true;
                            }
                        }
                    }
                }
                if (!isShowMainForm)
                    Program.StandAlone = true;
                else
                    Program.StandAlone = false;

                if (load_extraDrop_Editor)
                {
                    SplashScreen.ExtraDropEditor = new ExtraDropSave();
                    if (path != null && path.Length > 0 && File.Exists(path) && Path.GetExtension(path).ToLower().Equals(".sev"))
                    {
                        SplashScreen.ExtraDropEditor.isAutoOpen = true;
                        SplashScreen.ExtraDropEditor.autoOpenPath = path;
                    }
                    await Task.Factory.StartNew(() =>
                    {
                        this.Invoke(new MethodInvoker(delegate
                        {
                            SplashScreen.ExtraDropEditor.Show();
                            SplashScreen.ExtraDropEditor.WindowState = FormWindowState.Minimized;
                            SplashScreen.ExtraDropEditor.ShowInTaskbar = SplashScreen.ExtraDropEditor.ShowIcon = true;
                            SplashScreen.ExtraDropEditor.Opacity = 100;
                            SplashScreen.ExtraDropEditor.progress_bar2 += mainForm.progress_bar;
                            SplashScreen.ExtraDropEditor.SetStyle(pref.color[(int)EditorsColors.ExtraDropSev], pref.teme[(int)EditorsColors.ExtraDropSev], 255);
                            GC.KeepAlive(SplashScreen.ExtraDropEditor);
                        }));
                    });
                }

                if (load_DynObjects_Editor)
                {
                    SplashScreen.dynObjectsEditor = new DynObjectsEditor();
                    if (path != null && path.Length > 0 && File.Exists(path) && Path.GetExtension(path).ToLower().Equals(".data"))
                    {
                        SplashScreen.dynObjectsEditor.isAutoOpen = true;
                        SplashScreen.dynObjectsEditor.autoOpenPath = path;
                    }
                    await Task.Factory.StartNew(() =>
                     {
                         this.Invoke(new MethodInvoker(delegate
                         {
                             SplashScreen.dynObjectsEditor.Show();
                             SplashScreen.dynObjectsEditor.WindowState = FormWindowState.Minimized;
                             SplashScreen.dynObjectsEditor.ShowInTaskbar = SplashScreen.dynObjectsEditor.ShowIcon = true;
                             SplashScreen.dynObjectsEditor.Opacity = 100;
                             SplashScreen.dynObjectsEditor.progress_bar2 += mainForm.progress_bar;
                             SplashScreen.dynObjectsEditor.SetStyle(pref.color[(int)EditorsColors.DynObjects_Editor], pref.teme[(int)EditorsColors.DynObjects_Editor], 255);
                             GC.KeepAlive(SplashScreen.dynObjectsEditor);
                         }));
                     });
                }

                if (load_WorldTargets_Editor)
                {
                    SplashScreen.worldTargetsEditor = new WorldTargetsEditor();
                    if (path != null && path.Length > 0 && File.Exists(path) && Path.GetExtension(path).ToLower().Equals(".txt"))
                    {
                        SplashScreen.worldTargetsEditor.isAutoOpen = true;
                        SplashScreen.worldTargetsEditor.autoOpenPath = path;
                    }
                    await Task.Factory.StartNew(() =>
                     {
                         this.Invoke(new MethodInvoker(delegate
                         {
                             SplashScreen.worldTargetsEditor.Show();
                             SplashScreen.worldTargetsEditor.WindowState = FormWindowState.Minimized;
                             SplashScreen.worldTargetsEditor.ShowInTaskbar = SplashScreen.worldTargetsEditor.ShowIcon = true;
                             SplashScreen.worldTargetsEditor.Opacity = 100;
                             SplashScreen.worldTargetsEditor.progress_bar2 += mainForm.progress_bar;
                             SplashScreen.worldTargetsEditor.SetStyle(pref.color[(int)EditorsColors.WorldTargets_Editor], pref.teme[(int)EditorsColors.WorldTargets_Editor], 255);
                             GC.KeepAlive(SplashScreen.worldTargetsEditor);
                         }));
                     });
                }

                if (load_Region_Editor)
                {
                    SplashScreen.regionEditor = new RegionEditor();
                    if (path != null && path.Length > 0 && File.Exists(path))
                    {
                        SplashScreen.regionEditor.isAutoOpen = true;
                        SplashScreen.regionEditor.autoOpenPath = path;
                    }
                    await Task.Factory.StartNew(() =>
                     {
                         this.Invoke(new MethodInvoker(delegate
                         {
                             SplashScreen.regionEditor.Show();
                             SplashScreen.regionEditor.WindowState = FormWindowState.Minimized;
                             SplashScreen.regionEditor.ShowInTaskbar = SplashScreen.regionEditor.ShowIcon = true;
                             SplashScreen.regionEditor.Opacity = 100;
                             SplashScreen.regionEditor.progress_bar2 += mainForm.progress_bar;
                             SplashScreen.regionEditor.SetStyle(pref.color[(int)EditorsColors.Region_Editor], pref.teme[(int)EditorsColors.Region_Editor], 255);
                             GC.KeepAlive(SplashScreen.regionEditor);
                         }));
                     });
                }


                if (load_Precinct_Editor)
                {
                    SplashScreen.precinctEditor = new PrecinctEditor();
                    if (path != null && path.Length > 0 && File.Exists(path))
                    {
                        SplashScreen.precinctEditor.isAutoOpen = true;
                        SplashScreen.precinctEditor.autoOpenPath = path;
                    }
                    await Task.Factory.StartNew(() =>
                     {
                         this.Invoke(new MethodInvoker(delegate
                         {
                             SplashScreen.precinctEditor.Show();
                             SplashScreen.precinctEditor.WindowState = FormWindowState.Minimized;
                             SplashScreen.precinctEditor.ShowInTaskbar = SplashScreen.precinctEditor.ShowIcon = true;
                             SplashScreen.precinctEditor.Opacity = 100;
                             SplashScreen.precinctEditor.progress_bar2 += mainForm.progress_bar;
                             SplashScreen.precinctEditor.SetStyle(pref.color[(int)EditorsColors.Precinct_Editor], pref.teme[(int)EditorsColors.Precinct_Editor], 255);
                             GC.KeepAlive(SplashScreen.precinctEditor);
                         }));
                     });
                }


                if (load_elementsEditor)
                {
                    SplashScreen.elementsEditor = new ElementsEditor();
                    if (path != null && path.Length > 0 && File.Exists(path) && Path.GetExtension(path).ToLower().Equals(".data"))
                    {
                        SplashScreen.elementsEditor.isAutoOpen = true;
                        SplashScreen.elementsEditor.autoOpenPath = path;
                    }
                    await Task.Factory.StartNew(() =>
                     {
                         this.Invoke(new MethodInvoker(delegate
                     {
                         SplashScreen.elementsEditor.Show();
                         SplashScreen.elementsEditor.WindowState = FormWindowState.Minimized;
                         SplashScreen.elementsEditor.ShowInTaskbar = SplashScreen.elementsEditor.ShowIcon = true;
                         SplashScreen.elementsEditor.Opacity = 100;
                         SplashScreen.elementsEditor.progress_bar2 += mainForm.progress_bar;
                         SplashScreen.elementsEditor.SetStyle(pref.color[(int)EditorsColors.Elements_Editor], pref.teme[(int)EditorsColors.Elements_Editor], 255);
                         GC.KeepAlive(SplashScreen.elementsEditor);
                     }));
                     });
                }
                if (load_gameShopEditor)
                {
                    SplashScreen.gameShopEditor = new GameShopEditor();
                    if (path != null && path.Length > 0 && File.Exists(path) && Path.GetExtension(path).ToLower().Equals(".data"))
                    {
                        SplashScreen.gameShopEditor.isAutoOpen = true;
                        SplashScreen.gameShopEditor.autoOpenPath = path;
                    }
                    await Task.Factory.StartNew(() =>
                     {
                         this.Invoke(new MethodInvoker(delegate
                         {
                             SplashScreen.gameShopEditor.Show();
                             SplashScreen.gameShopEditor.WindowState = FormWindowState.Minimized;
                             SplashScreen.gameShopEditor.ShowInTaskbar = SplashScreen.gameShopEditor.ShowIcon = true;
                             SplashScreen.gameShopEditor.Opacity = 100;
                             SplashScreen.gameShopEditor.progress_bar2 += mainForm.progress_bar;
                             SplashScreen.gameShopEditor.SetStyle(pref.color[(int)EditorsColors.Shop_Editor], pref.teme[(int)EditorsColors.Shop_Editor], 255);
                             GC.KeepAlive(SplashScreen.gameShopEditor);
                         }));
                     });
                }
                if (load_taskEditor)
                {
                    SplashScreen.taskEditor = new TaskEditor();
                    if (path != null && path.Length > 0 && File.Exists(path) && Path.GetExtension(path).ToLower().Equals(".data"))
                    {
                        SplashScreen.taskEditor.isAutoOpen = true;
                        SplashScreen.taskEditor.autoOpenPath = path;
                    }
                    await Task.Factory.StartNew(() =>
                     {
                         this.Invoke(new MethodInvoker(delegate
                         {
                             SplashScreen.taskEditor.Show();
                             SplashScreen.taskEditor.WindowState = FormWindowState.Minimized;
                             SplashScreen.taskEditor.ShowInTaskbar = SplashScreen.taskEditor.ShowIcon = true;
                             SplashScreen.taskEditor.Opacity = 100;
                             SplashScreen.taskEditor.progress_bar2 += mainForm.progress_bar;
                             SplashScreen.taskEditor.SetStyle(pref.color[(int)EditorsColors.Tasks_Editor], pref.teme[(int)EditorsColors.Tasks_Editor], 255);
                             GC.KeepAlive(SplashScreen.taskEditor);
                         }));
                     });
                }
                if (load_npcEditor)
                {
                    SplashScreen.npcEditor = new NpcEditor();
                    if (path != null && path.Length > 0 && File.Exists(path) && Path.GetExtension(path).ToLower().Equals(".data"))
                    {
                        SplashScreen.npcEditor.isAutoOpen = true;
                        SplashScreen.npcEditor.autoOpenPath = path;
                    }
                    await Task.Factory.StartNew(() =>
                     {
                         this.Invoke(new MethodInvoker(delegate
                         {
                             SplashScreen.npcEditor.Show();
                             SplashScreen.npcEditor.WindowState = FormWindowState.Minimized;
                             SplashScreen.npcEditor.ShowInTaskbar = SplashScreen.npcEditor.ShowIcon = true;
                             SplashScreen.npcEditor.Opacity = 100;
                             SplashScreen.npcEditor.progress_bar2 += mainForm.progress_bar;
                             SplashScreen.npcEditor.SetStyle(pref.color[(int)EditorsColors.NPC_Editor], pref.teme[(int)EditorsColors.NPC_Editor], 255);
                             GC.KeepAlive(SplashScreen.npcEditor);
                         }));
                     });
                }
                if (load_aiPolicyEditor)
                {
                    SplashScreen.aiPolicyEditor = new AiPolicyEditor();
                    if (path != null && path.Length > 0 && File.Exists(path) && Path.GetExtension(path).ToLower().Equals(".data"))
                    {
                        SplashScreen.aiPolicyEditor.isAutoOpen = true;
                        SplashScreen.aiPolicyEditor.autoOpenPath = path;
                    }
                    await Task.Factory.StartNew(() =>
                     {
                         this.Invoke(new MethodInvoker(delegate
                         {
                             SplashScreen.aiPolicyEditor.Show();
                             SplashScreen.aiPolicyEditor.WindowState = FormWindowState.Minimized;
                             SplashScreen.aiPolicyEditor.ShowInTaskbar = SplashScreen.aiPolicyEditor.ShowIcon = true;
                             SplashScreen.aiPolicyEditor.Opacity = 100;
                             SplashScreen.aiPolicyEditor.progress_bar2 += mainForm.progress_bar;
                             SplashScreen.aiPolicyEditor.SetStyle(pref.color[(int)EditorsColors.Policy_Editor], pref.teme[(int)EditorsColors.Policy_Editor], 255);
                             GC.KeepAlive(SplashScreen.aiPolicyEditor);
                         }));
                     });
                }
                if (load_domainEditor)
                {
                    SplashScreen.domainEditor = new DomainEditor();
                    if (path != null && path.Length > 0 && File.Exists(path) && Path.GetExtension(path).ToLower().Equals(".data"))
                    {
                        SplashScreen.domainEditor.isAutoOpen = true;
                        SplashScreen.domainEditor.autoOpenPath = path;
                    }
                    await Task.Factory.StartNew(() =>
                     {
                         this.Invoke(new MethodInvoker(delegate
                         {
                             SplashScreen.domainEditor.Show();
                             SplashScreen.domainEditor.WindowState = FormWindowState.Minimized;
                             SplashScreen.domainEditor.ShowInTaskbar = SplashScreen.domainEditor.ShowIcon = true;
                             SplashScreen.domainEditor.Opacity = 100;
                             SplashScreen.domainEditor.progress_bar2 += mainForm.progress_bar;
                             SplashScreen.domainEditor.SetStyle(pref.color[(int)EditorsColors.Domain_Editor], pref.teme[(int)EditorsColors.Domain_Editor], 255);
                             GC.KeepAlive(SplashScreen.domainEditor);
                         }));
                     });
                }
                if (load_packView)
                {
                    SplashScreen.packView = new PackView();
                    if(path != null && path.Length > 0 && File.Exists(path) && Path.GetExtension(path).ToLower().Equals(".pck"))
                    {
                        SplashScreen.packView.autoLoad = true;
                        SplashScreen.packView.autoOpenPath = path;
                    }
                    await Task.Factory.StartNew(() =>
                     {
                         this.Invoke(new MethodInvoker(delegate
                         {
                             SplashScreen.packView.Show();
                             SplashScreen.packView.WindowState = FormWindowState.Minimized;
                             SplashScreen.packView.ShowInTaskbar = SplashScreen.packView.ShowIcon = true;
                             SplashScreen.packView.Opacity = 100;
                             SplashScreen.packView.progress_bar2 += mainForm.progress_bar;
                             SplashScreen.packView.SetStyle(pref.color[(int)EditorsColors.Pck_Editor], pref.teme[(int)EditorsColors.Pck_Editor], 255);
                             GC.KeepAlive(SplashScreen.packView);
                         }));
                     });
                }
                while (!DatabaseManager.Loaded)
                {

                }          
                mainForm.CustomThing += Form1_FormClosing;
                new JAnimate().FadeOutForm(this, 20, showMainMenu);
            }
            else
            {
                this.Hide();
            }
        }

        private void showMainMenu()
        {
            mainForm.Show();
            this.Hide();
        }

        private void Form1_FormClosing()
        {
            this.Close();
        }
    }
}
