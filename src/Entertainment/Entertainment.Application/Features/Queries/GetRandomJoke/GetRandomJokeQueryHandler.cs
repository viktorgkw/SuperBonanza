using Entertainment.Application.Contracts;
using Entertainment.Domain.Entities;
using MediatR;

namespace Entertainment.Application.Features.Queries.GetRandomJoke;

public class GetRandomJokeQueryHandler(IJokeService jokeService)
    : IRequestHandler<GetRandomJokeQuery, Joke>
{
    private readonly IJokeService _jokeService = jokeService;

    public async Task<Joke> Handle(GetRandomJokeQuery request, CancellationToken cancellationToken)
        => await _jokeService.GetRandomJoke();
}