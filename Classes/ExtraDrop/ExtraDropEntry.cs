using PWDataEditorPaied.Game_Shop_classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWDataEditorPaied.Classes.ExtraDrop
{
    public class ExtraDropEntry
    {
        public enum ExtraDropType
        {
            Replace = 1,
            Addon = 2,
        }
        private readonly float[] _dropNumProbabilities = new float[8];

        public NameChar Name { get; private set; }

        public ExtraDropType Type { get; private set; }

        public List<int> Monsters { get; } = new List<int>();

        public List<ExtraDropItem> DropItems { get; } = new List<ExtraDropItem>(256);

        public ExtraDropEntry()
        {
            this.Type = ExtraDropType.Addon;
            this.Name.Name = "< new >";
        }

        public ExtraDropEntry(ExtraDropEntry entry)
        {
            this.Name = entry.Name;
            this.Type = entry.Type;
            for (int index = 0; index < 8; ++index)
                this._dropNumProbabilities[index] = entry._dropNumProbabilities[index];
            foreach (int monster in entry.Monsters)
                this.Monsters.Add(monster);
            foreach (ExtraDropItem dropItem in entry.DropItems)
                this.DropItems.Add(new ExtraDropItem(dropItem));
        }

        public void SetName(byte[] name)
        {
            if (name.Length > 128)
                name = ((IEnumerable<byte>)name).Take<byte>(128).ToArray<byte>();
            this.Name.Name = Encoding.GetEncoding("GB18030").GetString(name);
        }

        public void SetName(string name)
        {
            byte[] bytes = Encoding.GetEncoding("GB18030").GetBytes(name);
            if (bytes.Length > 128)
                name = Encoding.GetEncoding("GB18030").GetString(((IEnumerable<byte>)bytes).Take<byte>(128).ToArray<byte>());
            this.Name.Name = name;
        }

        public void SetType(int type)
        {
            if (type != 1 && type != 2)
                throw new InvalidCastException(type.ToString());
            this.Type = (ExtraDropType)type;
        }

        public void SetType(ExtraDropType type)
        {
            this.Type = type;
        }

        public float GetDropProbability(int i)
        {
            return this._dropNumProbabilities[i];
        }

        public void SetDropProbability(int i, float probability)
        {
            this._dropNumProbabilities[i] = probability;
        }

        public int NewMonster()
        {
            this.Monsters.Add(0);
            return 0;
        }

        public void EditMonster(int index, int monsterId)
        {
            this.Monsters[index] = monsterId;
        }

        public void DeleteMonster(int index)
        {
            this.Monsters.RemoveAt(index);
        }

        public ExtraDropItem AddItem(uint id, float probability)
        {
            if (this.DropItems.Count >= 256)
                throw new OverflowException("Too many items in entry");
            ExtraDropItem extraDropItem = new ExtraDropItem(id, probability);
            this.DropItems.Add(extraDropItem);
            return extraDropItem;
        }

        public ExtraDropItem NewItem()
        {
            return this.AddItem(0U, 0.0f);
        }

        public void EditItemId(int index, uint id)
        {
            this.DropItems[index].Id = id;
        }

        public void EditItemProbability(int index, float probability)
        {
            this.DropItems[index].Probability = probability;
        }

        public void DeleteItem(int index)
        {
            this.DropItems.RemoveAt(index);
        }

        private float sumDropNumProbabilities()
        {
            float num = 0.0f;
            for (int index = 0; index < 8; ++index)
                num += this._dropNumProbabilities[index];
            return num;
        }

        public void FixDropNumProbabilities()
        {
            float num = this.sumDropNumProbabilities();
            if ((double)num == 0.0)
            {
                for (int index = 0; index < 8; ++index)
                {
                    this._dropNumProbabilities[index] = 1f;
                    ++num;
                }
            }
            for (int index = 0; index < 8; ++index)
                this._dropNumProbabilities[index] = this._dropNumProbabilities[index] / num;
        }

        public bool IsDropNumProbabilitiesCorrect()
        {
            return (double)Math.Abs(this.sumDropNumProbabilities() - 1f) <= 9E-07;
        }

        private float sumDropItemsProbabilities()
        {
            float num = 0.0f;
            foreach (ExtraDropItem dropItem in this.DropItems)
                num += dropItem.Probability;
            return num;
        }

        public void FixDropItemsProbabilities()
        {
            float num = this.sumDropItemsProbabilities();
            if ((double)num == 0.0)
            {
                foreach (ExtraDropItem dropItem in this.DropItems)
                {
                    dropItem.Probability = 1f;
                    ++num;
                }
            }
            foreach (ExtraDropItem dropItem in this.DropItems)
                dropItem.Probability /= num;
        }

        public bool IsDropItemsProbabilitiesCorrect()
        {
            return (double)Math.Abs(this.sumDropItemsProbabilities() - 1f) <= 9E-07;
        }

        public int FindMonster(int monsterId, int offset)
        {
            int num = this.Monsters.Skip<int>(offset).ToList<int>().IndexOf(monsterId);
            if (num == -1)
                return -1;
            return num + offset;
        }

        public int FindItem(uint itemId, int offset)
        {
            ExtraDropItem extraDropItem = new ExtraDropItem(itemId, 0.0f);
            int num = this.DropItems.Skip<ExtraDropItem>(offset).ToList<ExtraDropItem>().IndexOf(extraDropItem);
            if (num == -1)
                return -1;
            return num + offset;
        }

        public override string ToString()
        {
            return this.Name.Name;
        }

        public void Serialize(Stream output)
        {
            BinaryWriter binaryWriter = new BinaryWriter(output);
            binaryWriter.Write(this.Monsters.Count);
            for (int index = 0; index < this.Monsters.Count; ++index)
                binaryWriter.Write(this.Monsters[index]);
            for (int index = 0; index < 256; ++index)
            {
                if (index < this.DropItems.Count)
                    this.DropItems[index].Serialize(output);
                else
                    new ExtraDropItem(0U, 0.0f).Serialize(output);
            }
            byte[] bytes = this.Name.EncodedName;
            binaryWriter.Write(this.Name.EncodedName);
            binaryWriter.Write((int)this.Type);
            for (int index = 0; index < 8; ++index)
                binaryWriter.Write(this._dropNumProbabilities[index]);
        }

        public ExtraDropEntry(Stream input)
        {
            Name = new NameChar(128);
            Name.DefaultEncoding = Encoding.GetEncoding("GB18030");
            BinaryReader binaryReader = new BinaryReader(input);
            int num1 = binaryReader.ReadInt32();

            for (int index = 0; index < num1; ++index)
                this.Monsters.Add(binaryReader.ReadInt32());

            for (int index = 0; index < 256; ++index)
            {
                ExtraDropItem extraDropItem = new ExtraDropItem(input);
                if (extraDropItem.Id > 0U)
                    this.DropItems.Add(extraDropItem);
            }
            this.SetName(binaryReader.ReadBytes(128));
            this.SetType(binaryReader.ReadInt32());
            for (int index = 0; index < 8; ++index)
            {
                float num2 = binaryReader.ReadSingle();
                this._dropNumProbabilities[index] = num2;
            }
        }
    }
}
