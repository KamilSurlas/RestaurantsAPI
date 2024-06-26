﻿using Restaurants.Domain.Entities;

namespace Restaurants.Domain.Repositories
{
    public interface IDishesRepository
    {
        Task<int> Create(Dish entity);
        Task DeleteAll(IEnumerable<Dish> entities);
        Task Delete(Dish entity);
        Task<Dish?> GetDishByIdForRestaurant(int restaurantId, int dishId);
    }
}
