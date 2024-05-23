using OnlineStore.Core.Contracts.Orders;
using OnlineStore.Core.Domain.Orders.Entities;
using OnlineStore.Infrastructure.Sql.Common;

namespace OnlineStore.Infrastructure.Sql.Orders;

public sealed class OrderRepository(OnlineStoreDbContext context) : IOrderRepository
{
    public async Task InsertAsync(Order Order) => await context.Orders.AddAsync(Order);
}
