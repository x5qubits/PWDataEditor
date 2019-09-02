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
using PWDataEditorPaied.NewEditors;
using System.IO;
using System.Text.RegularExpressions;
using System.Drawing.Imaging;
using ElementEditor;
using PWDataEditorPaied.Utils;
using PWDataEditorPaied.Properties;
using JHUI.Utils;
using PWDataEditorPaied.Forms.SubForms;

namespace ElementEditor
{
    public partial class RegionEditor : JForm
    {
        internal bool isAutoOpen;
        internal string autoOpenPath;
        internal delegate void UpdateProgressDelegate(String value, int min, int max);
        internal event UpdateProgressDelegate progress_bar2;
        private RegionFile Read;
        private WorldMap mapView;
        private bool Loaded = false;
        private bool locked = false;

        public RegionEditor()
        {
            InitializeComponent();
        }

        public void SetStyle(JColorStyle style, JThemeStyle thme, int alpha)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    SetStyle(style, thme, alpha);
                }));
                return;
            }
            this.components.SetStyle(this, style, thme, alpha);
        }

        private void RegionEditor_Shown(object sender, EventArgs e)
        {
            if (isAutoOpen)
            {
                DoLoading();
            }
        }

        public void MapViewMouseDown(float x, float y)
        {
            if (RegionDataGrid.CurrentCell != null && ZonesDataGrid.CurrentCell != null)
            {
                last_index = ZonesDataGrid.CurrentCell.RowIndex;
                int itemid = RegionDataGrid.CurrentCell.RowIndex;
                int zoneId = ZonesDataGrid.CurrentCell.RowIndex;

                if (zoneId == 0 || zoneId == Read.regions[itemid].Zones.Count - 1)
                {
                    Read.regions[itemid].Zones[0].oX = x.ToString("F6");
                    Read.regions[itemid].Zones[0].oZ = y.ToString("F6");
                    Read.regions[itemid].Zones[points.Length - 1].oX = x.ToString("F6");
                    Read.regions[itemid].Zones[points.Length - 1].oZ = y.ToString("F6");
                }
                else
                {
                    Read.regions[itemid].Zones[zoneId].oX = x.ToString("F6");
                    Read.regions[itemid].Zones[zoneId].oZ = y.ToString("F6");
                }
                points = new PointF[Read.regions[itemid].ZoneCount];
                for (int i = 0; i < Read.regions[itemid].ZoneCount; i++)
                {
                    points[i] = new PointF(Read.regions[itemid].Zones[i].X, Read.regions[itemid].Zones[i].Z);
                }
                if(mapView != null)
                    mapView.DrawPoligonWithSelectedPoint(last_index, points, false);
            }
        }

        private void listBox_items_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            if (locked || !Loaded)
                return;

            if (Read != null)
            {
                int index = e.RowIndex;
                if (e.ColumnIndex == 0)
                {
                    e.Value = Read.regions[index].IdInstance;
                }
                if (e.ColumnIndex == 1)
                {
                    e.Value = Read.regions[index].name;
                }
                if (e.ColumnIndex == 2)
                {
                    e.Value = Read.regions[index].Strategy;
                }
            }
        }

        private void listBox_items_SelectionChanged(object sender, EventArgs e)
        {
            if (locked || !Loaded)
                return;

            if (Read != null && RegionDataGrid.CurrentCell != null)
            {
                int index = RegionDataGrid.CurrentCell.RowIndex;
                ZonesDataGrid.RowCount = Read.regions[RegionDataGrid.CurrentCell.RowIndex].ZoneCount;
                points = new PointF[Read.regions[index].ZoneCount];
                for (int i = 0; i < Read.regions[index].ZoneCount; i++)
                {
                    points[i] = new PointF(Read.regions[index].Zones[i].X, Read.regions[index].Zones[i].Z);
                }
                bool scroolto = sender != null;
                if (mapView != null)
                    mapView.DrawPoligonWithSelectedPoint(0, points, scroolto);
                if (!scroolto)
                { 
                    if (last_index != -1)
                    {
                        try
                        {
                            ZonesDataGrid.Rows[last_index].Selected = true;
                            ZonesDataGrid.CurrentCell = ZonesDataGrid.Rows[last_index].Cells[0];
                        }
                        catch { }
                    }
                    last_index = -1;
                }
            }
        }

        private void ZonesDatagrid_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            if (!Loaded)
                return;
            try
            {
                if (RegionDataGrid.CurrentCell != null)
                {
                    int itemid = RegionDataGrid.CurrentCell.RowIndex;
                    if (e.ColumnIndex == 0)
                    {
                        e.Value = Read.regions[itemid].Zones[e.RowIndex].oX;
                    }
                    if (e.ColumnIndex == 1)
                    {
                        e.Value = Read.regions[itemid].Zones[e.RowIndex].oY;
                    }
                    if (e.ColumnIndex == 2)
                    {
                        e.Value = Read.regions[itemid].Zones[e.RowIndex].oZ;
                    }
                }
            }
            catch { }
        }

        private void ZonesDatagrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!Loaded)
                return;

            if (RegionDataGrid.CurrentCell != null)
            {
                int itemid = RegionDataGrid.CurrentCell.RowIndex;
                if (e.ColumnIndex == 0)
                {
                    Read.regions[itemid].Zones[e.RowIndex].oX = ZonesDataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue.ToString();
                }
                if (e.ColumnIndex == 1)
                {
                    Read.regions[itemid].Zones[e.RowIndex].oY = ZonesDataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue.ToString();
                }
                if (e.ColumnIndex == 2)
                {
                    Read.regions[itemid].Zones[e.RowIndex].oZ = ZonesDataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue.ToString();
                }
            }
        }

        private int last_index = -1;
        private PointF[] points;

        private void JDataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (Loaded && points != null && points.Length > 0 && ZonesDataGrid.CurrentCell != null)
            {
                if (mapView != null)
                    mapView.DrawPoligonWithSelectedPoint(ZonesDataGrid.CurrentCell.RowIndex, points, sender != null);
            }
        }

        private void RegionLoadSave(object sender, EventArgs e)
        {
            OpenFileDialog load = new OpenFileDialog();
            load.Filter = "Region (region.clt)|*.clt|All Files (*.*)|*.*";
            if (load.ShowDialog() == System.Windows.Forms.DialogResult.OK && File.Exists(load.FileName))
            {
                autoOpenPath = load.FileName;
                isAutoOpen = true;

                Read = null;
                RegionDataGrid.RowCount = 0;
                ZonesDataGrid.RowCount = 0;
                DoLoading();
            }
        }

        private void DoLoading()
        {
            if (isAutoOpen)
            {
                locked = true;
                Read = new RegionFile();
                if (Read.ReadFile(autoOpenPath))
                {
                    try
                    {

                        jTextBox1.Text = Read.dwVersion.ToString();
                        jTextBox2.Text = Read.dwTimeStamp.ToString();
                        RegionDataGrid.RowCount = Read.regions.Count;
                        TransportBoxesDatagrid.RowCount = Read.teleports.Count;

                        Loaded = true;
                        locked = false;
                        try
                        {
                            RegionDataGrid.Rows[0].Selected = true;
                            RegionDataGrid.CurrentCell = RegionDataGrid.Rows[0].Cells[0];
                            listBox_items_SelectionChanged(RegionDataGrid, null);
                        }
                        catch { }
                    }
                    catch
                    {
                        return;
                    }
                }
                locked = false;
            }
        }

        private void TransportBoxes_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            if (!Loaded)
                return;

            if (Read != null)
            {
                int itemid = e.RowIndex;
                if (e.ColumnIndex == 0)
                {
                    e.Value = Read.teleports[itemid].m_iType;
                }
                if (e.ColumnIndex == 1)
                {
                    e.Value = Read.teleports[itemid].m_idSrcInst;
                }
                if (e.ColumnIndex == 2)
                {
                    e.Value = Read.teleports[itemid].m_idInst;
                }
                if (e.ColumnIndex == 3)
                {
                    e.Value = Read.teleports[itemid].m_iLevelLmt;
                }
                if (e.ColumnIndex == 4)
                {
                    e.Value = Read.teleports[itemid].tm_vPos.oX;
                }
                if (e.ColumnIndex == 5)
                {
                    e.Value = Read.teleports[itemid].tm_vPos.oY;
                }
                if (e.ColumnIndex == 6)
                {
                    e.Value = Read.teleports[itemid].tm_vPos.oZ;
                }
                if (e.ColumnIndex == 7)
                {
                    e.Value = Read.teleports[itemid].m_vExts.oX;
                }
                if (e.ColumnIndex == 8)
                {
                    e.Value = Read.teleports[itemid].m_vExts.oY;
                }
                if (e.ColumnIndex == 9)
                {
                    e.Value = Read.teleports[itemid].m_vExts.oZ;
                }
                if (e.ColumnIndex == 10)
                {
                    e.Value = Read.teleports[itemid].m_vTarge.oX;
                }
                if (e.ColumnIndex == 11)
                {
                    e.Value = Read.teleports[itemid].m_vTarge.oY;
                }
                if (e.ColumnIndex == 12)
                {
                    e.Value = Read.teleports[itemid].m_vTarge.oZ;
                }
            }
        }

        private void jPictureBox2_Click(object sender, EventArgs e)
        {
            if (Read != null)
            {
                if (Read.SaveFile(autoOpenPath))
                {
                    JMessageBox.Show(this, "Region has been saved!");
                }
            }
        }

        private void RegionDataGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (locked || !Loaded)
                return;

            locked = true;
            if (Read != null)
            {
                int index = e.RowIndex;
                if (e.ColumnIndex == 0)
                {
                    try
                    {
                        Read.regions[index].IdInstance = int.Parse(RegionDataGrid.Rows[index].Cells[e.ColumnIndex].EditedFormattedValue.ToString());
                    }
                    catch { }
                }
                if (e.ColumnIndex == 1)
                {
                    try
                    {
                        Read.regions[index].name = RegionDataGrid.Rows[index].Cells[e.ColumnIndex].EditedFormattedValue.ToString();
                    }
                    catch { }
                }
                if (e.ColumnIndex == 2)
                {
                    try
                    {
                        Read.regions[index].Strategy = int.Parse(RegionDataGrid.Rows[index].Cells[e.ColumnIndex].EditedFormattedValue.ToString());
                    }
                    catch { }
                }
            }
            locked = false;
        }

        private void RegionEditor_FormClosing(object sender, FormClosingEventArgs e)
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

        private void jPictureBox3_Click(object sender, EventArgs e)
        {
            if (Read != null)
            {
                jTextBox2.Text = (Time.timeStampMilisecond / 1000).ToString();
                Read.dwTimeStamp = Convert.ToInt32(jTextBox2.Text);
            }
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

        private void cloneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (locked || !Loaded)
                return;
            if (Read == null)
                return;
            if (RegionDataGrid.CurrentCell == null)
                return;
            try
            {
                int index = RegionDataGrid.CurrentCell.RowIndex;
                RegionStructure selected = Read.regions[index].clone();
                Read.regions.Add(selected);
                RegionDataGrid.RowCount = Read.regions.Count;
                RegionDataGrid.Refresh();
                
                RegionDataGrid.ClearSelection();//If you want
                int nRowIndex = RegionDataGrid.Rows.Count - 1;
                int nColumnIndex = 0;

                RegionDataGrid.Rows[nRowIndex].Selected = true;
                RegionDataGrid.Rows[nRowIndex].Cells[nColumnIndex].Selected = true;

            }
            catch { }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (locked || !Loaded)
                return;
            if (Read == null)
                return;
            if (RegionDataGrid.CurrentCell == null)
                return;
            try
            {
                int index = RegionDataGrid.CurrentCell.RowIndex;
                Read.regions.RemoveAt(index);
                RegionDataGrid.RowCount = Read.regions.Count;
                RegionDataGrid.Refresh();
                RegionDataGrid.ClearSelection();//If you want

                int nRowIndex = RegionDataGrid.Rows.Count - 1;
                int nColumnIndex = 0;

                RegionDataGrid.Rows[nRowIndex].Selected = true;
                RegionDataGrid.Rows[nRowIndex].Cells[nColumnIndex].Selected = true;
            }
            catch { }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (locked || !Loaded)
                return;
            if (Read == null)
                return;
            if (RegionDataGrid.CurrentCell == null && ZonesDataGrid.CurrentCell != null)
                return;
            try
            {
                int index = RegionDataGrid.CurrentCell.RowIndex;
                int zoneId = ZonesDataGrid.CurrentCell.RowIndex;

                Read.regions[index].Zones.Insert(1, new Vector3(Read.regions[index].Zones[zoneId].oX, Read.regions[index].Zones[zoneId].oY, Read.regions[index].Zones[zoneId].oZ));
                ZonesDataGrid.RowCount = Read.regions[index].Zones.Count;
                ZonesDataGrid.Refresh();
                listBox_items_SelectionChanged(null, null);
                ZonesDataGrid.ClearSelection();
                int nRowIndex = 1;
                int nColumnIndex = 0;
                ZonesDataGrid.Rows[nRowIndex].Selected = true;
                ZonesDataGrid.Rows[nRowIndex].Cells[nColumnIndex].Selected = true;
            }
            catch { }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (locked || !Loaded)
                return;
            if (Read == null)
                return;
            if (RegionDataGrid.CurrentCell == null && ZonesDataGrid.CurrentCell != null)
                return;
            try
            {
                int index = RegionDataGrid.CurrentCell.RowIndex;
                int zoneId = ZonesDataGrid.CurrentCell.RowIndex;
                if (zoneId == 0 || zoneId == Read.regions[index].Zones.Count - 1)
                {
                    JMessageBox.Show(this, "Can't Delete first and last point!");
                    return;
                }
                Read.regions[index].Zones.RemoveAt(zoneId);
                ZonesDataGrid.RowCount = Read.regions[index].Zones.Count;
                ZonesDataGrid.Refresh();
                listBox_items_SelectionChanged(null, null);
                ZonesDataGrid.ClearSelection();
                int nRowIndex = ZonesDataGrid.Rows.Count - 1;
                int nColumnIndex = 0;
                ZonesDataGrid.Rows[nRowIndex].Selected = true;
                ZonesDataGrid.Rows[nRowIndex].Cells[nColumnIndex].Selected = true;
            }
            catch { }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (locked || !Loaded)
                return;
            if (Read == null)
                return;
            if (RegionDataGrid.CurrentCell == null && TransportBoxesDatagrid.CurrentCell != null)
                return;
            try
            {
                int index = RegionDataGrid.CurrentCell.RowIndex;
                int zoneId = TransportBoxesDatagrid.CurrentCell.RowIndex;

                CELTransportBox transport = Read.teleports[zoneId].clone();
                Read.teleports.Add(transport);
                TransportBoxesDatagrid.RowCount = Read.teleports.Count;
                TransportBoxesDatagrid.Refresh();
                TransportBoxesDatagrid.ClearSelection();
                int nRowIndex = TransportBoxesDatagrid.Rows.Count - 1;
                int nColumnIndex = 0;
                TransportBoxesDatagrid.Rows[nRowIndex].Selected = true;
                TransportBoxesDatagrid.Rows[nRowIndex].Cells[nColumnIndex].Selected = true;
            }
            catch { }
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (locked || !Loaded)
                return;
            if (Read == null)
                return;
            if (RegionDataGrid.CurrentCell == null && TransportBoxesDatagrid.CurrentCell != null)
                return;
            try
            {
                int zoneId = TransportBoxesDatagrid.CurrentCell.RowIndex;
                Read.teleports.RemoveAt(zoneId);
                TransportBoxesDatagrid.RowCount = Read.teleports.Count;
                TransportBoxesDatagrid.Refresh();
                TransportBoxesDatagrid.ClearSelection();
                int nRowIndex = TransportBoxesDatagrid.Rows.Count - 1;
                int nColumnIndex = 0;
                TransportBoxesDatagrid.Rows[nRowIndex].Selected = true;
                TransportBoxesDatagrid.Rows[nRowIndex].Cells[nColumnIndex].Selected = true;
            }
            catch { }
        }

        private void TransportBoxesDatagrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!Loaded)
                return;

            if (Read != null)
            {
                try
                {
                    int itemid = e.RowIndex;
                    if (e.ColumnIndex == 0)
                    {
                        Read.teleports[itemid].m_iType = int.Parse(TransportBoxesDatagrid.Rows[itemid].Cells[e.ColumnIndex].EditedFormattedValue.ToString().GetNumbers());
                    }
                    if (e.ColumnIndex == 1)
                    {
                        Read.teleports[itemid].m_idSrcInst = int.Parse(TransportBoxesDatagrid.Rows[itemid].Cells[e.ColumnIndex].EditedFormattedValue.ToString().GetNumbers());
                    }
                    if (e.ColumnIndex == 2)
                    {
                        Read.teleports[itemid].m_idInst = int.Parse(TransportBoxesDatagrid.Rows[itemid].Cells[e.ColumnIndex].EditedFormattedValue.ToString().GetNumbers());
                    }
                    if (e.ColumnIndex == 3)
                    {
                        Read.teleports[itemid].m_iLevelLmt = int.Parse(TransportBoxesDatagrid.Rows[itemid].Cells[e.ColumnIndex].EditedFormattedValue.ToString().GetNumbers());
                    }
                    if (e.ColumnIndex == 4)
                    {
                        Read.teleports[itemid].tm_vPos.oX = TransportBoxesDatagrid.Rows[itemid].Cells[e.ColumnIndex].EditedFormattedValue.ToString();
                    }
                    if (e.ColumnIndex == 5)
                    {
                        Read.teleports[itemid].tm_vPos.oY = TransportBoxesDatagrid.Rows[itemid].Cells[e.ColumnIndex].EditedFormattedValue.ToString();
                    }
                    if (e.ColumnIndex == 6)
                    {
                        Read.teleports[itemid].tm_vPos.oZ = TransportBoxesDatagrid.Rows[itemid].Cells[e.ColumnIndex].EditedFormattedValue.ToString();
                    }
                    if (e.ColumnIndex == 7)
                    {
                        Read.teleports[itemid].m_vExts.oX = TransportBoxesDatagrid.Rows[itemid].Cells[e.ColumnIndex].EditedFormattedValue.ToString();
                    }
                    if (e.ColumnIndex == 8)
                    {
                        Read.teleports[itemid].m_vExts.oY = TransportBoxesDatagrid.Rows[itemid].Cells[e.ColumnIndex].EditedFormattedValue.ToString();
                    }
                    if (e.ColumnIndex == 9)
                    {
                        Read.teleports[itemid].m_vExts.oZ = TransportBoxesDatagrid.Rows[itemid].Cells[e.ColumnIndex].EditedFormattedValue.ToString();
                    }
                    if (e.ColumnIndex == 10)
                    {
                        Read.teleports[itemid].m_vTarge.oX = TransportBoxesDatagrid.Rows[itemid].Cells[e.ColumnIndex].EditedFormattedValue.ToString();
                    }
                    if (e.ColumnIndex == 11)
                    {
                        Read.teleports[itemid].m_vTarge.oY = TransportBoxesDatagrid.Rows[itemid].Cells[e.ColumnIndex].EditedFormattedValue.ToString();
                    }
                    if (e.ColumnIndex == 12)
                    {
                        Read.teleports[itemid].m_vTarge.oZ = TransportBoxesDatagrid.Rows[itemid].Cells[e.ColumnIndex].EditedFormattedValue.ToString();
                    }
                }
                catch { }
            }
        }

        private void TransportBoxesDatagrid_SelectionChanged(object sender, EventArgs e)
        {
            if (locked || !Loaded)
                return;

            if (Read != null && TransportBoxesDatagrid.CurrentCell != null)
            {
                int index = TransportBoxesDatagrid.CurrentCell.RowIndex;
                points = new PointF[2];

                points[0] = new PointF(Read.teleports[TransportBoxesDatagrid.CurrentCell.RowIndex].tm_vPos.X, Read.teleports[TransportBoxesDatagrid.CurrentCell.RowIndex].tm_vPos.Z);
                points[1] = new PointF(Read.teleports[TransportBoxesDatagrid.CurrentCell.RowIndex].tm_vPos.X, Read.teleports[TransportBoxesDatagrid.CurrentCell.RowIndex].tm_vPos.Z);
                bool scroolto = sender != null;
                if (mapView != null)
                    mapView.DrawPoligonWithSelectedPoint(0, points, scroolto);

            }
        }

        private void ConvertMapFolderToSev_Click(object sender, EventArgs e)
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
                            var myFiles = Directory.GetFiles(fbd.SelectedPath, "region.clt", SearchOption.AllDirectories);
                            foreach (string path in myFiles)
                            {
                                RegionFile Region = new RegionFile();
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
