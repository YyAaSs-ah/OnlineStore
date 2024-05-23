using Microsoft.Extensions.Caching.Memory;
using Moq;
using OnlineStore.Core.ApplicationServices.Products;
using OnlineStore.Core.ApplicationServices.Products.Proxies;
using OnlineStore.Core.Contracts.Products;
using OnlineStore.Core.Domain.Products.Entities;
using OnlineStore.Core.RequestResponse.Products.Create;
using OnlineStore.Core.RequestResponse.Products.GetDetail;
using System.Data;

namespace OnlineStore.ApplicationServices.Test;

public class GetProductDetailHandlerTest
{
    [Fact]
    public void GetProduct_WhenProductIsExists_ThenReturnProduct()
    {
        //Arrange
        var productRepositoryMock = new Mock<IProductRepository>();
        var memoryCacheMock = new Mock<IMemoryCache>();

        var expectedValue = new GetProductDetailResult();
        memoryCacheMock.Setup(x => x.CreateEntry(It.IsAny<object>())).Returns(Mock.Of<ICacheEntry>);

        productRepositoryMock.Setup(s => s.GetProductDetailAsync(It.IsAny<int>())).ReturnsAsync(new GetProductDetailResult()
        {
            Id = 1,
            Title = "Test",
            DiscountedPrice = 10
        });

        var prductProxy = new ProductProxy(productRepositoryMock.Object, memoryCacheMock.Object);
        var getProductDetailHandler = new GetProductDetailHandler(prductProxy);
        var getProductDetail = new GetProductDetail { Id = 1 };

        //Act
        var result = getProductDetailHandler.Handle(getProductDetail, CancellationToken.None).Result;

        //Assert
        Assert.True(result.IsSuccess);
        Assert.True(result.Data.Title == "Test");
    }

    [Fact]
    public void GetProduct_WhenProductIsNotExists_ThenRaiseKeyNotFoundException()
    {
        //Arrange
        var productRepositoryMock = new Mock<IProductRepository>();
        var memoryCacheMock = new Mock<IMemoryCache>();

        var expectedValue = new GetProductDetailResult();
        memoryCacheMock.Setup(x => x.CreateEntry(It.IsAny<object>())).Returns(Mock.Of<ICacheEntry>);

        productRepositoryMock.Setup(s => s.GetProductDetailAsync(It.IsAny<int>())).
            ReturnsAsync((GetProductDetailResult)null);

        var prductProxy = new ProductProxy(productRepositoryMock.Object, memoryCacheMock.Object);
        var getProductDetailHandler = new GetProductDetailHandler(prductProxy);
        var getProductDetail = new GetProductDetail { Id = 1 };

        //Act
        var result = () => getProductDetailHandler.Handle(getProductDetail, CancellationToken.None);

        //Assert
        Task<KeyNotFoundException> exception = Assert.ThrowsAsync<KeyNotFoundException>(result);
        Assert.Equal("Product not found", exception.Result.Message);
    }
}