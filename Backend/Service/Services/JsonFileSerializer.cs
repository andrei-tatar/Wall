using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using Newtonsoft.Json;
using Service.Interfaces;

namespace Service.Services
{
    [Export(typeof(IFileRepositorySerializer<,>))]
    public class JsonFileSerializer<TId, TItem> : IFileRepositorySerializer<TId, TItem>
    {
        //ToDo: remove hardcoded path to repository file
        private readonly string _jsonRepositoryFile = @"C:\Users\Laura\Desktop\WallProject\Backend\Service\users.json";

        public void Serialize(object value)
        {
            var json = JsonConvert.SerializeObject(value, Formatting.Indented);
            using (var stream = new StreamWriter(_jsonRepositoryFile))
            {
                stream.Write(json);
            }
        }

        public IDictionary<TId, TItem> Deserialize()
        {
            using (var stream = new StreamReader(_jsonRepositoryFile))
            {
                return JsonConvert.DeserializeObject<Dictionary<TId, TItem>>(stream.ReadToEnd());
            }
        }
    }
}