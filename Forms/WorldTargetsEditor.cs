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
using PWDataEditorPaied.Forms.SubForms;

namespace ElementEditor
{
    public partial class WorldTargetsEditor : JForm
    {
        internal bool isAutoOpen;
        internal string autoOpenPath;

        public bool Loaded { get; private set; }

        private bool locked;
        private WorldMap mapView;
        private int last_index;

        internal WorldTargetsFile Read { get; set; }

        internal delegate void UpdateProgressDelegate(String value, int min, int max);
        internal event UpdateProgressDelegate progress_bar2;

        public WorldTargetsEditor()
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

        private void WorldTargetsEditor_Shown(object sender, EventArgs e)
        {
            if (isAutoOpen)
            {
                DoLoading();
            }
        }

        private void DoLoading()
        {
            if (isAutoOpen)
            {
                locked = true;
                Read = new WorldTargetsFile();
                if (Read.ReadTxtFile(autoOpenPath))
                {
                    try
                    {

                        RegionDataGrid.RowCount = Read.TeleportList.Count;

                        Loaded = true;
                        locked = false;
                        try
                        {
                            RegionDataGrid.Rows[0].Selected = true;
                            RegionDataGrid.CurrentCell = RegionDataGrid.Rows[0].Cells[0];
                            RegionDataGrid_SelectionChanged(RegionDataGrid, null);
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

        private void jPictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog load = new OpenFileDialog();
            load.Filter = "world_targets.txt (world_targets.txt)|*.txt|All Files (*.*)|*.*";
            if (load.ShowDialog() == System.Windows.Forms.DialogResult.OK && File.Exists(load.FileName))
            {
                autoOpenPath = load.FileName;
                isAutoOpen = true;

                Read = null;
                RegionDataGrid.RowCount = 0;
                DoLoading();
            }
        }

        private void RegionDataGrid_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            if (!Loaded)
                return;

            if (Read != null)
            {
                switch(e.ColumnIndex)
                {
                    case 0:
                        e.Value = Read.TeleportList[e.RowIndex].ID;
                        break;
                    case 1:
                        e.Value = Read.TeleportList[e.RowIndex].MapName;
                        break;
                    case 2:
                        e.Value = Read.TeleportList[e.RowIndex].MapId;
                        break;
                    case 3:
                        e.Value = Read.TeleportList[e.RowIndex].MapPoint.X;
                        break;
                    case 4:
                        e.Value = Read.TeleportList[e.RowIndex].MapPoint.Y;
                        break;
                    case 5:
                        e.Value = Read.TeleportList[e.RowIndex].MapPoint.Z;
                        break;
                    case 6:
                        e.Value = Read.TeleportList[e.RowIndex].GroupId;
                        break;
                }
            }
        }

        private void RegionDataGrid_SelectionChanged(object sender, EventArgs e)
        {
            if (Read != null && RegionDataGrid.CurrentCell != null)
            {
                last_index = RegionDataGrid.CurrentCell.RowIndex;
                if (mapView != null)
                    mapView.DrawPoligonWithSelectedPoint(0, new PointF[] { new PointF(Read.TeleportList[last_index].MapPoint.X, Read.TeleportList[last_index].MapPoint.Z), new PointF(Read.TeleportList[last_index].MapPoint.X, Read.TeleportList[last_index].MapPoint.Z) }, true);
            }
        }

        private void jPictureBox2_Click(object sender, EventArgs e)
        {
            if (Read != null)
            {
                if (Read.Save(autoOpenPath))
                {
                    JMessageBox.Show(this, "Region has been saved!");
                }
            }
        }

        private void RegionDataGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!Loaded)
                return;

            if (Read != null)
            {
                try
                {
                    switch (e.ColumnIndex)
                    {
                        case 0:
                            Read.TeleportList[e.RowIndex].ID = int.Parse(RegionDataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue.ToString().GetNumbers());
                            break;
                        case 1:
                            Read.TeleportList[e.RowIndex].MapName = RegionDataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue.ToString();
                            break;
                        case 2:
                            Read.TeleportList[e.RowIndex].MapId = int.Parse(RegionDataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue.ToString().GetNumbers());
                            break;
                        case 3:
                            Read.TeleportList[e.RowIndex].MapPoint.oX = RegionDataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue.ToString();
                            break;
                        case 4:
                            Read.TeleportList[e.RowIndex].MapPoint.oY = RegionDataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue.ToString();
                            break;
                        case 5:
                            Read.TeleportList[e.RowIndex].MapPoint.oZ = RegionDataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue.ToString();
                            break;
                        case 6:
                            Read.TeleportList[e.RowIndex].GroupId = int.Parse(RegionDataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue.ToString().GetNumbers());
                            break;
                    }
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

        private void MapViewMouseDown(float x, float y)
        {
            if (RegionDataGrid.CurrentCell != null && Read != null)
            {
                last_index = RegionDataGrid.CurrentCell.RowIndex;
                int itemid = RegionDataGrid.CurrentCell.RowIndex;

                Read.TeleportList[itemid].MapPoint.oX = x.ToString("F6");
                Read.TeleportList[itemid].MapPoint.oZ = y.ToString("F6");

                if (mapView != null)
                    mapView.DrawPoligonWithSelectedPoint(last_index, new PointF[] { new PointF(Read.TeleportList[last_index].MapPoint.X, Read.TeleportList[last_index].MapPoint.Z), new PointF(Read.TeleportList[last_index].MapPoint.X, Read.TeleportList[last_index].MapPoint.Z) }, false);

            }
        }

        private void WorldTargetsEditor_FormClosing(object sender, FormClosingEventArgs e)
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
    }
}
