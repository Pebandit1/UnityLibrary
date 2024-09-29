using Serialization;
using System.Threading.Tasks;
using System;
using System.IO;
using UnityEngine;

namespace DataService
{
    public class LocalFileDataService : IDataService
    {
        ISerializer serializer;

        public LocalFileDataService(ISerializer serializer)
        {
            this.serializer = serializer;
        }

        public async Task<object> Load(string fn, Type type)
        {
            string path = Path.Combine(Application.persistentDataPath, fn);
            if (!File.Exists(path))
                throw new FileNotFoundException(path);

            Task<string> reading = File.ReadAllTextAsync(path);

            if(reading.Exception != null)
                throw reading.Exception;

            await reading;

            object deserialized = serializer.Deserialize(reading.Result, type);

            return deserialized;
        }

        public async Task Save(string fn, object data, bool createDir)
        {
            string path = Path.Combine(Application.persistentDataPath, fn);
            
            if (!File.Exists(path) && !createDir)
                throw new FileNotFoundException(path);

            string serialized = serializer.Serialize(data);

            Task writing = File.WriteAllTextAsync(path, serialized);
            
            if(writing.Exception != null)
                throw writing.Exception;

            await writing;
        }
    }
}