using AIPolicy;
using AIPolicy.Conditions;
using JHUI.Forms;
using PWDataEditorPaied.AIPolicy.Conditions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PWDataEditorPaied.AIPolicy.Input
{
    public partial class ConditionVisual : JForm
    {
        private bool locked;

        private string TBText
        {
            get
            {
                return this.ConditionTB.Text;
            }
        }

        internal Condition Result { get; private set; }

        public ConditionVisual()
        {
            InitializeComponent();
        }

        public void SetText(string text)
        {
            this.ConditionTB.Text = text;
            GetRepresentation(Result);
        }

        private void GetRepresentation(Condition cond, bool initial = true)
        {
            OperationCondition op = null;
            OperationArithmetic ar = null;
            switch (cond.Type)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                case 4:
                case 8:
                case 16:
                case 18:
                case 19:
                case 20:
                case 21:
                case 22:
                case 23:
                case 24:
                case 25:
                    op = new OperationCondition();
                    op.onChange += this.onePanelChanged;
                    op.SetOption(EnumUtils.StringValueOf((Condition.Name)cond.Type));
                    Func func = (Func)cond;
                    for (int index = 1; index < func.Parameters.Count; ++index)
                    {
                        if(!(func.Parameters[index] is float))
                        {
                            op.setText1(func.Parameters[index].ToString());
                        }
                        else
                        {
                            op.setText1(((float)func.Parameters[index]).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture));
                        }
                    }
                    panel1.Controls.Add(op);
                    break;
                case 5:
                    if (((Negation)cond).Inner.Type == 15)
                    {
                        this.GetExprRepresentationNeg(((Arithmetic)((Negation)cond).Inner).Left);
                        this.GetCompar(((Negation)cond).Inner, true);
                        this.GetExprRepresentationNeg(((Arithmetic)((Negation)cond).Inner).Right);
                    }
                    else
                    {
                        
                        if (cond.Type % 2 > 0)
                        {
                            ar = new OperationArithmetic();
                            ar.setOperation("!");
                            ar.onChange += this.onePanelChanged;
                            panel1.Controls.Add(ar);
                        }
                        
                        this.GetRepresentation(((Negation)cond).Inner, false);

                    }
                    break;
                case 6:
                case 7:
                    this.GetRepresentation(((Logic)cond).Left);
                    
                    if (cond.Type % 2 > 0)
                    {
                        ar = new OperationArithmetic();
                        ar.setOperation("&&");
                        ar.onChange += this.onePanelChanged;
                        panel1.Controls.Add(ar);
                    }
                    else
                    {
                        ar = new OperationArithmetic();
                        ar.setOperation("||");
                        ar.onChange += this.onePanelChanged;
                        panel1.Controls.Add(ar);
                    }
                   
                    this.GetRepresentation(((Logic)cond).Right);
                    break;
                case 13:
                case 14:
                case 15:
                    //((Arithmetic)cond).Left.GetExprRepresentation();
                    this.GetExprRepresentationNeg(((Arithmetic)cond).Left);
                    ar = new OperationArithmetic();
                    ar.setOperation(this.GetCompar(cond, false));
                    ar.onChange += this.onePanelChanged;
                    panel1.Controls.Add(ar);
                    this.GetExprRepresentationNeg(((Arithmetic)cond).Right);
                    // str1 = str1 + ((Arithmetic)cond).Left.GetExprRepresentation() + cond.GetCompar(false) + ((Arithmetic)cond).Right.GetExprRepresentation();
                    break;
                case 17:
                    ar = new OperationArithmetic();
                    ar.setOperation("Var");
                    ar.SetText1(((ValueExpr)cond).Constant.ToString());
                    ar.onChange += this.onePanelChanged;
                    panel1.Controls.Add(ar);
                    // ((ValueExpr)cond).Constant.ToString();
                    break;
            }
        }

        private void onePanelChanged(object sender, EventArgs e)
        {
            if (this.locked) { return; }
            try
            {
                string test = "";
                foreach (Control ct in panel1.Controls)
                {
                    if (ct is OperationArithmetic)
                    {
                        test += ((OperationArithmetic)ct).toString();
                    }
                    if (ct is OperationCondition)
                    {
                        test += ((OperationCondition)ct).toString();
                    }
                }
                test = Regex.Replace(test, @"\s+", "").Replace(',', '.');
                string s = ConditionTranslator.TranslateCondition(test);
                if (s.Length == 0) MessageBox.Show("Error: " + ConditionTranslator.GetLastError());
                if (s == null)
                {
                    //if (MessageBox.Show("Error: " + ConditionTranslator.GetLastError(), "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Hand) != DialogResult.Cancel)
                        return;
                }
                else
                {
                    Condition condition = new Condition().GetCondition(new CharStream(s));
                    if (condition == null)
                    {
                        //if (MessageBox.Show("Error parsing text.", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Hand) != DialogResult.Cancel)
                            return;
                    }
                    else
                    {
                        this.Result = condition;
                    }
                }
                this.ConditionTB.Text = this.Result.GetRepresentation();
            }
            catch { }
        }

        private void GetExprRepresentationNeg(Condition cond)
        {
            OperationCondition op = null;
            OperationArithmetic ar = null;
            switch (cond.Type)
            {
                case 9:
                case 10:
                case 11:
                case 12:
                    //((FormulaExpr)cond).Left
                    //this.GetSign(cond)
                    //((FormulaExpr)cond).Right
                    this.GetExprRepresentationNeg(((FormulaExpr)cond).Left);
                    ar = new OperationArithmetic();
                    ar.setOperation(this.GetCompar(cond, false));
                    ar.onChange += this.onePanelChanged;
                    panel1.Controls.Add(ar);
                    this.GetExprRepresentationNeg(((FormulaExpr)cond).Right);
                    //str = str + "(" + ((FormulaExpr)cond).Left.GetExprRepresentation() + this.GetSign(cond) + ((FormulaExpr)cond).Right.GetExprRepresentation() + ")";
                    break;
                case 16:
                case 21:
                case 23:
                    op = new OperationCondition();
                    op.onChange += this.onePanelChanged;
                    string name = EnumUtils.StringValueOf((Condition.Name)cond.Type);
                    op.SetOption(name);
                    op.onChange += this.onePanelChanged;
                    op.setText1(((ValueExpr)cond).Constant+"");
                    panel1.Controls.Add(op);
                    // return "" + (object)(Condition.Name)cond.Type + "(" + (object)((ValueExpr)cond).Constant + ")";
                    break;
                case 17:
                    ar = new OperationArithmetic();
                    ar.setOperation("Var");
                    ar.onChange += this.onePanelChanged;
                    ar.SetText1(((ValueExpr)cond).Constant.ToString());
                    panel1.Controls.Add(ar);
                    // return ((ValueExpr)cond).Constant.ToString();
                    break;
                case 26:
                    op = new OperationCondition();
                    op.onChange += this.onePanelChanged;
                    op.SetOption(EnumUtils.StringValueOf((Condition.Name)cond.Type));
                    panel1.Controls.Add(op);
                    //return "" + (object)(Condition.Name)cond.Type + "()";
                    break;
            }
        }

        private string GetCompar(Condition cond, bool negation)
        {
            switch (cond.Type)
            {
                case 13:
                    return ">";
                case 14:
                    return "<";
                case 15:
                    return negation ? "!=" : "==";
                default:
                    return "";
            }
        }

        private string GetSign(Condition cond)
        {
            switch (cond.Type)
            {
                case 9:
                    return "+";
                case 10:
                    return "-";
                case 11:
                    return "*";
                case 12:
                    return "/";
                default:
                    return "";
            }
        }

        private void OkBTN_Click(object sender, EventArgs e)
        {
            string test = "";
            foreach(Control ct in panel1.Controls)
            {
                if (ct is OperationArithmetic)
                {
                    test += ((OperationArithmetic)ct).toString();
                }
                if (ct is OperationCondition)
                {
                    test += ((OperationCondition)ct).toString();
                }
            }
           /// MessageBox.Show(test);
            string s = ConditionTranslator.TranslateCondition(string.Join("", test.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries)));
            if (s == null)
            {
                if (MessageBox.Show("Error: " + ConditionTranslator.GetLastError(), "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Hand) != DialogResult.Cancel)
                    return;
                this.Close();
            }
            else
            {
                Condition condition = new Condition().GetCondition(new CharStream(s));
                if (condition == null)
                {
                    if (MessageBox.Show("Error parsing text.", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Hand) != DialogResult.Cancel)
                        return;
                    this.Close();
                }
                else
                {
                    this.Result = condition;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        internal void SetResult(Condition cnd)
        {
            this.Result = cnd;
        }

        private void AddNewOperation(object sender, EventArgs e)
        {
            contextMenuStripCondition.Show(button1, new Point(0, button1.Height));
        }

        private void addConditionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.locked = true;
            OperationArithmetic op = new OperationArithmetic();
            op.onChange += this.onePanelChanged;
            panel1.Controls.Add(op);
            this.locked =false;
        }

        private void addOperatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.locked =true;
            OperationCondition op = new OperationCondition();
            op.onChange += this.onePanelChanged;
            panel1.Controls.Add(op);
            this.locked = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_ControlAdded(object sender, ControlEventArgs e)
        {
            onePanelChanged(null, null);
            panel1.AutoScrollPosition = new Point(
                    e.Control.Right - panel1.AutoScrollPosition.X,
                     e.Control.Bottom - panel1.AutoScrollPosition.Y);
        }

        private void panel1_ControlRemoved(object sender, ControlEventArgs e)
        {
            onePanelChanged(null, null);
        }

        private void variableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.locked  = true;
            OperationArithmetic op = new OperationArithmetic();
            op.setOperation("Var");
            op.SetText1("0");
            op.onChange += this.onePanelChanged;
            panel1.Controls.Add(op);
            this.locked = false;
        }

        private void ConditionVisual_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            string test = "";
            foreach (Control ct in panel1.Controls)
            {
                if (ct is OperationArithmetic)
                {
                    test += ((OperationArithmetic)ct).toString();
                }
                if (ct is OperationCondition)
                {
                    test += ((OperationCondition)ct).toString();
                }
            }
            /// MessageBox.Show(test);
            string s = ConditionTranslator.TranslateCondition(string.Join("", test.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries)));
            if (s == null)
            {
                if (MessageBox.Show("Error: " + ConditionTranslator.GetLastError(), "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Hand) != DialogResult.Cancel)
                    return;
                e.Cancel = false;
            }
            else
            {
                Condition condition = new Condition().GetCondition(new CharStream(s));
                if (condition == null)
                {
                    if (MessageBox.Show("Error parsing text.", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Hand) != DialogResult.Cancel)
                        return;
                    e.Cancel = false;
                }
                else
                {
                    this.Result = condition;
                    this.DialogResult = DialogResult.OK;
                    e.Cancel = false;
                }
            }
        }
    }
}
