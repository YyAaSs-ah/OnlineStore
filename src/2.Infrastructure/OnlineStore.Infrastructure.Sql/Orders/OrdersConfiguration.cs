using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStore.Core.Domain.Common.ValueObjects;
using OnlineStore.Core.Domain.Orders.Entities;

namespace OnlineStore.Infrastructure.Sql.Orders;

public sealed class OrdersConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.Property(p => p.ProductCount).HasConversion(count => count.Value, value => Count.Set(value));
    }
}
