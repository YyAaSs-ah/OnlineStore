using OnlineStore.Core.Domain.Products.ValueObjects;

namespace OnlineStore.Core.Domain.Products.Parameters;

public sealed record CreateProductParameter(Title Title, Price Price, Discount Discount);
