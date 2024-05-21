using AutoMapper;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants
{
    internal class RestaurantsService(IRestaurantsRepository _restaurantRepository, 
        ILogger<RestaurantsService> _logger, IMapper _mapper) : IRestaurantsService
    {
        public async Task<int> Create(CreateRestaurantDto dto)
        {
            _logger.LogInformation("Creating a new restaurant");

            var restaurant = _mapper.Map<Restaurant>(dto);

            int id = await _restaurantRepository.Create(restaurant);

            return id;

        }

        public async Task<IEnumerable<RestaurantDto>> GetAllRestaurants()
        {
            _logger.LogInformation("Restaurants get");
            var restaurants = await _restaurantRepository.GetAllAsync();
            var restaurantsDtos = _mapper.Map<IEnumerable<RestaurantDto>>(restaurants);
            return restaurantsDtos;
        }

        public async Task<RestaurantDto?> GetById(int restaurantId)
        {
            _logger.LogInformation($"Getting restauirant with Id: {restaurantId}");
            var restaurant = await _restaurantRepository.GetByIdAsync(restaurantId);
            var restaurantDto = _mapper.Map<RestaurantDto>(restaurant);
            return restaurantDto;
        }
    }
}
