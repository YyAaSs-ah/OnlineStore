using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using OnlineStore.Core.Contracts.Orders;
using OnlineStore.Core.Contracts.Products;
using OnlineStore.Core.Contracts.Users;
using OnlineStore.Infrastructure.Sql.Common;
using OnlineStore.Infrastructure.Sql.Orders;
using OnlineStore.Infrastructure.Sql.Products;
using OnlineStore.Infrastructure.Sql.Users;

namespace OnlineStore.EndPoint.WebAPI.Infrastructures.ServiceRegisterations;

public static class OnlineStoreServiceRegisteration
{
    public static IServiceCollection RegisterRepositories(this IServiceCollection services)
    {
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();

        return services;
    }
}
