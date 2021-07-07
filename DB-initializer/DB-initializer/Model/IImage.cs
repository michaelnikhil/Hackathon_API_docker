using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;

namespace DB_initializer.Model
{
    public interface IImage
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        ObjectId Id { get; set; }
        string Label { get; set; }
        Uri Path {get; set;}
    }

    

}
