using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWDataEditorPaied.Classes.ExtraDrop
{
    public class ExtraDropItem
    {
        public uint Id { get; set; }

        public float Probability { get; set; }

        public ExtraDropItem(uint id, float probability)
        {
            this.Id = id;
            this.Probability = probability;
        }

        public ExtraDropItem(ExtraDropItem item)
        {
            this.Id = item.Id;
            this.Probability = item.Probability;
        }

        public override string ToString()
        {
            return string.Format("{0} ({1})", (object)this.Id, (object)this.Probability.ToString("0.0###############"));
        }

        public override bool Equals(object obj)
        {
            if ((object)(obj as ExtraDropItem) == null)
                return false;
            return (int)this.Id == (int)((ExtraDropItem)obj).Id;
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode() ^ this.Probability.GetHashCode();
        }

        public static bool operator ==(ExtraDropItem x, ExtraDropItem y)
        {
            if ((object)x == null || (object)y == null)
                return false;
            return (int)x.Id == (int)y.Id;
        }

        public static bool operator !=(ExtraDropItem x, ExtraDropItem y)
        {
            return !(x == y);
        }

        public void Serialize(Stream output)
        {
            BinaryWriter binaryWriter = new BinaryWriter(output);
            binaryWriter.Write(this.Id);
            binaryWriter.Write(this.Probability);
        }

        public ExtraDropItem(Stream input)
        {
            BinaryReader binaryReader = new BinaryReader(input);
            this.Id = binaryReader.ReadUInt32();
            this.Probability = binaryReader.ReadSingle();
        }
    }
}
