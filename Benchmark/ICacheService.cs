using System.Collections.Frozen;

namespace Benchmark;

public interface ICacheService<in TKey, out TValue>
{
    TValue? GetItem(TKey key);
}

public class VanillaUserCache : ICacheService<int, User>
{
    private readonly Dictionary<int, User> _usersCache;
    
    public VanillaUserCache()
    {
        _usersCache = new Dictionary<int, User> { { 1, new User(1, "Ernesto Chihuahua", 39) } };
    }
    
    public User? GetItem(int key)
    {
        return _usersCache.TryGetValue(key, out var user) ? user : null;
    }
}

public class PerformantUserCache : ICacheService<int, User>
{
    private readonly FrozenDictionary<int, User> _usersCache;

    public PerformantUserCache()
    {
        var src = new Dictionary<int, User> { { 1, new User(1, "John Bumbaloomp", 23) } };
        _usersCache = src.ToFrozenDictionary();
    }
    
    public User? GetItem(int key)
    {
        return _usersCache.TryGetValue(key, out var user) ? user : null;
    }
}