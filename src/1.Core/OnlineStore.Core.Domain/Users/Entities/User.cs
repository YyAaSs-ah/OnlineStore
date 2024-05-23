using OnlineStore.Core.Domain.Common.Entities;
using OnlineStore.Core.Domain.Orders.Entities;
using OnlineStore.Core.Domain.Users.Parameters;
using OnlineStore.Core.Domain.Users.ValueObjects;
using System.Xml.Linq;

namespace OnlineStore.Core.Domain.Users.Entities;

public sealed class User : BaseEntity
{
    #region Properties
    public Name Name { get; private set; }
    #endregion

    #region Constructors
    private User() { }
    private User(CreateUserParameter createUserParameter)
    {
        Name = createUserParameter.Name;
    }
    #endregion

    #region Methods
    public static User Create(CreateUserParameter createUserParameter) => new User(createUserParameter);

    #endregion
}
