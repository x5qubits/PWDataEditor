using ElementEditor.Element_Editor_Classes;
using JHUI.Controls;
using PWDataEditorPaied.Database;
using PWDataEditorPaied.Database.Utils;
using PWnpcEditor;
using SkillXMLEditor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Threading;

namespace ElementEditor.classes
{
    [Serializable]
    public class eListCollection
    {
        internal delegate void UpdateProgressDelegate(string value, int min, int max);
        internal event UpdateProgressDelegate progress_bar;
        public short Version;
        public short Signature;
        public int ConversationListIndex;
        public int RecipeListIndex = 69;
        public int HomeItemsListIndex = 223;
        public int TitleListIndex = 169;
        public int SaleServiceListIndex = 40;
        public int CraftServiceListIndex = 54;
        public int EngraveServiceListIndex = 145;
        public int HoneServiceListIndex = 146;
        public int ForcesListIndex = 150;
        public int MineEssenceList = 79;

        public int Pets = 94;
        public int PetEggs = 95;

        public string ConfigFile;
        public string loadedFile;
        public eList[] Lists;
        public SortedList<int, ItemDupe> ocupiedIds = new SortedList<int, ItemDupe>(); //itemID list
        public SortedList<int, ItemDupe> ocupiedIds_duplicate = new SortedList<int, ItemDupe>(); //itemID list
        public SortedList<int, int> addonIndex = new SortedList<int, int>(); //itemID list
        public SortedList<int, SkillText> skillNames = new SortedList<int, SkillText>(); //itemID list
        public SortedList<int, ItemDupe> valuableItems = new SortedList<int, ItemDupe>(); //itemID list
        public SortedList<int, ItemDupe> NPCSellServices = new SortedList<int, ItemDupe>();
        public SortedList<int, ItemDupe> NPCReciveQuests = new SortedList<int, ItemDupe>();
        public SortedList<int, ItemDupe> NPCActivateQuests = new SortedList<int, ItemDupe>();
        public SortedList<int, ItemDupe> NPCTasks = new SortedList<int, ItemDupe>();
        public SortedList<int, ItemDupe> NPCSkill = new SortedList<int, ItemDupe>();
        public SortedList<int, ItemDupe> NPCCraftingService = new SortedList<int, ItemDupe>();
        public SortedList<int, ItemDupe> NPCEngraveService = new SortedList<int, ItemDupe>();
        public SortedList<int, ItemDupe> NPCHoneService = new SortedList<int, ItemDupe>();
        public SortedList<int, ItemDupe> MONSTERS = new SortedList<int, ItemDupe>();
        public SortedList<int, ItemDupe> NPCTYPE = new SortedList<int, ItemDupe>();
        public SortedList<int, ItemDupe> NPCS = new SortedList<int, ItemDupe>();
        public SortedList<int, ItemDupe> RESOURCES = new SortedList<int, ItemDupe>();
        public SortedList<int, ItemDupe> FORCES = new SortedList<int, ItemDupe>();

        public SortedList<int, ItemDupe> PETS = new SortedList<int, ItemDupe>();
        public SortedList<int, ItemDupe> PET_EGGS = new SortedList<int, ItemDupe>();
        public SortedList<int, ItemDupe> PET_EGGS_ID = new SortedList<int, ItemDupe>();


        public SortedList<int, ErrorClass> errorList = new SortedList<int, ErrorClass>();
        public SortedList<short, HashSet<int>> probablilityList = new SortedList<short, HashSet<int>>();
        public bool ready = false;
        private List<Task> process;
        private CancellationTokenSource tokenSource;
        private CancellationToken token;
        private bool isRunning = false;

        public int PetIdelementPosition { get; private set; }

        public eListCollection()
        {
            tokenSource = new CancellationTokenSource();
            token = tokenSource.Token;
        }

        public int getNextFreeId(int lastautoSavedId, JLabel nextautoIdlabel)
        {

            int defStartId = 1;
            int defStartIdMax = 80000;
            if (nextautoIdlabel != null)
            {
                int val = 0;
                bool da = int.TryParse(nextautoIdlabel.Text, out val);
                if (da)
                {
                    if (defStartIdMax > val)
                    {
                        defStartId = val;
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
            if (nextautoIdlabel != null)
            {
                try
                {
                    nextautoIdlabel.Invoke(new MethodInvoker(delegate
                    {
                        nextautoIdlabel.Text = minID.ToString();
                    }));
                }
                catch { }
            }
            DatabaseManager.Instance.nextId = minID;
            return minID;
        }

        public int getNextFreeId2(int lastautoSavedId)
        {
            if (lastautoSavedId == 0)
            {
                lastautoSavedId = 30000;
            }
            int minID = lastautoSavedId;
            while (true)
            {
                if (!ocupiedIds.ContainsKey(minID))
                {
                    break;
                }
                minID++;
            }
            DatabaseManager.Instance.nextId = minID;
            return minID;
        }

        public ItemDupe getItem(int itemId)
        {
            ItemDupe ret = null;
            ocupiedIds.TryGetValue(itemId, out ret);
            return ret;
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
        public void SetLists(eList[] _Lists)
        {
            Lists = _Lists;
        }
        public void RemoveItem(int ListIndex, int ElementIndex)
        {
            Lists[ListIndex].RemoveItem(ListIndex, ElementIndex);
        }
        public int AddItem(int ListIndex, SortedList<int, object> ItemValues)
        {
            Lists[ListIndex].AddItem(ListIndex, ItemValues);
            return Lists[ListIndex].elementValues.Count - 1;
        }
        public string GetOffset(int ListIndex)
        {
            return BitConverter.ToString(Lists[ListIndex].listOffset);
        }
        public void SetOffset(int ListIndex, string Offset)
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
        public string GetValue(int ListIndex, int ElementIndex, int FieldIndex)
        {
            return Lists[ListIndex].GetValue(ElementIndex, FieldIndex);
        }
        public void SetValue(int ListIndex, int ElementIndex, int FieldIndex, string Value)
        {
            Lists[ListIndex].SetValue(ElementIndex, FieldIndex, Value);
        }
        public string GetType(int ListIndex, int FieldIndex)
        {
            return Lists[ListIndex].GetType(FieldIndex);
        }

        public object ReadValue(BinaryReader br, string type)
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

        public void TrySetValue(int listID, int FieldIndex, ref SortedList<int, object> elementValues, object Value)
        {
            try
            {
                string type = Lists[listID].elementTypes[FieldIndex];

                if (type == "int16")
                {
                    elementValues[FieldIndex] = Convert.ToInt16(Value);
                    return;
                }
                if (type == "int32")
                {
                    elementValues[FieldIndex] = Convert.ToInt32(Value);
                    return;
                }
                if (type == "int64")
                {
                    elementValues[FieldIndex] = Convert.ToInt64(Value);
                    return;
                }
                if (type == "float")
                {
                    elementValues[FieldIndex] = Convert.ToSingle(Value);
                    return;
                }
                if (type == "double")
                {
                    elementValues[FieldIndex] = Convert.ToDouble(Value);
                    return;
                }
                if (type.Contains("byte:"))
                {
                    string[] hex = Convert.ToString(Value).Split('-');
                    byte[] b = new byte[Convert.ToInt32(type.Substring(5))];
                    for (int i = 0; i < hex.Length; i++)
                    {
                        b[i] = Convert.ToByte(hex[i], 16);
                    }
                    elementValues[FieldIndex] = b;
                    return;
                }
                if (type.Contains("wstring:"))
                {
                    if (!(Value is byte[]))
                        throw new SystemException();

                    Encoding enc = Encoding.GetEncoding("Unicode");
                    byte[] target = new byte[Convert.ToInt32(type.Substring(8))];
                    byte[] source = (byte[])Value;
                    if (target.Length > source.Length)
                    {
                        Array.Copy(source, target, source.Length);
                    }
                    else
                    {
                        Array.Copy(source, target, target.Length);
                    }
                    elementValues[FieldIndex] = target;
                    return;
                }
                if (type.Contains("string:"))
                {
                    if (!(Value is byte[]))
                        throw new SystemException();

                    Encoding enc = Encoding.GetEncoding("GBK");
                    byte[] target = new byte[Convert.ToInt32(type.Substring(7))];
                    byte[] source = (byte[])Value;
                    if (target.Length > source.Length)
                    {
                        Array.Copy(source, target, source.Length);
                    }
                    else
                    {
                        Array.Copy(source, target, target.Length);
                    }
                    elementValues[FieldIndex] = target;
                    return;
                }
                return;
            }
            catch { }
        }

        public object GetDefaultValue(string type)
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
                return (float)0.0F;
            }
            if (type == "double")
            {
                return (double)0.0D;
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

        private void WriteValue(BinaryWriter bw, object value, string type)
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

        private eList[] LoadConfiguration(string file)
        {
            string allFile = File.ReadAllText(file).Replace("\r", "");
            string[] filesp = allFile.Split('\n');
            filesp = filesp.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            int ai = -1;
            eList[] Li = new eList[Convert.ToInt32(filesp[ai += 1])];
            ConversationListIndex = Convert.ToInt32(filesp[ai += 1]);
            for (int i = 0; i < Li.Length; i++)
            {
                Li[i] = new eList();
                Li[i].listName = filesp[ai += 1].ToString().Split('-')[1].TrimStart();
                string offset = filesp[ai += 1].ToString();
                if (offset != "AUTO")
                {
                    Li[i].listOffset = new byte[Convert.ToInt32(offset)];
                }
                Li[i].elementFields = filesp[ai += 1].ToString().Split(';');
                Li[i].elementTypes = filesp[ai += 1].ToString().Split(';');
            }
            return Li;
        }

        public eList[] LoadEmptyConfigs(int version)
        {
            eList[] Li = new eList[0];
            // check if a corresponding configuration file exists
            String[] configFiles = Directory.GetFiles(Application.StartupPath + "\\Configs\\Element\\Configs\\", "PW_*_v" + version + ".cfg");
            if (configFiles.Length > 0)
            {
                // configure an eList array with the configuration file
                ConfigFile = configFiles[0];
                Li = LoadConfiguration(ConfigFile);
            }
            return Li;
        }

        // only works for PW !!!
        public eList[] Load(string elFile)
        {
            LoadProbailityConfig();
            isRunning = false;
            this.loadedFile = elFile;
            eList[] Li = new eList[0];
            errorList = new SortedList<int, ErrorClass>();
            addonIndex = new SortedList<int, int>();
            process = new List<Task>();
            ready = false;
            try
            {
                Helper.subtypesInfolist = new SortedList<int, SubTypeElement>();
                // open the element file
                // FileStream fs = new FileStream(elFile, FileMode.Open, FileAccess.Read, FileShare.Read);
                MemoryStream cache = new MemoryStream(File.ReadAllBytes(elFile));
                BinaryReader br = new BinaryReader(cache);


                Version = br.ReadInt16();
                Signature = br.ReadInt16();
                // check if a corresponding configuration file exists
                String[] configFiles = Directory.GetFiles(Application.StartupPath + "\\Configs\\Element\\Configs\\", "PW_*_v" + Version + ".cfg");
                if (configFiles.Length > 0)
                {
                    // configure an eList array with the configuration file
                    ConfigFile = configFiles[0];
                    Li = LoadConfiguration(ConfigFile);
                    // read the element file
                    int cnow = 0;
                    int maxCount = 100;
                    if (maxCount > 1000)
                        maxCount = Li.Length / 200;
                    else
                        maxCount = Li.Length / 10;

                    if (maxCount <= 1)
                    {
                        maxCount = 1;
                    }
                    if (Version > 191)
                    {
                        RecipeListIndex = 68;
                        HomeItemsListIndex = 222;
                        TitleListIndex = 168;
                        SaleServiceListIndex = 40;
                        CraftServiceListIndex = 54;
                        EngraveServiceListIndex = 144;
                        HoneServiceListIndex = 145;
                        ForcesListIndex = 149;
                        MineEssenceList = 78;
                        Pets = 93;
                        PetEggs = 94;
                    }
                    else
                    {
                        RecipeListIndex = 69;
                        HomeItemsListIndex = 223;
                        TitleListIndex = 169;
                        SaleServiceListIndex = 40;
                        CraftServiceListIndex = 54;
                        EngraveServiceListIndex = 145;
                        HoneServiceListIndex = 146;
                        ForcesListIndex = 150;
                        MineEssenceList = 79;
                        Pets = 94;
                        PetEggs = 95;
                       
                    }
                    for (int l = 0; l < Li.Length; l++)
                    {
                        #region PROGRESS
                        if (cnow > maxCount)
                        {
                            Application.DoEvents();
                            progress_bar("Reading elements ...", l, Li.Length);
                            cnow = 0;
                        }
                        cnow++;
                        #endregion
                        #region read offset
                        if (Li[l].listOffset != null)
                        {
                            // offset > 0
                            if (Li[l].listOffset.Length > 0)
                            {
                                Li[l].listOffset = br.ReadBytes(Li[l].listOffset.Length);
                            }
                        }
                        #endregion
                        #region autodetect offset (for list 20 & 100)
                        else
                        {
                            if (l == 0)
                            {
                                byte[] t = br.ReadBytes(4);
                                byte[] len = br.ReadBytes(4);
                                byte[] buffer = br.ReadBytes(BitConverter.ToInt32(len, 0));
                                Li[l].listOffset = new byte[t.Length + len.Length + buffer.Length];
                                Array.Copy(t, 0, Li[l].listOffset, 0, t.Length);
                                Array.Copy(len, 0, Li[l].listOffset, 4, len.Length);
                                Array.Copy(buffer, 0, Li[l].listOffset, 8, buffer.Length);
                            }
                            if (l == 20)
                            {
                                byte[] tag = br.ReadBytes(4);
                                byte[] len = br.ReadBytes(4);
                                byte[] buffer = br.ReadBytes(BitConverter.ToInt32(len, 0));
                                byte[] t = br.ReadBytes(4);
                                Li[l].listOffset = new byte[tag.Length + len.Length + buffer.Length + t.Length];
                                Array.Copy(tag, 0, Li[l].listOffset, 0, tag.Length);
                                Array.Copy(len, 0, Li[l].listOffset, 4, len.Length);
                                Array.Copy(buffer, 0, Li[l].listOffset, 8, buffer.Length);
                                Array.Copy(t, 0, Li[l].listOffset, 8 + buffer.Length, t.Length);
                            }
                            int NPC_WAR_TOWERBUILD_SERVICE_index = 100;
                            if (Version >= 191)
                                NPC_WAR_TOWERBUILD_SERVICE_index = 99;
                            if (l == NPC_WAR_TOWERBUILD_SERVICE_index)
                            {
                                byte[] tag = br.ReadBytes(4);
                                byte[] len = br.ReadBytes(4);
                                byte[] buffer = br.ReadBytes(BitConverter.ToInt32(len, 0));
                                Li[l].listOffset = new byte[tag.Length + len.Length + buffer.Length];
                                Array.Copy(tag, 0, Li[l].listOffset, 0, tag.Length);
                                Array.Copy(len, 0, Li[l].listOffset, 4, len.Length);
                                Array.Copy(buffer, 0, Li[l].listOffset, 8, buffer.Length);
                            }

                        }
                        #endregion
                        #region read conversation list
                        if (l == ConversationListIndex)
                        {
                            if (Version >= 191)
                            {
                                long sourcePosition = br.BaseStream.Position;
                                int listLength = 0;
                                bool run = true;
                                while (run)
                                {
                                    run = false;
                                    try
                                    {
                                        br.ReadByte();
                                        listLength++;
                                        run = true;
                                    }
                                    catch
                                    { }
                                }
                                br.BaseStream.Position = sourcePosition;
                                Li[l].elementTypes[0] = "byte:" + listLength;
                            }
                            else
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
                            }
                            Li[l].elementValues = new SortedList<int, SortedList<int, object>>
                            {
                                [0] = new SortedList<int, object>()
                            };
                            Li[l].elementValues[0][0] = ReadValue(br, Li[l].elementTypes[0]);
                        }
                        #endregion
                        #region read lists
                        else
                        {

                            if (Version >= 191)
                            {
                                Li[l].listType = br.ReadInt32();
                            }
                            Li[l].elementValues = new SortedList<int, SortedList<int, object>>();
                            int count = br.ReadInt32();
                            if (Version >= 191)
                            {
                                Li[l].elementSize = br.ReadInt32();
                            }

                            long startFrom = br.BaseStream.Position; //Start Reading the list from offset
                            long endFrom = 0;//Start Reading the list from offset

                            endFrom = EndPosition(Li, count, l);

                            byte[] ListBytes = br.ReadBytes((int)endFrom);
                            Li[l].ListId = l;
                            process.Add(Li[l].ReadShit(ListBytes, count, token));
                        }
                        #endregion
                    }
                }
                else
                {
                    MessageBox.Show("No configuration file found for version " + Version + "!");
                }
                br.Close();
                cache.Dispose();
                cache = null;
                Application.DoEvents();

                RunRestOfConfigs(token);
                progress_bar("Ready", 0, 0);
                Program.elementSeditorFirstLoad = false;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            return Li;
        }

        public void CancelAllTasks()
        {
            tokenSource.Cancel();
        }

        public void RefreshTasksRecipe()
        {
            RunRestOfConfigs(token, false);
        }

        private Task RunRestOfConfigs(CancellationToken tt, bool isWait = true)
        {
            return Task.Run(() =>
             {
                 if (!isRunning)
                 {
                     isRunning = true;

                     if (isWait)
                         Task.WaitAll(process.ToArray());

                     int[] whereToSearch = new int[] { 200, 197, 182, 141, 118, 3, 6, 9, 12, 15, 17, 19, 21, 22, 23, 24, 28, 30, 31, 35, 74, 75, MineEssenceList, 89, 95, 106, 114, 115, 116, 33, 184, 171, 214, 215, 218, 223, 224, 225, 226, 227, 228, 229, 230, 117, 125 };
                     if (Version > 191)
                         whereToSearch = new int[] { 3, 6, 9, 12, 15, 17, 19, 21, 22, 23, 24, 28, 30, 31, 35, 73, 74, 78, 88, 94, 105, 113, 114, 115, 33 };
                     skillNames = new SortedList<int, SkillText>(); //itemID list
                     valuableItems = new SortedList<int, ItemDupe>(); //itemID list
                     NPCSellServices = new SortedList<int, ItemDupe>();
                     NPCReciveQuests = new SortedList<int, ItemDupe>();
                     NPCActivateQuests = new SortedList<int, ItemDupe>();
                     NPCTasks = new SortedList<int, ItemDupe>();
                     NPCSkill = new SortedList<int, ItemDupe>();
                     NPCCraftingService = new SortedList<int, ItemDupe>();
                     NPCEngraveService = new SortedList<int, ItemDupe>();
                     NPCHoneService = new SortedList<int, ItemDupe>();
                     MONSTERS = new SortedList<int, ItemDupe>();
                     NPCTYPE = new SortedList<int, ItemDupe>();
                     NPCS = new SortedList<int, ItemDupe>();
                     RESOURCES = new SortedList<int, ItemDupe>();
                     FORCES = new SortedList<int, ItemDupe>();
                     errorList = new SortedList<int, ErrorClass>();

                     PETS = new SortedList<int, ItemDupe>();
                     PET_EGGS = new SortedList<int, ItemDupe>();
                     PET_EGGS_ID = new SortedList<int, ItemDupe>();

                     for (int l = 0; l < Lists.Length; l++)
                     {
                         for (int e = 0; e < Lists[l].elementValues.Count; e++)
                         {
                             int id = -1;
                             string name = "";
                             int idnpc = -1;
                             int maxCount = 0;
                             int idtest = -1;
                             #region loop
                             for (int f = 0; f < Lists[l].elementTypes.Length; f++)
                             {
                                 if (Lists[l].elementFields[f].ToLower() == "pile_num_max")
                                 {
                                     string max_count = Lists[l].GetValue(e, f);
                                     int.TryParse(max_count, out maxCount);
                                 }
                                 if (Lists[l].elementFields[f] == "ID")
                                 {
                                     Lists[l].ItemIdIndex = f;
                                     idtest = Int32.Parse(Lists[l].GetValue(e, f));
                                     if (l == 0)
                                     {
                                         if (!addonIndex.ContainsKey(idtest))
                                         {
                                             addonIndex.Add(idtest, e);
                                         }
                                         else
                                         {
                                             ErrorClass er = new ErrorClass
                                             {
                                                 itemId = e,
                                                 listId = l,
                                                 msg = "Found duplicate Addon id:" + idtest
                                             };
                                             errorList[e + l] = er;
                                             addonIndex[idtest] = e;
                                         }
                                     }

                                 }

                                 if (Lists[l].elementFields[f] == "Name" && idtest > 0)
                                 {
                                     Lists[l].itemNameIndex = f;
                                     if (ocupiedIds_duplicate.ContainsKey(idtest))
                                     {
                                         ocupiedIds_duplicate[idtest].itemId = idtest;
                                         ocupiedIds_duplicate[idtest].name = Lists[l].GetValue(e, f);
                                     }
                                     if (ocupiedIds.ContainsKey(idtest))
                                     {
                                         ocupiedIds[idtest].itemId = idtest;
                                         ocupiedIds[idtest].name = Lists[l].GetValue(e, f);
                                     }
                                     if (whereToSearch.Contains<int>(l))
                                     {
                                         ItemDupe itemDupe = new ItemDupe
                                         {
                                             count = 1,
                                             listID = l,
                                             index = e,
                                             name = Lists[l].GetValue(e, f),
                                             itemId = idtest
                                         };
                                         valuableItems[idtest] = itemDupe;
                                     }
                                     if (l == SaleServiceListIndex)
                                     {
                                         ItemDupe itemDupe = new ItemDupe
                                         {
                                             count = 1,
                                             listID = l,
                                             index = e,
                                             name = Lists[l].GetValue(e, f),
                                             itemId = idtest
                                         };
                                         NPCSellServices[idtest] = itemDupe;
                                     }
                                     if (l == 45)
                                     {
                                         ItemDupe itemDupe = new ItemDupe
                                         {
                                             count = 1,
                                             listID = l,
                                             index = e,
                                             name = Lists[l].GetValue(e, f),
                                             itemId = idtest
                                         };
                                         NPCReciveQuests[idtest] = itemDupe;
                                     }
                                     if (l == 46)
                                     {
                                         ItemDupe itemDupe = new ItemDupe
                                         {
                                             count = 1,
                                             listID = l,
                                             index = e,
                                             name = Lists[l].GetValue(e, f),
                                             itemId = idtest
                                         };
                                         NPCActivateQuests[idtest] = itemDupe;
                                     }
                                     if (l == 47)
                                     {
                                         ItemDupe itemDupe = new ItemDupe
                                         {
                                             count = 1,
                                             listID = l,
                                             index = e,
                                             name = Lists[l].GetValue(e, f),
                                             itemId = idtest
                                         };
                                         NPCTasks[idtest] = itemDupe;
                                     }
                                     if (l == 48)
                                     {
                                         ItemDupe itemDupe = new ItemDupe
                                         {
                                             count = 1,
                                             listID = l,
                                             index = e,
                                             name = Lists[l].GetValue(e, f),
                                             itemId = idtest
                                         };
                                         NPCSkill[idtest] = itemDupe;
                                     }
                                     if (l == CraftServiceListIndex)
                                     {
                                         ItemDupe itemDupe = new ItemDupe
                                         {
                                             count = 1,
                                             listID = l,
                                             index = e,
                                             name = Lists[l].GetValue(e, f),
                                             itemId = idtest
                                         };
                                         NPCCraftingService[idtest] = itemDupe;
                                     }
                                     if (l == EngraveServiceListIndex)
                                     {
                                         ItemDupe itemDupe = new ItemDupe
                                         {
                                             count = 1,
                                             listID = l,
                                             index = e,
                                             name = Lists[l].GetValue(e, f),
                                             itemId = idtest
                                         };
                                         NPCEngraveService[idtest] = itemDupe;
                                     }
                                     if (l == HoneServiceListIndex)
                                     {
                                         ItemDupe itemDupe = new ItemDupe
                                         {
                                             count = 1,
                                             listID = l,
                                             index = e,
                                             name = Lists[l].GetValue(e, f),
                                             itemId = idtest
                                         };
                                         NPCHoneService[idtest] = itemDupe;
                                     }
                                     if (l == 57)
                                     {
                                         ItemDupe itemDupe = new ItemDupe
                                         {
                                             count = 1,
                                             listID = l,
                                             index = e,
                                             name = Lists[l].GetValue(e, f),
                                             itemId = idtest
                                         };
                                         NPCS[idtest] = itemDupe;
                                     }
                                     if (l == MineEssenceList)
                                     {
                                         ItemDupe itemDupe = new ItemDupe
                                         {
                                             count = 1,
                                             listID = l,
                                             index = e,
                                             name = Lists[l].GetValue(e, f),
                                             itemId = idtest
                                         };
                                         RESOURCES[idtest] = itemDupe;
                                     }
                                     if (l == 38)
                                     {
                                         ItemDupe itemDupe = new ItemDupe
                                         {
                                             count = 1,
                                             listID = l,
                                             index = e,
                                             name = Lists[l].GetValue(e, f),
                                             itemId = idtest
                                         };
                                         MONSTERS[idtest] = itemDupe;
                                     }
                                     if (l == 56)
                                     {
                                         ItemDupe itemDupe = new ItemDupe
                                         {
                                             count = 1,
                                             listID = l,
                                             index = e,
                                             name = Lists[l].GetValue(e, f),
                                             itemId = idtest
                                         };
                                         NPCTYPE[idtest] = itemDupe;
                                     }
                                     if (l == ForcesListIndex)
                                     {
                                         ItemDupe itemDupe = new ItemDupe
                                         {
                                             count = 1,
                                             listID = l,
                                             index = e,
                                             name = Lists[l].GetValue(e, f),
                                             itemId = idtest
                                         };
                                         FORCES[idtest] = itemDupe;
                                     }

                                     if (l == Pets)
                                     {
                                         ItemDupe itemDupe = new ItemDupe
                                         {
                                             count = 1,
                                             listID = l,
                                             index = e,
                                             name = Lists[l].GetValue(e, f),
                                             itemId = idtest
                                         };
                                         PETS[idtest] = itemDupe;
                                     }

                                 }

                                 if (l == PetEggs && Lists[l].elementFields[f] == "id_pet")
                                 {
                                     ItemDupe itemDupe = new ItemDupe
                                     {
                                         count = 1,
                                         listID = l,
                                         index = e,
                                         name = Lists[l].GetValue(e, Lists[l].itemNameIndex),
                                         itemId = idtest,
                                         petId = int.Parse(Lists[l].GetValue(e, f))
                                     };
                                     PetIdelementPosition = f;
                                     PET_EGGS[idtest] = itemDupe;
                                     PET_EGGS_ID[PET_EGGS[idtest].petId] = itemDupe;
                                 }

                                 if (l == 38 || l == 57 || l == MineEssenceList)
                                 {
                                     if (Lists[l].elementFields[f] == "ID")
                                     {
                                         idnpc = Int32.Parse(Lists[l].GetValue(e, f));
                                         // NpcEditor.npcdb
                                     }
                                     if (Lists[l].elementFields[f] == "Name")
                                     {
                                         ItemDupe itemDupe = new ItemDupe
                                         {
                                             count = 1,
                                             listID = l,
                                             index = e,
                                             name = Lists[l].GetValue(e, f),
                                             itemId = idnpc
                                         };
                                         NpcEditor.npcdb[idnpc] = itemDupe;

                                     }
                                 }
                                 if (Helper.list_supdype.ContainsKey(l))
                                 {

                                     if (Lists[l].elementFields[f] == "ID")
                                     {
                                         id = Int32.Parse(Lists[l].GetValue(e, f));
                                     }
                                     if (Lists[l].elementFields[f] == "Name")
                                     {
                                         name = Lists[l].GetValue(e, f);
                                         SubTypeElement ste = new SubTypeElement();
                                         if (Helper.list_supdype[l].type == Constatns.typeSubType)
                                         {
                                             if (Helper.subtypesInfolist.ContainsKey(Helper.list_supdype[l].useonList))
                                             {
                                                 if (!Helper.subtypesInfolist[Helper.list_supdype[l].useonList].subtype.ContainsKey(id))
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
                             if (!ocupiedIds.ContainsKey(idtest))
                             {
                                 ItemDupe itemDupe = new ItemDupe
                                 {
                                     count = 1,
                                     listID = l,
                                     index = e,
                                     maxCount = maxCount > 0 ? maxCount : 1
                                 };
                                 ocupiedIds.Add(idtest, itemDupe);
                             }
                             else
                             {
                                 if (!ocupiedIds_duplicate.ContainsKey(idtest))
                                 {
                                     ItemDupe itemDupe = new ItemDupe
                                     {
                                         count = 1,
                                         listID = l,
                                         index = e,
                                         maxCount = maxCount > 0 ? maxCount : 1
                                     };
                                     ocupiedIds_duplicate.Add(idtest, itemDupe);
                                 }
                                 else
                                 {
                                     ocupiedIds_duplicate[idtest].count++;
                                 }

                             }
                             #endregion
                         }
                     }
                 }
                 
                 isRunning = false;
             }, tt);
        }
        private long EndPosition(eList[] lists, int elements, int list)
        {
            long oneCount = 0;
            for (int i = 0; i < lists[list].elementTypes.Length; i++)
                oneCount += GetCount(lists[list].elementTypes[i].ToString());

            return oneCount * elements;
        }

        public void AddxProperty(ExpandoObject expando, string propertyName, object propertyValue)
        {
            // ExpandoObject supports IDictionary so we can extend it like this
            var expandoDict = expando as IDictionary<string, object>;
            if (expandoDict.ContainsKey(propertyName))
                expandoDict[propertyName] = propertyValue;
            else
                expandoDict.Add(propertyName, propertyValue);
        }

        public long GetCount(string type)
        {
            if (type == "int16")
            {
                return sizeof(short);
            }
            if (type == "int32")
            {
                return sizeof(Int32);
            }
            if (type == "int64")
            {
                return sizeof(Int64);
            }
            if (type == "float")
            {
                return sizeof(float);
            }
            if (type == "double")
            {
                return sizeof(double);
            }
            if (type.Contains("byte:"))
            {
                return Convert.ToInt32(type.Substring(5));
            }
            if (type.Contains("wstring:"))
            {
                return Convert.ToInt32(type.Substring(8));
            }
            if (type.Contains("string:"))
            {
                return Convert.ToInt32(type.Substring(7));
            }
            return 0;
        }

        public bool Save(string elFile)
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
            for (int l = 0; l < Lists.Length; l++)
            {
                progress_bar("Saving elements ...", l, Lists.Length);

                if (Lists[l].listOffset.Length > 0)
                {
                    bw.Write(Lists[l].listOffset);
                }

                if (l != ConversationListIndex)
                {
                    if (Version >= 191)
                    {
                        bw.Write(Lists[l].listType);
                    }

                    bw.Write(Lists[l].elementValues.Count);

                    if (Version >= 191)
                    {
                        bw.Write(Lists[l].elementSize);
                    }
                }

                // go through all elements of a list
                for (int e = 0; e < Lists[l].elementValues.Count; e++)
                {
                    // go through all fields of an element
                    for (int f = 0; f < Lists[l].elementValues[e].Count; f++)
                    {
                        WriteValue(bw, Lists[l].elementValues[e][f], Lists[l].elementTypes[f]);
                    }
                }
            }
            bw.Close();
            fs.Close();
            progress_bar("Ready", 0, 0);
            return true;

            /*
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
            */
        }

        private Hashtable LoadRules(string file)
        {
            StreamReader sr = new StreamReader(file);
            Hashtable result = new Hashtable();
            string key = "";
            string value = "";
            string line;
            while (!sr.EndOfStream)
            {
                line = sr.ReadLine();
                if (line != "" && !line.StartsWith("#"))
                {
                    if (line.Contains("|"))
                    {
                        key = line.Split(new char[] { '|' })[0];
                        value = line.Split(new char[] { '|' })[1];
                    }
                    else
                    {
                        key = line;
                        value = "";
                    }
                    result.Add(key, value);
                }
            }
            sr.Close();

            if (!result.ContainsKey("SETCONVERSATIONLISTINDEX"))
                result.Add("SETCONVERSATIONLISTINDEX", 58);

            return result;
        }

        public void Export(string RulesFile, string TargetFile)
        {
            // Load the rules
            Hashtable rules = LoadRules(RulesFile);


            if (File.Exists(TargetFile))
            {
                File.Delete(TargetFile);
            }

            FileStream fs = new FileStream(TargetFile, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);

            if (rules.ContainsKey("SETVERSION"))
            {
                bw.Write(Convert.ToInt16((string)rules["SETVERSION"]));
            }
            else
            {
                MessageBox.Show("Rules file is missing parameter\n\nSETVERSION:", "Export Failed");
                bw.Close();
                fs.Close();
                return;
            }

            if (rules.ContainsKey("SETSIGNATURE"))
            {
                bw.Write(Convert.ToInt16((string)rules["SETSIGNATURE"]));
            }
            else
            {
                MessageBox.Show("Rules file is missing parameter\n\nSETSIGNATURE:", "Export Failed");
                bw.Close();
                fs.Close();
                return;
            }
            // go through all lists
            for (int l = 0; l < Lists.Length; l++)
            {
                progress_bar("Saving elements ...", l, Lists.Length);
                if (Convert.ToInt16((string)rules["SETCONVERSATIONLISTINDEX"]) == l)
                {
                    for (int e = 0; e < Lists[ConversationListIndex].elementValues.Count; e++)
                    {
                        // go through all fields of an element
                        for (int f = 0; f < Lists[ConversationListIndex].elementValues[e].Count; f++)
                        {
                            WriteValue(bw, Lists[ConversationListIndex].elementValues[e][f], Lists[ConversationListIndex].elementTypes[f]);
                        }
                    }
                }
                if (l != ConversationListIndex)
                {
                    if (!rules.ContainsKey("REMOVELIST:" + l))
                    {

                        if (rules.ContainsKey("REPLACEOFFSET:" + l))
                        {
                            // Convert from Hex to byte[]
                            string[] hex = ((string)rules["REPLACEOFFSET:" + l]).Split(new char[] { '-', ' ' });
                            if (hex.Length > 1)
                            {
                                byte[] b = new byte[hex.Length];
                                for (int i = 0; i < hex.Length; i++)
                                {
                                    b[i] = Convert.ToByte(hex[i], 16);
                                }
                                if (b.Length > 0)
                                {
                                    bw.Write(b);
                                }
                            }
                        }
                        else
                        {
                            if (Lists[l].listOffset.Length > 0)
                            {
                                bw.Write(Lists[l].listOffset);
                            }
                        }

                        if (Convert.ToInt16((string)rules["SETVERSION"]) >= 191)
                        {
                            bw.Write(Lists[l].listType);
                        }

                        bw.Write(Lists[l].elementValues.Count);

                        if (Convert.ToInt16((string)rules["SETVERSION"]) >= 191)
                        {
                            bw.Write(Lists[l].elementSize);
                        }

                        // go through all elements of a list
                        for (int e = 0; e < Lists[l].elementValues.Count; e++)
                        {
                            // go through all fields of an element
                            for (int f = 0; f < Lists[l].elementValues[e].Count; f++)
                            {
                                if (!rules.ContainsKey("REMOVEVALUE:" + l + ":" + f))
                                {
                                    WriteValue(bw, Lists[l].elementValues[e][f], Lists[l].elementTypes[f]);
                                }
                            }
                        }
                    }
                }
            }
            bw.Close();
            fs.Close();
            progress_bar("Ready", 0, 0);
        }

        public void LoadProbailityConfig()
        {
            probablilityList = new SortedList<short, HashSet<int>>();
            string rulesFile = Application.StartupPath + "\\Configs\\item_drop_list.txt";
            if (!File.Exists(rulesFile))
            {
                MessageBox.Show(rulesFile + " is Missing!");
                return;
            }
            try
            {
                StreamReader sr = new StreamReader(rulesFile);
                string line;
                while (!sr.EndOfStream)
                {
                    line = sr.ReadLine();
                    if (line != "" && !line.StartsWith("#") && line != null)
                    {
                        string[] data = line.Split(null).CleanArray();
                        short Version = short.Parse(data[1]);
                        int ListId = int.Parse(data[0]);
                        if (probablilityList.ContainsKey(Version))
                        {
                            probablilityList[Version].Add(ListId);
                        }
                        else
                        {
                            probablilityList[Version] = new HashSet<int>();
                            probablilityList[Version].Add(ListId);
                        }
                    }
                }
                sr.Close();
            }
            catch { MessageBox.Show(rulesFile + " contains invalid sintax!"); }
        }

        public bool CanShopProbabilityMenu(int listId)
        {
            bool show = false;

            if (probablilityList.ContainsKey(Version))
            {
                return probablilityList[Version].Contains(listId);
            }

            return show;
        }
    }
}
