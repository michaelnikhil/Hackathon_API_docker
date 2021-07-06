using System.Threading.Tasks;

namespace DB_initializer.Job
{
    using DB_initializer.Database;

    class RunTasks
    {
        private readonly ICollectionService _collectionService;
        public RunTasks(ICollectionService collectionService)
        {
            _collectionService=collectionService;

        }


        public async Task Run()
        {
            bool success = await _collectionService.CreateCollection();

        }

    }
}