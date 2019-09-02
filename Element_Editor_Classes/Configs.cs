using ElementEditor.classes;
using PWDataEditorPaied.Element_Editor_Classes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ElementEditor.classes
{
    [Serializable]
    public class Configs
    {
        public bool autoOpen = false;
        public bool autoSave = false;
        public bool autLoadelements = false;
        public String lastElementsLocation = null;
        public Dictionary<int, ConvertElements> currentConvertSettings = new Dictionary<int, ConvertElements>();
        public bool exportClipboardWithRules = false;
        public Dictionary<int, Profile> profiles = new Dictionary<int, Profile>();
        public String keyString = "root";
        public int computerCount = 1;
        public bool autoNewId = false;
        public bool autonewIdCTRLV = false;
        public int nextAutoNewId = 0;
        public bool muteSounds = true;
        public bool enableDisableLiveCacheRefresh = true;

        public ConvertElements GetExportConfig(int currentElVersion, int ImportVersion)
        {
            return currentConvertSettings.Values.ToList().FirstOrDefault(x=>x.versionFrom == ImportVersion && x.versionTo == currentElVersion);
        }
    }
}
