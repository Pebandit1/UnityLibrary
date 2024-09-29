using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Serialization
{
    public class BinarySerializer : ISerializer
    {
        BinaryFormatter bf;

        public BinarySerializer()
        {
            bf = new BinaryFormatter();
        }

        public string Serialize(object obj)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                string result = Convert.ToBase64String(ms.ToArray());
                ms.Close();

                return result;
            }
        }

        //Type isn't usefull for this type of serialization
        public object Deserialize(string serilizedString, Type type)
        {
            byte[] decoded = Convert.FromBase64String(serilizedString);
            using (MemoryStream ms = new MemoryStream(decoded))
            {
                object deserialized = bf.Deserialize(ms);
                ms.Close();
                return deserialized;
            }
        }
    }
}
