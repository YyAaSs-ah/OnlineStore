using MediatR;
using OnlineStore.Core.RequestResponse.Common;

namespace OnlineStore.Core.RequestResponse.Orders.Create;

public sealed class CreateOrder : IRequest<Result<int>>
{
    public int UserId { get; set; }
    public int ProductId { get; set; }
    public int ProductCount { get; set; }

}
