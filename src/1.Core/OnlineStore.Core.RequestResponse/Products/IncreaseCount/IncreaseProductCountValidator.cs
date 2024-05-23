using FluentValidation;
using System.Data;

namespace OnlineStore.Core.RequestResponse.Products.IncreaseCount;

public class IncreaseProductCountValidator : AbstractValidator<IncreaseProductCount>
{
    public IncreaseProductCountValidator()
    {
        RuleFor(r => r.Id).Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("Id cannot be empty")
            .GreaterThan(0).WithMessage("Id must be greater than 0");

        RuleFor(r => r.Count).Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("Count cannot be empty")
            .GreaterThan(0).WithMessage("Count must be greater than 0");
    }
}
