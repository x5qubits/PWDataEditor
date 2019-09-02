using System;
using System.Collections.Generic;
using System.Text;

namespace Shield.classes.oops
{
    public class IFacade
    {
        public Dictionary<string, INotification> classes = new Dictionary<string, INotification>();

		public void sendNotification(String protocol, BaseSocketPacket data)
        { 
            if (classes.ContainsKey(protocol))
            {
                classes[protocol].execute(data);
            }
		}

        public void registerMediator(String protocol, INotification data)
        {
            if (!classes.ContainsKey(protocol))
            {
                classes[protocol] = data;
            }
        }
        public void removeMediator(String protocol)
        {
            if (classes.ContainsKey(protocol))
            {
                classes.Remove(protocol);
            }
        }
    }
}
