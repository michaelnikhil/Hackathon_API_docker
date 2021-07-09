using System;
using MongoDB.Bson;

namespace media_api.Model
{
    public interface IImage
        {    
           // [BsonId]
           // [BsonRepresentation(BsonType.String)]
            ObjectId Id { get; set; }
            string Label { get; set; }
            Uri Path {get; set;}
        }
}