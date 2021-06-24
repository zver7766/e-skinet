using System;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Core.Intefraces;
using StackExchange.Redis;

namespace Infrastructure.Data
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDatabase _database;
        public BasketRepository(IConnectionMultiplexer redis)
        {
            _database = redis.GetDatabase();
        }
        public async Task<bool> DeleteBasketAsync(string basketId)
        {
            return await _database.KeyDeleteAsync(basketId);
        }

        public async Task<CustomerBasket> GetBasketAsync(string basketId)
        {
            var data = await _database.StringGetAsync(basketId);

            return data.IsNullOrEmpty ? null : JsonSerializer.Deserialize<CustomerBasket>(data);
        }

        public async Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket)
        {
            var createad = await _database.StringSetAsync(basket.Id,
                JsonSerializer.Serialize(basket), TimeSpan.FromDays(30));

            if (!createad) return null;

            return await GetBasketAsync(basket.Id);


        }
    }
}