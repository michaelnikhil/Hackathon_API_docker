using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace media_api.Model
{
    public class Image 
        {
            [BsonId]
            [BsonRepresentation(BsonType.ObjectId)]
            public string Id { get; set; }
            public string Label { get; set; }
            public string Path {get; set;}
        }
}