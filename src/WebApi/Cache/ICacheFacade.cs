using System;
using System.Threading.Tasks;

namespace WebApi.Cache
{
    public interface ICacheFacade
    {
        Task<string> GetAsync(string key);
        Task StoreAsync(string key, object value, TimeSpan timeSpan);
    }
}