using MediatR;
using OnlineStore.Core.Contracts.Products;
using OnlineStore.Core.RequestResponse.Common;
using OnlineStore.Core.RequestResponse.Products.IncreaseCount;

namespace OnlineStore.Core.ApplicationServices.Products;

public class IncreaseProductCountHandler(IProductRepository productRepository) : IRequestHandler<IncreaseProductCount, Result>
{
    public async Task<Result> Handle(IncreaseProductCount request, CancellationToken cancellationToken)
    {
        var product = await productRepository.GetByIdAsync(request.Id);
        if (product == null)
            throw new KeyNotFoundException("The specified product was not found");

        product.IncreaseCount(request.Count);

        await productRepository.SaveChangeAsync();

        return new Result();
    }
}

