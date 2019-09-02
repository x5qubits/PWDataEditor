using Shield.classes.oops;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using PWDataEditorPaied.PW_Admin_classes.IWEB;
using System.Windows.Forms;

namespace PWDataEditorPaied.OOP_NET.oops.mediator
{
    public class SavePermisionGM : INotification
    {
        public void execute(BaseSocketPacket data)
        {
            Dictionary<string, object> response = (Dictionary<string, object>)data.value;
            if (response.ContainsKey("result"))
            {
                int resp = int.Parse(response["result"].ToString());
                switch (resp)
                {
                    case 0:
                        PWAdmin.getInstance().unlockGMPANEL();
                        break;
                    case 10000:
                        PWAdmin.getInstance().unlockGMPANEL();
                        MessageBox.Show("Character roleId/userId must be numeric!");
                        break;
                    default:
                        PWAdmin.getInstance().unlockGMPANEL();
                        MessageBox.Show("Unknown server errror!");
                        break;
                }
            }
        }
    }
}
