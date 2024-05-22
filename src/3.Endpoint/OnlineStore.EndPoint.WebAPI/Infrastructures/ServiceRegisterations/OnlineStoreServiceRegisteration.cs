using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using OnlineStore.Core.Contracts.Products;
using OnlineStore.Infrastructure.Sql.Common;
using OnlineStore.Infrastructure.Sql.Products;

namespace OnlineStore.EndPoint.WebAPI.Infrastructures.ServiceRegisterations;

public static class OnlineStoreServiceRegisteration
{
    public static IServiceCollection RegisterRepositories(this IServiceCollection services)
    {
        services.AddScoped<IProductRepository, ProductRepository>();

        return services;
    }
}
