using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnlineStore.Core.Domain.Products.Entities;
using OnlineStore.Core.Domain.Products.ValueObjects;
using System.Linq.Expressions;

namespace OnlineStore.Infrastructure.Sql.Common;

public class OnlineStoreDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public OnlineStoreDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(OnlineStoreDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}

