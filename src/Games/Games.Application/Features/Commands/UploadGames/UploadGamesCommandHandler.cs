using Games.Application.Contracts;
using MediatR;

namespace Games.Application.Features.Commands.UploadGames;

public class UploadGamesCommandHandler(IGamesStore gamesStore)
    : IRequestHandler<UploadGamesCommand>
{
    private readonly IGamesStore _gamesStore = gamesStore;

    public async Task Handle(UploadGamesCommand request, CancellationToken cancellationToken)
        => await _gamesStore.UploadGames(request.Games, cancellationToken);
}