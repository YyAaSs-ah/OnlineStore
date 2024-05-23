using Moq;
using OnlineStore.Core.ApplicationServices.Products;
using OnlineStore.Core.Contracts.Products;
using OnlineStore.Core.Domain.Products.Entities;
using OnlineStore.Core.RequestResponse.Products.Create;
using System.Data;

namespace OnlineStore.ApplicationServices.Test;

public class CreateProductHandlerTest
{
    [Fact]
    public void CreateProduct_WhenProductNameIsExists_ThenRaiseDuplicateError()
    {
        //Arrange
        var productRepositoryMock = new Mock<IProductRepository>();
        productRepositoryMock.Setup(s => s.ExistAsync(It.IsAny<string>())).ReturnsAsync(true);
        productRepositoryMock.Setup(s => s.InsertAsync(It.IsAny<Product>()));

        var createProductHandler = new CreateProductHandler(productRepositoryMock.Object);
        var createProduct = new CreateProduct { Title = "Desktop", Price = 1000, Discount = 10 };

        //Act
        var result = () => createProductHandler.Handle(createProduct, CancellationToken.None);

        //Assert
        Task<DuplicateNameException> exception = Assert.ThrowsAsync<DuplicateNameException>(result);
        Assert.Equal("Product`s name is duplicated", exception.Result.Message);
    }

    [Fact]
    public void CreateProduct_WhenProductNameIsNotExists_ThenCreateProduct()
    {
        //Arrange
        var productRepositoryMock = new Mock<IProductRepository>();
        productRepositoryMock.Setup(s => s.ExistAsync(It.IsAny<string>())).ReturnsAsync(false);
        productRepositoryMock.Setup(s => s.InsertAsync(It.IsAny<Product>()));

        var createProductHandler = new CreateProductHandler(productRepositoryMock.Object);
        var createProduct = new CreateProduct { Title = "Desktop", Price = 1000, Discount = 10 };

        //Act
        var result = createProductHandler.Handle(createProduct, CancellationToken.None).Result;

        //Assert
        Assert.True(result.IsSuccess);
    }
}