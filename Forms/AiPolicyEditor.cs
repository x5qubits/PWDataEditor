using AIPolicy;
using AIPolicy.Input;
using AIPolicy.Operations;
using ElementEditor;
using ElementEditor.classes;
using JHUI.Forms;
using PWDataEditorPaied.AIPolicy.Conditions;
using PWDataEditorPaied.AIPolicy.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;
using JHUI;
using System.Xml;
using System.Xml.Serialization;
using static AIPolicy.Operations.Operation;

namespace PWDataEditorPaied
{
    public partial class AiPolicyEditor : JForm
    {
        private AI Data;

        internal delegate void UpdateProgressDelegate(String value, int min, int max);
        internal event UpdateProgressDelegate progress_bar2;
        public AiPolicyEditor()
        {
            InitializeComponent();
            this.MinimizeBox = Program.SHOWMINIMIZEBUTTON;
            jPictureBox2.Visible = label1.Visible = jLabel2.Visible = pathLabel.Visible = version_label.Visible = false;
           // EnumUtils.LoadHemCombo(this.TypeOperationCB, typeof(Operation.Name));
           //  EnumUtils.LoadHemCombo(this.TypeTargetCB, typeof(Target.Name));

        }

        public void progress_bar(String value, int min, int max)
        {
            if (progress_bar2 != null)
            {
                progress_bar2(value, min, max);
            }
        }

        private bool Frozen { get; set; }

        private Policy CurrentPolicy { get; set; }

        private Trigger CurrentTrigger { get; set; }

        private Operation CurrentOperation { get; set; }

        private List<Trigger> ShownTriggers { get; set; }

        private List<Operation> ShownOperations { get; set; }
        public object OriginalParameter { get; set; }
        public object OriginalTarget { get; set; }
        public string FileName { get; set; }

        private void OpenBtn_Click(object sender, EventArgs e)
        {
            if (this.OpenDialog.ShowDialog() != DialogResult.OK)
                return;
            if (Path.GetExtension(this.OpenDialog.FileName) == "xml")
            {
                var serializer = new XmlSerializer(typeof(Policy[]));
                Policy[] datax = null;
                using (var reader = XmlReader.Create(this.OpenDialog.FileName))
                {
                    datax = (Policy[])serializer.Deserialize(reader);
                }
            }
            else
            {

                this.Data = FileManager.LoadAI(this.OpenDialog.FileName);
            }

            if (this.Data == null)
            {
                int num = (int)JMessageBox.Show(this, "Unable to open file. Make sure you are trying to load a correct file.");
            }
            else
            {
                FileName = this.OpenDialog.FileName;
                //if (this.Visible)
                //    NewMainForm.getInstance().setText("P.W.D.E. - " + this.OpenDialog.FileName);
                //this.TypeTargetCB.DataSource = (object)Enumerable.ToList<string>((IEnumerable<string>)Enum.GetNames(typeof(Target.Name)));
                this.version_label.Text = Trigger.EstimatedVersion.ToString();
                pathLabel.Text = OpenDialog.FileName;
                jPictureBox2.Visible = label1.Visible = jLabel2.Visible = pathLabel.Visible = version_label.Visible = true;
                this.CurrentPolicy = null;
                this.CurrentTrigger = null;
                this.CurrentOperation = null;
                this.LoadData();
                this.SetPolicy(1);
            }
        }

        private void LoadData()
        {
            this.Frozen = true;
            this.PolicyBorderPanel.Enabled = true;
            this.PolicysView.Enabled = true;
            int index1 = 0;
            int index2 = 0;
            int index3 = 0;
            if (this.CurrentPolicy != null)
                index1 = this.PolicysView.CurrentCell.RowIndex;
            if (this.CurrentTrigger != null)
                index2 = this.ActionSetsView.CurrentCell.RowIndex;
            if (this.CurrentOperation != null)
                index3 = this.ProceduresView.CurrentCell.RowIndex;
            List<Operation> shownOperations = this.ShownOperations;
            this.PolicysView.DataSource = (object)Enumerable.ToList(Enumerable.Select((IEnumerable<Policy>)this.Data.Policies.Values, o =>
            {
                var fAnonymousType0 = new
                {
                    ID = o.ID
                };
                return fAnonymousType0;
            }));
            this.PolicysView.CurrentCell = this.PolicysView.Rows[index1].Cells[0];
            if (this.CurrentPolicy != null)
            {
                this.ActionSetsView.DataSource = (object)Enumerable.ToList(Enumerable.Select((IEnumerable<Trigger>)this.CurrentPolicy.Triggers, o =>
                {
                    var fAnonymousType1 = new
                    {
                        Name = o.GetRepresentation()
                    };
                    return fAnonymousType1;
                }));
                this.ActionSetsView.CurrentCell = this.ActionSetsView.Rows[index2].Cells[0];
                //  ActionSetsView.rowEd
            }
            if (this.CurrentTrigger == null)
                return;
            this.ShownOperations = shownOperations;
            if (this.ShownOperations == null)
                return;

            this.ProceduresView.DataSource = (object)Enumerable.ToList(Enumerable.Select((IEnumerable<Operation>)this.ShownOperations, o =>
            {
                var fAnonymousType1 = new
                {
                    Name = o.GetRepresentation()
                };
                return fAnonymousType1;
            }));
           

            this.ProceduresView.CurrentCell = this.ProceduresView.Rows[index3].Cells[0];
            this.Frozen = false;
        }
        private bool locked = false;
        private void DataView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (locked) return;
            locked = true;
            ActionSetsView.DataSource = (Object)null;
            ParamView.DataSource = (Object)null;
            ProceduresView.DataSource = (Object)null;
            this.SetPolicy((int)this.PolicysView.SelectedCells[0].Value);
            if (this.CurrentPolicy !=null && this.CurrentPolicy.Count > 0)
            {
                this.SetTrigger(0);
            }
            if (this.CurrentTrigger != null && this.CurrentTrigger.Count > 0)
            {
                this.SetOperation(0, true);
            }
            locked = false;
        }

        private void TriggerView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.SetTrigger(e.RowIndex);
            if (this.CurrentTrigger.Count <= 0)
                return;
            this.SetOperation(0, true);
        }

        private int lastList = 0;
        private void PolicyTB_TextChanged(object sender, EventArgs e)
        {
            if (this.Data == null)
                return;

            if (!cansearch) return;
            string text = searchInput1.Text;
            int result;
            bool isInt = int.TryParse(text, out result);
            if (isInt)
            {
                if (result <= 0)
                    return;
                int policyIndex = this.Data.FindPolicyIndex(int.Parse(text));
                if (policyIndex == -1 || policyIndex >= this.Data.Count())
                    return;

                try
                {
                    //change_list(null, null);
                    PolicysView.Rows[policyIndex].Selected = true;
                    PolicysView.CurrentCell = PolicysView.Rows[policyIndex].Cells[0];
                    DataView_CellClick(null, null);
                }
                catch
                {
                    this.PolicysView.FirstDisplayedScrollingRowIndex = policyIndex;
                }
            }
            else
            {
                bool hfound = false;
                goto Search;

               
                StartOver:
                {
                    lastList = 0;
                    goto Search;
                }
                Search:
                {
                    cansearch = false;
                    Policy[] ddd = this.Data.Policies.Values.ToArray();
                    lastList++;
                    if (lastList >= ddd.Length - 1)
                    {
                        lastList = 0;
                    }
                   
                    for (int i = lastList; i < ddd.Length; i++)
                    {
                        Policy policy = ddd[i];
                        int triggerCount = 0;
                        int OperationParameterCount = 0;
                        foreach (Trigger trigger in policy.Triggers)
                        {
                            OperationParameterCount = 0;
                            foreach (Operation operation in trigger.Operations)
                            {
                                if (operation.Type == 2)
                                {
                                    string input = operation.Parameters[0].ToString();
                                    if (input.ToLower().Contains(text.ToLower()))
                                    {
                                        try
                                        {
                                            //change_list(null, null);
                                            PolicysView.Rows[i].Selected = true;
                                            PolicysView.CurrentCell = PolicysView.Rows[i].Cells[0];

                                            ActionSetsView.DataSource = (Object)null;
                                            ParamView.DataSource = (Object)null;
                                            ProceduresView.DataSource = (Object)null;
                                            this.SetPolicy((int)this.PolicysView.SelectedCells[0].Value);
                                            if (this.CurrentPolicy.Count <= 0)
                                                return;
                                            this.SetTrigger(triggerCount);
                                            if (this.CurrentTrigger.Count <= 0)
                                                return;
                                            this.SetOperation(OperationParameterCount, true);

                                        }
                                        catch
                                        {
                                            this.PolicysView.FirstDisplayedScrollingRowIndex = i;
                                        }
                                        lastList = i;
                                        cansearch = true;
                                        hfound = true;                                    
                                        goto Fine;
                                    }
                                }
                                OperationParameterCount++;
                            }
                            triggerCount++;
                        }

                    }
                }
                if(!hfound)
                goto StartOver;
            }
            cansearch = true;
            Fine:
            {

            }
        }

        private void RunCB_CheckedChanged(object sender, EventArgs e)
        {
            if (this.Frozen)
                return;
            CheckBox checkBox = (CheckBox)sender;
            if (this.CurrentTrigger == null)
                return;
            this.CurrentTrigger.SetFlag(2, checkBox.Checked);
        }

        private void EnabledCB_CheckedChanged(object sender, EventArgs e)
        {
            if (this.Frozen)
                return;
            CheckBox checkBox = (CheckBox)sender;
            if (this.CurrentTrigger == null)
                return;
            this.CurrentTrigger.SetFlag(1, checkBox.Checked);
        }

        private void AttackCB_CheckedChanged(object sender, EventArgs e)
        {
            if (this.Frozen)
                return;
            CheckBox checkBox = (CheckBox)sender;
            if (this.CurrentTrigger == null)
                return;
            this.CurrentTrigger.SetFlag(3, checkBox.Checked);
        }

        private void OperationView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.SetOperation(e.RowIndex);
        }

        private void DelPolicyBTN_Click(object sender, EventArgs e)
        {
            if (this.PolicysView.SelectedCells.Count == 0 || this.CurrentPolicy == null)
                return;
            int rowIndex1 = this.PolicysView.CurrentCell.RowIndex;
            List<int> ids = new List<int>();
            for (int i = 0; i < this.PolicysView.SelectedRows.Count; i++)
            {
                int polid = int.Parse(this.PolicysView.Rows[this.PolicysView.SelectedRows[i].Index].Cells[0].Value.ToString());
                ids.Add(polid);
            }
            int ccCount = ids.Count();
            this.Data.removeAll(ids);
            this.PolicysView.DataSource = (object)Enumerable.ToList(Enumerable.Select((IEnumerable<Policy>)this.Data.Policies.Values, o =>
            {
                var fAnonymousType0 = new
                {
                    ID = o.ID
                };
                return fAnonymousType0;
            }));
            int rowIndex2 = Math.Min(this.PolicysView.Rows.Count - ccCount, rowIndex1);
            //int rowIndex2 = this.PolicysView.Rows.Count - 1;
            if (rowIndex2 <= -1)
                return;
            this.PolicysView.CurrentCell = this.PolicysView.Rows[rowIndex2].Cells[0];
            this.DataView_CellClick((object)this, new DataGridViewCellEventArgs(0, rowIndex2));
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

        private void DelTriggerBTN_Click(object sender, EventArgs e)
        {
            if (this.CurrentPolicy == null || this.CurrentTrigger == null)
                return;
            int rowIndex1 = this.ActionSetsView.CurrentCell.RowIndex;

            List<int> ids = new List<int>();
            for (int i = 0; i < ActionSetsView.SelectedRows.Count; i++)
            {
                int polid = ActionSetsView.SelectedRows[i].Index;
                this.CurrentPolicy.Remove(this.ShownTriggers[polid]);
            }
            this.ActionSetsView.DataSource = (object)Enumerable.ToList(Enumerable.Select((IEnumerable<Trigger>)this.CurrentPolicy.Triggers, o =>
            {
                var fAnonymousType1 = new
                {
                    Name = o.GetRepresentation()
                };
                return fAnonymousType1;
            }));
            int rowIndex2 = Math.Min(this.CurrentPolicy.Count - 1, rowIndex1);
            if (rowIndex2 > -1)
            {
                this.ActionSetsView.CurrentCell = this.ActionSetsView.Rows[rowIndex2].Cells[0];
                this.TriggerView_CellClick((object)this.PolicysView, new DataGridViewCellEventArgs(0, rowIndex2));
            }
            else
            {
                this.DisableTriggerEdit();
                this.DisableOpEdit();
            }
        }

        private void DelOpBTN_Click(object sender, EventArgs e)
        {
            if (this.CurrentPolicy == null || this.CurrentTrigger == null || this.CurrentOperation == null)
                return;
            int rowIndex = this.ProceduresView.CurrentCell.RowIndex;

            List<int> ids = new List<int>();
            for (int i = 0; i < ProceduresView.SelectedRows.Count; i++)
            {
                int polid = ProceduresView.SelectedRows[i].Index;
                this.CurrentTrigger.Remove(this.ShownOperations[polid]);
            }
            this.ParamView.DataSource = (object)null;
            this.TargetView.DataSource = (object)null;
            int index = Math.Min(this.CurrentTrigger.Count - 1, rowIndex);
            this.ProceduresView.DataSource = (object)Enumerable.ToList(Enumerable.Select((IEnumerable<Operation>)this.CurrentTrigger.Operations, o =>
            {
                var fAnonymousType1 = new
                {
                    Name = o.GetRepresentation()
                };
                return fAnonymousType1;
            }));
            if (index > -1)
            {
                this.ProceduresView.CurrentCell = this.ProceduresView.Rows[index].Cells[0];
                this.OperationView_CellClick((object)this.ActionSetsView, new DataGridViewCellEventArgs(0, 0));
            }
            else
                this.DisableOpEdit();
        }

        internal bool autoLoad(string nPath)
        {
            this.Data = FileManager.LoadAI(nPath);
            if (this.Data == null)
            {
                int num = (int)JMessageBox.Show(this, "Unable to open file. Make sure you are trying to load a correct file.");
            }
            else
            {
                FileName = nPath;
                //this.TypeTargetCB.DataSource = (object)Enumerable.ToList<string>((IEnumerable<string>)Enum.GetNames(typeof(Target.Name)));
                this.CurrentPolicy = null;
                this.CurrentTrigger = null;
                this.CurrentOperation = null;
                this.LoadData();
                this.SetPolicy(1);
            }
            return true;
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {

            if (this.Data != null && this.Data.Dump(FileName))
            {
                int num1 = (int)JMessageBox.Show(this, FileName + " has been successfully saved.");
            }
            else
            {
                int num2 = (int)JMessageBox.Show(this, "Something went wrong. Check if there is enough space on the disk or if the file you are overwriting is being used by another process.");
            }
        }

        private void AddPolicyBTN_Click(object sender, EventArgs e)
        {
            AddPolicy addPolicy = new AddPolicy();
            addPolicy.SetData(this.Data);
            if (addPolicy.ShowDialog(this) != DialogResult.OK)
                return;
            this.Data.Add(addPolicy.Result);
            this.LoadData();
            this.SetPolicy(addPolicy.Result.ID);
        }

        private void EditCondBTN_Click(object sender, EventArgs e)
        {
            ProceduresView.Focus();
            ConditionVisual conditionInput = new ConditionVisual();
            conditionInput.SetResult(this.CurrentTrigger.RootConditon);
            conditionInput.SetText(this.ConditionTB.Text);
            if (conditionInput.ShowDialog(this) != DialogResult.OK)
                return;
            this.CurrentTrigger.SetCondition(conditionInput.Result);
            this.ConditionTB.Text = this.CurrentTrigger.RootConditon.GetRepresentation(true);
        }


        private void SetPolicy(int ID)
        {
            if(this.Data != null)
            this.SetPolicy(this.Data.FindPolicy(ID));
        }

        private void SetPolicy(Policy p)
        {
            if (this.PolicysView.CurrentCell == null) return;
            this.CurrentPolicy = (Policy)null;
            this.CurrentTrigger = (Trigger)null;
            this.CurrentOperation = (Operation)null;
            this.CurrentPolicy = p;
            this.PolicysView.CurrentCell = this.PolicysView.Rows[this.PolicysView.CurrentCell.RowIndex].Cells[0];
            this.ShownTriggers = this.CurrentPolicy.Triggers;
            this.ActionSetsView.DataSource = (object)Enumerable.ToList(Enumerable.Select((IEnumerable<Trigger>)this.ShownTriggers, o =>
            {
                var fAnonymousType2 = new
                {
                    Rep = o.GetRepresentation()
                };
                return fAnonymousType2;
            }));
            if (this.CurrentPolicy.Count > 0)
            {
                this.SetTrigger(0);
            }
            else
            {
                this.DisableTriggerEdit();
                this.DisableOpEdit();
            }
        }

        private void SetTrigger(int index)
        {
           
            this.SetTrigger(this.ShownTriggers[index]);
        }

        private void SetTrigger(Trigger tg)
        {
            this.Frozen = true;
            this.CurrentOperation = (Operation)null;
            this.EnableTriggerEdit();
            if (this.CurrentPolicy != tg.Parent)
                this.SetPolicy(tg.Parent);
            this.CurrentTrigger = tg;
            try
            {
                this.ConditionTB.Text = this.CurrentTrigger.RootConditon.GetRepresentation(true);
            }
            catch { }
            this.RunCB.Checked = this.CurrentTrigger.IsRun;
            this.EnabledCB.Checked = this.CurrentTrigger.IsEnabled;
            this.AttackCB.Checked = this.CurrentTrigger.IsAttackValid;
            this.ShownOperations = this.CurrentTrigger.Operations;
            this.ActionSetsView.CurrentCell = this.ActionSetsView.Rows[this.CurrentPolicy.FindTriggerIndex(tg)].Cells[0];
            this.ProceduresView.DataSource = (object)Enumerable.ToList(Enumerable.Select((IEnumerable<Operation>)this.ShownOperations, o =>
            {
                var fAnonymousType1 = new
                {
                    Name = o.GetRepresentation()
                };
                return fAnonymousType1;
            }));
            if (this.CurrentTrigger.Count > 0)
                this.SetOperation(0, true);
            else
                this.DisableOpEdit();
            this.Frozen = false;
        }

        private void SetOperation(Operation op, bool load = true)
        {
            this.Frozen = true;
            this.EnableOpEdit();
            this.ParamView.Enabled = true;
            this.TargetView.Enabled = true;
            if (load)
            {
                if (this.CurrentPolicy != op.Parent.Parent)
                    this.SetPolicy(op.Parent.Parent);
                if (this.CurrentTrigger != op.Parent)
                    this.SetTrigger(op.Parent);
            }
            this.setOperationData(this.CurrentOperation = op);
            this.SetTargetData(this.CurrentOperation);
            if (load)
                this.ProceduresView.CurrentCell = this.ProceduresView.Rows[this.CurrentTrigger.Operations.IndexOf(op)].Cells[0];
            else
                this.ProceduresView.CurrentCell = this.ProceduresView.Rows[this.ShownOperations.IndexOf(op)].Cells[0];
            this.Frozen = false;
        }

        private void SetTargetData(Operation op)
        {
            if (op.Tg == null)
                return;
            try
            {
                this.Frozen = true;
                this.CurrentOperation = op;
                this.TargetView.Visible = true;
                this.TypeTargetCB.SelectedIndex = op.Tg.Type;
                this.TargetView.DataSource = op.Tg.Type != 6 ? (object)null : (object)op.Tg.GetParameters;
                this.Frozen = false;
            }
            catch { }
        }

        private void setOperationData(Operation op)
        {
            this.Frozen = true;
            this.CurrentOperation = op;
            this.ParamView.Visible = true;
            this.ParamView.DataSource = (object)op.GetParameters;
            if (op.Type == 2)
            {
                DataGridViewComboBoxCell viewComboBoxCell = new DataGridViewComboBoxCell();
                viewComboBoxCell.DataSource = (object)Enum.GetNames(typeof(Operation.MessageType));
                Operation.MessageType result;
                viewComboBoxCell.Value = (object)(bool)(Enum.TryParse<Operation.MessageType>(this.ParamView.Rows[1].Cells[2].Value.ToString(), out result) ? true : false);
                viewComboBoxCell.FlatStyle = FlatStyle.Flat;
                this.ParamView.Rows[1].Cells[2] = (DataGridViewCell)viewComboBoxCell;
            }
            this.TypeOperationCB.SelectedIndex = op.Type;
            this.Frozen = false;
        }

        private void DisableTriggerEdit()
        {
            this.Frozen = true;
            this.AttackCB.AutoCheck = false;
            this.RunCB.AutoCheck = false;
            this.EnabledCB.AutoCheck = false;
            this.RunCB.Checked = false;
            this.EnabledCB.Checked = false;
            this.AttackCB.Checked = false;
            this.ConditionTB.Enabled = false;
            this.ConditionTB.Text = "";
            this.Frozen = false;
        }

        private void EnableTriggerEdit()
        {
            this.AttackCB.AutoCheck = true;
            this.RunCB.AutoCheck = true;
            this.EnabledCB.AutoCheck = true;
            this.RunCB.Checked = true;
            this.EnabledCB.Checked = true;
            this.AttackCB.Checked = true;
            this.ConditionTB.Enabled = true;
        }

        private void DisableOpEdit()
        {
            this.TargetView.DataSource = (object)null;
            //this.ParamView.Rows.Clear();
            this.ProceduresView.DataSource = (object)null;
            this.ParamView.Enabled = false;
            this.TargetView.Enabled = false;
        }

        private void EnableOpEdit()
        {
            this.ParamView.Enabled = true;
            this.TargetView.Enabled = true;
        }

        private void SetOperation(int index, bool load = true)
        {
            this.SetOperation(this.ShownOperations[index], load);
        }

        private void AddTriggerBTN_Click(object sender, EventArgs e)
        {
            AddTrigger addTrigger = new AddTrigger();
            addTrigger.SetPolicy(this.CurrentPolicy);
            if (addTrigger.ShowDialog(this) != DialogResult.OK)
                return;
            this.CurrentPolicy.Add(addTrigger.Result);
            this.LoadData();
            this.SetPolicy(this.CurrentPolicy.ID);
            this.SetTrigger(addTrigger.Result);
        }

        private void AddOpBTN_Click(object sender, EventArgs e)
        {
            AddOperation addOperation = new AddOperation();
            if (addOperation.ShowDialog(this) != DialogResult.OK)
                return;
            Operation op = new Operation(this.CurrentTrigger, addOperation.Result);
            this.CurrentTrigger.Add(op);
            this.LoadData();
            this.SetTrigger(this.CurrentTrigger);
            this.SetOperation(op, true);
        }

        private void DataChanged(object sender, EventArgs e)
        {
            this.LoadData();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.SaveDialog.ShowDialog() != DialogResult.OK)
                return;
            if (this.Data.Dump(this.SaveDialog.FileName))
            {
                int num1 = (int)JMessageBox.Show(this, this.SaveDialog.FileName + " has been successfully saved.");
            }
            else
            {
                int num2 = (int)JMessageBox.Show(this, "Something went wrong. Check if there is enough space on the disk or if the file you are overwriting is being used by another process.");
            }
        }

        private void ParamView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            this.OriginalParameter = this.ParamView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            if (!this.ParamView.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value.ToString().Equals("String") && !this.ParamView.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value.ToString().Equals("GB18030"))
                return;
            EditMessage editMessage = new EditMessage();
            editMessage.SetText(this.ParamView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
            if (editMessage.ShowDialog(this) == DialogResult.OK)
                this.ParamView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = (object)editMessage.Result;
            this.ParamView.EndEdit();
        }

        private void ParamView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (locked) return;
            string str = this.ParamView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            Type.GetType((string)this.ParamView.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value);
            if (!this.CurrentOperation.SetParameter(e.RowIndex, str))
            {
                int num = (int)JMessageBox.Show(this, "Error. Invalid parameter type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                this.ParamView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = this.OriginalParameter;
            }
            this.DataChanged((object)this, new EventArgs());
        }

        private void TargetView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            this.OriginalTarget = this.TargetView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            if(this.CurrentOperation.Tg.Type == 6)
            {
                ClassMaskGenerator cmg = new ClassMaskGenerator(int.Parse(this.OriginalTarget.ToString()));
                cmg.FormClosing += this.doneEdting;
                cmg.ShowDialog(this);
            }
            //ClassMaskGenerator
        }

        private void doneEdting(object sender, FormClosingEventArgs e)
        {
            if(TargetView.CurrentCell != null)
            this.TargetView.Rows[TargetView.CurrentCell.RowIndex].Cells[TargetView.CurrentCell.ColumnIndex].Value = ElementsEditor.selectedMask;
        }

        private void TargetView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (this.CurrentOperation.Tg.Type != 6)
                return;
            int result;
            if (!int.TryParse(this.TargetView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), out result))
            {
                int num = (int)JMessageBox.Show(this, "Error. Invalid parameter type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                this.TargetView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = this.OriginalTarget;
            }
            else
                this.CurrentOperation.Tg.SetParameter(result);
        }

        private void SetTarget(Operation op)
        {
            this.Frozen = true;
            this.CurrentOperation = op;
            this.TargetView.Visible = true;
            this.TypeTargetCB.SelectedIndex = op.Tg.Type;
            this.TargetView.DataSource = op.Tg.Type != 6 ? (object)null : (object)op.Tg.GetParameters;
            this.Frozen = false;
        }

        private void TargetCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Frozen || this.TypeTargetCB.SelectedIndex == -1 || this.CurrentOperation == null || this.ProceduresView.CurrentCell == null || this.ActionSetsView.CurrentCell == null)
                return;
            this.CurrentOperation.SetTarget(new Target(this.TypeTargetCB.SelectedIndex));
            this.TargetView.DataSource = (object)null;
            this.SetTarget(this.CurrentOperation);
            LoadData();
        }

        private void TypeOperationCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Frozen || this.TypeOperationCB.SelectedIndex == -1 || this.CurrentOperation == null || this.ProceduresView.CurrentCell == null || this.ActionSetsView.CurrentCell == null)
                return;
            // 
            this.CurrentTrigger.Operations[this.ProceduresView.CurrentCell.RowIndex] = new Operation(this.CurrentTrigger, this.TypeOperationCB.SelectedIndex);
            this.Frozen = true;
            this.CurrentOperation = this.CurrentTrigger.Operations[this.ProceduresView.CurrentCell.RowIndex];
            this.ParamView.Visible = true;
           
            this.ParamView.DataSource = this.CurrentTrigger.Operations[this.ProceduresView.CurrentCell.RowIndex].GetParameters;
            this.SetOperation(this.CurrentTrigger.Operations[this.ProceduresView.CurrentCell.RowIndex], true);

            LoadData();
            this.Frozen = false;
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.Data != null && PolicysView.CurrentCell != null)
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "PolicyData Export (*.adx)|*.adx";
                int xe = PolicysView.CurrentCell.RowIndex;
                if (xe > -1 && save.ShowDialog() == DialogResult.OK && save.FileName != "")
                {
                    Export export = new Export();
                    export.ListId = 0;
                    export.type = 2; 
                    export.Version = 0;
                    export.data = new SortedDictionary<int, object>(new ReverseComparer<int>(Comparer<int>.Default));
                    for (int i = 0; i < PolicysView.SelectedRows.Count; i++)
                    {
                        progress_bar("Exporting ...", i, PolicysView.SelectedRows.Count);
                        int index = int.Parse(this.PolicysView.Rows[PolicysView.SelectedRows[i].Index].Cells[0].Value.ToString());
                        Policy pol = Data.Policies[index];
                        export.data.Add(i, pol);
                    }
                    FileStream fs = new FileStream(save.FileName, FileMode.Create, FileAccess.Write);
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(fs, export);
                    fs.Close();
                }
            }
            progress_bar("Ready", 0, 0);
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.Data == null)
            {
                return;
            }
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "PolicyData Export(*.adx) | *.adx";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                String pathx = openFileDialog1.FileName;
                progress_bar("Importing ...", 0, 0);
                Application.DoEvents();
                using (Stream file = File.Open(pathx, FileMode.Open))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    Export obj = (Export)bf.Deserialize(file);
                    if (obj.type != 2)
                    {
                        JMessageBox.Show(this, "Invalid export file!");
                        return;
                    }
                    int i = 0;
                    DialogResult Result = JMessageBox.Show(this, "If duplicates found you want to replace?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    foreach (KeyValuePair<int, Object> entry in obj.data)
                    {
                        Application.DoEvents();
                        progress_bar("Importing ...", i, obj.data.Count);
                        Policy addPolicy = (Policy)entry.Value;
                        //addPolicy.Version = int.Parse(version_label.Text);
                        
                        if (this.Data.FindPolicy(addPolicy.ID) != null && Result == DialogResult.No)
                        {
                            addPolicy.ID = this.Data.getNewId();
                            this.Data.Add(addPolicy);
                        }
                        else
                        {
                            this.Data.removeAll(new List<int>() { addPolicy.ID });
                            this.Data.Add(addPolicy);
                        }
                        i++;
                    }
                }
                this.PolicysView.DataSource = (object)Enumerable.ToList(Enumerable.Select((IEnumerable<Policy>)this.Data.Policies.Values, o =>
                {
                    var fAnonymousType0 = new
                    {
                        ID = o.ID
                    };
                    return fAnonymousType0;
                }));
                int rowIndex2 = this.PolicysView.Rows.Count - 1;
                if (rowIndex2 <= -1)
                    return;
                this.PolicysView.CurrentCell = this.PolicysView.Rows[rowIndex2].Cells[0];
                this.DataView_CellClick((object)this, new DataGridViewCellEventArgs(0, rowIndex2));  
            }
            progress_bar("Ready", 0, 0);
        }

        private void cloneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.Data != null && PolicysView.CurrentCell != null)
            {
                for (int i = 0; i < PolicysView.SelectedRows.Count; i++)
                {
                    progress_bar("Cloning ...", i, PolicysView.SelectedRows.Count);
                    int index = int.Parse(PolicysView.Rows[PolicysView.SelectedRows[i].Index].Cells[0].Value.ToString());
                    Policy pol = Data.Policies[index];
                    Policy duplicateItemVO = new Policy
                    {
                        Triggers = pol.Triggers,
                        ID = this.Data.getNewId(),
                        Count = pol.Count,
                        Version = pol.Version
                    };
                    this.Data.Add(duplicateItemVO);
                }
                this.LoadData();

            }
            progress_bar("Ready", 0, 0);
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

        private void PolicysView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Control | Keys.C))
            {
                e.Handled = true;
                copyPolicyesToClipboard();
            }
            else if (e.KeyData == (Keys.Control | Keys.V))
            {
                e.Handled = true;
                ImportPolicyFromClpiboard();
            }
            else if (e.KeyData == Keys.Delete)
            {
                e.Handled = true;
                if (PolicysView.CurrentCell.RowIndex != -1)
                {
                    int count = PolicysView.SelectedRows.Count;
                    if ((JMessageBox.Show(this, "Do you realy want to delete:" + count + " items?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes))
                    {
                        this.DelPolicyBTN_Click(null, null);
                    }
                }
             
            }
        }

        private void ImportPolicyFromClpiboard()
        {
            if (this.Data == null)
            {
                return;
            }
            progress_bar("Importing ...", 0, 0);
            Application.DoEvents();
                BinaryFormatter bf = new BinaryFormatter();
                Export obj = (Export)GetFromClipboard();
                if (obj != null && obj.type != 2)
                {
                    JMessageBox.Show(this, "Invalid export file!");
                    return;
                }
                int i = 0;
                foreach (KeyValuePair<int, Object> entry in obj.data)
                {
                    Application.DoEvents();
                    progress_bar("Importing ...", i, obj.data.Count);
                    Policy addPolicy = (Policy)entry.Value;
                    if (this.Data.FindPolicy(addPolicy.ID) != null && JMessageBox.Show(this, "Warning: ID already exists. Do you want to generate new id? (No to overwrite)", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        addPolicy.ID = this.Data.getNewId();
                        this.Data.Add(addPolicy);
                    }
                    else
                    {
                        this.Data.Add(addPolicy);
                    }
                    i++;
                }
            
            this.PolicysView.DataSource = (object)Enumerable.ToList(Enumerable.Select((IEnumerable<Policy>)this.Data.Policies.Values, o =>
            {
                var fAnonymousType0 = new
                {
                    ID = o.ID
                };
                return fAnonymousType0;
            }));
            int rowIndex2 = this.PolicysView.Rows.Count - 1;
            if (rowIndex2 <= -1)
                return;
            this.PolicysView.CurrentCell = this.PolicysView.Rows[rowIndex2].Cells[0];
            this.DataView_CellClick((object)this, new DataGridViewCellEventArgs(0, rowIndex2));
            progress_bar("Ready", 0, 0);
        }

        private void copyPolicyesToClipboard()
        {
            if (this.Data != null && PolicysView.CurrentCell != null)
            {
                Export export = new Export();
                export.ListId = 0;
                export.type = 2;
                export.Version = 0;
                export.data = new SortedDictionary<int, object>(new ReverseComparer<int>(Comparer<int>.Default));
                for (int i = 0; i < PolicysView.SelectedRows.Count; i++)
                {
                    progress_bar("Exporting ...", i, PolicysView.SelectedRows.Count);
                    int index = int.Parse(this.PolicysView.Rows[PolicysView.SelectedRows[i].Index].Cells[0].Value.ToString());
                    Policy pol = Data.Policies[index];
                    export.data.Add(i, pol);
                }
                CopyToClipboard(export);
                progress_bar("Ready", 0, 0);
            }
        }

        private void ActionSetsView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Control | Keys.C))
            {
                e.Handled = true;
                copyToClipboardActionSet();
            }
            else if (e.KeyData == (Keys.Control | Keys.V))
            {
                e.Handled = true;
                pasteFromClipboardActionSet();
            }
            else if (e.KeyData == Keys.Delete)
            {
                e.Handled = true;
                if (ActionSetsView.CurrentCell.RowIndex != -1)
                {
                    int count = ActionSetsView.SelectedRows.Count;
                    if ((JMessageBox.Show(this, "Do you realy want to delete:" + count + " items?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes))
                    {
                        DelTriggerBTN_Click(null, null);
                    }
                }
               
            }
        }

        private void pasteFromClipboardActionSet()
        {
            if (this.Data == null)
            {
                return;
            }
            progress_bar("Importing ...", 0, 0);
            Application.DoEvents();
            BinaryFormatter bf = new BinaryFormatter();
            Export obj = (Export)GetFromClipboard();
            if (obj != null && obj.type != 3)
            {
                JMessageBox.Show(this, "Invalid export file!");
                return;
            }
            int i = 0;
            foreach (KeyValuePair<int, Object> entry in obj.data)
            {
                Application.DoEvents();
                progress_bar("Importing ...", i, obj.data.Count);
                Trigger addPolicy = (Trigger)entry.Value;
                addPolicy.Parent = this.CurrentPolicy;
                int nextValId = 0;
                foreach(Trigger tr in this.CurrentPolicy.Triggers)
                {
                    if(nextValId < tr.Index)
                    {
                        nextValId = tr.Index;
                    }

                }
                addPolicy.Index = nextValId + 1;
                this.CurrentPolicy.Add(addPolicy);
                i++;
            }
            this.LoadData();
            int rowIndex2 = this.ActionSetsView.Rows.Count - 1;
            if (rowIndex2 <= -1)
                return;
            this.ActionSetsView.CurrentCell = this.ActionSetsView.Rows[rowIndex2].Cells[0];
            this.TriggerView_CellClick((object)this, new DataGridViewCellEventArgs(0, rowIndex2));

            progress_bar("Ready", 0, 0);
        }

        private void copyToClipboardActionSet()
        {
            if (this.Data != null && this.ActionSetsView.CurrentCell != null && this.CurrentPolicy != null)
            {
                Export export = new Export();
                export.ListId = 0;
                export.type = 3;
                export.Version = 0;
                export.data = new SortedDictionary<int, object>(new ReverseComparer<int>(Comparer<int>.Default));
                for (int i = 0; i < this.ActionSetsView.SelectedRows.Count; i++)
                {
                    progress_bar("Exporting ...", i, PolicysView.SelectedRows.Count);
                    int index = ActionSetsView.SelectedRows[i].Index;
                    Trigger pol = Data.Policies[this.CurrentPolicy.ID].Triggers[index];
                    export.data.Add(i, pol);
                }
                CopyToClipboard(export);
                progress_bar("Ready", 0, 0);
            }
        }

        private void ProceduresView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Control | Keys.C))
            {
                e.Handled = true;
            }
            else if (e.KeyData == (Keys.Control | Keys.V))
            {
                e.Handled = true;
            }
            else if (e.KeyData == Keys.Delete)
            {
                e.Handled = true;
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(this.Data != null && this.PolicysView.CurrentCell != null && this.ActionSetsView.CurrentCell != null)
            {
                Trigger pol = this.Data.Policies[this.CurrentPolicy.ID].Triggers[this.ActionSetsView.CurrentCell.RowIndex];
                int freeId = 0;
                foreach(Trigger tr in this.Data.Policies[this.CurrentPolicy.ID].Triggers)
                {
                    if(tr.Index > freeId)
                    {
                        freeId = tr.Index;
                    }
                }
                EditActionSet editor = new EditActionSet();
                editor.setObject(pol, freeId);
                if (editor.ShowDialog(this) != DialogResult.OK)
                    return;
                pol.Index = ((Trigger)editor.data).Index;
                pol.Name = ((Trigger)editor.data).Name;
                this.LoadData();
                int rowIndex2 = this.ActionSetsView.CurrentCell.RowIndex;
                if (rowIndex2 <= -1)
                    return;
                this.ActionSetsView.CurrentCell = this.ActionSetsView.Rows[rowIndex2].Cells[0];
                this.TriggerView_CellClick((object)this, new DataGridViewCellEventArgs(0, rowIndex2));

            }
        }
        bool cansearch = true;
        public bool isAutoOpen = false;
        public string autoOpenPath = "";

        private void AiPolicyEditor_FormClosing(object sender, FormClosingEventArgs e)
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

        private void DataView_CellClick(object sender, EventArgs e)
        {
            if (locked || this.Frozen) return;
            locked = true;
            ActionSetsView.DataSource = (Object)null;
            ParamView.DataSource = (Object)null;
            ProceduresView.DataSource = (Object)null;
            if (PolicysView.SelectedCells != null && PolicysView.SelectedCells.Count > 0)
            {
                this.SetPolicy((int)this.PolicysView.SelectedCells[0].Value);
                if (this.CurrentPolicy != null && this.CurrentPolicy.Count > 0)
                {
                    this.SetTrigger(0);
                }
                if (this.CurrentTrigger != null && this.CurrentTrigger.Count > 0)
                {
                    this.SetOperation(0, true);
                }
            }
            locked = false;
        }

        private void AiPolicyEditor_Shown(object sender, EventArgs e)
        {
            if(isAutoOpen)
            {
                try
                {
                    this.Data = FileManager.LoadAI(autoOpenPath);

                    if (this.Data == null)
                    {
                        int num = (int)JMessageBox.Show(this, "Unable to open file. Make sure you are trying to load a correct file.");
                    }
                    else
                    {
                        FileName = this.OpenDialog.FileName;
                        this.version_label.Text = Trigger.EstimatedVersion.ToString();
                        pathLabel.Text = OpenDialog.FileName;
                        jPictureBox2.Visible = label1.Visible = jLabel2.Visible = pathLabel.Visible = version_label.Visible = true;
                        this.CurrentPolicy = null;
                        this.CurrentTrigger = null;
                        this.CurrentOperation = null;
                        this.LoadData();
                        this.SetPolicy(1);
                    }
                }
                catch { }
            }
        }

        private void exportToXmlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(this.Data != null)
            {
                if (this.SaveDialog.ShowDialog() != DialogResult.OK)
                    return;

                var serializer = new XmlSerializer(typeof(Policy[]));
                Policy[] aaaaa = Data.Policies.Values.ToArray();
                using (var writer = XmlWriter.Create(this.SaveDialog.FileName))
                {
                    serializer.Serialize(writer, aaaaa);
                }

            }
        }


        private void exportToolStripMenu_Click(object sender, EventArgs e)
        {
            if (this.Data == null)
            {
                return;
            }

            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "XML Files|*.xml";
            saveFileDialog.Title = "Export Broadcast Messages";
            saveFileDialog.FileName = "aipolicy.xml";
            if (saveFileDialog.ShowDialog() != DialogResult.OK || saveFileDialog.FileName == "")
                return;

             XmlSerializer serializer = new XmlSerializer(typeof(xmlCollection));
            string path = saveFileDialog.FileName;
            StreamWriter reader = new StreamWriter(path);
            int idx = 0;
            List<Broadcast> broadcastl = new List<Broadcast>();
            Policy[] data = Data.Policies.Values.ToArray();
            for (int i = 0; i < data.Length; i++)
            {
                Policy policy = data[i];
                List<Trigger> trigList = policy.Triggers;
                for (int t = 0; t < trigList.Count; t++)
                {
                    Trigger trig = data[i].Triggers[t];
                    List<Operation> opList = trig.Operations;
                    for (int o = 0; o < opList.Count; o++)
                    {
                        Operation operation = opList[o];
                        if (operation.Type == (int)OperationType.SayMessage)
                        {
                          //  for (int p = 0; p < operation.GetParameters.Count; p++)
                          //  {
                                Parameter para = operation.GetParameters[0];
                                Broadcast broadcast = new Broadcast();
                                broadcast.Msg = para.Value.ToString();
                                broadcast.PolicyId = policy.ID;
                                broadcast.TrigIndex = trig.Index;
                                broadcast.OperationIndex = o;
                                broadcastl.Add(broadcast);
                                idx++;
                          //  }
                        }
                    }
                }
            }
            xmlCollection xml = new xmlCollection();
            xml.Messages = broadcastl.ToArray();
            serializer.Serialize(reader, xml);
            reader.Close();
            saveFileDialog.Dispose();
            JMessageBox.Show(this, "Exported "+ idx + " Messages Exported to XML.");
        }

        [Serializable()]
        public class Broadcast
        {
            [XmlElement("Msg")]
            public string Msg { get; set; }
            [XmlAttribute("TrigIndex")]
            public int TrigIndex { get; set; }
            [XmlAttribute("PolicyId")]
            public int PolicyId { get; set; }
            [XmlAttribute("OperationIndex")]
            public int OperationIndex { get; set; }
        }


        [Serializable()]
        [XmlRoot("")]
        public class xmlCollection
        {
            [XmlArray("Strings")]
            [XmlArrayItem("Messages", typeof(Broadcast))]
            public Broadcast[] Messages { get; set; }
        }

        private void importToolStripMenu_Click(object sender, EventArgs e)
        {
            if(this.Data == null)
            {
                return;
            }
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "XML Files|*.xml";
            openFileDialog.Title = "Import Broadcast Messages";
            openFileDialog.FileName = "aipolicy.xml";

            if (openFileDialog.ShowDialog() != DialogResult.OK || openFileDialog.FileName == "")
                return;
            try
            {
                xmlCollection xmlItimes = null;
                string path = openFileDialog.FileName;

                XmlSerializer serializer = new XmlSerializer(typeof(xmlCollection));

                StreamReader reader = new StreamReader(path);
                xmlItimes = (xmlCollection)serializer.Deserialize(reader);
                reader.Close();
                int idx = 0;
                for (int i = 0; i < xmlItimes.Messages.Length; i++)
                {
                    Broadcast data = xmlItimes.Messages[i];
                    if (this.Data.Policies.ContainsKey(data.PolicyId))
                    {
                        Policy pol = this.Data.Policies[data.PolicyId];
                        Trigger trig = pol.Triggers.FirstOrDefault(x => x.Index == data.TrigIndex);
                        if (trig != null)
                        {
                            if (data.OperationIndex < trig.Operations.Count)
                            {
                                try
                                {
                                    Operation op = trig.Operations[data.OperationIndex];
                                    if (op.Type == (int)OperationType.SayMessage)
                                    {
                                        op.SetParameter(0, data.Msg);
                                        //op.Parameters[0] = data.Msg;
                                        // op.Parameters[2] = data.Msg.Length * 2;
                                        idx++;
                                    }
                                }
                                catch { }
                            }

                        }
                    }
                }


                JMessageBox.Show(this, "imported " + idx + " Messages Exported to XML.");
            }
            catch(Exception ex)
            {
                JMessageBox.Show(this, ex.ToString());
            }
        }

    }
}

