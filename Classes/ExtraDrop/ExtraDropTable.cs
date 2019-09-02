using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PWDataEditorPaied.Classes.ExtraDrop
{
    public class ExtraDropTable
    {
        public int Version { get; set; }

        public List<ExtraDropEntry> Entries { get; } = new List<ExtraDropEntry>();

        public ExtraDropTable()
        {
            this.Version = 1;
        }

        public ExtraDropEntry NewEntry()
        {
            ExtraDropEntry extraDropEntry = new ExtraDropEntry();
            this.Entries.Add(extraDropEntry);
            return extraDropEntry;
        }

        public ExtraDropEntry CloneEntry(int index)
        {
            ExtraDropEntry extraDropEntry = new ExtraDropEntry(this.Entries[index]);
            this.Entries.Add(extraDropEntry);
            return extraDropEntry;
        }

        public void DeleteEntry(int index)
        {
            this.Entries.RemoveAt(index);
        }

        public Tuple<int, int, int> FindEntry(long id, int entryOffset, int monsterOffset, int itemOffset)
        {
            List<ExtraDropEntry> list = this.Entries.Skip<ExtraDropEntry>(entryOffset).ToList<ExtraDropEntry>();
            for (int index = 0; index < list.Count; ++index)
            {
                ExtraDropEntry extraDropEntry = list[index];
                int monster = extraDropEntry.FindMonster((int)id, monsterOffset);
                int num = extraDropEntry.FindItem((uint)id, itemOffset);
                if (monster > -1 || num > -1)
                    return Tuple.Create<int, int, int>(index + entryOffset, monster, num);
                monsterOffset = 0;
                itemOffset = 0;
            }
            return Tuple.Create<int, int, int>(-1, -1, -1);
        }

        public void Serialize(Stream output)
        {
            BinaryWriter binaryWriter = new BinaryWriter(output);
            binaryWriter.Write(this.Version);
            binaryWriter.Write(this.Entries.Count);
            foreach (ExtraDropEntry entry in this.Entries)
                entry.Serialize(output);
        }

        public ExtraDropTable(Stream input)
        {
            BinaryReader binaryReader = new BinaryReader(input);
            int num1 = binaryReader.ReadInt32();
            if (num1 != 1)
                throw new NotSupportedException(num1.ToString());
            this.Version = num1;
            int num2 = binaryReader.ReadInt32();
            this.Entries.Capacity = num2;
            for (int index = 0; index < num2; ++index)
                this.Entries.Add(new ExtraDropEntry(input));
        }
    }
}
