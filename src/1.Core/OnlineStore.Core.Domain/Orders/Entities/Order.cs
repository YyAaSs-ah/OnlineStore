using OnlineStore.Core.Domain.Common.Entities;
using OnlineStore.Core.Domain.Common.ValueObjects;
using OnlineStore.Core.Domain.Orders.Parameters;

namespace OnlineStore.Core.Domain.Orders.Entities;

public sealed class Order : BaseEntity
{
    #region Properties
    public DateTime CreationDate { get; private set; }
    public int UserId { get; private set; }
    public int ProductId { get; private set; }
    public Count ProductCount { get; private set; }

    #endregion

    #region Constructors
    private Order() { }
    private Order(CreateOrderParameter createOrderParameter)
    {
        CreationDate = DateTime.Now;
        UserId = createOrderParameter.UserId;
        ProductId = createOrderParameter.ProductId;
        ProductCount = createOrderParameter.ProductCount;
    }
    #endregion

    #region Methods
    public static Order Create(CreateOrderParameter createOrderParameter) => new Order(createOrderParameter);

    #endregion
}
