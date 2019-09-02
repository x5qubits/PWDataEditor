using PWDataEditorPaied.Game_Shop_classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ElementEditor.Game_Shop_classes
{
    [Serializable]
    public class SaleOption
    {
        private DateTime REFDATE = new DateTime(1970, 01, 01);
        public uint price;			// price of this item	
        public uint end_time = 0;
        public string _time = "";
        public uint time = 0;
        public uint start_time = 0;
        public int type;
        public uint day;
        public uint status;
        public uint flag;
        public uint min_vip_level;

        public void Read(BinaryReader bReader, int Version)
        {
            price = bReader.ReadUInt32();
            end_time = bReader.ReadUInt32();
            time = bReader.ReadUInt32();
            if (Version > 7)
            {
                start_time = bReader.ReadUInt32();
                type = bReader.ReadInt32();
                day = bReader.ReadUInt32();
                status = bReader.ReadUInt32();
                flag = bReader.ReadUInt32();
                if (Version >= 155)
                {
                    min_vip_level = bReader.ReadUInt32();
                }
            }
        }

        public void Write(BinaryWriter bWriter, int version, bool isClient)
        {
            if (version > 7)
            {
                if(flag == 0)
                    bWriter.Write(price);
                else
                    bWriter.Write((uint)0);
            }
            else
            {
                bWriter.Write(price);
            }

            if (version > 7)
            {
                bWriter.Write(end_time);
            }
            else bWriter.Write(0);
            bWriter.Write(time);
            if (version > 7)
            {
                bWriter.Write(start_time);
                bWriter.Write(type);
                bWriter.Write(day);
                bWriter.Write(status);
                bWriter.Write(flag);
                if (version >= 155)
                {
                    bWriter.Write(min_vip_level);
                }
            }
        }
    }
}
