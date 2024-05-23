using FluentValidation;
using System.Data;

namespace OnlineStore.Core.RequestResponse.Orders.Create;

public sealed class CreateOrderValidator : AbstractValidator<CreateOrder>
{
    public CreateOrderValidator()
    {
        RuleFor(r => r.UserId).Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("UserId cannot be empty")
            .GreaterThan(0).WithMessage("UserId must be greater than 0");
        
        RuleFor(r => r.ProductId).Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("ProductId cannot be empty")
            .GreaterThan(0).WithMessage("ProductId must be greater than 0");
        
        RuleFor(r => r.ProductCount).Cascade(CascadeMode.Stop).GreaterThan(0)
           .WithMessage("Product count cannot be less than 1");
    }
}
