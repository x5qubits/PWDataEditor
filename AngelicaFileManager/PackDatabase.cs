using System;
using System.Collections.Generic;
using System.IO;
using Ultimate_Editor.Clases.AngelicaFileManager;

namespace PWDataEditorPaied.AngelicaFileManager
{
    public class PackDatabase
    {
        public static Dictionary<string, PackHelper> packManager = new Dictionary<string, PackHelper>();

        private static PackDatabase instance;

        private PackDatabase() { }

        public static PackDatabase Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PackDatabase();
                }
                return instance;
            }
        }

        public PackHelper getManager(string name, string path, Action doneEvent = null, bool isThred = true)
        {
            if(path == null || name == null)
                return null;

            if(!File.Exists(path))
            {
                return null;
            }

            if (packManager.ContainsKey(name))
            {
                PackHelper pkh = packManager[name];
                pkh.ReadTableIsDone = doneEvent;
                if (pkh.initiated)
                    if (doneEvent != null)
                        doneEvent.Invoke();

                return pkh;
            }
            else
            {
                PackHelper pkh = new PackHelper(path, isThred);
                pkh.progress_bar += dummy;
                packManager[name] = pkh;
                pkh.ReadTableIsDone = doneEvent;
                return pkh;
            }

        }

        private void dummy(string value, int min, int max)
        {

        }

        public PackHelper getManager(string name)
        {
            return packManager.ContainsKey(name) ? packManager[name] : null;
        }

        public void Clear()
        {
            foreach(KeyValuePair<string, PackHelper> aaa in packManager)
            {
                packManager[aaa.Key].Dispose();
            }
        }
    }
}
