using OnlineStore.Core.Domain.Common.Entities;
using OnlineStore.Core.Domain.Common.ValueObjects;
using OnlineStore.Core.Domain.Products.Parameters;
using OnlineStore.Core.Domain.Products.ValueObjects;

namespace OnlineStore.Core.Domain.Products.Entities;

public sealed class Product : BaseEntity
{
    #region Properties
    public Title Title { get; private set; }
    public Count InventoryCount { get; private set; }
    public Price Price { get; private set; }
    public Discount Discount { get; private set; }
    #endregion

    #region Constructors
    private Product() { }
    private Product(CreateProductParameter productParameter)
    {
        Title = productParameter.Title;
        InventoryCount = Count.Set(1);
        Price = productParameter.Price;
        Discount = productParameter.Discount;
    }
    #endregion

    #region Methods
    public static Product Create(CreateProductParameter productParameter) =>
        new Product(productParameter);
    public void IncreaseCount(int count) => InventoryCount = Count.Set(InventoryCount.Value + count);
    public void DecreaseCount(int count)
    {
        if (InventoryCount.Value < count)
            throw new Exception("Insufficient inventory");

        InventoryCount = Count.Set(InventoryCount.Value - count);
    }
    #endregion
}
