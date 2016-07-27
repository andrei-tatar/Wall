using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IItemsSerializer<TId, TItem> where TItem : IIdentifiable<TId>
    {
        Task Serialize(IEnumerable<TItem> items, Stream stream);
        Task<TItem[]> Deserialize(Stream stream);
    }
}