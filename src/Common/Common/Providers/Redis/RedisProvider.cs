using AutoMapper;
using Common.Configuration;
using StackExchange.Redis;

namespace Common.Providers.Redis;

public class RedisProvider(
    RedisConnectionConfig config,
    IMapper mapper)
    : IRedisProvider
{
    private readonly ConnectionMultiplexer _connection = ConnectionMultiplexer.Connect(mapper.Map<ConfigurationOptions>(config));

    public IDatabase GetDatabase() => _connection.GetDatabase();
}