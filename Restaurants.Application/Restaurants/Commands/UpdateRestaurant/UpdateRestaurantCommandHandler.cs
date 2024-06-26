using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Commands.CreateRestaurant;
using Restaurants.Domain.Constants;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Interfaces;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Commands.UpdateRestaurant
{
    public class UpdateRestaurantCommandHandler(ILogger<CreateRestaurantCommandHandler> _logger,
       IRestaurantsRepository _restaurantsRepository, IMapper _mapper,
       IRestaurantAuthoirzationService _restaurantAuthoirzationService) : IRequestHandler<UpdateRestaurantCommand>
    {
        public async Task Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Updating restaurant with id: {RestaurantId}", request.RestaurantId);

            var restaurant = await _restaurantsRepository.GetByIdAsync(request.RestaurantId);

            if (restaurant is null)
            {
                throw new NotFoundException(nameof(Restaurant), request.RestaurantId.ToString());
            }

            if (!_restaurantAuthoirzationService.Authorize(restaurant, ResourceOperation.Update))
            {
                throw new ForbidException();
            }

            _mapper.Map(request, restaurant);

            await _restaurantsRepository.SaveChangesAsync();
        }
    }
}
