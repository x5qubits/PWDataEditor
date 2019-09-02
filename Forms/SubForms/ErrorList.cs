using ElementEditor;
using JHUI.Animation;
using JHUI.Forms;
using PWDataEditorPaied.Database.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PWDataEditorPaied.Forms.SubForms
{
    public partial class ErrorList : JForm
    {
        private List<ErrorClass> errors = new List<ErrorClass>();
        private bool locked = true;
        public ErrorList(List<ErrorClass> values)
        {
            errors = values;
            InitializeComponent();
            this.Opacity = 0;
            listBox_items.Rows.Clear();
            foreach (ErrorClass err in errors)
            {
                listBox_items.Rows.Add(new object[] { err.listId, err.itemId, err.msg });
            }
            new JAnimate().FadeInForm(this, 10, Done);
        }

        private void Done()
        {
            locked = false;
        }

        private void listBox_items_SelectionChanged(object sender, EventArgs e)
        {
            if (locked) return;
            locked = true;
            if (listBox_items.CurrentCell != null)
            {
                int element = listBox_items.CurrentCell.RowIndex;

                ElementsEditor.Instance.setIndex(errors[element]);

            }
            Done();
        }

        private void listBox_items_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (locked) return;
            locked = true;
            if (listBox_items.CurrentCell != null)
            {
                int element = listBox_items.CurrentCell.RowIndex;

                ElementsEditor.Instance.setIndex(errors[element]);

            }
            Done();
        }
    }
}
