using Gpckx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pck_Guy_View
{
    public class FolderTreeModel
    {
        public string Title { get; set; }
        public PckEntry File { get; set; }
        public List<FolderTreeModel> Rows { get; set; }
    }
}
