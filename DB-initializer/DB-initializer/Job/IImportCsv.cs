using DB_initializer.Model;

using System.Collections.Generic;

namespace DB_initializer.Job
{
    public interface IImportCsv
    {
        IEnumerable<Image> GetImagesFromFile();
    }
}