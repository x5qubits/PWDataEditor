using PWDataEditorPaied.Classes.ExtraDrop;
using PWDataEditorPaied.Game_Shop_classes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PWDataEditorPaied.NewEditors
{
    internal class FileStructure
    {
        public string MapName = "";
        public int ID;
        public int MapId;
        public Vector3 MapPoint;
        public int GroupId;
    }

    internal class Vector3
    {
        public float X
        {
            get
            {
                return Convert.ToSingle(oX);
            }
        }
        public float Y
        {
            get
            {
                return Convert.ToSingle(oY);
            }
        }
        public float Z
        {
            get
            {
                return Convert.ToSingle(oZ);
            }
        }


        public string oX = "0";
        public string oY = "0";
        public string oZ = "0";
        private string v1;
        private string v2;

        public Vector3()
        {
            oX = "0";
            oY = "0";
            oZ = "0";
        }

        public Vector3(string line, char split)
        {
            string[] heder = line.Split(split);
            oX = heder[0].Trim();
            oY = heder[1].Trim();
            oZ = heder[2].Trim();
        }
        public Vector3(string line)
        {
            string[] heder = line.Split(null).CleanArray();
            oX = heder[0].Trim();
            oY = heder[1].Trim();
            oZ = heder[2].Trim();
        }

        public Vector3(string x, string y, string z)
        {
            oX = x.Trim();
            oY = y.Trim();
            oZ = z.Trim();
        }

        public string ToString6DigitsDoubleSpace()
        {
            return oX + "  " + oY + "  " + oZ;
        }

        public string ToString6DigitsVirgula()
        {
            return oX + ", " + oY + ", " + oZ;
        }

        public string ToString6DigitsVirgulaSpatiiDuble()
        {
            return oX + ",  " + oY + ",  " + oZ;
        }

        public string ToString6DigitsTab()
        {
            return oX + "   " + oY + "  " + oZ;
        }

        public string ToString3Digits()
        {
            return X.ToString("F3") + "  " + Y.ToString("F3") + "  " + Z.ToString("F3");
        }

        public void Write(BinaryWriter bw)
        {
            bw.Write(X);
            bw.Write(Y);
            bw.Write(Z);
        }
    }

    internal class RegionStructure
    {
        public int Type = 0;
        public int IdInstance = 0;
        public int ZoneCount {
            get
            {
                return Zones.Count;
            }
        }
        public int Strategy = 0;
        public string name = "";
        public List<Vector3> Zones = new List<Vector3>();

        internal RegionStructure clone()
        {
            RegionStructure retu = new RegionStructure();
            retu.Type = Type;
            retu.IdInstance = IdInstance;
            retu.Strategy = Strategy;
            retu.name = name + "Clone";
            retu.Zones = Zones;
            return retu;
        }
    }

    internal class CELTransportBox
    {
        public int m_iType = 1;
        public int m_idInst = 0;
        public int m_idSrcInst = 0;
        public int m_iLevelLmt = 0;
        public Vector3 tm_vPos = new Vector3();
        public Vector3 m_vExts = new Vector3();
        public Vector3 m_vTarge = new Vector3();

        internal CELTransportBox clone()
        {
            CELTransportBox t = new CELTransportBox
            {
                m_iType = m_iType,
                m_idInst = m_idInst,
                m_idSrcInst = m_idSrcInst,
                m_iLevelLmt = m_iLevelLmt,
                tm_vPos = tm_vPos,
                m_vExts = m_vExts,
                m_vTarge = m_vTarge
            };
            return t;
        }
    }

    internal class CELNPC
    {
        public string Name = "";
        public Vector3 position = new Vector3();

        public string toLine()
        {
            return "\""+ Name+"\"  "+ position.ToString6DigitsDoubleSpace();
        }
    }

    internal class CELPrecinct
    {
        public int ID = 0;
        public string name;
        public int iNumPoint = 0;
        public int m_iPriority = 0;
        public int m_idDstIns = 0;
        public int m_idSrcInst = 0;
        public int m_idDomain = 0;
        public byte m_bPKProtect = 0;
        public Vector3 m_vCityPos = new Vector3();
        public List<Vector3> m_aPoints = new List<Vector3>();
        public int unk0;
        public int unk1;
        public int unk2;
        public int unk3;
        public List<CELNPC> Npcs = new List<CELNPC>();
        public List<string> music = new List<string>();

        internal CELPrecinct clone()
        {
            CELPrecinct c = new CELPrecinct();
            c.ID = ID;
            c.name = name;
            c.iNumPoint = iNumPoint;
            c.m_iPriority = m_iPriority;
            c.m_idDstIns = m_idDstIns;
            c.m_idSrcInst = m_idSrcInst;
            c.m_idDomain = m_idDomain;
            c.m_bPKProtect = m_bPKProtect;
            c.m_vCityPos = m_vCityPos;
            c.m_aPoints = m_aPoints;
            c.unk0 = unk0;
            c.unk1 = unk1;
            c.unk2 = unk2;
            c.unk3 = unk3;
            c.Npcs = Npcs;
            c.music = music;
            return c;
        }
    }

    internal class WorldTargetsFile
    {
        public List<FileStructure> TeleportList;

        public int TeleportAmount { get; private set; }

        public Encoding encoding;

        public void ReadSevFile(BinaryReader br)
        {
            this.TeleportList = new List<FileStructure>();
            this.TeleportAmount = br.ReadInt32();
            for (int index = 0; index < this.TeleportAmount; ++index)
                this.TeleportList.Add(new FileStructure()
                {
                    ID = br.ReadInt32(),
                    MapId = br.ReadInt32(),
                    MapPoint = new Vector3(br.ReadSingle().ToString(), br.ReadSingle().ToString(), br.ReadSingle().ToString()),
                    GroupId = br.ReadInt32()
                });
            br.Close();
        }

        public bool ReadTxtFile(string path)
        {
            this.TeleportList = new List<FileStructure>();
            try
            {
                string line = "";
                using (FileStream fr = File.OpenRead(path))
                {
                    using (StreamReader sr = new StreamReader(fr))
                    {
                        encoding = sr.CurrentEncoding;
                        while ((line = sr.ReadLine()) != null)
                        {
                            if (line.Length > 0)
                            {
                                string[] l = line.Split('\t');
                                FileStructure world_target = new FileStructure();
                                world_target.ID = int.Parse(l[0].GetNumbers());
                                world_target.MapName = l[1].Replace("\"", "");
                                world_target.MapId = int.Parse(l[2].GetNumbers());
                                world_target.MapPoint = new Vector3(l[3].Replace("\"", ""), ',');
                                world_target.GroupId = int.Parse(l[4].GetNumbers());
                                this.TeleportList.Add(world_target);
                            }
                        }
                    }
                }
                return true;
            }
                       
            catch (Exception)
            {
                return false;
            }
        }

        public bool Save(string path)
        {
            try
            {
                string svfile = path.Replace(".clt", ".sev");
                using (MemoryStream ms = new MemoryStream())
                {
                    using (BinaryWriter bw = new BinaryWriter(ms))
                    {
                        bw.Write(this.TeleportList.Count);
                        for (int index = 0; index < this.TeleportList.Count; ++index)
                        {
                            bw.Write(TeleportList[index].ID);
                            bw.Write(TeleportList[index].MapId);
                            TeleportList[index].MapPoint.Write(bw);
                            bw.Write(TeleportList[index].GroupId);
                        }
                        bw.Close();
                    }
                }

                StringBuilder sb = new StringBuilder();
                for (int index = 0; index < this.TeleportList.Count; ++index)
                {
                    sb.AppendLine(string.Format("{0}\t\"{1}\"\t{2}\t\"{3},{4},{5}\"\t{6}", TeleportList[index].ID, TeleportList[index].MapName, TeleportList[index].MapId, TeleportList[index].MapPoint.X.ToString("F3"), TeleportList[index].MapPoint.Y.ToString("F3"), TeleportList[index].MapPoint.Z.ToString("F3"), TeleportList[index].GroupId));
                }
                File.WriteAllText(path, sb.ToString(), encoding);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }

    internal class RegionFile
    {
        public uint dwVersion;
        public int dwTimeStamp;
        public Encoding encoding;
        public List<CELTransportBox> teleports = new List<CELTransportBox>();
        public List<RegionStructure> regions = new List<RegionStructure>();

        public bool ReadFile(string path)
        {
            try
            {
                teleports = new List<CELTransportBox>();
                regions = new List<RegionStructure>();
                string line = "";
                using (FileStream fr = File.OpenRead(path))
                {
                    using (StreamReader sr = new StreamReader(fr))
                    {
                        while ((line = sr.ReadLine()) != null)
                        {
                            if (line.Contains("version") && !line.StartsWith("//"))
                            {
                                encoding = sr.CurrentEncoding;
                                dwVersion = uint.Parse(line.GetNumbers());
                                dwTimeStamp = int.Parse(sr.ReadLine().GetNumbers());
                            }

                            if (line.Contains("[trans]") && !line.StartsWith("//"))
                            {
                                CELTransportBox teleport = new CELTransportBox();
                                string[] heder = sr.ReadLine().Split(null).CleanArray();
                                int x = 0;
                                
                                teleport.m_idInst = int.Parse(heder[x].GetNumbers());
                                x++;
                                if (dwVersion >= 3)
                                {
                                    teleport.m_idSrcInst = int.Parse(heder[x].GetNumbers());
                                    x++;
                                }
                                if (dwVersion >= 5)
                                {
                                    teleport.m_iLevelLmt = int.Parse(heder[x].GetNumbers());
                                    x++;
                                }
                               
                                teleport.tm_vPos = new Vector3(sr.ReadLine(), ',');
                                teleport.m_vExts = new Vector3(sr.ReadLine(), ',');
                                teleport.m_vTarge = new Vector3(sr.ReadLine(), ',');
                                teleports.Add(teleport);

                            }
                            if (line.Contains("[region]") && !line.StartsWith("//"))
                            {
                                RegionStructure region = new RegionStructure();
                                string name = sr.ReadLine().Replace('"', ' ').Trim();
                                string[] heder = sr.ReadLine().Split(null).CleanArray();
                                region.name = name;
                                region.Type = 0;
                                region.IdInstance = int.Parse(heder[0].GetNumbers());
                                int ZoneCount = int.Parse(heder[1].GetNumbers());
                                region.Zones = new List<Vector3>();
                                if (dwVersion > 5)
                                {
                                    region.Strategy = int.Parse(sr.ReadLine().GetNumbers());// sr.ReadLine();
                                }
                                for (int i = 0; i < ZoneCount; i++)
                                {
                                    region.Zones.Add(new Vector3(sr.ReadLine()));
                                }
                                regions.Add(region);
                            }
                        }
                    }
                }
                return true;
            }
            catch { }
            return false;
        }

        public bool SaveFile(string path, bool both = true)
        {
            try
            {
                bool exists = System.IO.Directory.Exists(Path.GetDirectoryName(path));

                if (!exists)
                    System.IO.Directory.CreateDirectory(Path.GetDirectoryName(path));

                #region SERVER
                string svfile = path.Replace(".clt", ".sev");
                using (MemoryStream ms = new MemoryStream())
                {
                    using (BinaryWriter bw = new BinaryWriter(ms))
                    {
                        bw.Write(dwVersion);
                        bw.Write(regions.Count);
                        if (dwVersion >= 2)
                        {
                            bw.Write(teleports.Count);
                        }
                        if (dwVersion >= 4)
                        {
                            bw.Write(dwTimeStamp);
                        }
                      
                        foreach (RegionStructure region in regions)
                        {
                            bw.Write(region.Type);
                            bw.Write(region.ZoneCount);
                            for (int i = 0; i < region.ZoneCount; i++)
                            {
                                region.Zones[i].Write(bw);
                            }
                        }
                        foreach (CELTransportBox teleport in teleports)
                        {
                            bw.Write(teleport.m_iType);
                            bw.Write(teleport.m_idInst);
                            if (dwVersion >= 3)
                            {
                                bw.Write(teleport.m_idSrcInst);
                            }
                            if (dwVersion >= 5)
                            {
                                bw.Write(teleport.m_iLevelLmt);
                            }                      
                            teleport.tm_vPos.Write(bw);
                            teleport.m_vExts.Write(bw);
                            teleport.m_vTarge.Write(bw);
                        }


                        File.WriteAllBytes(svfile, ms.ToArray());

                    }
                }
                #endregion
                if (!both)
                    return true;
                #region CLIENT
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("//  Element region file (client version) Generated by JHS Data Tools");
                sb.AppendLine();
                sb.AppendLine("version  " + dwVersion);
                sb.AppendLine(dwTimeStamp.ToString());
                sb.AppendLine();
                foreach (RegionStructure region in regions)
                {
                    sb.AppendLine("[region]");
                    sb.AppendLine("\"" + region.name + "\"");
                    sb.AppendLine(region.IdInstance + "  " + region.ZoneCount);
                    for (int i = 0; i < region.ZoneCount; i++)
                    {
                        sb.AppendLine(region.Zones[i].ToString6DigitsDoubleSpace());
                    }
                    sb.AppendLine();
                }

                foreach (CELTransportBox teleport in teleports)
                {
                    sb.AppendLine("[trans]");
                    sb.AppendLine(teleport.m_idInst + "  " + teleport.m_idSrcInst + "  " + teleport.m_iLevelLmt);
                    sb.AppendLine(teleport.tm_vPos.ToString6DigitsVirgula());
                    sb.AppendLine(teleport.m_vExts.ToString6DigitsVirgula());
                    sb.AppendLine(teleport.m_vTarge.ToString6DigitsVirgula());
                    sb.AppendLine();
                }
                sb.AppendLine();
                File.WriteAllText(path, sb.ToString(), encoding);
                #endregion
                return true;
            }
            catch { }
            return false;
        }

    }

    internal class PretinctFile
    {
        private Encoding encoding;
        public uint dwVersion;
        public int dwTimeStamp;
        public List<CELPrecinct> zones = new List<CELPrecinct>();
        public bool ReadFile(string path)
        {
            try
            {
                zones = new List<CELPrecinct>();
                string line = "";
                using (FileStream fr = File.OpenRead(path))
                {
                    using (StreamReader sr = new StreamReader(fr))
                    {
                        while ((line = sr.ReadLine()) != null)
                        {
                            if (line.Contains("version") && !line.StartsWith("//"))
                            {
                                encoding = sr.CurrentEncoding;
                                dwVersion = uint.Parse(line.GetNumbers());
                                dwTimeStamp = int.Parse(sr.ReadLine().GetNumbers());
                            }
                            if (line.Contains("\"") && !line.StartsWith("//"))
                            {
                                CELPrecinct zone = new CELPrecinct();
                                zone.name = line.Replace("\"", "").Trim();
                                string[] heder = sr.ReadLine().Split(null).CleanArray();
                                //2210  7  0  3  178  0  60  1  178  0  0  
                                //ID NUM ? 
                                int x = 0;
                                zone.ID = int.Parse(heder[x].GetNumbers());
                                x++;
                                zone.iNumPoint = int.Parse(heder[x].GetNumbers());
                                x++;
                                zone.unk0 = int.Parse(heder[x].GetNumbers());
                                x++;
                                zone.m_iPriority = int.Parse(heder[x].GetNumbers());
                                x++;
                                zone.m_idDstIns = int.Parse(heder[x].GetNumbers());
                                x++;
                                zone.unk1 = int.Parse(heder[x].GetNumbers());
                                x++;
                                zone.unk2 = int.Parse(heder[x].GetNumbers());
                                x++;
                                zone.unk3 = int.Parse(heder[x].GetNumbers());
                                x++;
                                zone.m_idSrcInst = int.Parse(heder[x].GetNumbers());
                                x++;
                                if (dwVersion >= 6)
                                {
                                    zone.m_idDomain = int.Parse(heder[x].GetNumbers());
                                    x++;
                                }
                                if (dwVersion >= 7)
                                {
                                    zone.m_bPKProtect = byte.Parse(heder[x].GetNumbers());
                                    x++;
                                }

                                zone.m_vCityPos = new Vector3(sr.ReadLine(), ',');
                                zone.m_aPoints = new List<Vector3>();
                                for (int i = 0; i < zone.iNumPoint; i++)
                                {
                                    zone.m_aPoints.Add(new Vector3(sr.ReadLine()));
                                }
                                sr.ReadLine();


                                zone.Npcs = new List<CELNPC>();
                                zone.music = new List<string>();
                                while ((line = sr.ReadLine()) != null && line.Contains("\"") && !line.StartsWith("//"))
                                {
                                    string name = line.GetBetween("\"", "\"");
                                    CELNPC npc = new CELNPC();
                                    npc.Name = name;
                                    string numberOnly = line.Split('"')[2].Trim();
                                    npc.position = new Vector3(numberOnly);
                                    zone.Npcs.Add(npc);
                                }

                                while ((line = sr.ReadLine()) != null && line.Contains("\"") && !line.StartsWith("//"))
                                {
                                    zone.music.Add(line.Replace("\"", ""));
                                }
                                zones.Add(zone);
                            }

                        }
                    }

                }
                return true;
            }
            catch { }
            return false;
        }

        public bool SaveFile(string path, bool both = true)
        {
            try
            {
                #region SERVER
                string svfile = path.Replace(".clt", ".sev");
                using (MemoryStream ms = new MemoryStream())
                {
                    using (BinaryWriter bw = new BinaryWriter(ms))
                    {
                        bw.Write(dwVersion);
                        bw.Write(zones.Count);
                        if (dwVersion >= 5)
                            bw.Write(dwTimeStamp);

                        foreach (CELPrecinct zone in zones)
                        {
                            bw.Write(zone.iNumPoint);
                            bw.Write(zone.m_iPriority);
                            bw.Write(zone.m_idDstIns);
                            if (dwVersion >= 4)
                            {
                                bw.Write(zone.m_idSrcInst);
                            }
                            if (dwVersion >= 6)
                            {
                                bw.Write(zone.m_idDomain);
                            }
                            if (dwVersion >= 7)
                            {
                                bw.Write(zone.m_bPKProtect);
                            }
                            zone.m_vCityPos.Write(bw);

                            for (int i = 0; i < zone.iNumPoint; i++)
                            {
                                zone.m_aPoints[i].Write(bw);
                            }
                        }
                        File.WriteAllBytes(svfile, ms.ToArray());

                    }
                }
                #endregion
                if (!both) return true;
                #region Client
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("//  Element pricinct file (client version) Generated by JHS Data Tools");
                sb.AppendLine();
                sb.AppendLine("version  " + dwVersion);
                sb.AppendLine(dwTimeStamp.ToString());
                sb.AppendLine();
                foreach (CELPrecinct zone in zones)
                {
                    sb.AppendLine("\""+zone.name+"\"");
                    zone.iNumPoint = zone.m_aPoints.Count;
                    string heder = zone.ID + "  ";
                    heder += zone.iNumPoint + "  ";
                    heder += zone.unk0 + "  ";
                    heder += zone.m_iPriority + "  ";
                    heder += zone.m_idDstIns + "  ";
                    heder += zone.unk1 + "  ";
                    heder += zone.unk2 + "  ";
                    heder += zone.unk3 + "  ";
                    heder += zone.m_idSrcInst + "  ";
                    if (dwVersion >= 6 && dwVersion < 7)
                    {
                        heder += zone.m_idDomain;
                    }
                    else if (dwVersion >= 7)
                    {
                        heder += zone.m_idDomain + "  ";
                        heder += zone.m_bPKProtect;
                    }
                    sb.AppendLine(heder);
                    sb.AppendLine(zone.m_vCityPos.ToString6DigitsVirgula());
                    for (int i = 0; i < zone.iNumPoint; i++)
                    {
                        sb.AppendLine(zone.m_aPoints[i].ToString6DigitsDoubleSpace());
                    }
                    sb.AppendLine();
                    if (zone.Npcs.Count == 0)
                    {
                        sb.AppendLine();
                    }
                    else
                    {
                        for (int i = 0; i < zone.Npcs.Count; i++)
                        {
                            sb.AppendLine(zone.Npcs[i].toLine());
                        }
                        sb.AppendLine();
                    }


                    for (int i = 0; i < zone.music.Count; i++)
                    {
                        sb.AppendLine("\""+zone.music[i]+"\"");
                    }

                    sb.AppendLine();

                }
                File.WriteAllText(path, sb.ToString(), encoding);

                #endregion
                return true;
            }
            catch { }
            return false;
        }
    }
    internal class MonsterDrop
    {
        public uint ID;
        public float probability;
    }
    internal class DropItem
    {
        public List<int> monstersId = new List<int>();
        public List<MonsterDrop> DropItems = new List<MonsterDrop>();
        public NameChar Name = new NameChar(128);
        public int type = 0;
        public List<float> probs = new List<float>();

        public DropItem()
        {
        }
    }

    internal class ExtraDrop
    {
        internal List<DropItem> drops = new List<DropItem>();

        public int NumberOfDrops { get; private set; }
        public int Version { get; private set; }

        public bool ReadFile(string path)
        {
            if (!File.Exists(path))
                return false;
            try
            {
                using (MemoryStream ms = new MemoryStream(File.ReadAllBytes(path)))
                {
                    using (BinaryReader br = new BinaryReader(ms))
                    { 
                        Version = br.ReadInt32();
                        NumberOfDrops = br.ReadInt32();
                        for (int index = 0; index < NumberOfDrops; ++index)
                        {
                            DropItem drop = new DropItem();
                            int monsterCount = br.ReadInt32();
                            for (int i = 0; i < monsterCount; ++i)
                            {
                                int monstersId = br.ReadInt32();
                                drop.monstersId.Add(monstersId);
                            }

                            for (int i = 0; i < 256; ++i)
                            {
                                uint id = br.ReadUInt32();
                                float Probability = br.ReadSingle();
                               // if (id > 0U)
                               // {
                                    MonsterDrop md = new MonsterDrop();
                                    md.ID = id;
                                    md.probability = Probability;
                                    drop.DropItems.Add(md);
                               // }
                            }

                            drop.Name = new NameChar(128, br, Encoding.GetEncoding("GB18030"));
                            drop.type = br.ReadInt32();
                            for (int i = 0; i < 8; ++i)
                            {
                                drop.probs.Add(br.ReadSingle());
                            }

                            drops.Add(drop);
                        }
                    }

                }
                return true;
            }
            catch { }
            return false;
        }

        public bool Save(string path)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream(File.ReadAllBytes(path)))
                {
                    using (BinaryWriter bw = new BinaryWriter(ms))
                    {
                        bw.Write(Version);
                        bw.Write(drops.Count);
                        for (int index = 0; index < drops.Count; ++index)
                        {
                            bw.Write(drops[index].monstersId.Count);
                            for (int i = 0; i < drops[index].monstersId.Count; ++i)
                            {
                                bw.Write(drops[index].monstersId[i]);
                            }

                            for (int i = 0; i < 256; ++i)
                            {
                                bw.Write(drops[index].DropItems[i].ID);
                                bw.Write(drops[index].DropItems[i].probability);

                            }
                            bw.Write(drops[index].Name.EncodedName);
                            bw.Write(drops[index].type);
  
                            for (int i = 0; i < 8; ++i)
                            {
                                bw.Write(drops[index].probs[i]);
                            }
                        }
                    }
                    File.WriteAllBytes(path, ms.ToArray());

                }
                return true;
            }
            catch { }
            return false;
        }
    }
}
