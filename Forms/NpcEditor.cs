using ElementEditor;
using ElementEditor.classes;
using ElementEditor.Element_Editor_Classes;
using JHUI.Forms;
using PWnpcEditor.classes;
using sTASKedit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;
using JHUI;
using PWDataEditorPaied.Forms.SubForms;
using System.Linq;
using PWDataEditorPaied.Classes;

namespace PWnpcEditor
{
    public partial class NpcEditor : JForm
    {
        public int defWidth = 932;
        public int defHeight = 647;
        internal delegate void UpdateProgressDelegate(String value, int min, int max);
        internal event UpdateProgressDelegate progress_bar2;

        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);
        [DllImport("kernel32.dll")]
        public static extern bool ReadProcessMemory(int hProcess, int lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesRead);
        [DllImport("Kernel32.dll")]
        private static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, int nSize, int lpNumberOfBytesRead);


        const int PROCESS_ALL_ACCESS = (0x0010);

        public static NPCALL npcgen = null;
        public static Dictionary<int, ItemDupe> npcdb = new Dictionary<int, ItemDupe>();

        public Dictionary<int, String> imgDb = new Dictionary<int, string>();
        public Dictionary<int, int> imgDbj = new Dictionary<int, int>();
        private int selindex = -1;

        private int selindexofset = 0;

        public Dictionary<int, Offset> clientOffsets = new Dictionary<int, Offset>();

        private Boolean controlLock = false;
        private bool locked;
        public static string npgendatapath;


        public NpcEditor()
        {
            InitializeComponent();
            this.MinimizeBox = Program.SHOWMINIMIZEBUTTON;
            label1.Visible = version_label.Visible = jLabel2.Visible = pathLabel.Visible = jLabel1.Visible = jPictureBox2.Visible = false;
        }

        private SortedList<int, int> ids = new SortedList<int, int>();

        private void Load_Click(object sender, EventArgs e)
        {
            // Create an instance of the open file dialog box.
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            mobsNpcList.Enabled = false;
            tabControl1.Enabled = false;
            // Set filter options and filter index.
            openFileDialog1.Filter = "Data Files (.data)|*.data|All Files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;

            openFileDialog1.Multiselect = true;

            // Process input if the user clicked OK.
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                GC.Collect();
                npgendatapath = openFileDialog1.FileName;

                using (BinaryReader br = new BinaryReader(File.Open(npgendatapath, FileMode.Open)))
                {
                    selindex = -1;
                    try
                    {
                        npcgen = new NPCALL();

                        npcgen.version = br.ReadInt32();
                       // this.Text = "Npc Editor By Games Shark - npc version " + npcgen.version;
                        npcgen.creature_sets_count = br.ReadInt32();
                        npcgen.resource_sets_count = br.ReadInt32();
                        if (npcgen.version >= 10)
                        {
                            npcgen.dynamics_count = br.ReadInt32();
                            npcgen.triggers_count = br.ReadInt32();
                        }
                        else
                        {
                            npcgen.dynamics_count = 0;
                            npcgen.triggers_count = 0;
                        }
                        load_creatures(br);
                        load_resources(br);
                        load_dynamics(br);
                        load_triggers(br);
                        pathLabel.Text = npgendatapath;
                        version_label.Text = npcgen.version.ToString();
                        label1.Visible = version_label.Visible = jLabel2.Visible = pathLabel.Visible = jLabel1.Visible = jPictureBox2.Visible = true;
                    }
                    catch 
                    {
                    }
                }
            }
            mobsNpcList.Enabled = true;
            tabControl1.Enabled = true;
            mobsNpcList.PerformLayout();
            dataGridView_resources.PerformLayout();
            Dyntext_items.PerformLayout();
            dataGridView_triggers.PerformLayout();
            dataGridView_triggers.Refresh();
        }

        private void load_triggers(BinaryReader br)
        {
            dataGridView_triggers.Rows.Clear();
            dataGridView_triggers.Visible = false;
            npcgen.triggers = new SortedList<int, Trigger>(npcgen.triggers_count);
            for (int i = 0; i < npcgen.triggers_count; i++)
            {
                progress_bar("Loading triger data...", i, npcgen.triggers_count);
                npcgen.triggers[i] = new Trigger();
                npcgen.triggers[i].triger_id = br.ReadInt32();
                npcgen.triggers[i].gm_activateId = br.ReadInt32();
                npcgen.triggers[i].name = br.ReadBytes(128);
                npcgen.triggers[i].on_load = br.ReadBoolean();
                npcgen.triggers[i].unknown_4 = br.ReadInt32();
                npcgen.triggers[i].unknown_5 = br.ReadInt32();
                bool auStart = br.ReadBoolean();
                npcgen.triggers[i].auto_start = false;
                if (!auStart)
                {
                    npcgen.triggers[i].auto_start = true;
                }
                bool auStop = br.ReadBoolean();
                npcgen.triggers[i].auto_stop = false;
                if (!auStop)
                {
                    npcgen.triggers[i].auto_stop = true;
                }
                npcgen.triggers[i].year_1 = br.ReadInt32();
                npcgen.triggers[i].month_1 = br.ReadInt32();
                npcgen.triggers[i].week_day_1 = br.ReadInt32();
                npcgen.triggers[i].day_1 = br.ReadInt32();
                npcgen.triggers[i].hour_1 = br.ReadInt32();
                npcgen.triggers[i].minute_1 = br.ReadInt32();
                npcgen.triggers[i].year_2 = br.ReadInt32();
                npcgen.triggers[i].month_2 = br.ReadInt32();
                npcgen.triggers[i].week_day_2 = br.ReadInt32();
                npcgen.triggers[i].day_2 = br.ReadInt32();
                npcgen.triggers[i].hour_2 = br.ReadInt32();
                npcgen.triggers[i].minute_2 = br.ReadInt32();
                npcgen.triggers[i].duration = br.ReadInt32();

                Encoding enc = Encoding.GetEncoding("GBK");
                dataGridView_triggers.Rows.Add(
                    npcgen.triggers[i].triger_id.ToString(),
                    npcgen.triggers[i].gm_activateId.ToString(),
                    enc.GetString(npcgen.triggers[i].name),
                    Convert.ToBoolean(npcgen.triggers[i].on_load),
                    npcgen.triggers[i].unknown_4.ToString(),
                    npcgen.triggers[i].unknown_5.ToString(),
                    Convert.ToBoolean(npcgen.triggers[i].auto_start),
                    Convert.ToBoolean(npcgen.triggers[i].auto_stop),
                    npcgen.triggers[i].year_1.ToString(),
                    npcgen.triggers[i].month_1.ToString(),
                    Column42.Items[npcgen.triggers[i].week_day_1 + 1],
                    npcgen.triggers[i].day_1.ToString(),
                    npcgen.triggers[i].hour_1.ToString(),
                    npcgen.triggers[i].minute_1.ToString(),
                    npcgen.triggers[i].year_2.ToString(),
                    npcgen.triggers[i].month_2.ToString(),
                    Column43.Items[npcgen.triggers[i].week_day_2 + 1],
                    npcgen.triggers[i].day_2.ToString(),
                    npcgen.triggers[i].hour_2.ToString(),
                    npcgen.triggers[i].minute_2.ToString(),
                    npcgen.triggers[i].duration.ToString()
               );


                dataGridView_triggers.Rows[i].HeaderCell.Value = (dataGridView_triggers.Rows.Count - 1).ToString();
            }
            dataGridView_triggers.Visible = true;
            progress_bar("Ready", 0, 0);
        }

        private String dynName(int id)
        {
            String result;

            result = "NOT FOUND";

            try
            {
                if (imgDb.ContainsKey(id))
                {
                    result = (String)imgDb[id];
                }
            }
            catch (Exception) { }
            return result;
        }

        internal bool autoLoad(string nPath)
        {
            // Create an instance of the open file dialog box.
            GC.Collect();
            mobsNpcList.Enabled = false;
            tabControl1.Enabled = false;
            String path = nPath;
            npgendatapath = nPath;
            
            using (BinaryReader br = new BinaryReader(File.Open(path, FileMode.Open)))
                {
                    selindex = -1;
                    try
                    {
                        npcgen = new NPCALL();

                        npcgen.version = br.ReadInt32();
                       // this.Text = "Npc Editor By Games Shark - npc version " + npcgen.version;
                        npcgen.creature_sets_count = br.ReadInt32();
                        npcgen.resource_sets_count = br.ReadInt32();
                        if (npcgen.version >= 10)
                        {
                            npcgen.dynamics_count = br.ReadInt32();
                            npcgen.triggers_count = br.ReadInt32();
                        }
                        else
                        {
                            npcgen.dynamics_count = 0;
                            npcgen.triggers_count = 0;
                        }
                        load_creatures(br);
                        load_resources(br);
                        load_dynamics(br);
                        load_triggers(br);
                    }
                    catch
                    {

                    }
                }
            mobsNpcList.Enabled = true;
            tabControl1.Enabled = true;
            mobsNpcList.SelectedIndex = 0;
            mobsNpcList.PerformLayout();
            dataGridView_resources.PerformLayout();
            Dyntext_items.PerformLayout();
            dataGridView_triggers.PerformLayout();
            return true;
        }

        private void progress_bar(String value, int min, int max)
        {
            if (progress_bar2 != null)
            {
                progress_bar2(value, min, max);
            }
        }
        private void load_dynamics(BinaryReader br)
        {
            Dyntext_items.Items.Clear();
            npcgen.dynamics = new SortedList<int, Dynamic>();
            for (int i = 0; i < npcgen.dynamics_count; i++)
            {
                progress_bar("Reading dynamics data...", i, npcgen.dynamics_count);
                npcgen.dynamics[i] = new Dynamic();
                npcgen.dynamics[i].id = br.ReadInt32();
                npcgen.dynamics[i].spawn_x = br.ReadSingle();
                npcgen.dynamics[i].spawn_y = br.ReadSingle();
                npcgen.dynamics[i].spawn_z = br.ReadSingle();
                npcgen.dynamics[i].dx = br.ReadByte();
                npcgen.dynamics[i].dy = br.ReadByte();
                npcgen.dynamics[i].dz = br.ReadByte();
                npcgen.dynamics[i].trigger = br.ReadInt32();
                npcgen.dynamics[i].scale = br.ReadByte();

                Dyntext_items.Items.Add(npcgen.dynamics[i].id + "-" + dynName(npcgen.dynamics[i].id));
            }
            progress_bar("Ready", 0, 0);
        }

        private void load_resources(BinaryReader br)
        {
            dataGridView_resources.Rows.Clear();

            npcgen.resource_sets = new SortedList<int, ResourceSet>();
            for (int i = 0; i < npcgen.resource_sets_count; i++)
            {
                progress_bar("Reading data...", i, npcgen.resource_sets_count);
                npcgen.resource_sets[i] = new ResourceSet();
                npcgen.resource_sets[i].spawn_x = br.ReadSingle();
                npcgen.resource_sets[i].spawn_alt = br.ReadSingle();
                npcgen.resource_sets[i].spawn_z = br.ReadSingle();
                npcgen.resource_sets[i].spread_x = br.ReadSingle();
                npcgen.resource_sets[i].spread_z = br.ReadSingle();
                npcgen.resource_sets[i].resource_groups_count = br.ReadInt32();
                npcgen.resource_sets[i].unknown_1 = br.ReadBoolean();
                npcgen.resource_sets[i].unknown_2 = br.ReadBoolean();
                npcgen.resource_sets[i].unknown_3 = br.ReadBoolean();
                npcgen.resource_sets[i].unknown_4 = br.ReadInt32();
                if (npcgen.version >= 10)
                {
                    npcgen.resource_sets[i].unknown_5a = br.ReadByte();
                    npcgen.resource_sets[i].unknown_5b = br.ReadByte();
                    npcgen.resource_sets[i].unknown_5c = br.ReadByte();
                    npcgen.resource_sets[i].unknown_trigger = br.ReadInt32();
                    npcgen.resource_sets[i].unknown_6 = br.ReadByte();
                    npcgen.resource_sets[i].unknown_7 = br.ReadBoolean();
                    npcgen.resource_sets[i].unknown_8 = br.ReadBoolean();
                    npcgen.resource_sets[i].unknown_9 = br.ReadBoolean();
                }
                else
                {
                    npcgen.resource_sets[i].unknown_5a = 192;
                    npcgen.resource_sets[i].unknown_5b = 63;
                    npcgen.resource_sets[i].unknown_5c = 0;
                    npcgen.resource_sets[i].unknown_trigger = 0;
                    npcgen.resource_sets[i].unknown_6 = 0;
                    npcgen.resource_sets[i].unknown_7 = false;
                    npcgen.resource_sets[i].unknown_8 = false;
                    npcgen.resource_sets[i].unknown_9 = false;
                }
                npcgen.resource_sets[i].resource_groups = new Dictionary<int, ResourceGroup>();
                for (int n = 0; n < npcgen.resource_sets[i].resource_groups_count; n++)
                {
                    npcgen.resource_sets[i].resource_groups[n] = new ResourceGroup();
                    npcgen.resource_sets[i].resource_groups[n].unknown_1 = br.ReadInt32();
                    npcgen.resource_sets[i].resource_groups[n].id = br.ReadInt32();
                    npcgen.resource_sets[i].resource_groups[n].respawn = br.ReadInt32();
                    npcgen.resource_sets[i].resource_groups[n].amount = br.ReadInt32();
                    npcgen.resource_sets[i].resource_groups[n].unknown_2 = br.ReadInt32();
                }

                dataGridView_resources.Rows.Add(
                npcgen.resource_sets[i].resource_groups_count.ToString(),
                npcgen.resource_sets[i].spawn_x.ToString("F3"),
                npcgen.resource_sets[i].spawn_alt.ToString("F3"),
                npcgen.resource_sets[i].spawn_z.ToString("F3"),
                npcgen.resource_sets[i].spread_x.ToString("F3"),
                npcgen.resource_sets[i].spread_z.ToString("F3"),
                npcgen.resource_sets[i].unknown_1,
                npcgen.resource_sets[i].unknown_2,
                npcgen.resource_sets[i].unknown_3,
                npcgen.resource_sets[i].unknown_4.ToString(),
                npcgen.resource_sets[i].unknown_5a.ToString(),
                npcgen.resource_sets[i].unknown_5b.ToString(),
                npcgen.resource_sets[i].unknown_5c.ToString(),
                npcgen.resource_sets[i].unknown_trigger.ToString(),
                npcgen.resource_sets[i].unknown_6.ToString(),
                npcgen.resource_sets[i].unknown_7.ToString(),
                npcgen.resource_sets[i].unknown_8.ToString(),
                npcgen.resource_sets[i].unknown_9

                );

                if (npcgen.resource_sets[i].resource_groups_count > 0)
                {
                    dataGridView_resources.Rows[i].HeaderCell.Value = npcgen.resource_sets[i].resource_groups[0].id.ToString();
                    dataGridView_resources.RowHeadersWidth = 70;
                }
            }
            progress_bar("Ready", 0, 0);
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

        private void load_creatures(BinaryReader br)
        {

            ids = new SortedList<int, int>();
            mobsNpcList.Items.Clear();
            mobsNpcList.Visible = false;
            npcgen.creature_sets = new SortedList<int, CreatureSet>();
            for (int i = 0; i < npcgen.creature_sets_count; i++)
            {
                progress_bar("Loading mob data...", i, npcgen.creature_sets_count);
                npcgen.creature_sets[i] = new CreatureSet();
                npcgen.creature_sets[i].positionType = br.ReadInt32();
                npcgen.creature_sets[i].creature_groups_count = br.ReadInt32();
                npcgen.creature_sets[i].spawn_x = br.ReadSingle();
                npcgen.creature_sets[i].spawn_alt = br.ReadSingle();
                npcgen.creature_sets[i].spawn_z = br.ReadSingle();
                npcgen.creature_sets[i].rot_1 = br.ReadSingle();
                npcgen.creature_sets[i].rot_2 = br.ReadSingle();
                npcgen.creature_sets[i].rot_3 = br.ReadSingle();
                npcgen.creature_sets[i].spread_x = br.ReadSingle();
                npcgen.creature_sets[i].spread_alt = br.ReadSingle();
                npcgen.creature_sets[i].spread_z = br.ReadSingle();
                npcgen.creature_sets[i].monstertype = br.ReadInt32();
                npcgen.creature_sets[i].groupeType = br.ReadInt32();
                npcgen.creature_sets[i].unknown_9 = br.ReadBoolean();
                npcgen.creature_sets[i].unknown_10 = br.ReadBoolean();
                npcgen.creature_sets[i].unknown_11 = br.ReadBoolean();
                npcgen.creature_sets[i].GenId = br.ReadInt32();

                if (npcgen.version >= 10)
                {
                    npcgen.creature_sets[i].trigger = br.ReadInt32();
                    npcgen.creature_sets[i].LifeTime = br.ReadInt32();
                    npcgen.creature_sets[i].MaxNum = br.ReadInt32();
                }
                else
                {
                    npcgen.creature_sets[i].trigger = 0;
                    npcgen.creature_sets[i].LifeTime = 0;
                    npcgen.creature_sets[i].MaxNum = 0;
                }
                npcgen.creature_sets[i].creature_groups = new SortedList<int, CreatureGroup>();
                for (int n = 0; n < npcgen.creature_sets[i].creature_groups_count; n++)
                {
                    npcgen.creature_sets[i].creature_groups[n] = new CreatureGroup();
                    npcgen.creature_sets[i].creature_groups[n].id = br.ReadInt32();
                    ids[npcgen.creature_sets[i].creature_groups[n].id] = npcgen.creature_sets[i].creature_groups[n].id;
                    npcgen.creature_sets[i].creature_groups[n].amount = br.ReadInt32();
                    npcgen.creature_sets[i].creature_groups[n].respawn = br.ReadInt32();
                    npcgen.creature_sets[i].creature_groups[n].diedTimes = br.ReadInt32();
                    npcgen.creature_sets[i].creature_groups[n].aggressive = br.ReadInt32();
                    npcgen.creature_sets[i].creature_groups[n].faction = br.ReadInt32();
                    npcgen.creature_sets[i].creature_groups[n].unknown_5 = br.ReadInt32();
                    npcgen.creature_sets[i].creature_groups[n].unknown_6 = br.ReadInt32();
                    npcgen.creature_sets[i].creature_groups[n].unknown_7 = br.ReadInt32();
                    npcgen.creature_sets[i].creature_groups[n].unknown_8 = br.ReadInt32();
                    npcgen.creature_sets[i].creature_groups[n].defFaction = br.ReadBoolean();
                    npcgen.creature_sets[i].creature_groups[n].defFacHelp = br.ReadBoolean();
                    npcgen.creature_sets[i].creature_groups[n].defFacAccept = br.ReadBoolean();
                    npcgen.creature_sets[i].creature_groups[n].needHelp = br.ReadBoolean();
                    npcgen.creature_sets[i].creature_groups[n].unknown_13 = br.ReadInt32();
                    npcgen.creature_sets[i].creature_groups[n].pathID = br.ReadInt32();
                    npcgen.creature_sets[i].creature_groups[n].loopType = br.ReadInt32();
                    npcgen.creature_sets[i].creature_groups[n].sppedFlag = br.ReadInt32();
                    if (npcgen.version >= 11)
                    {
                        npcgen.creature_sets[i].creature_groups[n].delayTime = br.ReadInt32();
                    }
                    else
                    {
                        npcgen.creature_sets[i].creature_groups[n].delayTime = 0;
                    }

                }
                int id = 0;
                try
                {
                    id = npcgen.creature_sets[i].creature_groups[0].id;

                }
                catch (Exception) { }

                String name = "NOT FOUND";
                try
                {
                    if (NpcEditor.npcdb.ContainsKey(id))
                    {
                        name = NpcEditor.npcdb[id].name;
                    }

                }
                catch (Exception) { }

                mobsNpcList.Items.Add("" + id + "(" + npcgen.creature_sets[i].creature_groups_count.ToString() + ") -" + name);
            }
            mobsNpcList.Visible = true;
            progress_bar("Ready", 0, 0);
        }



        public double[] getPos(double pos_x, double pos_z, double pos_y)
        {
            double XA = pos_x + 4096.0;
            double YA = -pos_z + 5632.0;
            double x = XA / 10.0 - 9.6;
            double y = 1113.2 - (YA / 10.0);
            return new double[3] {x, y, Math.Round((double)(pos_y / 10)) };
        }

        private String textString = "";
        private void mobsNpcList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = mobsNpcList.SelectedIndex;
            if (i > -1 && i != selindex && !controlLock)
            {
                jTextBox1.Text = "";
                controlLock = true;
                int id = 0;
                try
                {
                    id = npcgen.creature_sets[i].creature_groups[0].id;

                }
                catch (Exception) { }

                mobnpc_id.Text = id.ToString();
                mobnpc_name.Text = npcName(id);

                mobnpc_type.SelectedIndex = npcgen.creature_sets[i].monstertype;
                mobnpc_positiontype.SelectedIndex = npcgen.creature_sets[i].positionType;

                mobnpc_x.Text = npcgen.creature_sets[i].spawn_x.ToString("F3");
                mobnpc_y.Text = npcgen.creature_sets[i].spawn_alt.ToString("F3");
                mobnpc_z.Text = npcgen.creature_sets[i].spawn_z.ToString("F3");

                if (mapView != null)
                {
                    mapView.DrawPoligonWithSelectedPoint(0, new PointF[] { new PointF(npcgen.creature_sets[i].spawn_x, npcgen.creature_sets[i].spawn_z), new PointF(npcgen.creature_sets[i].spawn_x, npcgen.creature_sets[i].spawn_z) }, true);
                }

                labelX.Text = getPos(npcgen.creature_sets[i].spawn_x, npcgen.creature_sets[i].spawn_z, npcgen.creature_sets[i].spawn_alt)[0].ToString("0");
                labelY.Text = getPos(npcgen.creature_sets[i].spawn_x, npcgen.creature_sets[i].spawn_z, npcgen.creature_sets[i].spawn_alt)[2].ToString("0");
                labelZ.Text = getPos(npcgen.creature_sets[i].spawn_x, npcgen.creature_sets[i].spawn_z, npcgen.creature_sets[i].spawn_alt)[1].ToString("0");

                textString = labelX.Text + "," + labelZ.Text + " (" + labelY.Text + ")";
                mobnpc_rx.Text = npcgen.creature_sets[i].rot_1.ToString("F3");
                mobnpc_ry.Text = npcgen.creature_sets[i].rot_2.ToString("F3");
                mobnpc_rz.Text = npcgen.creature_sets[i].rot_3.ToString("F3");

                mobnpc_ax.Text = npcgen.creature_sets[i].spread_x.ToString("F3");
                mobnpc_ay.Text = npcgen.creature_sets[i].spread_alt.ToString("F3");
                mobnpc_az.Text = npcgen.creature_sets[i].spread_z.ToString("F3");

                mobnpc_trig.Text = npcgen.creature_sets[i].trigger.ToString();

                mobnpc_gid.Text = npcgen.creature_sets[i].GenId.ToString();

                mobnpc_gt.Text = npcgen.creature_sets[i].groupeType.ToString();

                mobnpc_lt.Text = npcgen.creature_sets[i].LifeTime.ToString();

                mobnpc_maxNum.Text = npcgen.creature_sets[i].MaxNum.ToString();

                mobnpc_ingen.Checked = npcgen.creature_sets[i].unknown_9;

                mobnpc_autor.Checked = npcgen.creature_sets[i].unknown_10;

                mobnpc_validone.Checked = npcgen.creature_sets[i].unknown_11;
                grupeNpcMob.Rows.Clear();
                for (int x = 0; x < npcgen.creature_sets[i].creature_groups.Count; x++)
                {
                    grupeNpcMob.Rows.Add(
                            npcName(npcgen.creature_sets[i].creature_groups[x].id),
                            npcgen.creature_sets[i].creature_groups[x].id.ToString(),
                            npcgen.creature_sets[i].creature_groups[x].amount.ToString(),
                            npcgen.creature_sets[i].creature_groups[x].respawn.ToString(),
                            npcgen.creature_sets[i].creature_groups[x].diedTimes.ToString(),
                            npcgen.creature_sets[i].creature_groups[x].aggressive.ToString(),
                            npcgen.creature_sets[i].creature_groups[x].faction.ToString(),
                            npcgen.creature_sets[i].creature_groups[x].unknown_5.ToString(),
                            npcgen.creature_sets[i].creature_groups[x].unknown_6.ToString(),
                            npcgen.creature_sets[i].creature_groups[x].unknown_7.ToString(),
                            npcgen.creature_sets[i].creature_groups[x].unknown_8.ToString(),
                            npcgen.creature_sets[i].creature_groups[x].defFaction,
                            npcgen.creature_sets[i].creature_groups[x].defFacHelp,
                            npcgen.creature_sets[i].creature_groups[x].defFacAccept,
                            npcgen.creature_sets[i].creature_groups[x].needHelp,
                            npcgen.creature_sets[i].creature_groups[x].unknown_13.ToString(),
                            npcgen.creature_sets[i].creature_groups[x].pathID.ToString(),
                            npcgen.creature_sets[i].creature_groups[x].loopType.ToString(),
                            npcgen.creature_sets[i].creature_groups[x].sppedFlag.ToString(),
                            npcgen.creature_sets[i].creature_groups[x].delayTime.ToString()

                        );
                   // grupeNpcMob.Rows[x].HeaderCell.Value = npcName(npcgen.creature_sets[i].creature_groups[x].id);
                }
                selindex = i;
                controlLock = false;
            }
        }

        private String npcName(int id)
        {
            String result;

            result = "NOT FOUND";

            try
            {
                if (!Program.elementSeditorFirstLoad)
                {
                    result = NpcEditor.npcdb[id].name;
                }
            }
            catch (Exception) { }
            return result;
        }

        private void grupeNpcMob_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (npcgen != null && mobsNpcList.SelectedIndex >= 0 && grupeNpcMob.CurrentCell != null)
            {
                try
                {
                    int r = mobsNpcList.SelectedIndex;
                    int n = grupeNpcMob.CurrentCell.RowIndex;

                    switch (grupeNpcMob.CurrentCell.ColumnIndex)
                    {
                        case 1:
                            npcgen.creature_sets[r].creature_groups[n].id = Int32.Parse(grupeNpcMob.CurrentCell.Value.ToString());
                            if (n == 0)
                            {

                                String name = "NOT FOUND";
                                try
                                {
                                    
                                    if (!Program.elementSeditorFirstLoad)
                                    {
                                        name = NpcEditor.npcdb[Int32.Parse(grupeNpcMob.CurrentCell.Value.ToString())].name;
                                    }
                                }
                                catch (Exception) { }
                                mobsNpcList.Items[r] = "" + npcgen.creature_sets[r].creature_groups[n].id + "(" + npcgen.creature_sets[r].creature_groups_count.ToString() + ") -" + name;
                            }
                            grupeNpcMob.Rows[n].HeaderCell.Value = npcName(npcgen.creature_sets[r].creature_groups[n].id);
                            break;
                        case 2:
                            npcgen.creature_sets[r].creature_groups[n].amount = Int32.Parse(grupeNpcMob.CurrentCell.Value.ToString());
                            break;
                        case 3:
                            npcgen.creature_sets[r].creature_groups[n].respawn = Int32.Parse(grupeNpcMob.CurrentCell.Value.ToString());
                            break;
                        case 4:
                            npcgen.creature_sets[r].creature_groups[n].diedTimes = Int32.Parse(grupeNpcMob.CurrentCell.Value.ToString());
                            break;
                        case 5:
                            npcgen.creature_sets[r].creature_groups[n].aggressive = Int32.Parse(grupeNpcMob.CurrentCell.Value.ToString());
                            break;
                        case 6:
                            npcgen.creature_sets[r].creature_groups[n].faction = Int32.Parse(grupeNpcMob.CurrentCell.Value.ToString());
                            break;
                        case 7:
                            npcgen.creature_sets[r].creature_groups[n].unknown_5 = Int32.Parse(grupeNpcMob.CurrentCell.Value.ToString());
                            break;
                        case 8:
                            npcgen.creature_sets[r].creature_groups[n].unknown_6 = Int32.Parse(grupeNpcMob.CurrentCell.Value.ToString());
                            break;
                        case 9:
                            npcgen.creature_sets[r].creature_groups[n].unknown_7 = Int32.Parse(grupeNpcMob.CurrentCell.Value.ToString());
                            break;
                        case 10:
                            npcgen.creature_sets[r].creature_groups[n].unknown_8 = Int32.Parse(grupeNpcMob.CurrentCell.Value.ToString());
                            break;
                        case 11:
                            npcgen.creature_sets[r].creature_groups[n].defFaction = Convert.ToBoolean(grupeNpcMob.CurrentCell.Value);
                            break;
                        case 12:
                            npcgen.creature_sets[r].creature_groups[n].defFacHelp = Convert.ToBoolean(grupeNpcMob.CurrentCell.Value);
                            break;
                        case 13:
                            npcgen.creature_sets[r].creature_groups[n].defFacAccept = Convert.ToBoolean(grupeNpcMob.CurrentCell.Value);
                            break;
                        case 14:
                            npcgen.creature_sets[r].creature_groups[n].needHelp = Convert.ToBoolean(grupeNpcMob.CurrentCell.Value);
                            break;
                        case 15:
                            npcgen.creature_sets[r].creature_groups[n].unknown_13 = Int32.Parse(grupeNpcMob.CurrentCell.Value.ToString());
                            break;
                        case 16:
                            npcgen.creature_sets[r].creature_groups[n].pathID = Int32.Parse(grupeNpcMob.CurrentCell.Value.ToString());
                            break;
                        case 17:
                            npcgen.creature_sets[r].creature_groups[n].loopType = Int32.Parse(grupeNpcMob.CurrentCell.Value.ToString());
                            break;
                        case 18:
                            npcgen.creature_sets[r].creature_groups[n].sppedFlag = Int32.Parse(grupeNpcMob.CurrentCell.Value.ToString());
                            break;
                        case 19:
                            npcgen.creature_sets[r].creature_groups[n].delayTime = Int32.Parse(grupeNpcMob.CurrentCell.Value.ToString());
                            break;
                    }
                }
                catch (Exception ex)
                {
                    JMessageBox.Show(this, "FORMAT ERROR\nInput value must be in the correct format!\n" + ex.ToString());
                }
            }
        }

        private void mobnpc_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            npcgen.creature_sets[mobsNpcList.SelectedIndex].monstertype = mobnpc_type.SelectedIndex;
        }

        private void mobnpc_positiontype_SelectedIndexChanged(object sender, EventArgs e)
        {
            npcgen.creature_sets[mobsNpcList.SelectedIndex].positionType = mobnpc_positiontype.SelectedIndex;
        }

        private void mobnpc_x_TextChanged(object sender, EventArgs e)
        {
            try
            {
                npcgen.creature_sets[mobsNpcList.SelectedIndex].spawn_x = float.Parse(mobnpc_x.Text);
            }
            catch { }
        }

        private void mobnpc_y_TextChanged(object sender, EventArgs e)
        {
            try
            {
                npcgen.creature_sets[mobsNpcList.SelectedIndex].spawn_alt = float.Parse(mobnpc_y.Text);
            }
            catch { }
        }

        private void mobnpc_z_TextChanged(object sender, EventArgs e)
        {
            try
            {
                npcgen.creature_sets[mobsNpcList.SelectedIndex].spawn_z = float.Parse(mobnpc_z.Text);
            }
            catch { }
        }

        private void mobnpc_rx_TextChanged(object sender, EventArgs e)
        {
            try
            {
                npcgen.creature_sets[mobsNpcList.SelectedIndex].rot_1 = float.Parse(mobnpc_rx.Text);
            }
            catch { }
        }

        private void mobnpc_ry_TextChanged(object sender, EventArgs e)
        {
            try
            {
                npcgen.creature_sets[mobsNpcList.SelectedIndex].rot_2 = float.Parse(mobnpc_ry.Text);
            }
            catch { }
        }

        private void mobnpc_rz_TextChanged(object sender, EventArgs e)
        {
            try
            {
                npcgen.creature_sets[mobsNpcList.SelectedIndex].rot_3 = float.Parse(mobnpc_rz.Text);
            }
            catch { }
        }

        private void mobnpc_ax_TextChanged(object sender, EventArgs e)
        {
            try
            {
                npcgen.creature_sets[mobsNpcList.SelectedIndex].spread_x = float.Parse(mobnpc_ax.Text);
            }
            catch { }
        }

        private void mobnpc_ay_TextChanged(object sender, EventArgs e)
        {
            try
            {
                npcgen.creature_sets[mobsNpcList.SelectedIndex].spread_alt = float.Parse(mobnpc_ay.Text);
            }
            catch { }
        }

        private void mobnpc_az_TextChanged(object sender, EventArgs e)
        {
            try
            {
                npcgen.creature_sets[mobsNpcList.SelectedIndex].spread_z = float.Parse(mobnpc_az.Text);
            }
            catch { }
        }

        private void mobnpc_trig_TextChanged(object sender, EventArgs e)
        {
            npcgen.creature_sets[mobsNpcList.SelectedIndex].trigger = Int32.Parse(mobnpc_trig.Text);
        }

        private void mobnpc_gid_TextChanged(object sender, EventArgs e)
        {
            npcgen.creature_sets[mobsNpcList.SelectedIndex].GenId = Int32.Parse(mobnpc_gid.Text);
        }

        private void mobnpc_gt_TextChanged(object sender, EventArgs e)
        {
            npcgen.creature_sets[mobsNpcList.SelectedIndex].groupeType = Int32.Parse(mobnpc_gt.Text);
        }

        private void mobnpc_lt_TextChanged(object sender, EventArgs e)
        {
            npcgen.creature_sets[mobsNpcList.SelectedIndex].LifeTime = Int32.Parse(mobnpc_lt.Text);
        }

        private void mobnpc_maxNum_TextChanged(object sender, EventArgs e)
        {
            npcgen.creature_sets[mobsNpcList.SelectedIndex].MaxNum = Int32.Parse(mobnpc_maxNum.Text);
        }

        private void mobnpc_ingen_CheckedChanged(object sender, EventArgs e)
        {
            npcgen.creature_sets[mobsNpcList.SelectedIndex].unknown_9 = mobnpc_ingen.Checked;
        }

        private void mobnpc_autor_CheckedChanged(object sender, EventArgs e)
        {
            npcgen.creature_sets[mobsNpcList.SelectedIndex].unknown_10 = mobnpc_autor.Checked;
        }

        private void mobnpc_validone_CheckedChanged(object sender, EventArgs e)
        {
            npcgen.creature_sets[mobsNpcList.SelectedIndex].unknown_11 = mobnpc_validone.Checked;
        }

        private void dataGridView_resources_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView_resourceGroups.Rows.Clear();

            if (npcgen != null && e.RowIndex > -1)
            {
                for (int i = 0; i < npcgen.resource_sets[e.RowIndex].resource_groups_count; i++)
                {
                    dataGridView_resourceGroups.Rows.Add(
                    npcgen.resource_sets[e.RowIndex].resource_groups[i].unknown_1.ToString(),
                    npcgen.resource_sets[e.RowIndex].resource_groups[i].id.ToString(),
                    npcgen.resource_sets[e.RowIndex].resource_groups[i].respawn.ToString(),
                    npcgen.resource_sets[e.RowIndex].resource_groups[i].amount.ToString(),
                    npcgen.resource_sets[e.RowIndex].resource_groups[i].unknown_2.ToString()
                    );
                    String name = "NOT FOUND";
                    try
                    {
                        if (!Program.elementSeditorFirstLoad && npcgen.resource_sets[e.RowIndex].resource_groups_count > 0)
                        {
                            if (NpcEditor.npcdb.ContainsKey(Int32.Parse(npcgen.resource_sets[e.RowIndex].resource_groups[i].id.ToString())))
                            {
                                name = NpcEditor.npcdb[Int32.Parse(npcgen.resource_sets[e.RowIndex].resource_groups[i].id.ToString())].name;
                            }
                        }
                    }
                    catch (Exception) { }

                    dataGridView_resourceGroups.Rows[i].HeaderCell.Value = name;
                }

            }
        }

        private void dataGridView_resources_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (npcgen != null && dataGridView_resources.CurrentCell != null)
            {
                try
                {
                    int r = dataGridView_resources.CurrentCell.RowIndex;
                    switch (dataGridView_resources.CurrentCell.ColumnIndex)
                    {
                        case 1:
                            npcgen.resource_sets[r].spawn_x = float.Parse(dataGridView_resources.CurrentCell.Value.ToString());
                            break;
                        case 2:
                            npcgen.resource_sets[r].spawn_alt = float.Parse(dataGridView_resources.CurrentCell.Value.ToString());
                            break;
                        case 3:
                            npcgen.resource_sets[r].spawn_z = float.Parse(dataGridView_resources.CurrentCell.Value.ToString());
                            break;
                        case 4:
                            npcgen.resource_sets[r].spread_x = float.Parse(dataGridView_resources.CurrentCell.Value.ToString());
                            break;
                        case 5:
                            npcgen.resource_sets[r].spread_z = float.Parse(dataGridView_resources.CurrentCell.Value.ToString());
                            break;
                        case 6:
                            npcgen.resource_sets[r].unknown_1 = Convert.ToBoolean(dataGridView_resources.CurrentCell.Value);
                            break;
                        case 7:
                            npcgen.resource_sets[r].unknown_2 = Convert.ToBoolean(dataGridView_resources.CurrentCell.Value);
                            break;
                        case 8:
                            npcgen.resource_sets[r].unknown_3 = Convert.ToBoolean(dataGridView_resources.CurrentCell.Value);
                            break;
                        case 9:
                            npcgen.resource_sets[r].unknown_4 = Int32.Parse(dataGridView_resources.CurrentCell.Value.ToString());
                            break;
                        case 10:
                            npcgen.resource_sets[r].unknown_5a = Byte.Parse(dataGridView_resources.CurrentCell.Value.ToString());
                            break;
                        case 11:
                            npcgen.resource_sets[r].unknown_5b = Byte.Parse(dataGridView_resources.CurrentCell.Value.ToString());
                            break;
                        case 12:
                            npcgen.resource_sets[r].unknown_5c = Byte.Parse(dataGridView_resources.CurrentCell.Value.ToString());
                            break;
                        case 13:
                            npcgen.resource_sets[r].unknown_trigger = Int32.Parse(dataGridView_resources.CurrentCell.Value.ToString());
                            break;
                        case 14:
                            npcgen.resource_sets[r].unknown_6 = Byte.Parse(dataGridView_resources.CurrentCell.Value.ToString());
                            break;
                        case 15:
                            npcgen.resource_sets[r].unknown_7 = Convert.ToBoolean(dataGridView_resources.CurrentCell.Value);
                            break;
                        case 16:
                            npcgen.resource_sets[r].unknown_8 = Convert.ToBoolean(dataGridView_resources.CurrentCell.Value);
                            break;
                        case 17:
                            npcgen.resource_sets[r].unknown_9 = Convert.ToBoolean(dataGridView_resources.CurrentCell.Value);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    JMessageBox.Show(this, "FORMAT ERROR\nInput value must be in the correct format!\n" + ex.ToString());
                }
            }
        }

        private void dataGridView_triggers_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (npcgen != null)
            {
                progress_bar("Saving ...", 0, 0);
                try
                {
                    FileStream fs = new FileStream(npgendatapath, FileMode.Create, FileAccess.Write);
                    BinaryWriter bw = new BinaryWriter(fs);

                    if (npcgen.version < 11)
                    {
                        bw.Write((int)10);
                    }
                    else
                    {
                        bw.Write(npcgen.version);
                    }
                    bw.Write(npcgen.creature_sets_count);
                    bw.Write(npcgen.resource_sets_count);
                    bw.Write(npcgen.dynamics_count);
                    bw.Write(npcgen.triggers_count);

                    save_creatures(bw);
                    save_resources(bw);
                    save_dynamics(bw);
                    save_triggers(bw);

                    bw.Close();
                    fs.Close();


                }
                catch (Exception)
                {
                    JMessageBox.Show(this, "SAVING ERROR!");
                }
                JMessageBox.Show(this, "Saved.");
                progress_bar("Ready", 0, 0);
            }
        }

        private void save_triggers(BinaryWriter bw)
        {
            for (int i = 0; i < npcgen.triggers.Count; i++)
            {
                progress_bar("Saving Trigers data...", i, npcgen.triggers.Count);
                bw.Write(npcgen.triggers[i].triger_id);
                bw.Write(npcgen.triggers[i].gm_activateId);
                bw.Write(npcgen.triggers[i].name);
                bw.Write(npcgen.triggers[i].on_load);
                bw.Write(npcgen.triggers[i].unknown_4);
                bw.Write(npcgen.triggers[i].unknown_5);

                if (!npcgen.triggers[i].auto_start)
                {
                    bw.Write(true);
                }
                else
                {
                    bw.Write(false);
                }

                if (!npcgen.triggers[i].auto_stop)
                {
                    bw.Write(true);
                }
                else
                {
                    bw.Write(false);
                }

                bw.Write(npcgen.triggers[i].year_1);
                bw.Write(npcgen.triggers[i].month_1);
                bw.Write(npcgen.triggers[i].week_day_1);
                bw.Write(npcgen.triggers[i].day_1);
                bw.Write(npcgen.triggers[i].hour_1);
                bw.Write(npcgen.triggers[i].minute_1);
                bw.Write(npcgen.triggers[i].year_2);
                bw.Write(npcgen.triggers[i].month_2);
                bw.Write(npcgen.triggers[i].week_day_2);
                bw.Write(npcgen.triggers[i].day_2);
                bw.Write(npcgen.triggers[i].hour_2);
                bw.Write(npcgen.triggers[i].minute_2);
                bw.Write(npcgen.triggers[i].duration);
            }
        }

        private void save_dynamics(BinaryWriter bw)
        {
            for (int i = 0; i < npcgen.dynamics.Count; i++)
            {
                progress_bar("Saving Dynamic data...", i, npcgen.dynamics.Count);
                bw.Write(npcgen.dynamics[i].id);
                bw.Write(npcgen.dynamics[i].spawn_x);
                bw.Write(npcgen.dynamics[i].spawn_y);
                bw.Write(npcgen.dynamics[i].spawn_z);
                bw.Write(npcgen.dynamics[i].dx);
                bw.Write(npcgen.dynamics[i].dy);
                bw.Write(npcgen.dynamics[i].dz);
                bw.Write(npcgen.dynamics[i].trigger);
                bw.Write(npcgen.dynamics[i].scale);
            }
        }

        private void save_resources(BinaryWriter bw)
        {
            for (int i = 0; i < npcgen.resource_sets.Count; i++)
            {
                progress_bar("Saving Resources data...", i, npcgen.resource_sets.Count);
                bw.Write(npcgen.resource_sets[i].spawn_x);
                bw.Write(npcgen.resource_sets[i].spawn_alt);
                bw.Write(npcgen.resource_sets[i].spawn_z);
                bw.Write(npcgen.resource_sets[i].spread_x);
                bw.Write(npcgen.resource_sets[i].spread_z);
                bw.Write(npcgen.resource_sets[i].resource_groups_count);
                bw.Write(npcgen.resource_sets[i].unknown_1);
                bw.Write(npcgen.resource_sets[i].unknown_2);
                bw.Write(npcgen.resource_sets[i].unknown_3);
                bw.Write(npcgen.resource_sets[i].unknown_4);
                bw.Write(npcgen.resource_sets[i].unknown_5a);
                bw.Write(npcgen.resource_sets[i].unknown_5b);
                bw.Write(npcgen.resource_sets[i].unknown_5c);
                bw.Write(npcgen.resource_sets[i].unknown_trigger);
                bw.Write(npcgen.resource_sets[i].unknown_6);
                bw.Write(npcgen.resource_sets[i].unknown_7);
                bw.Write(npcgen.resource_sets[i].unknown_8);
                bw.Write(npcgen.resource_sets[i].unknown_9);
                for (int n = 0; n < npcgen.resource_sets[i].resource_groups.Count; n++)
                {
                    bw.Write(npcgen.resource_sets[i].resource_groups[n].unknown_1);
                    bw.Write(npcgen.resource_sets[i].resource_groups[n].id);
                    bw.Write(npcgen.resource_sets[i].resource_groups[n].respawn);
                    bw.Write(npcgen.resource_sets[i].resource_groups[n].amount);
                    bw.Write(npcgen.resource_sets[i].resource_groups[n].unknown_2);
                }
            }
        }

        private void save_creatures(BinaryWriter bw)
        {
            for (int i = 0; i < npcgen.creature_sets.Count; i++)
            {
                progress_bar("Saving mobs data...", i, npcgen.creature_sets.Count);
                bw.Write(npcgen.creature_sets[i].positionType);
                bw.Write(npcgen.creature_sets[i].creature_groups_count);
                bw.Write(npcgen.creature_sets[i].spawn_x);
                bw.Write(npcgen.creature_sets[i].spawn_alt);
                bw.Write(npcgen.creature_sets[i].spawn_z);
                bw.Write(npcgen.creature_sets[i].rot_1);
                bw.Write(npcgen.creature_sets[i].rot_2);
                bw.Write(npcgen.creature_sets[i].rot_3);
                bw.Write(npcgen.creature_sets[i].spread_x);
                bw.Write(npcgen.creature_sets[i].spread_alt);
                bw.Write(npcgen.creature_sets[i].spread_z);
                bw.Write(npcgen.creature_sets[i].monstertype);
                bw.Write(npcgen.creature_sets[i].groupeType);
                bw.Write(npcgen.creature_sets[i].unknown_9);
                bw.Write(npcgen.creature_sets[i].unknown_10);
                bw.Write(npcgen.creature_sets[i].unknown_11);
                bw.Write(npcgen.creature_sets[i].GenId);
                bw.Write(npcgen.creature_sets[i].trigger);
                bw.Write(npcgen.creature_sets[i].LifeTime);
                bw.Write(npcgen.creature_sets[i].MaxNum);
                for (int n = 0; n < npcgen.creature_sets[i].creature_groups.Count; n++)
                {
                    bw.Write(npcgen.creature_sets[i].creature_groups[n].id);
                    bw.Write(npcgen.creature_sets[i].creature_groups[n].amount);
                    bw.Write(npcgen.creature_sets[i].creature_groups[n].respawn);
                    bw.Write(npcgen.creature_sets[i].creature_groups[n].diedTimes);
                    bw.Write(npcgen.creature_sets[i].creature_groups[n].aggressive);
                    bw.Write(npcgen.creature_sets[i].creature_groups[n].faction);
                    bw.Write(npcgen.creature_sets[i].creature_groups[n].unknown_5);
                    bw.Write(npcgen.creature_sets[i].creature_groups[n].unknown_6);
                    bw.Write(npcgen.creature_sets[i].creature_groups[n].unknown_7);
                    bw.Write(npcgen.creature_sets[i].creature_groups[n].unknown_8);
                    bw.Write(npcgen.creature_sets[i].creature_groups[n].defFaction);
                    bw.Write(npcgen.creature_sets[i].creature_groups[n].defFacHelp);
                    bw.Write(npcgen.creature_sets[i].creature_groups[n].defFacAccept);
                    bw.Write(npcgen.creature_sets[i].creature_groups[n].needHelp);
                    bw.Write(npcgen.creature_sets[i].creature_groups[n].unknown_13);
                    bw.Write(npcgen.creature_sets[i].creature_groups[n].pathID);
                    bw.Write(npcgen.creature_sets[i].creature_groups[n].loopType);
                    bw.Write(npcgen.creature_sets[i].creature_groups[n].sppedFlag);
                    if (npcgen.version >= 11)
                    {
                        bw.Write(npcgen.creature_sets[i].creature_groups[n].delayTime);
                    }
                }
            }
        }

        private void dataGridView_resourceGroups_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (npcgen != null && dataGridView_resources.CurrentCell != null && dataGridView_resourceGroups.CurrentCell != null)
            {
                try
                {
                    int r = dataGridView_resources.CurrentCell.RowIndex;
                    int n = dataGridView_resourceGroups.CurrentCell.RowIndex;
                    switch (dataGridView_resourceGroups.CurrentCell.ColumnIndex)
                    {
                        case 0:
                            npcgen.resource_sets[r].resource_groups[n].unknown_1 = Int32.Parse(dataGridView_resourceGroups.CurrentCell.Value.ToString());
                            break;
                        case 1:
                            npcgen.resource_sets[r].resource_groups[n].id = Int32.Parse(dataGridView_resourceGroups.CurrentCell.Value.ToString());
                            if (n == 0)
                            {
                                dataGridView_resources.Rows[r].HeaderCell.Value = npcgen.resource_sets[r].resource_groups[0].id.ToString();
                            }
                            break;
                        case 2:
                            npcgen.resource_sets[r].resource_groups[n].respawn = Int32.Parse(dataGridView_resourceGroups.CurrentCell.Value.ToString());
                            break;
                        case 3:
                            npcgen.resource_sets[r].resource_groups[n].amount = Int32.Parse(dataGridView_resourceGroups.CurrentCell.Value.ToString());
                            break;
                        case 4:
                            npcgen.resource_sets[r].resource_groups[n].unknown_2 = Int32.Parse(dataGridView_resourceGroups.CurrentCell.Value.ToString());
                            break;
                    }
                }
                catch (Exception)
                {
                    JMessageBox.Show(this, "FORMAT ERROR\nInput value must be in the correct format!");
                }
            }
        }

        private void dataGridView_triggers_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (npcgen != null && dataGridView_triggers.CurrentCell != null)
            {
                try
                {
                    int r = dataGridView_triggers.CurrentCell.RowIndex;
                    switch (dataGridView_triggers.CurrentCell.ColumnIndex)
                    {
                        case 0:
                            npcgen.triggers[r].triger_id = Int32.Parse(dataGridView_triggers.CurrentCell.Value.ToString());
                            break;
                        case 1:
                            npcgen.triggers[r].gm_activateId = Int32.Parse(dataGridView_triggers.CurrentCell.Value.ToString());
                            break;
                        case 2:
                            npcgen.triggers[r].name = getBytesGBK(dataGridView_triggers.CurrentCell.Value.ToString());
                            break;
                        case 3:
                            npcgen.triggers[r].on_load = Boolean.Parse(dataGridView_triggers.CurrentCell.Value.ToString());
                            break;
                        case 4:
                            npcgen.triggers[r].unknown_4 = Int32.Parse(dataGridView_triggers.CurrentCell.Value.ToString());
                            break;
                        case 5:
                            npcgen.triggers[r].unknown_5 = Int32.Parse(dataGridView_triggers.CurrentCell.Value.ToString());
                            break;
                        case 6:
                            npcgen.triggers[r].auto_start = Boolean.Parse(dataGridView_triggers.CurrentCell.Value.ToString());
                            break;
                        case 7:
                            npcgen.triggers[r].auto_stop = Boolean.Parse(dataGridView_triggers.CurrentCell.Value.ToString());
                            break;
                        case 8:
                            npcgen.triggers[r].year_1 = Int32.Parse(dataGridView_triggers.CurrentCell.Value.ToString());
                            break;
                        case 9:
                            npcgen.triggers[r].month_1 = Int32.Parse(dataGridView_triggers.CurrentCell.Value.ToString());
                            break;
                        case 10:
                            npcgen.triggers[r].week_day_1 = Column42.Items.IndexOf(dataGridView_triggers.CurrentCell.Value) - 1;
                            break;
                        case 11:
                            npcgen.triggers[r].day_1 = Int32.Parse(dataGridView_triggers.CurrentCell.Value.ToString());
                            break;
                        case 12:
                            npcgen.triggers[r].hour_1 = Int32.Parse(dataGridView_triggers.CurrentCell.Value.ToString());
                            break;
                        case 13:
                            npcgen.triggers[r].minute_1 = Int32.Parse(dataGridView_triggers.CurrentCell.Value.ToString());
                            break;
                        case 14:
                            npcgen.triggers[r].year_2 = Int32.Parse(dataGridView_triggers.CurrentCell.Value.ToString());
                            break;
                        case 15:
                            npcgen.triggers[r].month_2 = Int32.Parse(dataGridView_triggers.CurrentCell.Value.ToString());
                            break;
                        case 16:
                            npcgen.triggers[r].week_day_2 = Column43.Items.IndexOf(dataGridView_triggers.CurrentCell.Value) - 1;
                            break;
                        case 17:
                            npcgen.triggers[r].day_2 = Int32.Parse(dataGridView_triggers.CurrentCell.Value.ToString());
                            break;
                        case 18:
                            npcgen.triggers[r].hour_2 = Int32.Parse(dataGridView_triggers.CurrentCell.Value.ToString());
                            break;
                        case 19:
                            npcgen.triggers[r].minute_2 = Int32.Parse(dataGridView_triggers.CurrentCell.Value.ToString());
                            break;
                        case 20:
                            npcgen.triggers[r].duration = Int32.Parse(dataGridView_triggers.CurrentCell.Value.ToString());
                            break;
                    }
                }
                catch (Exception)
                {
                    JMessageBox.Show(this, "FORMAT ERROR\nInput value must be in the correct format!");
                }
            }
        }

        private byte[] getBytesGBK(string v)
        {
            Encoding enc = Encoding.GetEncoding("GBK");
            byte[] target = new byte[128];
            byte[] source = enc.GetBytes(v);
            if (target.Length > source.Length)
            {
                Array.Copy(source, target, source.Length);
            }
            else
            {
                Array.Copy(source, target, target.Length);
            }
            return target;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mobsNpcList.SelectedIndex == -1)
            {
                return;
            }
            int index = mobsNpcList.Items.Count - 1;
            CreatureSet cs = new CreatureSet();
            cs.creature_groups = new SortedList<int, CreatureGroup>();
            cs.creature_groups[0] = new CreatureGroup();
            npcgen.creature_sets.Add(Int32.MaxValue, cs);
            mobsNpcList.Items.Add("New");
            npcgen.creature_sets = resortDic(npcgen.creature_sets);
            npcgen.creature_sets_count = npcgen.creature_sets.Count;
            mobsNpcList.ClearSelected();
            mobsNpcList.SelectedIndex = mobsNpcList.Items.Count - 1;
            mobsNpcList_SelectedIndexChanged(null, null);
        }

        private void deleteSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mobsNpcList.SelectedIndex == -1)
            {
                progress_bar("Please select a npc", 0, 0);
                return;
            }
            controlLock = true;
            if (mobsNpcList.SelectedIndex != -1)
            {
                ListBox.SelectedIndexCollection selected = mobsNpcList.SelectedIndices;
                for (int x = 0; x < mobsNpcList.SelectedIndices.Count; x++)
                {
                    System.Windows.Forms.Application.DoEvents();
                    progress_bar("Deleting ...", x, mobsNpcList.SelectedIndices.Count);
                    int idx = mobsNpcList.SelectedIndices[x];
                    npcgen.creature_sets.Remove(idx);
                }
                
                npcgen.creature_sets = resortDic(npcgen.creature_sets);
                npcgen.creature_sets_count = npcgen.creature_sets.Count;
                for (int i = selected.Count - 1; i >= 0; i--)
                {
                    mobsNpcList.Items.RemoveAt(selected[i]);
                }

            }
            
            
            controlLock = false;
            progress_bar("Ready", 0, 0);
        }

        private SortedList<int, CreatureSet> resortDic(SortedList<int, CreatureSet> data)
        {
            SortedList<int, CreatureSet> datanew = new SortedList<int, CreatureSet>();
            npcgen.creature_sets = new SortedList<int, CreatureSet>();
            int i = 0;
            foreach (KeyValuePair<int, CreatureSet> entry in data)
            {
                datanew[i] = entry.Value;
                i++;
            }
            return datanew;
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mobsNpcList.SelectedIndex == -1)
            {
                progress_bar("Please select an element!", 0, 0);
                return;
            }
            int index = mobsNpcList.SelectedIndex;
            npcgen.creature_sets[index].creature_groups[npcgen.creature_sets[index].creature_groups.Count] = new CreatureGroup();
            npcgen.creature_sets[index].creature_groups_count++;
            mobsNpcList.Items[index] = "" + npcgen.creature_sets[index].creature_groups[0].id + "(" + npcgen.creature_sets[index].creature_groups_count.ToString() + ") -" + npcName(npcgen.creature_sets[index].creature_groups[0].id);
            selindex = -1;
            mobsNpcList_SelectedIndexChanged(null, null);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mobsNpcList.SelectedIndex == -1)
            {
                progress_bar("Please select an element!", 0, 0);
                return;
            }
            int index = mobsNpcList.SelectedIndex;
            int rowIndex = grupeNpcMob.CurrentCell.RowIndex;
            if(index > -1 && rowIndex > -1)
            {

                DataGridViewSelectedRowCollection selected = grupeNpcMob.SelectedRows;
                for (int x = 0; x < grupeNpcMob.SelectedRows.Count; x++)
                {
                    
                    Application.DoEvents();
                    progress_bar("Deleting ...", x, grupeNpcMob.SelectedRows.Count);
                    int idx = grupeNpcMob.SelectedRows[x].Index;
                    npcgen.creature_sets[index].creature_groups.Remove(idx);
                }
                npcgen.creature_sets[index].creature_groups = resortDicg(npcgen.creature_sets[index].creature_groups);
                npcgen.creature_sets[index].creature_groups_count = npcgen.creature_sets[index].creature_groups.Count;
                if (npcgen.creature_sets[index].creature_groups.Count > 0)
                {
                    mobsNpcList.Items[index] = "" + npcgen.creature_sets[index].creature_groups[0].id + "(" + npcgen.creature_sets[index].creature_groups_count.ToString() + ") -" + npcName(npcgen.creature_sets[index].creature_groups[0].id);
                }
                else
                {
                    mobsNpcList.Items[index] = "0(" + npcgen.creature_sets[index].creature_groups_count.ToString() + ") -" + npcName(0);
                }
                selindex = -1;

                mobsNpcList_SelectedIndexChanged(null, null);
            }
            progress_bar("Ready", 0, 0);
        }

        private SortedList<int, CreatureGroup> resortDicg(SortedList<int, CreatureGroup> data)
        {
            SortedList<int, CreatureGroup> datanew = new SortedList<int, CreatureGroup>();
            int i = 0;
            foreach (KeyValuePair<int, CreatureGroup> entry in data)
            {
                datanew[i] = entry.Value;
                i++;
            }
            return datanew;
        }

        private void exportSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(mobsNpcList.SelectedIndex == -1)
            {
                progress_bar("Please select items to export!", 0, 0);
                return;
            }
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "NPC Files (*.npc)|*.npc";
            save.FileName = npcgen.creature_sets[mobsNpcList.SelectedIndex].creature_groups[0].id + ".npc";
            if (npcgen != null && save.ShowDialog() == DialogResult.OK && save.FileName != "")
            {
                try
                {
                    controlLock = true;

                    if (mobsNpcList.SelectedIndex != -1)
                    {
                        List<CreatureSet> data = new List<CreatureSet>();
                        for (int i = 0; i < mobsNpcList.SelectedIndices.Count; i++)
                        {
                            progress_bar("Exporting ...", i, mobsNpcList.SelectedIndices.Count);
                            int index = mobsNpcList.SelectedIndices[i];

                            data.Add(npcgen.creature_sets[index]);

                        }
                        FileStream fs = new FileStream(save.FileName, FileMode.Create, FileAccess.Write);
                        BinaryFormatter bf = new BinaryFormatter();
                        bf.Serialize(fs, data);
                        fs.Close();
                    }

                    controlLock = false;
                }
                catch (Exception)
                {

                }
                progress_bar("Ready", 0, 0);
            }
        }

        private void importSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mobsNpcList.SelectedIndex == -1)
            {
                progress_bar("Please select items to import!", 0, 0);
                return;
            }
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            // Set filter options and filter index.
            openFileDialog1.Filter = "NPC Files (*.npc)|*.npc";
            openFileDialog1.FilterIndex = 1;

            openFileDialog1.Multiselect = true;

            // Process input if the user clicked OK.
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                String path = openFileDialog1.FileName;

                using (Stream file = File.Open(path, FileMode.Open))
                {

                    controlLock = true;
                    BinaryFormatter bf = new BinaryFormatter();
                    List<CreatureSet> obj = (List < CreatureSet > )bf.Deserialize(file);
                    for (int i = 0; i < obj.Count; i++)
                    {
                        progress_bar("Importing ...", i, obj.Count);
                        npcgen.creature_sets.Add(Int32.MaxValue, obj[i]);
                        npcgen.creature_sets = resortDic(npcgen.creature_sets);
                        npcgen.creature_sets_count = npcgen.creature_sets.Count;
                        try
                        {
                            mobsNpcList.Items.Add("" + obj[i].creature_groups[0].id + "(" + obj[i].creature_groups_count.ToString() + ") -" + npcName(obj[i].creature_groups[0].id));
                        }
                        catch (Exception)
                        {
                            mobsNpcList.Items.Add("0(0) - "+ npcName(0));
                        }
                    }

                    controlLock = false;
                    progress_bar("Ready", 0, 0);
                    file.Close();
                }

            }
        }



        private void addToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            int rowIndex = dataGridView_resources.CurrentCell.RowIndex;
            int index = dataGridView_resourceGroups.CurrentCell.RowIndex;
            if (rowIndex > -1 && index > -1)
            {
                npcgen.resource_sets[rowIndex].resource_groups_count++;
                npcgen.resource_sets[rowIndex].resource_groups[npcgen.resource_sets[rowIndex].resource_groups_count-1] = new ResourceGroup();
                dataGridView_resources.Rows[rowIndex].Cells[0].Value = npcgen.resource_sets[rowIndex].resource_groups_count+"";
                dataGridView_resourceGroups.Rows.Clear();
                for (int i = 0; i < npcgen.resource_sets[rowIndex].resource_groups_count; i++)
                {
                    dataGridView_resourceGroups.Rows.Add(
                        npcgen.resource_sets[rowIndex].resource_groups[i].unknown_1.ToString(),
                    npcgen.resource_sets[rowIndex].resource_groups[i].id.ToString(),
                    npcgen.resource_sets[rowIndex].resource_groups[i].respawn.ToString(),
                    npcgen.resource_sets[rowIndex].resource_groups[i].amount.ToString(),
                    npcgen.resource_sets[rowIndex].resource_groups[i].unknown_2.ToString()

                );
                }
            }
        }

        private Dictionary<int, ResourceGroup> resortdeleteToolStripMenuItem2_Click(Dictionary<int, ResourceGroup> data)
        {
            Dictionary<int, ResourceGroup> datanew = new Dictionary<int, ResourceGroup>();
            int i = 0;
            foreach (KeyValuePair<int, ResourceGroup> entry in data)
            {
                datanew[i] = entry.Value;
                i++;
            }
            return datanew;
        }

        private void deleteToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            int rowIndex = dataGridView_resources.CurrentCell.RowIndex;
            int index = dataGridView_resourceGroups.CurrentCell.RowIndex;
            if (rowIndex > -1 && index > -1)
            {
                npcgen.resource_sets[rowIndex].resource_groups_count--;
                npcgen.resource_sets[rowIndex].resource_groups.Remove(index);
                npcgen.resource_sets[rowIndex].resource_groups=resortdeleteToolStripMenuItem2_Click(npcgen.resource_sets[rowIndex].resource_groups);
                dataGridView_resourceGroups.Rows.Clear();
                for (int i = 0; i < npcgen.resource_sets[rowIndex].resource_groups_count; i++)
                {
                    progress_bar("Deleting ...", i, npcgen.resource_sets[rowIndex].resource_groups_count);
                    dataGridView_resourceGroups.Rows.Add(
                        npcgen.resource_sets[rowIndex].resource_groups[i].unknown_1.ToString(),
                    npcgen.resource_sets[rowIndex].resource_groups[i].id.ToString(),
                    npcgen.resource_sets[rowIndex].resource_groups[i].respawn.ToString(),
                    npcgen.resource_sets[rowIndex].resource_groups[i].amount.ToString(),
                    npcgen.resource_sets[rowIndex].resource_groups[i].unknown_2.ToString()

                );
                }
                    dataGridView_resources.Rows[rowIndex].Cells[0].Value = npcgen.resource_sets[rowIndex].resource_groups_count + "";
                progress_bar("Ready", 0, 0);
            }
        }

        private void addToolStripMenuItem1_Click(object sender, EventArgs e)
        {
                npcgen.resource_sets_count++;
                npcgen.resource_sets[npcgen.resource_sets_count - 1] = new ResourceSet();
                int i = npcgen.resource_sets_count - 1;
                npcgen.resource_sets[i].resource_groups = new Dictionary<int, ResourceGroup>();
                npcgen.resource_sets[i].resource_groups[0] = new ResourceGroup();

                dataGridView_resources.Rows.Add(
                npcgen.resource_sets[i].resource_groups_count.ToString(),
                npcgen.resource_sets[i].spawn_x.ToString("F3"),
                npcgen.resource_sets[i].spawn_alt.ToString("F3"),
                npcgen.resource_sets[i].spawn_z.ToString("F3"),
                npcgen.resource_sets[i].spread_x.ToString("F3"),
                npcgen.resource_sets[i].spread_z.ToString("F3"),
                npcgen.resource_sets[i].unknown_1,
                npcgen.resource_sets[i].unknown_2,
                npcgen.resource_sets[i].unknown_3,
                npcgen.resource_sets[i].unknown_4.ToString(),
                npcgen.resource_sets[i].unknown_5a.ToString(),
                npcgen.resource_sets[i].unknown_5b.ToString(),
                npcgen.resource_sets[i].unknown_5c.ToString(),
                npcgen.resource_sets[i].unknown_trigger.ToString(),
                npcgen.resource_sets[i].unknown_6.ToString(),
                npcgen.resource_sets[i].unknown_7.ToString(),
                npcgen.resource_sets[i].unknown_8.ToString(),
                npcgen.resource_sets[i].unknown_9
                );
                dataGridView_resources.Rows[i].HeaderCell.Value = npcgen.resource_sets[i].resource_groups[0].id.ToString();
                dataGridView_resources.RowHeadersWidth = 70;
                dataGridView_resources.Rows[i].Selected = true;
                dataGridView_resources.CurrentCell = dataGridView_resources.Rows[i].Cells[0];
                dataGridView_resources_CellClick(null, new DataGridViewCellEventArgs(i, i));

        }
        private SortedList<int, ResourceSet> resortResourceSet_Click(SortedList<int, ResourceSet> data)
        {
            SortedList<int, ResourceSet> datanew = new SortedList<int, ResourceSet>();
            int i = 0;
            foreach (KeyValuePair<int, ResourceSet> entry in data)
            {
                datanew[i] = entry.Value;
                i++;
            }
            return datanew;
        }

        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int rowIndex = dataGridView_resources.CurrentCell.RowIndex;

            if (rowIndex != -1)
            {

                DataGridViewSelectedRowCollection selected = dataGridView_resources.SelectedRows;
                for (int x = 0; x < dataGridView_resources.SelectedRows.Count; x++)
                {
                    System.Windows.Forms.Application.DoEvents();
                    progress_bar("Deleting ...", x, dataGridView_resources.SelectedRows.Count);
                    int idx = dataGridView_resources.SelectedRows[x].Index;
                    npcgen.resource_sets.Remove(idx);
                }

                npcgen.resource_sets = resortResourceSet_Click(npcgen.resource_sets);
                npcgen.resource_sets_count = npcgen.resource_sets.Count;
                for (int i = selected.Count - 1; i >= 0; i--)
                {
                    dataGridView_resources.Rows.Remove(selected[i]);
                }

                /*
                for (int i = dataGridView_resources.SelectedRows.Count - 1; i >= 0; i--)
                {
                    progress_bar("Deleting....", i, dataGridView_resources.SelectedRows.Count);
                    int index = dataGridView_resources.SelectedRows[i].Index;
                    npcgen.resource_sets.Remove(index);
                    npcgen.resource_sets_count = npcgen.resource_sets.Count;
                    dataGridView_resources.Rows.RemoveAt(index);
                    npcgen.resource_sets = resortResourceSet_Click(npcgen.resource_sets);

                }
                */
                progress_bar("Ready", 0, 0);
            }

        }

        private void exportSelectedToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int rowIndex = dataGridView_resources.CurrentCell.RowIndex;
            if (rowIndex == -1)
            {
                progress_bar("Please select an element!", 0, 0);
                return;
            }
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Resurces Files (*.res)|*.res";
            save.FileName = npcgen.resource_sets[rowIndex].resource_groups[0].id + ".res";
            if (npcgen != null && save.ShowDialog() == DialogResult.OK && save.FileName != "")
            {
                try
                {

                    if (rowIndex != -1)
                    {
                        List<ResourceSet> data = new List<ResourceSet>();
                        for (int i = 0; i < dataGridView_resources.SelectedRows.Count; i++)
                        {
                            progress_bar("Exporting ...", i, dataGridView_resources.SelectedRows.Count);
                            int index = dataGridView_resources.SelectedRows[i].Index;

                            data.Add(npcgen.resource_sets[index]);

                        }
                        FileStream fs = new FileStream(save.FileName, FileMode.Create, FileAccess.Write);
                        BinaryFormatter bf = new BinaryFormatter();
                        bf.Serialize(fs, data);
                        fs.Close();
                    }
                }
                catch (Exception)
                {

                }
                progress_bar("Ready", 0, 0);
            }
        }

        private void importSelectedToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int rowIndex = dataGridView_resources.CurrentCell.RowIndex;
            if (rowIndex == -1)
            {
                progress_bar("Please select an element!", 0, 0);
                return;
            }
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            // Set filter options and filter index.
            openFileDialog1.Filter = "Resurces Files (*.res)|*.res";
            openFileDialog1.FilterIndex = 1;

            openFileDialog1.Multiselect = true;

            // Process input if the user clicked OK.
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                String path = openFileDialog1.FileName;

                using (Stream file = File.Open(path, FileMode.Open))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    List<ResourceSet> obj = (List<ResourceSet>)bf.Deserialize(file);
                    int i = 0;
                    for (int x = 0; x < obj.Count; x++)
                    {
                        progress_bar("Importing ...", i, obj.Count);
                        int index = mobsNpcList.Items.Count;
                        npcgen.resource_sets_count++;
                        i = npcgen.resource_sets_count - 1;
                        npcgen.resource_sets[i] = obj[x];
                        
                        
                        dataGridView_resources.Rows.Add(
                        npcgen.resource_sets[i].resource_groups_count.ToString(),
                        npcgen.resource_sets[i].spawn_x.ToString("F3"),
                        npcgen.resource_sets[i].spawn_alt.ToString("F3"),
                        npcgen.resource_sets[i].spawn_z.ToString("F3"),
                        npcgen.resource_sets[i].spread_x.ToString("F3"),
                        npcgen.resource_sets[i].spread_z.ToString("F3"),
                        npcgen.resource_sets[i].unknown_1,
                        npcgen.resource_sets[i].unknown_2,
                        npcgen.resource_sets[i].unknown_3,
                        npcgen.resource_sets[i].unknown_4.ToString(),
                        npcgen.resource_sets[i].unknown_5a.ToString(),
                        npcgen.resource_sets[i].unknown_5b.ToString(),
                        npcgen.resource_sets[i].unknown_5c.ToString(),
                        npcgen.resource_sets[i].unknown_trigger.ToString(),
                        npcgen.resource_sets[i].unknown_6.ToString(),
                        npcgen.resource_sets[i].unknown_7.ToString(),
                        npcgen.resource_sets[i].unknown_8.ToString(),
                        npcgen.resource_sets[i].unknown_9
                        );
                        try
                        {
                            dataGridView_resources.Rows[i].HeaderCell.Value = npcgen.resource_sets[i].resource_groups[0].id.ToString();
                        }catch(Exception)
                        {
                            dataGridView_resources.Rows[i].HeaderCell.Value = "NOT FOUND";
                        }
                        dataGridView_resources.RowHeadersWidth = 70;
                    }
                    dataGridView_resources.Rows[i].Selected = true;
                    dataGridView_resources.CurrentCell = dataGridView_resources.Rows[i].Cells[0];
                }

                progress_bar("Ready", 0, 0);
            }
        }

        private void addToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            int rowIndex = dataGridView_triggers.CurrentCell.RowIndex;
            if (rowIndex > -1)
            {
                npcgen.triggers_count++;
                int i = npcgen.triggers_count - 1;
                npcgen.triggers[i] = new Trigger();
                Encoding enc = Encoding.GetEncoding("GBK");
                dataGridView_triggers.Rows.Add(
                    npcgen.triggers[i].triger_id.ToString(),
                    npcgen.triggers[i].gm_activateId.ToString(),
                    enc.GetString(npcgen.triggers[i].name),
                    Convert.ToBoolean(npcgen.triggers[i].on_load),
                    npcgen.triggers[i].unknown_4.ToString(),
                    npcgen.triggers[i].unknown_5.ToString(),
                    Convert.ToBoolean(npcgen.triggers[i].auto_start),
                    Convert.ToBoolean(npcgen.triggers[i].auto_stop),
                    npcgen.triggers[i].year_1.ToString(),
                    npcgen.triggers[i].month_1.ToString(),
                    Column42.Items[npcgen.triggers[i].week_day_1 + 1],
                    npcgen.triggers[i].day_1.ToString(),
                    npcgen.triggers[i].hour_1.ToString(),
                    npcgen.triggers[i].minute_1.ToString(),
                    npcgen.triggers[i].year_2.ToString(),
                    npcgen.triggers[i].month_2.ToString(),
                    Column43.Items[npcgen.triggers[i].week_day_2 + 1],
                    npcgen.triggers[i].day_2.ToString(),
                    npcgen.triggers[i].hour_2.ToString(),
                    npcgen.triggers[i].minute_2.ToString(),
                    npcgen.triggers[i].duration.ToString()
               );
                dataGridView_triggers.Rows[i].Selected = true;
                dataGridView_triggers.CurrentCell = dataGridView_triggers.Rows[i].Cells[0];
                dataGridView_triggers.Rows[i].HeaderCell.Value = (dataGridView_triggers.Rows.Count - 1).ToString();
            }
        }
        private SortedList<int, Trigger> resorttriggers_Click(SortedList<int, Trigger> data)
        {
            SortedList<int, Trigger> datanew = new SortedList<int, Trigger>();
            int i = 0;
            foreach (KeyValuePair<int, Trigger> entry in data)
            {
                datanew[i] = entry.Value;
                i++;
            }
            return datanew;
        }

        private void deleteSelectedToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            int rowIndex = dataGridView_triggers.CurrentCell.RowIndex;
            if (rowIndex != -1)
            {
                DataGridViewSelectedRowCollection selected = dataGridView_triggers.SelectedRows;
                for (int x = 0; x < dataGridView_triggers.SelectedRows.Count; x++)
                {
                    System.Windows.Forms.Application.DoEvents();
                    progress_bar("Deleting ...", x, dataGridView_triggers.SelectedRows.Count);
                    int idx = dataGridView_triggers.SelectedRows[x].Index;
                    npcgen.triggers.Remove(idx);
                }

                npcgen.triggers = resorttriggers_Click(npcgen.triggers);
                npcgen.triggers_count = npcgen.triggers.Count;
                for (int i = selected.Count - 1; i >= 0; i--)
                {
                    dataGridView_triggers.Rows.Remove(selected[i]);
                }
                progress_bar("Ready", 0, 0);
            }
        }

        private void exportSelectedToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            int rowIndex = dataGridView_triggers.CurrentCell.RowIndex;
            if (rowIndex == -1)
            {
                progress_bar("Please select an element!", 0, 0);
                return;
            }
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Trigers Files (*.trig)|*.trig";
            if (npcgen != null && save.ShowDialog() == DialogResult.OK && save.FileName != "")
            {
                try
                {

                    if (rowIndex != -1)
                    {
                        List<Trigger> data = new List<Trigger>();
                        for (int i = 0; i < dataGridView_triggers.SelectedRows.Count; i++)
                        {
                            progress_bar("Exporting ...", i, dataGridView_triggers.SelectedRows.Count);
                            int index = dataGridView_triggers.SelectedRows[i].Index;

                            data.Add(npcgen.triggers[index]);

                        }
                        FileStream fs = new FileStream(save.FileName, FileMode.Create, FileAccess.Write);
                        BinaryFormatter bf = new BinaryFormatter();
                        bf.Serialize(fs, data);
                        fs.Close();
                    }
                }
                catch (Exception)
                {

                }
                progress_bar("Ready", 0, 0);
            }
        }

        private void importSelectedToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            int rowIndex = dataGridView_resources.CurrentCell.RowIndex;
            if (rowIndex == -1)
            {
                progress_bar("Please select an element!", 0, 0);
                return;
            }
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            // Set filter options and filter index.
            openFileDialog1.Filter = "Triger Files (*.trig)|*.trig";
            openFileDialog1.FilterIndex = 1;

            openFileDialog1.Multiselect = true;

            // Process input if the user clicked OK.
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                String path = openFileDialog1.FileName;

                using (Stream file = File.Open(path, FileMode.Open))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    List<Trigger> obj = (List<Trigger>)bf.Deserialize(file);
                    int i = 0;
                    for (int x = 0; x < obj.Count; x++)
                    {
                        int index = mobsNpcList.Items.Count;
                        npcgen.triggers_count++;
                        i = npcgen.triggers_count - 1;
                        npcgen.triggers[i] = obj[x];
                        progress_bar("Importing ...", x, obj.Count);

                        Encoding enc = Encoding.GetEncoding("GBK");
                        dataGridView_triggers.Rows.Add(
                            npcgen.triggers[i].triger_id.ToString(),
                            npcgen.triggers[i].gm_activateId.ToString(),
                            enc.GetString(npcgen.triggers[i].name),
                            Convert.ToBoolean(npcgen.triggers[i].on_load),
                            npcgen.triggers[i].unknown_4.ToString(),
                            npcgen.triggers[i].unknown_5.ToString(),
                            Convert.ToBoolean(npcgen.triggers[i].auto_start),
                            Convert.ToBoolean(npcgen.triggers[i].auto_stop),
                            npcgen.triggers[i].year_1.ToString(),
                            npcgen.triggers[i].month_1.ToString(),
                            Column42.Items[npcgen.triggers[i].week_day_1 + 1],
                            npcgen.triggers[i].day_1.ToString(),
                            npcgen.triggers[i].hour_1.ToString(),
                            npcgen.triggers[i].minute_1.ToString(),
                            npcgen.triggers[i].year_2.ToString(),
                            npcgen.triggers[i].month_2.ToString(),
                            Column43.Items[npcgen.triggers[i].week_day_2 + 1],
                            npcgen.triggers[i].day_2.ToString(),
                            npcgen.triggers[i].hour_2.ToString(),
                            npcgen.triggers[i].minute_2.ToString(),
                            npcgen.triggers[i].duration.ToString()
                       );
                        dataGridView_triggers.Rows[i].HeaderCell.Value = (dataGridView_triggers.Rows.Count - 1).ToString();
                    }

                    dataGridView_triggers.Rows[i].Selected = true;
                    dataGridView_triggers.CurrentCell = dataGridView_triggers.Rows[i].Cells[0];
                    

                }
                progress_bar("Ready", 0, 0);
            }
        }

        private void Dyntext_items_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(locked) { return; }
            int i = Dyntext_items.SelectedIndex;
            if(i != -1)
            {

                Dyntext_id.Text = npcgen.dynamics[i].id.ToString();
                String name = dynName(npcgen.dynamics[i].id);
                if (!name.Equals("NOT FOUND"))
                {
                    try
                    {
                        Dyntext_name.SelectedIndex = imgDbj[npcgen.dynamics[i].id];
                    }catch(Exception)
                    {
                        Dyntext_name.SelectedIndex = 0;
                    }
                }else
                {
                    Dyntext_name.SelectedIndex = 0;

                }
                Dyntext_x.Text = npcgen.dynamics[i].spawn_x.ToString("F3");
                Dyntext_y.Text = npcgen.dynamics[i].spawn_y.ToString("F3");
                Dyntext_z.Text = npcgen.dynamics[i].spawn_z.ToString("F3");

                Dyntext_dx.Text = npcgen.dynamics[i].dx.ToString();
                Dyntext_dy.Text = npcgen.dynamics[i].dy.ToString();
                Dyntext_dz.Text = npcgen.dynamics[i].dz.ToString();

                Dyntext_trig.Text = npcgen.dynamics[i].trigger.ToString();

                Dyntext_scale.Text = npcgen.dynamics[i].scale.ToString();
               
                if (!name.Equals("NOT FOUND"))
                {
                    String path = Path.GetDirectoryName(Application.ExecutablePath) + "\\Configs\\Npc\\dynImg\\z" + npcgen.dynamics[i].id.ToString() + ".jpg";
                    Dyntext_image.BackgroundImage = Image.FromFile(path);
                    //Dyntext_image.Image = Image.FromFile(path);
                }else
                {
                    Dyntext_image.BackgroundImage = null;
                }
            }
        }

        private void Dyntext_id_TextChanged(object sender, EventArgs e)
        {
            int i = Dyntext_items.SelectedIndex;
            if (i != -1)
            {
                npcgen.dynamics[i].id = Int32.Parse(Dyntext_id.Text);
                String name = dynName(npcgen.dynamics[i].id);
                if (!name.Equals("NOT FOUND"))
                {
                    try
                    {
                        Dyntext_name.SelectedIndex = imgDbj[npcgen.dynamics[i].id];
                    }
                    catch (Exception)
                    {
                        Dyntext_name.SelectedIndex = 0;
                    }
                }
                else
                {
                    Dyntext_name.SelectedIndex = 0;

                }
                if (!name.Equals("NOT FOUND"))
                {
                    String path = Path.GetDirectoryName(Application.ExecutablePath) + "\\Configs\\Npc\\dynImg\\z" + npcgen.dynamics[i].id.ToString() + ".jpg";
                    Dyntext_image.BackgroundImage = Image.FromFile(path);
                    //Dyntext_image.Image = Image.FromFile(path);
                }
                else
                {
                    Dyntext_image.BackgroundImage = null;
                }
            }
        }
        private void Dyntext_trig_TextChanged(object sender, EventArgs e)
        {
            int i = Dyntext_items.SelectedIndex;
            if (i != -1)
            {
                npcgen.dynamics[i].trigger = Int32.Parse(Dyntext_trig.Text);
            }
        }

        private void Dyntext_x_TextChanged(object sender, EventArgs e)
        {
            int i = Dyntext_items.SelectedIndex;
            if (i != -1)
            {
                npcgen.dynamics[i].spawn_x = float.Parse(Dyntext_x.Text);
            }
        }

        private void Dyntext_y_TextChanged(object sender, EventArgs e)
        {
            int i = Dyntext_items.SelectedIndex;
            if (i != -1)
            {
                npcgen.dynamics[i].spawn_y = float.Parse(Dyntext_y.Text);
            }
        }

        private void Dyntext_z_TextChanged(object sender, EventArgs e)
        {
            int i = Dyntext_items.SelectedIndex;
            if (i != -1)
            {
                npcgen.dynamics[i].spawn_z = float.Parse(Dyntext_z.Text);
            }
        }

        private void Dyntext_dx_TextChanged(object sender, EventArgs e)
        {
            int i = Dyntext_items.SelectedIndex;
            if (i != -1)
            {
                npcgen.dynamics[i].dx = byte.Parse(Dyntext_dx.Text);
            }
        }

        private void Dyntext_dy_TextChanged(object sender, EventArgs e)
        {
            int i = Dyntext_items.SelectedIndex;
            if (i != -1)
            {
                npcgen.dynamics[i].dy = byte.Parse(Dyntext_dy.Text);
            }
        }

        private void Dyntext_dz_TextChanged(object sender, EventArgs e)
        {
            int i = Dyntext_items.SelectedIndex;
            if (i != -1)
            {
                npcgen.dynamics[i].dz = byte.Parse(Dyntext_dz.Text);
            }
        }

        private void Dyntext_scale_TextChanged(object sender, EventArgs e)
        {
            int i = Dyntext_items.SelectedIndex;
            if (i != -1)
            {
                npcgen.dynamics[i].scale = byte.Parse(Dyntext_scale.Text);
            }
        }

        private void addToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            npcgen.dynamics_count++;
            int i = npcgen.dynamics_count - 1;
            npcgen.dynamics[i] = new Dynamic();
            Dyntext_items.Items.Add(npcgen.dynamics[i].id + "-" + dynName(npcgen.dynamics[i].id));
        }

        private SortedList<int, Dynamic> resortdelToolStripMenuItem_Click(SortedList<int, Dynamic> data)
        {
            SortedList<int, Dynamic> datanew = new SortedList<int, Dynamic>();
            int i = 0;
            foreach (KeyValuePair<int, Dynamic> entry in data)
            {
                datanew[i] = entry.Value;
                i++;
            }
            return datanew;
        }

        private void delToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (Dyntext_items.SelectedIndex == -1)
            {
                progress_bar("Please select a item.", 0, 0);
                return;
            }

            if (Dyntext_items.SelectedIndex != -1)
            {
                locked = true;
                ListBox.SelectedIndexCollection selected = Dyntext_items.SelectedIndices;
                for (int x = 0; x < Dyntext_items.SelectedIndices.Count; x++)
                {
                    System.Windows.Forms.Application.DoEvents();
                    progress_bar("Deleting ...", x, Dyntext_items.SelectedIndices.Count);
                    int idx = Dyntext_items.SelectedIndices[x];
                    npcgen.dynamics.Remove(idx);
                }

                npcgen.dynamics = resortdelToolStripMenuItem_Click(npcgen.dynamics);
                npcgen.dynamics_count = npcgen.dynamics.Count;
                for (int i = selected.Count - 1; i >= 0; i--)
                {
                    Dyntext_items.Items.RemoveAt(selected[i]);
                }

            }
            locked = false;
            progress_bar("Ready", 0, 0);
        }

        private void Dyntext_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = Dyntext_items.SelectedIndex;
            int nameIndex = Dyntext_name.SelectedIndex;
            if (i != -1 && nameIndex >= 0)
            {
                String[] data = Dyntext_name.Items[nameIndex].ToString().Split('-');
                int id = Int32.Parse(data[0]);

                String name = dynName(id);
                if (!name.Equals("NOT FOUND"))
                {
                    try
                    {

                        npcgen.dynamics[i].id = id;
                        Dyntext_id.Text = id + "";
                        Dyntext_items.Items[i] = (npcgen.dynamics[i].id + "-" + dynName(npcgen.dynamics[i].id));

                        Dyntext_name.SelectedIndex = imgDbj[npcgen.dynamics[i].id];
                    }
                    catch (Exception)
                    {
                        Dyntext_name.SelectedIndex = 0;
                    }
                }
                else
                {
                    Dyntext_name.SelectedIndex = 0;

                }
            }

        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int rowIndex = Dyntext_items.SelectedIndex;
            if (rowIndex == -1)
            {
                return;
            }
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Dynamic Files (*.dyn)|*.dyn";
            if (npcgen != null && save.ShowDialog() == DialogResult.OK && save.FileName != "")
            {
                try
                {

                    if (rowIndex != -1)
                    {
                        List<Dynamic> data = new List<Dynamic>();
                        for (int i = Dyntext_items.SelectedIndices.Count - 1; i >= 0; i--)
                        {
                            int index = Dyntext_items.SelectedIndices[i];

                            data.Add(npcgen.dynamics[index]);

                        }
                        FileStream fs = new FileStream(save.FileName, FileMode.Create, FileAccess.Write);
                        BinaryFormatter bf = new BinaryFormatter();
                        bf.Serialize(fs, data);
                        fs.Close();
                    }
                }
                catch (Exception)
                {

                }
            }
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int rowIndex = Dyntext_items.SelectedIndex;
            if (rowIndex == -1)
            {
                return;
            }
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            // Set filter options and filter index.
            openFileDialog1.Filter = "Dynamic Files (*.dyn)|*.dyn";
            openFileDialog1.FilterIndex = 1;

            openFileDialog1.Multiselect = true;

            // Process input if the user clicked OK.
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                String path = openFileDialog1.FileName;

                using (Stream file = File.Open(path, FileMode.Open))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    List<Dynamic> obj = (List<Dynamic>)bf.Deserialize(file);
                    int i = 0;
                    for (int x = 0; x < obj.Count; x++)
                    {
                        npcgen.dynamics_count++;
                        i = npcgen.dynamics_count - 1;
                        npcgen.dynamics[i] = obj[x];
                        Dyntext_items.Items.Add(npcgen.dynamics[i].id + "-" + dynName(npcgen.dynamics[i].id));
                    }
                }
            }
        }
        private bool IsNumeric(string s)
        {
            float output;
            return float.TryParse(s, out output);
        }

        private int selected_index = 0;
        public bool isAutoOpen = false;
        public string autoOpenPath = "";

        private void btnAdd_Click(object sender, EventArgs e)
        {
            mobsNpcList.ClearSelected();
            if (jCheckBox1.Checked)
            {
                if (IsNumeric(searchInput1.Text))
                {
                    int search = Int32.Parse(searchInput1.Text);
                    for (int i = selected_index; i < npcgen.creature_sets_count; i++)
                    {
                        for (int x = 0; x < npcgen.creature_sets[i].creature_groups_count; x++)
                        {
                            if (npcgen.creature_sets[i].trigger == search)
                            {
                                mobsNpcList.SelectedIndex = i;
                                selected_index = i + 1;
                                if (!checkBox1.Checked)
                                {
                                    return;
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                    }
                }
                else
                {
                    JMessageBox.Show(this, "Input must be numeric.");
                }
            }
            else
            {

                if (IsNumeric(searchInput1.Text))
                {
                    int search = Int32.Parse(searchInput1.Text);
                    for (int i = selected_index; i < npcgen.creature_sets_count; i++)
                    {
                        for (int x = 0; x < npcgen.creature_sets[i].creature_groups_count; x++)
                        {
                            if (npcgen.creature_sets[i].creature_groups[x].id == search)
                            {
                                mobsNpcList.SelectedIndex = i;
                                selected_index = i + 1;
                                if (!checkBox1.Checked)
                                {
                                    return;
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                    }
                }
                else
                {
                    foreach (KeyValuePair<int, ItemDupe> entry in NpcEditor.npcdb)
                    {
                        String search = searchInput1.Text.ToLower();
                        if (entry.Value.name.ToLower().Equals(search))
                        {
                            int search2 = entry.Key;
                            for (int i = selected_index; i < npcgen.creature_sets_count; i++)
                            {
                                for (int x = 0; x < npcgen.creature_sets[i].creature_groups_count; x++)
                                {
                                    if (npcgen.creature_sets[i].creature_groups[x].id == search2)
                                    {
                                        mobsNpcList.SelectedIndex = i;
                                        selected_index = i + 1;
                                        if (!checkBox1.Checked)
                                        {
                                            return;
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                }
                            }
                        }

                    }
                }
            }
            selected_index = 0;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (IsNumeric(searchInput1.Text))
            {
                int search = Int32.Parse(searchInput1.Text);
                for (int i = 0; i < npcgen.resource_sets_count; i++)
                {
                    for (int x = 0; x < npcgen.resource_sets[i].resource_groups_count; x++)
                    {
                        if (npcgen.resource_sets[i].resource_groups[x].id == search)
                        {
                            dataGridView_resources.Rows[i].Selected = true;
                            dataGridView_resources.CurrentCell = dataGridView_resources.Rows[i].Cells[0];
                            break;
                        }
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (IsNumeric(searchInput1.Text))
            {
                Dyntext_items.SelectedIndex = -1;
                int search = Int32.Parse(searchInput1.Text);
                for (int i = 0; i < npcgen.dynamics_count; i++)
                {
 
                    if (npcgen.dynamics[i].id == search)
                    {
                        Dyntext_items.SelectedIndex = i;
                        break;
                    }
                }
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            //textBox4
            //dataGridView_triggers.Rows[i].Selected = true;
            //dataGridView_triggers.CurrentCell = dataGridView_triggers.Rows[i].Cells[0];
            //break;
            int r = dataGridView_triggers.CurrentCell.RowIndex + 1;
            if (IsNumeric(searchInput1.Text))
            {
                int searchh = Int32.Parse(searchInput1.Text);
                for (int i = r; i < npcgen.triggers_count; i++)
                {
                    if(npcgen.triggers[i].triger_id == searchh || npcgen.triggers[i].gm_activateId == searchh)
                    {
                        dataGridView_triggers.Rows[i].Selected = true;
                        dataGridView_triggers.CurrentCell = dataGridView_triggers.Rows[i].Cells[0];
                        break;
                    }
                }
            }
            else
            {
                String searchh = searchInput1.Text;
                Encoding enc = Encoding.GetEncoding("GBK");
                for (int i = r; i < npcgen.triggers_count; i++)
                {
                    if (enc.GetString(npcgen.triggers[i].name) == searchh)
                    {
                        dataGridView_triggers.Rows[i].Selected = true;
                        dataGridView_triggers.CurrentCell = dataGridView_triggers.Rows[i].Cells[0];
                        break;
                    }
                }        
            }
        }
        public int SelectedProcess = 0;
        public Process[] processes = null;
        private WorldMap mapView;

        public void GetProcessid()
        {
            jComboBox1.Items.Clear();
            processes = Process.GetProcessesByName("elementclient");
            for (int i = 0; i < processes.Length; i++)
            {
                jComboBox1.Items.Add(processes[i].MainWindowTitle);
            }

            try
            {
                jComboBox1.SelectedIndex = 0;
            }
            catch { }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selindexofset = comboBox1.SelectedIndex;
            comboBox1.SelectedIndex = selindexofset;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OFFSetResult offset = GetOffset();
            if (offset != null)
            {
                mobnpc_x.Text = offset.DirX.ToString("F3");
                mobnpc_y.Text = offset.DirY.ToString("F3");
                mobnpc_z.Text = offset.DirZ.ToString("F3");

                mobnpc_rx.Text = offset.RotX.ToString("F3");
                mobnpc_ry.Text = offset.RotY.ToString("F3");
                mobnpc_rz.Text = offset.RotZ.ToString("F3");
            }     
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OFFSetResult offset = GetOffset();
            int r = dataGridView_resources.CurrentCell.RowIndex;
            if (offset != null && r != -1)
            {
                dataGridView_resources.Rows[r].Cells[1].Value = offset.DirX.ToString("F3");
                dataGridView_resources.Rows[r].Cells[2].Value = offset.DirY.ToString("F3");
                dataGridView_resources.Rows[r].Cells[3].Value = offset.DirZ.ToString("F3");
                npcgen.resource_sets[r].spawn_x = float.Parse(offset.DirX.ToString("F3"));
                npcgen.resource_sets[r].spawn_z = float.Parse(offset.DirZ.ToString("F3"));
                npcgen.resource_sets[r].spawn_alt = float.Parse(offset.DirY.ToString("F3"));

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OFFSetResult offset = GetOffset();
            if (offset != null)
            {
                Dyntext_x.Text = offset.DirX.ToString("F3");
                Dyntext_y.Text = offset.DirY.ToString("F3");
                Dyntext_z.Text = offset.DirZ.ToString("F3");
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.games-shark.com/en/");
        }

        private void LoadNPCRules()
        {
            Application.DoEvents();
            progress_bar("Loading configs...", 0, 50);
            tabControl1.Enabled = false;
            comboBox1.Items.Clear();
            clientOffsets = new Dictionary<int, Offset>();
            try
            {

                int counter = 0;
                string line = "";
                StreamReader file = new System.IO.StreamReader(Path.GetDirectoryName(Application.ExecutablePath) + "\\Configs\\Npc\\coord_data.txt");
                String[] values = null;
                GetProcessid();
                while ((line = file.ReadLine()) != null)
                {
                    if (!line.StartsWith("#") && line.Length > 3 )
                    {
                        string[] arr = line.Split('\t');
                        if (arr != null) {
                            values = arr.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                            Offset offset = new Offset(values);
                            comboBox1.Items.Add(offset.name);
                            clientOffsets[counter] = offset;
                            counter++;
                        }
                    }
                }
                file.Close();
                Application.DoEvents();
                comboBox1.SelectedIndex = selindexofset;
                tabControl1.SelectedIndex = 0;
                tabControl1.Enabled = true;
                progress_bar("Ready", 0, 0);
            }
            catch (Exception)
            {
                JMessageBox.Show(this, "One of the config files are mising!!");
            }
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            Application.DoEvents();
            progress_bar("Loading configs...", 0,50);
            tabControl1.Enabled = false;
            try
            {
                imgDb = new Dictionary<int, string>();
                imgDbj = new Dictionary<int, int>();
                int counter = 0;
                string line;
                counter = 0;
                System.IO.StreamReader file = new System.IO.StreamReader(Path.GetDirectoryName(Application.ExecutablePath) + "\\Configs\\Npc\\dynobj.txt");
                Dyntext_name.Items.Add("0-NOT FOUND");
                while ((line = file.ReadLine()) != null)
                {
                    String[] data = line.Split('-');
                    imgDb[Int32.Parse(data[0])] = data[1];
                    imgDbj[Int32.Parse(data[0])] = counter + 1;
                    Dyntext_name.Items.Add(data[0] + "-" + data[1]);
                    counter++;
                }
                file.Close();
                LoadNPCRules();
            }
            catch(Exception)
            {
                JMessageBox.Show(this, "One of the config files are mising!!");
            }
            tabControl1.Enabled = true;
            if(isAutoOpen)
            {
                // Process input if the user clicked OK.
                GC.Collect();
                npgendatapath = autoOpenPath;

                using (BinaryReader br = new BinaryReader(File.Open(npgendatapath, FileMode.Open)))
                {
                    selindex = -1;
                    try
                    {
                        npcgen = new NPCALL();

                        npcgen.version = br.ReadInt32();
                        // this.Text = "Npc Editor By Games Shark - npc version " + npcgen.version;
                        npcgen.creature_sets_count = br.ReadInt32();
                        npcgen.resource_sets_count = br.ReadInt32();
                        if (npcgen.version >= 10)
                        {
                            npcgen.dynamics_count = br.ReadInt32();
                            npcgen.triggers_count = br.ReadInt32();
                        }
                        else
                        {
                            npcgen.dynamics_count = 0;
                            npcgen.triggers_count = 0;
                        }
                        load_creatures(br);
                        load_resources(br);
                        load_dynamics(br);
                        load_triggers(br);
                        pathLabel.Text = npgendatapath;
                        version_label.Text = npcgen.version.ToString();
                        label1.Visible = version_label.Visible = jLabel2.Visible = pathLabel.Visible = jLabel1.Visible = jPictureBox2.Visible = true;
                    }
                    catch (Exception ex)
                    {
                        JMessageBox.Show(this, "" + ex.ToString());
                    }
                }
                
                mobsNpcList.Enabled = true;
                tabControl1.Enabled = true;
                mobsNpcList.PerformLayout();
                dataGridView_resources.PerformLayout();
                Dyntext_items.PerformLayout();
                dataGridView_triggers.PerformLayout();
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Refresh();
        }

        public void CopyToClipboard(Export objectToCopy)
        {
            string format = "MyImporting";
            Clipboard.Clear();
            Clipboard.SetData(format, objectToCopy);
        }

        protected Export GetFromClipboard()
        {
            Export doc = null;
            string format = "MyImporting";
            if (Clipboard.ContainsData(format))
            {
                doc = (Export)Clipboard.GetData(format);
            }
            return doc;
        }

        private void mobsNpcList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Control | Keys.V))
            {
                e.Handled = true;
                importNPCmoBFromClipboard();
            }
        }

        private void importNPCmoBFromClipboard()
        {
            if (mobsNpcList.SelectedIndex == -1)
            {
                progress_bar("Please select items to import!", 0, 0);
                return;
            }

            int ltc = mobsNpcList.SelectedIndex;
            Export exportdata = GetFromClipboard();
            if (exportdata != null)
            {
                if (exportdata.ListId == 38 || exportdata.ListId == 57)
                {
                    if (exportdata.ListId == 38 && mobnpc_type.SelectedIndex != 0)
                    {
                        JMessageBox.Show(this, "You can't import Monster in NPC grupe!");
                        controlLock = false;
                        progress_bar("Ready", 0, 0);
                        return;
                    }
                    if (exportdata.ListId == 57 && mobnpc_type.SelectedIndex != 1)
                    {
                        JMessageBox.Show(this, "You can't import NPC in Monster grupe!");
                        controlLock = false;
                        progress_bar("Ready", 0, 0);
                        return;
                    }

                    controlLock = true;
                    progress_bar("Importing ...", 0, 0);
                    Application.DoEvents();
                    if (TaskEditor.eLC != null)
                    {
                        foreach (KeyValuePair<int, Object> entry in exportdata.data)
                        {
                            Dictionary<int, Object> data = (Dictionary<int, Object>)entry.Value;
                            int id_index = -1;
                            for (int i = 0; i < TaskEditor.eLC.Lists[exportdata.ListId].elementFields.Length; i++)
                            {
                                if (TaskEditor.eLC.Lists[exportdata.ListId].elementFields[i] == "ID")
                                {
                                    id_index = i;
                                    break;
                                }
                            }
                            int itemID = (int)data[id_index];
                            CreatureGroup cg = new CreatureGroup();
                            cg.id = itemID;
                            cg.amount = 1;
                            int index = mobsNpcList.SelectedIndex;
                            npcgen.creature_sets[index].creature_groups[npcgen.creature_sets[index].creature_groups.Count] = cg;
                            npcgen.creature_sets[index].creature_groups_count++;
                            mobsNpcList.Items[index] = "" + npcgen.creature_sets[index].creature_groups[0].id + "(" + npcgen.creature_sets[index].creature_groups_count.ToString() + ") -" + npcName(npcgen.creature_sets[index].creature_groups[0].id);
                        }
                        selindex = -1;
                        controlLock = false;
                        mobsNpcList_SelectedIndexChanged(null, null);
                    }
                    else
                    {
                        JMessageBox.Show(this, "Please load elements.data");
                    }
                }
                else
                {

                    JMessageBox.Show(this, "You can only paste monsters and npcs!");
                }

            }else
            {
                JMessageBox.Show(this, "You can only paste monsters and npcs!");
            }
            controlLock = false;
            progress_bar("Ready", 0, 0);
        }

        private void dataGridView_resourceGroups_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Control | Keys.V))
            {
                e.Handled = true;
                importResurceFromClipboard();
            }
        }

        private void importResurceFromClipboard()
        {
            if (dataGridView_resources.CurrentCell == null)
            {
                progress_bar("Please select resurce before import!", 0, 0);
                return;
            }
            if (dataGridView_resources.CurrentCell.RowIndex == -1)
            {
                progress_bar("Please select resurce before import!", 0, 0);
                return;
            }

            
            int ltc = mobsNpcList.SelectedIndex;
            Export exportdata = GetFromClipboard();
            if (exportdata != null)
            {
                if (exportdata.ListId == 79)
                {
                    progress_bar("Importing ...", 0, 0);
                    Application.DoEvents();
                    if (TaskEditor.eLC != null)
                    {
                        foreach (KeyValuePair<int, Object> entry in exportdata.data)
                        {
                            Dictionary<int, Object> data = (Dictionary<int, Object>)entry.Value;
                            //  eLC.Lists[obj.ListId].AddItem(obj.ListId, data);
                            int id_index = -1;
                            for (int i = 0; i < TaskEditor.eLC.Lists[exportdata.ListId].elementFields.Length; i++)
                            {
                                if (TaskEditor.eLC.Lists[exportdata.ListId].elementFields[i] == "ID")
                                {
                                    id_index = i;
                                    break;
                                }
                            }
                                int itemID = (int)data[id_index];
                                ResourceGroup rg = new ResourceGroup();
                                rg.id = itemID;
                                rg.amount = 1;
                                rg.unknown_1 = 80;
                                int rowIndex = dataGridView_resources.CurrentCell.RowIndex;
                                npcgen.resource_sets[rowIndex].resource_groups_count++;
                                npcgen.resource_sets[rowIndex].resource_groups[npcgen.resource_sets[rowIndex].resource_groups_count - 1] = rg;
                                dataGridView_resources.Rows[rowIndex].Cells[0].Value = npcgen.resource_sets[rowIndex].resource_groups_count + "";
                                dataGridView_resourceGroups.Rows.Clear();
                                for (int i = 0; i < npcgen.resource_sets[rowIndex].resource_groups_count; i++)
                                {
                                    dataGridView_resourceGroups.Rows.Add(
                                        npcgen.resource_sets[rowIndex].resource_groups[i].unknown_1.ToString(),
                                    npcgen.resource_sets[rowIndex].resource_groups[i].id.ToString(),
                                    npcgen.resource_sets[rowIndex].resource_groups[i].respawn.ToString(),
                                    npcgen.resource_sets[rowIndex].resource_groups[i].amount.ToString(),
                                    npcgen.resource_sets[rowIndex].resource_groups[i].unknown_2.ToString()

                                );
                                String name = "NOT FOUND";
                                try
                                {
                                    if (!Program.elementSeditorFirstLoad && npcgen.resource_sets[rowIndex].resource_groups_count > 0)
                                    {
                                        if (NpcEditor.npcdb.ContainsKey(Int32.Parse(npcgen.resource_sets[rowIndex].resource_groups[i].id.ToString())))
                                        {
                                            name = NpcEditor.npcdb[Int32.Parse(npcgen.resource_sets[rowIndex].resource_groups[i].id.ToString())].name;
                                        }
                                    }
                                }
                                catch (Exception) { }

                                dataGridView_resourceGroups.Rows[i].HeaderCell.Value = name;
                            }

                        }
                    }
                    else
                    {
                        JMessageBox.Show(this, "Please load elements.data");
                    }
                }
                else
                {

                    JMessageBox.Show(this, "You can only paste resource here!");
                }

            }
            else
            {
                JMessageBox.Show(this, "You can only paste resource here!");
            }
            controlLock = false;
            progress_bar("Ready", 0, 0);
        }

        private void mobsNpcList_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (npcgen != null && !controlLock)
            {
                e.DrawBackground();
                if (npcgen.creature_sets[e.Index].monstertype == 0)
                {
                    e.Graphics.DrawString(mobsNpcList.Items[e.Index].ToString(), mobsNpcList.Font, Brushes.Silver, e.Bounds);
                }
                else
                {
                    e.Graphics.DrawString(mobsNpcList.Items[e.Index].ToString(), mobsNpcList.Font, Brushes.OrangeRed, e.Bounds);
                }
            }
        }
        private void saveAsToolStripMenuItem_Click10(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Elements File (*.data)|*.data|All Files (*.*)|*.*";

            if (npcgen != null && save.ShowDialog() == DialogResult.OK && save.FileName != "")
            {
                npcgen.version = 10;
                progress_bar("Saving ...", 0, 0);
                try
                {
                    FileStream fs = new FileStream(save.FileName, FileMode.Create, FileAccess.Write);
                    BinaryWriter bw = new BinaryWriter(fs);

                    if (npcgen.version < 11)
                    {
                        bw.Write((int)10);
                    }
                    else
                    {
                        bw.Write(npcgen.version);
                    }
                    bw.Write(npcgen.creature_sets_count);
                    bw.Write(npcgen.resource_sets_count);
                    bw.Write(npcgen.dynamics_count);
                    bw.Write(npcgen.triggers_count);

                    save_creatures(bw);
                    save_resources(bw);
                    save_dynamics(bw);
                    save_triggers(bw);

                    bw.Close();
                    fs.Close();


                }
                catch (Exception)
                {
                    JMessageBox.Show(this, "SAVING ERROR!");
                }
                progress_bar("Ready", 0, 0);
            }
        }

        private void saveAsToolStripMenuItem_Click11(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Elements File (*.data)|*.data|All Files (*.*)|*.*";
            
            if (npcgen != null && save.ShowDialog() == DialogResult.OK && save.FileName != "")
            {
                npcgen.version = 11;
                progress_bar("Saving ...", 0, 0);
                try
                {
                    FileStream fs = new FileStream(save.FileName, FileMode.Create, FileAccess.Write);
                    BinaryWriter bw = new BinaryWriter(fs);

                    if (npcgen.version < 11)
                    {
                        bw.Write((int)10);
                    }
                    else
                    {
                        bw.Write(npcgen.version);
                    }
                    bw.Write(npcgen.creature_sets_count);
                    bw.Write(npcgen.resource_sets_count);
                    bw.Write(npcgen.dynamics_count);
                    bw.Write(npcgen.triggers_count);

                    save_creatures(bw);
                    save_resources(bw);
                    save_dynamics(bw);
                    save_triggers(bw);

                    bw.Close();
                    fs.Close();


                }
                catch (Exception)
                {
                    JMessageBox.Show(this, "SAVING ERROR!");
                }
                progress_bar("Ready", 0, 0);
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Elements File (*.data)|*.data|All Files (*.*)|*.*";
            if (npcgen != null && save.ShowDialog() == DialogResult.OK && save.FileName != "")
            {
                progress_bar("Saving ...", 0, 0);
                try
                {
                    FileStream fs = new FileStream(save.FileName, FileMode.Create, FileAccess.Write);
                    BinaryWriter bw = new BinaryWriter(fs);

                    if (npcgen.version < 11)
                    {
                        bw.Write((int)10);
                    }
                    else
                    {
                        bw.Write(npcgen.version);
                    }
                    bw.Write(npcgen.creature_sets_count);
                    bw.Write(npcgen.resource_sets_count);
                    bw.Write(npcgen.dynamics_count);
                    bw.Write(npcgen.triggers_count);

                    save_creatures(bw);
                    save_resources(bw);
                    save_dynamics(bw);
                    save_triggers(bw);

                    bw.Close();
                    fs.Close();


                }
                catch (Exception)
                {
                    JMessageBox.Show(this, "SAVING ERROR!");
                }
                JMessageBox.Show(this, "Saved.");
                progress_bar("Ready", 0, 0);
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            int someOtherInt = int.Parse(mobnpc_id.Text);
            if (TaskEditor.eLC != null && TaskEditor.eLC.getItem(someOtherInt) != null)
            {
                ItemDupe item = TaskEditor.eLC.getItem(someOtherInt);
                MainProgram.getInstance().goToElementIndex(item);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView_resourceGroups.CurrentCell != null)
                {
                    int value = int.Parse(dataGridView_resourceGroups.Rows[dataGridView_resourceGroups.CurrentCell.RowIndex].Cells[2].Value.ToString());
                    int someOtherInt = int.Parse(mobnpc_id.Text);
                    if (TaskEditor.eLC != null && TaskEditor.eLC.getItem(someOtherInt) != null)
                    {
                        ItemDupe item = TaskEditor.eLC.getItem(someOtherInt);
                        MainProgram.getInstance().goToElementIndex(item);
                    }
                }
            }
            catch { }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if(npcgen != null && mobsNpcList.SelectedIndex > -1 && textString.Length > 0)
            Clipboard.SetText(textString);
        }

        private void UniversalSearch(object sender, EventArgs e)
        {
            switch(tabControl1.SelectedIndex)
            {
                case 0:
                    btnAdd_Click(sender, e);
                    break;
                case 1:
                    button1_Click_1(sender, e);
                    break;
                case 2:
                    button2_Click(sender, e);
                    break;
                case 3:
                    button3_Click(sender, e);
                    break;
            }
        }

        private void NpcEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Program.StandAlone)
            {
                if (e.CloseReason == CloseReason.UserClosing)
                {
                    e.Cancel = true;
                    MainProgram.getInstance().ShowNpcEditor(null, null);
                }
            }
            else
            {
                MainProgram.getInstance().ExitInvoke();
            }
        }

        private void importFromCoordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImportFromCoordNPC aaa = new ImportFromCoordNPC(this);
            aaa.Show();
        }

        public void ImportData(int type, List<ImportFromCoordNPC.Mobs> obj)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(() => { ImportData(type, obj); }));
                    return;
                }

                switch (type)
                {
                    case 0://NPC
                        controlLock = true;
                        foreach (ImportFromCoordNPC.Mobs mob in obj)
                        {
                            if (!ids.ContainsKey(mob.id))
                            {
                                int index = mobsNpcList.Items.Count - 1;
                                CreatureSet cs = new CreatureSet();
                                cs.creature_groups = new SortedList<int, CreatureGroup>();
                                cs.creature_groups[0] = new CreatureGroup();
                                cs.creature_groups[0].id = mob.id;
                                cs.creature_groups[0].amount = 1;
                                cs.positionType = 1;
                                cs.unknown_11 = false;
                                cs.monstertype = 1;
                                float x = 0f;
                                float y = 0f;
                                float z = 0f;
                                float.TryParse(mob.x, out x);
                                float.TryParse(mob.y, out y);
                                float.TryParse(mob.z, out z);
                                cs.spawn_x = x;
                                cs.spawn_alt = y;
                                cs.spawn_z = z;
                                npcgen.creature_sets.Add(npcgen.creature_sets.Count, cs);
                                mobsNpcList.Items.Add(mob.Name);
                            }

                        }
                        npcgen.creature_sets = resortDic(npcgen.creature_sets);
                        npcgen.creature_sets_count = npcgen.creature_sets.Count;
                        mobsNpcList.ClearSelected();
                        mobsNpcList.SelectedIndex = mobsNpcList.Items.Count - 1;
                        mobsNpcList_SelectedIndexChanged(null, null);
                        controlLock = false;
                        break;
                    case 1://MOB
                        controlLock = true;
                        foreach (ImportFromCoordNPC.Mobs mob in obj)
                        {
                            if (!ids.ContainsKey(mob.id))
                            {
                                int index = mobsNpcList.Items.Count - 1;

                                CreatureSet cs = new CreatureSet();
                                cs.creature_groups = new SortedList<int, CreatureGroup>();
                                cs.creature_groups[0] = new CreatureGroup();
                                cs.creature_groups[0].id = mob.id;
                                cs.creature_groups[0].amount = 1;
                                cs.creature_groups[0].respawn = 3600;
                                cs.positionType = 1;
                                cs.unknown_11 = false;
                                cs.monstertype = 0;
                                float x = 0f;
                                float y = 0f;
                                float z = 0f;
                                float.TryParse(mob.x, out x);
                                float.TryParse(mob.y, out y);
                                float.TryParse(mob.z, out z);
                                cs.spawn_x = x;
                                cs.spawn_alt = y;
                                cs.spawn_z = z;
                                npcgen.creature_sets.Add(npcgen.creature_sets.Count, cs);
                                mobsNpcList.Items.Add(mob.Name);
                            }

                        }
                        npcgen.creature_sets = resortDic(npcgen.creature_sets);
                        npcgen.creature_sets_count = npcgen.creature_sets.Count;
                        mobsNpcList.ClearSelected();
                        mobsNpcList.SelectedIndex = mobsNpcList.Items.Count - 1;
                        mobsNpcList_SelectedIndexChanged(null, null);
                        controlLock = false;
                        break;
                    case 2://Resource

                        break;
                }
            }catch(Exception ea)
            {
                JMessageBox.Show(this, "Error:"+ ea.ToString() + "");
            }
        }

        private void jButton1_Click(object sender, EventArgs e)
        {
            if (npcgen != null)
            {
                try
                {
                    int mobId = int.Parse(mobnpc_trig.Text);
                    if (mobId > 0)
                    {
                        Trigger trig = npcgen.triggers.FirstOrDefault(x => x.Value.triger_id == mobId).Value;
                        if (trig != null)
                        {
                            Clipboard.SetText(trig.gm_activateId.ToString());
                            JMessageBox.Show(this, "Gm Activator id copied to clipboard.");
                        }

                    }

                }
                catch { }
            }
        }

        private void aSKToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (npcgen != null)
            {
                var items = npcgen.triggers.OrderBy(r => r.Value.triger_id);
                SortedList<int, Trigger> datanew = new SortedList<int, Trigger>();
                int i = 0;
                foreach (KeyValuePair<int, Trigger> entry in items)
                {
                    datanew[i] = entry.Value;
                    i++;
                }
                npcgen.triggers = datanew;
                reSortTrigers();
            }
        }

        private void reSortTrigers()
        {
            tabControl1.Enabled = false;
            dataGridView_triggers.SuspendLayout();
            dataGridView_triggers.Rows.Clear();
            int i = 0;
            foreach (KeyValuePair<int, Trigger> entry in npcgen.triggers)
            {
                Encoding enc = Encoding.GetEncoding("GBK");
                dataGridView_triggers.Rows.Add(
                    entry.Value.triger_id.ToString(),
                    entry.Value.gm_activateId.ToString(),
                    enc.GetString(entry.Value.name),
                    Convert.ToBoolean(entry.Value.on_load),
                    entry.Value.unknown_4.ToString(),
                    entry.Value.unknown_5.ToString(),
                    Convert.ToBoolean(entry.Value.auto_start),
                    Convert.ToBoolean(entry.Value.auto_stop),
                    entry.Value.year_1.ToString(),
                    entry.Value.month_1.ToString(),
                    Column42.Items[entry.Value.week_day_1 + 1],
                    entry.Value.day_1.ToString(),
                    entry.Value.hour_1.ToString(),
                    entry.Value.minute_1.ToString(),
                    entry.Value.year_2.ToString(),
                    entry.Value.month_2.ToString(),
                    Column43.Items[entry.Value.week_day_2 + 1],
                    entry.Value.day_2.ToString(),
                    entry.Value.hour_2.ToString(),
                    entry.Value.minute_2.ToString(),
                    entry.Value.duration.ToString()
               );
                dataGridView_triggers.Rows[i].HeaderCell.Value = (dataGridView_triggers.Rows.Count - 1).ToString();
                i++;
            }
            tabControl1.Enabled = true;
            dataGridView_triggers.ResumeLayout();
            dataGridView_triggers.PerformLayout();

        }

        private void dSKToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (npcgen != null)
            {
                var items = npcgen.triggers.OrderByDescending(r => r.Value.triger_id);
                SortedList<int, Trigger> datanew = new SortedList<int, Trigger>();
                int i = 0;
                foreach (KeyValuePair<int, Trigger> entry in items)
                {
                    datanew[i] = entry.Value;
                    i++;
                }
                npcgen.triggers = datanew;
                reSortTrigers();
            }
        }

        public float[] getPosx(double pos_x, double pos_y, double pos_z)
        {
            double x = (pos_x + 9.6) * 10 - 4096.0;
            double y = (pos_y * 10);
            double z = (pos_z - 1113.2) * 10 + 5632.0;
            return new float[3] {(float)x, (float)y, (float)z };
        }

        private void jTextBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string[] coordinates = jTextBox1.Text.Split(null);
                if(coordinates.Length > 0)
                {
                   // MessageBox.Show(string.Join(",",getPosx(double.Parse(coordinates[0]), 700, double.Parse(coordinates[1]))));
                    float[] data = getPosx(double.Parse(coordinates[0]), coordinates.Length >=3 ? double.Parse(coordinates[2]):700, double.Parse(coordinates[1]));
                    try
                    {
                        npcgen.creature_sets[mobsNpcList.SelectedIndex].spawn_x = data[0];
                        mobnpc_x.Text = data[0].ToString();
                    }
                    catch { }
                    try
                    {
                        npcgen.creature_sets[mobsNpcList.SelectedIndex].spread_alt = data[1];
                        mobnpc_y.Text = data[1].ToString();
                    }
                    catch { }
                    try
                    {
                        npcgen.creature_sets[mobsNpcList.SelectedIndex].spawn_z = data[2];
                        mobnpc_z.Text = data[2].ToString();
                    }
                    catch { }
                    return;
                }
                coordinates = jTextBox1.Text.Split(',');
                if (coordinates.Length > 0)
                {
                    // MessageBox.Show(string.Join(",",getPosx(double.Parse(coordinates[0]), 700, double.Parse(coordinates[1]))));
                    float[] data = getPosx(double.Parse(coordinates[0]), coordinates.Length >= 3 ? double.Parse(coordinates[2]) : 700, double.Parse(coordinates[1]));
                    try
                    {
                        npcgen.creature_sets[mobsNpcList.SelectedIndex].spawn_x = data[0];
                        mobnpc_x.Text = data[0].ToString();
                    }
                    catch { }
                    try
                    {
                        npcgen.creature_sets[mobsNpcList.SelectedIndex].spread_alt = data[1];
                        mobnpc_y.Text = data[1].ToString();
                    }
                    catch { }
                    try
                    {
                        npcgen.creature_sets[mobsNpcList.SelectedIndex].spawn_z = data[2];
                        mobnpc_z.Text = data[2].ToString();
                    }
                    catch { }
                    return;
                }
            }
            catch { }
        }

        private OFFSetResult GetOffset()
        {
            OFFSetResult res = null;
            int selectedOFset = comboBox1.SelectedIndex;
            if (selectedOFset != -1)
            {
                try
                {
                    Offset offset = (Offset)clientOffsets[selectedOFset];
                    Process process = processes[jComboBox1.SelectedIndex];
                    IntPtr processHandle = OpenProcess(PROCESS_ALL_ACCESS, true, process.Id);
                    byte[] lpBuffer = new byte[4];
                    ReadProcessMemory(processHandle, (IntPtr)(offset.GAME), lpBuffer, 4, 0);
                    int a = BitConverter.ToInt32(lpBuffer, 0);
                    ReadProcessMemory(processHandle, (IntPtr)(a + offset.COORD), lpBuffer, 4, 0);
                    int adr = BitConverter.ToInt32(lpBuffer, 0);
                    ReadProcessMemory(processHandle, (IntPtr)(adr + offset.TARGET), lpBuffer, 4, 0);
                    int roleID = BitConverter.ToInt32(lpBuffer, 0);
                    ReadProcessMemory(processHandle, (IntPtr)(adr + offset.X), lpBuffer, 4, 0);
                    float X = BitConverter.ToSingle(lpBuffer, 0);
                    ReadProcessMemory(processHandle, (IntPtr)(adr + offset.Y), lpBuffer, 4, 0);
                    float Y = BitConverter.ToSingle(lpBuffer, 0);
                    ReadProcessMemory(processHandle, (IntPtr)(adr + offset.Z), lpBuffer, 4, 0);
                    float Z = BitConverter.ToSingle(lpBuffer, 0);
                    ReadProcessMemory(processHandle, (IntPtr)(adr + offset.RotX), lpBuffer, 4, 0);
                    float RotX = BitConverter.ToSingle(lpBuffer, 0);
                    ReadProcessMemory(processHandle, (IntPtr)(adr + offset.RotY), lpBuffer, 4, 0);
                    float RotY = BitConverter.ToSingle(lpBuffer, 0);
                    ReadProcessMemory(processHandle, (IntPtr)(adr + offset.RotZ), lpBuffer, 4, 0);
                    float RotZ = BitConverter.ToSingle(lpBuffer, 0);
                    res = new OFFSetResult();
                    res.NpcId = roleID;
                    res.DirX = X;
                    res.DirY = Y;
                    res.DirZ = Z;
                    res.RotX = RotX;
                    res.RotY = RotY;
                    res.RotZ = RotZ;
                    return res;

                }
                catch { }

            }
            return res;
        }

        private void jPictureBox4_Click(object sender, EventArgs e)
        {
            LoadNPCRules();
        }

        private void jPictureBox5_Click(object sender, EventArgs e)
        {
            GetOffset();
        }

        private void mobsNpcList_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Control | Keys.A))
            {
                mobsNpcList.ClearSelected();
                for (int i = 0; i < mobsNpcList.Items.Count; i++)
                {
                    mobsNpcList.SetSelected(i, true);
                }
            }
        }

        private void exportToCoorddatatxtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RenameForm rf = new RenameForm("Choose Map Name");
            DialogResult res = rf.ShowDialog(this);
            if(res == DialogResult.OK)
            {
                string result = RenameForm.value.ToLower();
                string text = "";
                for (int i = 0; i < mobsNpcList.SelectedIndices.Count; i++)
                {
                    progress_bar("Exporting ...", i, mobsNpcList.SelectedIndices.Count);
                    int index = mobsNpcList.SelectedIndices[i];
                    CreatureSet set = npcgen.creature_sets[index];
                    try
                    {
                        text += set.creature_groups[0].id + "		 " + result + "		   " + set.spawn_x.ToString("####0.00") + "		   " + set.spawn_alt.ToString("####0.00") + "		   " + set.spawn_z.ToString("####0.00") + "\r";
                    }
                    catch { }

                }
                Clipboard.SetText(text);
                JMessageBox.Show(this, "Copied to clipboard.");
            }
        }

        public void CopyToClipboardE(Export objectToCopy)
        {
            string format = "MyImporting";
            Clipboard.Clear();
            Clipboard.SetData(format, objectToCopy);
        }

        private void copyElementsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //  var myKey = types.FirstOrDefault(x => x.Value == "one").Key;
            if (mobsNpcList.SelectedIndex == -1)
            {
                progress_bar("Please select items to export!", 0, 0);
                return;
            }

            try
            {
                controlLock = true;

                if (mobsNpcList.SelectedIndex != -1)
                {
                    HashSet<int> values = new HashSet<int>();
                    for (int i = 0; i < mobsNpcList.SelectedIndices.Count; i++)
                    {
                        progress_bar("Getting info ...", i, mobsNpcList.SelectedIndices.Count);
                        int index = mobsNpcList.SelectedIndices[i];
                        foreach(CreatureGroup grup in npcgen.creature_sets[index].creature_groups.Values)
                        {
                            values.Add(grup.id);
                        }
                    }
                    Export export = new Export();
                    export.ListId = 57;
                    export.type = 0; //Elements data = 0 | Gshop = 1 
                    export.Version = ElementsEditor.eLC.Version;
                    export.RowCount = ElementsEditor.eLC.Lists[export.ListId].elementFields.Length;
                    export.data = new SortedDictionary<int, object>(new ReverseComparer<int>(Comparer<int>.Default));
                    foreach (int i in values)
                    {
                        ItemDupe dupe = npcdb.ContainsKey(i) ? npcdb[i] : null;
                        if (dupe != null && dupe.listID == 57)
                        {
                            export.data.Add(i, ElementsEditor.eLC.Lists[dupe.listID].elementValues[dupe.index]);
                        }
                    }
                    CopyToClipboardE(export);
                    JMessageBox.Show(this, "List 57 has ben copyed to clipboard. Press ok to copy list 38");
                    export = new Export();
                    export.ListId = 38;
                    export.type = 0; //Elements data = 0 | Gshop = 1 
                    export.Version = ElementsEditor.eLC.Version;
                    export.RowCount = ElementsEditor.eLC.Lists[export.ListId].elementFields.Length;
                    export.data = new SortedDictionary<int, object>(new ReverseComparer<int>(Comparer<int>.Default));
                    foreach (int i in values)
                    {
                        ItemDupe dupe = npcdb.ContainsKey(i) ? npcdb[i] : null;
                        if (dupe != null && dupe.listID == 38)
                        {
                            export.data.Add(i, ElementsEditor.eLC.Lists[dupe.listID].elementValues[dupe.index]);
                        }
                    }
                    CopyToClipboardE(export);
                    JMessageBox.Show(this, "List 38 has ben copyed to clipboard. Bye!");
                }

                controlLock = false;
            }
            catch (Exception)
            {

            }
            progress_bar("Ready", 0, 0);
            
        }

        private void jPictureBox5_Click_1(object sender, EventArgs e)
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
            mapView = new WorldMap("world", false);
            mapView.mouseDown += MapViewMouseDown;
            mapView.Show();
        }

        private void MapViewMouseDown(float x, float y)
        {

        }
    }
}
