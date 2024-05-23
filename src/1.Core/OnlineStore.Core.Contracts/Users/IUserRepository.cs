using OnlineStore.Core.Domain.Products.Entities;
using OnlineStore.Core.RequestResponse.Products.GetDetail;

namespace OnlineStore.Core.Contracts.Users;

public interface IUserRepository
{
    Task<bool> ExistAsync(int id);
}
