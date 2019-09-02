using ElementEditor;
using JHUI.Forms;
using JHUI.Native;
using Shield.classes.net;
using System;
using System.Drawing;
using System.Windows.Forms;
using ElementEditor.classes;
using PWDataEditorPaied;
using ElementEditor.Element_Editor_Classes;
using System.Threading.Tasks;
using sTASKedit;
using PWnpcEditor;
using DomainEditors;
using JHUI.Animation;
using System.Threading;
using System.Reflection;
using Pck_Guy_View;
using JHUI;
using PWDataEditorPaied.Forms.SubForms;
using PWDataEditorPaied.Database;
using System.Diagnostics;
using PWDataEditorPaied.helper_classes;
using JHUI.Utils;

namespace ElementEditor
{

    public partial class MainProgram : JForm
    {
        private static MainProgram instance;

        public static MainProgram getInstance()
        {
            if (instance == null)
            {
                instance = new MainProgram();
            }
            return instance;
        }
        private Configs configs;
        private Point lastLocation = new Point();
        public EditorsColors callonShow = EditorsColors.Elements_Editor;
        public bool BecomeVisible = true;
        public static string appPath = "";
        private Preferences pref;

        public Action CustomThing { get; internal set; }

        public void progress_bar(string value, int min, int max)
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)delegate () { progress_bar(value, min, max); });
                return;
            }
            jLabel1.Text = value;
            if (min == 0 || max == 0)
            {
                jProgressBar1.Value = 0;

            }
            else
            {
                int val = (100 * min) / max;
                jProgressBar1.Value = val <= 100 ? val : 100;
            }
        }

        public void ExitInvoke(bool forceExit = false)
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)delegate () { ExitInvoke(forceExit); });
                return;
            }
            isForceExit = forceExit;
            try
            {
                Application.Exit();
            }
            catch
            {
                Environment.Exit(0);
            }
        }


        public MainProgram()
        {
            appPath = Application.ExecutablePath;
            pref = PreferencesManager.Instance.Get();
            InitializeComponent();
            instance = this;
            configs = new SystemCacheManager().getConfig();
            if (pref.RememberLastLocation)
            {
                lastLocation = pref.LastLocation;
            }
            else
            {
                lastLocation = Point.Empty;
            }
            this.StartPosition = FormStartPosition.Manual;
            this.Opacity = 1;
            this.PaintTopBorder = true;
            this.TopMost = true;
            if (lastLocation.IsEmpty)
            {
                this.StartPosition = FormStartPosition.Manual;
                foreach (var scrn in Screen.AllScreens)
                {
                    if (scrn.Bounds.Contains(this.Location))
                    {
                        this.Location = new Point(scrn.Bounds.Right - this.Width - 5, scrn.Bounds.Top + 5);
                        return;
                    }
                }
            }
            else
            {
                Location = lastLocation;
            }
        }

        private void MainProgram_Shown(object sender, EventArgs e)
        {
            if (!BecomeVisible)
            {
                switch(callonShow)
                {
                    case EditorsColors.Elements_Editor:
                        ShowElementEditor(null, null);
                        break;
                    case EditorsColors.Shop_Editor:
                        ShowShopEditor(null, null);
                        break;
                    case EditorsColors.Tasks_Editor:
                        ShowTaskEditor(null, null);
                        break;
                    case EditorsColors.NPC_Editor:
                        ShowNpcEditor(null, null);
                        break;
                    case EditorsColors.Policy_Editor:
                        ShowAiPolicyEditor(null, null);
                        break;
                    case EditorsColors.Domain_Editor:
                        ShowDomainEditor(null, null);
                        break;
                    case EditorsColors.Pck_Editor:
                        ShowPackView(null, null);
                        break; 
                }
                try
                {
                    //WindowState = FormWindowState.Minimized;
                    //ShowInTaskbar = ShowIcon = false; //TODO FIX FUCKING SHIT
                    this.Hide();
                }
                catch { }
                return;
            }else
            {
                if(pref.ShowElementOnStart)
                    ShowElementEditor(null, null);
            }
            jLabel3.Text = "V: " + Program.productVersion.Major + " Rev.: " + Program.productVersion.Revision;
            jLabel1.Text = "Hello " + LicenceManager.Instance.LicenceName + "!";

            if(LicenceManager.Products[(int)Editors.Region_Editor] == 0)
            {
                regionEditorToolStripMenuItem.Enabled = false;
                regionEditorToolStripMenuItem.Visible = false;
            }
            if (LicenceManager.Products[(int)Editors.Domain_Editor] == 0)
            {
                domainEditorToolStripMenuItem.Enabled = false;
                domainEditorToolStripMenuItem.Visible = false;
            }
            if (LicenceManager.Products[(int)Editors.Pck_Editor] == 0)
            {
                pckEditorToolStripMenuItem.Enabled = false;
                pckEditorToolStripMenuItem.Visible = false;
            }
            if (LicenceManager.Products[(int)Editors.Policy_Editor] == 0)
            {
                policyEditorToolStripMenuItem.Enabled = false;
                policyEditorToolStripMenuItem.Visible = false;
            }
            if (LicenceManager.Products[(int)Editors.Precinct_Editor] == 0)
            {
                precinctEditorToolStripMenuItem.Enabled = false;
                precinctEditorToolStripMenuItem.Visible = false;
            }
            if (LicenceManager.Products[(int)Editors.DynObject_Editor] == 0)
            {
                dynobjectsEditorToolStripMenuItem.Enabled = false;
                dynobjectsEditorToolStripMenuItem.Visible = false;
            }
            if (LicenceManager.Products[(int)Editors.WorldTargetsev] == 0)
            {
                worldTargetsEditorToolStripMenuItem.Enabled = false;
                worldTargetsEditorToolStripMenuItem.Visible = false;
            }
            if (LicenceManager.Products[(int)Editors.DynTask_Editor] == 0)
            {
                dynTasksEditorToolStripMenuItem.Enabled = false;
                dynTasksEditorToolStripMenuItem.Visible = false;
            }
            if (LicenceManager.Products[(int)Editors.ExtraDropSev] == 0)
            {
                extraDropEditorToolStripMenuItem.Enabled = false;
                extraDropEditorToolStripMenuItem.Visible = false;
            }
            if (LicenceManager.Products[(int)Editors.AdminTool] == 0)
            {
                adminToolToolStripMenuItem.Enabled = false;
                adminToolToolStripMenuItem.Visible = false;
            }
            new JBehavor().InvokeRepeating(CheckTimeLeft, 30);
        }

        static public int count = 0;
        private bool isForceExit = false;
        private void CheckTimeLeft()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)delegate () { CheckTimeLeft(); });
                return;
            }
            if (LicenceManager.TimeLeft < 4 && MainProgram.count < 1
                || LicenceManager.type == LICENCETYPE.PERMANENT && MainProgram.count < 1
                || LicenceManager.type == LICENCETYPE.ADMIN && MainProgram.count < 1)
            {
                jPictureBox2_Click(null, null);
                MainProgram.count++;
            }
            /*
            Task.Factory.StartNew(async () => {
                LicenceManager _LicenceManager = LicenceManager.Instance;
                await _LicenceManager.CheckLicenceAsync(false);
                if(_LicenceManager.status == LICSTATUS.UNACTIVATED)
                {
                    MainProgram.getInstance().ExitInvoke(true);
                }

            });
            */
        }

        #region FUNCTIONS
        public void ShowElementEditor(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)delegate () { ShowElementEditor(sender, e); });
                return;
            }
            if (SplashScreen.elementsEditor != null)
            {
                if(SplashScreen.elementsEditor.WindowState == FormWindowState.Minimized)
                {
                    SplashScreen.elementsEditor.Show();
                    SplashScreen.elementsEditor.WindowState = FormWindowState.Normal;
                    SplashScreen.elementsEditor.ShowInTaskbar = SplashScreen.elementsEditor.ShowIcon = true;
                    jButton1.Text = "Hide Element Editor";
                }
                else
                {
                    SplashScreen.elementsEditor.WindowState = FormWindowState.Minimized;
                    SplashScreen.elementsEditor.Hide();
                    jButton1.Text = "Show Element Editor";
                }
            }
            else
            {
                SplashScreen.elementsEditor = new ElementsEditor();
                SplashScreen.elementsEditor.progress_bar2 += progress_bar;
                SplashScreen.elementsEditor.Show();
                SplashScreen.elementsEditor.SetStyle(pref.color[(int)EditorsColors.Elements_Editor], pref.teme[(int)EditorsColors.Elements_Editor], 255);
                SplashScreen.elementsEditor.Opacity = 0;
                new JAnimate().FadeInForm(SplashScreen.elementsEditor, 10);
                SplashScreen.elementsEditor.ShowInTaskbar = SplashScreen.elementsEditor.ShowIcon = true;
                ElementsEditor.configs = configs;
                jButton1.Text = "Hide Element Editor";
                
            }
        }

        public void AllTimeOntop(bool checkedx)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate {
                    AllTimeOntop(checkedx);
                }));
                return;
            }
            this.TopMost = checkedx;
        }

        public void goToElementIndex(ItemDupe item)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate {
                    goToElementIndex(item);
                }));
                return;
            }
            if (SplashScreen.elementsEditor != null)
            {
                SplashScreen.elementsEditor.setIndex(item);
                SplashScreen.elementsEditor.WindowState = FormWindowState.Normal;
                SplashScreen.elementsEditor.Focus();
            }
        }

        public void ReloadConfigs()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate {
                    ReloadConfigs();
                }));
                return;
            }
            if (SplashScreen.elementsEditor != null)
            {
                SplashScreen.elementsEditor.LoadImportConfig();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void ShowShopEditor(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)delegate () { ShowShopEditor(sender, e); });
                return;
            }
            if (SplashScreen.gameShopEditor != null)
            {
                if (SplashScreen.gameShopEditor.WindowState == FormWindowState.Minimized)
                {
                    SplashScreen.gameShopEditor.Show();
                    SplashScreen.gameShopEditor.WindowState = FormWindowState.Normal;
                    jButton3.Text = "Hide Shop Editor";
                }
                else
                {
                    SplashScreen.gameShopEditor.WindowState = FormWindowState.Minimized;
                    SplashScreen.gameShopEditor.Hide();
                    jButton3.Text = "Show Shop Editor";
                }
            }else
            {
                SplashScreen.gameShopEditor = new GameShopEditor();
                SplashScreen.gameShopEditor.progress_bar2 += progress_bar;
                SplashScreen.gameShopEditor.Show();
                SplashScreen.gameShopEditor.SetStyle(pref.color[(int)EditorsColors.Shop_Editor], pref.teme[(int)EditorsColors.Shop_Editor], 255);
                SplashScreen.gameShopEditor.Opacity = 0;
                new JAnimate().FadeInForm(SplashScreen.gameShopEditor, 10);
                SplashScreen.gameShopEditor.ShowInTaskbar = SplashScreen.gameShopEditor.ShowIcon = true;
                jButton3.Text = "Hide Shop Editor";
            }
        }

        public void ShowTaskEditor(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)delegate () { ShowTaskEditor(sender, e); });
                return;
            }
            if (SplashScreen.taskEditor != null)
            {
                if (SplashScreen.taskEditor.WindowState == FormWindowState.Minimized)
                {
                    SplashScreen.taskEditor.Show();
                    SplashScreen.taskEditor.WindowState = FormWindowState.Normal;
                    jButton2.Text = "Hide Task Editor";
                }
                else
                {
                    SplashScreen.taskEditor.WindowState = FormWindowState.Minimized;
                    SplashScreen.taskEditor.Hide();
                    jButton2.Text = "Show Task Editor";
                }
            }
            else
            {
                SplashScreen.taskEditor = new TaskEditor();
                SplashScreen.taskEditor.progress_bar2 += progress_bar;
                SplashScreen.taskEditor.Show();
                SplashScreen.taskEditor.SetStyle(pref.color[(int)EditorsColors.Tasks_Editor], pref.teme[(int)EditorsColors.Tasks_Editor], 255);
                SplashScreen.taskEditor.Opacity = 0;
                new JAnimate().FadeInForm(SplashScreen.taskEditor, 10);
                SplashScreen.taskEditor.ShowInTaskbar = SplashScreen.taskEditor.ShowIcon = true;
                jButton2.Text = "Hide Task Editor";
            }
        }

        public void ShowNpcEditor(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)delegate () { ShowNpcEditor(sender, e); });
                return;
            }
            if (SplashScreen.npcEditor != null)
            {
                if (SplashScreen.npcEditor.WindowState == FormWindowState.Minimized)
                {
                    SplashScreen.npcEditor.Show();
                    SplashScreen.npcEditor.WindowState = FormWindowState.Normal;
                    jButton4.Text = "Hide NPC Editor";
                }
                else
                {
                    SplashScreen.npcEditor.WindowState = FormWindowState.Minimized;
                    SplashScreen.npcEditor.Hide();
                    jButton4.Text = "Show NPC Editor";
                }
            }
            else
            {
                SplashScreen.npcEditor = new NpcEditor();
                SplashScreen.npcEditor.progress_bar2 += progress_bar;
                SplashScreen.npcEditor.Show();
                SplashScreen.npcEditor.SetStyle(pref.color[(int)EditorsColors.NPC_Editor], pref.teme[(int)EditorsColors.NPC_Editor], 255);
                SplashScreen.npcEditor.Opacity = 0;
                new JAnimate().FadeInForm(SplashScreen.npcEditor, 10);
                SplashScreen.npcEditor.ShowInTaskbar = SplashScreen.npcEditor.ShowIcon = true;
                jButton4.Text = "Hide NPC Editor";
            }
        }

        private void ShowAiPolicyEditor(object sender, EventArgs e)
        {
            if (SplashScreen.aiPolicyEditor != null)
            {
                if (SplashScreen.aiPolicyEditor.WindowState == FormWindowState.Minimized)
                {
                    SplashScreen.aiPolicyEditor.Show();
                    SplashScreen.aiPolicyEditor.WindowState = FormWindowState.Normal;
                    SplashScreen.aiPolicyEditor.ShowInTaskbar = SplashScreen.aiPolicyEditor.ShowIcon = true;
                }
                else
                {
                    SplashScreen.aiPolicyEditor.WindowState = FormWindowState.Minimized;
                    SplashScreen.aiPolicyEditor.Hide();
                }
            }
            else
            {
                SplashScreen.aiPolicyEditor = new AiPolicyEditor();
                SplashScreen.aiPolicyEditor.progress_bar2 += progress_bar;
                SplashScreen.aiPolicyEditor.Show();
                SplashScreen.aiPolicyEditor.SetStyle(pref.color[(int)EditorsColors.Policy_Editor], pref.teme[(int)EditorsColors.Policy_Editor], 255);
                SplashScreen.aiPolicyEditor.Opacity = 0;
                new JAnimate().FadeInForm(SplashScreen.aiPolicyEditor, 10);
                SplashScreen.aiPolicyEditor.ShowInTaskbar = SplashScreen.aiPolicyEditor.ShowIcon = false;
            }
        }

        private void ShowDomainEditor(object sender, EventArgs e)
        {
            if (SplashScreen.domainEditor != null)
            {
                if (SplashScreen.domainEditor.WindowState == FormWindowState.Minimized)
                {
                    SplashScreen.domainEditor.Show();
                    SplashScreen.domainEditor.WindowState = FormWindowState.Normal;
                    SplashScreen.domainEditor.ShowInTaskbar = SplashScreen.domainEditor.ShowIcon = true;
                }
                else
                {
                    SplashScreen.domainEditor.WindowState = FormWindowState.Minimized;
                    SplashScreen.domainEditor.Hide();
                }
            }
            else
            {
                SplashScreen.domainEditor = new DomainEditor();
                SplashScreen.domainEditor.progress_bar2 += progress_bar;
                SplashScreen.domainEditor.Show();
                SplashScreen.domainEditor.SetStyle(pref.color[(int)EditorsColors.Domain_Editor], pref.teme[(int)EditorsColors.Domain_Editor], 255);
                SplashScreen.domainEditor.Opacity = 0;
                new JAnimate().FadeInForm(SplashScreen.domainEditor, 10);
                SplashScreen.domainEditor.ShowInTaskbar = SplashScreen.domainEditor.ShowIcon = true;
            }
        }

        private void ShowPackView(object sender, EventArgs e)
        {
            if (SplashScreen.packView != null)
            {
                if (SplashScreen.packView.WindowState == FormWindowState.Minimized)
                {
                    SplashScreen.packView.Show();
                    SplashScreen.packView.WindowState = FormWindowState.Normal;
                    SplashScreen.packView.ShowInTaskbar = SplashScreen.packView.ShowIcon = true;
                }
                else
                {
                    SplashScreen.packView.WindowState = FormWindowState.Minimized;
                    SplashScreen.packView.Hide();
                }
            }
            else
            {
                SplashScreen.packView = new PackView();
                SplashScreen.packView.progress_bar2 += progress_bar;
                SplashScreen.packView.Show();
                SplashScreen.packView.SetStyle(pref.color[(int)EditorsColors.Pck_Editor], pref.teme[(int)EditorsColors.Pck_Editor], 255);
                SplashScreen.packView.Opacity = 0;
                new JAnimate().FadeInForm(SplashScreen.packView, 10);
                SplashScreen.packView.ShowInTaskbar = SplashScreen.packView.ShowIcon = true;
            }
        }

        public void setTemplate(JThemeStyle thme, JColorStyle style, EditorsColors editorid, int alpha = 255)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate {
                    setTemplate(thme, style, editorid, alpha);
                }));
                return;
            }
            switch(editorid)
            {
                case EditorsColors.Elements_Editor:
                    SplashScreen.elementsEditor.SetStyle(style, thme, alpha);
                    break;
                case EditorsColors.Tasks_Editor:
                    SplashScreen.taskEditor.SetStyle(style, thme, alpha);
                    break;
                case EditorsColors.Shop_Editor:
                    SplashScreen.gameShopEditor.SetStyle(style, thme, alpha);
                    break;
                case EditorsColors.NPC_Editor:
                    SplashScreen.npcEditor.SetStyle(style, thme, alpha);
                    break;
                case EditorsColors.Domain_Editor:
                    SplashScreen.domainEditor.SetStyle(style, thme, alpha);
                    break;
                case EditorsColors.Policy_Editor:
                    SplashScreen.aiPolicyEditor.SetStyle(style, thme, alpha);
                    break;
                case EditorsColors.Pck_Editor:
                    SplashScreen.packView.SetStyle(style, thme, alpha);
                    break;
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            MainFormSettings mf = new MainFormSettings();
            mf.ShowDialog(this);
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (WindowState != FormWindowState.Normal || !this.Visible)
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
                if (Program.HIDEINTASKBAR)
                    ShowIcon = ShowInTaskbar = false;

                Program.StandAlone = false;

                this.Focus();
            }
            else
            {


            }
            resetLocationToolStripMenuItem_Click(null, null);
        }
        #endregion

        private void startStandAloneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process process = new Process();
            process.StartInfo.FileName = appPath;
            process.StartInfo.Arguments = "\"-start " + (int)EditorsColors.Elements_Editor + "\"";
            process.Start();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Process process = new Process();
            process.StartInfo.FileName = appPath;
            process.StartInfo.Arguments = "\"-start " + (int)EditorsColors.Tasks_Editor + "\"";
            process.Start();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Process process = new Process();
            process.StartInfo.FileName = appPath;
            process.StartInfo.Arguments = "\"-start " + (int)EditorsColors.Shop_Editor + "\"";
            process.Start();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Process process = new Process();
            process.StartInfo.FileName = appPath;
            process.StartInfo.Arguments = "\"-start " + (int)EditorsColors.NPC_Editor + "\"";
            process.Start();
        }

        private void startStandAloneToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Process process = new Process();
            process.StartInfo.FileName = appPath;
            process.StartInfo.Arguments = "\"-start " + (int)EditorsColors.Policy_Editor + "\"";
            process.Start();
        }

        private void startStandaloneToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Process process = new Process();
            process.StartInfo.FileName = appPath;
            process.StartInfo.Arguments = "\"-start " + (int)EditorsColors.Domain_Editor + "\"";
            process.Start();
        }

        private void startStandaloneToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Process process = new Process();
            process.StartInfo.FileName = appPath;
            process.StartInfo.Arguments = "\"-start " + (int)EditorsColors.Pck_Editor +"\"";
            process.Start();
        }

        private void MainProgram_Move(object sender, EventArgs e)
        {
            if(pref.RememberLastLocation)
                lastLocation = Location;

        }

        private void MainProgram_ResizeEnd(object sender, EventArgs e)
        {
            if (pref.RememberLastLocation)
            {
                pref.LastLocation = lastLocation;
                PreferencesManager.Instance.Set(pref);
            }
        }

        private void resetLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.Manual;
            foreach (var scrn in Screen.AllScreens)
            {
                if (scrn.Bounds.Contains(this.Location))
                {
                    this.Location = new Point(scrn.Bounds.Right - this.Width - 5, scrn.Bounds.Top + 5);
                    return;
                }
            }
            if (pref.RememberLastLocation)
            {
                pref.LastLocation = Location;
                PreferencesManager.Instance.Set(pref);
            }
        }

        private void jLabel2_Click(object sender, EventArgs e)
        {
            Process.Start("http://jhsoftware.pro/");
        }

        private void jPictureBox1_Click(object sender, EventArgs e)
        {
            Control btnSender = (Control)sender;
            Point ptLowerLeft = new Point(0, btnSender.Height);
            ptLowerLeft = btnSender.PointToScreen(ptLowerLeft);
            jContextMenu2.Show(ptLowerLeft);
        }

        private void jPictureBox2_Click(object sender, EventArgs e)
        {
            XMessageBox msg = new XMessageBox();
            msg.SetInfo(LicenceManager.message, MessageBoxButtons.OK, "Licence Info");
            msg.ShowDialog(this);
        }

        private void MainProgram_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(isForceExit)
            {
                e.Cancel = false;
                return;
            }
            try
            {
                XMessageBox msg = new XMessageBox();
                msg.SetInfo("Are you shure you want to exit?", MessageBoxButtons.YesNo);
                msg.ShowDialog(this);

                e.Cancel = (PreferencesManager.XMessageBox == DialogResult.No);
            }
            catch
            {
                e.Cancel = false;
            }
            if(!e.Cancel)
            {
                CustomThing();
            }
            else
            {
                this.WindowState = FormWindowState.Minimized;
                ShowIcon = ShowInTaskbar = true;
            }
        }

        private void MainProgram_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void regionEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SplashScreen.regionEditor != null)
            {
                if (SplashScreen.regionEditor.WindowState == FormWindowState.Minimized)
                {
                    SplashScreen.regionEditor.Show();
                    SplashScreen.regionEditor.WindowState = FormWindowState.Normal;
                    SplashScreen.regionEditor.ShowInTaskbar = SplashScreen.regionEditor.ShowIcon = true;
                }
                else
                {
                    SplashScreen.regionEditor.WindowState = FormWindowState.Minimized;
                    SplashScreen.regionEditor.Hide();
                }
            }
            else
            {
                SplashScreen.regionEditor = new RegionEditor();
                SplashScreen.regionEditor.progress_bar2 += progress_bar;
                SplashScreen.regionEditor.Show();
                SplashScreen.regionEditor.SetStyle(pref.color[(int)EditorsColors.Region_Editor], pref.teme[(int)EditorsColors.Region_Editor], 255);
                SplashScreen.regionEditor.Opacity = 0;
                new JAnimate().FadeInForm(SplashScreen.regionEditor, 10);
                SplashScreen.regionEditor.ShowInTaskbar = SplashScreen.regionEditor.ShowIcon = true;
            }
        }

        private void precinctEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SplashScreen.precinctEditor != null)
            {
                if (SplashScreen.precinctEditor.WindowState == FormWindowState.Minimized)
                {
                    SplashScreen.precinctEditor.Show();
                    SplashScreen.precinctEditor.WindowState = FormWindowState.Normal;
                    SplashScreen.precinctEditor.ShowInTaskbar = SplashScreen.precinctEditor.ShowIcon = true;
                }
                else
                {
                    SplashScreen.precinctEditor.WindowState = FormWindowState.Minimized;
                    SplashScreen.precinctEditor.Hide();
                }
            }
            else
            {
                SplashScreen.precinctEditor = new PrecinctEditor();
                SplashScreen.precinctEditor.progress_bar2 += progress_bar;
                SplashScreen.precinctEditor.Show();
                SplashScreen.precinctEditor.SetStyle(pref.color[(int)EditorsColors.Precinct_Editor], pref.teme[(int)EditorsColors.Precinct_Editor], 255);
                SplashScreen.precinctEditor.Opacity = 0;
                new JAnimate().FadeInForm(SplashScreen.precinctEditor, 10);
                SplashScreen.precinctEditor.ShowInTaskbar = SplashScreen.precinctEditor.ShowIcon = true;
            }
        }

        private void worldTargetsEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SplashScreen.worldTargetsEditor != null)
            {
                if (SplashScreen.worldTargetsEditor.WindowState == FormWindowState.Minimized)
                {
                    SplashScreen.worldTargetsEditor.Show();
                    SplashScreen.worldTargetsEditor.WindowState = FormWindowState.Normal;
                    SplashScreen.worldTargetsEditor.ShowInTaskbar = SplashScreen.worldTargetsEditor.ShowIcon = true;
                }
                else
                {
                    SplashScreen.worldTargetsEditor.WindowState = FormWindowState.Minimized;
                    SplashScreen.worldTargetsEditor.Hide();
                }
            }
            else
            {
                SplashScreen.worldTargetsEditor = new WorldTargetsEditor();
                SplashScreen.worldTargetsEditor.progress_bar2 += progress_bar;
                SplashScreen.worldTargetsEditor.Show();
                SplashScreen.worldTargetsEditor.SetStyle(pref.color[(int)EditorsColors.WorldTargets_Editor], pref.teme[(int)EditorsColors.WorldTargets_Editor], 255);
                SplashScreen.worldTargetsEditor.Opacity = 0;
                new JAnimate().FadeInForm(SplashScreen.worldTargetsEditor, 10);
                SplashScreen.worldTargetsEditor.ShowInTaskbar = SplashScreen.worldTargetsEditor.ShowIcon = true;
            }
        }

        private void dynobjectsEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SplashScreen.dynObjectsEditor != null)
            {
                if (SplashScreen.dynObjectsEditor.WindowState == FormWindowState.Minimized)
                {
                    SplashScreen.dynObjectsEditor.Show();
                    SplashScreen.dynObjectsEditor.WindowState = FormWindowState.Normal;
                    SplashScreen.dynObjectsEditor.ShowInTaskbar = SplashScreen.dynObjectsEditor.ShowIcon = true;
                }
                else
                {
                    SplashScreen.dynObjectsEditor.WindowState = FormWindowState.Minimized;
                    SplashScreen.dynObjectsEditor.Hide();
                }
            }
            else
            {
                SplashScreen.dynObjectsEditor = new DynObjectsEditor();
                SplashScreen.dynObjectsEditor.progress_bar2 += progress_bar;
                SplashScreen.dynObjectsEditor.Show();
                SplashScreen.dynObjectsEditor.SetStyle(pref.color[(int)EditorsColors.DynObjects_Editor], pref.teme[(int)EditorsColors.DynObjects_Editor], 255);
                SplashScreen.dynObjectsEditor.Opacity = 0;
                new JAnimate().FadeInForm(SplashScreen.dynObjectsEditor, 10);
                SplashScreen.dynObjectsEditor.ShowInTaskbar = SplashScreen.dynObjectsEditor.ShowIcon = true;
            }
        }

        private void startStandaloneToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Process process = new Process();
            // Configure the process using the StartInfo properties.
            process.StartInfo.FileName = appPath;
            process.StartInfo.Arguments = "\"-start " + (int)EditorsColors.Region_Editor + "\"";
            process.Start();
        }

        private void startStandaloneToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            Process process = new Process();
            // Configure the process using the StartInfo properties.
            process.StartInfo.FileName = appPath;
            process.StartInfo.Arguments = "\"-start " + (int)EditorsColors.Precinct_Editor + "\"";
            process.Start();
        }

        private void startStandaloneToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            Process process = new Process();
            // Configure the process using the StartInfo properties.
            process.StartInfo.FileName = appPath;
            process.StartInfo.Arguments = "\"-start " + (int)EditorsColors.WorldTargets_Editor + "\"";
            process.Start();
        }

        private void startStandaloneToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            Process process = new Process();
            // Configure the process using the StartInfo properties.
            process.StartInfo.FileName = appPath;
            process.StartInfo.Arguments = "\"-start " + (int)EditorsColors.DynObjects_Editor + "\"";
            process.Start();
        }

        private void extraDropEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SplashScreen.ExtraDropEditor != null)
            {
                if (SplashScreen.ExtraDropEditor.WindowState == FormWindowState.Minimized)
                {
                    SplashScreen.ExtraDropEditor.Show();
                    SplashScreen.ExtraDropEditor.WindowState = FormWindowState.Normal;
                    SplashScreen.ExtraDropEditor.ShowInTaskbar = SplashScreen.ExtraDropEditor.ShowIcon = true;
                }
                else
                {
                    SplashScreen.ExtraDropEditor.WindowState = FormWindowState.Minimized;
                    SplashScreen.ExtraDropEditor.Hide();
                }
            }
            else
            {
                SplashScreen.ExtraDropEditor = new ExtraDropSave();
                SplashScreen.ExtraDropEditor.progress_bar2 += progress_bar;
                SplashScreen.ExtraDropEditor.Show();
                SplashScreen.ExtraDropEditor.SetStyle(pref.color[(int)EditorsColors.ExtraDropSev], pref.teme[(int)EditorsColors.ExtraDropSev], 255);
                SplashScreen.ExtraDropEditor.Opacity = 0;
                new JAnimate().FadeInForm(SplashScreen.ExtraDropEditor, 10);
                SplashScreen.ExtraDropEditor.ShowInTaskbar = SplashScreen.ExtraDropEditor.ShowIcon = true;
            }
        }
    }
}
