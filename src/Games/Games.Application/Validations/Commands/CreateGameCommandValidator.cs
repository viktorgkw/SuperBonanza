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
            .WithMessage("Game Id should not be empty or null!");

        RuleFor(x => x.Game.Name)
            .NotEmpty()
            .NotNull()
            .WithMessage("Game Name should not be empty or null!");

        RuleFor(x => x.Game.Description)
            .NotEmpty()
            .NotNull()
            .WithMessage("Game Description should not be empty or null!");
    }
}