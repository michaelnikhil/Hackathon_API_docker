using System.Threading.Tasks;
using System;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Data;
using DB_initializer.Model;
using System.Collections.Generic;
using MongoDB.Driver.Core.Operations;
using DB_initializer.Job;

namespace DB_initializer.Database
{
    public class CollectionService : ICollectionService
    {
        private readonly IMongoDbContext _context;
        private readonly IImportCsv _import;
        public CollectionService(IMongoDbContext context, IImportCsv import)
        {
            _context = context;
            _import = import;
        }

        public async Task<bool> CreateCollection()
        {
            Console.WriteLine("Create collection");
            if(!await CollectionExists(_context.CollectionName)){
                await _context.Database.CreateCollectionAsync(_context.CollectionName);
            }
            else{
                Console.WriteLine("Collection already exists");
            }
            return true;
        }

        public async Task<bool> CollectionExists(string collectionName)
        {
            var filter = new BsonDocument("name", collectionName);
            IAsyncCursor<BsonDocument> collections = await _context.Database.ListCollectionsAsync(new ListCollectionsOptions { Filter = filter });
            return await collections.AnyAsync();
        }

        public async Task<bool> ImportItems()
        {
            IEnumerable<Image> images = _import.GetImagesFromFile();
            try 
            {
                await _context.Database.GetCollection<Image>(_context.CollectionName).InsertManyAsync(images);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Could not import items :" + ex.Message);
                return false;
            }
        }
    }
}