using media_api.Model;
using MongoDB.Driver;
using System.Collections.Generic;

namespace media_api.Database
{
    public interface  IMongoDbContext
    {
        //IMongoCollection<Image> GetImageCollection();
        //IMongoDatabase Database { get; }
        //IMongoClient mongoClient { get; }
        //List<string> GetListDatabases();
        IMongoDatabase GetMongoDatabase();
    }
}