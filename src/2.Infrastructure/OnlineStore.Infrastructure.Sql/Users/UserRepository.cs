using Microsoft.EntityFrameworkCore;
using OnlineStore.Core.Contracts.Users;
using OnlineStore.Core.Domain.Products.ValueObjects;
using OnlineStore.Infrastructure.Sql.Common;

namespace OnlineStore.Infrastructure.Sql.Users;

public sealed class UserRepository(OnlineStoreDbContext context) : IUserRepository
{
    public async Task<bool> ExistAsync(int id) => await context.Users.AnyAsync(s => s.Id == id);
}
