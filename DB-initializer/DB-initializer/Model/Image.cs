using System;

namespace DB_initializer.Model
{
    public class Image : IImage
        {
            public Object Id { get; set; }
            public string Label { get; set; }
            public Uri Path {get; set;}
        }
}