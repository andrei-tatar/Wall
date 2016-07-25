using System.ComponentModel.Composition;
using System.Threading.Tasks;
using Service.Interfaces;

namespace Service.Services
{
    public class JsonRepository<TId, TItem> : BaseMemoryRepository<TId, TItem> where TItem : IIdentifiable<TId>
    {
        private readonly IFileRepositorySerializer<TId, TItem> _serializer;

        [ImportingConstructor]
        public JsonRepository(IFileRepositorySerializer<TId, TItem> serializer)
        {
            _serializer = serializer;
        }

        //ToDo: Don't override Add and Remove methods
        //ToDo: Implement a method for saving changes to repository and call that periodically
        public override Task Add(TItem item)
        {
            base.Add(item);
            _serializer.Serialize(Items);
            return Task.FromResult(0);
        }

        public override Task Remove(TId id)
        {
            base.Remove(id);
            _serializer.Serialize(Items);
            return Task.FromResult(0);
        }

        public Task LoadRepository()
        {
            var items = _serializer.Deserialize();
            foreach (var item in items)
            {
                Items.TryAdd(item.Key, item.Value);
            }
            return Task.FromResult(0);
        }
    }
}