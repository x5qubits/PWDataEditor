using Shield.classes.oops;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PWDataEditorPaied.OOP_NET.oops.mediator.User
{
    public class CHANGEPWD_ACCOUNT_HANDLER : INotification
    {
        public void execute(BaseSocketPacket data)
        {
            Dictionary<string, object> response = (Dictionary<string, object>)data.value;
            if (response.ContainsKey("result"))
            {
                int result = int.Parse(response["result"].ToString());
                switch (result)
                {
                    case 0:
                        PWAdmin.getInstance().updateAccountManagment();
                        break;
                    case 100:
                        MessageBox.Show("Invalid username. Must be between 4 and 16 alfanum characters.");
                        PWAdmin.getInstance().updateAccountManagment();
                        break;
                    case 101:
                        MessageBox.Show("Invalid password. Must be between 4 and 19 caseSensitve alfanum + ['#','@'.'!'] characters.");
                        PWAdmin.getInstance().updateAccountManagment();
                        break;
                    case 102:
                        MessageBox.Show("Invalid encryption.");
                        PWAdmin.getInstance().updateAccountManagment();
                        break;
                    case 200:
                        if (response.ContainsKey("ERR"))
                        {
                            MessageBox.Show("Sql Exception:" + response["ERR"].ToString());
                        }
                        else
                        {
                            MessageBox.Show("Sql Exception.");
                        }
                        PWAdmin.getInstance().updateAccountManagment();
                        break;
                    default:
                        PWAdmin.getInstance().updateAccountManagment();
                        break;

                }
            }
        }
    }
}
