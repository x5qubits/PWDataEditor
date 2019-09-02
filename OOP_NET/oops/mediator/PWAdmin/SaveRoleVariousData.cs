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
    public class SaveRoleVariousData : INotification
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
                        PWAdmin.getInstance().igotResponseFromSave();
                        MessageBox.Show("All data saved successfully!");
                        break;
                    case 10000:
                        PWAdmin.getInstance().igotResponseFromSave();
                        MessageBox.Show("XML Error please re-check your xml data!");
                        break;
                    case 101:
                        PWAdmin.getInstance().igotResponseFromSave();
                        MessageBox.Show("Game Database Demon refused to save the data!");
                        break;
                    default:
                        PWAdmin.getInstance().igotResponseFromSave();
                        MessageBox.Show("XML Error please re-check your xml data!");
                        break;
                }

            }
        }
    }
}