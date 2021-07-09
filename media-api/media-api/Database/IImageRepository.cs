using System.Security.Permissions;
using System.Threading.Tasks;
using System.Collections.Generic;
using media_api.Model;

namespace media_api.Database
{
    public interface IImageRepository
    {       
        Task Create(Image obj);
        // void Update(TEntity obj);
        void Delete(string id);
        Task<Image> Get(string id);
        Task<IEnumerable<Image>> Get();
    }
}
