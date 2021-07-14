using Xunit;
using Moq;
using media_api.Database;
using MongoDB.Driver;
using media_api.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace media_api.Tests
{
    public class ImageRepositoryTests
    {
        private readonly Mock<IMongoDbContext> _mockContext;
        private readonly Mock<IMongoDatabase> _mockDB;

        public ImageRepositoryTests()
        {
            _mockContext = new Mock<IMongoDbContext>();
            _mockDB = new Mock<IMongoDatabase>();
        }

        [Fact]
        public void ImageRepository_constructor_success()
        {
            //Arrange
            _mockContext.Setup(s => s.CollectionName).Returns(It.IsAny<string>);
            _mockContext.Setup(s => s.Database).Returns(_mockDB.Object);           

            //Act 
            var context = new ImageRepository(_mockContext.Object);

            //Assert 
            Assert.NotNull(context);
        }

        [Fact]
        public async Task ImageRepository_GetImages_CollectionNameEmpty_FailureAsync()
        {
            //Arrange
            _mockContext.Setup(s => s.CollectionName).Returns("");
            _mockContext.Setup(s => s.Database).Returns(_mockDB.Object);

            //Act 
            var context = new ImageRepository(_mockContext.Object);
            IEnumerable<Image> myImages = await context.Get();

            //Assert 
            Assert.Null(myImages);
        }
    }
}
