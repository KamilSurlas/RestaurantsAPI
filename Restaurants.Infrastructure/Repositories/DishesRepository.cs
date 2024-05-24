using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Persistance;

namespace Restaurants.Infrastructure.Repositories
{
    internal class DishesRepository(RestaurantsDbContext _dbContext) : IDishesRepository
    {
        public async Task<int> Create(Dish entity)
        {
            _dbContext.Dishes.Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity.DishId;
        }

        public async Task Delete(Dish entity)
        {
           _dbContext.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAll(IEnumerable<Dish> entities)
        {
            _dbContext.RemoveRange(entities);
            await _dbContext.SaveChangesAsync();
        }
    }
}
