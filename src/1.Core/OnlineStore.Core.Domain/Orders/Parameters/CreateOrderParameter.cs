using OnlineStore.Core.Domain.Common.ValueObjects;

namespace OnlineStore.Core.Domain.Orders.Parameters;

public sealed record CreateOrderParameter(int UserId, int ProductId, Count ProductCount);
