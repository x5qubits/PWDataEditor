using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Shield.classes.net
{
    [Serializable]
    public class HashMap<K, V> : ISerializable
    {
        Dictionary<K, V> dict = new Dictionary<K, V>();

        public HashMap() { }

        protected HashMap(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            foreach (K key in dict.Keys)
            {
                info.AddValue(key.ToString(), dict[key]);
            }
        }

        public void Add(K key, V value)
        {
            dict.Add(key, value);
        }

        public void Addall(Dictionary<K, V> dictx)
        {
            foreach (KeyValuePair<K, V> d in dictx)
            {
                dict.Add(d.Key, d.Value);
            }
        }

        public V this[K index]
        {
            set { dict[index] = value; }
            get { return dict[index]; }
        }
    }
}
