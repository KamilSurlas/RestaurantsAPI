using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Commands.CreateRestaurant;
using Restaurants.Domain.Constants;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Interfaces;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Commands.DeleteRestaurant
{
    public class DeleteRestaurantCommandHandler(ILogger<CreateRestaurantCommandHandler> _logger,
       IRestaurantsRepository _restaurantsRepository,
       IRestaurantAuthoirzationService _restaurantAuthoirzationService) : IRequestHandler<DeleteRestaurantCommand>
    {
        public async Task Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
        {
            _logger.LogWarning("Deleting restaurant with id: {RestaurantId}",request.Id);

            var restaurant = await _restaurantsRepository.GetByIdAsync(request.Id);

            if(restaurant is null)
            {
                throw new NotFoundException(nameof(Restaurant),request.Id.ToString());
            }

            if (!_restaurantAuthoirzationService.Authorize(restaurant,ResourceOperation.Delete))
            {
                throw new ForbidException();
            }

            await _restaurantsRepository.Delete(restaurant);
        }
    }
}
