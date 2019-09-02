using Gpckx;
using JHUI;
using JHUI.Forms;
using JHUI.Native;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ultimate_Editor.Clases.AngelicaFileManager;

namespace PWDataEditorPaied.AngelicaFileManager
{
    public partial class FileRip : JForm
    {
        private string ElementEditorPath = "";
        private string FileToRip = "";
        private string[] FilesToRip = null;
        private string saveDirectory = "";
        private string mainPackName;
        private List<string> gfx = new List<string>();
        private List<string> sfx = new List<string>();
        private List<string> atk = new List<string>();
        private PackDatabase packDatabase = null;
        private int index = 0;

        private PackHelper getManager(string name, string path, Action doneEvent = null, bool hasProgress = false, bool isThread = true)
        {
            PackHelper tpackManager = PackDatabase.Instance.getManager(name, path, doneEvent, isThread);
            if (tpackManager != null)
            {
                if (hasProgress)
                    tpackManager.progress_bar += progress_bar;
                tpackManager.ReadTableIsDone = doneEvent;
            }
            return tpackManager;
        }

        private PackHelper getManager(string name)
        {
            return packDatabase.getManager(name);
        }

        public FileRip(string[] path, string saveDirectory, string ElementEditorPath)
        {
            if (path == null || path.Length == 0)
            {
                this.Close();
            }
            index = 0;
            packDatabase = PackDatabase.Instance;
            this.ElementEditorPath = ElementEditorPath;
            FilesToRip = path;
            FileToRip = FilesToRip[index];
            this.saveDirectory = saveDirectory;
            InitializeComponent();
           
            this.StartPosition = FormStartPosition.Manual;
            this.Opacity = 1;
            this.PaintTopBorder = false;
            this.TopMost = true;

            Taskbar myTaskbar = new Taskbar();
            switch (myTaskbar.Position)
            {
                case TaskbarPosition.Left:
                    Location = new Point(myTaskbar.Bounds.Width + 5, myTaskbar.Bounds.Height - Height - 5);
                    break;
                case TaskbarPosition.Top:
                    Location = new Point(myTaskbar.Bounds.Width - Width - 5, myTaskbar.Bounds.Height + 5);
                    break;
                case TaskbarPosition.Right:
                    Location = new Point(myTaskbar.Bounds.X - Width - 5, myTaskbar.Bounds.Height - Height - 5);
                    break;
                case TaskbarPosition.Bottom:
                    Location = new Point(myTaskbar.Bounds.Width - Width - 5, myTaskbar.Bounds.Y - Height - 5);
                    break;
                case TaskbarPosition.Unknown:
                default:
                    Location = new Point(Screen.PrimaryScreen.Bounds.Width - Width - 5, Screen.PrimaryScreen.Bounds.Height - Height - 5);
                    break;
            }
          //  Thread tg = new Thread(() => { DoWork(); });
          //  tg.IsBackground = true;
          //  tg.Start();
           
        }

        public void progress_bar(String value, int min, int max)
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)delegate () { progress_bar(value, min, max); });
                return;
            }
            try
            {
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
            catch { }
        }

        private void DoWork()
        {
            try
            {
                mainPackName = FileToRip.Split(Path.DirectorySeparatorChar)[0] + ".pck";
                string packPath = Directory.GetParent(Path.GetDirectoryName(ElementEditorPath)).FullName + Path.DirectorySeparatorChar + mainPackName;
                PackHelper man = getManager(mainPackName, packPath, FinishExtractingMainFile, true);
                if (man == null)
                {
                    AllDone();
                }
            }
            catch { AllDone(); }
        }

        public void FinishExtractingMainFile()
        {
            try
            {
                progress_bar("Extracting files", 0, 0);
            }
            catch { }
            List<PckEntry> dd = getManager(mainPackName).getDirectory(Path.GetDirectoryName(FileToRip));
            List<PckEntry> ecrm = new List<PckEntry>();
            int maxCount = 1;
            int entryCount = ecrm.Count;
            int cnow = 0;

            if (maxCount > 1000)
                maxCount = entryCount / 100;
            else
                maxCount = entryCount / 10;

            if (maxCount <= 1)
            {
                maxCount = 1;
            }

            for (int i = 0; i < dd.Count; i ++)
            {
                if (cnow > maxCount)
                {
                    Application.DoEvents();
                    progress_bar("Saving files ....", i, entryCount);
                    cnow = 0;
                }
                cnow++;
                string dirpath = Path.GetDirectoryName(Path.Combine(saveDirectory, dd[i].fullP));
                string subpath = Path.Combine(saveDirectory, dd[i].fullP);
                string fileEx = Path.GetExtension(subpath).Replace(".", "").ToLower();
                
                if (!Directory.Exists(dirpath))
                    Directory.CreateDirectory(dirpath);

                if (fileEx.Equals("ecm"))
                    ecrm.Add(dd[i]);

                File.WriteAllBytes(subpath, dd[i].bytes);
            }
            if (maxCount > 1000)
                maxCount = entryCount / 100;
            else
                maxCount = entryCount / 10;

            if (maxCount <= 1)
            {
                maxCount = 1;
            }
            cnow = 0;
            entryCount = ecrm.Count;
            //Gather info

            try
            {
                for (int i = 0; i < ecrm.Count; i++)
                {
                    if (cnow > maxCount)
                    {
                        Application.DoEvents();
                        progress_bar("Geting additional files ....", i, entryCount);
                        cnow = 0;
                    }
                    cnow++;
                    ParseSkyFile(ecrm[i]);
                }
            }
            catch { };
            progress_bar("Please wait...", 0, 0);
            Application.DoEvents();
            /*
            DialogResult result = lastDiaResult;
            if (!confirm)
            {
                if (gfx.Count != 0 && sfx.Count != 0 && atk.Count != 0)
                {
                    result = JMessageBox.Show(this, "We found " + gfx.Count + " GFX, " + sfx.Count + " SFX and " + atk.Count + " ATK file would you like to extract them? ", "Other files to extract", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, FormStartPosition.CenterScreen);
                }
                else if (gfx.Count == 0 && sfx.Count != 0 && atk.Count != 0)
                {
                    result = JMessageBox.Show(this, "We found " + sfx.Count + " SFX and " + atk.Count + " ATK files would you like to extract them? ", "Other files to extract", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, FormStartPosition.CenterScreen);
                }
                else if (gfx.Count != 0 && sfx.Count == 0 && atk.Count != 0)
                {
                    result = JMessageBox.Show(this, "We found " + gfx.Count + " GFX and " + atk.Count + " ATK files would you like to extract them? ", "Other files to extract", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, FormStartPosition.CenterScreen);
                }
                else if (gfx.Count != 0 && sfx.Count != 0 && atk.Count == 0)
                {
                    result = JMessageBox.Show(this, "We found " + gfx.Count + " GFX and " + sfx.Count + " SFX files would you like to extract them? ", "Other files to extract", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, FormStartPosition.CenterScreen);
                }
                else if (gfx.Count == 0 && sfx.Count == 0 && atk.Count != 0)
                {
                    result = JMessageBox.Show(this, "We found " + atk.Count + " ATK files would you like to extract them? ", "Other files to extract", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, FormStartPosition.CenterScreen);
                }
                else if (gfx.Count != 0 && sfx.Count == 0 && atk.Count == 0)
                {
                    result = JMessageBox.Show(this, "We found " + gfx.Count + " GFX files would you like to extract them? ", "Other files to extract", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, FormStartPosition.CenterScreen);
                }
                else if (gfx.Count == 0 && sfx.Count != 0 && atk.Count == 0)
                {
                    result = JMessageBox.Show(this, "We found " + sfx.Count + " SFX files would you like to extract them? ", "Other files to extract", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, FormStartPosition.CenterScreen);
                }
                confirm = true;
            }
            */
 //           if(result == DialogResult.Yes)
 //           {
                //Process Extra Files
                Task<bool>[] taskList = {
                    Task.Factory.StartNew(() => ExtractGfx()),
                    Task.Factory.StartNew(() => ExtractSfx()),
                    Task.Factory.StartNew(() => ExtractAtk())
                };
                progress_bar("Extracting extra files please wait...", 0, 0);
                Application.DoEvents();
                Task.WaitAll(taskList);
                this.AllDone();
 //           }
 //           else
//               this.AllDone();

            
            //lastDiaResult = result;

        }

        private bool ExtractAtk()
        {
            try
            {
                string sfx = Directory.GetParent(Path.GetDirectoryName(ElementEditorPath)).FullName + Path.DirectorySeparatorChar + "gfx.pck";
                PackHelper gfxManager = getManager("gfx.pck", sfx, null, false, false);
                if (gfxManager == null) return true;

                foreach (string str in this.atk)
                {
                    List<PckEntry> dd = gfxManager.getDirectory(Path.GetDirectoryName(str), true, Path.GetFileName(str));
                    for (int i = 0; i < dd.Count; i++)
                    {
                        PckEntry curGfx = dd[i];
                        string dirpath = Path.GetDirectoryName(Path.Combine(saveDirectory, curGfx.fullP));
                        string subpath = Path.Combine(saveDirectory, curGfx.fullP);
                        string fileEx = Path.GetExtension(subpath).Replace(".", "").ToLower();
                        if (!Directory.Exists(dirpath))
                            Directory.CreateDirectory(dirpath);

                        File.WriteAllBytes(subpath, curGfx.bytes);

                    }

                }
            }
            catch { }
            return true;
        }

        public bool ExtractGfx()
        {
            try
            {
                string gfx = Directory.GetParent(Path.GetDirectoryName(ElementEditorPath)).FullName + Path.DirectorySeparatorChar + "gfx.pck";
                PackHelper gfxManager = getManager("gfx.pck", gfx, null, true, false);
                if (gfxManager == null) return true;
                foreach (string str in this.gfx)
                {
                    List<PckEntry> dd = gfxManager.getDirectory(Path.GetDirectoryName(str), true, Path.GetFileName(str));
                    for (int i = 0; i < dd.Count; i++)
                    {
                        PckEntry curGfx = dd[i];
                        string dirpath = Path.GetDirectoryName(Path.Combine(saveDirectory, curGfx.fullP));
                        string subpath = Path.Combine(saveDirectory, curGfx.fullP);
                        string fileEx = Path.GetExtension(subpath).Replace(".", "").ToLower();
                        if (!Directory.Exists(dirpath))
                            Directory.CreateDirectory(dirpath);

                        File.WriteAllBytes(subpath, curGfx.bytes);
                        SaveTextures(curGfx);

                    }

                }
            }
            catch { }
            return true;
        }

        public void SaveTextures(PckEntry entry)
        {
            try
            {
                string gfx = Directory.GetParent(Path.GetDirectoryName(ElementEditorPath)).FullName + Path.DirectorySeparatorChar + "gfx.pck";
                const Int32 BufferSize = 128;
                using (var streamReader = new StreamReader(new MemoryStream(entry.bytes), Encoding.GetEncoding("GB2312"), true, BufferSize))
                {
                    String line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        if (line.ToLower().StartsWith("texfile"))
                        {
                            string fileName = line.Split(':')[1].TrimStart();
                            if (fileName.Length > 3)
                            {
                                PackHelper aa = getManager("gfx.pck", gfx, null);
                                if (aa != null)
                                {
                                    List<PckEntry> dd = aa.getDirectory("gfx" + Path.DirectorySeparatorChar + "textures" + Path.DirectorySeparatorChar + Path.GetDirectoryName(fileName), true, Path.GetFileName(fileName));
                                    for (int i = 0; i < dd.Count; i++)
                                    {
                                        PckEntry curGfx = dd[i];
                                        string dirpath = Path.GetDirectoryName(Path.Combine(saveDirectory, curGfx.fullP));
                                        string subpath = Path.Combine(saveDirectory, curGfx.fullP);
                                        string fileEx = Path.GetExtension(subpath).Replace(".", "").ToLower();
                                        if (!Directory.Exists(dirpath))
                                            Directory.CreateDirectory(dirpath);

                                        File.WriteAllBytes(subpath, curGfx.bytes);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch { }
        }

        public bool ExtractSfx()
        {
            try
            {
                string sfx = Directory.GetParent(Path.GetDirectoryName(ElementEditorPath)).FullName + Path.DirectorySeparatorChar + "sfx.pck";
                PackHelper gfxManager = getManager("sfx.pck", sfx, null, false, false);
                if (gfxManager == null) return true;
                foreach (string str in this.sfx)
                {
                    List<PckEntry> dd = gfxManager.getDirectory(Path.GetDirectoryName(str), true, Path.GetFileName(str));
                    for (int i = 0; i < dd.Count; i++)
                    {
                        PckEntry curGfx = dd[i];
                        string dirpath = Path.GetDirectoryName(Path.Combine(saveDirectory, curGfx.fullP));
                        string subpath = Path.Combine(saveDirectory, curGfx.fullP);
                        string fileEx = Path.GetExtension(subpath).Replace(".", "").ToLower();
                        if (!Directory.Exists(dirpath))
                            Directory.CreateDirectory(dirpath);

                        File.WriteAllBytes(subpath, curGfx.bytes);

                    }

                }
            }
            catch { }
            return true;
        }

        public void ParseSkyFile(PckEntry entry)
        {
            try
            {
                gfx = new List<string>();
                sfx = new List<string>();
                atk = new List<string>();
                const Int32 BufferSize = 128;
                using (var streamReader = new StreamReader(new MemoryStream(entry.bytes), Encoding.GetEncoding("GB2312"), true, BufferSize))
                {
                    String line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        if (line.ToLower().StartsWith("fxfilepath"))
                        {
                            string fileName = line.Split(':')[1].TrimStart();
                            if (fileName.Length > 3)
                            {
                                string fileExt = Path.GetExtension(fileName).Replace(".", "").ToLower();
                                switch (fileExt)
                                {
                                    case "gfx":
                                        gfx.Add(("gfx" + Path.DirectorySeparatorChar + fileName).Replace("/", "\\"));
                                        break;
                                    case "ogg":
                                    case "wav":
                                        sfx.Add(("sfx" + Path.DirectorySeparatorChar + fileName.Replace("/", "\\")));
                                        break;
                                }
                            }
                        }
                        if (line.ToLower().StartsWith("atkpath"))
                        {
                            string fileName = line.Split(':')[1].TrimStart();
                            if (fileName.Length > 3)
                            {
                                atk.Add(("gfx" + Path.DirectorySeparatorChar + "skillattack" + Path.DirectorySeparatorChar + fileName.Replace("/", "\\")));
                            }
                        }
                    }
                }
            }catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            
        }

        /// <summary>
        /// Dispose this class
        /// </summary>
        public void AllDone()
        {
            if(FilesToRip.Length -1 > index)
            {
                    index++;
                    FileToRip = FilesToRip[index];
                    // Thread tg = new Thread(() => { DoWork(); });
                    //  tg.IsBackground = true;
                    //  tg.Start();
                    DoWork();
                return;
            }
            else
            {
                if (this.InvokeRequired)
                {
                    this.BeginInvoke(new MethodInvoker(delegate {
                        this.Close();
                    }));
                    return;
                }
                else
                {
                    this.Close();
                }
            }
        }

        private void FileRip_FormClosing(object sender, FormClosingEventArgs e)
        {
            PackDatabase.Instance.Clear();
        }

        private void FileRip_Shown(object sender, EventArgs e)
        {
            //  Thread tg = new Thread(() => { DoWork(); });
            //  tg.IsBackground = true;
            //  tg.Start();
            DoWork();
        }
    }
}
