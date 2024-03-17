using FluentValidation;
using Games.Application.Features.Queries.GetAllGames;

namespace Games.Application.Validations.Queries;

public class GetAllGamesQueryValidator : AbstractValidator<GetAllGamesQuery>;