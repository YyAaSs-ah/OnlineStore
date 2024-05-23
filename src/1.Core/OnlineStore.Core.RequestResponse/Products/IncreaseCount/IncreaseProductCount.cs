using MediatR;
using OnlineStore.Core.RequestResponse.Common;

namespace OnlineStore.Core.RequestResponse.Products.IncreaseCount;

public sealed class IncreaseProductCount : IRequest<Result>
{
    public int Id { get; set; }
    public int Count { get; set; }

}
