using Etier.IconHelper;
using Gpckx;
using JHUI.Forms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using JHUI;
using Ultimate_Editor.Clases.AngelicaFileManager;
using JHUI.Components;
using PWDataEditorPaied.Forms.SubForms;
using PWDataEditorPaied.Properties;
using ElementEditor;
using PWDataEditorPaied.Classes;

namespace Pck_Guy_View
{
    public partial class PackView : JForm
    {
        private readonly string[] SizeSuffixes = { "b", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };
        private string unppack_path;
        internal delegate void UpdateProgressDelegate(String value, int min, int max);
        internal event UpdateProgressDelegate progress_bar2;
        private string fiullFilePath;

        public static PackView Instance;
        public void progress_bar(String value, int min, int max)
        {
            try
            {
                if (InvokeRequired)
                {
                    Invoke((MethodInvoker)delegate () { progress_bar(value, min, max); });
                    return;
                }
                progressBar1.Maximum = max;
                progressBar1.Value = min;
                progres.Text = value;
                if (progress_bar2 != null)
                {
                    progress_bar2(value, min, max);
                }
            }
            catch { }
        }


        private IconListManager _iconListManager;
        private PackHelper openedPckFies = null;
        private ImageList _smallImageList = new ImageList();
        private ImageList _largeImageList = new ImageList();
        public PackView()
        {
            InitializeComponent();
            this.MinimizeBox = Program.SHOWMINIMIZEBUTTON;
            _smallImageList.ColorDepth = ColorDepth.Depth32Bit;
            _largeImageList.ColorDepth = ColorDepth.Depth32Bit;

            _smallImageList.ImageSize = new System.Drawing.Size(16, 16);
            _largeImageList.ImageSize = new System.Drawing.Size(32, 32);

            _iconListManager = new IconListManager(_smallImageList, _largeImageList);
            FileList.SmallImageList = _smallImageList;
            FileList.LargeImageList = _largeImageList;
            pictureBox1.AllowDrop = true;
            Instance = this;
            JToolTip tool = new JToolTip();
            tool.SetToolTip(pictureBox1, "Open pck.");
            tool.SetToolTip(SavePackBox, "Save Changes.");
            tool.SetToolTip(RewritePackBox, "Rewrite PCK From Disk or into memory.");
            tool.SetToolTip(pictureBox2, "Unpack pck.");
            tool.SetToolTip(jPictureBox1, "Create new pck from files");
        }

        private void listView1_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }    
        private string SizeSuffix(Int64 value)
        {
            if (value < 0) { return "-" + SizeSuffix(-value); }
            if (value == 0) { return "0 b"; }

            int mag = (int)Math.Log(value, 1024);
            decimal adjustedSize = (decimal)value / (1L << (mag * 10));
            int final_ = (int)adjustedSize;
            String ret = final_ + " " + SizeSuffixes[mag];
            return ret;
        }

        public static double ConvertSize(double bytes, string type)
        {
            try
            {
                const int CONVERSION_VALUE = 1024;
                //determine what conversion they want
                switch (type)
                {
                    case "BY":
                        //convert to bytes (default)
                        return bytes;
                    case "KB":
                        //convert to kilobytes
                        return (bytes / CONVERSION_VALUE);
                    case "MB":
                        //convert to megabytes
                        return (bytes / CalculateSquare(CONVERSION_VALUE));
                    case "GB":
                        //convert to gigabytes
                        return (bytes / CalculateCube(CONVERSION_VALUE));
                    default:
                        //default
                        return bytes;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }
        public static double CalculateSquare(Int32 number)
        {
            return Math.Pow(number, 2);
        }
        public static double CalculateCube(Int32 number)
        {
            return Math.Pow(number, 3);
        }
        public PackStructureManager selectedPck;
        public FolderTreeModel selectedtree;
        public Dictionary<int, FolderTreeModel> folderDeeplist;
        public int folderDeep = 0;

        public bool lockedItemDrop = false;
        private bool lockedItemSelect = false;
        public bool autoLoad = false;
        public string autoOpenPath = "";

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lockedItemSelect) return;
            int index = -1;
            if (FileList.SelectedIndices.Count > 0)
            {
                index = FileList.SelectedIndices[0];
            }

            if (index >= 0)
            {
                string filepathxy = FileList.Items[index].Text;
                ListViewItem lvi = null;
                this.FileList.SuspendLayout();
                this.FileList.BeginUpdate();
                if(filepathxy.Equals(".."))
                {
                    folderDeep--;
                    if (folderDeep <= 0)
                    {
                        this.FileList.EndUpdate();
                        folderDeeplist = new Dictionary<int, FolderTreeModel>();
                        drawListViewInitial();
                        return;
                    }else
                    {
                        if (folderDeeplist != null)
                        {
                            Console.WriteLine("Back");
                            FileList.Items.Clear();
                            lvi = new ListViewItem();
                            lvi.Text = "..";
                            lvi.ImageIndex = _iconListManager.AddFileId("d", "d", true);
                            FileList.Items.Add(lvi);
                            selectedtree = folderDeeplist[folderDeep - 1];
                            foreach (FolderTreeModel row in folderDeeplist[folderDeep-1].Rows.OrderBy(o => o.File != null).ToList())
                            {
                                lvi = new ListViewItem();
                                lvi.Text = row.Title;
                                if (row.File != null)
                                {
                                    lvi.ImageIndex = _iconListManager.AddFileId(Path.GetExtension(row.Title), row.Title, false);
                                    double compresRatio = ConvertSize(row.File.decompressedSize, "MB") - ConvertSize(row.File.compressedSize, "MB") / ConvertSize(row.File.decompressedSize, "MB");
                                    lvi.SubItems.Add(SizeSuffix(row.File.compressedSize));
                                    lvi.SubItems.Add(SizeSuffix(row.File.decompressedSize));
                                    lvi.SubItems.Add((compresRatio * 100).ToString("F").Substring(1) + " %");
                                    lvi.Tag = row.File;
                                }
                                else
                                {
                                    lvi.ImageIndex = _iconListManager.AddFileId(row.Title, row.Title, true);
                                    lvi.SubItems.Add("-");
                                    lvi.SubItems.Add("-");
                                    lvi.SubItems.Add("-");
                                    lvi.Tag = row;
                                }
                                FileList.Items.Add(lvi);
                            }
                            folderDeeplist.Remove(folderDeep);
                        }
                    }
                }
                else if (FileList.Items[index].Tag != null && FileList.Items[index].Tag is PackStructureManager)
                {
                    Console.WriteLine("In pck");
                    selectedPck = (PackStructureManager)FileList.Items[index].Tag;
                    FileList.Items.Clear();
                    lvi = new ListViewItem();
                    lvi.Text = "..";
                    lvi.ImageIndex = _iconListManager.AddFileId("d", "d", true);
                    FileList.Items.Add(lvi);
                    if (selectedPck.root.Rows.Count > 0)
                    {
                        selectedtree = selectedPck.root.Rows[0];
                        folderDeeplist[folderDeep] = selectedtree;
                        foreach (FolderTreeModel row in selectedtree.Rows.OrderBy(o => o.File != null).ToList())
                        {
                            lvi = new ListViewItem();
                            lvi.Text = row.Title;
                            if (row.File != null)
                            {
                                lvi.ImageIndex = _iconListManager.AddFileId(Path.GetExtension(row.Title), row.Title, false);
                                double compresRatio = ConvertSize(row.File.decompressedSize, "MB") - ConvertSize(row.File.compressedSize, "MB") / ConvertSize(row.File.decompressedSize, "MB");
                                lvi.SubItems.Add(SizeSuffix(row.File.compressedSize));
                                lvi.SubItems.Add(SizeSuffix(row.File.decompressedSize));
                                lvi.SubItems.Add((compresRatio * 100).ToString("F").Substring(1) + " %");
                                lvi.Tag = row.File;
                            }
                            else
                            {
                                lvi.ImageIndex = _iconListManager.AddFileId(row.Title, row.Title, true);
                                lvi.SubItems.Add("-");
                                lvi.SubItems.Add("-");
                                lvi.SubItems.Add("-");
                                lvi.Tag = row;
                            }
                            FileList.Items.Add(lvi);
                        }
                        folderDeep++;
                    }else
                    {
                        selectedtree = selectedPck.root;
                        folderDeeplist[folderDeep] = selectedtree;
                    }
                }
                else if (FileList.Items[index].Tag != null && FileList.Items[index].Tag is FolderTreeModel)
                {
                    Console.WriteLine("In Directory");
                    
                    selectedtree = (FolderTreeModel)FileList.Items[index].Tag;
                    FileList.Items.Clear();
                    lvi = new ListViewItem();
                    lvi.Text = "..";
                    lvi.ImageIndex = _iconListManager.AddFileId("d", "d", true);
                    FileList.Items.Add(lvi);
                    folderDeeplist[folderDeep] = selectedtree;
                    foreach (FolderTreeModel row in selectedtree.Rows.OrderBy(o => o.File != null).ToList())
                    {
                        lvi = new ListViewItem();
                        lvi.Text = row.Title;
                        if (row.File != null)
                        {
                            lvi.ImageIndex = _iconListManager.AddFileId(Path.GetExtension(row.Title), row.Title, false);
                            double compresRatio = ConvertSize(row.File.decompressedSize, "MB") - ConvertSize(row.File.compressedSize, "MB") / ConvertSize(row.File.decompressedSize, "MB");
                            lvi.SubItems.Add(SizeSuffix(row.File.compressedSize));
                            lvi.SubItems.Add(SizeSuffix(row.File.decompressedSize));
                            lvi.SubItems.Add((compresRatio * 100).ToString("F").Substring(1) + " %");
                            lvi.Tag = row.File;
                        }
                        else
                        {
                            lvi.ImageIndex = _iconListManager.AddFileId(row.Title, row.Title, true);
                            lvi.SubItems.Add("-");
                            lvi.SubItems.Add("-");
                            lvi.SubItems.Add("-");
                            lvi.Tag = row;
                        }
                        
                        FileList.Items.Add(lvi);
                    }
                    folderDeep++;
                }
                this.FileList.ResumeLayout();
                this.FileList.EndUpdate();
                textBox1.Text = "";
                foreach (FolderTreeModel list in folderDeeplist.Values)
                {
                    textBox1.AppendText(list.Title + Path.DirectorySeparatorChar);
                }
                string ddd = textBox1.Text;
                textBox1.Text = ddd.TrimEnd(Path.DirectorySeparatorChar);
            }
        }

        public void SetStyle(JColorStyle style, JThemeStyle thme, int alpha)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate {
                    SetStyle(style, thme, alpha);
                }));
                return;
            }
            this.components.SetStyle(this, style, thme, alpha);
        }

        public void drawListViewInitial()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate {
                    drawListViewInitial();
                }));
                return;
            }
            folderDeeplist = new Dictionary<int, FolderTreeModel>();
            folderDeep = 0;
            FileList.Items.Clear();
            ListViewItem lvi = new ListViewItem();
            textBox1.Text = "";
            PackStructureManager row = openedPckFies.directoryStructure;
            lvi = new ListViewItem();
            lvi.Text = row.Title;
            lvi.ImageIndex = _iconListManager.AddFileId(row.Title, row.Title, true);
            lvi.Tag = row;
            FileList.Items.Add(lvi);
            selectedtree = null;
            FileList.Items[0].Selected = true;
            FileList.Select();
            listView1_MouseDoubleClick(null, null);
            progress_bar("Ready", 0, 0);
        }

        private void listView1_DragOver_1(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void listView1_DragDrop_1(object sender, DragEventArgs e)
        {
            lockedItemSelect = true;
            string[] paths = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (selectedPck != null && paths != null && paths.Length >= 0)
            {
                string packFullPath = selectedPck.Title;
                if (openedPckFies != null)
                {
                    Dictionary<string, PckEntry> path_datafile = new Dictionary<string, PckEntry>();

                    for (int i =0;i< paths.Length;i++)
                    {
                        string FilePath = paths[i];
                        progress_bar("Adding files...", i, paths.Length);
                        Application.DoEvents();
                        if (Path.GetExtension(FilePath) == ".pck" || Path.GetExtension(FilePath) == ".rar" || Path.GetExtension(FilePath) == ".zip")
                        {

                        }
                        else
                        {
                            string DirectoryPath = textBox1.Text + FilePath.Replace(Path.GetDirectoryName(FilePath), "").Replace("/", "\\");
                            if (Path.HasExtension(FilePath))
                            {
                                openedPckFies.addFilesToTable(DirectoryPath, FilePath);
                            }
                            else
                            {
                                string[] files = Directory.GetFiles(FilePath, "*", SearchOption.AllDirectories);
                                for (int x = 0; x < files.Length; x++)
                                {
                                    string sFilePath = files[x];
                                    progress_bar("Adding sub-files...", x, files.Length);
                                    Application.DoEvents();
                                    DirectoryPath = textBox1.Text + Path.DirectorySeparatorChar + sFilePath.Replace(Path.GetDirectoryName(FilePath), "").Replace("/", "\\").Remove(0, 1);
                                    if (Path.HasExtension(sFilePath))
                                    {
                                        openedPckFies.addFilesToTable(DirectoryPath, sFilePath);
                                    }
                                }
                            }
                        }


                    }



                    progress_bar("Drawing grid", 0, 0);
                    this.FileList.SuspendLayout();
                    this.FileList.BeginUpdate();
                    if (selectedtree.Rows == null || selectedtree.Rows != null && selectedtree.Rows.Count == 0)
                        selectedtree = selectedPck.root;


                    FileList.Items.Clear();
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = "..";
                    lvi.ImageIndex = _iconListManager.AddFileId("d", "d", true);
                    FileList.Items.Add(lvi);

                    foreach (FolderTreeModel row in selectedtree.Rows.OrderBy(o => o.File != null).ToList())
                    {
                        lvi = new ListViewItem();
                        lvi.Text = row.Title;
                        if (row.File != null)
                        {
                            lvi.ImageIndex = _iconListManager.AddFileId(Path.GetExtension(row.Title), row.Title, false);
                            double compresRatio = ConvertSize(row.File.decompressedSize, "MB") - ConvertSize(row.File.compressedSize, "MB") / ConvertSize(row.File.decompressedSize, "MB");
                            lvi.SubItems.Add(SizeSuffix(row.File.compressedSize));
                            lvi.SubItems.Add(SizeSuffix(row.File.decompressedSize));
                            lvi.SubItems.Add((compresRatio * 100).ToString("F").Substring(1) + " %");
                            lvi.Tag = row.File;
                        }
                        else
                        {
                            lvi.ImageIndex = _iconListManager.AddFileId(row.Title, row.Title, true);
                            lvi.SubItems.Add("-");
                            lvi.SubItems.Add("-");
                            lvi.SubItems.Add("-");
                            lvi.Tag = row;
                        }

                        FileList.Items.Add(lvi);
                    }
                    // folderDeep++;
                }
                this.FileList.ResumeLayout();
                this.FileList.EndUpdate();
                textBox1.Text = "";
                foreach (FolderTreeModel list in folderDeeplist.Values)
                {
                    textBox1.AppendText(list.Title + Path.DirectorySeparatorChar);
                }
                string ddd = textBox1.Text;
                textBox1.Text = ddd.TrimEnd(Path.DirectorySeparatorChar);



            }
            else
            {
                JMessageBox.Show(this, "Please enter pck directory.");
            }
            lockedItemSelect = false;
            progress_bar("Ready", 0, 0);
        }

        private void updateStatus()
        {
            if (selectedPck == null)
            {
                if(this.fiullFilePath.Length > 0)
                {
                    label_path.Text = this.fiullFilePath;
                    if (openedPckFies.table != null)
                    {

                        label_files.Text = openedPckFies.table.Count.ToString();
                        label_comp.Text = PackConfigs.compression.ToString();
                    }
                }
                return;
            }
            else
            {

                if (openedPckFies != null)
                {
                    label_path.Text = selectedPck.fiullFilePath;
                    label_files.Text = openedPckFies.table.Count.ToString();
                    label_comp.Text = PackConfigs.compression.ToString();
                }
            }

        }

        private void listView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            //Extract file
            if (lockedItemDrop)
            {
                return;
            }
            if(selectedPck == null)
            {
                return;
            }
            List<PckEntry> selectedFiles = new List<PckEntry>();
            string pckName = selectedPck.fiullFilePath;
            if (openedPckFies != null)
            {
                lockedItemDrop = true;
                foreach (ListViewItem item in FileList.SelectedItems)
                {
                    int index = item.Index;
                    if (FileList.Items[index].Tag is PckEntry)
                    {
                        PckEntry file = (PckEntry)FileList.Items[index].Tag;
                        if (file != null)
                        {
                            byte[] bytes = openedPckFies.getChunk(file.packPath, file);
                            if (bytes != null)
                            {
                                file.memory = new MemoryStream(openedPckFies.getChunk(file.packPath, file));
                                selectedFiles.Add(file);
                            }
                        }
                    }
                }
                DataDragObject dataDragObject = new DataDragObject(selectedFiles.ToArray());
                dataDragObject.SetData(NativeMethods.CFSTR_FILEDESCRIPTORW, null);
                dataDragObject.SetData(NativeMethods.CFSTR_FILECONTENTS, null);
                dataDragObject.SetData(NativeMethods.CFSTR_PERFORMEDDROPEFFECT, null);
                DoDragDrop(dataDragObject, DragDropEffects.Copy);
                lockedItemDrop = false;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            unpacking = false;
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open Pck File";
            theDialog.Filter = "Pck files|*.Pck";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                string path = theDialog.FileName;
                if (Path.GetExtension(path) == ".pck")
                {
                    unppack_path = path;
                }
                if (unppack_path.Length <= 1)
                {
                    JMessageBox.Show( this, "Please select .pck!");
                }
                else
                {
                    autoOpenPath = unppack_path;
                    autoLoad = true;
                    openedPckFies = new PackHelper(unppack_path, true);
                    openedPckFies.ReadTableIsDone = initialRead;
                    openedPckFies.progress_bar += progress_bar;
                    this.fiullFilePath = unppack_path;
                }
            }
        }

        private void initialRead()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate {
                    findIndex(openedPckFies.version);
                    drawListViewInitial();
                    try
                    {
                        label_path.Text = openedPckFies.path;
                        label_files.Text = openedPckFies.table.Count().ToString();
                        label_comp.Text = PackConfigs.compression.ToString();
                    }
                    catch { }
                    return;
                }));
            }else
            {
                findIndex(openedPckFies.version);
                drawListViewInitial();
                    try
                    {
                        label_path.Text = openedPckFies.path;
                        label_files.Text = openedPckFies.table.Count().ToString();
                        label_comp.Text = PackConfigs.compression.ToString();
                }
                    catch { }
            }
            
        }

        private void findIndex(short version)
        {
            int i = 0;
            foreach(string da in jComboBox1.Items)
            {
                if (da == version.ToString())
                {
                    jComboBox1.SelectedIndex = i;
                    break;
                }
                i++;
            }
        }

        private void listView1_KeyUp(object sender, KeyEventArgs e)
        {
            if (FileList.Items.Count == 0)
            {
                return;
            }
            if (e.Control && e.KeyCode == Keys.A)
            {
                CheckAllItems(FileList, true);
            }
        }
        public void CheckAllItems(ListView lvw, bool check)
        {
            lvw.Items.OfType<ListViewItem>().ToList().ForEach(item => item.Selected = check);
        }

        public Point MouseDownLocation { get; private set; }

        private void SavePackBox_Click(object sender, EventArgs e)
        {
            if (lockedItemDrop || selectedPck == null)
            {
                return;
            }
            String pckName = selectedPck.fiullFilePath;
            if (openedPckFies != null)
            {
               // this.Cursor = Cursors.WaitCursor;
               // this.Enabled = false;
                openedPckFies.CompressionLevel = PackConfigs.compression;
                Thread t = new Thread(new ThreadStart(() => { openedPckFies.Update(); AutoOpen(); }));
                t.Start();
                this.updateStatus();

                //this.Enabled = true;
               // this.Cursor = Cursors.Default;
            }
        }

        private void RewritePackBox_Click(object sender, EventArgs e)
        {
            if (lockedItemDrop || selectedPck == null)
            {
                return;
            }
            string pckName = selectedPck.fiullFilePath;
            if (openedPckFies != null)
            {
                openedPckFies.CompressionLevel = PackConfigs.compression;
                if(jComboBox1.SelectedIndex != -1)
                    openedPckFies.version = short.Parse(jComboBox1.Items[jComboBox1.SelectedIndex].ToString());
                else
                {
                    openedPckFies.version = 2;
                }
                Thread t = new Thread(new ThreadStart(() => { openedPckFies.ReWrite(); drawListViewInitial(); }));
                t.Start();
            }
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (lockedItemDrop || selectedPck == null)
            {
                return;
            }
            if (unpacking) return;
            if (openedPckFies != null)
            {
                //this.Cursor = Cursors.WaitCursor;
                unpacking = true;
                openedPckFies.CompressionLevel = PackConfigs.compression;
                openedPckFies.unpack(true, compleateUnpack);
            }
        }
        bool unpacking = false;
        private void compleateUnpack()
        {
            if (InvokeRequired)
            {
                
                Invoke((MethodInvoker)delegate () {
                    // this.Cursor = Cursors.Default;
                    unpacking = false;
                    progress_bar("Ready", 0, 0);
                });
                return;
            }
            else
            {
                  // this.Cursor = Cursors.Default;
                progress_bar("Ready", 0, 0);
                unpacking = false;
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lockedItemDrop || selectedPck == null || selectedtree == null)
            {
                return;
            }
            string pckName = selectedPck.fiullFilePath;
            if (openedPckFies != null)
            {
                this.FileList.SuspendLayout();
                this.FileList.BeginUpdate();
                // this.Cursor = Cursors.WaitCursor;
                List<int> ids = new List<int>();
                foreach (ListViewItem item in FileList.SelectedItems)
                {
                    int index = item.Index;
                    if (FileList.Items[index].Tag is PckEntry)
                    {
                        PckEntry file = (PckEntry)FileList.Items[index].Tag;
                        ids.Add(file.id);
                        foreach(FolderTreeModel row in selectedtree.Rows)
                        {
                            if (row.Title == Path.GetFileName(file.filePath))
                            {
                                selectedtree.Rows.Remove(row);
                                break;
                            }
                        }
                        FileList.Items.RemoveAt(index);
                    }
                    else if (FileList.Items[index].Tag is FolderTreeModel)
                    {
                        FolderTreeModel file = (FolderTreeModel)FileList.Items[index].Tag;
                        List<PckEntry> files = openedPckFies.directoryStructure.getAllFIles(file);
                        foreach (PckEntry row in files)
                        {
                              ids.Add(row.id);
                        }
                        FileList.Items.RemoveAt(index);
                        selectedtree.Rows.Remove(file);
                    }
                }
                openedPckFies.deleteFile(ids.ToArray());
                if (selectedtree.Rows == null || selectedtree.Rows != null && selectedtree.Rows.Count == 0)
                    selectedtree = selectedPck.root;


                FileList.Items.Clear();
                ListViewItem lvi = new ListViewItem();
                lvi.Text = "..";
                lvi.ImageIndex = _iconListManager.AddFileId("d", "d", true);
                FileList.Items.Add(lvi);
                //folderDeeplist[folderDeep - 1] = selectedtree;
                foreach (FolderTreeModel row in selectedtree.Rows.OrderBy(o => o.File != null).ToList())
                {
                    lvi = new ListViewItem();
                    lvi.Text = row.Title;
                    if (row.File != null)
                    {
                        lvi.ImageIndex = _iconListManager.AddFileId(Path.GetExtension(row.Title), row.Title, false);
                        double compresRatio = ConvertSize(row.File.decompressedSize, "MB") - ConvertSize(row.File.compressedSize, "MB") / ConvertSize(row.File.decompressedSize, "MB");
                        lvi.SubItems.Add(SizeSuffix(row.File.compressedSize));
                        lvi.SubItems.Add(SizeSuffix(row.File.decompressedSize));
                        lvi.SubItems.Add((compresRatio * 100).ToString("F").Substring(1) + " %");
                        lvi.Tag = row.File;
                    }
                    else
                    {
                        lvi.ImageIndex = _iconListManager.AddFileId(row.Title, row.Title, true);
                        lvi.SubItems.Add("-");
                        lvi.SubItems.Add("-");
                        lvi.SubItems.Add("-");
                        lvi.Tag = row;
                    }

                    FileList.Items.Add(lvi);
                }
                this.FileList.ResumeLayout();
                this.FileList.EndUpdate();
                textBox1.Text = "";
                foreach (FolderTreeModel list in folderDeeplist.Values)
                {
                    textBox1.AppendText(list.Title + Path.DirectorySeparatorChar);
                }
                string ddd = textBox1.Text;
                textBox1.Text = ddd.TrimEnd(Path.DirectorySeparatorChar);
            }

        }

        private void openSettings(object sender, EventArgs e)
        {
            SettingWindow aaa = new SettingWindow();
            aaa.ShowDialog(this);
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lockedItemDrop || selectedPck == null || selectedtree == null)
            {
                return;
            }

            if (selectedtree.Rows == null || selectedtree.Rows != null && selectedtree.Rows.Count == 0)
                selectedtree = selectedPck.root;

            this.FileList.SuspendLayout();
            this.FileList.BeginUpdate();
            FileList.Items.Clear();
            ListViewItem lvi = new ListViewItem();
            lvi.Text = "..";
            lvi.ImageIndex = _iconListManager.AddFileId("d", "d", true);
            FileList.Items.Add(lvi);
            //folderDeeplist[folderDeep - 1] = selectedtree;
            foreach (FolderTreeModel row in selectedtree.Rows.OrderBy(o => o.File != null).ToList())
            {
                lvi = new ListViewItem();
                lvi.Text = row.Title;
                if (row.File != null)
                {
                    lvi.ImageIndex = _iconListManager.AddFileId(Path.GetExtension(row.Title), row.Title, false);
                    double compresRatio = ConvertSize(row.File.decompressedSize, "MB") - ConvertSize(row.File.compressedSize, "MB") / ConvertSize(row.File.decompressedSize, "MB");
                    lvi.SubItems.Add(SizeSuffix(row.File.compressedSize));
                    lvi.SubItems.Add(SizeSuffix(row.File.decompressedSize));
                    lvi.SubItems.Add((compresRatio * 100).ToString("F").Substring(1) + " %");
                    lvi.Tag = row.File;
                }
                else
                {
                    lvi.ImageIndex = _iconListManager.AddFileId(row.Title, row.Title, true);
                    lvi.SubItems.Add("-");
                    lvi.SubItems.Add("-");
                    lvi.SubItems.Add("-");
                    lvi.Tag = row;
                }

                FileList.Items.Add(lvi);
            }
            this.FileList.ResumeLayout();
            this.FileList.EndUpdate();
            textBox1.Text = "";
            foreach (FolderTreeModel list in folderDeeplist.Values)
            {
                textBox1.AppendText(list.Title + Path.DirectorySeparatorChar);
            }
            string ddd = textBox1.Text;
            textBox1.Text = ddd.TrimEnd(Path.DirectorySeparatorChar);
        }

        private void PackView_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Program.StandAlone)
            {
                e.Cancel = true;
                this.WindowState = FormWindowState.Minimized;
                this.MinimizeBox = Program.SHOWMINIMIZEBUTTON;
                if (Program.HIDEINTASKBAR)
                    ShowIcon = ShowInTaskbar = false;
            }
            else
            {
                MainProgram.getInstance().ExitInvoke();
            }
        }

        private void UnpackDirectoryOrFiles(object sender, EventArgs e)
        {
            if (lockedItemDrop || selectedPck == null || selectedtree == null)
            {
                return;
            }
            using (var fbd = new FolderBrowserDialog())
            {
                progress_bar("Extracting...", 0, 0);
                DialogResult result = fbd.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    string pckName = selectedPck.fiullFilePath;
                    string savePath = fbd.SelectedPath;
                    if (openedPckFies != null)
                    {
                        List<PckEntry> filesToSave = new List<PckEntry>();
                        // this.Cursor = Cursors.WaitCursor;
                        foreach (ListViewItem item in FileList.SelectedItems)
                        {
                            int index = item.Index;
                            if (FileList.Items[index].Tag is PckEntry)
                            {
                                PckEntry file = (PckEntry)FileList.Items[index].Tag;
                                if (Path.HasExtension(file.filePath))
                                {
                                    filesToSave.AddRange(openedPckFies.getDirectory(file.filePath, true, Path.GetFileName(file.filePath)));
                                }
                                else
                                {
                                    filesToSave.AddRange(openedPckFies.getDirectory(file.filePath));
                                }
                            }
                            else
                            {
                                if (FileList.Items[index].Tag is FolderTreeModel)
                                {
                                    FolderTreeModel file = (FolderTreeModel)FileList.Items[index].Tag;
                                    
                                    filesToSave.AddRange(openedPckFies.getDirectory(textBox1.Text + Path.DirectorySeparatorChar + file.Title));

                                }
                            }
                        }
                        if (filesToSave.Count > 0)
                        {
                            foreach (PckEntry item in filesToSave)
                            {
                                string dirpath = Path.GetDirectoryName(Path.Combine(savePath, item.fullP));
                                string subpath = Path.Combine(savePath, item.fullP);
                                string fileEx = Path.GetExtension(subpath).Replace(".", "").ToLower();
                                if (!Directory.Exists(dirpath))
                                    Directory.CreateDirectory(dirpath);

                                File.WriteAllBytes(subpath, item.bytes);
                            }
                        }
                        // this.Cursor = Cursors.Default;
                    }
                }
            }
            progress_bar("Ready", 0, 0);
        }

        private void jPictureBox1_Click(object sender, EventArgs e)
        {
            progress_bar("Creating...", 0, 0);
            RenameForm rf = new RenameForm();
            DialogResult res = rf.ShowDialog(this);
            if (res == DialogResult.OK && RenameForm.value != null && RenameForm.value.Length > 0)
            {
                using (var fbd = new FolderBrowserDialog())
                {
                    DialogResult result = fbd.ShowDialog();
                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                    {
                        string path = Path.Combine(fbd.SelectedPath, Path.GetFileNameWithoutExtension(RenameForm.value) + ".pck");
                        File.WriteAllBytes(path, Resources.BlankPk);
                        if (Path.GetExtension(path) == ".pck")
                        {
                            unppack_path = path;
                        }
                        if (unppack_path.Length <= 1)
                        {
                            JMessageBox.Show( this, "Please select .pck!");
                        }
                        else
                        {
                            openedPckFies = new PackHelper(unppack_path, true);
                            openedPckFies.ReadTableIsDone = initialRead;
                            openedPckFies.progress_bar += progress_bar;
                            this.fiullFilePath = unppack_path;
                        }

                    }
                }
            }
            progress_bar("Ready", 0, 0);
        }

        private void PackView_Shown(object sender, EventArgs e)
        {
            AutoOpen();
        }

        private void AutoOpen()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate {
                    AutoOpen();
                }));
                return;
            }
            if (autoLoad && autoOpenPath.Length > 0 && File.Exists(autoOpenPath))
            {
                string path = autoOpenPath;
                if (Path.GetExtension(path) == ".pck")
                {
                    unppack_path = path;
                }
                if (unppack_path.Length <= 1)
                {
                    JMessageBox.Show(this, "Please select .pck!");
                }
                else
                {
                    if(openedPckFies != null)
                    {
                        openedPckFies.Dispose();
                    }
                    openedPckFies = new PackHelper(unppack_path, true)
                    {
                        ReadTableIsDone = initialRead
                    };
                    openedPckFies.progress_bar += progress_bar;
                    this.fiullFilePath = unppack_path;
                }
            }
        }

        private void jComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (openedPckFies != null)
            {
                openedPckFies.version = short.Parse(jComboBox1.Items[jComboBox1.SelectedIndex].ToString());
            }
        }

        private void jPictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
