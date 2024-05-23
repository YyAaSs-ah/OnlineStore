using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using OnlineStore.Core.Contracts.Products;
using OnlineStore.Core.Domain.Products.Entities;
using OnlineStore.Core.Domain.Products.ValueObjects;
using OnlineStore.Core.RequestResponse.Products.GetDetail;
using OnlineStore.Infrastructure.Sql.Common;

namespace OnlineStore.Infrastructure.Sql.Products;

public class ProductRepository(OnlineStoreDbContext context) : IProductRepository
{
    public async Task<bool> ExistAsync(string title) => await context.Products.AnyAsync(s => s.Title == (Title)title);

    public async Task<Product?> GetByIdAsync(int id) => await context.Products.SingleOrDefaultAsync(s => s.Id == id);
    public async Task<GetProductDetailResult?> GetProductDetailAsync(int id)
    {
        return await context.Products.Select(s => new GetProductDetailResult
        {
            Id = s.Id,
            Title = s.Title.Value,
            InventoryCount = s.InventoryCount.Value,
            DiscountedPrice = (100 - (int)s.Discount) * 0.01M * (decimal)s.Price

        }).SingleOrDefaultAsync(w => w.Id == id); ;
    }

    public async Task InsertAsync(Product product) => await context.Products.AddAsync(product);

    public async Task SaveChangeAsync() => await context.SaveChangesAsync();
}
