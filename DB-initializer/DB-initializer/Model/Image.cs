using System;
using MongoDB.Bson;

namespace DB_initializer.Model
{
    public class Image : IImage
        {
            public ObjectId Id { get; set; }
            public string Label { get; set; }
            public Uri Path {get; set;}
        }
}