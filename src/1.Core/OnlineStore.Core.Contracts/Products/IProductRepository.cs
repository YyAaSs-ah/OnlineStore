using OnlineStore.Core.Domain.Products.Entities;

namespace OnlineStore.Core.Contracts.Products;

public interface IProductRepository
{
    Task InsertAsync(Product product);
    Task<bool> ExistAsync(string title);
    Task SaveChangeAsync();
}
