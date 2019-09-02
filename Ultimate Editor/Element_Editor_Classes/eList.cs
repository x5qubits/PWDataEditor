using PWDataEditorPaied.helper_classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;

namespace ElementEditor.classes
{
    public class eList 
    {

        public String listName;// . from config file
        public byte[] listOffset;  // . length from config file, values from elements.data
        public IDictionary<int, string> elementFields; // . length & values from config file
        public IDictionary<int, string> elementTypes; // . length & values from config file
        public Dictionary<int, Dictionary<int,Object>> elementValues; // list.length from elements.data, elements.length from config file

        public String GetValue(int ElementIndex, int FieldIndex)
        {
            if (FieldIndex > -1)
            {
                Object value = elementValues[ElementIndex][FieldIndex];
                String type = elementTypes[FieldIndex];

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

        public void SetValue(int ElementIndex, int FieldIndex, String Value)
        {
            String type = elementTypes[FieldIndex];

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
        public String GetType(int FieldIndex)
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
        public void AddItem(int ListIndex, Dictionary<int, Object> itemValues)
        {
            elementValues[elementValues.Count] = itemValues;
        }
    }
}
