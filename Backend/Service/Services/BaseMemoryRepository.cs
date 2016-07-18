using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;
using Service.Interfaces;

namespace Service.Services
{
    public class BaseMemoryRepository<TId, TItem> : IRepository<TId, TItem> where TItem : IIdentifiable<TId>
    {
        private readonly ConcurrentDictionary<TId, TItem> _items = new ConcurrentDictionary<TId, TItem>();

        public Task Add(TItem item)
        {
            _items.AddOrUpdate(item.Id, item, (id, item1) => item);
            return Task.FromResult(0);
        }

        public Task Remove(TId id)
        {
            TItem item;
            _items.TryRemove(id, out item);
            return Task.FromResult(0);
        }

        public Task<TItem> Get(TId id)
        {
            TItem item = _items.TryGetValue(id, out item) ? item : default(TItem);
            return Task.FromResult(item);
        }

        public Task<TItem[]> GetAll()
        {
            return Task.FromResult(_items.Values.ToArray());
        }
    }
}