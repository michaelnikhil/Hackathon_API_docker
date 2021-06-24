using System.Threading.Tasks;

namespace DB_initializer.Database
{
    public interface ICollectionService<T>
    {
        Task<bool> CreateCollection(string collectionName);
    }
}