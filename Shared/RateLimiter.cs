using StackExchange.Redis;

namespace minimal_api_distributed_rate_limiting_redis.Shared;

public static class RateLimiter
{
    private static readonly ConnectionMultiplexer Redis = ConnectionMultiplexer.Connect("localhost:6379");
    private static readonly IDatabase RedisDb = Redis.GetDatabase();

    public static async Task<bool> IsRateLimited(string key, int limit, int windowSeconds)
    {
        var count = await RedisDb.StringIncrementAsync(key);

        if (count == 1)
            await RedisDb.KeyExpireAsync(key, TimeSpan.FromSeconds(windowSeconds));

        return count > limit;
    }
}
