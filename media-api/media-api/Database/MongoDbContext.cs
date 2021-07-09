using media_api.Model;
using Microsoft.Extensions.Options;
using MongoDB.Driver;


namespace media_api.Database
{
    public class MongoDbContext : IMongoDbContext
    {
        private IMongoDatabase _db { get; set; }

        private readonly MongoDbSettings _settings;
        public MongoDbContext(IOptions<MongoDbSettings> mongoDbSettings)
        {
            _settings =  mongoDbSettings.Value;
            var client = new MongoClient(_settings.ConnectionString);
            _db = client.GetDatabase(_settings.DatabaseName);
        }

        public IMongoCollection<Image> GetImageCollection()
        {
            return _db.GetCollection<Image>(_settings.CollectionName);
        }
    }    
}