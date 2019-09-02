using System;
using System.Collections.Generic;
using System.Text;

namespace Shield.classes.oops
{
    public interface INotification
    {
        void execute(BaseSocketPacket data);
    }
}
