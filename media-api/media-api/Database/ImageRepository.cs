using System.Threading.Tasks;
using System.Collections.Generic;
using MongoDB.Driver;
using MongoDB.Bson;
using System;
using media_api.Model;

namespace media_api.Database
{
    public class ImageRepository : IImageRepository
    {
        public readonly IMongoDbContext _mongoContext;
        public IMongoCollection<Image> _dbCollection;
 
        public ImageRepository(IMongoDbContext context)
        {
            _mongoContext = context;
            _dbCollection = _mongoContext.GetImageCollection();
        }
 
        public async Task<Image> Get(string id)
        {
            //ex. 5dc1039a1521eaa36835e541
 
            var objectId = new ObjectId(id);
            FilterDefinition<Image> filter = Builders<Image>.Filter.Eq("_id", objectId);
            return await _dbCollection.FindAsync(filter).Result.FirstOrDefaultAsync();
 
        }
 
 
        public async Task<IEnumerable<Image>> Get()
        {
            var all = await _dbCollection.FindAsync(Builders<Image>.Filter.Empty);
            return await all.ToListAsync();
        }

        public async Task Create(Image obj)
       {
           if(obj == null)
           {
               throw new ArgumentNullException(typeof(Image).Name + " object is null");
           }
           await _dbCollection.InsertOneAsync(obj);
       }

    //    public virtual void Update(TEntity obj)
    //    {
    //        _dbCollection.ReplaceOneAsync(Builders<TEntity>.Filter.Eq("_id", obj.GetId()), obj);
    //    }

       public void Delete(string id)
        {
            //ex. 5dc1039a1521eaa36835e541
 
            var objectId = new ObjectId(id);
            _dbCollection.DeleteOneAsync(Builders<Image>.Filter.Eq("_id", objectId));
 
        }
    }
}