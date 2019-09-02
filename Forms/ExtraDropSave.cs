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
using System.Xml.Linq;

namespace ElementEditor
{
    public partial class ExtraDropSave : JForm
    {
        internal bool isAutoOpen;
        internal string autoOpenPath;

        public bool Loaded { get; private set; }
        private bool locked;

        internal ExtraDrop Read { get; set; }

        internal delegate void UpdateProgressDelegate(String value, int min, int max);
        internal event UpdateProgressDelegate progress_bar2;

        public ExtraDropSave()
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
                Read = new ExtraDrop();
                if (Read.ReadFile(autoOpenPath))
                {
                    try
                    {

                        RegionDataGrid.RowCount = Read.drops.Count;

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
            load.Filter = "extra_drops (extra_drops.sev)|*.sev|All Files (*.*)|*.*";
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
                        e.Value = e.RowIndex;
                    break;
                    case 1:
                        e.Value = Read.drops[e.RowIndex].Name;
                        break;
                }
            }
        }

        private void RegionDataGrid_SelectionChanged(object sender, EventArgs e)
        {
            if (Read != null && RegionDataGrid.CurrentCell != null && !locked)
            {
                AffectedMonster.RowCount = 0;
                ItemsAndProbability.RowCount = 0;
                DropNumProbability.RowCount = 0;
                int itemId = RegionDataGrid.CurrentCell.RowIndex;
                AffectedMonster.RowCount = Read.drops[itemId].monstersId.Count();
                ItemsAndProbability.RowCount = Read.drops[itemId].DropItems.Count();
                DropNumProbability.RowCount = Read.drops[itemId].probs.Count();
            }
        }

        private void jPictureBox2_Click(object sender, EventArgs e)
        {
            if (Read != null)
            {
                if (Read.Save(autoOpenPath))
                {
                    JMessageBox.Show(this, "Extra Drops has been saved!");
                }
            }
        }

        private void RegionDataGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!Loaded || locked)
                return;

            if (Read != null)
            {
                try
                {
                    switch (e.ColumnIndex)
                    {
                        case 1:
                            Read.drops[e.RowIndex].Name.Name = RegionDataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue.ToString();
                            break;

                    }
                }
                catch { }
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

        private void AffectedMonster_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            try
            {
                if (Read != null && RegionDataGrid.CurrentCell != null && !locked)
                {
                    int itemId = RegionDataGrid.CurrentCell.RowIndex;
                    switch (e.ColumnIndex)
                    {
                        case 0:
                            e.Value = Read.drops[itemId].monstersId[e.RowIndex];
                            break;
                        case 1:
                            ElementsEditor elementsEditor = ElementsEditor.Instance;
                            if (elementsEditor != null && ElementsEditor.eLC != null)
                            {
                                int Id = Read.drops[itemId].monstersId[e.RowIndex];
                                if (ElementsEditor.eLC.MONSTERS.ContainsKey(Id))
                                {
                                    e.Value = ElementsEditor.eLC.MONSTERS[Id].name;
                                }
                                else
                                {
                                    e.Value = "Unknown Monster";
                                }
                            }
                            else
                            {
                                e.Value = "Please Load elements.data";
                            }
                            break;
                    }
                }
            }
            catch { }
        }

        private void AffectedMonster_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (Read != null && RegionDataGrid.CurrentCell != null && !locked)
                {
                    int itemId = RegionDataGrid.CurrentCell.RowIndex;
                    switch (e.ColumnIndex)
                    {
                        case 0:
                            Read.drops[itemId].monstersId[e.RowIndex] = int.Parse(AffectedMonster.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue.ToString().GetNumbers());
                            break;
                    }
                }
            }
            catch { }
        }

        private void ItemsAndProbability_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            if (Read != null && RegionDataGrid.CurrentCell != null && !locked)
            {
                int itemId = RegionDataGrid.CurrentCell.RowIndex;
                switch (e.ColumnIndex)
                {
                    case 0:
                        e.Value = Read.drops[itemId].DropItems[e.RowIndex].ID;
                        break;
                    case 1:
                        int Id = (int)Read.drops[itemId].DropItems[e.RowIndex].ID;
                        ElementsEditor elementsEditor = ElementsEditor.Instance;
                        if (elementsEditor != null && ElementsEditor.eLC != null)
                        {
                           
                            if (Id > 0 && ElementsEditor.eLC.ocupiedIds.ContainsKey(Id))
                            {
                                e.Value = ElementsEditor.eLC.ocupiedIds[Id].name;
                            }
                            else
                            {
                                if (Id == 0)
                                {
                                    e.Value = "Empty Slot";
                                }
                                else
                                {
                                    e.Value = "Unknown Item";
                                }
                            }
                        }
                        else
                        {
                            if (Id == 0)
                            {
                                e.Value = "Empty Slot";
                            }
                            else
                            {
                                e.Value = "Please Load elements.data";
                            }
                        }
                        break;
                    case 2:
                        e.Value = Read.drops[itemId].DropItems[e.RowIndex].probability.ToString("0.0###############");
                        break;
                }
            }
        }

        private void ItemsAndProbability_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (Read != null && RegionDataGrid.CurrentCell != null && !locked)
            {
                int itemId = RegionDataGrid.CurrentCell.RowIndex;
                switch (e.ColumnIndex)
                {
                    case 0:
                        Read.drops[itemId].DropItems[e.RowIndex].ID = uint.Parse(ItemsAndProbability.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue.ToString());
                        break;
                    case 1:
                        break;
                    case 2:
                        Read.drops[itemId].DropItems[e.RowIndex].probability = float.Parse(ItemsAndProbability.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue.ToString());
                        break;
                }
            }
        }

        private void DropNumProbability_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            //DropNumProbability
            if (Read != null && RegionDataGrid.CurrentCell != null && !locked)
            {
                int itemId = RegionDataGrid.CurrentCell.RowIndex;
                switch (e.ColumnIndex)
                {
                    case 0:
                        e.Value = "Drop_"+e.RowIndex;
                        break;
                    case 1:
                        e.Value = Read.drops[itemId].probs[e.RowIndex].ToString();
                        break;
                }
            }
        }

        private void DropNumProbability_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (Read != null && RegionDataGrid.CurrentCell != null && !locked)
            {
                int itemId = RegionDataGrid.CurrentCell.RowIndex;
                switch (e.ColumnIndex)
                {
                    case 0:
                        break;
                    case 1:
                        Read.drops[itemId].probs[e.RowIndex] = float.Parse(DropNumProbability.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue.ToString());
                        break;
                }
            }
        }

        private void addNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Read != null && RegionDataGrid.CurrentCell != null && !locked && AffectedMonster.CurrentCell != null)
            {
                int itemId = RegionDataGrid.CurrentCell.RowIndex;
                Read.drops[itemId].monstersId.Add(12222);
                AffectedMonster.RowCount = Read.drops[itemId].monstersId.Count();

                try
                {
                    int nRowIndex = AffectedMonster.Rows.Count - 1;
                    int nColumnIndex = 0;
                    AffectedMonster.Rows[nRowIndex].Selected = true;
                    AffectedMonster.Rows[nRowIndex].Cells[nColumnIndex].Selected = true;
                }
                catch { }

            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Read != null && RegionDataGrid.CurrentCell != null && !locked && AffectedMonster.CurrentCell != null)
            {
                int itemId = RegionDataGrid.CurrentCell.RowIndex;
                Read.drops[itemId].monstersId.RemoveAt(AffectedMonster.CurrentCell.RowIndex);
                AffectedMonster.RowCount = Read.drops[itemId].monstersId.Count();

                try
                {
                    int nRowIndex = AffectedMonster.Rows.Count - 1;
                    int nColumnIndex = 0;
                    AffectedMonster.Rows[nRowIndex].Selected = true;
                    AffectedMonster.Rows[nRowIndex].Cells[nColumnIndex].Selected = true;
                }
                catch { }

            }
        }
    }
}
