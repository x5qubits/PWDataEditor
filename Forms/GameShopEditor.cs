using ElementEditor.classes;
using ElementEditor.Element_Editor_Classes;
using ElementEditor.Game_Shop_classes;
using ElementEditor.helper_classes;
using JHUI;
using JHUI.Animation;
using JHUI.Forms;
using sTASKedit;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Linq;
using PWDataEditorPaied.Database;
using PWDataEditorPaied.Forms.SubForms;
using PWDataEditorPaied.Game_Shop_classes;
using JHUI.Utils;

namespace ElementEditor
{
    public partial class GameShopEditor : JForm
    {
        internal delegate void UpdateProgressDelegate(String value, int min, int max);
        internal event UpdateProgressDelegate progress_bar2;
        public int defWidth = 932;
        public int defHeight = 647;
        private Boutique GSHOP;
        public static Boutique BGSHOP;
        int max_item_id;
        private bool try153 = false;
        private bool try136 = false;
        private int version = 0;
        public static string loadedFileName = "";


        public GameShopEditor()
        {
            InitializeComponent();
            this.MinimizeBox = Program.SHOWMINIMIZEBUTTON;
            jLabel1.Visible = jLabel2.Visible = pathLabel.Visible = version_label.Visible = jPictureBox2.Visible = false;
            textBox_timestamp.Alpha = 0;
            jPictureBox3.Visible = false;
            jPictureBox3.Alpha = 0;
            comboBox_dbSource.SelectedIndex = 1;
            saleOptionIndex = 0;
            comboBox_status.SelectedIndex = 0;
            comboBox_type.SelectedIndex = 0;
            versionSelector.SelectedIndex = 0;
            fieldscomboBox.SelectedIndex = 0;
            button1_Click(null, null);
        }

        private void autoDetectVersion(string load)
        {
            Application.DoEvents();
            if (try153 && try136 && try155 && try157 || autoloadedCount >= 4)
            {
                progress_bar("Ready", 0, 0);
                try153 = false;
                try136 = false;
                try155 = false;
                try157 = false;
                autoloadedCount = 0;
                JMessageBox.Show(this, "Unable to read the file, are you sure is gshop.data?");
                return;
            }

            if (!try155)
            {
                //progress_bar("Loading open155", 0, 0);
                autoloadedCount++;
                try155 = true;
                OpenShop(load, 155);
                return;
            }

            if (!try157)
            {
                // progress_bar("Loading open136", 0, 0);
                autoloadedCount++;
                try157 = true;
                OpenShop(load, 157);
                return;
            }

            if (!try153)
            {
                //progress_bar("Loading open151", 0, 0);
                autoloadedCount++;
                try153 = true;
                OpenShop(load, 127);
                return;
            }
            if (!try136)
            {
                // progress_bar("Loading open136", 0, 0);
                autoloadedCount++;
                try136 = true;
                OpenShop(load, 7);
                return;
            }

        }

        public bool autoLoad(string _path)
        {
            GC.Collect();
            loadedFileName = _path;
            autoDetectVersion(_path);
            return true;
        }

        private void LoadShopClick(object sender, EventArgs ex)
        {
            try
            {
                try153 = false;
                try136 = false;
                try155 = false;
                try157 = false;
                lockedCheck = true;
                autoloadedCount = 0;
                OpenFileDialog load = new OpenFileDialog();
                load.Filter = "GShop (*.data)|*.data|All Files (*.*)|*.*";
                if (load.ShowDialog() == System.Windows.Forms.DialogResult.OK && File.Exists(load.FileName))
                {
                    loadedFileName = load.FileName;
                    GSHOP = null;
                    GC.Collect();
                    autoDetectVersion(load.FileName);
                }
            }
            catch { }
        }

        private void OpenShop(string load, int version, bool isClient = true, bool retry = true)
        {
            try
            {
                this.version = version;
                lockedCheck = true;
                Application.DoEvents();
                progress_bar("Loading " + version + "...", 0, 0);
                //Cursor = System.Windows.Forms.Cursors.WaitCursor;
                listBox_Cats.Rows.Clear();
                listBox_SubCats.Rows.Clear();
                listBox_items.Rows.Clear();

                GSHOP = new Boutique();
                max_item_id = 0;

                using (FileStream fr = File.OpenRead(load))
                {
                    using (BinaryReader br = new BinaryReader(fr))
                    {

                        GSHOP.timestamp = br.ReadUInt32();
                        GSHOP.item_count = br.ReadUInt32();
                        GSHOP.items = new Dictionary<int, Item>();
                        if (GSHOP.item_count > 40000)
                        {
                            throw new Exception();
                        }
                        for (int i = 0; i < GSHOP.item_count; i++)
                        {
                            GSHOP.items[i] = new Item();
                            GSHOP.items[i].activate = true;
                            GSHOP.items[i].deleted = false;
                            GSHOP.items[i].shop_id = i;
                            GSHOP.items[i].Read(br, version, isClient);
                            max_item_id = Math.Max(max_item_id, GSHOP.items[i].local_id);
                        }
                        GSHOP.categories = new Category[8];
                        if (isClient)
                        {
                            for (int i = 0; i < GSHOP.categories.Length; i++)
                            {
                                GSHOP.categories[i] = new Category();
                                GSHOP.categories[i].name = new NameChar(128, br);
                                GSHOP.categories[i].sub_cats_count = br.ReadUInt32();
                                GSHOP.categories[i].sub_cats = new Dictionary<int, NameChar>();
                                for (int n = 0; n < GSHOP.categories[i].sub_cats_count; n++)
                                {
                                    GSHOP.categories[i].sub_cats[n] = new NameChar(128, br);
                                }
                            }
                        }
                        else
                        {
                            for (int x = 0; x < GSHOP.item_count; x++)
                            {
                                int main_type = GSHOP.items[x].main_type;
                                int sub_type = GSHOP.items[x].sub_type;
                                if (GSHOP.categories[main_type] == null)
                                {
                                    GSHOP.categories[main_type] = new Category();
                                    GSHOP.categories[main_type].name = new NameChar(128);
                                    GSHOP.categories[main_type].sub_cats = new Dictionary<int, NameChar>();
                                }
                                if (GSHOP.categories[main_type].sub_cats_count < sub_type + 1)
                                    GSHOP.categories[main_type].sub_cats_count = (uint)sub_type + 1;

                                for (int n = 0; n < GSHOP.categories[main_type].sub_cats_count; n++)
                                {
                                    GSHOP.categories[main_type].sub_cats[n] = new NameChar(128, br);
                                }
                            }
                        }
                    }
                }
                for (int i = 0; i < GSHOP.categories.Length; i++)
                {
                    if (GSHOP.categories[i] == null)
                    {
                        GSHOP.categories[i] = new Category();
                        GSHOP.categories[i].name = new NameChar(128);
                        GSHOP.categories[i].sub_cats = new Dictionary<int, NameChar>();
                    }
                    if (GSHOP.categories[i].name.Name != null && GSHOP.categories[i].name.Name.Length > 0)
                        listBox_Cats.Rows.Add(new object[] { GSHOP.categories[i].name.Name });
                    else
                        listBox_Cats.Rows.Add(new object[] { "Cat_" + i });
                }

                build_contextMenus();
                textBox_timestamp.Text = GUtils.timestamp_to_string(GSHOP.timestamp);
                //Cursor = System.Windows.Forms.Cursors.Default;
                listBox_Cats.Rows[0].Selected = true;
                listBox_Cats.CurrentCell = listBox_Cats.Rows[0].Cells[0];
                lockedCheck = false;
                listBox_Cats_SelectedIndexChanged(null, null);
                pathLabel.Text = load;
                version_label.Text = version.ToString();
                jLabel1.Visible = jLabel2.Visible = pathLabel.Visible = version_label.Visible = jPictureBox2.Visible = true;
            }
            catch
            {
                lockedCheck = false;
                GSHOP = null;
                GC.Collect();
                if (retry)
                    autoDetectVersion(load);
                return;
            }
            versionSelector.SelectedIndex = 0;
            GameShopEditor.BGSHOP = GSHOP;
            lockedCheck = false;
            progress_bar("Ready", 0, 0);
        }

        private bool saveShop(string save, bool isClient, int versionx)
        {

            try
            {
                Application.DoEvents();
                progress_bar("Saving " + (isClient ? "Client" : "Server") + " ...", 0, 0);
                using (FileStream fw = new FileStream(save, FileMode.Create, FileAccess.Write))
                {
                    using (BinaryWriter bw = new BinaryWriter(fw))
                    {
                        lockedCheck = true;
                        GSHOP.timestamp = GUtils.string_to_timestamp(textBox_timestamp.Text);
                        int active_item_count = 0;
                        bw.Write(GSHOP.timestamp);
                        for (int i = 0; i < GSHOP.items.Count; i++)
                        {
                            if (GSHOP.items[i].main_type > -1 && GSHOP.items[i].sub_type > -1 && !GSHOP.items[i].deleted)
                            {
                                active_item_count++;
                            }
                        }
                        bw.Write(active_item_count); //bw.Write(GSHOP.item_count);
                        for (int i = 0; i < GSHOP.items.Count; i++)
                        {
                            if (GSHOP.items[i].main_type > -1 && GSHOP.items[i].sub_type > -1 && !GSHOP.items[i].deleted)
                            {
                                GSHOP.items[i].Write(bw, versionx, isClient);
                            }
                        }
                        if (isClient)
                        {
                            for (int i = 0; i < GSHOP.categories.Length; i++)
                            {
                                bw.Write(GSHOP.categories[i].name.EncodedName);
                                bw.Write((uint)GSHOP.categories[i].sub_cats.Count);
                                for (int n = 0; n < GSHOP.categories[i].sub_cats.Count; n++)
                                {
                                    bw.Write(GSHOP.categories[i].sub_cats[n].EncodedName);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                JMessageBox.Show(this, "EXPORT ERROR!\n\n" + e.Message);
                lockedCheck = false;
                return false;
            }
            lockedCheck = false;
            progress_bar("Ready", 0, 0);
            return true;
        }

        private void SaveShopClick(object sender, EventArgs ex)
        {
            if (versionSelector.SelectedIndex == 3)
            {
                JMessageBox.Show(this, "Currently not Available!");
                return;
            }
            if (GSHOP != null)
            {
                saveShop(loadedFileName, true, version);
                string filename = Path.GetFileNameWithoutExtension(loadedFileName);
                string resultString = Regex.Match(filename, @"\d+").Value;
                int num = 0;
                bool hasNumber = Int32.TryParse(resultString, out num);
                string path = "";
                if (hasNumber)
                {
                    path = Path.GetDirectoryName(loadedFileName) + "\\gshopsev" + num + ".data";
                }
                else
                {
                    path = Path.GetDirectoryName(loadedFileName) + "\\gshopsev.data";
                }
                saveShop(path, false, version);
            }
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
            button1_Click(null, null);
        }

        private bool Iit = false;
        private void listBox_Cats_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lockedCheck) { return; }
            if (!Iit)
            {
                Iit = true;
                new JAnimate().Start(textBox_timestamp, 2, Effect.FadeIn);
                new JAnimate().Start(jPictureBox3, 2, Effect.FadeIn, () => { jPictureBox3.Visible = true; });
            }

            if (GSHOP != null && listBox_Cats.CurrentCell != null)
            {
                int SelectedIndex = listBox_Cats.CurrentCell.RowIndex;
                progress_bar("Loading ...", 0, 100);
                lockedCheck = true;
                listBox_SubCats.Rows.Clear();
                listBox_items.Rows.Clear();
                for (int i = 0; i < GSHOP.categories[SelectedIndex].sub_cats.Count; i++)
                {
                    progress_bar("Loading ...", i, GSHOP.categories[SelectedIndex].sub_cats.Count);

                    if (GSHOP.categories[SelectedIndex].sub_cats[i].Name != null && GSHOP.categories[SelectedIndex].sub_cats[i].Name.Length > 0)
                        listBox_SubCats.Rows.Add(new object[] { GSHOP.categories[SelectedIndex].sub_cats[i].Name });
                    else
                        listBox_SubCats.Rows.Add(new object[] { "SubCat_" + i });
                    //listBox_SubCats.Rows.Add(GSHOP.categories[SelectedIndex].sub_cats[i].Name);
                }
                try
                {
                    lockedCheck = false;
                    listBox_SubCats.Rows[0].Selected = true;
                    listBox_SubCats.CurrentCell = listBox_SubCats.Rows[0].Cells[0];
                    listBox_SubCats_SelectedIndexChanged(null, null);
                }
                catch
                {

                }
                progress_bar("Ready", 0, 0);
                lockedCheck = false;
            }
        }

        public void progress_bar(string value, int min, int max)
        {
            if (progress_bar2 != null)
            {
                progress_bar2(value, min, max);
            }
        }
        private bool lockedCheck = false;
        private List<Item> current = new List<Item>();
        private void listBox_SubCats_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lockedCheck) { return; }
            if (GSHOP != null && listBox_Cats.CurrentCell != null && listBox_SubCats.CurrentCell != null)
            {
                showInfo = false;
                progress_bar("Loading ...", 0, 100);
                lockedCheck = true;
                listBox_items.Enabled = false;
                listBox_items.Rows.Clear();
                if (GSHOP.items.ContainsKey(listBox_Cats.CurrentCell.RowIndex))
                {

                    current = GSHOP.items.Values.Where(x => x.main_type == listBox_Cats.CurrentCell.RowIndex && !x.deleted && x.sub_type == listBox_SubCats.CurrentCell.RowIndex).ToList();
                    listBox_items.RowCount = current.Count();

                }
                try
                {
                    lockedCheck = false;
                    listBox_items.Enabled = true;
                    listBox_items.Rows[0].Selected = true;
                    listBox_items.CurrentCell = listBox_items.Rows[0].Cells[0];
                    change_item(null, null);

                }
                catch
                {

                }
                lockedCheck = false;
                isDraging = false;
                listBox_items.Enabled = true;
                listBox_items.Refresh();
                progress_bar("Ready", 0, 0);
            }
        }

        private void listBox_Items_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lockedCheck) { return; }
            if (GSHOP != null && listBox_items.CurrentCell != null && listBox_items.CurrentCell.RowIndex > -1)
            {
                lockedCheck = true;
                progress_bar("Loading ...", 0, 100);
                saleOptionIndex = 0;
                button1_Click(null, null);
                int current_item_index = Convert.ToInt32(listBox_items.Rows[listBox_items.CurrentCell.RowIndex].Cells[0].Value);
                if (current_item_index > -1)
                {
                    checkBox_active.Checked = GSHOP.items[current_item_index].activate;
                    numericUpDown_itemID.Text = GSHOP.items[current_item_index].id.ToString();
                    numericUpDown_amount.Value = GSHOP.items[current_item_index].num;
                    textBox_name.Text = GSHOP.items[current_item_index].name.Name;
                    comboBox_surface.Text = GSHOP.items[current_item_index].icon.Name;
                    textBox_description.Text = GSHOP.items[current_item_index].description.Name;
                    change_preview();
                    if (saleOptionIndex > -1)
                    {
                        numericUpDown_price.Value = Convert.ToDecimal(GSHOP.items[current_item_index].sale_options[saleOptionIndex].price) / 100;
                        textBox_end_date.Value = REFDATE.AddSeconds(GSHOP.items[current_item_index].sale_options[saleOptionIndex].end_time);
                        textBox_duration.Text = GUtils.seconds_to_string(GSHOP.items[current_item_index].sale_options[saleOptionIndex].time);
                        textBox_start_date.Value = REFDATE.AddSeconds(GSHOP.items[current_item_index].sale_options[saleOptionIndex].start_time);
                        comboBox_type.SelectedIndex = GSHOP.items[current_item_index].sale_options[saleOptionIndex].type + 1;
                        textBox_day.Text = GSHOP.items[current_item_index].sale_options[saleOptionIndex].day.ToString();
                        comboBox_status.SelectedIndex = (int)GSHOP.items[current_item_index].sale_options[saleOptionIndex].status;
                        textBox_flags.Text = GSHOP.items[current_item_index].sale_options[saleOptionIndex].flag.ToString();
                    }
                    textBox_npc1.Text = GSHOP.items[current_item_index].npc1.ToString();
                    textBox_npc2.Text = GSHOP.items[current_item_index].npc2.ToString();
                    textBox_npc3.Text = GSHOP.items[current_item_index].npc3.ToString();
                    textBox_npc4.Text = GSHOP.items[current_item_index].npc4.ToString();
                    textBox_npc5.Text = GSHOP.items[current_item_index].npc5.ToString();
                    textBox_npc6.Text = GSHOP.items[current_item_index].npc6.ToString();
                    textBox_npc7.Text = GSHOP.items[current_item_index].npc7.ToString();
                    textBox_npc8.Text = GSHOP.items[current_item_index].npc8.ToString();

                    numericUpDown_gift_id.Value = GSHOP.items[current_item_index].idGift;
                    numericUpDown_gift_amount.Value = GSHOP.items[current_item_index].iGiftNum;
                    textBox_gift_duration.Text = GSHOP.items[current_item_index].iGiftTime.ToString();
                    numericUpDown_log_price.Value = Convert.ToDecimal(GSHOP.items[current_item_index].iLogPrice) / 100;
                }
                lockedCheck = false;
                progress_bar("Ready", 0, 0);
            }
        }
        private void change_preview()
        {
            String line = textBox_description.Text.Replace("\\r", Environment.NewLine).Replace("\\n", Environment.NewLine);
            //line.Replace("\r\n", "").Replace("\r", "").Replace("\n", "");
            string defaultcolor = "^FFFFFF";
            Color tmp = Color.FromArgb(int.Parse(defaultcolor.Substring(1, 6), NumberStyles.HexNumber));
            string[] blocks = line.Split(new char[] { '^' });
            this.richTextBox_PreviewText.Text = "";
            int index = 0;
            this.richTextBox_PreviewText.AppendText("Price: " + string.Format("{0:0.00}", (numericUpDown_price.Value)) + " Silver" + Environment.NewLine);
            this.richTextBox_PreviewText.Select(index, richTextBox_PreviewText.Text.Length);
            this.richTextBox_PreviewText.SelectionColor = Color.FromArgb(int.Parse("00ffff", NumberStyles.HexNumber));
            index = richTextBox_PreviewText.Text.Length;
            this.richTextBox_PreviewText.AppendText("Count: " + numericUpDown_amount.Value.ToString() + "" + Environment.NewLine);
            this.richTextBox_PreviewText.Select(index, richTextBox_PreviewText.Text.Length);
            this.richTextBox_PreviewText.SelectionColor = Color.WhiteSmoke;
            index = richTextBox_PreviewText.Text.Length;
            this.richTextBox_PreviewText.AppendText("Is Active: " + (checkBox_active.Checked ? "Yes" : "NO") + "" + Environment.NewLine);
            this.richTextBox_PreviewText.Select(index, richTextBox_PreviewText.Text.Length);
            this.richTextBox_PreviewText.SelectionColor = checkBox_active.Checked ? Color.Green : Color.Red;
            index = richTextBox_PreviewText.Text.Length;
            this.richTextBox_PreviewText.AppendText("Ctrl Type: " + comboBox_type.Items[comboBox_type.SelectedIndex].ToString() + "" + Environment.NewLine);
            this.richTextBox_PreviewText.Select(index, richTextBox_PreviewText.Text.Length);
            this.richTextBox_PreviewText.SelectionColor = Color.Yellow;
            index = richTextBox_PreviewText.Text.Length;
            if (ElementsEditor.eLC != null)
            {
                this.richTextBox_PreviewText.AppendText("Buy Limit: " + buy_times_limit.Text + "/" + buy_times_limit_mode.Items[buy_times_limit_mode.SelectedIndex].ToString() + "" + Environment.NewLine);
                this.richTextBox_PreviewText.Select(index, richTextBox_PreviewText.Text.Length);
                this.richTextBox_PreviewText.SelectionColor = Color.Violet;
                index = richTextBox_PreviewText.Text.Length;

                ItemDupe item = ElementsEditor.eLC.getItem(Convert.ToInt32(numericUpDown_itemID.Text.GetNumbers()));
                if (item != null)
                {
                    this.richTextBox_PreviewText.AppendText("Exist: Yes." + Environment.NewLine + Environment.NewLine);
                    this.richTextBox_PreviewText.Select(index, richTextBox_PreviewText.Text.Length);
                    this.richTextBox_PreviewText.SelectionColor = Color.Green;
                    index = richTextBox_PreviewText.Text.Length;
                }
                else
                {
                    this.richTextBox_PreviewText.AppendText("Exist: NO." + Environment.NewLine + Environment.NewLine);
                    this.richTextBox_PreviewText.Select(index, richTextBox_PreviewText.Text.Length);
                    this.richTextBox_PreviewText.SelectionColor = Color.Red;
                    index = richTextBox_PreviewText.Text.Length;
                }

            }
            else
            {
                this.richTextBox_PreviewText.AppendText("Buy Limit: " + buy_times_limit.Text + "/" + buy_times_limit_mode.Items[buy_times_limit_mode.SelectedIndex].ToString() + "" + Environment.NewLine);
                this.richTextBox_PreviewText.Select(index, richTextBox_PreviewText.Text.Length);
                this.richTextBox_PreviewText.SelectionColor = Color.Violet;
                index = richTextBox_PreviewText.Text.Length;
                this.richTextBox_PreviewText.AppendText("Please Load Elements.data!" + Environment.NewLine + Environment.NewLine);
                this.richTextBox_PreviewText.Select(index, richTextBox_PreviewText.Text.Length);
                this.richTextBox_PreviewText.SelectionColor = Color.Red;
                index = richTextBox_PreviewText.Text.Length;
            }
            this.richTextBox_PreviewText.AppendText("GAME DESCRIOTION:" + Environment.NewLine);
            this.richTextBox_PreviewText.Select(index, richTextBox_PreviewText.Text.Length);
            this.richTextBox_PreviewText.SelectionColor = Color.White;
            index = richTextBox_PreviewText.Text.Length;

            if (blocks.Length > 1)
            {
                int le1 = 0;
                
                le1 = (line.IndexOf('^', 0));
                this.richTextBox_PreviewText.AppendText(string.Format(line.Substring(0, le1)));
                this.richTextBox_PreviewText.Select(index, le1);
                this.richTextBox_PreviewText.SelectionColor = tmp;
                string result = "";

                if (blocks[0] != "")
                {
                    result += blocks[0];
                }

                int le = index;
                int st = 0;
                Color color = tmp;
                for (int i = 1; i < blocks.Length; i++)
                {
                    if (blocks[i] != "")
                    {
                        st = this.richTextBox_PreviewText.Text.Length;
                        try
                        {
                            if (blocks[i].Substring(0, 6).ToUpper() == "FFFFFF")
                            {
                                color = tmp;
                            }
                            else
                            {
                                color = Color.FromArgb(int.Parse(blocks[i].Substring(0, 6), NumberStyles.HexNumber));
                            }
                            this.richTextBox_PreviewText.AppendText(string.Format(blocks[i].Substring(6)));
                        }
                        catch
                        {
                            this.richTextBox_PreviewText.AppendText(string.Format("^" + blocks[i]));
                        }
                        le = this.richTextBox_PreviewText.Text.Length - st;
                        this.richTextBox_PreviewText.Select(st, le);
                        this.richTextBox_PreviewText.SelectionColor = color;
                    }
                }
            }
            else
            {
                this.richTextBox_PreviewText.Text = line;
                this.richTextBox_PreviewText.Select(index, this.richTextBox_PreviewText.Text.Length);
                this.richTextBox_PreviewText.SelectionColor = tmp;
            }
            this.richTextBox_PreviewText.Multiline = true;

        }
        private void edit_item(object sender, EventArgs e)
        {
            int fellback = -1;
            if (GSHOP != null && listBox_items.CurrentCell != null && listBox_items.CurrentCell.RowIndex > -1 && !lockedCheck)
            {
                DataGridViewSelectedRowCollection selected = listBox_items.SelectedRows;
                lockedCheck = true;

                for (int x = 0; x < listBox_items.SelectedRows.Count; x++)
                {
                    int idx = listBox_items.SelectedRows[x].Index;
                    int current_item_index = Convert.ToInt32(listBox_items.Rows[idx].Cells[0].Value);
                    int current_sale_index = saleOptionIndex;
                    if (fellback == -1)
                    {
                        fellback = idx;
                    }
                    if ((Control)sender == checkBox_active)
                    {
                        GSHOP.items[current_item_index].activate = checkBox_active.Checked;
                    }
                    if ((Control)sender == numericUpDown_itemID)
                    {
                        GSHOP.items[current_item_index].id = Convert.ToUInt32(numericUpDown_itemID.Text.GetNumbers());
                    }
                    if ((Control)sender == numericUpDown_amount)
                    {
                        GSHOP.items[current_item_index].num = Convert.ToUInt32(numericUpDown_amount.Value);
                        int value = (int)GSHOP.items[current_item_index].num;

                        if (GSHOP.items[current_item_index].name.Name.Contains("("))
                        {
                            if (value > 1)
                            {
                                Regex yourRegex = new Regex(@"\(([^\}]+)\)");
                                string result = yourRegex.Replace(GSHOP.items[current_item_index].name.Name, "(" + value.ToString() + ")");
                                GSHOP.items[current_item_index].name.Name = result;
                                listBox_items.Rows[idx].Cells[0].Value = GSHOP.items[current_item_index].shop_id;//ID
                                listBox_items.Rows[idx].Cells[1].Value = GSHOP.items[current_item_index].id;//ICON
                                listBox_items.Rows[idx].Cells[2].Value = result;//NAME
                                //textBox_name.Text = result;
                            }
                            else
                            {
                                Regex yourRegex = new Regex(@"\(([^\}]+)\)");
                                string result = yourRegex.Replace(GSHOP.items[current_item_index].name.Name, "");
                                GSHOP.items[current_item_index].name.Name = result.TrimEnd();
                                listBox_items.Rows[idx].Cells[0].Value = GSHOP.items[current_item_index].shop_id;//ID
                                listBox_items.Rows[idx].Cells[1].Value = GSHOP.items[current_item_index].id;//ICON
                                listBox_items.Rows[idx].Cells[2].Value = result.TrimEnd();//NAME
                            }
                        }
                        else
                        {
                            if (value > 1)
                            {
                                string valxxue = GSHOP.items[current_item_index].name.ToString();
                                GSHOP.items[current_item_index].name.Name = valxxue + (value > 1 ? " (" + GSHOP.items[current_item_index].num.ToString() + ")" : "");
                                listBox_items.Rows[idx].Cells[0].Value = GSHOP.items[current_item_index].shop_id;//ID
                                listBox_items.Rows[idx].Cells[1].Value = GSHOP.items[current_item_index].id;//ICON
                                listBox_items.Rows[idx].Cells[2].Value = valxxue + (value > 1 ? " (" + GSHOP.items[current_item_index].num.ToString() + ")" : "");//NAME
                            }

                        }


                    }
                    if ((Control)sender == textBox_name)
                    {
                        int value = (int)GSHOP.items[current_item_index].num;
                        string name = textBox_name.Text;
                        if (name.Contains("(") && value > 1)
                        {
                            Regex yourRegex = new Regex(@"\(([^\}]+)\)");
                            string result = yourRegex.Replace(name, value.ToString());
                            GSHOP.items[current_item_index].name.Name = result;
                            listBox_items.Rows[idx].Cells[0].Value = GSHOP.items[current_item_index].shop_id;//ID
                            listBox_items.Rows[idx].Cells[1].Value = GSHOP.items[current_item_index].id;//ICON
                            listBox_items.Rows[idx].Cells[2].Value = result;//NAME
                        }
                        else
                        {
                            if (value > 1)
                            {
                                string valxxue = textBox_name.Text.ToString();
                                GSHOP.items[current_item_index].name.Name = valxxue + (value > 1 ? " (" + GSHOP.items[current_item_index].num.ToString() + ")" : "");
                                listBox_items.Rows[idx].Cells[0].Value = GSHOP.items[current_item_index].shop_id;//ID
                                listBox_items.Rows[idx].Cells[1].Value = GSHOP.items[current_item_index].id;//ICON
                                listBox_items.Rows[idx].Cells[2].Value = valxxue + (value > 1 ? " (" + GSHOP.items[current_item_index].num.ToString() + ")" : "");//NAME
                            }
                            else
                            {
                                GSHOP.items[current_item_index].name.Name = textBox_name.Text;
                                listBox_items.Rows[idx].Cells[0].Value = GSHOP.items[current_item_index].shop_id;//ID
                                listBox_items.Rows[idx].Cells[1].Value = GSHOP.items[current_item_index].id;//ICON
                                listBox_items.Rows[idx].Cells[2].Value = textBox_name.Text;//NAME
                            }

                        }
                    }
                    if ((Control)sender == textBox_description)
                    {
                        GSHOP.items[current_item_index].description.Name = textBox_description.Text;
                        change_preview();
                    }
                    if ((Control)sender == comboBox_surface)
                    {
                        string text = comboBox_surface.Text;
                        GSHOP.items[current_item_index].icon.Name = text;
                        load_surface(null, null);
                    }
                    if ((Control)sender == numericUpDown_price)
                    {
                        GSHOP.items[current_item_index].sale_options[current_sale_index].price = (uint)Convert.ToInt32(100 * numericUpDown_price.Value);
                    }
                    if ((Control)sender == comboBox_type)
                    {
                        GSHOP.items[current_item_index].sale_options[current_sale_index].type = Convert.ToInt32(comboBox_type.SelectedIndex - 1);
                    }
                    if ((Control)sender == textBox_start_date)
                    {
                        GSHOP.items[current_item_index].sale_options[current_sale_index].start_time = (uint)(textBox_start_date.Value - REFDATE).TotalSeconds;
                    }
                    if ((Control)sender == textBox_end_date)
                    {
                        GSHOP.items[current_item_index].sale_options[current_sale_index].end_time = (uint)(textBox_end_date.Value - REFDATE).TotalSeconds;
                    }
                    if ((Control)sender == textBox_duration)
                    {
                        GSHOP.items[current_item_index].sale_options[current_sale_index].time = GUtils.string_to_seconds(textBox_duration.Text);
                    }
                    if ((Control)sender == textBox_day)
                    {
                        GSHOP.items[current_item_index].sale_options[current_sale_index].day = Convert.ToUInt32(textBox_day.Text);
                    }
                    if ((Control)sender == comboBox_status)
                    {
                        GSHOP.items[current_item_index].sale_options[current_sale_index].status = (uint)comboBox_status.SelectedIndex;
                    }
                    if ((Control)sender == textBox_flags)
                    {
                        GSHOP.items[current_item_index].sale_options[current_sale_index].flag = Convert.ToUInt32(textBox_flags.Text);
                    }
                    if ((Control)sender == numericUpDown_gift_id)
                    {
                        GSHOP.items[current_item_index].idGift = Convert.ToUInt32(numericUpDown_gift_id.Value);
                    }
                    if ((Control)sender == numericUpDown_gift_amount)
                    {
                        GSHOP.items[current_item_index].iGiftNum = Convert.ToUInt32(numericUpDown_gift_amount.Value);
                    }
                    if ((Control)sender == textBox_gift_duration)
                    {
                        GSHOP.items[current_item_index].iGiftTime = Convert.ToUInt32(textBox_gift_duration.Text);//string_to_seconds(textBox_gift_duration.Text);
                    }
                    if ((Control)sender == numericUpDown_log_price)
                    {
                        GSHOP.items[current_item_index].iLogPrice = Convert.ToUInt32(100 * numericUpDown_log_price.Value);
                    }
                }
            }
            lockedCheck = false;
        }

        private void load_surface(object sender, EventArgs e)
        {
            string surface = Path.GetDirectoryName(Application.ExecutablePath) + Path.DirectorySeparatorChar + "Configs" + Path.DirectorySeparatorChar + "Gshop" + Path.DirectorySeparatorChar + "Images" + Path.DirectorySeparatorChar + comboBox_surface.Text.ToLower();
            pictureBox_surface.BackgroundImage = DatabaseManager.Instance.getShopImage(surface.Replace("\\surfaces\\百宝阁", "").Replace("surfaces\\百宝阁", ""));
        }
        private int saleOptionIndex = 0;
        private int movingIndex;
        private IToolType customTooltype;
        private int autoloadedCount;
        private bool try155 = false;
        private bool try157 = false;

        private void change_item(object sender, EventArgs e)
        {
            if (lockedCheck) { return; }
            lockedCheck = true;
            showInfo = false;
            try
            {
                if (GSHOP != null && listBox_items.CurrentCell != null && listBox_items.CurrentCell.RowIndex > -1)
                {
                    int current_item_index = Convert.ToInt32(listBox_items.Rows[listBox_items.CurrentCell.RowIndex].Cells[0].Value);

                    if (current_item_index > -1)
                    {
                        lockedCheck = true;
                        checkBox_active.Checked = GSHOP.items[current_item_index].activate;
                        numericUpDown_itemID.Text = GSHOP.items[current_item_index].id.ToString();
                        numericUpDown_amount.Value = GSHOP.items[current_item_index].num;
                        try
                        {
                            buy_times_limit_mode.SelectedIndex = GSHOP.items[current_item_index].buy_times_limit_mode;
                        }
                        catch { }
                        buy_times_limit.Text = GSHOP.items[current_item_index].buy_times_limit.ToString();
                        textBox_name.Text = GSHOP.items[current_item_index].name.Name;
                        comboBox_surface.Text = GSHOP.items[current_item_index].icon.Name;
                        load_surface(null, null);
                        lockedCheck = true;
                        textBox_description.Text = GSHOP.items[current_item_index].description.Name;
                        
                        if (saleOptionIndex > -1)
                        {
                            numericUpDown_price.Value = Convert.ToDecimal(GSHOP.items[current_item_index].sale_options[saleOptionIndex].price) / 100;
                            textBox_end_date.Value = REFDATE.AddSeconds(GSHOP.items[current_item_index].sale_options[saleOptionIndex].end_time);
                            textBox_duration.Text = GUtils.seconds_to_string(GSHOP.items[current_item_index].sale_options[saleOptionIndex].time);
                            textBox_start_date.Value = REFDATE.AddSeconds(GSHOP.items[current_item_index].sale_options[saleOptionIndex].start_time);
                            comboBox_type.SelectedIndex = GSHOP.items[current_item_index].sale_options[saleOptionIndex].type + 1;
                            textBox_day.Text = GSHOP.items[current_item_index].sale_options[saleOptionIndex].day.ToString();
                            comboBox_status.SelectedIndex = (int)GSHOP.items[current_item_index].sale_options[saleOptionIndex].status;
                            textBox_flags.Text = GSHOP.items[current_item_index].sale_options[saleOptionIndex].flag.ToString();
                        }
                        lockedCheck = true;
                        textBox_npc1.Text = GSHOP.items[current_item_index].npc1.ToString();
                        textBox_npc2.Text = GSHOP.items[current_item_index].npc2.ToString();
                        textBox_npc3.Text = GSHOP.items[current_item_index].npc3.ToString();
                        textBox_npc4.Text = GSHOP.items[current_item_index].npc4.ToString();
                        textBox_npc5.Text = GSHOP.items[current_item_index].npc5.ToString();
                        textBox_npc6.Text = GSHOP.items[current_item_index].npc6.ToString();
                        textBox_npc7.Text = GSHOP.items[current_item_index].npc7.ToString();
                        textBox_npc8.Text = GSHOP.items[current_item_index].npc8.ToString();
                        lockedCheck = true;
                        numericUpDown_gift_id.Value = GSHOP.items[current_item_index].idGift;
                        numericUpDown_gift_amount.Value = GSHOP.items[current_item_index].iGiftNum;
                        textBox_gift_duration.Text = GSHOP.items[current_item_index].iGiftTime.ToString();
                        numericUpDown_log_price.Value = Convert.ToDecimal(GSHOP.items[current_item_index].iLogPrice) / 100;
                        if (TaskEditor.eLC != null && TaskEditor.eLC.getItem((int)GSHOP.items[current_item_index].id) != null)
                        {
                            selectInElementsToolStripMenuItem.Enabled = true;
                        }
                        else
                        {
                            selectInElementsToolStripMenuItem.Enabled = false;
                        }
                        change_preview();

                    }
                }
            }
            catch { }
            lockedCheck = false;
        }

        private void click_get_timestamp(object sender, EventArgs e)
        {

            uint current_timestamp = Convert.ToUInt32(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds);
            if (GSHOP != null)
            {
                GSHOP.timestamp = current_timestamp;
            }
            textBox_timestamp.Text = GUtils.timestamp_to_string(current_timestamp);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (sender != null)
                groupBox8.Text = ((Button)sender).Text;
            saleOptionIndex = 0;
            button1.ForeColor = Color.Gainsboro;
            button1.BackColor = Color.FromArgb(17, 17, 17);

            button2.ForeColor = Color.FromArgb(17, 17, 17);
            button2.BackColor = Color.Gainsboro;

            button3.ForeColor = Color.FromArgb(17, 17, 17);
            button3.BackColor = Color.Gainsboro;

            button4.ForeColor = Color.FromArgb(17, 17, 17);
            button4.BackColor = Color.Gainsboro;

            change_item(null, null);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            groupBox8.Text = ((Button)sender).Text;
            saleOptionIndex = 1;
            button1.ForeColor = Color.FromArgb(17, 17, 17);
            button1.BackColor = Color.Gainsboro;
            button2.ForeColor = Color.Gainsboro;
            button2.BackColor = Color.FromArgb(17, 17, 17);
            button3.ForeColor = Color.FromArgb(17, 17, 17);
            button3.BackColor = Color.Gainsboro;
            button4.ForeColor = Color.FromArgb(17, 17, 17);
            button4.BackColor = Color.Gainsboro;
            change_item(null, null);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            groupBox8.Text = ((Button)sender).Text;
            saleOptionIndex = 2;
            button1.ForeColor = Color.FromArgb(17, 17, 17);
            button1.BackColor = Color.Gainsboro;
            button2.ForeColor = Color.FromArgb(17, 17, 17);
            button2.BackColor = Color.Gainsboro;
            button3.ForeColor = Color.Gainsboro;
            button3.BackColor = Color.FromArgb(17, 17, 17);
            button4.ForeColor = Color.FromArgb(17, 17, 17);
            button4.BackColor = Color.Gainsboro;
            change_item(null, null);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            groupBox8.Text = ((Button)sender).Text;
            saleOptionIndex = 3;
            button1.ForeColor = Color.FromArgb(17, 17, 17);
            button1.BackColor = Color.Gainsboro;
            button2.ForeColor = Color.FromArgb(17, 17, 17);
            button2.BackColor = Color.Gainsboro;
            button3.ForeColor = Color.FromArgb(17, 17, 17);
            button3.BackColor = Color.Gainsboro;
            button4.ForeColor = Color.Gainsboro;
            button4.BackColor = Color.FromArgb(17, 17, 17);
            change_item(null, null);
        }

        private void build_contextMenus()
        {
            toolStripMenuItem_moveCat.DropDownItems.Clear();
            toolStripMenuItem_moveItem.DropDownItems.Clear();
            for (int i = 0; i < GSHOP.categories.Length; i++)
            {
                toolStripMenuItem_moveCat.DropDownItems.Add(GSHOP.categories[i].name.Name.Split(new char[] { '\0' })[0]);
                toolStripMenuItem_moveCat.DropDownItems[i].Click += move_subcat;
                toolStripMenuItem_moveItem.DropDownItems.Add(GSHOP.categories[i].name.Name.Split(new char[] { '\0' })[0]);
                for (int n = 0; n < GSHOP.categories[i].sub_cats.Count; n++)
                {
                    ((ToolStripMenuItem)toolStripMenuItem_moveItem.DropDownItems[i]).DropDownItems.Add(GSHOP.categories[i].sub_cats[n].Name.Split(new char[] { '\0' })[0]);
                    ((ToolStripMenuItem)toolStripMenuItem_moveItem.DropDownItems[i]).DropDownItems[n].Click += move_item;
                }
            }
        }

        private void click_deleteSubCat(Object sender, EventArgs e)
        {
            if (GSHOP != null && listBox_Cats.CurrentCell != null && listBox_SubCats.CurrentCell != null)
            {
                progress_bar("Deleting ...", 0, 100);
                int category_index = listBox_Cats.CurrentCell.RowIndex;
                int sub_index = listBox_SubCats.CurrentCell.RowIndex;
                for (int i = 0; i < GSHOP.items.Count; i++)
                {
                    progress_bar("Deleting ...", i, GSHOP.items.Count);
                    if (GSHOP.items[i].main_type == category_index)
                    {
                        if (GSHOP.items[i].sub_type == sub_index)
                        {
                            GSHOP.item_count--;
                            GSHOP.items[i].main_type = -1;
                            GSHOP.items[i].sub_type = -1;
                            GSHOP.items[i].deleted = true;
                        }

                        if (GSHOP.items[i].sub_type > sub_index)
                        {
                            GSHOP.items[i].sub_type--;
                        }
                    }
                }
                GSHOP.categories[category_index].sub_cats.Remove(sub_index);
                GSHOP.categories[category_index].sub_cats = reSortedDictionary(GSHOP.categories[category_index].sub_cats);
                GSHOP.categories[category_index].sub_cats_count = (uint)GSHOP.categories[category_index].sub_cats.Count;

                listBox_Cats_SelectedIndexChanged(null, null);
                progress_bar("Ready", 0, 0);
            }
        }

        private Dictionary<int, NameChar> reSortedDictionary(Dictionary<int, NameChar> data)
        {
            Dictionary<int, NameChar> datanew = new Dictionary<int, NameChar>();
            int i = 0;
            foreach (KeyValuePair<int, NameChar> entry in data)
            {
                datanew[i] = entry.Value;
                i++;
            }
            return datanew;
        }

        private void move_subcat(Object sender, EventArgs e)
        {
            if (GSHOP != null && listBox_Cats.CurrentCell != null && listBox_SubCats.CurrentCell != null)
            {
                int source_cat = listBox_Cats.CurrentCell.RowIndex;
                int source_subCat = listBox_SubCats.CurrentCell.RowIndex;
                int target_cat = toolStripMenuItem_moveCat.DropDownItems.IndexOf((ToolStripMenuItem)sender);

                if (GSHOP.categories[target_cat].sub_cats.Count < 9)
                {
                    int target_sub_cat = (int)GSHOP.categories[target_cat].sub_cats_count;
                    GSHOP.categories[target_cat].sub_cats.Add(9999999, GSHOP.categories[source_cat].sub_cats[source_subCat]);
                    GSHOP.categories[target_cat].sub_cats = reSortedDictionary(GSHOP.categories[target_cat].sub_cats);
                    GSHOP.categories[target_cat].sub_cats_count = (uint)GSHOP.categories[target_cat].sub_cats.Count;

                    for (int i = 0; i < GSHOP.items.Count; i++)
                    {
                        if (GSHOP.items[i].main_type == source_cat && GSHOP.items[i].sub_type == source_subCat)
                        {
                            GSHOP.items[i].main_type = target_cat;
                            GSHOP.items[i].sub_type = target_sub_cat;
                        }
                    }
                    // delete source subCat
                    GSHOP.categories[source_cat].sub_cats.Remove(source_subCat);
                    GSHOP.categories[source_cat].sub_cats = reSortedDictionary(GSHOP.categories[source_cat].sub_cats);
                    GSHOP.categories[source_cat].sub_cats_count = (uint)GSHOP.categories[source_cat].sub_cats.Count;
                    listBox_Cats_SelectedIndexChanged(null, null);

                    build_contextMenus();
                }
                else
                {
                    JMessageBox.Show(this, "Target already has 8 SubCategories!");
                }
            }
        }

        private void move_item(Object sender, EventArgs e)
        {
            if (GSHOP != null && listBox_items.CurrentCell != null && listBox_items.CurrentCell.RowIndex > -1)
            {
                int count_items = 0;
                listBox_items.Enabled = false;
                DataGridViewSelectedRowCollection selected = listBox_items.SelectedRows;
                for (int x = 0; x < listBox_items.SelectedRows.Count; x++)
                {
                    int index = listBox_items.SelectedRows[x].Index;
                    int current_item_index = Convert.ToInt32(listBox_items.Rows[index].Cells[0].Value);

                    for (int i = 0; i < toolStripMenuItem_moveItem.DropDownItems.Count; i++)
                    {
                        if (((ToolStripMenuItem)toolStripMenuItem_moveItem.DropDownItems[i]).DropDownItems.Contains((ToolStripMenuItem)sender))
                        {
                            GSHOP.items[current_item_index].main_type = i;
                            GSHOP.items[current_item_index].sub_type = ((ToolStripMenuItem)toolStripMenuItem_moveItem.DropDownItems[i]).DropDownItems.IndexOf((ToolStripMenuItem)((ToolStripMenuItem)sender));
                            break;
                        }
                    }
                    count_items++;
                }

                listBox_items.Enabled = true;
                JMessageBox.Show(this, "Moved : " + count_items);
                listBox_SubCats_SelectedIndexChanged(null, null);
            }

        }

        private void search(object sender, EventArgs e)
        {
            try
            {
                if (GSHOP != null)
                {
                    // Get the index of current selected item

                    int current_item_index = 0;
                    if (GSHOP != null && listBox_items.CurrentCell != null && listBox_SubCats.CurrentCell != null)
                    {
                        current_item_index = Convert.ToInt32(listBox_items.Rows[listBox_items.CurrentCell.RowIndex].Cells[0].Value) + 1;
                    }

                    for (int i = current_item_index; i < GSHOP.items.Count; i++)
                    {
                        progress_bar("Searching ...", current_item_index, GSHOP.items.Count);
                        if (GSHOP.items[i].main_type > -1 && GSHOP.items[i].sub_type > -1)
                        {
                            if (textBox_search.Text == GSHOP.items[i].id.ToString() || GSHOP.items[i].name.Name.Contains(textBox_search.Text))
                            {
                                //listBox_Cats.SelectedIndex = GSHOP.items[i].cat_index;
                                listBox_Cats.Rows[GSHOP.items[i].main_type].Selected = true;
                                // listBox_Cats.CurrentCell = listBox_items.Rows[GSHOP.items[i].main_type].Cells[0];
                                listBox_Cats_SelectedIndexChanged(null, null);
                                try
                                {
                                    listBox_SubCats.Rows[GSHOP.items[i].sub_type].Selected = true;
                                    listBox_SubCats.CurrentCell = listBox_SubCats.Rows[GSHOP.items[i].sub_type].Cells[0];
                                }
                                catch { }
                                listBox_SubCats_SelectedIndexChanged(null, null);
                                foreach (DataGridViewRow row in listBox_items.Rows)
                                {
                                    if (row.Cells[0].Value.ToString().Equals(GSHOP.items[i].shop_id.ToString()))
                                    {
                                        listBox_items.Rows[row.Index].Selected = true;
                                        listBox_items.CurrentCell = listBox_items.Rows[row.Index].Cells[0];
                                        break;
                                    }
                                }
                                progress_bar("Ready", 0, 0);
                                return;
                            }
                        }
                    }

                    current_item_index = 0;

                    for (int i = current_item_index; i < GSHOP.items.Count; i++)
                    {
                        progress_bar("Searching ...", current_item_index, GSHOP.items.Count);
                        if (GSHOP.items[i].main_type > -1 && GSHOP.items[i].sub_type > -1)
                        {
                            if (textBox_search.Text == GSHOP.items[i].id.ToString() || GSHOP.items[i].name.Name.Contains(textBox_search.Text))
                            {
                                listBox_Cats.Rows[GSHOP.items[i].main_type].Selected = true;
                                listBox_Cats.CurrentCell = listBox_items.Rows[GSHOP.items[i].main_type].Cells[0];
                                listBox_Cats_SelectedIndexChanged(null, null);
                                listBox_SubCats.Rows[GSHOP.items[i].sub_type].Selected = true;
                                listBox_SubCats.CurrentCell = listBox_SubCats.Rows[GSHOP.items[i].sub_type].Cells[0];
                                listBox_SubCats_SelectedIndexChanged(null, null);
                                foreach (DataGridViewRow row in listBox_items.Rows)
                                {
                                    if (row.Cells[0].Value.ToString().Equals(GSHOP.items[i].shop_id.ToString()))
                                    {
                                        listBox_items.Rows[row.Index].Selected = true;
                                        listBox_items.CurrentCell = listBox_items.Rows[row.Index].Cells[0];
                                        break;
                                    }
                                }
                                progress_bar("Ready", 0, 0);
                                return;
                            }
                        }
                    }
                    JMessageBox.Show(this, "Search reached end of List without result");
                    progress_bar("Ready", 0, 0);
                }
            }
            catch { progress_bar("Ready", 0, 0); }
        }

        private void click_addSubCat(object sender, EventArgs e)
        {
            if (GSHOP != null && listBox_Cats.CurrentCell != null)
            {
                if (GSHOP.categories[listBox_Cats.CurrentCell.RowIndex].sub_cats.Count < 9)
                {
                    NameChar name = new NameChar(128);
                    name.Name = "New";
                    GSHOP.categories[listBox_Cats.CurrentCell.RowIndex].sub_cats.Add(9999, name);
                    GSHOP.categories[listBox_Cats.CurrentCell.RowIndex].sub_cats = reSortedDictionary(GSHOP.categories[listBox_Cats.CurrentCell.RowIndex].sub_cats);
                    GSHOP.categories[listBox_Cats.CurrentCell.RowIndex].sub_cats_count = (uint)GSHOP.categories[listBox_Cats.CurrentCell.RowIndex].sub_cats.Count;
                    listBox_SubCats.Rows.Add("New");
                    listBox_SubCats.Rows[listBox_SubCats.Rows.Count - 1].Selected = true;
                    listBox_SubCats.CurrentCell = listBox_SubCats.Rows[listBox_SubCats.Rows.Count - 1].Cells[0];
                    build_contextMenus();
                }
                else
                {
                    JMessageBox.Show(this, "Maximum of 8 reached!");
                }
            }
        }

        private void change_subcat(object sender, EventArgs e)
        {
            if (GSHOP != null && listBox_Cats.CurrentCell != null && listBox_SubCats.CurrentCell != null)
            {
                listBox_items.Rows.Clear();
                if (GSHOP.items.ContainsKey(listBox_Cats.CurrentCell.RowIndex))
                {

                    current = GSHOP.items.Values.Where(x => x.main_type == listBox_Cats.CurrentCell.RowIndex && !x.deleted && x.sub_type == listBox_SubCats.CurrentCell.RowIndex).ToList();
                    listBox_items.RowCount = current.Count();

                }
            }
        }

        private void mouseUp_StopMove(object sender, MouseEventArgs e)
        {
            // this.//Cursor = Cursors.Default;
        }

        private void mouseDown_StartMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.//Cursor = System.Windows.Forms.Cursors.SizeNS;
                movingIndex = ((ListBox)sender).SelectedIndex;
            }
        }

        private void click_addItem(object sender, EventArgs e)
        {
            if (GSHOP != null && listBox_Cats.CurrentCell != null && listBox_SubCats.CurrentCell != null)
            {
                GSHOP.item_count++;
                Item item = new Item();
                item.main_type = listBox_Cats.CurrentCell.RowIndex;
                item.sub_type = listBox_SubCats.CurrentCell.RowIndex;
                max_item_id++;
                item.shop_id = GSHOP.items.Count;
                item.local_id = max_item_id;
                for (int n = 0; n < item.sale_options.Length; n++)
                {
                    item.sale_options[n] = new SaleOption();
                }
                GSHOP.items.Add(item.shop_id, item);
                GSHOP.items = this.resortItems(GSHOP.items);
                GSHOP.item_count = (uint)GSHOP.items.Count;
                listBox_SubCats_SelectedIndexChanged(null, null);
                listBox_items.Rows[listBox_items.Rows.Count - 1].Selected = true;
                listBox_items.CurrentCell = listBox_items.Rows[listBox_items.Rows.Count - 1].Cells[0];
            }
        }

        private Dictionary<int, Item> resortItems(Dictionary<int, Item> data)
        {
            Dictionary<int, Item> datanew = new Dictionary<int, Item>();
            int i = 0;
            foreach (KeyValuePair<int, Item> entry in data)
            {

                datanew[i] = entry.Value;
                datanew[i].shop_id = i;
                i++;
            }
            return datanew;
        }

        private void click_deleteItem(object sender, EventArgs e)
        {
            if (GSHOP != null && listBox_items.CurrentCell != null && listBox_items.CurrentCell.RowIndex > -1)
            {
                int savepos = listBox_items.CurrentCell.RowIndex;
                int count_items = 0;
                listBox_items.Enabled = false;
                lockedCheck = true;
                DataGridViewSelectedRowCollection selected = listBox_items.SelectedRows;
                for (int x = 0; x < listBox_items.SelectedRows.Count; x++)
                {

                    Application.DoEvents();
                    progress_bar("Deleteing ...", x, listBox_items.SelectedRows.Count);
                    int index = listBox_items.SelectedRows[x].Index;
                    int current_item_index = Convert.ToInt32(listBox_items.Rows[index].Cells[0].Value);
                    GSHOP.items[current_item_index].sub_type = -1;
                    GSHOP.items[current_item_index].main_type = -1;
                    GSHOP.items[current_item_index].deleted = true;
                    count_items++;
                }
                GSHOP.items = GSHOP.items.Where(pair => !pair.Value.deleted).ToDictionary(pair => pair.Key, pair => pair.Value);
                listBox_items.RowCount = 0;
                GSHOP.items = this.resortItems(GSHOP.items);
                current = GSHOP.items.Values.Where(x => x.main_type == listBox_Cats.CurrentCell.RowIndex && !x.deleted && x.sub_type == listBox_SubCats.CurrentCell.RowIndex).ToList();
                listBox_items.RowCount = current.Count();
                GSHOP.item_count = (uint)GSHOP.items.Count;
                lockedCheck = false;
                listBox_items.Enabled = true;
                listBox_SubCats_SelectedIndexChanged(null, null);
                progress_bar("Ready", 0, 0);
                listBox_items.Refresh();
                try
                {
                    listBox_items.Rows[savepos].Selected = true;
                    listBox_items.CurrentCell = listBox_items.Rows[savepos].Cells[0];
                    change_item(null, null);
                }
                catch { }


                JMessageBox.Show(this, "Deleted : " + count_items);
            }
            lockedCheck = false;
        }

        private void textBox_description_TextChanged(object sender, EventArgs e)
        {
            if (!lockedCheck)
            {
                change_preview();
            }
        }

        private void changeNPC(object sender, EventArgs e)
        {
            if (lockedCheck) { return; }
            if (GSHOP != null && listBox_items.CurrentCell != null && listBox_items.CurrentCell.RowIndex > -1)
            {
                try
                {
                    int current_item_index = Convert.ToInt32(listBox_items.Rows[listBox_items.CurrentCell.RowIndex].Cells[0].Value);
                    GSHOP.items[current_item_index].npc1 = UInt32.Parse(textBox_npc1.Text);
                    GSHOP.items[current_item_index].npc2 = UInt32.Parse(textBox_npc2.Text);
                    GSHOP.items[current_item_index].npc3 = UInt32.Parse(textBox_npc3.Text);
                    GSHOP.items[current_item_index].npc4 = UInt32.Parse(textBox_npc4.Text);
                    GSHOP.items[current_item_index].npc5 = UInt32.Parse(textBox_npc5.Text);
                    GSHOP.items[current_item_index].npc6 = UInt32.Parse(textBox_npc6.Text);
                    GSHOP.items[current_item_index].npc7 = UInt32.Parse(textBox_npc7.Text);
                    GSHOP.items[current_item_index].npc8 = UInt32.Parse(textBox_npc8.Text);
                }
                catch { }
            }
        }

        private void exportItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBox_items.CurrentCell == null)
            {
                progress_bar("Please select items to export!", 0, 0);
                return;
            }

            if (listBox_SubCats.CurrentCell == null)
            {
                progress_bar("Please select a subcategory!", 0, 0);
                return;
            }

            if (GSHOP == null)
            {
                progress_bar("Please load gshop.data!", 0, 0);
                return;
            }

            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Gshop Export (*.edx)|*.gsx";
            save.FileName = "GshopExport_items_" + listBox_items.SelectedRows.Count + ".gsx";
            int xe = listBox_items.CurrentCell.RowIndex;
            if (xe > -1 && save.ShowDialog() == DialogResult.OK && save.FileName != "")
            {
                try
                {
                    lockedCheck = true;

                    if (listBox_items.CurrentCell.RowIndex != -1)
                    {
                        Export export = new Export();
                        export.type = 1; //Elements data = 0 | Gshop = 1 
                        export.ListId = listBox_Cats.CurrentCell.RowIndex;
                        export.Version = listBox_SubCats.CurrentCell.RowIndex;
                        export.data = new SortedDictionary<int, object>(new ReverseComparer<int>(Comparer<int>.Default));
                        for (int i = 0; i < listBox_items.SelectedRows.Count; i++)
                        {
                            progress_bar("Exporting ...", i, listBox_items.SelectedRows.Count);
                            int index = listBox_items.SelectedRows[i].Index;
                            int current_item_index = Convert.ToInt32(listBox_items.Rows[index].Cells[0].Value);
                            export.data.Add(i, GSHOP.items[current_item_index]);
                        }
                        byte[] databytes = export.Serialize();
                        File.WriteAllBytes(save.FileName, databytes);
                    }
                    lockedCheck = false;
                }
                catch (Exception)
                {

                }
                progress_bar("Ready", 0, 0);
            }
            else
            {
                JMessageBox.Show(this, "Please select a item!");

            }
        }

        private void importItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GSHOP == null)
            {
                progress_bar("Please load gshop.data!", 0, 0);
                return;
            }

            if (listBox_SubCats.CurrentCell == null)
            {
                progress_bar("Please select a subcategory!", 0, 0);
                return;
            }


            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            // Set filter options and filter index.
            openFileDialog1.Filter = "Gshop Import File (*.gsx)|*.gsx|ElementData Export (*.edx)|*.edx";
            //openFileDialog1.FilterIndex = 1;
            //openFileDialog1.Multiselect = true;
            //int ltc = listBox_items.CurrentCell.RowIndex;
            // Process input if the user clicked OK.
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileExtension = Path.GetExtension(openFileDialog1.FileName);
                if (fileExtension == ".gsx")
                {
                    ///JMessageBox.Show(this, "gshop");
                    progress_bar("Importing ...", 0, 0);
                    Application.DoEvents();
                    Export obj = new Export(openFileDialog1.FileName);
                    int importid = int.MaxValue;
                    foreach (KeyValuePair<int, Object> entry in obj.data)
                    {
                        Item item = (Item)entry.Value;
                        importid--;
                        item.shop_id = importid;
                        item.main_type = listBox_Cats.CurrentCell.RowIndex;
                        item.sub_type = listBox_SubCats.CurrentCell.RowIndex;
                        GSHOP.items.Add(item.shop_id, item);
                    }
                    GSHOP.items = this.resortItems(GSHOP.items);
                    GSHOP.item_count = (uint)GSHOP.items.Count;
                    listBox_SubCats_SelectedIndexChanged(null, null);
                    listBox_items.Rows[listBox_items.Rows.Count - 1].Selected = true;
                    listBox_items.CurrentCell = listBox_items.Rows[listBox_items.Rows.Count - 1].Cells[0];
                }
                else
                {
                    progress_bar("Importing ...", 0, 0);
                    Application.DoEvents();
                    Export obj = new Export(openFileDialog1.FileName);
                    if (TaskEditor.eLC != null)
                    {
                        foreach (KeyValuePair<int, Object> entry in obj.data)
                        {
                            SortedList<int, object> data = (SortedList<int, object>)entry.Value;
                            //  eLC.Lists[obj.ListId].AddItem(obj.ListId, data);
                            int id_index = -1;
                            int name_index = -1;
                            for (int i = 0; i < TaskEditor.eLC.Lists[obj.ListId].elementFields.Length; i++)
                            {
                                if (TaskEditor.eLC.Lists[obj.ListId].elementFields[i] == "ID")
                                {
                                    id_index = i;
                                }
                                if (TaskEditor.eLC.Lists[obj.ListId].elementFields[i] == "Name")
                                {
                                    name_index = i;
                                }
                                if (id_index != -1 && name_index != -1)
                                {
                                    break;
                                }
                            }

                            int itemID = (int)data[id_index];
                            Encoding enc = Encoding.GetEncoding("Unicode");
                            string ItemName = enc.GetString((byte[])data[name_index]).Split('\0')[0];
                            GSHOP.item_count++;
                            Item item = new Item();
                            item.main_type = listBox_Cats.CurrentCell.RowIndex;
                            item.sub_type = listBox_SubCats.CurrentCell.RowIndex;
                            max_item_id++;
                            item.shop_id = GSHOP.items.Count;
                            item.local_id = max_item_id;
                            item.id = (uint)itemID;
                            item.name.Name = ItemName;
                            for (int n = 0; n < item.sale_options.Length; n++)
                            {
                                item.sale_options[n] = new SaleOption();
                            }
                            GSHOP.items.Add(item.shop_id, item);
                        }
                        GSHOP.items = this.resortItems(GSHOP.items);
                        GSHOP.item_count = (uint)GSHOP.items.Count;
                        listBox_SubCats_SelectedIndexChanged(null, null);
                        listBox_items.Rows[listBox_items.Rows.Count - 1].Selected = true;
                        listBox_items.CurrentCell = listBox_items.Rows[listBox_items.Rows.Count - 1].Cells[0];
                    }
                    else
                    {
                        JMessageBox.Show(this, "Please load elements.data");
                    }

                    GSHOP.items = this.resortItems(GSHOP.items);
                    GSHOP.item_count = (uint)GSHOP.items.Count;
                    listBox_SubCats_SelectedIndexChanged(null, null);
                    listBox_items.Rows[listBox_items.Rows.Count - 1].Selected = true;
                    listBox_items.CurrentCell = listBox_items.Rows[listBox_items.Rows.Count - 1].Cells[0];
                }

            }
            progress_bar("Ready", 0, 0);
        }

        private void button_autoDetect_Click(object sender, EventArgs e)
        {
            if (GSHOP == null)
            {
                progress_bar("Please load gshop.data!", 0, 0);
                return;
            }

            if (listBox_SubCats.CurrentCell == null)
            {
                progress_bar("Please select a subcategory!", 0, 0);
                return;
            }
            if (listBox_items.CurrentCell == null)
            {
                progress_bar("Please select a item!", 0, 0);
                return;
            }

            var CurrentCell = listBox_items.CurrentCell;
            //Cursor = Cursors.AppStarting;
            var dataGrid = listBox_items.SelectedRows;
            foreach (DataGridViewRow r in dataGrid)
            {
                int item = r.Index;
                int current_item_index = Convert.ToInt32(listBox_items.Rows[item].Cells[0].Value);
                int current_sale_index = saleOptionIndex;


                if (comboBox_dbSource.SelectedIndex < 1)
                {
                    String description = (String)Extensions.ItemDesc((int)GSHOP.items[current_item_index].id);
                    if (description != null)
                    {
                        description = description.Replace("\\r", " \\r");
                        GSHOP.items[current_item_index].description.Name = description;
                        textBox_description.Text = description;
                    }
                    edit_item(textBox_description, null);
                }
                else
                {
                    try
                    {
                        int index;
                        int length;
                        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www." + comboBox_dbSource.SelectedItem.ToString() + "/items/" + GSHOP.items[current_item_index].id);
                        request.Proxy = null;
                        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                        StreamReader wr = new StreamReader(response.GetResponseStream());
                        String content = wr.ReadToEnd();
                        wr.Close();
                        // Find Item Name
                        index = content.IndexOf("<th class=\"itemHeader\"") + 35;
                        if (index > 34)
                        {
                            length = content.IndexOf("<a href", index) - index;
                            String name = content.Substring(index, length);
                            // Remove span + color
                            if (name.Contains("<"))
                            {
                                name = name.Substring(name.IndexOf(">") + 1);
                                name = name.Substring(0, name.IndexOf("</"));
                            }
                            name = name.Replace("&#9734;", "★");
                            int value = Int32.Parse(GSHOP.items[current_item_index].num.ToString());
                            GSHOP.items[current_item_index].name.Name = name + (value > 1 ? " (" + GSHOP.items[current_item_index].num.ToString() + ")" : "");
                            //edit_item(textBox_name, null);
                        }
                        // Find if Item Contains Shop Info
                        index = content.IndexOf("<a href=\"shopitem/", index) + 18;
                        if (index > 18)
                        {
                            length = content.IndexOf("\">", index) - index;
                            String shop_id = content.Substring(index, length);
                            // Load Shop Description
                            request = (HttpWebRequest)WebRequest.Create("http://www." + comboBox_dbSource.SelectedItem.ToString() + "/shopitem/" + shop_id);
                            request.Proxy = null;
                            response = (HttpWebResponse)request.GetResponse();
                            wr = new StreamReader(response.GetResponseStream());
                            content = wr.ReadToEnd();
                            wr.Close();
                            index = content.IndexOf("<h3>Description</h3><p>") + 23;
                            if (index > 22)
                            {
                                length = content.IndexOf("</p>", index) - index;
                                String description = content.Substring(index, length);
                                description = description.Replace("<span style='color:", "");
                                description = description.Replace("#", "^");
                                description = description.Replace(";", "");
                                description = description.Replace("'>", "");
                                description = description.Replace("<br />", "\\r");
                                description = description.Replace("<br/>", "\\r");
                                description = description.Replace("<br>", "\\r");
                                description = description.Replace("</span>", "");
                                description = description.Replace("\\r", " \\r");
                                GSHOP.items[current_item_index].description.Name = description;
                                //textBox_description.Text = description;
                            }
                        }
                        edit_item(textBox_description, null);
                    }
                    catch (Exception ex)
                    {
                        JMessageBox.Show(this, "Connection Failed:" + ex);
                    }
                }

            }

            listBox_items.CurrentCell = null;
            listBox_items.CurrentCell = CurrentCell;
            //Cursor = Cursors.Default;
        }

        private void moveUplistBox_Cats(object sender, EventArgs e)
        {
            if (!lockedCheck && GSHOP != null && listBox_Cats.CurrentCell != null)
            {
                // Removing Event Handlers
                this.listBox_Cats.SelectionChanged -= change_cat;
                int movingIndex = listBox_Cats.CurrentCell.RowIndex;

                int target_index = listBox_Cats.CurrentCell.RowIndex;
                String direction = (sender as ToolStripMenuItem).Text;
                bool canContinue = false;
                if (direction == "Move Down")
                {
                    target_index++;
                }
                else
                {
                    target_index--;
                }
                if (target_index >= 0 && target_index <= 7)
                {
                    canContinue = true;
                }
                if (canContinue)
                {
                    Category movingCat = GSHOP.categories[movingIndex];
                    GSHOP.categories[movingIndex] = GSHOP.categories[target_index];
                    GSHOP.categories[target_index] = movingCat;
                    object movingListBoxItem = listBox_Cats.Rows[movingIndex].Cells[0].Value;
                    listBox_Cats.Rows[movingIndex].Cells[0].Value = listBox_Cats.Rows[target_index].Cells[0].Value;
                    listBox_Cats.Rows[target_index].Cells[0].Value = movingListBoxItem;
                    for (int i = 0; i < GSHOP.items.Count; i++)
                    {
                        if (GSHOP.items[i].main_type == movingIndex)
                        {
                            GSHOP.items[i].main_type = target_index;
                        }
                        else
                        {
                            if (GSHOP.items[i].main_type == target_index)
                            {
                                GSHOP.items[i].main_type = movingIndex;
                            }
                        }
                    }
                }
                else
                {
                    target_index = movingIndex;
                }
                // Adding Event Handlers
                listBox_Cats.Rows[target_index].Selected = true;
                listBox_Cats.CurrentCell = listBox_SubCats.Rows[target_index].Cells[0];
                this.listBox_Cats.SelectionChanged += change_cat;
                build_contextMenus();
            }
        }

        private void change_cat(object sender, EventArgs e)
        {
            if (GSHOP != null && listBox_Cats.CurrentCell != null)
            {
                listBox_SubCats.Rows.Clear();
                listBox_items.Rows.Clear();
                int SelectedIndex = listBox_Cats.CurrentCell.RowIndex;
                for (int i = 0; i < GSHOP.categories[SelectedIndex].sub_cats.Count; i++)
                {
                    if (GSHOP.categories[SelectedIndex].sub_cats[i].Name != null && GSHOP.categories[SelectedIndex].sub_cats[i].Name.Length > 0)
                        listBox_SubCats.Rows.Add(new object[] { GSHOP.categories[SelectedIndex].sub_cats[i].Name });
                    else
                        listBox_SubCats.Rows.Add(new object[] { "SubCat_" + i });
                }
            }

        }
        private void moveUplistBox_Sub_Cats(object sender, EventArgs e)
        {
            if (!lockedCheck && GSHOP != null && listBox_Cats.CurrentCell != null)
            {
                lockedCheck = true;
                // Removing Event Handlers
                this.listBox_SubCats.SelectionChanged -= change_subcat;
                int movingCatIndex = listBox_Cats.CurrentCell.RowIndex;
                int movingIndex = listBox_SubCats.CurrentCell.RowIndex;

                int target_index = listBox_SubCats.CurrentCell.RowIndex;
                String direction = (sender as ToolStripMenuItem).Text;
                bool canContinue = false;
                if (direction == "Move Down")
                {
                    target_index++;
                }
                else
                {
                    target_index--;
                }
                if (target_index >= 0 && target_index <= 7 && listBox_SubCats.Rows.Count > target_index)
                {
                    canContinue = true;
                }
                if (canContinue)
                {

                    // Swap categories
                    NameChar movingSubCat = GSHOP.categories[listBox_Cats.CurrentCell.RowIndex].sub_cats[movingIndex];
                    GSHOP.categories[listBox_Cats.CurrentCell.RowIndex].sub_cats[movingIndex] = GSHOP.categories[listBox_Cats.CurrentCell.RowIndex].sub_cats[target_index];
                    GSHOP.categories[listBox_Cats.CurrentCell.RowIndex].sub_cats[target_index] = movingSubCat;

                    object movingListBoxItem = listBox_SubCats.Rows[movingIndex].Cells[0].Value;
                    listBox_SubCats.Rows[movingIndex].Cells[0].Value = listBox_SubCats.Rows[target_index].Cells[0].Value;
                    listBox_SubCats.Rows[target_index].Cells[0].Value = movingListBoxItem;

                    for (int i = 0; i < GSHOP.items.Count; i++)
                    {
                        if (GSHOP.items[i].main_type == movingCatIndex)
                        {
                            if (GSHOP.items[i].sub_type == movingIndex)
                            {
                                GSHOP.items[i].sub_type = target_index;
                            }
                            else
                            {
                                if (GSHOP.items[i].sub_type == target_index)
                                {
                                    GSHOP.items[i].sub_type = movingIndex;
                                }
                            }
                        }
                    }


                }
                else
                {
                    target_index = movingIndex;
                }
                // Adding Event Handlers
                lockedCheck = false;
                listBox_Cats_SelectedIndexChanged(null, null);

            }
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

        private void listBox_items_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Control | Keys.C))
            {
                e.Handled = true;
                ExportItems();
            }
            else if (e.KeyData == (Keys.Control | Keys.V))
            {
                e.Handled = true;
                importItems();
            }
        }
        private void importItems()
        {
            if (GSHOP == null)
            {
                progress_bar("Please load gshop.data!", 0, 0);
                return;
            }

            if (listBox_SubCats.CurrentCell == null)
            {
                progress_bar("Please select a subcategory!", 0, 0);
                return;
            }

            Export exportdata = GetFromClipboard();
            if (exportdata == null)
            {
                JMessageBox.Show(this, "Nothing in clipboard!");
            }
            try
            {
                if (exportdata.type == 1)
                {
                    progress_bar("Importing ...", 0, 0);
                    Application.DoEvents();
                    int importid = int.MaxValue;
                    foreach (KeyValuePair<int, Object> entry in exportdata.data)
                    {
                        Item item = (Item)entry.Value;
                        importid--;
                        item.shop_id = importid;
                        item.main_type = listBox_Cats.CurrentCell.RowIndex;
                        item.sub_type = listBox_SubCats.CurrentCell.RowIndex;
                        GSHOP.items.Add(item.shop_id, item);
                    }


                    GSHOP.items = this.resortItems(GSHOP.items);
                    GSHOP.item_count = (uint)GSHOP.items.Count;
                    listBox_SubCats_SelectedIndexChanged(null, null);
                    listBox_items.Rows[listBox_items.Rows.Count - 1].Selected = true;
                    listBox_items.CurrentCell = listBox_items.Rows[listBox_items.Rows.Count - 1].Cells[0];
                }
                else
                {
                    progress_bar("Importing ...", 0, 0);
                    Application.DoEvents();
                    if (TaskEditor.eLC != null)
                    {
                        foreach (KeyValuePair<int, Object> entry in exportdata.data)
                        {
                            if (entry.Value is Export)
                            {
                                Export datax = (Export)entry.Value;
                                foreach (KeyValuePair<int, Object> entryx in datax.data)
                                {
                                    SortedList<int, object> data = (SortedList<int, object>)entryx.Value;
                                    int id_index = -1;
                                    int name_index = -1;
                                    for (int i = 0; i < TaskEditor.eLC.Lists[datax.ListId].elementFields.Length; i++)
                                    {
                                        if (TaskEditor.eLC.Lists[datax.ListId].elementFields[i] == "ID")
                                        {
                                            id_index = i;
                                        }
                                        if (TaskEditor.eLC.Lists[datax.ListId].elementFields[i] == "Name")
                                        {
                                            name_index = i;
                                        }
                                        if (id_index != -1 && name_index != -1)
                                        {
                                            break;
                                        }
                                    }

                                    int itemID = (int)data[id_index];
                                    Encoding enc = Encoding.GetEncoding("Unicode");
                                    string ItemName = enc.GetString((byte[])data[name_index]).Split('\0')[0];
                                    GSHOP.item_count++;
                                    Item item = new Item();
                                    item.main_type = listBox_Cats.CurrentCell.RowIndex;
                                    item.sub_type = listBox_SubCats.CurrentCell.RowIndex;
                                    max_item_id++;
                                    item.shop_id = GSHOP.items.Count;
                                    item.local_id = max_item_id;
                                    item.id = (uint)itemID;
                                    item.name.Name = ItemName;
                                    for (int n = 0; n < item.sale_options.Length; n++)
                                    {
                                        item.sale_options[n] = new SaleOption();
                                    }
                                    GSHOP.items.Add(item.shop_id, item);
                                }
                                GSHOP.items = this.resortItems(GSHOP.items);
                                GSHOP.item_count = (uint)GSHOP.items.Count;
                            }
                            else
                            {
                                SortedList<int, object> data = (SortedList<int, object>)entry.Value;
                                int id_index = -1;
                                int name_index = -1;
                                for (int i = 0; i < TaskEditor.eLC.Lists[exportdata.ListId].elementFields.Length; i++)
                                {
                                    if (TaskEditor.eLC.Lists[exportdata.ListId].elementFields[i] == "ID")
                                    {
                                        id_index = i;
                                    }
                                    if (TaskEditor.eLC.Lists[exportdata.ListId].elementFields[i] == "Name")
                                    {
                                        name_index = i;
                                    }
                                    if (id_index != -1 && name_index != -1)
                                    {
                                        break;
                                    }
                                }

                                int itemID = (int)data[id_index];
                                Encoding enc = Encoding.GetEncoding("Unicode");
                                string ItemName = enc.GetString((byte[])data[name_index]).Split('\0')[0];
                                GSHOP.item_count++;
                                Item item = new Item();
                                item.main_type = listBox_Cats.CurrentCell.RowIndex;
                                item.sub_type = listBox_SubCats.CurrentCell.RowIndex;
                                max_item_id++;
                                item.shop_id = GSHOP.items.Count;
                                item.local_id = max_item_id;
                                item.id = (uint)itemID;
                                item.name.Name = ItemName;
                                for (int n = 0; n < item.sale_options.Length; n++)
                                {
                                    item.sale_options[n] = new SaleOption();
                                }
                                GSHOP.items.Add(item.shop_id, item);
                                GSHOP.items = this.resortItems(GSHOP.items);
                                GSHOP.item_count = (uint)GSHOP.items.Count;
                            }

                        }
                        listBox_SubCats_SelectedIndexChanged(null, null);
                        listBox_items.Rows[listBox_items.Rows.Count - 1].Selected = true;
                        listBox_items.CurrentCell = listBox_items.Rows[listBox_items.Rows.Count - 1].Cells[0];
                    }
                    else
                    {
                        JMessageBox.Show(this, "Please load elements.data");
                    }

                    GSHOP.items = this.resortItems(GSHOP.items);
                    GSHOP.item_count = (uint)GSHOP.items.Count;
                    listBox_SubCats_SelectedIndexChanged(null, null);
                    listBox_items.Rows[listBox_items.Rows.Count - 1].Selected = true;
                    listBox_items.CurrentCell = listBox_items.Rows[listBox_items.Rows.Count - 1].Cells[0];
                }

            }
            catch { }
            progress_bar("Ready", 0, 0);
        }
        private void ExportItems()
        {
            if (listBox_items.CurrentCell == null)
            {
                progress_bar("Please select items to export!", 0, 0);
                return;
            }

            if (listBox_SubCats.CurrentCell == null)

                if (GSHOP == null)
                {
                    progress_bar("Please load gshop.data!", 0, 0);
                    return;
                }
            int xe = listBox_items.CurrentCell.RowIndex;
            if (xe > -1)
            {
                try
                {
                    lockedCheck = true;

                    if (listBox_items.CurrentCell.RowIndex != -1)
                    {
                        Export export = new Export
                        {
                            ListId = listBox_Cats.CurrentCell.RowIndex,
                            Version = listBox_SubCats.CurrentCell.RowIndex,
                            type = 1, //Elements data = 0 | Gshop = 1 
                            data = new SortedDictionary<int, object>(new ReverseComparer<int>(Comparer<int>.Default))
                        };
                        for (int i = 0; i < listBox_items.SelectedRows.Count; i++)
                        {
                            progress_bar("Exporting ...", i, listBox_items.SelectedRows.Count);
                            int index = listBox_items.SelectedRows[i].Index;
                            int current_item_index = Convert.ToInt32(listBox_items.Rows[index].Cells[0].Value);
                            export.data.Add(i, GSHOP.items[current_item_index]);
                        }
                        CopyToClipboard(export);
                    }
                    lockedCheck = false;
                }
                catch (Exception)
                {

                }
                progress_bar("Ready", 0, 0);
            }
            else
            {
                JMessageBox.Show(this, "Please select a item!");

            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.games-shark.com/en/");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (GSHOP == null)
            {
                progress_bar("Please load gshop.data!", 0, 0);
                return;
            }

            if (listBox_SubCats.CurrentCell == null)
                if (listBox_items.CurrentCell == null)
                {
                    progress_bar("Please select a item!", 0, 0);
                    return;
                }

            //Cursor = Cursors.AppStarting;
            var dataGrid = listBox_items.SelectedRows;
            foreach (DataGridViewRow r in dataGrid)
            {
                int item = r.Index;
                int current_item_index = Convert.ToInt32(listBox_items.Rows[item].Cells[0].Value);
                int current_sale_index = saleOptionIndex;
                try
                {
                    int value = int.Parse(textBox1.Text);
                    GSHOP.items[current_item_index].sale_options[current_sale_index].price = (uint)Convert.ToInt32(100 * value);

                }
                catch { }
            }
            listBox_items.CurrentCell = null;
            //Cursor = Cursors.Default;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (GSHOP == null)
            {
                progress_bar("Please load gshop.data!", 0, 0);
                return;
            }

            if (listBox_SubCats.CurrentCell == null)
                if (listBox_items.CurrentCell == null)
                {
                    progress_bar("Please select a item!", 0, 0);
                    return;
                }

            //Cursor = Cursors.AppStarting;
            var dataGrid = listBox_items.SelectedRows;
            foreach (DataGridViewRow r in dataGrid)
            {
                int item = r.Index;
                int current_item_index = Convert.ToInt32(listBox_items.Rows[item].Cells[0].Value);
                int current_sale_index = saleOptionIndex;
                GSHOP.items[current_item_index].sale_options[current_sale_index].type = -1;
            }
            listBox_items.CurrentCell = null;
            //Cursor = Cursors.Default;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (GSHOP == null)
            {
                progress_bar("Please load gshop.data!", 0, 0);
                return;
            }

            if (listBox_SubCats.CurrentCell == null)
                if (listBox_items.CurrentCell == null)
                {
                    progress_bar("Please select a item!", 0, 0);
                    return;
                }

            //Cursor = Cursors.AppStarting;
            var dataGrid = listBox_items.SelectedRows;
            foreach (DataGridViewRow r in dataGrid)
            {
                int item = r.Index;
                int current_item_index = Convert.ToInt32(listBox_items.Rows[item].Cells[0].Value);
                int current_sale_index = saleOptionIndex;
                GSHOP.items[current_item_index].sale_options[current_sale_index].type = 0;
            }
            listBox_items.CurrentCell = null;
            //Cursor = Cursors.Default;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (GSHOP == null)
            {
                progress_bar("Please load gshop.data!", 0, 0);
                return;
            }

            if (listBox_SubCats.CurrentCell == null)
                if (listBox_items.CurrentCell == null)
                {
                    progress_bar("Please select a item!", 0, 0);
                    return;
                }

            //Cursor = Cursors.AppStarting;
            var dataGrid = listBox_items.SelectedRows;
            foreach (DataGridViewRow r in dataGrid)
            {
                int item = r.Index;
                int current_item_index = Convert.ToInt32(listBox_items.Rows[item].Cells[0].Value);
                int current_sale_index = saleOptionIndex;
                GSHOP.items[current_item_index].sale_options[current_sale_index].status = 1;
            }
            listBox_items.CurrentCell = null;
            //Cursor = Cursors.Default;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (GSHOP == null)
            {
                progress_bar("Please load gshop.data!", 0, 0);
                return;
            }

            if (listBox_SubCats.CurrentCell == null)
                if (listBox_items.CurrentCell == null)
                {
                    progress_bar("Please select a item!", 0, 0);
                    return;
                }

            //Cursor = Cursors.AppStarting;
            var dataGrid = listBox_items.SelectedRows;
            foreach (DataGridViewRow r in dataGrid)
            {
                int item = r.Index;
                int current_item_index = Convert.ToInt32(listBox_items.Rows[item].Cells[0].Value);
                int current_sale_index = saleOptionIndex;
                GSHOP.items[current_item_index].sale_options[current_sale_index].status = 3;
            }
            listBox_items.CurrentCell = null;
            //Cursor = Cursors.Default;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            //  textBox2
            if (GSHOP == null)
            {
                progress_bar("Please load gshop.data!", 0, 0);
                return;
            }

            if (listBox_SubCats.CurrentCell == null)
                if (listBox_items.CurrentCell == null)
                {
                    progress_bar("Please select a item!", 0, 0);
                    return;
                }

            //Cursor = Cursors.AppStarting;
            var dataGrid = listBox_items.SelectedRows;
            double value = 0;
            if (!double.TryParse(MultiplyValueText.Text, out value))
            {
                //Cursor = Cursors.Default;
                return;
            }
            if (value == 0)
            {
                //Cursor = Cursors.Default;
                return;
            }
            for (int i = 0; i < GSHOP.items.Count; i++)
            {
                for (int s = 0; s < GSHOP.items[i].sale_options.Length; s++)
                {
                    if (GSHOP.items[i].sale_options[s].price != 0)
                    {
                        GSHOP.items[i].sale_options[s].price = Convert.ToUInt32(GSHOP.items[i].sale_options[s].price / value);
                    }
                }
            }

            listBox_items.CurrentCell = null;
            //Cursor = Cursors.Default;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            //  textBox2
            if (GSHOP == null)
            {
                progress_bar("Please load gshop.data!", 0, 0);
                return;
            }

            if (listBox_SubCats.CurrentCell == null)
                if (listBox_items.CurrentCell == null)
                {
                    progress_bar("Please select a item!", 0, 0);
                    return;
                }

            //Cursor = Cursors.AppStarting;
            var dataGrid = listBox_items.SelectedRows;
            double value = 0;
            if (!double.TryParse(MultiplyValueText.Text, out value))
            {
                //Cursor = Cursors.Default;
                return;
            }
            if (value == 0)
            {
                //Cursor = Cursors.Default;
                return;
            }
            for (int i = 0; i < GSHOP.items.Count; i++)
            {
                for (int s = 0; s < GSHOP.items[i].sale_options.Length; s++)
                {
                    if (GSHOP.items[i].sale_options[s].price != 0)
                    {
                        GSHOP.items[i].sale_options[s].price = Convert.ToUInt32(GSHOP.items[i].sale_options[s].price * value);
                    }
                }
            }

            listBox_items.CurrentCell = null;
            //Cursor = Cursors.Default;
        }

        private void SaveQUSClick(object sender, EventArgs e)
        {
            if (versionSelector.SelectedIndex == 3)
            {
                JMessageBox.Show(this, "Currently not Available!");
                return;
            }
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "GShop (*.data)|*.data|All Files (*.*)|*.*";
            if (GSHOP != null && save.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                saveShop(save.FileName, true, version);
                string filename = Path.GetFileNameWithoutExtension(save.FileName);
                string resultString = Regex.Match(filename, @"\d+").Value;
                int num = 0;
                bool hasNumber = Int32.TryParse(resultString, out num);
                string path = "";
                if (hasNumber)
                {
                    path = Path.GetDirectoryName(save.FileName) + "\\gshopsev" + num + ".data";
                }
                else
                {
                    path = Path.GetDirectoryName(save.FileName) + "\\gshopsev.data";
                }
                saveShop(path, false, version);
            }
        }

        private void SaveUSClick(object sender, EventArgs e)
        {
            if (versionSelector.SelectedIndex == 3)
            {
                JMessageBox.Show(this, "Currently not Available!");
                return;
            }
            int versx = 7;
            switch (versionSelector.SelectedIndex)
            {
                case 0:
                    versx = 155;
                    break;
                case 1:
                    versx = 127;
                    break;
                case 2:
                    versx = 7;
                    break;
            }
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "GShop (*.data)|*.data|All Files (*.*)|*.*";
            if (GSHOP != null && save.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                saveShop(save.FileName, true, versx);
                string filename = Path.GetFileNameWithoutExtension(save.FileName);
                string resultString = Regex.Match(filename, @"\d+").Value;
                int num = 0;
                bool hasNumber = Int32.TryParse(resultString, out num);
                string path = "";
                if (hasNumber)
                {
                    path = Path.GetDirectoryName(save.FileName) + "\\gshopsev" + num + ".data";
                }
                else
                {
                    path = Path.GetDirectoryName(save.FileName) + "\\gshopsev.data";
                }
                saveShop(path, false, versx);
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (GSHOP == null)
            {
                progress_bar("Please load gshop.data!", 0, 0);
                return;
            }

            if (listBox_SubCats.CurrentCell == null)
                if (listBox_items.CurrentCell == null)
                {
                    progress_bar("Please select a item!", 0, 0);
                    return;
                }

            //Cursor = Cursors.AppStarting;
            var dataGrid = listBox_items.SelectedRows;
            foreach (DataGridViewRow r in dataGrid)
            {
                int item = r.Index;
                int current_item_index = Convert.ToInt32(listBox_items.Rows[item].Cells[0].Value);
                int current_sale_index = saleOptionIndex;
                GSHOP.items[current_item_index].sale_options[current_sale_index].status = 0;
            }
            listBox_items.CurrentCell = null;
            //Cursor = Cursors.Default;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            int someOtherInt = Convert.ToInt32(numericUpDown_itemID.Text.ToString().GetNumbers());
            if (TaskEditor.eLC != null && TaskEditor.eLC.getItem(someOtherInt) != null)
            {
                ItemDupe item = TaskEditor.eLC.getItem(someOtherInt);
                MainProgram.getInstance().goToElementIndex(item);
            }
        }

        private void globalUpdateField(object sender, EventArgs e)
        {
            int replaced = 0;
            string equality = jTextBox1.Text;
            string replaceWith = replaceWithTextBox.Text;
            bool isMatchValue = equality != null && equality.Length > 0 && equality.Equals("*");
            int countReplaced = 0;
            #region ONLY SELECTEDD
            if (checkBox1.Checked)
            {
                //Only selected
                int upType = fieldscomboBox.SelectedIndex;
                if (GSHOP == null)
                {
                    progress_bar("Please load gshop.data!", 0, 0);
                    return;
                }

                if (listBox_SubCats.CurrentCell == null)
                {
                    progress_bar("Please select a subcategory!", 0, 0);
                    return;
                }
                if (listBox_items.CurrentCell == null)
                {
                    progress_bar("Please select a item!", 0, 0);
                    return;
                }
                countReplaced = listBox_items.SelectedRows.Count;
                //Cursor = Cursors.AppStarting;
                var dataGrid = listBox_items.SelectedRows;
                foreach (DataGridViewRow r in dataGrid)
                {
                    try
                    {
                        int item = r.Index;
                        int i = Convert.ToInt32(listBox_items.Rows[item].Cells[0].Value);
                        if (upType == 0)//Cant
                        {
                            int val = 0;
                            bool trypar = int.TryParse(replaceWith, out val);
                            if (trypar)
                            {
                                if (isMatchValue)
                                {
                                    GSHOP.items[i].num = Convert.ToUInt32(val);
                                    replaced++;
                                }
                                else
                                {
                                    GSHOP.items[i].num = Convert.ToUInt32(GSHOP.items[i].num.ToString().Equals(equality) ? val : (int)GSHOP.items[i].num);
                                    if (GSHOP.items[i].num.ToString().Equals(equality))
                                        replaced++;
                                }
                            }
                            continue;
                        }
                        if (upType == 3)//Duration
                        {
                            int val = 0;
                            bool trypar = int.TryParse(replaceWith, out val);
                            if (trypar)
                            {
                                if (isMatchValue)
                                {
                                    GSHOP.items[i].iGiftTime = Convert.ToUInt32(val);
                                    replaced++;
                                }
                                else
                                {
                                    GSHOP.items[i].iGiftTime = Convert.ToUInt32(GSHOP.items[i].iGiftTime.ToString().Equals(equality) ? val : (int)GSHOP.items[i].iGiftTime);
                                    if (GSHOP.items[i].iGiftTime.ToString().Equals(equality))
                                        replaced++;
                                }
                            }
                            continue;
                        }
                        int s = saleOptionIndex;
                        switch (upType)
                        {
                            case 1://Activation Date
                                GSHOP.items[i].sale_options[s].start_time = GUtils.string_to_timestamp(replaceWith);
                                replaced++;
                                break;
                            case 2://Expire Date
                                GSHOP.items[i].sale_options[s].end_time = GUtils.string_to_timestamp(replaceWith);
                                replaced++;
                                break;
                            case 4://Day
                                int val = 0;
                                bool trypar = int.TryParse(replaceWith, out val);
                                if (trypar)
                                {
                                    GSHOP.items[i].sale_options[s].day = Convert.ToUInt32(val);
                                    replaced++;
                                }
                                break;
                            case 5://Price
                                bool tryparx = int.TryParse(replaceWith, out val);
                                if (tryparx)
                                {
                                    if (isMatchValue)
                                    {
                                        GSHOP.items[i].sale_options[s].price = Convert.ToUInt32(val);
                                        replaced++;
                                    }
                                    else
                                    {
                                        //GSHOP.items[i].sale_options[s].price = Convert.ToUInt32(GSHOP.items[i].sale_options[s].price.ToString().Equals(equality) ? val : (int)GSHOP.items[i].sale_options[s].price);
                                        if (GSHOP.items[i].sale_options[s].price == Convert.ToUInt32(equality))
                                        {
                                            GSHOP.items[i].sale_options[s].price = Convert.ToUInt32(val);
                                            replaced++;
                                        }

                                    }
                                }
                                break;

                        }
                    }
                    catch { }
                }

                listBox_items.CurrentCell = null;
                //Cursor = Cursors.Default;
            }
            #endregion
            else
            #region ALL SHOPE
            {
                //All
                int upType = fieldscomboBox.SelectedIndex;
                if (GSHOP == null)
                {
                    progress_bar("Please load gshop.data!", 0, 0);
                    return;
                }

                if (listBox_SubCats.CurrentCell == null)
                {
                    progress_bar("Please select a subcategory!", 0, 0);
                    return;
                }
                if (listBox_items.CurrentCell == null)
                {
                    progress_bar("Please select a item!", 0, 0);
                    return;
                }
                countReplaced = GSHOP.items.Count;
                //Cursor = Cursors.AppStarting;
                int current_item_index = Convert.ToInt32(listBox_items.Rows[listBox_items.CurrentCell.RowIndex].Cells[0].Value);
                for (int i = 0; i < GSHOP.items.Count; i++)
                {
                    try
                    {
                        if (upType == 0)//Cant
                        {
                            int val = 0;
                            bool trypar = int.TryParse(replaceWith, out val);
                            if (trypar)
                            {
                                if (isMatchValue)
                                {
                                    GSHOP.items[i].num = Convert.ToUInt32(val);
                                    replaced++;
                                }
                                else
                                {
                                    GSHOP.items[i].num = Convert.ToUInt32(GSHOP.items[i].num.ToString().Equals(equality) ? val : (int)GSHOP.items[i].num);
                                    if (GSHOP.items[i].num.ToString().Equals(equality))
                                        replaced++;
                                }
                            }
                            continue;
                        }
                        if (upType == 3)//Duration
                        {
                            int val = 0;
                            bool trypar = int.TryParse(replaceWith, out val);
                            if (trypar)
                            {
                                if (isMatchValue)
                                {
                                    GSHOP.items[i].iGiftTime = Convert.ToUInt32(val);
                                    replaced++;
                                }
                                else
                                {
                                    GSHOP.items[i].iGiftTime = Convert.ToUInt32(GSHOP.items[i].iGiftTime.ToString().Equals(equality) ? val : (int)GSHOP.items[i].iGiftTime);
                                    if (GSHOP.items[i].iGiftTime.ToString().Equals(equality))
                                        replaced++;
                                }
                            }
                            continue;
                        }
                        //  for (int s = 0; s < GSHOP.items[i].sale_options.Length; s++)
                        // {
                        int s = saleOptionIndex;
                        switch (upType)
                        {
                            case 1://Activation Date
                                GSHOP.items[i].sale_options[s].start_time = GUtils.string_to_timestamp(replaceWith);
                                replaced++;
                                break;
                            case 2://Expire Date
                                GSHOP.items[i].sale_options[s].end_time = GUtils.string_to_timestamp(replaceWith);
                                replaced++;
                                break;
                            case 4://Day
                                int val = 0;
                                bool trypar = int.TryParse(replaceWith, out val);
                                if (trypar)
                                {
                                    GSHOP.items[i].sale_options[s].day = Convert.ToUInt32(val);
                                    replaced++;
                                }
                                break;
                            case 5://Price
                                bool tryparx = int.TryParse(replaceWith, out val);
                                if (tryparx)
                                {
                                    if (isMatchValue)
                                    {
                                        GSHOP.items[i].sale_options[s].price = Convert.ToUInt32(val);
                                        replaced++;
                                    }
                                    else
                                    {
                                        if (GSHOP.items[i].sale_options[s].price == Convert.ToUInt32(equality))
                                        {
                                            GSHOP.items[i].sale_options[s].price = Convert.ToUInt32(val);
                                            replaced++;
                                        }
                                    }
                                }
                                break;
                        }
                    }
                    //  }
                    catch { }
                }
                #endregion

                listBox_items.CurrentCell = null;
                //Cursor = Cursors.Default;
            }
            JMessageBox.Show(this, "Updated: " + replaced + "/" + countReplaced + " items.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            //  textBox2
            if (GSHOP == null)
            {
                progress_bar("Please load gshop.data!", 0, 0);
                return;
            }

            if (listBox_SubCats.CurrentCell == null)
                if (listBox_items.CurrentCell == null)
                {
                    progress_bar("Please select a item!", 0, 0);
                    return;
                }
            lockedCheck = true;
            //Cursor = Cursors.AppStarting;
            for (int i = 0; i < GSHOP.items.Count; i++)
            {
                GSHOP.items[i].sale_options[saleOptionIndex].type = -1;
            }

            listBox_items.CurrentCell = null;
            //Cursor = Cursors.Default;
            lockedCheck = false;
        }

        private void button19_Click(object sender, EventArgs e)
        {

            //  textBox2
            if (GSHOP == null)
            {
                progress_bar("Please load gshop.data!", 0, 0);
                return;
            }

            if (listBox_SubCats.CurrentCell == null)
                if (listBox_items.CurrentCell == null)
                {
                    progress_bar("Please select a item!", 0, 0);
                    return;
                }
            lockedCheck = true;
            //Cursor = Cursors.AppStarting;
            var dataGrid = listBox_items.SelectedRows;
            for (int i = 0; i < GSHOP.items.Count; i++)
            {
                //  for (int s = 0; s < GSHOP.items[i].sale_options.Length; s++)
                //  {
                GSHOP.items[i].sale_options[saleOptionIndex].type = 0;
                // }
            }

            listBox_items.CurrentCell = null;
            //Cursor = Cursors.Default;
            lockedCheck = false;
        }

        private void rename_cat(object sender, DataGridViewCellEventArgs e)
        {
            if (listBox_Cats.CurrentCell != null)
            {
                GSHOP.categories[listBox_Cats.CurrentCell.RowIndex].name.Name = listBox_Cats.Rows[listBox_Cats.CurrentCell.RowIndex].Cells[0].Value.ToString();
                build_contextMenus();
            }
        }

        private void GameShopEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Program.StandAlone)
            {
                if (e.CloseReason == CloseReason.UserClosing)
                {
                    showInfo = false;
                    e.Cancel = true;
                    MainProgram.getInstance().ShowShopEditor(null, null);
                }
            }
            else
            {
                MainProgram.getInstance().ExitInvoke();
            }
        }

        private void rename_subcat(object sender, DataGridViewCellEventArgs e)
        {
            if (listBox_Cats.CurrentCell != null && listBox_SubCats.CurrentCell != null && !lockedCheck)
            {
                lockedCheck = true;

                GSHOP.categories[listBox_Cats.CurrentCell.RowIndex].sub_cats[e.RowIndex].Name = listBox_SubCats.Rows[e.RowIndex].Cells[0].Value.ToString();
                build_contextMenus();
                lockedCheck = false;
            }
        }

        private void listBox_items_CellValueNeeded(object sender, DataGridViewCellValueEventArgs data)
        {
            lockedCheck = true;
            if (GSHOP != null)
            {
                if (current.Count > 0)
                {

                    switch (data.ColumnIndex)
                    {
                        case 0:
                            data.Value = current[data.RowIndex].shop_id;
                            listBox_items.Rows[data.RowIndex].ReadOnly = true;
                            break;
                        case 1:
                            data.Value = current[data.RowIndex].id;
                            break;
                        case 2:
                            data.Value = current[data.RowIndex].name.Name;
                            break;
                    }
                }
            }
            lockedCheck = false;
        }
        private bool locked = false;
        private void jPictureBox4_Click(object sender, EventArgs e)
        {
            if (GSHOP != null && listBox_items.CurrentCell != null && !locked)
            {
                locked = true;
                GshopImageView giv = new GshopImageView();
                giv.ShowDialog(this);
                if (GshopImageView.selectedItem.Length > 0)
                {
                    comboBox_surface.Text = "surfaces\\百宝阁\\" + GshopImageView.selectedItem;
                    // edit_item(comboBox_surface, null);
                    locked = false;
                    GshopImageView.selectedItem = "";
                }
            }
            locked = false;
        }

        private void buy_times_limit_Leave(object sender, EventArgs e)
        {
            if (lockedCheck) { return; }
            if (GSHOP != null && listBox_items.CurrentCell != null && listBox_items.CurrentCell.RowIndex > -1)
            {
                try
                {
                    int current_item_index = Convert.ToInt32(listBox_items.Rows[listBox_items.CurrentCell.RowIndex].Cells[0].Value);
                    GSHOP.items[current_item_index].buy_times_limit = Int32.Parse(buy_times_limit.Text);
                }
                catch { }
            }
        }

        private void buy_times_limit_mode_Leave(object sender, EventArgs e)
        {
            if (lockedCheck) { return; }
            if (GSHOP != null && listBox_items.CurrentCell != null && listBox_items.CurrentCell.RowIndex > -1)
            {
                try
                {
                    int current_item_index = Convert.ToInt32(listBox_items.Rows[listBox_items.CurrentCell.RowIndex].Cells[0].Value);
                    GSHOP.items[current_item_index].buy_times_limit_mode = buy_times_limit_mode.SelectedIndex;
                }
                catch { }
            }
        }

        private void versionSelector_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog load = new OpenFileDialog();
                load.Filter = "GShop (*.data)|*.data|All Files (*.*)|*.*";
                if (load.ShowDialog() == System.Windows.Forms.DialogResult.OK && File.Exists(load.FileName))
                {
                    loadedFileName = load.FileName;
                    OpenShop(load.FileName, 155, false, false);
                }
            }
            catch { }
        }

        private void sevToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog load = new OpenFileDialog();
                load.Filter = "GShop (*.data)|*.data|All Files (*.*)|*.*";
                if (load.ShowDialog() == System.Windows.Forms.DialogResult.OK && File.Exists(load.FileName))
                {
                    loadedFileName = load.FileName;
                    OpenShop(load.FileName, 7, false, false);
                }
            }
            catch { }
        }

        private void sevToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog load = new OpenFileDialog();
                load.Filter = "GShop (*.data)|*.data|All Files (*.*)|*.*";
                if (load.ShowDialog() == System.Windows.Forms.DialogResult.OK && File.Exists(load.FileName))
                {
                    loadedFileName = load.FileName;
                    OpenShop(load.FileName, 127, false, false);
                }
            }
            catch { }
        }

        private void listBox_items_DragEnter(object sender, DragEventArgs e)
        {
            if (GSHOP == null)
            {
                progress_bar("Please load gshop.data!", 0, 0);
                return;
            }

            if (listBox_SubCats.CurrentCell == null)
            {
                progress_bar("Please select a subcategory!", 0, 0);
                return;
            }

            e.Effect = DragDropEffects.Copy;
        }

        private bool isDraging = false;
        private void listBox_items_DragOver(object sender, DragEventArgs e)
        {
            if (isDraging)
                return;
            if (GSHOP == null)
            {
                progress_bar("Please load gshop.data!", 0, 0);
                return;
            }

            if (listBox_SubCats.CurrentCell == null)
            {
                progress_bar("Please select a subcategory!", 0, 0);
                return;
            }
            DialogResult res = JMessageBox.Show(this, "Do you want to copy items here?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.No)
                return;

            Export exportdata = GetFromClipboard();
            if (exportdata == null)
            {
                JMessageBox.Show(this, "Nothing in clipboard!");
            }
            try
            {
                isDraging = true;
                if (exportdata.type == 1)
                {
                    progress_bar("Importing ...", 0, 0);
                    Application.DoEvents();
                    int importid = int.MaxValue;
                    foreach (KeyValuePair<int, Object> entry in exportdata.data)
                    {
                        Item item = (Item)entry.Value;
                        importid--;
                        item.shop_id = importid;
                        item.main_type = listBox_Cats.CurrentCell.RowIndex;
                        item.sub_type = listBox_SubCats.CurrentCell.RowIndex;
                        GSHOP.items.Add(item.shop_id, item);
                    }


                    GSHOP.items = this.resortItems(GSHOP.items);
                    GSHOP.item_count = (uint)GSHOP.items.Count;
                    listBox_SubCats_SelectedIndexChanged(null, null);
                    listBox_items.Rows[listBox_items.Rows.Count - 1].Selected = true;
                    listBox_items.CurrentCell = listBox_items.Rows[listBox_items.Rows.Count - 1].Cells[0];
                }
                else
                {
                    progress_bar("Importing ...", 0, 0);
                    Application.DoEvents();
                    if (TaskEditor.eLC != null)
                    {
                        foreach (KeyValuePair<int, Object> entry in exportdata.data)
                        {
                            SortedList<int, object> data = (SortedList<int, Object>)entry.Value;
                            //  eLC.Lists[obj.ListId].AddItem(obj.ListId, data);
                            int id_index = -1;
                            int name_index = -1;
                            for (int i = 0; i < TaskEditor.eLC.Lists[exportdata.ListId].elementFields.Length; i++)
                            {
                                if (TaskEditor.eLC.Lists[exportdata.ListId].elementFields[i] == "ID")
                                {
                                    id_index = i;
                                }
                                if (TaskEditor.eLC.Lists[exportdata.ListId].elementFields[i] == "Name")
                                {
                                    name_index = i;
                                }
                                if (id_index != -1 && name_index != -1)
                                {
                                    break;
                                }
                            }

                            int itemID = (int)data[id_index];
                            Encoding enc = Encoding.GetEncoding("Unicode");
                            string ItemName = enc.GetString((byte[])data[name_index]).Split('\0')[0];
                            GSHOP.item_count++;
                            Item item = new Item();
                            item.main_type = listBox_Cats.CurrentCell.RowIndex;
                            item.sub_type = listBox_SubCats.CurrentCell.RowIndex;
                            max_item_id++;
                            item.shop_id = GSHOP.items.Count;
                            item.local_id = max_item_id;
                            item.id = (uint)itemID;
                            item.name.Name = ItemName;
                            for (int n = 0; n < item.sale_options.Length; n++)
                            {
                                item.sale_options[n] = new SaleOption();
                            }
                            GSHOP.items.Add(item.shop_id, item);
                        }
                        GSHOP.items = this.resortItems(GSHOP.items);
                        GSHOP.item_count = (uint)GSHOP.items.Count;
                        listBox_SubCats_SelectedIndexChanged(null, null);
                        listBox_items.Rows[listBox_items.Rows.Count - 1].Selected = true;
                        listBox_items.CurrentCell = listBox_items.Rows[listBox_items.Rows.Count - 1].Cells[0];
                    }
                    else
                    {
                        JMessageBox.Show(this, "Please load elements.data");
                    }

                    GSHOP.items = this.resortItems(GSHOP.items);
                    GSHOP.item_count = (uint)GSHOP.items.Count;
                    listBox_SubCats_SelectedIndexChanged(null, null);
                    listBox_items.Rows[listBox_items.Rows.Count - 1].Selected = true;
                    listBox_items.CurrentCell = listBox_items.Rows[listBox_items.Rows.Count - 1].Cells[0];
                }

            }
            catch { }
            progress_bar("Ready", 0, 0);
            isDraging = false;
        }

        private void listBox_items_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (lockedCheck) return;

            if (Time.time > MouseEnterTime && !showInfo)
            {
                try
                {
                    if (customTooltype != null)
                        customTooltype.Close();
                }
                catch { }
                if (e.ColumnIndex >= 0 && e.ColumnIndex == 1 && e.RowIndex > -1)
                {
                    InfoTool ift = null;
                    try
                    {
                        int xe = e.RowIndex;
                        int Id = Convert.ToInt32(this.listBox_items.Rows[e.RowIndex].Cells[1].Value);
                        if (Id > 0)
                        {
                            ift = Extensions.GetItemProps2byId(Id, 0);
                        }
                        if (ift == null)
                        {
                            string text = Extensions.GetItemProps(Id, 0);
                            text += Extensions.ItemDesc(Id);
                            this.listBox_items.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = text;
                        }
                        else
                        {
                            ift.description = Extensions.ColorClean(Extensions.ItemDesc(Id));
                            customTooltype = new IToolType(ift);
                            customTooltype.Show();
                            showInfo = true;
                        }
                    }
                    catch
                    {
                    }
                }
            }
        }
        private float MouseEnterTime = 0;
        private bool showInfo = false;
        public bool isAutoOpen = false;
        public string autoOpenPath = "";

        static DateTime REFDATE = new DateTime(1970, 01, 01);

        private void listBox_items_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (lockedCheck) return;

            if (e.ColumnIndex >= 0 && e.ColumnIndex == 1 && e.RowIndex > -1)
            {
                MouseEnterTime = Time.time + 0.1f;
            }
        }

        private void listBox_items_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (customTooltype != null)
            {
                customTooltype.Close();

            }
            showInfo = false;
        }

        private void GameShopEditor_Shown(object sender, EventArgs e)
        {
            if (isAutoOpen)
            {
                try
                {
                    try153 = false;
                    try136 = false;
                    try155 = false;
                    lockedCheck = true;
                    autoloadedCount = 0;
                    loadedFileName = autoOpenPath;
                    GSHOP = null;
                    GC.Collect();
                    autoDetectVersion(autoOpenPath);
                    tabControl1.SelectedIndex = 0;
                }
                catch { }
            }
        }

        private void GameShopEditor_Load(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void deleteIfNotExistInShopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GSHOP == null)
            {
                progress_bar("Please load gshop.data!", 0, 0);
                return;
            }

            if (listBox_SubCats.CurrentCell == null)
            {
                progress_bar("Please select a subcategory!", 0, 0);
                return;
            }
            if (listBox_items.CurrentCell == null)
            {
                progress_bar("Please select a item!", 0, 0);
                return;
            }

            var CurrentCell = listBox_items.CurrentCell;
            //Cursor = Cursors.AppStarting;
            var dataGrid = listBox_items.SelectedRows;
            foreach (DataGridViewRow r in dataGrid)
            {
                int item = r.Index;
                int current_item_index = Convert.ToInt32(listBox_items.Rows[item].Cells[0].Value);
                int current_sale_index = saleOptionIndex;


                if (comboBox_dbSource.SelectedIndex < 1)
                {
                    String description = (String)Extensions.ItemDesc((int)GSHOP.items[current_item_index].id);
                    if (description != null)
                    {
                        description = description.Replace("\\r", " \\r");
                        GSHOP.items[current_item_index].description.Name = description;
                        textBox_description.Text = description;
                    }
                    edit_item(textBox_description, null);
                }
                else
                {
                    try
                    {
                        int index;
                        int length;
                        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www." + comboBox_dbSource.SelectedItem.ToString() + "/items/" + GSHOP.items[current_item_index].id);
                        request.Proxy = null;
                        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                        StreamReader wr = new StreamReader(response.GetResponseStream());
                        String content = wr.ReadToEnd();
                        wr.Close();
                        // Find Item Name
                        index = content.IndexOf("<th class=\"itemHeader\"") + 35;
                        if (index > 34)
                        {
                            length = content.IndexOf("<a href", index) - index;
                            String name = content.Substring(index, length);
                            // Remove span + color
                            if (name.Contains("<"))
                            {
                                name = name.Substring(name.IndexOf(">") + 1);
                                name = name.Substring(0, name.IndexOf("</"));
                            }
                            name = name.Replace("&#9734;", "★");
                            int value = Int32.Parse(GSHOP.items[current_item_index].num.ToString());
                            GSHOP.items[current_item_index].name.Name = name + (value > 1 ? " (" + GSHOP.items[current_item_index].num.ToString() + ")" : "");
                            //edit_item(textBox_name, null);
                        }
                        string start = @"<strong>Price</strong>";
                        string end = @"</p>";
                        String databetween = content.GetBetween(start, end).Trim().Split('\t')[0];
                        start = "<strong>Amount</strong>";
                        end = "</p>";
                        String databetweenx = content.GetBetween(start, end).Trim().Split('\t')[0];
                        if (databetween.Contains("This item may be unavailable in shop for now"))
                        {
                            GSHOP.items[current_item_index].sub_type = -1;
                            GSHOP.items[current_item_index].main_type = -1;
                            GSHOP.items[current_item_index].deleted = true;
                        }
                        else
                        {
                            string gprice = "";
                            string sprice = "";
                            string num = databetweenx.GetNumbers();
                            if (databetween.Contains("<span style=\"color:#ffdc50\">Gold</span>") && databetween.Contains("<span style=\"color:#88ffff\">Silver</span>"))
                            {
                                //GOLD AND SILVER
                                start = @":";
                                end = "<span style=\"color:#ffdc50\">Gold</span>";
                                gprice = databetween.GetBetween(start, end).Trim().Split('\t')[0];
                                start = "<span style=\"color:#ffdc50\">Gold</span>";
                                end = "<span style=\"color:#88ffff\">Silver</span>";
                                sprice = databetween.GetBetween(start, end).Trim().Split('\t')[0];
                            }
                            else if (databetween.Contains("<span style=\"color:#ffdc50\">Gold</span>") && !databetween.Contains("<span style=\"color:#88ffff\">Silver</span>"))
                            {
                                //ONLY GOLD
                                start = @":";
                                end = "<span style=\"color:#ffdc50\">Gold</span>";
                                gprice = databetween.GetBetween(start, end).Trim().Split('\t')[0];
                            }
                            else if (!databetween.Contains("<span style=\"color:#ffdc50\">Gold</span>") && databetween.Contains("<span style=\"color:#88ffff\">Silver</span>"))
                            {
                                //ONLY SILVER
                                start = @":";
                                end = "<span style=\"color:#88ffff\">Silver</span>";
                                sprice = databetween.GetBetween(start, end).Trim().Split('\t')[0];
                            }
                            uint gold = 0;
                            uint silver = 0;
                            uint numx = 0;
                            bool isGoldPrice = uint.TryParse(gprice, out gold);
                            bool isSilverPrice = uint.TryParse(sprice, out silver);
                            bool hasNum = uint.TryParse(num, out numx);
                            if (hasNum)
                            {
                                GSHOP.items[current_item_index].num = numx;
                            }
                            if (isGoldPrice && isSilverPrice)
                            {
                                GSHOP.items[current_item_index].sale_options[0].price = uint.Parse(gprice + sprice);

                            }
                            else if (isGoldPrice && !isSilverPrice)
                            {
                                GSHOP.items[current_item_index].sale_options[0].price = gold * 100;
                            }
                            else if (!isGoldPrice && isSilverPrice)
                            {
                                GSHOP.items[current_item_index].sale_options[0].price = silver;
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        JMessageBox.Show(this, "Connection Failed:" + ex);
                    }
                }

            }

            listBox_items.RowCount = 0;
            GSHOP.items = GSHOP.items.Where(pair => !pair.Value.deleted).ToDictionary(pair => pair.Key, pair => pair.Value);
            GSHOP.items = this.resortItems(GSHOP.items);
            current = GSHOP.items.Values.Where(x => x.main_type == listBox_Cats.CurrentCell.RowIndex && !x.deleted && x.sub_type == listBox_SubCats.CurrentCell.RowIndex).ToList();
            listBox_items.RowCount = current.Count();
            GSHOP.item_count = (uint)GSHOP.items.Count;
            lockedCheck = false;
            listBox_items.Enabled = true;
            listBox_SubCats_SelectedIndexChanged(null, null);
            progress_bar("Ready", 0, 0);
            listBox_items.Refresh();
            try
            {
                listBox_items.Rows[0].Selected = true;
                listBox_items.CurrentCell = listBox_items.Rows[0].Cells[0];
                change_item(null, null);
            }
            catch { }
        }

        private void removeInexistentItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GSHOP == null)
            {
                progress_bar("Please load gshop.data!", 0, 0);
                return;
            }

            if (ElementsEditor.eLC == null)
            {
                progress_bar("Please load elements.data", 0, 0);
                return;
            }
            lockedCheck = true;
            int deleted_count = 0;
            for (int current_item_index = 0; current_item_index < GSHOP.items.Count; current_item_index++)
            {
                ItemDupe item = ElementsEditor.eLC.getItem((int)GSHOP.items[current_item_index].id);
                if (item == null)
                {
                    GSHOP.items[current_item_index].sub_type = -1;
                    GSHOP.items[current_item_index].main_type = -1;
                    GSHOP.items[current_item_index].deleted = true;
                    deleted_count++;
                }
            }

            listBox_items.RowCount = 0;
            GSHOP.items = GSHOP.items.Where(pair => !pair.Value.deleted).ToDictionary(pair => pair.Key, pair => pair.Value);
            GSHOP.items = this.resortItems(GSHOP.items);
            current = GSHOP.items.Values.Where(x => x.main_type == listBox_Cats.CurrentCell.RowIndex && !x.deleted && x.sub_type == listBox_SubCats.CurrentCell.RowIndex).ToList();
            listBox_items.RowCount = current.Count();
            GSHOP.item_count = (uint)GSHOP.items.Count;
            lockedCheck = false;
            listBox_items.Enabled = true;
            listBox_SubCats_SelectedIndexChanged(null, null);
            progress_bar("Ready", 0, 0);
            listBox_items.Refresh();
            try
            {
                listBox_items.Rows[0].Selected = true;
                listBox_items.CurrentCell = listBox_items.Rows[0].Cells[0];
                change_item(null, null);
            }
            catch { }
            JMessageBox.Show(this, "Deleted: " + deleted_count+" items left:"+ GSHOP.items.Count);
        }

        class ShopItemEquality
        {
            public uint id;
            public uint Count;
        }

        private void autoFixShopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GSHOP == null)
            {
                progress_bar("Please load gshop.data!", 0, 0);
                return;
            }

            if (ElementsEditor.eLC == null)
            {
                progress_bar("Please load elements.data", 0, 0);
                return;
            }
            RenameForm form = new RenameForm("Enter price for zero priced items.");
            DialogResult result = form.ShowDialog(this);
            lockedCheck = true;
            HashSet<ShopItemEquality> items = new HashSet<ShopItemEquality>();
            uint price = 1;
            int deleted_count = 0;
            int Fix = 0;
            if (result == DialogResult.OK)
                price = uint.Parse(RenameForm.value.GetNumbers());
            for (int current_item_index = 0; current_item_index < GSHOP.items.Count; current_item_index++)
            {

                ItemDupe item = ElementsEditor.eLC.getItem((int)GSHOP.items[current_item_index].id);
                if (item == null 
                    || item != null && item.listID == ElementsEditor.eLC.RecipeListIndex
                    || item != null && item.listID == ElementsEditor.eLC.TitleListIndex
                    || item != null && item.listID == ElementsEditor.eLC.ConversationListIndex
                    || item != null && item.listID == ElementsEditor.eLC.CraftServiceListIndex
                    || item != null && item.listID == ElementsEditor.eLC.EngraveServiceListIndex
                    || item != null && item.listID == ElementsEditor.eLC.ForcesListIndex
                    || item != null && item.listID == ElementsEditor.eLC.MineEssenceList
                    )
                {
                    GSHOP.items[current_item_index].sub_type = -1;
                    GSHOP.items[current_item_index].main_type = -1;
                    GSHOP.items[current_item_index].deleted = true;
                    deleted_count++;
                }
                else
                {
                    bool hasSet = false;
                    GSHOP.items[current_item_index].sale_options[1].type = 0;
                    GSHOP.items[current_item_index].sale_options[2].type = 0;
                    GSHOP.items[current_item_index].sale_options[3].type = 0;
                    GSHOP.items[current_item_index].sale_options[1].price = 0;
                    GSHOP.items[current_item_index].sale_options[2].price = 0;
                    GSHOP.items[current_item_index].sale_options[3].price = 0;
                    GSHOP.items[current_item_index].sale_options[1].status = 0;
                    GSHOP.items[current_item_index].sale_options[2].status = 0;
                    GSHOP.items[current_item_index].sale_options[3].status = 0;

                    if (GSHOP.items[current_item_index].sale_options[0].type != -1)
                    {
                        GSHOP.items[current_item_index].sale_options[0].type = -1;
                        Fix++;
                        hasSet = true;
                    }

                    if (GSHOP.items[current_item_index].num > item.maxCount || 0 == GSHOP.items[current_item_index].num)
                    {
                        if (item.maxCount > 0)
                            GSHOP.items[current_item_index].num = (uint)item.maxCount;
                        else
                            GSHOP.items[current_item_index].num = 1;


                        if (!hasSet)
                        {
                            hasSet = true;
                            Fix++;
                        }
                    }
                    if (GSHOP.items[current_item_index].sale_options[0].price == 0)
                    {
                        GSHOP.items[current_item_index].sale_options[0].price = price * GSHOP.items[current_item_index].num;
                        if (!hasSet)
                            Fix++;
                    }
                    ShopItemEquality shopItemEquality = new ShopItemEquality();
                    shopItemEquality.id = GSHOP.items[current_item_index].id;
                    shopItemEquality.Count = GSHOP.items[current_item_index].num;
                    if (!items.Add(shopItemEquality))
                    {
                        GSHOP.items[current_item_index].sub_type = -1;
                        GSHOP.items[current_item_index].main_type = -1;
                        GSHOP.items[current_item_index].deleted = true;
                        deleted_count++;
                        continue;
                    }
                }
            }

            listBox_items.RowCount = 0;
            GSHOP.items = GSHOP.items.Where(pair => !pair.Value.deleted).ToDictionary(pair => pair.Key, pair => pair.Value);
            GSHOP.items = this.resortItems(GSHOP.items);
            current = GSHOP.items.Values.Where(x => x.main_type == listBox_Cats.CurrentCell.RowIndex && !x.deleted && x.sub_type == listBox_SubCats.CurrentCell.RowIndex).ToList();
            listBox_items.RowCount = current.Count();
            GSHOP.item_count = (uint)GSHOP.items.Count;
            lockedCheck = false;
            listBox_items.Enabled = true;
            listBox_SubCats_SelectedIndexChanged(null, null);
            progress_bar("Ready", 0, 0);
            listBox_items.Refresh();
            try
            {
                listBox_items.Rows[0].Selected = true;
                listBox_items.CurrentCell = listBox_items.Rows[0].Cells[0];
                change_item(null, null);
            }
            catch { }
            JMessageBox.Show(this, "Deleted: " + deleted_count + " Fixed:" + Fix);
            lockedCheck = false;
        }
    }
}
