using MediatR;
using OnlineStore.Core.Contracts.Products;
using OnlineStore.Core.RequestResponse.Common;
using OnlineStore.Core.RequestResponse.Products.GetDetail;

namespace OnlineStore.Core.ApplicationServices.Products;

public sealed class GetProductDetailHandler(IProductRepository productRepository) : IRequestHandler<GetProductDetail, Result<GetProductDetailResult>>
{
    public async Task<Result<GetProductDetailResult>> Handle(GetProductDetail request, CancellationToken cancellationToken)
    {
        var productDetail = await productRepository.GetProductDetailAsync(request.Id);
        if (productDetail == null)
            throw new KeyNotFoundException("The specified product was not found");

        return new Result<GetProductDetailResult>(productDetail);
    }
}

