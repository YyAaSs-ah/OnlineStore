using MediatR;

namespace OnlineStore.Core.RequestResponse.Products.GetDetail;

public class GetProductDetailResult
{
    public int Id { get; set; }
    public string Title { get; set; } = default!;
    public int InventoryCount { get; set; }
    public decimal DiscountedPrice { get; set; }
}
