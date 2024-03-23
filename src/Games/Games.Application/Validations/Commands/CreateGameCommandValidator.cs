using FluentValidation;
using Games.Application.Features.Commands.CreateGame;

namespace Games.Application.Validations.Commands;

public class CreateGameCommandValidator : AbstractValidator<CreateGameCommand>
{
    public CreateGameCommandValidator()
    {
        RuleFor(x => x.Game.Id)
            .NotEmpty()
            .NotNull()
            .WithMessage("Game Id is required!");

        RuleFor(x => x.Game.Name)
            .NotEmpty()
            .NotNull()
            .MinimumLength(4)
            .MaximumLength(18)
            .WithMessage("Game Name is required!");

        RuleFor(x => x.Game.Description)
            .NotEmpty()
            .NotNull()
            .MinimumLength(4)
            .MaximumLength(18)
            .WithMessage("Game Description is required!");
    }
}