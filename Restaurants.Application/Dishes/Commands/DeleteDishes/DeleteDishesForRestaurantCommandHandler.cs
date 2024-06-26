using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Constants;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Interfaces;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Dishes.Commands.DeleteDishes
{
    public class DeleteDishesForRestaurantCommandHandler(ILogger<DeleteDishesForRestaurantCommandHandler> _logger,
        IRestaurantsRepository _restaurantsRepository,
        IDishesRepository _dishesRepository,
        IRestaurantAuthoirzationService _restaurantAuthoirzationService) : IRequestHandler<DeleteDishesForRestaurantCommand>
    {
        public async Task Handle(DeleteDishesForRestaurantCommand request, CancellationToken cancellationToken)
        {
            _logger.LogWarning("Removing all dishes from restaurant wih id: {RestaurantId}", request.RestaurantId);
            var restaurant = await _restaurantsRepository.GetByIdAsync(request.RestaurantId);

            if (restaurant is null)
            {
                throw new NotFoundException(nameof(Restaurant), request.RestaurantId.ToString());
            }

            if (!_restaurantAuthoirzationService.Authorize(restaurant, ResourceOperation.Update))
            {
                throw new ForbidException();
            }

            await _dishesRepository.DeleteAll(restaurant.Dishes);
        }
    }
}
