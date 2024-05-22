using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Queries.GetAllRestaurants
{
    public class GetAllRestaurantsQueryHandler(ILogger<GetAllRestaurantsQueryHandler> _logger,
        IMapper _mapper, IRestaurantsRepository _restaurantsRepository) : IRequestHandler<GetAllRestaurantsQuery, IEnumerable<RestaurantDto>>
    {
        public async Task<IEnumerable<RestaurantDto>> Handle(GetAllRestaurantsQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Restaurants get");
            var restaurants = await _restaurantsRepository.GetAllAsync();
            var restaurantsDtos = _mapper.Map<IEnumerable<RestaurantDto>>(restaurants);
            return restaurantsDtos;
        }
    }
}
