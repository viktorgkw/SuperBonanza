using FluentValidation;
using Games.Application.Features.Commands.UploadGames;

namespace Games.Application.Validations.Commands;

public class UploadGamesCommandValidator : AbstractValidator<UploadGamesCommand>
{
    public UploadGamesCommandValidator()
    {
        RuleFor(x => x.Games)
            .NotEmpty()
            .NotNull();
    }
}