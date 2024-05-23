using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStore.Core.Domain.Common.ValueObjects;
using OnlineStore.Core.Domain.Orders.Entities;
using OnlineStore.Core.Domain.Products.Entities;
using OnlineStore.Core.Domain.Products.ValueObjects;

namespace OnlineStore.Infrastructure.Sql.Products;

public sealed class ProductsConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(p => p.Title)
            .IsRequired()
            .HasMaxLength(40)
            .HasConversion(title => title.Value, value => Title.Set(value));

        builder.Property(p => p.InventoryCount).HasConversion(count => count.Value, value => Count.Set(value));
        builder.Property(p => p.Price).HasConversion(price => price.Value, value => Price.Set(value));
        builder.Property(p => p.Discount).HasConversion(discount => discount.Value, value => Discount.Set(value));

        builder.HasMany<Order>().WithOne().HasForeignKey(p => p.ProductId).OnDelete(DeleteBehavior.Restrict);
    }
}
