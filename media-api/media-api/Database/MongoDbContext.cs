using media_api.Model;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Collections.Generic;

namespace media_api.Database
{
    public class MongoDbContext : IMongoDbContext
    {
        //public IMongoDatabase Database { get; set; }
        private IMongoClient _mongoClient;
        private readonly ImageDBSettings _settings;
        //private IAsyncCursor<string> _databases;

        public MongoDbContext(IOptions<ImageDBSettings> mongoDbSettings)
        {
            _settings =  mongoDbSettings.Value;
           // var client = new MongoClient(_settings.ConnectionString);
           // mongoClient = new MongoClient(_settings.ConnectionString);
            //Database = client.GetDatabase(_settings.DatabaseName);
          //  _databases = client.ListDatabaseNames();
        }

        //public IMongoCollection<Image> GetImageCollection()
        //{
        //    return Database.GetCollection<Image>(_settings.CollectionName);
        //}

        //public List<string> GetListDatabases()
        //{
        //    return _databases.ToList();
        //}

        public IMongoDatabase GetMongoDatabase()
        {
            _mongoClient = new MongoClient(_settings.ConnectionString);
            return _mongoClient.GetDatabase(_settings.DatabaseName);
        }

        //public IMongoClient mongoClient { get; }
    }    
}