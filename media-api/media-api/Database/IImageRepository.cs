using System.Threading.Tasks;
using System.Collections.Generic;
using media_api.Model;
using System.Linq.Expressions;
using System;

namespace media_api.Database
{
    public interface IImageRepository
    {
        Task<IEnumerable<Image>> Get(Expression<Func<Image, bool>> filter = null);
        Task<string> Save(Image image);
        Task Update(Image image);
    }
}
