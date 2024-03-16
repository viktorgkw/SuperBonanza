using Games.Domain.Entities;
using MediatR;

namespace Games.Application.Features.Queries.GetGameById;

public class GetGameByIdQuery : IRequest<Game>
{
    public string GameId { get; set; }
}