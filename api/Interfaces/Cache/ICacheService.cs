using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace api.Interfaces.Cache
{
    public interface ICacheService
    {
        Task<T?> GetFromHashTableAsync<T>(string hashKey, string field);

        Task RemoveFromHashTableAsync(string hashKey, string field);

        Task SetToHashTableAsync<T>(string hashKey, string field, T value);

        Task<HashEntry[]> GetAllFromHashTableAsync(string hashKey);
    }
}