using Games.Application.Contracts;
using MediatR;

namespace Games.Application.Features.Commands.DeleteGame;

public class DeleteGameCommandHandler(IGamesService gamesService)
    : IRequestHandler<DeleteGameCommand>
{
    private readonly IGamesService _gamesService = gamesService;

    public async Task Handle(DeleteGameCommand request, CancellationToken cancellationToken)
        => await _gamesService.DeleteGame(request.GameId, cancellationToken);
}