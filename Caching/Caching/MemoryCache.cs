using System;
using System.Collections.Concurrent;
using System.ComponentModel;

namespace Caching
{
    public class MemoryCache
    {
        private readonly ConcurrentDictionary<string, object> _cacheStorage = new ConcurrentDictionary<string, object>();
        public TResult AddOrExecute<TResult>(string keyName, Func<TResult> methodToExecute) where TResult : class
        {
            var result = _cacheStorage.GetOrAdd(keyName, methodToExecute);
            return result as TResult;
        }
    }
}
