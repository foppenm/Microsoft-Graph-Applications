using GraphApplications.Core.Exceptions;
using GraphApplications.Core.Interfaces;
using System.Collections.Generic;

namespace GraphApplications.Infrastructure
{
    /// <summary>
    /// A simple in memory cache
    /// </summary>
    public class CachingService : ICachingService
    {
        private readonly Dictionary<string, string> _cache = new Dictionary<string, string>();

        public string Get(string key)
        {
            if (!_cache.ContainsKey(key))
                throw new CacheNotFoundException($"No cache object found for key: {key}");

            return _cache[key];
        }

        public void Store(string key, string value)
        {
            if (_cache.ContainsKey(key))
                _cache[key] = value;
            else
                _cache.Add(key, value);
        }

        public void Remove(string key)
        {
            if(!_cache.ContainsKey(key))
                throw new CacheNotFoundException($"No cache object found for key: {key}");

            _cache.Remove(key);
        }
    }
}