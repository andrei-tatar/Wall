using System.IO;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IRepository<in TId, TItem> where TItem : IIdentifiable<TId>
    {
        Task Add(TItem item);
        Task Remove(TId id);
        Task<TItem> Get(TId id);
        Task<TItem[]> GetAll();
    }
}