using MediatR;
using OnlineStore.Core.Contracts.Products;
using OnlineStore.Core.Domain.Products.Entities;
using OnlineStore.Core.Domain.Products.Parameters;
using OnlineStore.Core.Domain.Products.ValueObjects;
using OnlineStore.Core.RequestResponse.Common;
using OnlineStore.Core.RequestResponse.Products.Create;
using System.Data;

namespace OnlineStore.Core.ApplicationServices.Products;

public class CreateProductHandler(IProductRepository productRepository) : IRequestHandler<CreateProduct, Result<int>>
{
    public async Task<Result<int>> Handle(CreateProduct request, CancellationToken cancellationToken)
    {
        if (await productRepository.ExistAsync(request.Title))
            throw new DuplicateNameException("Product`s name is duplicated");
        
        var product = Product.Create(new CreateProductParameter
        (
             Title.Set(request.Title),
             Price.Set(request.Price),
             Discount.Set(request.Discount)
         ));
        await productRepository.InsertAsync(product);
        await productRepository.SaveChangeAsync();

        return new Result<int>(product.Id);
    }
}


