using System.IO;
using System.Threading.Tasks;
using Service.Interfaces;

namespace Service.Services
{
    public class FileBasedRepository<TId, TItem> : BaseMemoryRepository<TId, TItem> where TItem : IIdentifiable<TId>
    {
        private readonly string _fileName;
        private readonly IItemsSerializer<TId, TItem> _serializer;
        private bool _loaded;

        public FileBasedRepository(string fileName, IItemsSerializer<TId, TItem> serializer)
        {
            _fileName = fileName;
            _serializer = serializer;
        }

        public override async Task AddOrUpdate(TItem item)
        {
            await Load();
            await base.AddOrUpdate(item);
            await Save();
        }

        public override async Task Remove(TId id)
        {
            await Load();
            await base.Remove(id);
            await Save();
        }

        public override async Task<TItem> Get(TId id)
        {
            await Load();
            return await base.Get(id);
        }

        public override async Task<TItem[]> GetAll()
        {
            await Load();
            return await base.GetAll();
        }

        protected virtual Task OnItemsLoaded(TItem[] items)
        {
            return Task.FromResult(0);
        }

        private async Task Load()
        {
            if (_loaded) return;
            _loaded = true;

            try
            {
                using (var stream = File.OpenRead(_fileName))
                {
                    var items = await _serializer.Deserialize(stream);
                    foreach (var item in items)
                        await base.AddOrUpdate(item);

                    await OnItemsLoaded(items);
                }
            }
            catch (FileNotFoundException)
            {
                await OnItemsLoaded(new TItem[0]);
            }
        }

        private async Task Save()
        {
            var items = await base.GetAll();
            using (var stream = File.OpenWrite(_fileName))
            {
                await _serializer.Serialize(items, stream);
            }
        }
    }
}