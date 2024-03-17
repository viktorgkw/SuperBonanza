using StackExchange.Redis;

namespace Common.Providers.Redis;

public interface IRedisProvider
{
    IDatabase GetDatabase();
}