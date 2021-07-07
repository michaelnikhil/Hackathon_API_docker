using System.ComponentModel.Design;
using System.Net.Mime;
using System.Collections.Generic;
using CsvHelper;
using System.IO;
using DB_initializer.Model;
using System.Globalization;
using System.Linq;
using MongoDB.Driver.Core.WireProtocol.Messages;
using MongoDB.Driver;

namespace DB_initializer.Job
{
    public class ImportCsv : IImportCsv
    {
        public IEnumerable<Image> GetImagesFromFile()
        {
            using (var reader = new StreamReader(Directory.GetCurrentDirectory() + "/ImageImport.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var images = csv.GetRecords<Image>();
                if (images !=null)
                {
                    return images.ToList();
                }
                else
                {
                    return new List<Image>{};
                }
            }
        }
    }
}