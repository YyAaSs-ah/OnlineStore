using Microsoft.Extensions.Caching.Memory;
using OnlineStore.Core.Contracts.Products;
using OnlineStore.Core.RequestResponse.Products.GetDetail;

namespace OnlineStore.Core.ApplicationServices.Products.Proxies;

public class ProductProxy(IProductRepository productRepository, IMemoryCache memoryCache)
{
    public async Task<GetProductDetailResult> GetProductDetail(GetProductDetail request)
    {
        if (memoryCache.TryGetValue($"Product_Id_{request.Id}", out GetProductDetailResult? cachedProductDetail) &&
           cachedProductDetail is not null)
            return cachedProductDetail;

        var productDetail = await productRepository.GetProductDetailAsync(request.Id);
        if (productDetail == null)
            throw new KeyNotFoundException("Product not found");

        memoryCache.Set($"Product_Id_{request.Id}", productDetail, TimeSpan.FromDays(1));

        return productDetail;
    }
}
