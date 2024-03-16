using Games.Application.Contracts;
using Games.Domain.Entities;
using MediatR;

namespace Games.Application.Features.Queries.GetAllGames;

public class GetAllGamesQueryHandler(IGamesService gamesService)
    : IRequestHandler<GetAllGamesQuery, IEnumerable<Game>>
{
    private readonly IGamesService _gamesService = gamesService;

    public async Task<IEnumerable<Game>> Handle(GetAllGamesQuery request, CancellationToken cancellationToken)
        => await _gamesService.GetAllGames(cancellationToken);
}