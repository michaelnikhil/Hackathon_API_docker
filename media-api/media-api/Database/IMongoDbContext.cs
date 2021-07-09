using media_api.Model;
using MongoDB.Driver;

namespace media_api.Database
{
    public interface  IMongoDbContext
    {
        IMongoCollection<Image> GetImageCollection();

    }
}