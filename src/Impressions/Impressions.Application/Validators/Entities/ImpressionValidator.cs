using FluentValidation;
using Impressions.Domain.Entities;

namespace Impressions.Application.Validators.Entities;

public class ImpressionValidator : AbstractValidator<Impression>
{
    public ImpressionValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .NotNull()
            .WithMessage("Id is required!");

        RuleFor(x => x.GameId)
            .NotEmpty()
            .NotNull()
            .WithMessage("GameId is required!");

        RuleFor(x => x.PlayerId)
            .NotEmpty()
            .NotNull()
            .WithMessage("PlayerId is required!");

        RuleFor(x => x.Type)
            .NotNull()
            .WithMessage("Type is required!");
    }
}