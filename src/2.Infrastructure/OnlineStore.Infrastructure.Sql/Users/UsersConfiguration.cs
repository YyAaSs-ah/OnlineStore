using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStore.Core.Domain.Orders.Entities;
using OnlineStore.Core.Domain.Users.Entities;
using OnlineStore.Core.Domain.Users.Parameters;
using OnlineStore.Core.Domain.Users.ValueObjects;

namespace OnlineStore.Infrastructure.Sql.Users;

public sealed class UsersConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(50)
            .HasConversion(name => name.Value, value => Name.Set(value));

        builder.HasMany<Order>().WithOne().HasForeignKey(p => p.UserId).OnDelete(DeleteBehavior.Restrict);
    }
}
