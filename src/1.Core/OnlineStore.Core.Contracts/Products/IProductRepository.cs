using OnlineStore.Core.Domain.Products.Entities;
using OnlineStore.Core.RequestResponse.Products.GetDetail;

namespace OnlineStore.Core.Contracts.Products;

public interface IProductRepository
{
    Task InsertAsync(Product product);
    Task<Product?> GetByIdAsync(int id);
    Task<GetProductDetailResult?> GetProductDetailAsync(int id);
    Task<bool> ExistAsync(string title);
    Task SaveChangeAsync();
}
