using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PWDataEditorPaied.helper_classes
{
    public class ElementAddons
    {

        public string getType(int type, string value)
        {
            switch(type)
            {
                case 1:
                    return "Physical Attack:";
                case 2:
                    return "Maximum Physical Attack:";
                case 3:
                    return "Physical Attack "+ value +" %.";
                case 4:
                    return "Maximum Magic Attack:";
                case 5:
                    return "Magic Attack # %.";
                case 6:
                    return "+Physical. Res.";

                default:
                    return "Unknown";
            }


        }

    }
}
