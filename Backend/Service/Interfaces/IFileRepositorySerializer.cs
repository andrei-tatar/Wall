using System.Collections.Generic;

namespace Service.Interfaces
{
    public interface IFileRepositorySerializer<TId, TItem>
    {
        void Serialize(object value);
        IDictionary<TId, TItem> Deserialize(); 
    }
}