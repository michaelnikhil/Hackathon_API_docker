using System.Threading.Tasks;

namespace DB_initializer.Database
{
    public interface ICollectionService
    {
        Task<bool> CreateCollection();

        Task<bool> CollectionExists(string collectionName);
        
    }
}