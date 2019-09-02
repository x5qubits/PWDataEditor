// FastSerializer.cs.  Provides SerializationWriter and SerializationReader classes to help high speed serialization.
// This short example shows how they're used:
//
//  [Serializable] public class TestObject : ISerializable {                       // Class must be ISerializable
//    public long   x;
//    public string y;
//
//    public void GetObjectData (SerializationInfo info, StreamingContext ctxt) {  // Serialization method
//      SerializationWriter sw = SerializationWriter.GetWriter ();                 // Get a Writer
//      sw.Write (x);                                                              // Write fields
//      sw.Write (y);                                                              // ditto
//      sw.AddToInfo (info);                                                       // Add the Writer to info
//    }
//
//    public TestObject (SerializationInfo info, StreamingContext ctxt) {          // Deserialization .ctor
//      SerializationReader sr = SerializationReader.GetReader (info);             // Get a Reader from info
//      x = sr.ReadInt64 ();                                                       // Read a field
//      y = sr.ReadInt64 ();                                                       // ditto
//    }
//
//  }
//
// Author: Tim Haynes, May 2006.  Use freely as you see fit.

using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using ElementEditor.classes;
using System.Collections;
using System.Collections.ObjectModel;

namespace PWDataEditorPaied.helper_classes
{

    // Enum for the standard types handled by Read/WriteObject()

    internal enum ObjType : byte
    {
        nullType,
        boolType,
        byteType,
        uint16Type,
        uint32Type,
        uint64Type,
        sbyteType,
        int16Type,
        int32Type,
        int64Type,
        charType,
        stringType,
        singleType,
        doubleType,
        decimalType,
        dateTimeType,
        byteArrayType,
        charArrayType,
        otherType
    }

    /// <summary> SerializationWriter.  Extends BinaryWriter to add additional data types,
    /// handle null strings and simplify use with ISerializable. </summary>

    public class SerializationWriter : BinaryWriter
    {

        private SerializationWriter(Stream s) : base(s) { }

        /// <summary> Static method to initialise the writer with a suitable MemoryStream. </summary>

        public static SerializationWriter GetWriter()
        {
            MemoryStream ms = new MemoryStream(1024);
            return new SerializationWriter(ms);
        }

        /// <summary> Writes a string to the buffer.  Overrides the base implementation so it can cope with nulls </summary>

        public override void Write(string str)
        {
            if (str == null)
            {
                Write((byte)ObjType.nullType);
            }
            else
            {
                Write((byte)ObjType.stringType);
                base.Write(str);
            }
        }

        /// <summary> Writes a byte array to the buffer.  Overrides the base implementation to
        /// send the length of the array which is needed when it is retrieved </summary>

        public override void Write(byte[] b)
        {
            if (b == null)
            {
                Write(-1);
            }
            else
            {
                int len = b.Length;
                Write(len);
                if (len > 0) base.Write(b);
            }
        }

        /// <summary> Writes a char array to the buffer.  Overrides the base implementation to
        /// sends the length of the array which is needed when it is read. </summary>

        public override void Write(char[] c)
        {
            if (c == null)
            {
                Write(-1);
            }
            else
            {
                int len = c.Length;
                Write(len);
                if (len > 0) base.Write(c);
            }
        }

        /// <summary> Writes a DateTime to the buffer. <summary>

        public void Write(DateTime dt) { Write(dt.Ticks); }

        /// <summary> Writes a generic ICollection (such as an IList<T>) to the buffer. </summary>

        public void Write<T>(ICollection<T> c)
        {
            if (c == null)
            {
                Write(-1);
            }
            else
            {
                Write(c.Count);
                foreach (T item in c) WriteObject(item);
            }
        }

        /// <summary> Writes a generic IDictionary to the buffer. </summary>

        public void Write<T, U>(IDictionary<T, U> d)
        {
            if (d == null)
            {
                Write(-1);
            }
            else
            {
                Write(d.Count);
                foreach (KeyValuePair<T, U> kvp in d)
                {
                    WriteObject(kvp.Key);
                    WriteObject(kvp.Value);
                }
            }
        }
        /// <summary> Writes an arbitrary object to the buffer.  Useful where we have something of type "object"
        /// and don't know how to treat it.  This works out the best method to use to write to the buffer. </summary>

        public void WriteObject(object obj)
        {
            if (obj == null)
            {
                Write((byte)ObjType.nullType);
            }
            else
            {

                switch (obj.GetType().Name)
                {

                    case "Boolean":
                        Write((byte)ObjType.boolType);
                        Write((bool)obj);
                        break;

                    case "Byte":
                        Write((byte)ObjType.byteType);
                        Write((byte)obj);
                        break;

                    case "UInt16":
                        Write((byte)ObjType.uint16Type);
                        Write((ushort)obj);
                        break;

                    case "UInt32":
                        Write((byte)ObjType.uint32Type);
                        Write((uint)obj);
                        break;

                    case "UInt64":
                        Write((byte)ObjType.uint64Type);
                        Write((ulong)obj);
                        break;

                    case "SByte":
                        Write((byte)ObjType.sbyteType);
                        Write((sbyte)obj);
                        break;

                    case "Int16":
                        Write((byte)ObjType.int16Type);
                        Write((short)obj);
                        break;

                    case "Int32":
                        Write((byte)ObjType.int32Type);
                        Write((int)obj);
                        break;

                    case "Int64":
                        Write((byte)ObjType.int64Type);
                        Write((long)obj);
                        break;

                    case "Char":
                        Write((byte)ObjType.charType);
                        base.Write((char)obj);
                        break;

                    case "String":
                        Write((byte)ObjType.stringType);
                        base.Write((string)obj);
                        break;

                    case "Single":
                        Write((byte)ObjType.singleType);
                        Write((float)obj);
                        break;

                    case "Double":
                        Write((byte)ObjType.doubleType);
                        Write((double)obj);
                        break;

                    case "Decimal":
                        Write((byte)ObjType.decimalType);
                        Write((decimal)obj);
                        break;

                    case "DateTime":
                        Write((byte)ObjType.dateTimeType);
                        Write((DateTime)obj);
                        break;

                    case "Byte[]":
                        Write((byte)ObjType.byteArrayType);
                        base.Write((byte[])obj);
                        break;

                    case "Char[]":
                        Write((byte)ObjType.charArrayType);
                        base.Write((char[])obj);
                        break;

                    default:
                        Write((byte)ObjType.otherType);
                        new BinaryFormatter().Serialize(BaseStream, obj);
                        break;

                } // switch

            } // if obj==null

        }  // WriteObject

        /// <summary> Adds the SerializationWriter buffer to the SerializationInfo at the end of GetObjectData(). </summary>

        public void AddToInfo(SerializationInfo info)
        {
            byte[] b = ((MemoryStream)BaseStream).ToArray();
            info.AddValue("X", b, typeof(byte[]));
        }

    } // SerializationWriter


    /// <summary> SerializationReader.  Extends BinaryReader to add additional data types,
    /// handle null strings and simplify use with ISerializable. </summary>

    public class SerializationReader : BinaryReader
    {

        private SerializationReader(Stream s) : base(s) { }

        /// <summary> Static method to take a SerializationInfo object (an input to an ISerializable constructor)
        /// and produce a SerializationReader from which serialized objects can be read </summary>.

        public static SerializationReader GetReader(SerializationInfo info)
        {
            byte[] byteArray = (byte[])info.GetValue("X", typeof(byte[]));
            MemoryStream ms = new MemoryStream(byteArray);
            return new SerializationReader(ms);
        }

        /// <summary> Reads a string from the buffer.  Overrides the base implementation so it can cope with nulls. </summary>

        public override string ReadString()
        {
            ObjType t = (ObjType)ReadByte();
            if (t == ObjType.stringType) return base.ReadString();
            return null;
        }

        /// <summary> Reads a byte array from the buffer, handling nulls and the array length. </summary>

        public byte[] ReadByteArray()
        {
            int len = ReadInt32();
            if (len > 0) return ReadBytes(len);
            if (len < 0) return null;
            return new byte[0];
        }

        /// <summary> Reads a char array from the buffer, handling nulls and the array length. </summary>

        public char[] ReadCharArray()
        {
            int len = ReadInt32();
            if (len > 0) return ReadChars(len);
            if (len < 0) return null;
            return new char[0];
        }

        /// <summary> Reads a DateTime from the buffer. </summary>

        public DateTime ReadDateTime() { return new DateTime(ReadInt64()); }

        /// <summary> Reads a generic list from the buffer. </summary>

        public IList<T> ReadList<T>()
        {
            int count = ReadInt32();
            if (count < 0) return null;
            IList<T> d = new List<T>();
            for (int i = 0; i < count; i++) d.Add((T)ReadObject());
            return d;
        }

        /// <summary> Reads a generic List from the buffer. </summary>

        public eList[] ReadEList<T>()
        {
            int count = ReadInt32();

            if (count < 0) { return null; }
            eList[] data = new eList[count];
            for (int i = 0; i < count; i++)
            {
                data[i] = (eList)ReadObject();
            }
            return data;
        }

        public ICollection<T> ReadEListColection<T>()
        {
            int count = ReadInt32();
            if (count < 0)
            {
                return null;
            }
            ICollection<T> d = new Collection<T>();
            for (int i = 0; i < count; i++)
            {
                var obj = ReadObject();
                d.Add((T)obj);
            }
            return d;
        }
        /// <summary> Reads a generic Dictionary from the buffer. </summary>

        public IDictionary<T, U> ReadDictionary<T, U>()
        {
            int count = ReadInt32();
            if (count < 0) return null;
            IDictionary<T, U> d = new Dictionary<T, U>();
            for (int i = 0; i < count; i++) d[(T)ReadObject()] = (U)ReadObject();
            return d;
        }

        /// <summary> Reads an object which was added to the buffer by WriteObject. </summary>

        public object ReadObject()
        {
            ObjType t = (ObjType)ReadByte();
            switch (t)
            {
                case ObjType.boolType: return ReadBoolean();
                case ObjType.byteType: return ReadByte();
                case ObjType.uint16Type: return ReadUInt16();
                case ObjType.uint32Type: return ReadUInt32();
                case ObjType.uint64Type: return ReadUInt64();
                case ObjType.sbyteType: return ReadSByte();
                case ObjType.int16Type: return ReadInt16();
                case ObjType.int32Type: return ReadInt32();
                case ObjType.int64Type: return ReadInt64();
                case ObjType.charType: return ReadChar();
                case ObjType.stringType: return base.ReadString();
                case ObjType.singleType: return ReadSingle();
                case ObjType.doubleType: return ReadDouble();
                case ObjType.decimalType: return ReadDecimal();
                case ObjType.dateTimeType: return ReadDateTime();
                case ObjType.byteArrayType: return ReadByteArray();
                case ObjType.charArrayType: return ReadCharArray();
                case ObjType.otherType: return new BinaryFormatter().Deserialize(BaseStream);
                default: return null;
            }
        }


    } // SerializationReader

} // namespace
