using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Service.Interfaces;

namespace Service.Services
{
    [Export(typeof (IItemsSerializer<,>))]
    public class JsonItemsSerializer<TId, TItem> : IItemsSerializer<TId, TItem> where TItem : IIdentifiable<TId>
    {
        public Task Serialize(IEnumerable<TItem> items, Stream stream)
        {
            var serialized = JsonConvert.SerializeObject(items, Formatting.Indented);
            using (var writer = new StreamWriter(stream))
            {
                return writer.WriteAsync(serialized);
            }
        }

        public async Task<TItem[]> Deserialize(Stream stream)
        {
            using (var reader = new StreamReader(stream))
            {
                var serialized = await reader.ReadToEndAsync();
                return JsonConvert.DeserializeObject<TItem[]>(serialized);
            }
        }
    }
}