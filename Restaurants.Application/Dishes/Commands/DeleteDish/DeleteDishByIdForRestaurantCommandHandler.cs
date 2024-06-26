using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Dishes.Commands.DeleteDishes;
using Restaurants.Application.Dishes.Queries.GetDishByIdForRestaurant;
using Restaurants.Domain.Constants;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Interfaces;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Dishes.Commands.DeleteDish
{
    public class DeleteDishByIdForRestaurantCommandHandler(ILogger<DeleteDishesForRestaurantCommandHandler> _logger,
        IRestaurantsRepository _restaurantsRepository,
        IDishesRepository _dishesRepository,
        IRestaurantAuthoirzationService _restaurantAuthoirzationService) : IRequestHandler<DeleteDishByIdForRestaurantCommand>
    {
        public async Task Handle(DeleteDishByIdForRestaurantCommand request, CancellationToken cancellationToken)
        {
            _logger.LogWarning("Removing dish with id: {DishId} from restaurant with id: {RestaurantId}",request.DishId, request.RestaurantId);
            var restaurant = await _restaurantsRepository.GetByIdAsync(request.RestaurantId);

            if (restaurant is null)
            {
                throw new NotFoundException(nameof(Restaurant), request.RestaurantId.ToString());
            }

            var dish = await _dishesRepository.GetDishByIdForRestaurant(request.RestaurantId,request.DishId);

            if (dish is null)
            {
                throw new NotFoundException(nameof(Dish), request.DishId.ToString());
            }

            if (!_restaurantAuthoirzationService.Authorize(restaurant, ResourceOperation.Update))
            {
                throw new ForbidException();
            }

            await _dishesRepository.Delete(dish);
        }
    }
}
