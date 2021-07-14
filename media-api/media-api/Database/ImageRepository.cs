using System.Threading.Tasks;
using System.Collections.Generic;
using MongoDB.Driver;
using MongoDB.Bson;
using System;
using media_api.Model;
using System.Linq.Expressions;

namespace media_api.Database
{
    public class ImageRepository : IImageRepository
    {
        public IMongoCollection<Image> _dbCollection;
        private readonly IMongoDbContext _context;

        public ImageRepository(IMongoDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CollectionExists(string collectionName)
        {
            var filter = new BsonDocument("name", collectionName);
            IAsyncCursor<BsonDocument> collections = await _context.Database.ListCollectionsAsync(new ListCollectionsOptions { Filter = filter });
            return await collections.AnyAsync();
        }

        public async Task<IEnumerable<Image>> Get(Expression<Func<Image, bool>> filter = null)
        {
            {
                try
                {
                    FilterDefinition<Image> filterDefinition = filter != null
                                ? Builders<Image>.Filter.Where(filter)
                                : Builders<Image>.Filter.Empty;
                    IFindFluent<Image, Image> entity = _context.Database.GetCollection<Image>(_context.CollectionName).Find(filterDefinition);
                    var tmp = await entity.ToListAsync();
                    return await entity.ToListAsync();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Failed to get collection :" + e.Message);
                    return default;
                }
            }
        }
    }
}