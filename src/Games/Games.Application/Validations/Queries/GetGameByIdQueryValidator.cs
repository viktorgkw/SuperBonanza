using FluentValidation;
using Games.Application.Features.Queries.GetGameById;

namespace Games.Application.Validations.Queries;

public class GetGameByIdQueryValidator : AbstractValidator<GetGameByIdQuery>
{
    public GetGameByIdQueryValidator()
    {
        RuleFor(x => x.GameId)
            .NotEmpty()
            .NotNull()
            .WithMessage("GameId should not be empty or null!");
    }
}