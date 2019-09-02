
using ElementEditor;
using PWDataEditorPaied.DomainEditors_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using JHUI;
using JHUI.Forms;

namespace DomainEditors
{
    public partial class DomainEditor : JForm
    {
        #region domain.data  
        private DOMAIN domain;

        public static string domainPath;

        private bool firstLoaded = false;

        public void progress_bar(String value, int min, int max)
        {
            if (progress_bar2 != null)
                progress_bar2(value, min, max);
        }

        public DomainEditor()
        {
            InitializeComponent();
            this.MinimizeBox = Program.SHOWMINIMIZEBUTTON;
            typeCombobox.SelectedIndex = 0;
            comboBox1.SelectedIndex = 0;

        }

        private void resetAllForm()
        {
            pathTextBox.Text = "";
            mainVersionTextbox.Text = "";
            battletimeMax.Text = "";
            domainInfoIdTextBox.Text = "";
            DomainInfoNameText.Text = "";
            MoneyRewardText.Text = "";
            battleDates.Rows.Clear();
            DomainList.Rows.Clear();
            domainNeigborurs.Rows.Clear();
            domainPoints.Rows.Clear();
            domainTriangles.Rows.Clear();
        }

        private bool isDoingWork = false;

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Create an instance of the open file dialog box.
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            // Set filter options and filter index.
            openFileDialog1.Filter = "Data Files (.data)|*.data|All Files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.FileName = "domain.data";
            openFileDialog1.Multiselect = false;

            // Process input if the user clicked OK.
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    isDoingWork = true;
                    firstLoaded = false;
                    DomainList.Rows.Clear();
                    domainPath = openFileDialog1.FileName;

                    domain = new DOMAIN();
                    FileStream fileStream = File.OpenRead(domainPath);
                    BinaryReader binaryReader = new BinaryReader((Stream)fileStream);
                    domain.version = binaryReader.ReadInt32();
                    int count = binaryReader.ReadInt32();
                    for (int i = 0; i < count; i++)
                    {
                        progress_bar("Loading data...", i, count);
                        DOMAIN_INFO domainInfo = new DOMAIN_INFO();
                        domainInfo.name = binaryReader.ReadBytes(32);
                        domainInfo.id = binaryReader.ReadInt32();
                        domainInfo.type = (DOMAIN_TYPE)binaryReader.ReadInt32();
                        DomainList.Rows.Add(new Object[] { domainInfo.id, new Unicode(domainInfo.name).ToString() });
                        domainInfo.reward = binaryReader.ReadInt32();
                        domainInfo.iconpos[0] = binaryReader.ReadInt32();
                        domainInfo.iconpos[1] = binaryReader.ReadInt32();
                        int pointscount = binaryReader.ReadInt32();
                        for (int x = 0; x < pointscount; x++)
                        {
                            DomainPoint point = new DomainPoint();
                            point.x = binaryReader.ReadInt32();
                            point.y = binaryReader.ReadInt32();
                            domainInfo.pointcountArray.Add(point);
                        }
                        int trianglescount = binaryReader.ReadInt32();
                        for (int t = 0; t < trianglescount; t++)
                        {
                            DomainTriangle tri = new DomainTriangle();
                            tri.id1 = binaryReader.ReadInt32();
                            tri.id2 = binaryReader.ReadInt32();
                            tri.id3 = binaryReader.ReadInt32();

                            domainInfo.triangle.Add(tri);
                        }
                        int nNumNeighbours = binaryReader.ReadInt32();
                        domainInfo.neighbour = new int[nNumNeighbours];
                        for (int n = 0; n < nNumNeighbours; n++)
                        {
                            domainInfo.neighbour[n] = binaryReader.ReadInt32();
                        }
                        domain.domains.Add(domainInfo);
                    }
                    int battletimecount = binaryReader.ReadInt32();
                    for (int b = 0; b < battletimecount; b++)
                    {
                        BATTLETIME tri = new BATTLETIME();
                        tri.Day = binaryReader.ReadInt32();
                        tri.Hour = binaryReader.ReadInt32();
                        tri.Minute = binaryReader.ReadInt32();
                        domain.battletime.Add(tri);
                    }
                    domain.battletime_max = binaryReader.ReadInt32();
                    domain.batles = new int[2];
                    fileStream.Close();
                    binaryReader.Close();
                }
                catch {
                    resetAllForm();
                    domain = null;
                    JMessageBox.Show(this, "Unable to read file!");
                }
            }
            isDoingWork = false;
            loadData();
            progress_bar("Ready!", 0, 0);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(domain == null) { return; }
            FileStream fileStream = File.OpenWrite(domainPath);
            BinaryWriter bw = new BinaryWriter((Stream)fileStream);
            bw.Write(domain.version);
            bw.Write(domain.domains.Count);
            for (int i = 0; i < domain.domains.Count; i++)
            {
                progress_bar("Saving .data...", i, domain.domains.Count);
                DOMAIN_INFO domainInfo = domain.domains[i];
                bw.Write((byte[])domainInfo.name);
                bw.Write(domainInfo.id);
                bw.Write((int)domainInfo.type);
                bw.Write(domainInfo.reward);
                bw.Write(domainInfo.iconpos[0]);
                bw.Write(domainInfo.iconpos[1]);
                int pointcount = domainInfo.pointcountArray.Count;
                bw.Write(pointcount);
                for (int x = 0; x < pointcount; x++)
                {
                    DomainPoint point = domainInfo.pointcountArray[x];
                    bw.Write(point.x);
                    bw.Write(point.y);
                }
                int trianglescount = domainInfo.triangle.Count;
                bw.Write(trianglescount);
                for (int t = 0; t < trianglescount; t++)
                {
                    DomainTriangle tri = domainInfo.triangle[t];
                    bw.Write(tri.id1);
                    bw.Write(tri.id2);
                    bw.Write(tri.id3);
                }
                int neighbourcount = domainInfo.neighbour.Length;
                bw.Write(neighbourcount);
                for (int n = 0; n < neighbourcount; n++)
                {
                    bw.Write(domainInfo.neighbour[n]);
                }

            }
            int battletimecount = domain.battletime.Count;
            bw.Write(battletimecount);
            for (int b = 0; b < battletimecount; b++)
            {
                BATTLETIME tri = domain.battletime[b];
                bw.Write(tri.Day);
                bw.Write(tri.Hour);
                bw.Write(tri.Minute);
            }
            bw.Write(domain.battletime_max);
            fileStream.Close();
            bw.Close();


            string domainSev_path = domainPath.ToLower().Replace(".data",".sev");
            fileStream = File.OpenWrite(domainSev_path);
            bw = new BinaryWriter((Stream)fileStream);
            bw.Write(domain.domains.Count);
            for (int i = 0; i < domain.domains.Count; i++)
            {
                DOMAIN_INFO domainInfo = domain.domains[i];
                progress_bar("Saving .sev...", i, domain.domains.Count);
                bw.Write(domainInfo.id);
                bw.Write((int)domainInfo.type);
                bw.Write(domainInfo.reward);
                int neighbourcount = domainInfo.neighbour.Length;
                bw.Write(neighbourcount);
                for (int n = 0; n < neighbourcount; n++)
                {
                    bw.Write(domainInfo.neighbour[n]);
                }
            }
            battletimecount = domain.battletime.Count;
            bw.Write(battletimecount);
            for (int b = 0; b < battletimecount; b++)
            {
                BATTLETIME tri = domain.battletime[b];
                bw.Write(tri.Day);
                bw.Write(tri.Hour);
                bw.Write(tri.Minute);
            }
            bw.Write(domain.battletime_max);
            fileStream.Close();
            bw.Close();
            progress_bar("Ready!", 0, 0);
        }

        private void loadData()
        {
            if (domain != null)
            {
                pathTextBox.Text = domainPath;
                mainVersionTextbox.Text = domain.version.ToString();
                battletimeMax.Text = domain.battletime_max.ToString();
                battleDates.Rows.Clear();
                for (int b = 0; b < domain.battletime.Count; b++)
                {
                    BATTLETIME bt = domain.battletime[b];
                    battleDates.Rows.Add(new object[] { b, bt.Day, bt.Hour, bt.Minute });
                }
                if(!firstLoaded)
                {
                    DomainList.Rows[0].Cells[0].Selected = true;
                    DomainList_SelectionChanged(null, null);
                    firstLoaded = true;
                }
            }
        }

        private void DomainList_SelectionChanged(object sender, EventArgs e)
        {
            if (!isDoingWork && domain != null && DomainList.CurrentCell != null && DomainList.CurrentCell.RowIndex >=0)
            {
                int index = DomainList.CurrentCell.RowIndex;
                DOMAIN_INFO domainInfo = domain.domains[index];
                domainNeigborurs.Rows.Clear();
                domainPoints.Rows.Clear();
                domainTriangles.Rows.Clear();

                for (int n = 0; n < domainInfo.neighbour.Length; n++)
                {
                    domainNeigborurs.Rows.Add(new object[] {domainInfo.neighbour[n] });
                }
                for (int x = 0; x < domainInfo.pointcountArray.Count; x++)
                {
                    DomainPoint point = domainInfo.pointcountArray[x];
                    domainPoints.Rows.Add(new object[] { x, point.x, point.y });
                }
                for (int t = 0; t < domainInfo.triangle.Count; t++)
                {
                    DomainTriangle tri = domainInfo.triangle[t];
                    domainTriangles.Rows.Add(new object[] { t, tri.id1, tri.id2, tri.id3 });
                }
                domainInfoIdTextBox.Text = domainInfo.id.ToString();
                DomainInfoNameText.Text = new Unicode(domainInfo.name).ToString();
                MoneyRewardText.Text = domainInfo.reward.ToString();
                typeCombobox.SelectedIndex = (int)domainInfo.type;
            }
        }

        private void battleDates_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!isDoingWork && domain != null && battleDates.CurrentCell != null && battleDates.CurrentCell.RowIndex >= 0)
            {
                isDoingWork = true;
                int editType = battleDates.CurrentCell.ColumnIndex;
                int selectedBattle = battleDates.CurrentCell.RowIndex;
                String value = battleDates.Rows[selectedBattle].Cells[editType].Value.ToString();
                int valueS = 0;
                bool isInt = int.TryParse(value, out valueS);
                if (isInt)
                {
                    switch (editType)
                    {
                        case 1:
                            //Day
                            domain.battletime[selectedBattle].Day = valueS;
                            break;
                        case 2:
                            //Hour
                            domain.battletime[selectedBattle].Hour = valueS;
                            break;
                        case 3:
                            //Minute
                            domain.battletime[selectedBattle].Minute = valueS;
                            break;
                    }
                }

                isDoingWork = false;
                loadData();
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

        private void battletimeMax_Leave(object sender, EventArgs e)
        {
            if (!isDoingWork && domain != null)
            {
                isDoingWork = true;
                int valueS = 0;
                bool isInt = int.TryParse(battletimeMax.Text, out valueS);
                if (isInt)
                {
                    domain.battletime_max = valueS;
                }
                isDoingWork = false;
                loadData();
            }
        }

        private void domainInfoIdTextBox_Leave(object sender, EventArgs e)
        {
            if (!isDoingWork && domain != null && DomainList.CurrentCell != null && DomainList.CurrentCell.RowIndex >= 0)
            {
                isDoingWork = true;
                int cellIndex = DomainList.CurrentCell.ColumnIndex;
                int selectedDomain = DomainList.CurrentCell.RowIndex;
                String value = domainInfoIdTextBox.Text;
                int valueS = 0;
                bool isInt = int.TryParse(value, out valueS);
                if (isInt)
                {
                    domain.domains[selectedDomain].id = valueS;
                    DomainList.Rows[selectedDomain].Cells[0].Value = valueS;
                }
               
                isDoingWork = false;
                loadData();
            }
        }

        private void DomainInfoNameText_Leave(object sender, EventArgs e)
        {
            if (!isDoingWork && domain != null && DomainList.CurrentCell != null && DomainList.CurrentCell.RowIndex >= 0)
            {
                isDoingWork = true;
                int cellIndex = DomainList.CurrentCell.ColumnIndex;
                int selectedDomain = DomainList.CurrentCell.RowIndex;
                String value = DomainInfoNameText.Text;
                Unicode uni = new Unicode(new byte[32]);
                uni.Set(value); 
                domain.domains[selectedDomain].name = uni.data;
                DomainList.Rows[selectedDomain].Cells[1].Value = new Unicode(domain.domains[selectedDomain].name).ToString();
                isDoingWork = false;
                loadData();
            }
        }

        private void MoneyRewardText_Leave(object sender, EventArgs e)
        {
            if (!isDoingWork && domain != null && DomainList.CurrentCell != null && DomainList.CurrentCell.RowIndex >= 0)
            {
                isDoingWork = true;
                int cellIndex = DomainList.CurrentCell.ColumnIndex;
                int selectedDomain = DomainList.CurrentCell.RowIndex;
                String value = MoneyRewardText.Text;
                int valueS = 0;
                bool isInt = int.TryParse(value, out valueS);
                if (isInt)
                {
                    domain.domains[selectedDomain].reward = valueS;
                }

                isDoingWork = false;
                loadData();
            }
        }

        private void typeCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isDoingWork && domain != null && DomainList.CurrentCell != null && DomainList.CurrentCell.RowIndex >= 0)
            {
                isDoingWork = true;
                int cellIndex = DomainList.CurrentCell.ColumnIndex;
                int selectedDomain = DomainList.CurrentCell.RowIndex;
                String value = MoneyRewardText.Text;
                int valueS = typeCombobox.SelectedIndex;
                domain.domains[selectedDomain].type = (DOMAIN_TYPE)valueS;
                isDoingWork = false;
                loadData();
            }
        }

        private void domainNeigborurs_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!isDoingWork && domain != null && DomainList.CurrentCell != null && DomainList.CurrentCell.RowIndex >= 0 && domainNeigborurs.CurrentCell != null)
            {
                isDoingWork = true;
                int cellIndex = DomainList.CurrentCell.ColumnIndex;
                int selectedDomain = DomainList.CurrentCell.RowIndex;
                String value = domainNeigborurs.Rows[domainNeigborurs.CurrentCell.RowIndex].Cells[domainNeigborurs.CurrentCell.ColumnIndex].Value.ToString();
                int valueS = 0;
                bool isInt = int.TryParse(value, out valueS);
                if (isInt)
                {
                    domain.domains[selectedDomain].neighbour[domainNeigborurs.CurrentCell.RowIndex] = valueS;
                }

                isDoingWork = false;
                loadData();
            }
        }

        private void domainPoints_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!isDoingWork && domain != null && DomainList.CurrentCell != null && DomainList.CurrentCell.RowIndex >= 0 && domainPoints.CurrentCell != null)
            {
                isDoingWork = true;
                int cellIndex = DomainList.CurrentCell.ColumnIndex;
                int selectedDomain = DomainList.CurrentCell.RowIndex;
                String value = domainPoints.Rows[domainPoints.CurrentCell.RowIndex].Cells[domainPoints.CurrentCell.ColumnIndex].Value.ToString();
                int valueS = 0;
                bool isInt = int.TryParse(value, out valueS);
                if (isInt)
                {
                    if (domainPoints.CurrentCell.ColumnIndex == 1)
                    {
                        domain.domains[selectedDomain].pointcountArray[domainPoints.CurrentCell.RowIndex].x = valueS;
                    }else
                    {
                        domain.domains[selectedDomain].pointcountArray[domainPoints.CurrentCell.RowIndex].y = valueS;
                    }
                }
                isDoingWork = false;
                loadData();
            }
        }

        private void domainTriangles_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!isDoingWork && domain != null && DomainList.CurrentCell != null && DomainList.CurrentCell.RowIndex >= 0 && domainTriangles.CurrentCell != null)
            {
                isDoingWork = true;
                int cellIndex = DomainList.CurrentCell.ColumnIndex;
                int selectedDomain = DomainList.CurrentCell.RowIndex;
                String value = domainTriangles.Rows[domainTriangles.CurrentCell.RowIndex].Cells[domainTriangles.CurrentCell.ColumnIndex].Value.ToString();
                int valueS = 0;
                bool isInt = int.TryParse(value, out valueS);
                if (isInt)
                {
                    if (domainTriangles.CurrentCell.ColumnIndex == 1)
                    {
                        domain.domains[selectedDomain].triangle[domainTriangles.CurrentCell.RowIndex].id1 = valueS;
                    }
                    if (domainTriangles.CurrentCell.ColumnIndex == 2)
                    {
                        domain.domains[selectedDomain].triangle[domainTriangles.CurrentCell.RowIndex].id2 = valueS;
                    }
                    if (domainTriangles.CurrentCell.ColumnIndex == 3)
                    {
                        domain.domains[selectedDomain].triangle[domainTriangles.CurrentCell.RowIndex].id3 = valueS;
                    }
                }
                isDoingWork = false;
                loadData();
            }
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            if (!isDoingWork && domain != null && battleDates.CurrentCell != null && battleDates.CurrentCell.RowIndex >= 0)
            {
                isDoingWork = true;
                int selectedBattle = battleDates.CurrentCell.RowIndex;
                String value = battleDates.Rows[selectedBattle].Cells[0].Value.ToString();
                int valueS = 0;
                bool isInt = int.TryParse(value, out valueS);
                if (isInt)
                {
                    domain.battletime.RemoveAt(valueS);
                }
                isDoingWork = false;
                loadData();
            }
        }

        private void toolStripMenuItem7_Click_1(object sender, EventArgs e)
        {
            if (!isDoingWork && domain != null && battleDates.CurrentCell != null && battleDates.CurrentCell.RowIndex >= 0)
            {
                isDoingWork = true;
                int selectedBattle = battleDates.CurrentCell.RowIndex;
                String value = battleDates.Rows[selectedBattle].Cells[0].Value.ToString();
                int valueS = 0;
                bool isInt = int.TryParse(value, out valueS);
                if (isInt)
                {
                    BATTLETIME newone = new BATTLETIME();
                    newone.Day = 0;
                    newone.Hour = 0;
                    newone.Minute = 0;
                    domain.battletime.Add(newone);
                }
                isDoingWork = false;
                loadData();
            }
        }

        private void AddDomainToolstrip(object sender, EventArgs e)
        {
            if (!isDoingWork && domain != null)
            {
                isDoingWork = true;
                DOMAIN_INFO newDom = new DOMAIN_INFO();
                newDom.id = 999;
                Unicode uni = new Unicode(new byte[32]);
                uni.Set("new Domain!");
                newDom.name = uni.data;
                domain.domains.Add(newDom);
                DomainList.Rows.Add(new Object[] { newDom.id, new Unicode(newDom.name).ToString() });
                DomainList.CurrentCell = null;
                DomainList.Rows[DomainList.Rows.Count-1].Cells[0].Selected = true;
                isDoingWork = false;
                loadData();
                DomainList_SelectionChanged(null, null);
            }
        }

        private void deleteDomeinTool(object sender, EventArgs e)
        {
            if (!isDoingWork && domain != null && DomainList.CurrentCell != null && DomainList.CurrentCell.RowIndex >= 0)
            {
                isDoingWork = true;
                int cellIndex = DomainList.CurrentCell.ColumnIndex;
                int selectedDomain = DomainList.CurrentCell.RowIndex;
                String value = domainInfoIdTextBox.Text;
                int valueS = 0;
                bool isInt = int.TryParse(value, out valueS);
                if (isInt)
                {

                    domain.domains.RemoveAt(selectedDomain);
                    DomainList.Rows.RemoveAt(selectedDomain);
                }
                isDoingWork = false;
                loadData();
            }
        }

        private void addNeigborTool(object sender, EventArgs e)
        {
            if (!isDoingWork && domain != null && DomainList.CurrentCell != null && DomainList.CurrentCell.RowIndex >= 0)
            {
                isDoingWork = true;
                int cellIndex = DomainList.CurrentCell.ColumnIndex;
                int selectedDomain = DomainList.CurrentCell.RowIndex;

                int newInt =  domain.domains[selectedDomain].neighbour.Length + 1;
                int[] newNeigbors = new int[newInt];
                for(int i = 0; i< domain.domains[selectedDomain].neighbour.Length; i++)
                {
                    newNeigbors[i] = domain.domains[selectedDomain].neighbour[i];
                }
                newNeigbors[newInt-1] = -1;
                domain.domains[selectedDomain].neighbour = newNeigbors;
                isDoingWork = false;
                loadData();
                DomainList_SelectionChanged(null, null);
            }
        }

        private void delNeigbor(object sender, EventArgs e)
        {
            if (!isDoingWork && domain != null && DomainList.CurrentCell != null && DomainList.CurrentCell.RowIndex >= 0 && domainNeigborurs.CurrentCell != null)
            {
                isDoingWork = true;
                int cellIndex = DomainList.CurrentCell.ColumnIndex;
                int selectedDomain = DomainList.CurrentCell.RowIndex;
                int newInt = domain.domains[selectedDomain].neighbour.Length - 1;
                int[] newNeigbors = new int[newInt];
                int x = 0;
                int i = 0;
                while (x < domain.domains[selectedDomain].neighbour.Length)
                {
                    if (x != domainNeigborurs.CurrentCell.RowIndex)
                    {
                        newNeigbors[i] = domain.domains[selectedDomain].neighbour[x];
                        i++;
                    }
                    x++;
                }
                domain.domains[selectedDomain].neighbour = newNeigbors;
                isDoingWork = false;
                loadData();
                DomainList_SelectionChanged(null, null);
            }
        }

        private void addpomts(object sender, EventArgs e)
        {
            if (!isDoingWork && domain != null && DomainList.CurrentCell != null && DomainList.CurrentCell.RowIndex >= 0)
            {
                isDoingWork = true;
                int cellIndex = DomainList.CurrentCell.ColumnIndex;
                int selectedDomain = DomainList.CurrentCell.RowIndex;
                DomainPoint dot = new DomainPoint();
                dot.x = -1;
                dot.y = -1;
                domain.domains[selectedDomain].pointcountArray.Add(dot);
                isDoingWork = false;
                loadData();
                DomainList_SelectionChanged(null, null);
            }
        }

        private void delpomts(object sender, EventArgs e)
        {
            if (!isDoingWork && domain != null && DomainList.CurrentCell != null && DomainList.CurrentCell.RowIndex >= 0 && domainPoints.CurrentCell != null)
            {
                isDoingWork = true;
                int cellIndex = DomainList.CurrentCell.ColumnIndex;
                int selectedDomain = DomainList.CurrentCell.RowIndex;
                domain.domains[selectedDomain].pointcountArray.RemoveAt(domainPoints.CurrentCell.RowIndex);
                isDoingWork = false;
                loadData();
                DomainList_SelectionChanged(null, null);
            }
        }

        private void addTriangle(object sender, EventArgs e)
        {
            if (!isDoingWork && domain != null && DomainList.CurrentCell != null && DomainList.CurrentCell.RowIndex >= 0)
            {
                isDoingWork = true;
                int cellIndex = DomainList.CurrentCell.ColumnIndex;
                int selectedDomain = DomainList.CurrentCell.RowIndex;
                DomainTriangle dt = new DomainTriangle();
                dt.id1 = -1;
                dt.id2 = -1;
                dt.id3 = -1;
                domain.domains[selectedDomain].triangle.Add(dt);
                isDoingWork = false;
                loadData();
                DomainList_SelectionChanged(null, null);
            }
        }

        private void removeTriangle(object sender, EventArgs e)
        {
            if (!isDoingWork && domain != null && DomainList.CurrentCell != null && DomainList.CurrentCell.RowIndex >= 0 && domainTriangles.CurrentCell != null)
            {
                isDoingWork = true;
                int cellIndex = DomainList.CurrentCell.ColumnIndex;
                int selectedDomain = DomainList.CurrentCell.RowIndex;
                domain.domains[selectedDomain].triangle.RemoveAt(domainTriangles.CurrentCell.RowIndex);
                isDoingWork = false;
                loadData();
                DomainList_SelectionChanged(null, null);
            }
        }
        #endregion
        internal delegate void UpdateProgressDelegate(String value, int min, int max);
        internal event UpdateProgressDelegate progress_bar2;
        private void resetAllForm2()
        {
            countryIdtext.Text = "";
            pathTextBox2.Text = "";
            textBoxmagic.Text = "";
            battletimeMax.Text = "";
            domain2_data_timestamp.Text = "";
            battletime_max2.Text = "";
            domainInfoIdTextBox2.Text = "";
            DomainInfoNameText2.Text = "";
            comboBox1.SelectedIndex = 0;
            iconPostX.Text = "";
            inconPostY.Text = "";
            battleDates2.Rows.Clear();
            DomainList2.Rows.Clear();
            domainNeigborurs2.Rows.Clear();
            domainPoints2.Rows.Clear();
            domainTriangles2.Rows.Clear();
            MapPositionsdataGrid.ClearSelection();
        }

        private DOMAIN2 domain2 = null;
        private bool firstLoaded2 = true;
        private bool isDoingWork2 = false;
        private string domainPath2;
        private string domain2sev;
        public bool isAutoOpen = false;
        public string autoOpenPath = "";

        private void openDomain2(object sender, EventArgs e)
        {
            // Create an instance of the open file dialog box.
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            // Set filter options and filter index.
            openFileDialog1.Filter = "Data Files (.data)|*.data|All Files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.FileName = "domain2.data";
            openFileDialog1.Multiselect = false;

            // Process input if the user clicked OK.
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    isDoingWork2 = true;
                    firstLoaded2 = false;
                    DomainList2.Rows.Clear();
                    domainPath2 = openFileDialog1.FileName;
                    openFileDialog1.Filter = "Data Files (.sev)|*.sev|All Files (*.*)|*.*";
                    openFileDialog1.FileName = "domain2.sev";
                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        domain2sev = openFileDialog1.FileName;
                        domain2 = new DOMAIN2();
                        FileStream fileStream = File.OpenRead(domainPath2);
                        BinaryReader br = new BinaryReader((Stream)fileStream);
                        domain2.magic = br.ReadInt32();
                        domain2.domain2_data_timestamp = br.ReadInt32();
                        int count = (int)br.ReadInt32();
                        for (int i = 0; i < count; i++)
                        {
                            progress_bar("Loading data...", i, count);
                            DOMAIN2_INFO domainInfo = new DOMAIN2_INFO();
                            domainInfo.name = br.ReadBytes(32);
                            domainInfo.id = br.ReadInt32();
                            domainInfo.point = br.ReadInt32();
                            domainInfo.wartype = br.ReadInt32();
                            domainInfo.country_id = br.ReadInt32();
                            domainInfo.is_capital = br.ReadInt32();
                            DomainList2.Rows.Add(new Object[] { domainInfo.id, new Unicode(domainInfo.name).ToString() });
                            int maxCount = 4;

                            for (int x = 0; x < maxCount; x++)
                            {
                                MapPos point = new MapPos();
                                point.x = br.ReadSingle();
                                point.y = br.ReadSingle();
                                point.z = br.ReadSingle();
                                domainInfo.mappos.Add(point);
                            }
                            domainInfo.iconpos[0] = br.ReadInt32();
                            domainInfo.iconpos[1] = br.ReadInt32();
                            int pointscount = br.ReadInt32();
                            for (int x = 0; x < pointscount; x++)
                            {
                                DomainPoint point = new DomainPoint();
                                point.x = br.ReadInt32();
                                point.y = br.ReadInt32();
                                domainInfo.pointcountArray.Add(point);
                            }
                            int trianglescount = br.ReadInt32();
                            for (int t = 0; t < trianglescount; t++)
                            {
                                DomainTriangle tri = new DomainTriangle();
                                tri.id1 = br.ReadInt32();
                                tri.id2 = br.ReadInt32();
                                tri.id3 = br.ReadInt32();

                                domainInfo.triangle.Add(tri);
                            }

                            int _count3 = br.ReadInt32();
                            domainInfo.neighbour = new int[_count3];
                            for (int n = 0; n < _count3; n++)
                            {
                                domainInfo.neighbour[n] = br.ReadInt32();
                            }
                            domain2.domains.Add(domainInfo);

                        }
                        int battletimecount = br.ReadInt32();
                        for (int b = 0; b < battletimecount; b++)
                        {
                            BATTLETIME tri = new BATTLETIME();
                            tri.Day = br.ReadInt32();
                            tri.Hour = br.ReadInt32();
                            tri.Minute = br.ReadInt32();
                            domain2.battletime.Add(tri);
                        }
                        domain2.battletime_max = br.ReadInt32();
                        fileStream.Close();
                        br.Close();


                        fileStream = File.OpenRead(domain2sev);
                        br = new BinaryReader((Stream)fileStream);
                        br.ReadInt32();
                        int count2 =  br.ReadInt32();
                        for (int i = 0; i < count2; i++)
                        {
                            int id = br.ReadInt32();
                            int pointx = br.ReadInt32();
                            int wartype = br.ReadInt32();

                            int country_id = br.ReadInt32();
                            int is_capital = br.ReadInt32();
                            int maxCount = 4;
                            for (int x = 0; x < maxCount; x++)
                            {
                                MapPos point = new MapPos();
                                point.x = br.ReadSingle();
                                point.y = br.ReadSingle();
                                point.z = br.ReadSingle();
                            }
                            int _count3 = br.ReadInt32();
                            int[] notimportant = new int[_count3];
                            for (int n = 0; n < _count3; n++)
                            {
                                notimportant[n] = br.ReadInt32();
                            }
                            int[] important = new int[_count3];
                            for (int n = 0; n < _count3; n++)
                            {
                                important[n] = br.ReadInt32();
                            }
                            DOMAIN2_INFO domaininfo = getDomainById(id);
                            if (domaininfo != null)
                            {
                                domaininfo.neighbour = notimportant;
                                domaininfo.time_neighbours = important;
                            }
                        }

                        battletimecount = br.ReadInt32();
                        for (int b = 0; b < battletimecount; b++)
                        {
                            BATTLETIME tri = new BATTLETIME();
                            tri.Day = br.ReadInt32();
                            tri.Hour = br.ReadInt32();
                            tri.Minute = br.ReadInt32();
                        }
                        domain2.battletime_max = br.ReadInt32();

                        fileStream.Close();
                        br.Close();
                    }
                }
                catch
                {
                    resetAllForm2();
                    domain2 = null;
                    JMessageBox.Show(this, "Unable to read file!");
                }
            }
            isDoingWork2 = false;
            loadData2();
            progress_bar("Ready!", 0, 0);
        }

        private DOMAIN2_INFO getDomainById(int id)
        {
            if(domain2 != null)
            {
                foreach(DOMAIN2_INFO dominfo in domain2.domains)
                {
                    if(id.Equals(dominfo.id))
                    {
                        return dominfo;
                    }
                }
            }

            return null;
        }

        private String timestamp_to_string(int timestamp)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            origin = origin.AddSeconds(timestamp);
            return origin.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void loadData2()
        {
            if (domain2 != null)
            {
                pathTextBox2.Text = domainPath2;
                textBoxmagic.Text = domain2.magic.ToString();
                battletimeMax.Text = domain2.battletime_max.ToString();
                domain2_data_timestamp.Text = timestamp_to_string(domain2.domain2_data_timestamp);
                battleDates2.Rows.Clear();
                for (int b = 0; b < domain2.battletime.Count; b++)
                {
                    BATTLETIME bt = domain2.battletime[b];
                    battleDates2.Rows.Add(new object[] { b, bt.Day, bt.Hour, bt.Minute });
                }
                if (!firstLoaded2)
                {
                    DomainList2.Rows[0].Cells[0].Selected = true;
                    DomainList2_SelectionChanged(null, null);
                    firstLoaded2 = true;
                }
                battletime_max2.Text = domain2.battletime_max.ToString();
                
            }
        }

        private void saveDomain2(object sender, EventArgs e)
        {
            if (domain2 == null) { return; }
            FileStream fileStream = File.OpenWrite(domainPath2);
            BinaryWriter bw = new BinaryWriter((Stream)fileStream);
            bw.Write(domain2.magic);
            bw.Write(domain2.domain2_data_timestamp);
            bw.Write(domain2.domains.Count);
            for (int i = 0; i < domain2.domains.Count; i++)
            {
                progress_bar("Saving .data...", i, domain2.domains.Count);
                DOMAIN2_INFO domainInfo = domain2.domains[i];
                bw.Write((byte[])domainInfo.name);
                bw.Write(domainInfo.id);
                bw.Write((int)domainInfo.point);
                bw.Write(domainInfo.wartype);
                bw.Write(domainInfo.country_id);
                bw.Write(domainInfo.is_capital);
                int maxCount = domainInfo.mappos.Count;
                for (int x = 0; x < maxCount; x++)
                {
                    MapPos point = domainInfo.mappos[x];
                    bw.Write(point.x);
                    bw.Write(point.y);
                    bw.Write(point.z);
                }
                bw.Write(domainInfo.iconpos[0]);
                bw.Write(domainInfo.iconpos[1]);
                int pointcount = domainInfo.pointcountArray.Count;
                bw.Write(pointcount);
                for (int x = 0; x < pointcount; x++)
                {
                    DomainPoint point = domainInfo.pointcountArray[x];
                    bw.Write(point.x);
                    bw.Write(point.y);
                }
                int trianglescount = domainInfo.triangle.Count;
                bw.Write(trianglescount);
                for (int t = 0; t < trianglescount; t++)
                {
                    DomainTriangle tri = domainInfo.triangle[t];
                    bw.Write(tri.id1);
                    bw.Write(tri.id2);
                    bw.Write(tri.id3);
                }
                int neighbourcount = domainInfo.neighbour.Length;
                bw.Write(neighbourcount);
                for (int n = 0; n < neighbourcount; n++)
                {
                    bw.Write(domainInfo.neighbour[n]);
                }

            }
            int battletimecount = domain2.battletime.Count;
            bw.Write(battletimecount);
            for (int b = 0; b < battletimecount; b++)
            {
                BATTLETIME tri = domain2.battletime[b];
                bw.Write(tri.Day);
                bw.Write(tri.Hour);
                bw.Write(tri.Minute);
            }
            bw.Write(domain2.battletime_max);
            fileStream.Close();
            bw.Close();


            string domainSev_path = domainPath2.ToLower().Replace(".data", ".sev");
            fileStream = File.OpenWrite(domainSev_path);
            bw = new BinaryWriter((Stream)fileStream);
            bw.Write(domain2.domain2_data_timestamp);
            bw.Write(domain2.domains.Count);
            for (int i = 0; i < domain2.domains.Count; i++)
            {
                progress_bar("Saving .sev...", i, domain2.domains.Count);
                DOMAIN2_INFO domainInfo = domain2.domains[i];
                bw.Write(domainInfo.id);
                bw.Write((int)domainInfo.point);
                bw.Write(domainInfo.wartype);
                bw.Write(domainInfo.country_id);
                bw.Write(domainInfo.is_capital);
                int maxCount = domainInfo.mappos.Count;
                for (int x = 0; x < maxCount; x++)
                {
                    MapPos point = domainInfo.mappos[x];
                    bw.Write(point.x);
                    bw.Write(point.y);
                    bw.Write(point.z);
                }
                int neighbourcount = domainInfo.neighbour.Length;
                bw.Write(neighbourcount);
                for (int n = 0; n < neighbourcount; n++)
                {
                    bw.Write(domainInfo.neighbour[n]);
                }
                for (int n = 0; n < neighbourcount; n++)
                {
                    bw.Write(domainInfo.time_neighbours[n]);
                }
            }
            battletimecount = domain2.battletime.Count;
            bw.Write(battletimecount);
            for (int b = 0; b < battletimecount; b++)
            {
                BATTLETIME tri = domain2.battletime[b];
                bw.Write(tri.Day);
                bw.Write(tri.Hour);
                bw.Write(tri.Minute);
            }
            bw.Write(domain2.battletime_max);
            fileStream.Close();
            bw.Close();
            
            progress_bar("Ready!", 0, 0);
        }

        private void DomainList2_SelectionChanged(object sender, EventArgs e)
        {
            if (!isDoingWork2 && domain2 != null && DomainList2.CurrentCell != null && DomainList2.CurrentCell.RowIndex >= 0)
            {
                int index = DomainList2.CurrentCell.RowIndex;
                DOMAIN2_INFO domainInfo = domain2.domains[index];
                domainNeigborurs2.Rows.Clear();
                MapPositionsdataGrid.Rows.Clear();
                domainPoints2.Rows.Clear();
                domainTriangles2.Rows.Clear();
                countryIdtext.Text = domainInfo.country_id.ToString();
                isCapitalCheck.Checked = domainInfo.is_capital == 1;
                for (int n = 0; n < domainInfo.neighbour.Length; n++)
                {
                    domainNeigborurs2.Rows.Add(new object[] { domainInfo.neighbour[n], domainInfo.time_neighbours[n]});
                }
                for (int x = 0; x < domainInfo.pointcountArray.Count; x++)
                {
                    DomainPoint point = domainInfo.pointcountArray[x];
                    domainPoints2.Rows.Add(new object[] { x, point.x, point.y });
                }
                for (int t = 0; t < domainInfo.triangle.Count; t++)
                {
                    DomainTriangle tri = domainInfo.triangle[t];
                    domainTriangles2.Rows.Add(new object[] { t, tri.id1, tri.id2, tri.id3 });
                }
                for (int t = 0; t < domainInfo.mappos.Count; t++)
                {
                    MapPos tri = domainInfo.mappos[t];
                    MapPositionsdataGrid.Rows.Add(new object[] { t, tri.x, tri.y, tri.z });
                }
                domainInfoIdTextBox2.Text = domainInfo.id.ToString();
                DomainInfoNameText2.Text = new Unicode(domainInfo.name).ToString();
                comboBox1.SelectedIndex = domainInfo.wartype;
                iconPostX.Text = domainInfo.iconpos[0].ToString();
                inconPostY.Text = domainInfo.iconpos[1].ToString();
            }
        }

        private void domain2AddNewBattle(object sender, EventArgs e)
        {
            if (!isDoingWork2 && domain2 != null && battleDates2.CurrentCell != null && battleDates2.CurrentCell.RowIndex >= 0)
            {
                isDoingWork2 = true;
                int selectedBattle = battleDates2.CurrentCell.RowIndex;
                String value = battleDates2.Rows[selectedBattle].Cells[0].Value.ToString();
                int valueS = 0;
                bool isInt = int.TryParse(value, out valueS);
                if (isInt)
                {
                    BATTLETIME newone = new BATTLETIME();
                    newone.Day = 0;
                    newone.Hour = 0;
                    newone.Minute = 0;
                    domain2.battletime.Add(newone);
                }
                isDoingWork2 = false;
                loadData2();
            }
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            if (!isDoingWork2 && domain2 != null && battleDates2.CurrentCell != null && battleDates2.CurrentCell.RowIndex >= 0)
            {
                isDoingWork = true;
                int selectedBattle = battleDates2.CurrentCell.RowIndex;
                String value = battleDates2.Rows[selectedBattle].Cells[0].Value.ToString();
                int valueS = 0;
                bool isInt = int.TryParse(value, out valueS);
                if (isInt)
                {
                    domain2.battletime.RemoveAt(valueS);
                }
                isDoingWork = false;
                loadData2();
            }
        }

        private void battleDates2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!isDoingWork2 && domain2 != null && battleDates2.CurrentCell != null && battleDates2.CurrentCell.RowIndex >= 0)
            {
                isDoingWork2 = true;
                int editType = battleDates2.CurrentCell.ColumnIndex;
                int selectedBattle = battleDates2.CurrentCell.RowIndex;
                String value = battleDates2.Rows[selectedBattle].Cells[editType].Value.ToString();
                int valueS = 0;
                bool isInt = int.TryParse(value, out valueS);
                if (isInt)
                {
                    switch (editType)
                    {
                        case 1:
                            //Day
                            domain2.battletime[selectedBattle].Day = valueS;
                            break;
                        case 2:
                            //Hour
                            domain2.battletime[selectedBattle].Hour = valueS;
                            break;
                        case 3:
                            //Minute
                            domain2.battletime[selectedBattle].Minute = valueS;
                            break;
                    }
                }
                isDoingWork2 = false;
                loadData2();
            }
        }

        private void battletime_max2_Leave(object sender, EventArgs e)
        {
            if (!isDoingWork2 && domain2 != null)
            {
                isDoingWork2 = true;
                int valueS = 0;
                bool isInt = int.TryParse(battletime_max2.Text, out valueS);
                if (isInt)
                {
                    domain2.battletime_max = valueS;
                }
                isDoingWork2 = false;
                loadData2();
            }
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            if (!isDoingWork2 && domain2 != null)
            {
                isDoingWork2 = true;
                DOMAIN2_INFO newDom = new DOMAIN2_INFO();
                newDom.id = 999;
                Unicode uni = new Unicode(new byte[32]);
                uni.Set("new Domain!");
                newDom.mappos.Add(new MapPos());
                newDom.mappos.Add(new MapPos());
                newDom.mappos.Add(new MapPos());
                newDom.mappos.Add(new MapPos());
                newDom.name = uni.data;
                domain2.domains.Add(newDom);
                DomainList2.Rows.Add(new Object[] { newDom.id, new Unicode(newDom.name).ToString() });
                DomainList2.CurrentCell = null;
                DomainList2.Rows[DomainList2.Rows.Count - 1].Cells[0].Selected = true;
                isDoingWork2 = false;
                loadData2();
                DomainList2_SelectionChanged(null, null);
            }
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            if (!isDoingWork2 && domain2 != null && DomainList2.CurrentCell != null && DomainList2.CurrentCell.RowIndex >= 0)
            {
                isDoingWork2 = true;
                int cellIndex = DomainList2.CurrentCell.ColumnIndex;
                int selectedDomain = DomainList2.CurrentCell.RowIndex;
                domain2.domains.RemoveAt(selectedDomain);
                DomainList2.Rows.RemoveAt(selectedDomain);
                isDoingWork2 = false;
                loadData2();
            }
        }

        private void MapPositionsdataGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!isDoingWork2 && domain2 != null && DomainList2.CurrentCell != null && DomainList2.CurrentCell.RowIndex >= 0 && MapPositionsdataGrid.CurrentCell != null)
            {
                isDoingWork2 = true;
                int cellIndex = DomainList2.CurrentCell.ColumnIndex;
                int selectedDomain = DomainList2.CurrentCell.RowIndex;
                String value = MapPositionsdataGrid.Rows[MapPositionsdataGrid.CurrentCell.RowIndex].Cells[MapPositionsdataGrid.CurrentCell.ColumnIndex].Value.ToString();
                int valueS = 0;
                bool isInt = int.TryParse(value, out valueS);
                if (isInt)
                {
                    if (MapPositionsdataGrid.CurrentCell.ColumnIndex == 1)
                    {
                        domain2.domains[selectedDomain].mappos[MapPositionsdataGrid.CurrentCell.RowIndex].x = valueS;
                    }
                    if (MapPositionsdataGrid.CurrentCell.ColumnIndex == 2)
                    {
                        domain2.domains[selectedDomain].mappos[MapPositionsdataGrid.CurrentCell.RowIndex].z = valueS;
                    }
                    if (MapPositionsdataGrid.CurrentCell.ColumnIndex == 3)
                    {
                        domain2.domains[selectedDomain].mappos[MapPositionsdataGrid.CurrentCell.RowIndex].y = valueS;
                    }
                }
                isDoingWork2 = false;
                loadData2();
            }
        }

        private void domainNeigborurs2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!isDoingWork2 && domain2 != null && DomainList2.CurrentCell != null && DomainList2.CurrentCell.RowIndex >= 0 && domainNeigborurs2.CurrentCell != null)
            {
                isDoingWork2 = true;
                int cellIndex = DomainList2.CurrentCell.ColumnIndex;
                int selectedDomain = DomainList2.CurrentCell.RowIndex;
                String value = domainNeigborurs2.Rows[domainNeigborurs2.CurrentCell.RowIndex].Cells[domainNeigborurs2.CurrentCell.ColumnIndex].Value.ToString();
                int valueS = 0;
                bool isInt = int.TryParse(value, out valueS);
                if (isInt)
                {
                    if(domainNeigborurs2.CurrentCell.ColumnIndex == 0)             
                        domain2.domains[selectedDomain].neighbour[domainNeigborurs2.CurrentCell.RowIndex] = valueS;
                    else
                        domain2.domains[selectedDomain].time_neighbours[domainNeigborurs2.CurrentCell.RowIndex] = valueS;
                }

                isDoingWork2 = false;
                loadData2();
            }
        }

        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            if (!isDoingWork2 && domain2 != null && DomainList2.CurrentCell != null && DomainList2.CurrentCell.RowIndex >= 0)
            {
                isDoingWork2 = true;
                int cellIndex = DomainList2.CurrentCell.ColumnIndex;
                int selectedDomain = DomainList2.CurrentCell.RowIndex;

                int newInt = domain2.domains[selectedDomain].neighbour.Length + 1;
                int[] newNeigbors = new int[newInt];
                int[] newNeigborsTime = new int[newInt];
                for (int i = 0; i < domain2.domains[selectedDomain].neighbour.Length; i++)
                {
                    newNeigbors[i] = domain2.domains[selectedDomain].neighbour[i];
                    newNeigborsTime[i] = domain2.domains[selectedDomain].time_neighbours[i];
                }
                newNeigbors[newInt - 1] = -1;
                newNeigborsTime[newInt - 1] = -1;
                domain2.domains[selectedDomain].neighbour = newNeigbors;
                domain2.domains[selectedDomain].time_neighbours = newNeigborsTime;
                isDoingWork2 = false;
                loadData2();
                DomainList2_SelectionChanged(null, null);
            }
        }

        private void toolStripMenuItem14_Click(object sender, EventArgs e)
        {
            if (!isDoingWork2 && domain2 != null && DomainList2.CurrentCell != null && DomainList2.CurrentCell.RowIndex >= 0 && domainNeigborurs2.CurrentCell != null)
            {
                isDoingWork2 = true;
                int cellIndex = DomainList2.CurrentCell.ColumnIndex;
                int selectedDomain = DomainList2.CurrentCell.RowIndex;
                int newInt = domain2.domains[selectedDomain].neighbour.Length - 1;
                int[] newNeigbors = new int[newInt];
                int[] newNeigborstime = new int[newInt];
                int x = 0;
                int i = 0;
                while (x < domain2.domains[selectedDomain].neighbour.Length)
                {
                    if (x != domainNeigborurs2.CurrentCell.RowIndex)
                    {
                        newNeigbors[i] = domain2.domains[selectedDomain].neighbour[x];
                        newNeigborstime[i] = domain2.domains[selectedDomain].time_neighbours[x];
                        i++;
                    }
                    x++;
                }
                domain2.domains[selectedDomain].neighbour = newNeigbors;
                domain2.domains[selectedDomain].time_neighbours = newNeigborstime;
                isDoingWork2 = false;
                loadData2();
                DomainList2_SelectionChanged(null, null);
            }
        }

        private void domainPoints2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!isDoingWork2 && domain2 != null && DomainList2.CurrentCell != null && DomainList2.CurrentCell.RowIndex >= 0 && domainPoints2.CurrentCell != null)
            {
                isDoingWork2 = true;
                int cellIndex = DomainList2.CurrentCell.ColumnIndex;
                int selectedDomain = DomainList2.CurrentCell.RowIndex;
                String value = domainPoints2.Rows[domainPoints2.CurrentCell.RowIndex].Cells[domainPoints2.CurrentCell.ColumnIndex].Value.ToString();
                int valueS = 0;
                bool isInt = int.TryParse(value, out valueS);
                if (isInt)
                {
                    if (domainPoints2.CurrentCell.ColumnIndex == 1)
                    {
                        domain2.domains[selectedDomain].pointcountArray[domainPoints2.CurrentCell.RowIndex].x = valueS;
                    }
                    else
                    {
                        domain2.domains[selectedDomain].pointcountArray[domainPoints2.CurrentCell.RowIndex].y = valueS;
                    }
                }
                isDoingWork2 = false;
                loadData2();
            }
        }

        private void toolStripMenuItem15_Click(object sender, EventArgs e)
        {
            if (!isDoingWork2 && domain2 != null && DomainList2.CurrentCell != null && DomainList2.CurrentCell.RowIndex >= 0)
            {
                isDoingWork = true;
                int cellIndex = DomainList2.CurrentCell.ColumnIndex;
                int selectedDomain = DomainList2.CurrentCell.RowIndex;
                DomainPoint dot = new DomainPoint();
                dot.x = -1;
                dot.y = -1;
                domain2.domains[selectedDomain].pointcountArray.Add(dot);
                isDoingWork2 = false;
                loadData2();
                DomainList2_SelectionChanged(null, null);
            }
        }

        private void toolStripMenuItem16_Click(object sender, EventArgs e)
        {
            if (!isDoingWork2 && domain2 != null && DomainList2.CurrentCell != null && DomainList2.CurrentCell.RowIndex >= 0 && domainPoints2.CurrentCell != null)
            {
                isDoingWork2 = true;
                int cellIndex = DomainList2.CurrentCell.ColumnIndex;
                int selectedDomain = DomainList2.CurrentCell.RowIndex;
                domain2.domains[selectedDomain].pointcountArray.RemoveAt(domainPoints2.CurrentCell.RowIndex);
                isDoingWork2 = false;
                loadData2();
                DomainList2_SelectionChanged(null, null);
            }
        }

        private void domainTriangles2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!isDoingWork2 && domain2 != null && DomainList2.CurrentCell != null && DomainList2.CurrentCell.RowIndex >= 0 && domainTriangles2.CurrentCell != null)
            {
                isDoingWork2 = true;
                int cellIndex = DomainList2.CurrentCell.ColumnIndex;
                int selectedDomain = DomainList2.CurrentCell.RowIndex;
                String value = domainTriangles2.Rows[domainTriangles2.CurrentCell.RowIndex].Cells[domainTriangles2.CurrentCell.ColumnIndex].Value.ToString();
                int valueS = 0;
                bool isInt = int.TryParse(value, out valueS);
                if (isInt)
                {
                    if (domainTriangles2.CurrentCell.ColumnIndex == 1)
                    {
                        domain2.domains[selectedDomain].triangle[domainTriangles2.CurrentCell.RowIndex].id1 = valueS;
                    }
                    if (domainTriangles2.CurrentCell.ColumnIndex == 2)
                    {
                        domain2.domains[selectedDomain].triangle[domainTriangles2.CurrentCell.RowIndex].id2 = valueS;
                    }
                    if (domainTriangles2.CurrentCell.ColumnIndex == 3)
                    {
                        domain2.domains[selectedDomain].triangle[domainTriangles2.CurrentCell.RowIndex].id3 = valueS;
                    }
                }
                isDoingWork2 = false;
                loadData2();
            }
        }

        private void toolStripMenuItem17_Click(object sender, EventArgs e)
        {
            if (!isDoingWork2 && domain2 != null && DomainList2.CurrentCell != null && DomainList2.CurrentCell.RowIndex >= 0)
            {
                isDoingWork2 = true;
                int cellIndex = DomainList2.CurrentCell.ColumnIndex;
                int selectedDomain = DomainList2.CurrentCell.RowIndex;
                DomainTriangle dt = new DomainTriangle();
                dt.id1 = -1;
                dt.id2 = -1;
                dt.id3 = -1;
                domain2.domains[selectedDomain].triangle.Add(dt);
                isDoingWork2 = false;
                loadData2();
                DomainList2_SelectionChanged(null, null);
            }
        }

        private void toolStripMenuItem18_Click(object sender, EventArgs e)
        {
            if (!isDoingWork2 && domain2 != null && DomainList2.CurrentCell != null && DomainList2.CurrentCell.RowIndex >= 0 && domainTriangles2.CurrentCell != null)
            {
                isDoingWork2 = true;
                int cellIndex = DomainList2.CurrentCell.ColumnIndex;
                int selectedDomain = DomainList2.CurrentCell.RowIndex;
                domain2.domains[selectedDomain].triangle.RemoveAt(domainTriangles2.CurrentCell.RowIndex);
                isDoingWork2 = false;
                loadData2();
                DomainList2_SelectionChanged(null, null);
            }
        }

        private void isCapitalCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (!isDoingWork2 && domain2 != null && DomainList2.CurrentCell != null && DomainList2.CurrentCell.RowIndex >= 0)
            {
                isDoingWork2 = true;
                int selectedDomain = DomainList2.CurrentCell.RowIndex;
                domain2.domains[selectedDomain].is_capital = isCapitalCheck.Checked ? 1:0;
                isDoingWork2 = false;
                loadData2();
                DomainList2_SelectionChanged(null, null);
            }
        }

        private void countryIdtext_Leave(object sender, EventArgs e)
        {
            if (!isDoingWork2 && domain2 != null && DomainList2.CurrentCell != null && DomainList2.CurrentCell.RowIndex >= 0)
            {
                isDoingWork2 = true;
                int selectedDomain = DomainList2.CurrentCell.RowIndex;
                String value = countryIdtext.Text;
                int valueS = 0;
                bool isInt = int.TryParse(value, out valueS);
                if (isInt)
                    domain2.domains[selectedDomain].country_id = valueS;
                isDoingWork2 = false;
                loadData2();
                DomainList2_SelectionChanged(null, null);
            }
        }

        private void iconPostX_TextChanged(object sender, EventArgs e)
        {
            if (!isDoingWork2 && domain2 != null && DomainList2.CurrentCell != null && DomainList2.CurrentCell.RowIndex >= 0)
            {
                isDoingWork2 = true;
                int selectedDomain = DomainList2.CurrentCell.RowIndex;
                String value = iconPostX.Text;
                int valueS = 0;
                bool isInt = int.TryParse(value, out valueS);
                if (isInt)
                    domain2.domains[selectedDomain].iconpos[0] = valueS;
                isDoingWork2 = false;
                loadData2();
                DomainList2_SelectionChanged(null, null);
            }
        }

        private void inconPostY_TextChanged(object sender, EventArgs e)
        {
            if (!isDoingWork2 && domain2 != null && DomainList2.CurrentCell != null && DomainList2.CurrentCell.RowIndex >= 0)
            {
                isDoingWork2 = true;
                int selectedDomain = DomainList2.CurrentCell.RowIndex;
                String value = iconPostX.Text;
                int valueS = 0;
                bool isInt = int.TryParse(value, out valueS);
                if (isInt)
                    domain2.domains[selectedDomain].iconpos[1] = valueS;
                isDoingWork2 = false;
                loadData2();
                DomainList2_SelectionChanged(null, null);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isDoingWork2 && domain2 != null && DomainList2.CurrentCell != null && DomainList2.CurrentCell.RowIndex >= 0)
            {
                isDoingWork2 = true;
                int selectedDomain = DomainList2.CurrentCell.RowIndex;
                domain2.domains[selectedDomain].wartype = comboBox1.SelectedIndex;
                isDoingWork2 = false;
                loadData2();
                DomainList2_SelectionChanged(null, null);
            }
        }

        private void domainInfoIdTextBox2_Leave(object sender, EventArgs e)
        {
            if (!isDoingWork2 && domain2 != null && DomainList2.CurrentCell != null && DomainList2.CurrentCell.RowIndex >= 0)
            {
                isDoingWork2 = true;
                int cellIndex = DomainList2.CurrentCell.ColumnIndex;
                int selectedDomain = DomainList2.CurrentCell.RowIndex;
                String value = domainInfoIdTextBox2.Text;
                int valueS = 0;
                bool isInt = int.TryParse(value, out valueS);
                if (isInt)
                {
                    domain2.domains[selectedDomain].id = valueS;
                    DomainList2.Rows[selectedDomain].Cells[0].Value = valueS;
                }

                isDoingWork2 = false;
                loadData2();
            }
        }

        private void DomainInfoNameText2_Leave(object sender, EventArgs e)
        {
            if (!isDoingWork2 && domain2 != null && DomainList2.CurrentCell != null && DomainList2.CurrentCell.RowIndex >= 0)
            {
                isDoingWork2 = true;
                int cellIndex = DomainList2.CurrentCell.ColumnIndex;
                int selectedDomain = DomainList2.CurrentCell.RowIndex;
                String value = DomainInfoNameText2.Text;
                Unicode uni = new Unicode(new byte[32]);
                uni.Set(value);
                domain2.domains[selectedDomain].name = uni.data;
                DomainList2.Rows[selectedDomain].Cells[1].Value = new Unicode(domain2.domains[selectedDomain].name).ToString();
                isDoingWork2 = false;
                loadData2();
            }
        }

        private void tabControl4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabControl4.SelectedIndex == 0)
            {
               // if (this.Visible)
                    //NewMainForm.getInstance().setText("P.W.D.E. - " + domainPath);
            }
            if (tabControl4.SelectedIndex == 1)
            {
               // if (this.Visible)
                   // NewMainForm.getInstance().setText("P.W.D.E. - " + domainPath2);
            }
        }

        private void DomainEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Program.StandAlone)
            {
                if (e.CloseReason == CloseReason.UserClosing)
                {
                    e.Cancel = true;
                    this.WindowState = FormWindowState.Minimized;
                    this.MinimizeBox = Program.SHOWMINIMIZEBUTTON;
                    if (Program.HIDEINTASKBAR)
                        ShowIcon = ShowInTaskbar = false;
                }
            }
            else
            {
                MainProgram.getInstance().ExitInvoke();
            }
        }

        private void DomainEditor_Shown(object sender, EventArgs e)
        {
            if(isAutoOpen)
            {
                try
                {
                        try
                        {
                            isDoingWork = true;
                            firstLoaded = false;
                            DomainList.Rows.Clear();
                            domainPath = autoOpenPath;

                            domain = new DOMAIN();
                            FileStream fileStream = File.OpenRead(domainPath);
                            BinaryReader binaryReader = new BinaryReader((Stream)fileStream);
                            domain.version = binaryReader.ReadInt32();
                            int count = binaryReader.ReadInt32();
                            for (int i = 0; i < count; i++)
                            {
                                progress_bar("Loading data...", i, count);
                                DOMAIN_INFO domainInfo = new DOMAIN_INFO();
                                domainInfo.name = binaryReader.ReadBytes(32);
                                domainInfo.id = binaryReader.ReadInt32();
                                domainInfo.type = (DOMAIN_TYPE)binaryReader.ReadInt32();
                                DomainList.Rows.Add(new Object[] { domainInfo.id, new Unicode(domainInfo.name).ToString() });
                                domainInfo.reward = binaryReader.ReadInt32();
                                domainInfo.iconpos[0] = binaryReader.ReadInt32();
                                domainInfo.iconpos[1] = binaryReader.ReadInt32();
                                int pointscount = binaryReader.ReadInt32();
                                for (int x = 0; x < pointscount; x++)
                                {
                                    DomainPoint point = new DomainPoint();
                                    point.x = binaryReader.ReadInt32();
                                    point.y = binaryReader.ReadInt32();
                                    domainInfo.pointcountArray.Add(point);
                                }
                                int trianglescount = binaryReader.ReadInt32();
                                for (int t = 0; t < trianglescount; t++)
                                {
                                    DomainTriangle tri = new DomainTriangle();
                                    tri.id1 = binaryReader.ReadInt32();
                                    tri.id2 = binaryReader.ReadInt32();
                                    tri.id3 = binaryReader.ReadInt32();

                                    domainInfo.triangle.Add(tri);
                                }
                                int nNumNeighbours = binaryReader.ReadInt32();
                                domainInfo.neighbour = new int[nNumNeighbours];
                                for (int n = 0; n < nNumNeighbours; n++)
                                {
                                    domainInfo.neighbour[n] = binaryReader.ReadInt32();
                                }
                                domain.domains.Add(domainInfo);
                            }
                            int battletimecount = binaryReader.ReadInt32();
                            for (int b = 0; b < battletimecount; b++)
                            {
                                BATTLETIME tri = new BATTLETIME();
                                tri.Day = binaryReader.ReadInt32();
                                tri.Hour = binaryReader.ReadInt32();
                                tri.Minute = binaryReader.ReadInt32();
                                domain.battletime.Add(tri);
                            }
                            domain.battletime_max = binaryReader.ReadInt32();
                            domain.batles = new int[2];
                            fileStream.Close();
                            binaryReader.Close();
                        }
                        catch
                        {
                            resetAllForm();
                            domain = null;

                            try
                            {
                                isDoingWork2 = true;
                                firstLoaded2 = false;
                                DomainList2.Rows.Clear();

                                    domain2sev = autoOpenPath;
                                    domain2 = new DOMAIN2();
                                    FileStream fileStream = File.OpenRead(domainPath2);
                                    BinaryReader br = new BinaryReader((Stream)fileStream);
                                    domain2.magic = br.ReadInt32();
                                    domain2.domain2_data_timestamp = br.ReadInt32();
                                    int count = (int)br.ReadInt32();
                                    for (int i = 0; i < count; i++)
                                    {
                                        progress_bar("Loading data...", i, count);
                                        DOMAIN2_INFO domainInfo = new DOMAIN2_INFO();
                                        domainInfo.name = br.ReadBytes(32);
                                        domainInfo.id = br.ReadInt32();
                                        domainInfo.point = br.ReadInt32();
                                        domainInfo.wartype = br.ReadInt32();
                                        domainInfo.country_id = br.ReadInt32();
                                        domainInfo.is_capital = br.ReadInt32();
                                        DomainList2.Rows.Add(new Object[] { domainInfo.id, new Unicode(domainInfo.name).ToString() });
                                        int maxCount = 4;

                                        for (int x = 0; x < maxCount; x++)
                                        {
                                            MapPos point = new MapPos();
                                            point.x = br.ReadSingle();
                                            point.y = br.ReadSingle();
                                            point.z = br.ReadSingle();
                                            domainInfo.mappos.Add(point);
                                        }
                                        domainInfo.iconpos[0] = br.ReadInt32();
                                        domainInfo.iconpos[1] = br.ReadInt32();
                                        int pointscount = br.ReadInt32();
                                        for (int x = 0; x < pointscount; x++)
                                        {
                                            DomainPoint point = new DomainPoint();
                                            point.x = br.ReadInt32();
                                            point.y = br.ReadInt32();
                                            domainInfo.pointcountArray.Add(point);
                                        }
                                        int trianglescount = br.ReadInt32();
                                        for (int t = 0; t < trianglescount; t++)
                                        {
                                            DomainTriangle tri = new DomainTriangle();
                                            tri.id1 = br.ReadInt32();
                                            tri.id2 = br.ReadInt32();
                                            tri.id3 = br.ReadInt32();

                                            domainInfo.triangle.Add(tri);
                                        }

                                        int _count3 = br.ReadInt32();
                                        domainInfo.neighbour = new int[_count3];
                                        for (int n = 0; n < _count3; n++)
                                        {
                                            domainInfo.neighbour[n] = br.ReadInt32();
                                        }
                                        domain2.domains.Add(domainInfo);

                                    }
                                    int battletimecount = br.ReadInt32();
                                    for (int b = 0; b < battletimecount; b++)
                                    {
                                        BATTLETIME tri = new BATTLETIME();
                                        tri.Day = br.ReadInt32();
                                        tri.Hour = br.ReadInt32();
                                        tri.Minute = br.ReadInt32();
                                        domain2.battletime.Add(tri);
                                    }
                                    domain2.battletime_max = br.ReadInt32();
                                    fileStream.Close();
                                    br.Close();


                                    fileStream = File.OpenRead(domain2sev);
                                    br = new BinaryReader((Stream)fileStream);
                                    br.ReadInt32();
                                    int count2 = br.ReadInt32();
                                    for (int i = 0; i < count2; i++)
                                    {
                                        int id = br.ReadInt32();
                                        int pointx = br.ReadInt32();
                                        int wartype = br.ReadInt32();

                                        int country_id = br.ReadInt32();
                                        int is_capital = br.ReadInt32();
                                        int maxCount = 4;
                                        for (int x = 0; x < maxCount; x++)
                                        {
                                            MapPos point = new MapPos();
                                            point.x = br.ReadSingle();
                                            point.y = br.ReadSingle();
                                            point.z = br.ReadSingle();
                                        }
                                        int _count3 = br.ReadInt32();
                                        int[] notimportant = new int[_count3];
                                        for (int n = 0; n < _count3; n++)
                                        {
                                            notimportant[n] = br.ReadInt32();
                                        }
                                        int[] important = new int[_count3];
                                        for (int n = 0; n < _count3; n++)
                                        {
                                            important[n] = br.ReadInt32();
                                        }
                                        DOMAIN2_INFO domaininfo = getDomainById(id);
                                        if (domaininfo != null)
                                        {
                                            domaininfo.neighbour = notimportant;
                                            domaininfo.time_neighbours = important;
                                        }
                                    }

                                    battletimecount = br.ReadInt32();
                                    for (int b = 0; b < battletimecount; b++)
                                    {
                                        BATTLETIME tri = new BATTLETIME();
                                        tri.Day = br.ReadInt32();
                                        tri.Hour = br.ReadInt32();
                                        tri.Minute = br.ReadInt32();
                                    }
                                    domain2.battletime_max = br.ReadInt32();

                                    fileStream.Close();
                                    br.Close();
                                
                            }
                            catch
                            {
                                resetAllForm2();
                                domain2 = null;
                            }
                        
                        isDoingWork2 = false;
                        loadData2();
                        progress_bar("Ready!", 0, 0);
                    }
                    
                    isDoingWork = false;
                    loadData();
                    progress_bar("Ready!", 0, 0);
                }
                catch { }
            }
        }
    }
}
