using MediatR;
using OnlineStore.Core.RequestResponse.Common;

namespace OnlineStore.Core.RequestResponse.Products.Create;

public sealed class CreateProduct : IRequest<Result<int>>
{
    public string Title { get; set; } = default!;
    public decimal Price { get; set; }
    public int Discount { get; set; }

}
