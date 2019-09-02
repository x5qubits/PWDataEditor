using PWDataEditorPaied.Game_Shop_classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ElementEditor.Game_Shop_classes
{
    [Serializable]
    public class Item
    {
        public bool activate = true;
        public bool deleted = false;
        public int shop_id = 0;
        public int local_id = 0;
        public int main_type = 0;
        public int sub_type = 0;
        public NameChar icon = new NameChar(128);// 128 Byte GBK
        public uint id = 0;
        public uint num = 1;
        public SaleOption[] sale_options = new SaleOption[4]; // length = 4
        public NameChar description = new NameChar(1024); // 1024 Byte Unicode
        public NameChar name = new NameChar(64); // 64 Byte Unicode
        public uint idGift = 0;
        public uint iGiftNum = 0;
        public uint iGiftTime = 0;
        public uint iLogPrice = 0;
        public uint npc1 = 0;
        public uint npc2 = 0;
        public uint npc3 = 0;
        public uint npc4 = 0;
        public uint npc5 = 0;
        public uint npc6 = 0;
        public uint npc7 = 0;
        public uint npc8 = 0;
        public int buy_times_limit = 0;
        public int buy_times_limit_mode = 0;
        public uint props;
        public uint unk1;

        public void Read(BinaryReader bReader, int Version, bool isClient)
        {
            local_id = bReader.ReadInt32();
            main_type = bReader.ReadInt32();
            sub_type = bReader.ReadInt32();
            if (isClient)
            {
                icon = new NameChar(128, bReader, Encoding.GetEncoding("gb2312"));
            }
            else
            {
                icon = new NameChar(128);
                icon.DefaultEncoding = Encoding.GetEncoding("gb2312");
            }
            id = bReader.ReadUInt32();
            num = bReader.ReadUInt32();
            for (int i = 0; i < 4; i++)
            {
                sale_options[i] = new SaleOption();
                sale_options[i].Read(bReader, Version);
            }
            if (Version <= 7)
            {
                props = bReader.ReadUInt32();
            }
            if (isClient)
            {
                description = new NameChar(1024, bReader);
                name = new NameChar(64, bReader);
            }
            else
            {
                description = new NameChar(1024);
                name = new NameChar(64);
                name.Name = "SVItem " + local_id;
            }
            if (id > 100000)
                throw new Exception("File might be wrong version the name has 0 bytes!");

            if (Version > 7)
            {
                idGift = bReader.ReadUInt32();
                iGiftNum = bReader.ReadUInt32();
                iGiftTime = bReader.ReadUInt32();
                iLogPrice = bReader.ReadUInt32();
                if (Version > 123)
                {
                    npc1 = bReader.ReadUInt32();
                    npc2 = bReader.ReadUInt32();
                    npc3 = bReader.ReadUInt32();
                    npc4 = bReader.ReadUInt32();
                    npc5 = bReader.ReadUInt32();
                    npc6 = bReader.ReadUInt32();
                    npc7 = bReader.ReadUInt32();
                    npc8 = bReader.ReadUInt32();
                    if (Version >= 155)
                    {
                        buy_times_limit = bReader.ReadInt32();
                        buy_times_limit_mode = bReader.ReadInt32();
                        if (Version >= 157)
                        {
                            unk1 = bReader.ReadUInt32();
                        }
                    }

                }
            }
        }

        public void Write(BinaryWriter bWriter, int version, bool isClient)
        {
            bWriter.Write(local_id);
            bWriter.Write(main_type);
            bWriter.Write(sub_type);
            if (isClient)
            {
                bWriter.Write(icon.EncodedName);
            }
            bWriter.Write(id);
            bWriter.Write(num);
            for (int i = 0; i < 4; i++)
            {
                sale_options[i].Write(bWriter, version, isClient);
            }
            if (version <= 7)
            {
                bWriter.Write(props);
            }
            if (isClient)
            {
                bWriter.Write(description.EncodedName);
                bWriter.Write(name.EncodedName);
            }
            if (version > 7)
            {
                bWriter.Write(idGift);
                bWriter.Write(iGiftNum);
                bWriter.Write(iGiftTime);
                bWriter.Write(iLogPrice);
                if (version > 123)
                {
                    bWriter.Write(npc1);
                    bWriter.Write(npc2);
                    bWriter.Write(npc3);
                    bWriter.Write(npc4);
                    bWriter.Write(npc5);
                    bWriter.Write(npc6);
                    bWriter.Write(npc7);
                    bWriter.Write(npc8);
                    if (version >= 155)
                    {
                        bWriter.Write(buy_times_limit);
                        bWriter.Write(buy_times_limit_mode);
                        if (version >= 157)
                        {
                            bWriter.Write(unk1);
                        }
                    }
                }
            }
        }
    }
}
