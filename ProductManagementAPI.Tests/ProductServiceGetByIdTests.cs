using Microsoft.Extensions.Logging;
using Moq;
using ProductManagementAPI.Models;
using ProductManagementAPI.Repositories;
using ProductManagementAPI.Services;

namespace ProductManagementAPI.Tests
{
    public class ProductServiceGetByIdTests
    {
        [Fact]
        public async Task GetProductByIdAsync_Returns_Null_When_Product_Does_Not_Exist()
        {
            // Arrange
            // Create a mock repository so we can simulate repository behavior
            // without connecting to a real database.
            var repositoryMock = new Mock<IProductRepository>();

            // Configure the mocked repository to return null when the service
            // requests a product with Id 999. This simulates a "product not found" case.
            repositoryMock.Setup(x => x.GetByIdAsync(Guid.Parse("63E8E98F-5C49-4AEA-B5F5-A65B6747B8E2")))
                          .ReturnsAsync((Product?)null);

            // Create a mock logger because ProductService requires an ILogger<ProductService>
            // in its constructor, but real logging is not needed for this unit test.
            var loggerMock = new Mock<ILogger<ProductService>>();

            // Create the service instance by injecting the mocked repository
            // and mocked logger.
            var service = new ProductService(repositoryMock.Object, loggerMock.Object);

            // Act
            // Call the service method with a product Id that does not exist.
            var result = await service.GetProductByIdAsync(Guid.Parse("63E8E98F-5C49-4AEA-B5F5-A65B6747B8E2"));

            // Assert
            // Verify that the service correctly returns null
            // when the requested product is not found.
            Assert.Null(result);
        }
    }
}
