using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace media_api.Model
{
    public interface IImage
        {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        string Id { get; set; }
            string Label { get; set; }
            string Path {get; set;}
        }
}