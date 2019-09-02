using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PWDataEditorPaied.Element_Editor_Classes
{
    public class DBDataGridView : DataGridView
    {
        public new bool DoubleBuffered
        {
            get { return base.DoubleBuffered; }
            set { base.DoubleBuffered = value; }
        }

        public DBDataGridView()
        {
            DoubleBuffered = true;
        }

    }
}
