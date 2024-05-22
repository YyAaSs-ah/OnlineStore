using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using OnlineStore.Core.Contracts.Products;
using OnlineStore.Core.Domain.Products.Entities;
using OnlineStore.Core.Domain.Products.ValueObjects;
using OnlineStore.Infrastructure.Sql.Common;

namespace OnlineStore.Infrastructure.Sql.Products;

public class ProductRepository(OnlineStoreDbContext context) : IProductRepository
{
    public async Task<bool> ExistAsync(string title) => await context.Products.AnyAsync(s => s.Title == (Title)title);

    public async Task InsertAsync(Product product) => await context.Products.AddAsync(product);

    public async Task SaveChangeAsync() => await context.SaveChangesAsync();
}
