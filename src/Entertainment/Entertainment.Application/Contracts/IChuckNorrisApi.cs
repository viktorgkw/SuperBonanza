using Entertainment.Domain.Entities;
using Refit;

namespace Entertainment.Application.Contracts;

public interface IChuckNorrisApi
{
    [Get("/jokes/random")]
    Task<Joke> GetRandomJoke();
}