using Entertainment.Domain.Entities;

namespace Entertainment.Application.Contracts;

public interface IJokeService
{
    Task<Joke> GetRandomJoke();
}