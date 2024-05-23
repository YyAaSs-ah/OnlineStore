using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnlineStore.Core.Domain.Orders.Entities;
using OnlineStore.Core.Domain.Products.Entities;
using OnlineStore.Core.Domain.Products.ValueObjects;
using OnlineStore.Core.Domain.Users.Entities;
using System.Linq.Expressions;

namespace OnlineStore.Infrastructure.Sql.Common;

public sealed class OnlineStoreDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<User> Users{ get; set; }
    public DbSet<Order> Orders{ get; set; }
    public OnlineStoreDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(OnlineStoreDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}

