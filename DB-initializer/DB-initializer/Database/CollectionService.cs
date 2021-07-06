
using System.Threading.Tasks;
using System;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DB_initializer.Database
{
    public class CollectionService : ICollectionService
    {
        private readonly IMongoDbContext _context;

        public CollectionService(IMongoDbContext context)
        {
            _context = context;
 
        }

        public async Task<bool> CreateCollection()
        {
            Console.WriteLine("*** create collection ***");
            if(!await CollectionExists(_context.CollectionName)){
                await _context.Database.CreateCollectionAsync(_context.CollectionName);
            }
            else{
                Console.WriteLine("Collection already exists");
            }
            return true;
        }

        public async Task<bool> CollectionExists(string collectionName)
        {
            var filter = new BsonDocument("name", collectionName);
            IAsyncCursor<BsonDocument> collections = await _context.Database.ListCollectionsAsync(new ListCollectionsOptions { Filter = filter });
            return await collections.AnyAsync();
        }
    }
}