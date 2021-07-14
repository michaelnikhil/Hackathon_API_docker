using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace media_api.Database
{
    public interface IImageDBSettings
    {
         string ConnectionString { get; set; }
         string DatabaseName { get; set; }
         string CollectionName { get; set; }
    }
}
