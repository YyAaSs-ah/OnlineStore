using MediatR;

namespace OnlineStore.Core.RequestResponse.Products.GetDetail;

public sealed class GetProductDetailResult
{
    public int Id { get; set; }
    public string Title { get; set; } = default!;
    public decimal DiscountedPrice { get; set; }
}
