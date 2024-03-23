using FluentValidation;
using Impressions.Domain.Entities;

namespace Impressions.Application.Validators.Entities;

public class GameValidator : AbstractValidator<Game>
{
    public GameValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .NotNull()
            .WithMessage("Id is required!");

        RuleFor(x => x.Name)
            .NotEmpty()
            .NotNull()
            .MinimumLength(4)
            .MaximumLength(18)
            .WithMessage("Name is required!");

        RuleFor(x => x.Description)
            .NotEmpty()
            .NotNull()
            .MinimumLength(8)
            .MaximumLength(50)
            .WithMessage("Description is required!");
    }
}