using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using api.Interfaces.Cache;
using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;
using StackExchange.Redis;

namespace api.Cache
{
    public class CacheService : ICacheService
    {   //Deserialize - превратить строку в объект
        private readonly IDatabase cache;

        private static readonly TimeSpan CacheExpiration = TimeSpan.FromMinutes(10);

        public CacheService(ConnectionMultiplexer connection)
        {
            cache = connection.GetDatabase();
        }
        public async Task<T?> GetFromHashTableAsync<T>(string hashKey, string field)
        {
            var result = await cache.HashGetAsync(hashKey, field);
            if (result.IsNullOrEmpty)
                return default;

            await cache.KeyExpireAsync(hashKey, CacheExpiration);
            return JsonSerializer.Deserialize<T>(result);
        }

        public async Task RemoveFromHashTableAsync(string hashKey, string field)
        {
            await cache.HashDeleteAsync(hashKey, field);
        }

        public async Task SetToHashTableAsync<T>(string hashKey, string field, T value)
        {
            var jsonData = JsonSerializer.Serialize(value);
            await cache.HashSetAsync(hashKey, field, jsonData);
            await cache.KeyExpireAsync(hashKey, CacheExpiration);
        }

        public async Task<HashEntry[]> GetAllFromHashTableAsync(string hashKey)
        {
            var result = await cache.HashGetAllAsync(hashKey);
            if (result.Length == 0 || result is null)
                return default;

            await cache.KeyExpireAsync(hashKey, CacheExpiration);
            return result;
        }
    }
}