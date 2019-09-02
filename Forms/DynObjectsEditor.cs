using JHUI.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JHUI;
using System.IO;
using PWDataEditorPaied.Game_Shop_classes;
using PWDataEditorPaied.Forms.SubForms;
using System.Text.RegularExpressions;
using Ultimate_Editor.Clases.AngelicaFileManager;
using PWDataEditorPaied.AngelicaFileManager;
using Gpckx;
using Tests;
using System.Diagnostics;

namespace ElementEditor
{
    public partial class DynObjectsEditor : JForm
    {
        public class DynObject
        {
            public int id;
            public AngelicaSTRING Path;
        }
        public class DynObjcts
        {
            public byte[] Heder = new byte[4];
            public DynObject[] objects = new DynObject[0];
            public string path = "";
            public bool ReadFile(string path)
            {
                this.path = path;
                try
                {
                   
                    if (File.Exists(path))
                    {

                        using (FileStream fr = File.OpenRead(path))
                        {
                            using (BinaryReader br = new BinaryReader(fr))
                            {
                                Heder = br.ReadBytes(4);
                                int count = br.ReadInt32();
                                objects = new DynObject[count];
                                for (int i = 0; i < count; i++)
                                {
                                    DynObject dinamic = new DynObject();
                                    dinamic.id = br.ReadInt32();
                                    int length = br.ReadInt32();
                                    dinamic.Path = new AngelicaSTRING(length, br, Encoding.GetEncoding("gb2312"));
                                    objects[i] = dinamic;
                                }
                            }
                        }

                        return true;
                    }
                }
                catch { }
                return false;
            }

            public void Save()
            {
                try
                {
                    using (FileStream fw = new FileStream(path, FileMode.Create, FileAccess.Write))
                    {
                        using (BinaryWriter bw = new BinaryWriter(fw))
                        {
                            bw.Write(Heder);
                            bw.Write(objects.Length);
                            for(int i = 0; i < objects.Length; i++)
                            {
                                bw.Write(objects[i].id);
                                bw.Write(objects[i].Path.Lenght);
                                bw.Write(objects[i].Path.EncodedValue);
                            }
                        }
                    }
                }
                catch { }
            }
        }

        internal bool isAutoOpen;
        internal string autoOpenPath;

        internal delegate void UpdateProgressDelegate(String value, int min, int max);
        internal event UpdateProgressDelegate progress_bar2;
        public DynObjcts dynObjcts = new DynObjcts();
        private bool lockedCheck;

        public DynObjectsEditor()
        {
            InitializeComponent();
        }

        public void progress_bar(string value, int min, int max)
        {
            if (progress_bar2 != null)
            {
                progress_bar2(value, min, max);
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

        private void DynObjectsEditor_Shown(object sender, EventArgs e)
        {
            if(isAutoOpen)
            {
                progress_bar("Reading File", 0, 0);
                listBox_items.Enabled = false;
                listBox_items.Rows.Clear();
                dynObjcts = new DynObjcts();
                if(dynObjcts.ReadFile(autoOpenPath))
                {
                    listBox_items.Enabled = true;
                    listBox_items.Refresh();
                    listBox_items.RowCount = dynObjcts.objects.Length;
                    progress_bar("Ready", 0, 0);
                }
            }
        }

        private void listBox_items_CellValueNeeded(object sender, DataGridViewCellValueEventArgs data)
        {
            if (lockedCheck)
                return;

            lockedCheck = true;
            if (dynObjcts != null && dynObjcts.objects != null && dynObjcts.objects.Length != 0)
            {
                switch (data.ColumnIndex)
                {
                    case 0:
                        data.Value = dynObjcts.objects[data.RowIndex].id;
                        break;
                    case 1:
                        data.Value = dynObjcts.objects[data.RowIndex].Path.Value;
                        break;
                }              
            }
            lockedCheck = false;
        }

        private int lastSearchIndex = 0;
        private void search_ButtonClick(object sender, EventArgs e)
        {
            //textBox_search
            if (lockedCheck)
                return;

            lockedCheck = true;
            if (dynObjcts != null && dynObjcts.objects != null && dynObjcts.objects.Length != 0)
            {
                if (lastSearchIndex >= dynObjcts.objects.Length)
                {
                    lastSearchIndex = 0;
                }

                for (int i = lastSearchIndex; i < dynObjcts.objects.Length; i++)
                {
                    if(jCheckBox1.Checked)
                    {
                        string value0 = dynObjcts.objects[i].id.ToString().Trim().ToLower();
                        string value1 = textBox_search.Text.Trim().ToLower();
                        if(value0.Equals(value1))
                        {
                            lastSearchIndex = i + 1;
                            listBox_items.Rows[i].Selected = true;
                            listBox_items.CurrentCell = listBox_items.Rows[i].Cells[0];
                            lockedCheck = false;
                            break;
                        }

                        value0 = dynObjcts.objects[i].Path.Value.ToString().Trim().ToLower();
                        if (value0.Equals(value1))
                        {
                            lastSearchIndex = i + 1;
                            listBox_items.Rows[i].Selected = true;
                            listBox_items.CurrentCell = listBox_items.Rows[i].Cells[0];
                            lockedCheck = false;
                            break;
                        }
                    }
                    else
                    {
                        string value0 = dynObjcts.objects[i].Path.Value.ToString().Trim().ToLower();
                        string value1 = textBox_search.Text.Trim().ToLower();

                        if (value0.Contains(value1))
                        {
                            lastSearchIndex = i + 1;
                            listBox_items.Rows[i].Selected = true;
                            listBox_items.CurrentCell = listBox_items.Rows[i].Cells[0];
                            lockedCheck = false;
                            break;
                        }
                    }

                }
            }
            lockedCheck = false;
        }

        private void listBox_items_CellValueChanged(object sender, DataGridViewCellEventArgs data)
        {
            if (lockedCheck)
                return;

            lockedCheck = true;
            if (dynObjcts != null && dynObjcts.objects != null && dynObjcts.objects.Length != 0)
            {
                switch (data.ColumnIndex)
                {
                    case 0:
                        int val = 0;
                        bool isInt = int.TryParse(listBox_items.Rows[data.RowIndex].Cells[data.ColumnIndex].EditedFormattedValue.ToString(), out val);
                        if (isInt)
                            dynObjcts.objects[data.RowIndex].id = val;
                        break;
                    case 1:
                        dynObjcts.objects[data.RowIndex].Path.Value = listBox_items.Rows[data.RowIndex].Cells[data.ColumnIndex].EditedFormattedValue.ToString();
                        break;
                }
            }
            lockedCheck = false;
        }

        private void jPictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog load = new OpenFileDialog();
            load.Filter = "GShop (*.data)|*.data|All Files (*.*)|*.*";
            if (load.ShowDialog() == System.Windows.Forms.DialogResult.OK && File.Exists(load.FileName))
            {
                progress_bar("Reading File", 0, 0);
                listBox_items.Enabled = false;
                listBox_items.Rows.Clear();
                dynObjcts = new DynObjcts();
                if (dynObjcts.ReadFile(load.FileName))
                {
                    listBox_items.Enabled = true;
                    listBox_items.Refresh();
                    listBox_items.RowCount = dynObjcts.objects.Length;
                    progress_bar("Ready", 0, 0);
                }
            }
        }

        private void jPictureBox2_Click(object sender, EventArgs e)
        {
            lockedCheck = true;
            if (dynObjcts != null)
            {
                dynObjcts.Save();
                progress_bar("Ready", 0, 0);
            }
            lockedCheck = false;
        }

        private void AddNew(object sender, EventArgs e)
        {
            if (lockedCheck)
                return;
            if (dynObjcts == null)
                return;
            try
            {
                lockedCheck = true;
                List<DynObject> objects = dynObjcts.objects.ToList();
                DynObject obj = new DynObject();
                obj.id = objects.Count;
                obj.Path = new AngelicaSTRING();
                obj.Path.DefaultEncoding = Encoding.GetEncoding("gb2312");
                objects.Add(obj);
                dynObjcts.objects = objects.ToArray();
                listBox_items.RowCount = dynObjcts.objects.Length;
                listBox_items.Refresh();
            }
            catch
            {

            }
            try
            {
                lockedCheck = false;
                listBox_items.Rows[dynObjcts.objects.Length - 1].Selected = true;
                listBox_items.CurrentCell = listBox_items.Rows[dynObjcts.objects.Length - 1].Cells[0];
            }
            catch
            {

            }
            lockedCheck = false;
        }

        private void LogicReplace(object sender, EventArgs e)
        {
            if (lockedCheck)
                return;
            if (dynObjcts == null)
                return;

            lockedCheck = true;
            PckMoveFixer pathfixer = new PckMoveFixer();
            pathfixer.ShowDialog(this);
            int replaced = 0;
            if (pathfixer.DialogResult == DialogResult.OK)
            {

                List<string> replaceValues = PckMoveFixer.oldValue.Split(',').ToList(); //models/npcs,//models2/npcs
                for (int i = 0; i < replaceValues.Count; i++)
                {
                    replaceValues[i] = replaceValues[i] + "(.*)".ToLower();
                }

                string valueStr = PckMoveFixer.newValue.ToLower() + "$1"; //shaders/npcs

                for (int selectedRowx = 0; selectedRowx < dynObjcts.objects.Length; selectedRowx++)
                {

                        progress_bar("Fixing ...", selectedRowx, listBox_items.SelectedRows.Count);
   
                        string valueNow = dynObjcts.objects[selectedRowx].Path.Value.ToLower();
                        foreach (string oldvalue in replaceValues)
                        {
                            try
                            {
                                Regex x = new Regex(oldvalue);
                                if (x.IsMatch(valueNow))
                                {
                                    string calculated = x.Replace(valueNow, valueStr);
                                    dynObjcts.objects[selectedRowx].Path.Value = calculated;
                                    replaced++;
                                }
                            }
                            catch { }
                        }

                    
                }

                JMessageBox.Show(this, "Replaced:" + replaced + " items!");
            }
            lockedCheck = false;
            progress_bar("Ready", 0, 0);
        }

        private void Delete(object sender, EventArgs e)
        {
            if (lockedCheck)
                return;
            if (dynObjcts == null)
                return;

            lockedCheck = true;
            try
            {
                if (listBox_items.CurrentCell != null && listBox_items.CurrentCell != null)
                {
                    dynObjcts.objects = dynObjcts.objects.Where((source, index) => index != listBox_items.CurrentCell.RowIndex).ToArray();
                    listBox_items.RowCount = dynObjcts.objects.Length;
                    listBox_items.Refresh();
                }
            }
            catch { }
            lockedCheck = false;
        }
        private PackHelper tpackManager = null;
        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lockedCheck)
                return;
            if (dynObjcts == null)
                return;
            if(ElementsEditor.eLC == null)
            {
                JMessageBox.Show(this, "Element Editor must be loaded to use this function!");
                return;
            }
            try
            {
                if (listBox_items.CurrentCell != null && listBox_items.CurrentCell != null)
                {
                    int element = listBox_items.CurrentCell.RowIndex;
                    string path = dynObjcts.objects[element].Path.Value;
                    string savePath = Path.GetDirectoryName(Application.ExecutablePath) + Path.DirectorySeparatorChar + "ModelView" + Path.DirectorySeparatorChar + "dataexe";
                    string exe = Path.GetDirectoryName(Application.ExecutablePath) + Path.DirectorySeparatorChar + "ModelView" + Path.DirectorySeparatorChar + "model.exe";

                    string modelPath = path.Replace('\\', Path.DirectorySeparatorChar).Replace('/', Path.DirectorySeparatorChar).ToLower();
                    string mainPackName = modelPath.Split(Path.DirectorySeparatorChar)[0] + ".pck";
                    string packPath = Directory.GetParent(Path.GetDirectoryName(ElementsEditor.eLC.loadedFile)).FullName + Path.DirectorySeparatorChar + mainPackName;
                    bool found = false;

                    tpackManager = PackDatabase.Instance.getManager(mainPackName, packPath, () => {
                        if (tpackManager != null)
                        {
                            List<PckEntry> files = tpackManager.getDirectory(Path.GetDirectoryName(modelPath));
                            string titles = modelPath;
                            ModelClass model = new ModelClass();

                            foreach (PckEntry file in files)
                            {
                                string extenstion = Path.GetExtension(file.fullP);
                                if (extenstion.ToLower().Equals(".ski"))
                                {
                                    model.skyfile = file.bytes;
                                    found = true;
                                }
                                if (extenstion.ToLower().Equals(".dds"))
                                {
                                    model.DDSIMAGE.Add(Path.GetFileName(file.fullP), file.bytes);
                                }
                            }
                            if (found)
                            {
                                using (BinaryWriter br = new BinaryWriter(new FileStream(savePath, FileMode.Create, FileAccess.Write)))
                                {
                                    byte[] title = Encoding.GetEncoding(936).GetBytes(titles);
                                    br.Write(title.Length);
                                    br.Write(title);
                                    br.Write(model.skyfile.Length);
                                    br.Write(model.skyfile);
                                    br.Write(model.DDSIMAGE.Count);
                                    foreach (KeyValuePair<string, byte[]> xxa in model.DDSIMAGE)
                                    {
                                        byte[] titlex = Encoding.GetEncoding(936).GetBytes(xxa.Key);
                                        br.Write(titlex.Length);
                                        br.Write(titlex);
                                        br.Write(xxa.Value.Length);
                                        br.Write(xxa.Value);
                                    }
                                }
                                Process.Start(exe);
                            }
                        }
                    }
                    , true);
                }
            }
            catch { }
        }
    }
}
