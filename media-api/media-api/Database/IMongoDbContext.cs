using MongoDB.Driver;

namespace media_api.Database
{
    public interface  IMongoDbContext
    {
        IMongoDatabase Database { get; }
        string CollectionName { get; set; }
    }
}