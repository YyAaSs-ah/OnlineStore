using OnlineStore.Core.Domain.Orders.Entities;

namespace OnlineStore.Core.Contracts.Orders;

public interface IOrderRepository
{
    Task InsertAsync(Order order);
}
