
using System.Threading.Tasks;
using System;

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
            await _context.Database.CreateCollectionAsync(_context.CollectionName);
            return true;
        }
    }
}