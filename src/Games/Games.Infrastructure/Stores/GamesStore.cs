using Common.Providers.Redis;
using Games.Application.Contracts;
using Games.Domain.Configuration;
using Games.Domain.Entities;
using MessagePack;
using Microsoft.Extensions.Options;
using StackExchange.Redis;

namespace Games.Infrastructure.Stores;

public class GamesStore(
    IRedisProvider redisProvider,
    IOptions<RedisStoreSettings> storeSettings)
    : IGamesStore
{
    private readonly SemaphoreSlim _semaphore = new(1, 1);
    private readonly IDatabase _redisDb = redisProvider.GetDatabase();
    private readonly RedisStoreSettings _storeSettings = storeSettings.Value;

    public async Task ClearAllGames(IEnumerable<Game> games, CancellationToken cancellationToken)
    {
        await Task.Yield();
        await _semaphore.WaitAsync(cancellationToken);

        try
        {
            var key = new RedisKey(_storeSettings.GamesHashKey);
            foreach (var game in games)
            {
                RedisValue value = MessagePackSerializer.Serialize(game, cancellationToken: cancellationToken);
                await _redisDb.HashDeleteAsync(key, value);
            }
        }
        catch (Exception ex)
        {
            // log error
        }
        finally
        {
            _semaphore.Release();
        }
    }

    public async Task UploadGames(IEnumerable<Game> games, CancellationToken cancellationToken)
    {
        await Task.Yield();
        await _semaphore.WaitAsync(cancellationToken);

        try
        {
            var key = new RedisKey(_storeSettings.GamesHashKey);
            var entries = games
                .Select(g => new HashEntry(g.Id.ToString(), MessagePackSerializer.Serialize(g)))
                .ToArray();

            await _redisDb.HashSetAsync(key, entries);
        }
        catch (Exception ex)
        {
            // log error
        }
        finally
        {
            _semaphore.Release();
        }
    }
}