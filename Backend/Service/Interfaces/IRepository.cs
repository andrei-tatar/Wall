using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IRepository<in TId, TItem> where TItem : IIdentifiable<TId>
    {
        Task AddOrUpdate(TItem item);
        Task Remove(TId id);
        Task<TItem> Get(TId id);
        Task<TItem[]> GetAll();
    }
}