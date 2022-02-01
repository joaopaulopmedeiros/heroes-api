using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace WebApi.Cache
{
    public class CacheFacade : ICacheFacade
    {
        private readonly IDistributedCache _cache;

        public CacheFacade(IDistributedCache cache)
        {
            _cache = cache; 
        }

        public async Task<string> GetAsync(string key)
        {
            var value = await _cache.GetStringAsync(key);
            return String.IsNullOrEmpty(value) ? null : value;
        }

        public async Task StoreAsync(string key, object value, TimeSpan timeSpan)
        {
            if(value == null) 
            {
                return;
            }

            var serializedValue = JsonConvert.SerializeObject(value);

            await _cache.SetStringAsync(key, serializedValue, new DistributedCacheEntryOptions 
            {
                AbsoluteExpirationRelativeToNow = timeSpan,
            });
        }
    }
}
