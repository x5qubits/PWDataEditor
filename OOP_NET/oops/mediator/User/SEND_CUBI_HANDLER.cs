using Shield.classes.oops;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PWDataEditorPaied.OOP_NET.oops.mediator.User
{
    public class SEND_CUBI_HANDLER : INotification
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
                        if (response.ContainsKey("afected"))
                        {
                            MessageBox.Show("Succesfuly changed: "+ response["afected"] + " rows.");
                        }
                        PWAdmin.getInstance().updateAccountManagment();
                        break;
                    default:
                        MessageBox.Show("Unable to run the query now. Please try again later!");
                        PWAdmin.getInstance().updateAccountManagment();
                        break;

                }
            }
        }
    }
}
