using Xunit;
using Moq;
using media_api.Database;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace media_api.Tests
{
    public class MongoDBContextTests
    {
        private readonly Mock<IOptions<MongoDbSettings>> _mockOptions;
        private readonly Mock<IMongoDatabase> _mockDB;
        private readonly Mock<IMongoClient> _mockClient;

        public MongoDBContextTests()
        {
            _mockOptions = new Mock<IOptions<MongoDbSettings>>();
            _mockDB = new Mock<IMongoDatabase>();
            _mockClient = new Mock<IMongoClient>();
        }
        
        
        [Fact]
        public void MongoDBContext_constructor_success()
        {
            var settings = new MongoDbSettings()
            {
                ConnectionString = "mongodb://tes123 ",
                DatabaseName = "TestDB"
            };

            _mockOptions.Setup(s => s.Value).Returns(settings);
            _mockClient.Setup(c => c
            .GetDatabase(_mockOptions.Object.Value.DatabaseName, null))
                .Returns(_mockDB.Object);

            //Act 
            var context = new MongoDbContext(_mockOptions.Object);

            //Assert 
            Assert.NotNull(context);

        }
    }
}
