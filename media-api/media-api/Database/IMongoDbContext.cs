using media_api.Model;
using MongoDB.Driver;
using System.Collections.Generic;

namespace media_api.Database
{
    public interface  IMongoDbContext
    {
        IMongoDatabase Database { get; }
        string CollectionName { get; set; }
    }
}