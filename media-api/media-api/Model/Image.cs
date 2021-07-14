using System;
using MongoDB.Bson;

namespace media_api.Model
{
    public class Image : IImage
        {
            public string Id { get; set; }
            public string Label { get; set; }
            public string Path {get; set;}
        }
}