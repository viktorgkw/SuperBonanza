using Entertainment.Domain.Entities;
using MediatR;

namespace Entertainment.Application.Features.Queries.GetRandomJoke;

public class GetRandomJokeQuery : IRequest<Joke>;