using Microsoft.Extensions.Options;
using MongoDB.Driver;


namespace DB_initializer.Database
{
    public class MongoDbContext : IMongoDbContext
    {
        private IMongoClient _mongoClient;
        private readonly string _uri;
        private readonly string _databaseName;

        public MongoDbContext(IOptions<MongoDbSettings> mongoDbSettings)
        {
            _uri = mongoDbSettings.Value.Uri;
            _databaseName = mongoDbSettings.Value.DatabaseName;
        }

        public IMongoDatabase GetMongoDatabase()
        {
            _mongoClient = _mongoClient ??= new MongoClient(_uri);
            return _mongoClient.GetDatabase(_databaseName);
        }
    }
}