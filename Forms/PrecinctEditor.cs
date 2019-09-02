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
using PWDataEditorPaied.NewEditors;
using PWDataEditorPaied.Forms.SubForms;
using JHUI.Utils;

namespace ElementEditor
{
    public partial class PrecinctEditor : JForm
    {
        internal bool isAutoOpen;
        internal PretinctFile Read = null;
        internal string autoOpenPath;
        private PointF[] points;
        private WorldMap mapView;
        private int last_index;

        public bool Loaded { get; private set; }

        internal delegate void UpdateProgressDelegate(String value, int min, int max);
        internal event UpdateProgressDelegate progress_bar2;

        public PrecinctEditor()
        {
            InitializeComponent();
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

        private void PrecinctEditor_FormClosing(object sender, FormClosingEventArgs e)
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

        private void PrecinctEditor_Shown(object sender, EventArgs e)
        {
            if(isAutoOpen)
            {
                LoadPrecinct();
            }
        }

        private void LoadPrecinct()
        {
            Read = new PretinctFile();
            PretinctDataGrid.RowCount = 0;
            if (Read.ReadFile(autoOpenPath))
            {
                Loaded = true;
                jTextBox1.Text = Read.dwVersion.ToString();
                jTextBox2.Text = Read.dwTimeStamp.ToString();
                PretinctDataGrid.RowCount = Read.zones.Count;
            }
            else
            {
                Loaded = false;
            }
        }

        private void jPictureBox1_Click(object sender, EventArgs e)
        {

            OpenFileDialog load = new OpenFileDialog();
            load.Filter = "Precinct (precinct.clt)|*.clt|All Files (*.*)|*.*";
            if (load.ShowDialog() == System.Windows.Forms.DialogResult.OK && File.Exists(load.FileName))
            {
                Loaded = false;
                autoOpenPath = load.FileName;
                isAutoOpen = true;
                Read = null;
                PretinctDataGrid.RowCount = 0;
                ZonesDataGrid.RowCount = 0;
                Music.RowCount = 0;
                Nigbour.RowCount = 0;
                LoadPrecinct();
            }          
        }

        private void jPictureBox2_Click(object sender, EventArgs e)
        {
            if(Read != null)
            {
                if(Read.SaveFile(autoOpenPath))
                {
                    JMessageBox.Show(this, "Precinct file saved."); 
                }
            }
        }

        private void PretinctDataGrid_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            if (!Loaded)
                return;
            try
            {
                if (PretinctDataGrid.CurrentCell != null)
                {
                    int itemid = e.RowIndex;
                    if (e.ColumnIndex == 0)
                    {
                        e.Value = Read.zones[itemid].ID.ToString();
                    }
                    if (e.ColumnIndex == 1)
                    {
                        e.Value = Read.zones[itemid].name;
                    }
                    if (e.ColumnIndex == 2)
                    {
                        e.Value = Read.zones[itemid].m_iPriority.ToString();
                    }
                    if (e.ColumnIndex == 3)
                    {
                        e.Value = Read.zones[itemid].m_idDstIns.ToString();
                    }
                    if (e.ColumnIndex == 4)
                    {
                        e.Value = Read.zones[itemid].m_idSrcInst.ToString();
                    }
                    if (e.ColumnIndex == 5)
                    {
                        e.Value = Read.zones[itemid].m_idDomain.ToString();
                    }
                    if (e.ColumnIndex == 6)
                    {
                        e.Value = Read.zones[itemid].m_bPKProtect.ToString();
                    }
                    if (e.ColumnIndex == 7)
                    {
                        e.Value = Read.zones[itemid].unk0.ToString();
                    }
                    if (e.ColumnIndex == 8)
                    {
                        e.Value = Read.zones[itemid].unk1.ToString();
                    }
                    if (e.ColumnIndex == 9)
                    {
                        e.Value = Read.zones[itemid].unk2.ToString();
                    }
                    if (e.ColumnIndex == 10)
                    {
                        e.Value = Read.zones[itemid].unk3.ToString();
                    }
                }
            }
            catch { }
        }

        private void PretinctDataGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!Loaded)
                return;
            try
            {
                if (PretinctDataGrid.CurrentCell != null)
                {
                    int itemid = e.RowIndex;
                    if (e.ColumnIndex == 0)
                    {
                        Read.zones[itemid].ID = int.Parse(PretinctDataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue.ToString());
                    }
                    if (e.ColumnIndex == 1)
                    {
                        Read.zones[itemid].name = PretinctDataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue.ToString();
                    }
                    if (e.ColumnIndex == 2)
                    {
                        Read.zones[itemid].m_iPriority = int.Parse(PretinctDataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue.ToString());
                    }
                    if (e.ColumnIndex == 3)
                    {
                        Read.zones[itemid].m_idDstIns = int.Parse(PretinctDataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue.ToString());
                    }
                    if (e.ColumnIndex == 4)
                    {
                       Read.zones[itemid].m_idSrcInst = int.Parse(PretinctDataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue.ToString());
                    }
                    if (e.ColumnIndex == 5)
                    {
                        Read.zones[itemid].m_idDomain = int.Parse(PretinctDataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue.ToString());
                    }
                    if (e.ColumnIndex == 6)
                    {
                        Read.zones[itemid].m_bPKProtect = byte.Parse(PretinctDataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue.ToString());
                    }
                    if (e.ColumnIndex == 7)
                    {
                        Read.zones[itemid].unk0 = int.Parse(PretinctDataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue.ToString());
                    }
                    if (e.ColumnIndex == 8)
                    {
                        Read.zones[itemid].unk1 = int.Parse(PretinctDataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue.ToString());
                    }
                    if (e.ColumnIndex == 9)
                    {
                       Read.zones[itemid].unk2 = int.Parse(PretinctDataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue.ToString());
                    }
                    if (e.ColumnIndex == 10)
                    {
                       Read.zones[itemid].unk3 = int.Parse(PretinctDataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue.ToString());
                    }
                }
            }
            catch { JMessageBox.Show(this, "Incorrect value."); }
        }

        private void PretinctDataGrid_SelectionChanged(object sender, EventArgs e)
        {
            if (Loaded && PretinctDataGrid.CurrentCell != null)
            {
                int index = PretinctDataGrid.CurrentCell.RowIndex;
                ZonesDataGrid.RowCount = Read.zones[index].m_aPoints.Count;
                Music.RowCount = Read.zones[index].music.Count;
                Nigbour.RowCount = Read.zones[index].Npcs.Count;
                points = new PointF[ZonesDataGrid.RowCount];
                m_vCityPosx.Text = Read.zones[index].m_vCityPos.oX;
                m_vCityPosy.Text = Read.zones[index].m_vCityPos.oY;
                m_vCityPosz.Text = Read.zones[index].m_vCityPos.oZ;

                if (mapView != null)
                {
                    for (int i = 0; i < Read.zones[PretinctDataGrid.CurrentCell.RowIndex].m_aPoints.Count; i++)
                    {
                        points[i] = new PointF(Read.zones[PretinctDataGrid.CurrentCell.RowIndex].m_aPoints[i].X, Read.zones[PretinctDataGrid.CurrentCell.RowIndex].m_aPoints[i].Z);
                    }
                    mapView.DrawPoligonWithSelectedPoint(0, points, sender != null);
                }
            }
        }

        private void jPictureBox4_Click(object sender, EventArgs e)
        {
            if (mapView != null)
            {
                try
                {
                    mapView.Close();
                }
                catch { }
                try
                {
                    mapView = null;
                }
                catch { }
            }
            mapView = new WorldMap(autoOpenPath);
            mapView.mouseDown += MapViewMouseDown;
            mapView.Show();
        }

        private void MapViewMouseDown(float x, float y)
        {
            if (PretinctDataGrid.CurrentCell != null && ZonesDataGrid.CurrentCell != null)
            {
                last_index = ZonesDataGrid.CurrentCell.RowIndex;
                int itemid = PretinctDataGrid.CurrentCell.RowIndex;
                int zoneId = ZonesDataGrid.CurrentCell.RowIndex;

                if (zoneId == 0 || zoneId == Read.zones[itemid].m_aPoints.Count - 1)
                {
                    Read.zones[itemid].m_aPoints[0].oX = x.ToString("F6");
                    Read.zones[itemid].m_aPoints[0].oZ = y.ToString("F6");
                    Read.zones[itemid].m_aPoints[points.Length - 1].oX = x.ToString("F6");
                    Read.zones[itemid].m_aPoints[points.Length - 1].oZ = y.ToString("F6");
                }
                else
                {
                    Read.zones[itemid].m_aPoints[zoneId].oX = x.ToString("F6");
                    Read.zones[itemid].m_aPoints[zoneId].oZ = y.ToString("F6");
                }
                points = new PointF[Read.zones[itemid].m_aPoints.Count];
                for (int i = 0; i < Read.zones[itemid].m_aPoints.Count; i++)
                {
                    points[i] = new PointF(Read.zones[itemid].m_aPoints[i].X, Read.zones[itemid].m_aPoints[i].Z);
                }
                if (mapView != null)
                    mapView.DrawPoligonWithSelectedPoint(last_index, points, false);
            }
        }

        private void ZonesDataGrid_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            if(Loaded && PretinctDataGrid.CurrentCell != null)
            {
                int index = e.RowIndex;
                int itemid = PretinctDataGrid.CurrentCell.RowIndex;
                if (e.ColumnIndex == 0)
                {
                    e.Value = Read.zones[itemid].m_aPoints[index].oX;
                }
                if (e.ColumnIndex == 1)
                {
                    e.Value = Read.zones[itemid].m_aPoints[index].oY;
                }
                if (e.ColumnIndex == 2)
                {
                    e.Value = Read.zones[itemid].m_aPoints[index].oZ;
                }
            }
        }

        private void ZonesDataGrid_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (Loaded && PretinctDataGrid.CurrentCell != null && ZonesDataGrid.CurrentCell != null)
                {
                    int index = PretinctDataGrid.CurrentCell.RowIndex;
                    points = new PointF[Read.zones[index].m_aPoints.Count];
                    if (mapView != null)
                    {
                        for (int i = 0; i < Read.zones[index].m_aPoints.Count; i++)
                        {
                            points[i] = new PointF(Read.zones[index].m_aPoints[i].X, Read.zones[index].m_aPoints[i].Z);
                        }

                        mapView.DrawPoligonWithSelectedPoint(ZonesDataGrid.CurrentCell.RowIndex, points, sender != null);
                    }
                }
            }
            catch { }
        }

        private void ZonesDataGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (Loaded && PretinctDataGrid.CurrentCell != null)
                {
                    int index = e.RowIndex;
                    int itemid = PretinctDataGrid.CurrentCell.RowIndex;
                    if (e.ColumnIndex == 0)
                    {
                        Read.zones[itemid].m_aPoints[index].oX = ZonesDataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue.ToString();
                    }
                    if (e.ColumnIndex == 1)
                    {
                        Read.zones[itemid].m_aPoints[index].oY = ZonesDataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue.ToString();
                    }
                    if (e.ColumnIndex == 2)
                    {
                        Read.zones[itemid].m_aPoints[index].oZ = ZonesDataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue.ToString();
                    }
                }
            }
            catch { JMessageBox.Show(this, "Incorrect value."); }
        }

        private void jTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (Read != null)
            {
                try
                {
                    uint vnew = Convert.ToUInt16(jTextBox1.Text);
                    Read.dwVersion = vnew;
                }
                catch { }
            }
        }

        private void jPictureBox3_Click(object sender, EventArgs e)
        {
            if (Read != null)
            {
                jTextBox2.Text = (Time.timeStampMilisecond / 1000).ToString();
                Read.dwTimeStamp = Convert.ToInt32(jTextBox2.Text);
            }
        }

        private void Music_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            if (Loaded && PretinctDataGrid.CurrentCell != null)
            {
                int index = e.RowIndex;
                int itemid = PretinctDataGrid.CurrentCell.RowIndex;
                if (e.ColumnIndex == 0)
                {
                    e.Value = Read.zones[itemid].music[index];
                }
            }
        }

        private void Nigbour_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            if (Loaded && PretinctDataGrid.CurrentCell != null)
            {
                int index = e.RowIndex;
                int itemid = PretinctDataGrid.CurrentCell.RowIndex;
                if(Read.zones[itemid].Npcs.Count == 0)
                {
                    return;
                }
                if (e.ColumnIndex == 0)
                {
                    e.Value = Read.zones[itemid].Npcs[index].Name;
                }
                if (e.ColumnIndex == 1)
                {
                    e.Value = Read.zones[itemid].Npcs[index].position.oX;
                }
                if (e.ColumnIndex == 2)
                {
                    e.Value = Read.zones[itemid].Npcs[index].position.oY;
                }
                if (e.ColumnIndex == 3)
                {
                    e.Value = Read.zones[itemid].Npcs[index].position.oZ;
                }
            }

        }

        private void m_vCityPosx_TextChanged(object sender, EventArgs e)
        {
            if (Read != null && Loaded && PretinctDataGrid.CurrentCell != null)
            {
                try
                {
                    int index = PretinctDataGrid.CurrentCell.RowIndex;
                    Read.zones[index].m_vCityPos.oX = m_vCityPosx.Text;
                }
                catch { }
            }
        }

        private void m_vCityPosy_TextChanged(object sender, EventArgs e)
        {
            if (Read != null && Loaded && PretinctDataGrid.CurrentCell != null)
            {
                try
                {
                    int index = PretinctDataGrid.CurrentCell.RowIndex;
                    Read.zones[index].m_vCityPos.oY = m_vCityPosy.Text;
                }
                catch { }
            }
        }

        private void m_vCityPosz_TextChanged(object sender, EventArgs e)
        {
            if (Read != null && Loaded && PretinctDataGrid.CurrentCell != null)
            {
                try
                {
                    int index = PretinctDataGrid.CurrentCell.RowIndex;
                    Read.zones[index].m_vCityPos.oZ = m_vCityPosz.Text;
                }
                catch { }
            }
        }

        private void Music_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (Loaded && PretinctDataGrid.CurrentCell != null)
            {
                int index = e.RowIndex;
                int itemid = PretinctDataGrid.CurrentCell.RowIndex;
                if (e.ColumnIndex == 0)
                {
                    Read.zones[itemid].music[index] = Music.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue.ToString();
                }
            }
        }

        private void Nigbour_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (Loaded && PretinctDataGrid.CurrentCell != null)
            {
                int index = e.RowIndex;
                int itemid = PretinctDataGrid.CurrentCell.RowIndex;
                if (e.ColumnIndex == 0)
                {
                    Read.zones[itemid].Npcs[index].Name = Nigbour.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue.ToString();
                }
                if (e.ColumnIndex == 1)
                {
                    Read.zones[itemid].Npcs[index].position.oX = Nigbour.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue.ToString();
                }
                if (e.ColumnIndex == 2)
                {
                    Read.zones[itemid].Npcs[index].position.oY = Nigbour.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue.ToString();
                }
                if (e.ColumnIndex == 2)
                {
                    Read.zones[itemid].Npcs[index].position.oZ = Nigbour.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue.ToString();
                }
            }
        }

        private void cloneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Loaded && PretinctDataGrid.CurrentCell != null)
            {
                try
                {
                    int itemid = PretinctDataGrid.CurrentCell.RowIndex;
                    Read.zones.Add(Read.zones[itemid].clone());
                    PretinctDataGrid.RowCount = Read.zones.Count();
                    PretinctDataGrid.Refresh();
                    int nRowIndex = PretinctDataGrid.Rows.Count - 1;
                    int nColumnIndex = 0;
                    PretinctDataGrid.Rows[nRowIndex].Selected = true;
                    PretinctDataGrid.Rows[nRowIndex].Cells[nColumnIndex].Selected = true;
                }
                catch { }
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Loaded && PretinctDataGrid.CurrentCell != null)
            {
                try
                {
                    int itemid = PretinctDataGrid.CurrentCell.RowIndex;
                    Read.zones.RemoveAt(itemid);
                    PretinctDataGrid.RowCount = Read.zones.Count();
                    PretinctDataGrid.Refresh();
                    int nRowIndex = PretinctDataGrid.Rows.Count - 1;
                    int nColumnIndex = 0;
                    PretinctDataGrid.Rows[nRowIndex].Selected = true;
                    PretinctDataGrid.Rows[nRowIndex].Cells[nColumnIndex].Selected = true;
                }
                catch { }
            }
        }

        private void Convertclttosevfolder_Click(object sender, EventArgs e)
        {
            JMessageBox.Show(this, "Select save path.");
            using (var savePfb = new FolderBrowserDialog())
            {
                DialogResult resultx = savePfb.ShowDialog();
                if (resultx == DialogResult.OK && !string.IsNullOrWhiteSpace(savePfb.SelectedPath))
                {
                    string SavePath = savePfb.SelectedPath;
                    JMessageBox.Show(this, "Select perfect world server map path.");
                    using (var fbd = new FolderBrowserDialog())
                    {
                        DialogResult result = fbd.ShowDialog();
                        if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                        {
                            var myFiles = Directory.GetFiles(fbd.SelectedPath, "precinct.clt", SearchOption.AllDirectories);
                            foreach (string path in myFiles)
                            {
                                PretinctFile Region = new PretinctFile();
                                if (Region.ReadFile(path))
                                {
                                    string fileName = Path.GetFileName(path);
                                    string dirName = new DirectoryInfo(Path.GetDirectoryName(path)).Name;
                                    string savePath = Path.Combine(SavePath, dirName + "\\" + fileName);
                                    Region.SaveFile(savePath, false);
                                }
                            }
                        }
                    }
                }
            }
            JMessageBox.Show(this, "All saved.");
        }
    }
}
