using MediatR;
using OnlineStore.Core.ApplicationServices.Products.Proxies;
using OnlineStore.Core.RequestResponse.Common;
using OnlineStore.Core.RequestResponse.Products.GetDetail;

namespace OnlineStore.Core.ApplicationServices.Products;

public sealed class GetProductDetailHandler(ProductProxy getProductDetailProxy) : IRequestHandler<GetProductDetail, Result<GetProductDetailResult>>
{
    public async Task<Result<GetProductDetailResult>> Handle(GetProductDetail request, CancellationToken cancellationToken)
    {
        var productDetail = await getProductDetailProxy.GetProductDetail(request);

        return new Result<GetProductDetailResult>(productDetail);
    }
}

