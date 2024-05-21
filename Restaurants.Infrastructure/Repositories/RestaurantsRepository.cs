using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Infrastructure.Repositories
{
    internal class RestaurantsRepository(RestaurantsDbContext _dbContext) : IRestaurantsRepository
    {
        public async Task<int> Create(Restaurant entity)
        {
            _dbContext.Restaurants.Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity.RestaurantId;
        }

        public async Task<IEnumerable<Restaurant>> GetAllAsync()
        {
            var restaurants =await _dbContext.Restaurants.Include(r=>r.Dishes).ToListAsync();
            return restaurants;
        }

        public async Task<Restaurant?> GetByIdAsync(int restaurantId)
        {
            var restaurant = await _dbContext.Restaurants
                .Include(r=>r.Dishes).FirstOrDefaultAsync(r => r.RestaurantId == restaurantId);
            return restaurant;
        }
    }
}
