using Games.Application.Contracts;
using MediatR;

namespace Games.Application.Features.Commands.CreateGame;

public class CreateGameCommandHandler(IGamesService gamesService)
    : IRequestHandler<CreateGameCommand>
{
    private readonly IGamesService _gamesService = gamesService;

    public async Task Handle(CreateGameCommand request, CancellationToken cancellationToken)
        => await _gamesService.CreateGame(request.Game, cancellationToken);
}