using ElementEditor;
using JHUI.Forms;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace sTASKedit
{
	public partial class SelectRelayStationIdWindow: JForm
    {
        private TaskEditor MainWindow;
        public SelectRelayStationIdWindow(TaskEditor MainWindow)
		{
            InitializeComponent();
            this.MainWindow = MainWindow;
            this.SetLocalization();

		}

        private void SelectRelayStationIdWindow_Load(object sender, EventArgs e)
        {
            this.dataGridView_RelayStations.Rows.Clear();
            string[] values = new string[]
			{
			    "0",
			    Extensions.GetLocalization(402)
			};
            this.dataGridView_RelayStations.Rows.Add(values);
            for (int num25 = 0; num25 < ElementsEditor.database.world_targets.Length - 1; num25 += 5)
            {
                try
                {
                    string[] strArray14 = new string[]
					{
						Convert.ToInt32(ElementsEditor.database.world_targets[num25 + 0]).ToString(),
                        ElementsEditor.database.world_targets[num25 + 1].ToString()
					};
                    this.dataGridView_RelayStations.Rows.Add(strArray14);
                    goto IL_701;
                }
                catch
                {
                    MessageBox.Show(Extensions.GetLocalization(465));
                    goto IL_701;
                }
            IL_701: ;
            }
            this.dataGridView_RelayStations.CurrentCell = this.dataGridView_RelayStations.Rows[MainWindow.SelectRelayStationIdWindow_SelectedItemIndex].Cells[0];
        }

        private void button_Ok_Click(object sender, EventArgs e)
        {
            MainWindow.ChangeRelayStationId(Convert.ToInt32(this.dataGridView_RelayStations.CurrentRow.Cells[0].Value));
            this.Close();
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SelectRelayStationIdWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainWindow.SelectRelayStationIdWindow_SelectedItemIndex = this.dataGridView_RelayStations.CurrentCell.RowIndex;
        }

        private void SelectRelayStationIdWindow_SizeChanged(object sender, EventArgs e)
        {
          //  if (this.WindowState != FormWindowState.Maximized) MainWindow.lSelectRelayStationIdWindow_Size = this.Size;
        }

        public void SetLocalization()
        {
            Text = Extensions.GetLocalization(6030);
            Column_RelayStationId.HeaderText = Extensions.GetLocalization(6031);
            Column_RelayStationName.HeaderText = Extensions.GetLocalization(6032);
            button_Ok.Text = Extensions.GetLocalization(6033);
            button_Cancel.Text = Extensions.GetLocalization(6034);
        }
	}
}
