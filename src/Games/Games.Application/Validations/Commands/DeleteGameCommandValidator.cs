using FluentValidation;
using Games.Application.Features.Commands.DeleteGame;

namespace Games.Application.Validations.Commands;

public class GetGameByIdQueryValidator : AbstractValidator<DeleteGameCommand>
{
    public GetGameByIdQueryValidator()
    {
        RuleFor(x => x.GameId)
            .NotEmpty()
            .NotNull()
            .WithMessage("GameId should not be empty or null!");
    }
}