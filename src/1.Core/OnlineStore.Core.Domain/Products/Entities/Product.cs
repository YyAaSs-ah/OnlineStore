using OnlineStore.Core.Domain.Common;
using OnlineStore.Core.Domain.Products.Parameters;
using OnlineStore.Core.Domain.Products.ValueObjects;

namespace OnlineStore.Core.Domain.Products.Entities;

public sealed class Product : BaseEntity
{
    public Title Title { get; private set; }
    public InventoryCount InventoryCount { get; private set; }
    public Price Price { get; private set; }
    public Discount Discount { get; private set; }

    private Product() { }
    private Product(CreateProductParameter productParameter)
    {
        Title = productParameter.Title;
        InventoryCount = InventoryCount.Set(1);
        Price = productParameter.Price;
        Discount = productParameter.Discount;
    }
    public static Product Create(CreateProductParameter productParameter) =>
        new Product(productParameter);
   
}
