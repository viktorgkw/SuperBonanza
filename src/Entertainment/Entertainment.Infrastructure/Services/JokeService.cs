using Entertainment.Application.Contracts;
using Entertainment.Domain.Configuration;
using Entertainment.Domain.Entities;
using Microsoft.Extensions.Options;
using Refit;

namespace Entertainment.Infrastructure.Services;

public class JokeService(
    IOptions<ExternalProviders> externalProviders)
    : IJokeService
{
    private readonly ExternalProviders _externalProviders = externalProviders.Value;

    public async Task<Joke> GetRandomJoke()
    {
        var jokesApi = RestService.For<IChuckNorrisApi>(_externalProviders.Providers["ChuckNorrisApi"]);

        return await jokesApi.GetRandomJoke();
    }
}