using MediatR;
using OnlineStore.Core.Contracts.Orders;
using OnlineStore.Core.Contracts.Products;
using OnlineStore.Core.Contracts.Users;
using OnlineStore.Core.Domain.Common.ValueObjects;
using OnlineStore.Core.Domain.Orders.Entities;
using OnlineStore.Core.Domain.Orders.Parameters;
using OnlineStore.Core.RequestResponse.Common;
using OnlineStore.Core.RequestResponse.Orders.Create;

namespace OnlineStore.Core.ApplicationServices.Orders;

public sealed class CreateOrderHandler(IOrderRepository orderRepository,
                                IProductRepository productRepository,
                                IUserRepository userRepository) : IRequestHandler<CreateOrder, Result<int>>
{
    public async Task<Result<int>> Handle(CreateOrder request, CancellationToken cancellationToken)
    {
        if (!await userRepository.ExistAsync(request.UserId))
            throw new KeyNotFoundException("User not found");

        var product = await productRepository.GetByIdAsync(request.ProductId);
        if (product is null)
            throw new KeyNotFoundException("Product not found");

        product.DecreaseCount(request.ProductCount);

        var order = Order.Create(new CreateOrderParameter(
            request.UserId, request.ProductId, Count.Set(request.ProductCount)));

        await orderRepository.InsertAsync(order);
        await productRepository.SaveChangeAsync();

        return new Result<int>(product.Id);
    }
}


