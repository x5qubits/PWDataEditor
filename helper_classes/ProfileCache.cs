using ElementEditor.classes;
using ElementEditor.Game_Shop_classes;
using PWnpcEditor.classes;
using sTASKedit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;

namespace PWDataEditorPaied.helper_classes
{
    [Serializable]
    public class ProfileCache
    {
        public Boutique GSHOP = null;
        public eListCollection ELEMENT = null;
        public ATaskTemplFixedData[] TASK = null;
        public NPCALL NPC = null;
    }
}
