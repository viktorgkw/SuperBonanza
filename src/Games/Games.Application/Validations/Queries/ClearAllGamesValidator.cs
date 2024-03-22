using FluentValidation;
using Games.Application.Features.Commands.UploadGames;

namespace Games.Application.Validations.Queries;

public class ClearAllGamesValidator : AbstractValidator<UploadGamesCommand>
{
    public ClearAllGamesValidator()
    {
        RuleFor(x => x.Games)
            .NotEmpty()
            .NotNull();
    }
}