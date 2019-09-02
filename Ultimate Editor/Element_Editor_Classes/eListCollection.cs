using ElementEditor.Element_Editor_Classes;
using PWDataEditorPaied.helper_classes;
using PWnpcEditor;
using SkillXMLEditor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;
using System.Windows.Forms;

namespace ElementEditor.classes
{
    [Serializable]
    public class eListCollection 
    {
        internal delegate void UpdateProgressDelegate(String value, int min, int max);
        internal event UpdateProgressDelegate progress_bar;
        public short Version;
        public short Signature;
        public int ConversationListIndex;
        public String ConfigFile;
        public String loadedFile;
        public eList[] Lists;
        public IDictionary<int, ItemDupe> ocupiedIds = new Dictionary<int, ItemDupe>(); //itemID list
        public IDictionary<int, ItemDupe> ocupiedIds_duplicate = new Dictionary<int, ItemDupe>(); //itemID list
        public IDictionary<int, int> addonIndex = new Dictionary<int, int>(); //itemID list
        public IDictionary<int, SkillText> skillNames = new Dictionary<int, SkillText>(); //itemID list
        public IDictionary<int, ItemDupe> valuableItems = new Dictionary<int, ItemDupe>(); //itemID list
        public IDictionary<int, ItemDupe> NPCSellServices = new Dictionary<int, ItemDupe>(); 
        public IDictionary<int, ItemDupe> NPCReciveQuests = new Dictionary<int, ItemDupe>();
        public IDictionary<int, ItemDupe> NPCActivateQuests = new Dictionary<int, ItemDupe>();
        public IDictionary<int, ItemDupe> NPCTasks = new Dictionary<int, ItemDupe>();
        public IDictionary<int, ItemDupe> NPCSkill = new Dictionary<int, ItemDupe>();
        public IDictionary<int, ItemDupe> NPCCraftingService = new Dictionary<int, ItemDupe>();
        public IDictionary<int, ItemDupe> NPCEngraveService = new Dictionary<int, ItemDupe>();
        public IDictionary<int, ItemDupe> NPCHoneService = new Dictionary<int, ItemDupe>();
        public IDictionary<int, ItemDupe> MONSTERS = new Dictionary<int, ItemDupe>();
        public IDictionary<int, ItemDupe> NPCTYPE = new Dictionary<int, ItemDupe>();
        public IDictionary<int, ItemDupe> FORCES = new Dictionary<int, ItemDupe>();

        public int getNextFreeId(int lastautoSavedId, TextBox nextautoIdlabel, TextBox nextautoIdlabelmax)
        {

            int defStartId = 30000;
            int defStartIdMax = 60000;
            if (nextautoIdlabel != null && nextautoIdlabelmax != null)
            {
                int val = 0;
                int valm = 0;
                bool da = int.TryParse(nextautoIdlabel.Text, out val);
                bool dam = int.TryParse(nextautoIdlabelmax.Text, out valm);
                if (da && dam)
                {
                    if (valm > val)
                    {
                        defStartId = val;
                        defStartIdMax = valm;
                    }

                }
            }

            if (lastautoSavedId == 0)
            {
                lastautoSavedId = defStartId;
            }
            int minID = lastautoSavedId;
            while (minID <= defStartIdMax)
            {
                if (!ocupiedIds.ContainsKey(minID))
                {
                    break;
                }
                minID++;
            }
            return minID;
        }
        public int getNextFreeId2(int lastautoSavedId)
        { 
            if(lastautoSavedId == 0)
            {
             lastautoSavedId = 30000;
            }
            int minID = lastautoSavedId;
            while(true)
            {
                if(!ocupiedIds.ContainsKey(minID))
                {
                    break;
                }
                minID++;
            }
            return minID;
        }
        public ItemDupe getItem(int itemId)
        {
            if(ocupiedIds.ContainsKey(itemId))
            {
                return this.ocupiedIds[itemId];
            }
            return null;
        }
        public void useFreeId(int idtest, int l, int e)
        {
            if (!ocupiedIds.ContainsKey(idtest))
            {
                ItemDupe itemDupe = new ItemDupe();
                itemDupe.count = 1;
                itemDupe.listID = l;
                itemDupe.index = e;
                ocupiedIds.Add(idtest, itemDupe);
            }
            else
            {
                if (!ocupiedIds_duplicate.ContainsKey(idtest))
                {
                    ItemDupe itemDupe = new ItemDupe();
                    itemDupe.count = 1;
                    itemDupe.listID = l;
                    itemDupe.index = e;
                    ocupiedIds_duplicate.Add(idtest, itemDupe);
                }
                else
                {
                    ocupiedIds_duplicate[idtest].count++;
                }

            }
        }
        public void setLists(eList[] _Lists)
        {
            Lists = _Lists;
        }
        public void RemoveItem(int ListIndex, int ElementIndex)
        {
            Lists[ListIndex].RemoveItem(ListIndex, ElementIndex);
        }
        public void AddItem(int ListIndex, Dictionary<int,object> ItemValues)
        {
            Lists[ListIndex].AddItem(ListIndex, ItemValues);
        }
        public String GetOffset(int ListIndex)
        {
            return BitConverter.ToString(Lists[ListIndex].listOffset);
        }
        public void SetOffset(int ListIndex, String Offset)
        {
            if (Offset != "")
            {
                // Convert from Hex to byte[]
                String[] hex = Offset.Split('-');
                Lists[ListIndex].listOffset = new byte[hex.Length];
                for (int i = 0; i < hex.Length; i++)
                {
                    Lists[ListIndex].listOffset[i] = Convert.ToByte(hex[i], 16);
                }
            }
            else
            {
                Lists[ListIndex].listOffset = new byte[0];
            }
        }
        public String GetValue(int ListIndex, int ElementIndex, int FieldIndex)
        {
            return Lists[ListIndex].GetValue(ElementIndex, FieldIndex);
        }
        public void SetValue(int ListIndex, int ElementIndex, int FieldIndex, String Value)
        {
            Lists[ListIndex].SetValue(ElementIndex, FieldIndex, Value);
        }
        public String GetType(int ListIndex, int FieldIndex)
        {
            return Lists[ListIndex].GetType(FieldIndex);
        }
        public Object readValue(BinaryReader br, String type)
        {
            if (type == "int16")
            {
                return br.ReadInt16();
            }
            if (type == "int32")
            {
                return br.ReadInt32();
            }
            if (type == "int64")
            {
                return br.ReadInt64();
            }
            if (type == "float")
            {
                return br.ReadSingle();
            }
            if (type == "double")
            {
                return br.ReadDouble();
            }
            if (type.Contains("byte:"))
            {
                return br.ReadBytes(Convert.ToInt32(type.Substring(5)));
            }
            if (type.Contains("wstring:"))
            {
                return br.ReadBytes(Convert.ToInt32(type.Substring(8)));
            }
            if (type.Contains("string:"))
            {
                return br.ReadBytes(Convert.ToInt32(type.Substring(7)));
            }
            return null;
        }
        public Object getDefaultValue(String type)
        {
            if (type == "int16")
            {
                return (short)0;
            }
            if (type == "int32")
            {
               return (int)0;
            }
            if (type == "int64")
            {
                return (long)0;
            }
            if (type == "float")
            {
                return (float)0;
            }
            if (type == "double")
            {
                return (double)0;
            }
            if (type.Contains("byte:"))
            {
                String[] tmp = type.Split(':');
                return new byte[Int32.Parse(tmp[1])];
            }
            if (type.Contains("wstring:"))
            {
                String[] tmp = type.Split(':');
                return new byte[Int32.Parse(tmp[1])];
            }
            if (type.Contains("string:"))
            {
                String[] tmp = type.Split(':');
                return new byte[Int32.Parse(tmp[1])];
            }
            return null;
        }
        private void writeValue(BinaryWriter bw, Object value, String type)
        {
            if (type == "int16")
            {
                bw.Write((short)value);
                return;
            }
            if (type == "int32")
            {
                bw.Write((int)value);
                return;
            }
            if (type == "int64")
            {
                bw.Write((long)value);
                return;
            }
            if (type == "float")
            {
                bw.Write((float)value);
                return;
            }
            if (type == "double")
            {
                bw.Write((double)value);
                return;
            }
            if (type.Contains("byte:"))
            {
                bw.Write((byte[])value);
                return;
            }
            if (type.Contains("wstring:"))
            {
                bw.Write((byte[])value);
                return;
            }
            if (type.Contains("string:"))
            {
                bw.Write((byte[])value);
                return;
            }
        }
        private eList[] loadConfiguration(String file)
        {
            StreamReader sr = new StreamReader(file);
            eList[] Li = new eList[Convert.ToInt32(sr.ReadLine())];
            try
            {
                ConversationListIndex = Convert.ToInt32(sr.ReadLine());
            }
            catch (Exception)
            {
                ConversationListIndex = 58;
            }
            String line;
            for (int i = 0; i < Li.Length; i++)
            {
                System.Windows.Forms.Application.DoEvents();
                progress_bar("Loading Configurations...", i, Li.Length);
                while ((line = sr.ReadLine()) == "")
                {
                }
                Li[i] = new eList();
                try
                {
                    Li[i].listName = line.Split('-')[1].TrimStart();
                }
                catch
                {
                    Li[i].listName = line;
                }
                Li[i].listOffset = null;
                String offset = sr.ReadLine();
                if (offset != "AUTO")
                {
                    Li[i].listOffset = new byte[Convert.ToInt32(offset)];
                }
                String[] a = sr.ReadLine().Split(';');
                String[] b = sr.ReadLine().Split(';');
                Dictionary<int, string> aa = new Dictionary<int, string>();
                Dictionary<int, string> ab = new Dictionary<int, string>();
                for (int x = 0; x < a.Length; x++)
                {
                    aa.Add(x, a[x].ToString());
                }
                for (int xx = 0; xx < b.Length; xx++)
                {
                    ab.Add(xx, b[xx].ToString());
                }
                Li[i].elementFields = aa;
                Li[i].elementTypes = ab;
            }
            sr.Close();
            progress_bar("Ready", 0, 0);
            return Li;
        }
        public eList[] loadEmptyConfigs(int version)
        {
            eList[] Li = new eList[0];
            // check if a corresponding configuration file exists
            String[] configFiles = Directory.GetFiles(Application.StartupPath + "\\configs\\Rules\\", "PW_*_v" + version + ".cfg");
            if (configFiles.Length > 0)
            {
                // configure an eList array with the configuration file
                ConfigFile = configFiles[0];
                Li = loadConfiguration(ConfigFile);

            }


           return Li;
        }
        // only works for PW !!!
        public eList[] Load(String elFile)
        {
            this.loadedFile = elFile;
            eList[] Li = new eList[0];
            addonIndex = new Dictionary<int, int>();
            try
            {
                Helper.subtypesInfolist = new Dictionary<int, SubTypeElement>();
                // open the element file
                FileStream fs = File.OpenRead(elFile);
                BinaryReader br = new BinaryReader(fs);
                Version = br.ReadInt16();
                Signature = br.ReadInt16();
                // check if a corresponding configuration file exists
                String[] configFiles = Directory.GetFiles(Application.StartupPath + "\\configs\\Rules\\", "PW_*_v" + Version + ".cfg");
                if (configFiles.Length > 0)
                {
                    // configure an eList array with the configuration file
                    ConfigFile = configFiles[0];
                    Li = loadConfiguration(ConfigFile);
                    // read the element file

                    for (int l = 0; l < Li.Length; l++)
                    {

                        Application.DoEvents();
                        progress_bar("Reading elements ...", l, Li.Length);

                        // read offset
                        if (Li[l].listOffset != null)
                        {
                            // offset > 0
                            if (Li[l].listOffset.Length > 0)
                            {
                                Li[l].listOffset = br.ReadBytes(Li[l].listOffset.Length);
                            }
                        }
                        // autodetect offset (for list 20 & 100)
                        else
                        {
                            if (l == 20)
                            {
                                byte[] head = br.ReadBytes(4);
                                byte[] count = br.ReadBytes(4);
                                byte[] body = br.ReadBytes(BitConverter.ToInt32(count, 0));
                                byte[] tail = br.ReadBytes(4);
                                Li[l].listOffset = new byte[head.Length + count.Length + body.Length + tail.Length];
                                Array.Copy(head, 0, Li[l].listOffset, 0, head.Length);
                                Array.Copy(count, 0, Li[l].listOffset, 4, count.Length);
                                Array.Copy(body, 0, Li[l].listOffset, 8, body.Length);
                                Array.Copy(tail, 0, Li[l].listOffset, 8 + body.Length, tail.Length);
                            }
                            if (l == 100)
                            {
                                byte[] head = br.ReadBytes(4);
                                byte[] count = br.ReadBytes(4);
                                byte[] body = br.ReadBytes(BitConverter.ToInt32(count, 0));
                                Li[l].listOffset = new byte[head.Length + count.Length + body.Length];
                                Array.Copy(head, 0, Li[l].listOffset, 0, head.Length);
                                Array.Copy(count, 0, Li[l].listOffset, 4, count.Length);
                                Array.Copy(body, 0, Li[l].listOffset, 8, body.Length);
                            }
                        }

                        // read conversation list
                        if (l == ConversationListIndex)
                        {
                            // Auto detect only works for Perfect World elements.data !!!
                            if (Li[l].elementTypes[0].Contains("AUTO"))
                            {
                                byte[] pattern = (Encoding.GetEncoding("GBK")).GetBytes("facedata\\");
                                long sourcePosition = br.BaseStream.Position;
                                int listLength = -72 - pattern.Length;
                                bool run = true;
                                while (run)
                                {
                                    run = false;
                                    for (int i = 0; i < pattern.Length; i++)
                                    {
                                        listLength++;
                                        if (br.ReadByte() != pattern[i])
                                        {
                                            run = true;
                                            break;
                                        }
                                    }
                                }
                                br.BaseStream.Position = sourcePosition;
                                Li[l].elementTypes[0] = "byte:" + listLength;
                            }

                            Li[l].elementValues = new Dictionary<int, Dictionary<int, Object>>();
                            Li[l].elementValues[0] = new Dictionary<int, Object>();
                            Li[l].elementValues[0][0] = readValue(br, Li[l].elementTypes[0]);
                        }
                        // read lists
                        else
                        {
                            Li[l].elementValues = new Dictionary<int, Dictionary<int, Object>>();

                            int count = br.ReadInt32();
                            // go through all elements of a list
                            for (int e = 0; e < count; e++)
                            {
                                Li[l].elementValues[e] = new Dictionary<int, Object>();

                                int id = -1;
                                String name = "";
                                // go through all fields of an element
                                int idnpc = -1;
                                String namenpc = "";
                                int idtest = -1;
                                for (int f = 0; f < Li[l].elementTypes.Count; f++)
                                {
                                    Li[l].elementValues[e][f] = readValue(br, Li[l].elementTypes[f]);
                                    if (Li[l].elementFields[f] == "ID")
                                    {
                                        idtest = Int32.Parse(Li[l].GetValue(e, f));
                                        if(l == 0)
                                        {
                                            if(!addonIndex.ContainsKey(idtest))
                                            {
                                                addonIndex.Add(idtest, e);
                                            }else
                                            {
                                                MessageBox.Show("Error: Found duplicate Addon id:" + idtest);
                                                addonIndex[idtest] = e;
                                            }
                                        }
                                        if (!ocupiedIds.ContainsKey(idtest))
                                        {
                                            ItemDupe itemDupe = new ItemDupe();
                                            itemDupe.count = 1;
                                            itemDupe.listID = l;
                                            itemDupe.index = e;
                                            ocupiedIds.Add(idtest, itemDupe);
                                        }
                                        else
                                        {
                                            if (!ocupiedIds_duplicate.ContainsKey(idtest))
                                            {
                                                ItemDupe itemDupe = new ItemDupe();
                                                itemDupe.count = 1;
                                                itemDupe.listID = l;
                                                itemDupe.index = e;
                                                ocupiedIds_duplicate.Add(idtest, itemDupe);
                                            }
                                            else
                                            {
                                                ocupiedIds_duplicate[idtest].count++;
                                            }

                                        }
                                    }
                                    if (Li[l].elementFields[f] == "Name" && idtest > 0)
                                    {
                                        if (ocupiedIds_duplicate.ContainsKey(idtest))
                                        {
                                            ocupiedIds_duplicate[idtest].itemId = idtest;
                                            ocupiedIds_duplicate[idtest].name = Li[l].GetValue(e, f);
                                        }
                                        if (ocupiedIds.ContainsKey(idtest))
                                        {
                                            ocupiedIds[idtest].itemId = idtest;
                                            ocupiedIds[idtest].name = Li[l].GetValue(e, f);
                                        }

                                        int[] whereToSearch = new int[] { 3, 6, 9, 12, 15, 17, 19, 21, 22, 23, 24, 28, 30, 31, 35, 74, 75, 79, 89, 95, 106, 114, 115, 116 , 33};
                                        if (whereToSearch.Contains<int>(l))
                                        {
                                            ItemDupe itemDupe = new ItemDupe();
                                            itemDupe.count = 1;
                                            itemDupe.listID = l;
                                            itemDupe.index = e;
                                            itemDupe.name = Li[l].GetValue(e, f);
                                            itemDupe.itemId = idtest;
                                            valuableItems[idtest] = itemDupe;
                                        }
                                        if(l == 40)
                                        {
                                            ItemDupe itemDupe = new ItemDupe();
                                            itemDupe.count = 1;
                                            itemDupe.listID = l;
                                            itemDupe.index = e;
                                            itemDupe.name = Li[l].GetValue(e, f);
                                            itemDupe.itemId = idtest;
                                            NPCSellServices[idtest] = itemDupe;
                                        }
                                        if (l == 45)
                                        {
                                            ItemDupe itemDupe = new ItemDupe();
                                            itemDupe.count = 1;
                                            itemDupe.listID = l;
                                            itemDupe.index = e;
                                            itemDupe.name = Li[l].GetValue(e, f);
                                            itemDupe.itemId = idtest;
                                            NPCReciveQuests[idtest] = itemDupe;
                                        }
                                        if (l == 46)
                                        {
                                            ItemDupe itemDupe = new ItemDupe();
                                            itemDupe.count = 1;
                                            itemDupe.listID = l;
                                            itemDupe.index = e;
                                            itemDupe.name = Li[l].GetValue(e, f);
                                            itemDupe.itemId = idtest;
                                            NPCActivateQuests[idtest] = itemDupe;
                                        }
                                        if (l == 47)
                                        {
                                            ItemDupe itemDupe = new ItemDupe();
                                            itemDupe.count = 1;
                                            itemDupe.listID = l;
                                            itemDupe.index = e;
                                            itemDupe.name = Li[l].GetValue(e, f);
                                            itemDupe.itemId = idtest;
                                            NPCTasks[idtest] = itemDupe;
                                        }
                                        if (l == 48)
                                        {
                                            ItemDupe itemDupe = new ItemDupe();
                                            itemDupe.count = 1;
                                            itemDupe.listID = l;
                                            itemDupe.index = e;
                                            itemDupe.name = Li[l].GetValue(e, f);
                                            itemDupe.itemId = idtest;
                                            NPCSkill[idtest] = itemDupe;
                                        }
                                        if (l == 54)
                                        {
                                            ItemDupe itemDupe = new ItemDupe();
                                            itemDupe.count = 1;
                                            itemDupe.listID = l;
                                            itemDupe.index = e;
                                            itemDupe.name = Li[l].GetValue(e, f);
                                            itemDupe.itemId = idtest;
                                            NPCCraftingService[idtest] = itemDupe;
                                        }
                                        if (l == 145)
                                        {
                                            ItemDupe itemDupe = new ItemDupe();
                                            itemDupe.count = 1;
                                            itemDupe.listID = l;
                                            itemDupe.index = e;
                                            itemDupe.name = Li[l].GetValue(e, f);
                                            itemDupe.itemId = idtest;
                                            NPCEngraveService[idtest] = itemDupe;
                                        }
                                        if (l == 146)
                                        {
                                            ItemDupe itemDupe = new ItemDupe();
                                            itemDupe.count = 1;
                                            itemDupe.listID = l;
                                            itemDupe.index = e;
                                            itemDupe.name = Li[l].GetValue(e, f);
                                            itemDupe.itemId = idtest;
                                            NPCHoneService[idtest] = itemDupe;
                                        }
                                        if (l == 38)
                                        {
                                            ItemDupe itemDupe = new ItemDupe();
                                            itemDupe.count = 1;
                                            itemDupe.listID = l;
                                            itemDupe.index = e;
                                            itemDupe.name = Li[l].GetValue(e, f);
                                            itemDupe.itemId = idtest;
                                            MONSTERS[idtest] = itemDupe;
                                        }
                                        if (l == 56)
                                        {
                                            ItemDupe itemDupe = new ItemDupe();
                                            itemDupe.count = 1;
                                            itemDupe.listID = l;
                                            itemDupe.index = e;
                                            itemDupe.name = Li[l].GetValue(e, f);
                                            itemDupe.itemId = idtest;
                                            NPCTYPE[idtest] = itemDupe;
                                        }
                                        if (l == 150)
                                        {
                                            ItemDupe itemDupe = new ItemDupe();
                                            itemDupe.count = 1;
                                            itemDupe.listID = l;
                                            itemDupe.index = e;
                                            itemDupe.name = Li[l].GetValue(e, f);
                                            itemDupe.itemId = idtest;
                                            FORCES[idtest] = itemDupe;
                                        }
                                        
                                        // 32227
                                    }
                                    if (l == 38 || l == 57 || l == 79)
                                    {
                                        if (Li[l].elementFields[f] == "ID")
                                        {
                                            idnpc = Int32.Parse(Li[l].GetValue(e, f));
                                            // NpcEditor.npcdb
                                        }
                                        if (Li[l].elementFields[f] == "Name")
                                        {
                                            namenpc = Li[l].GetValue(e, f);

                                                NpcEditor.npcdb[idnpc] = namenpc;

                                        }
                                    }
                                    if (Helper.list_supdype.ContainsKey(l))
                                    {

                                        if (Li[l].elementFields[f] == "ID")
                                        {
                                            id = Int32.Parse(Li[l].GetValue(e, f));
                                        }
                                        if (Li[l].elementFields[f] == "Name")
                                        {
                                            name = Li[l].GetValue(e, f);
                                            SubTypeElement ste = new SubTypeElement();
                                            if (Helper.list_supdype[l].type == Constatns.typeSubType)
                                            {
                                                if (Helper.subtypesInfolist.ContainsKey(Helper.list_supdype[l].useonList))
                                                {
                                                    if(!Helper.subtypesInfolist[Helper.list_supdype[l].useonList].subtype.ContainsKey(id))
                                                        Helper.subtypesInfolist[Helper.list_supdype[l].useonList].subtype.Add(id, name);
                                                }
                                                else
                                                {
                                                    Helper.subtypesInfolist.Add(Helper.list_supdype[l].useonList, ste);
                                                    Helper.subtypesInfolist[Helper.list_supdype[l].useonList].subtype.Add(id, name);
                                                }
                                            }

                                            if (Helper.list_supdype[l].type == Constatns.typeMajorType)
                                            {
                                                if (Helper.subtypesInfolist.ContainsKey(Helper.list_supdype[l].useonList))
                                                {
                                                    if (!Helper.subtypesInfolist[Helper.list_supdype[l].useonList].majorType.ContainsKey(id))
                                                    {
                                                        Helper.subtypesInfolist[Helper.list_supdype[l].useonList].majorType.Add(id, name);
                                                    }
                                                }
                                                else
                                                {
                                                    Helper.subtypesInfolist.Add(Helper.list_supdype[l].useonList, ste);
                                                    Helper.subtypesInfolist[Helper.list_supdype[l].useonList].majorType.Add(id, name);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No corressponding configuration file found!\nVersion: " + Version + "\nPattern: " + "configs\\PW_*_v" + Version + ".cfg");
                }
                br.Close();
                fs.Close();
                Application.DoEvents();
                progress_bar("Ready", 0, 0);
                Program.elementSeditorFirstLoad = false;
            }catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            return Li;
        }
        public bool Save(String elFile)
        {
            if (File.Exists(elFile))
            {
                File.Delete(elFile);
            }

            FileStream fs = new FileStream(elFile, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);

            bw.Write(Version);
            bw.Write(Signature);

            // go through all lists
            for (int list = 0; list < Lists.Length; list++)
            {
                System.Windows.Forms.Application.DoEvents();
                progress_bar("Saving elements ...", list, Lists.Length);
                if (Lists[list].listOffset.Length > 0)
                {
                    bw.Write(Lists[list].listOffset);
                }

                if (list != ConversationListIndex)
                {
                    bw.Write(Lists[list].elementValues.Count);
                }

                // go through all elements of a list
                for (int item = 0; item < Lists[list].elementValues.Count; item++)
                {
                    // go through all fields of an element
                    for (int row = 0; row < Lists[list].elementValues[item].Count; row++)
                    {
                        writeValue(bw, Lists[list].elementValues[item][row], Lists[list].elementTypes[row]);
                    }
                }
            }
            bw.Close();
            fs.Close();
            progress_bar("Ready", 0, 0);
            return true;
        }
    }
}
