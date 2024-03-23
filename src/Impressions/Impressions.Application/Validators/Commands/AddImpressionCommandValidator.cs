using FluentValidation;
using Impressions.Application.Features.Commands.AddImpression;

namespace Impressions.Application.Validators.Commands;

public class AddImpressionCommandValidator : AbstractValidator<AddImpressionCommand>
{
    public AddImpressionCommandValidator()
    {
        RuleFor(x => x.Impression.Id)
            .NotEmpty()
            .NotNull()
            .WithMessage("Id is required!");

        RuleFor(x => x.Impression.GameId)
            .NotEmpty()
            .NotNull()
            .WithMessage("GameId is required!");

        RuleFor(x => x.Impression.PlayerId)
            .NotEmpty()
            .NotNull()
            .WithMessage("PlayerId is required!");

        RuleFor(x => x.Impression.Type)
            .NotNull()
            .WithMessage("Type is required!");
    }
}