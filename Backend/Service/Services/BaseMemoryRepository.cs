using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;
using Service.Interfaces;

namespace Service.Services
{
    public class BaseMemoryRepository<TId, TItem> : IRepository<TId, TItem> where TItem : IIdentifiable<TId>
    {
        protected readonly ConcurrentDictionary<TId, TItem> Items = new ConcurrentDictionary<TId, TItem>();

        public virtual Task Add(TItem item)
        {
            Items.AddOrUpdate(item.Id, item, (id, item1) => item);
            return Task.FromResult(0);
        }

        public virtual Task Remove(TId id)
        {
            TItem item;
            Items.TryRemove(id, out item);
            return Task.FromResult(0);
        }

        public virtual Task<TItem> Get(TId id)
        {
            TItem item = Items.TryGetValue(id, out item) ? item : default(TItem);
            return Task.FromResult(item);
        }

        public virtual Task<TItem[]> GetAll()
        {
            return Task.FromResult(Items.Values.ToArray());
        }
    }
}