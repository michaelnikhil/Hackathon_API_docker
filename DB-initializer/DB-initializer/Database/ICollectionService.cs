using System.Threading.Tasks;

namespace Swisscom.BusinessCenter.MessageCenter.Import.Database
{
    public interface ICollectionService<T>
    {
        Task<bool> CreateCollection(string collectionName);
    }
}