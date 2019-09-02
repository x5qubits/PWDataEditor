using ElementEditor.Element_Editor_Classes;
using PWDataEditorPaied.Database.Utils;
using PWnpcEditor;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ElementEditor.classes
{
    public class eList 
    {

        public String listName;// . from config file
        public byte[] listOffset;  // . length from config file, values from elements.data
        public string[] elementFields; // . length & values from config file
        public string[] elementTypes; // . length & values from config file
        public SortedList<int, SortedList<int,object>> elementValues; // list.length from elements.data, elements.length from config file
        public SortedList<int, int> elementPosition; // list.length from elements.data, elements.length from config file
        public int ItemIdIndex;
        public int itemNameIndex;
        public int itemIconIndex;
        public int ListId;
        public int listType;
        public int elementSize;

        public string GetValue(int ElementIndex, int FieldIndex)
        {
            if (FieldIndex > -1)
            {
                object value = elementValues[ElementIndex][FieldIndex];
                string type = elementTypes[FieldIndex];

                if (type == "int16")
                {
                    return Convert.ToString((short)value);
                }
                if (type == "int32")
                {
                    return Convert.ToString((int)value);
                }
                if (type == "int64")
                {
                    return Convert.ToString((long)value);
                }
                if (type == "float")
                {
                    return Convert.ToString((float)value);
                }
                if (type == "double")
                {
                    return Convert.ToString((double)value);
                }
                if (type.Contains("byte:"))
                {
                    // Convert from byte[] to Hex String
                    byte[] b = (byte[])value;
                    return BitConverter.ToString(b);
                }
                if (type.Contains("wstring:"))
                {
                    Encoding enc = Encoding.GetEncoding("Unicode");
                    return enc.GetString((byte[])value).Split('\0')[0];
                }
                if (type.Contains("string:"))
                {
                    Encoding enc = Encoding.GetEncoding("GBK");
                    return enc.GetString((byte[])value).Split('\0')[0];
                }
            }
            return "";
        }

        public void SetValue(int ElementIndex, int FieldIndex, string Value)
        {
            string type = elementTypes[FieldIndex];

            if (type == "int16")
            {
                elementValues[ElementIndex][FieldIndex] = Convert.ToInt16(Value);
                return;
            }
            if (type == "int32")
            {
                elementValues[ElementIndex][FieldIndex] = Convert.ToInt32(Value);
                return;
            }
            if (type == "int64")
            {
                elementValues[ElementIndex][FieldIndex] = Convert.ToInt64(Value);
                return;
            }
            if (type == "float")
            {
                elementValues[ElementIndex][FieldIndex] = Convert.ToSingle(Value);
                return;
            }
            if (type == "double")
            {
                elementValues[ElementIndex][FieldIndex] = Convert.ToDouble(Value);
                return;
            }
            if (type.Contains("byte:"))
            {
                // Convert from Hex to byte[]
                String[] hex = Value.Split('-');
                byte[] b = new byte[Convert.ToInt32(type.Substring(5))];
                for (int i = 0; i < hex.Length; i++)
                {
                    b[i] = Convert.ToByte(hex[i], 16);
                }
                elementValues[ElementIndex][FieldIndex] = b;
                return;
            }
            if (type.Contains("wstring:"))
            {
                Encoding enc = Encoding.GetEncoding("Unicode");
                byte[] target = new byte[Convert.ToInt32(type.Substring(8))];
                byte[] source = enc.GetBytes(Value);
                if (target.Length > source.Length)
                {
                    Array.Copy(source, target, source.Length);
                }
                else
                {
                    Array.Copy(source, target, target.Length);
                }
                elementValues[ElementIndex][FieldIndex] = target;
                return;
            }
            if (type.Contains("string:"))
            {
                Encoding enc = Encoding.GetEncoding("GBK");
                byte[] target = new byte[Convert.ToInt32(type.Substring(7))];
                byte[] source = enc.GetBytes(Value);
                if (target.Length > source.Length)
                {
                    Array.Copy(source, target, source.Length);
                }
                else
                {
                    Array.Copy(source, target, target.Length);
                }
                elementValues[ElementIndex][FieldIndex] = target;
                return;
            }
            return;
        }
        // return the type of the field in string representation
        public string GetType(int FieldIndex)
        {
            if (FieldIndex > -1)
            {
                return elementTypes[FieldIndex];
            }
            return "";
        }

        // delete Item
        public void RemoveItem(int ListIndex, int itemIndex)
        {
            elementValues.Remove(itemIndex);
        }

        // add Item
        public void AddItem(int ListIndex, SortedList<int, object> itemValues)
        {
            elementValues[elementValues.Count] = itemValues;
        }

        public Task ReadShit(byte[] ListBytes, int count, CancellationToken tt)
        {
           Task tas = Task.Run(() =>
            {
                using (MemoryStream ms = new MemoryStream(ListBytes))
                {
                    using (BinaryReader br = new BinaryReader(ms))
                    {
                        for (int element = 0; element < count; element++)
                        {
                            elementValues[element] = new SortedList<int, object>();
                            for (int field = 0; field < elementTypes.Length; field++)
                            {
                                elementValues[element][field] = readValue(br, elementTypes[field]);
                                if (elementFields[field] == "Name")
                                {
                                    itemNameIndex = field;
                                }
                                if (elementFields[field] == "file_icon" || elementFields[field] == "file_icon1")
                                {
                                    itemIconIndex = field;
                                }
                            }
                        }
                    }
                }
            }, tt);
            return tas;
        }

        public object readValue(BinaryReader br, string type)
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
    }
}
