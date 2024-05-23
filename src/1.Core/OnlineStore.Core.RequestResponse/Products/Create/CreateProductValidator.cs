using FluentValidation;
using System.Data;

namespace OnlineStore.Core.RequestResponse.Products.Create;

public sealed class CreateProductValidator : AbstractValidator<CreateProduct>
{
    public CreateProductValidator()
    {
        RuleFor(r => r.Title).Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("Title cannot be empty")
            .MaximumLength(40).WithMessage("Title cannot be more than 40 characters ");

        RuleFor(r => r.Discount).Cascade(CascadeMode.Stop).InclusiveBetween(0, 100)
            .WithMessage("Discount percentage is a number between 0 to 100");

        RuleFor(r => r.Price).Cascade(CascadeMode.Stop).GreaterThan(0)
           .WithMessage("Price cannot be less than 1$");
    }
}
