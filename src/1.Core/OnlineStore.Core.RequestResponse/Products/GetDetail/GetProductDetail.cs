using MediatR;
using OnlineStore.Core.RequestResponse.Common;

namespace OnlineStore.Core.RequestResponse.Products.GetDetail;

public class GetProductDetail : IRequest<Result<GetProductDetailResult>>
{
    public int Id { get; set; }
}
