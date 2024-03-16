using Games.Domain.Entities;
using MediatR;

namespace Games.Application.Features.Queries.GetAllGames;

public class GetAllGamesQuery : IRequest<IEnumerable<Game>>;