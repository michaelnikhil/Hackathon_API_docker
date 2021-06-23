using System.Collections.Generic;
using System.Threading.Tasks;
using DB_initializer.Database;

namespace Swisscom.BusinessCenter.MessageCenter.Import.Database
{
    public class CollectionService<T> : ICollectionService<T>
    {
        private readonly IMongoDbContext _context;

        public CollectionService(IMongoDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateCollection(string collectionName)
        {
            await _context.GetMongoDatabase().CreateCollectionAsync(collectionName);
            return true;
        }
    }
}