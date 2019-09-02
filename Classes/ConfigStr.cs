using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWDataEditorPaied.Classes
{
    public class ConfigStr
    {
        public int GridSize;
        public int ImageXoffset;
        public int rows;
        public int cols;
        public int ImageYoffset;
        public int rowsStart;
        public int colsStart;

        public int ImageSize { get; internal set; }
    }
}
