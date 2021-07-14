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
        public IMongoCollection<Image> _dbCollection;
        

        public ImageRepository(IImageDBSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _dbCollection = database.GetCollection<Image>(settings.CollectionName);

            //_mongoContext = context;
            //Collection = _mongoContext.GetMongoDatabase().GetCollection<Image>("Image-collection");
            //_dbCollection = _mongoContext.GetImageCollection();
        }

        //public IAsyncCursor<string> GetAllDatabases()
        //{
        //    var tmp = _mongoContext.Database.GetCollection<Image>("Image-collection").ToBsonDocument();
        //    return _mongoContext.mongoClient.ListDatabaseNames();
        //}



        //public async Task<Image> Get(string id)
        //{
        //    //ex. 5dc1039a1521eaa36835e541
 
        //    var objectId = new ObjectId(id);
        //    FilterDefinition<Image> filter = Builders<Image>.Filter.Eq("_id", objectId);
        //    return await Collection.FindAsync(filter).Result.FirstOrDefaultAsync();

        //}
 
        public async Task<IEnumerable<Image>> Get()
        {
            {
                try
                {
                    IFindFluent<Image, Image> entity = _dbCollection.Find(Builders<Image>.Filter.Empty);
                    var tmp = await _dbCollection.Find(f => true).ToListAsync();
                    return await entity.ToListAsync();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Failed to get collection :" + e.Message);
                    return default;
                }
            }
        }

        public List<Image> GetImage() => _dbCollection.Find(f => true).ToList();

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