using Games.Application.Contracts;
using Games.Domain.Entities;
using MediatR;

namespace Games.Application.Features.Queries.GetGameById;

public class GetGameByIdQueryHandler(IGamesService gamesService)
    : IRequestHandler<GetGameByIdQuery, Game>
{
    private readonly IGamesService _gamesService = gamesService;

    public async Task<Game> Handle(GetGameByIdQuery request, CancellationToken cancellationToken)
        => await _gamesService.GetGameById(request.GameId, cancellationToken);
}