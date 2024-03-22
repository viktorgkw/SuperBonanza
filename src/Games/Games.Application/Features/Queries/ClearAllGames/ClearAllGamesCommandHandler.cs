using Games.Application.Contracts;
using MediatR;

namespace Games.Application.Features.Queries.ClearAllGames;

public class ClearAllGamesCommandHandler(IGamesStore gamesStore)
    : IRequestHandler<ClearAllGamesCommand>
{
    private readonly IGamesStore _gamesStore = gamesStore;

    public async Task Handle(ClearAllGamesCommand request, CancellationToken cancellationToken)
        => await _gamesStore.ClearAllGames(request.Games, cancellationToken);
}