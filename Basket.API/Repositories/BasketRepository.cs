﻿using Basket.API.Entities;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace Basket.API.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDistributedCache _redisCache;

        public BasketRepository(IDistributedCache redisCache)
        {
            _redisCache = redisCache;
        }       

        public async Task<ShoppingCart?> GetBasket(string userName)
        {
           var result = await _redisCache.GetStringAsync(userName);

            if (String.IsNullOrEmpty(result))
            {
                return null;
            }
            return JsonSerializer.Deserialize<ShoppingCart>(result);
        }

        public async Task<ShoppingCart?> UpdateBasket(ShoppingCart basket)
        {
           await _redisCache.SetStringAsync(basket.UserName, JsonSerializer.Serialize(basket));

           return await GetBasket(basket.UserName);
        }

        public async Task DeleteBasket(string userName)
        {
           await _redisCache.RemoveAsync(userName);
        }
    }
}
