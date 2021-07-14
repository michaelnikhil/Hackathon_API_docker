using System.Threading.Tasks;
using System.Collections.Generic;
using MongoDB.Driver;
using MongoDB.Bson;
using System;
using media_api.Model;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;

namespace media_api.Database
{
    public class ImageRepository : IImageRepository
    {
        public IMongoCollection<Image> _dbCollection;
        private readonly IMongoDbContext _context;
        private readonly IMongoCollection<Image> Collection;


        public ImageRepository(IMongoDbContext context)
        {
            _context = context;
            Collection = _context.Database.GetCollection<Image>(_context.CollectionName);
        }

        public async Task<IEnumerable<Image>> Get(Expression<Func<Image, bool>> filter = null)
        {
            {
                try
                {
                    FilterDefinition<Image> filterDefinition = filter != null
                                ? Builders<Image>.Filter.Where(filter)
                                : Builders<Image>.Filter.Empty;
                    IFindFluent<Image, Image> entity = Collection.Find(filterDefinition);
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

        public async Task<string> Save(Image image)
        {
            try
            {
                await Collection.InsertOneAsync(image);
                return "Image added";
                
            }
            catch (MongoWriteException ex)
            {
                Console.WriteLine("Failed to save element : \n" + ex.Message );
                return ex.Message;
            }
        }

        public async Task Update(Image image)
        {
            try
            {
                await Collection.ReplaceOneAsync(filter: d => d.Id == image.Id, replacement: image);
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not update image : " + e.Message);
            }
        }
    }
}