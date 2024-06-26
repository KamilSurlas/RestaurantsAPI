﻿using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Dishes.Commands.DeleteDish;
using Restaurants.Application.Dishes.Commands.DeleteDishes;
using Restaurants.Domain.Constants;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Interfaces;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Dishes.Commands.UpdateDish
{
    public class UpdateDishCommandHandler(ILogger<DeleteDishesForRestaurantCommandHandler> _logger,
        IRestaurantsRepository _restaurantsRepository,
        IDishesRepository _dishesRepository,IMapper _mapper,
        IRestaurantAuthoirzationService _restaurantAuthoirzationService) : IRequestHandler<UpdateDishCommand>
    {
        public async Task Handle(UpdateDishCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Updating dish with id: {DishId} for restaurant with id: {RestaurantId}",
                request.DishId,
                request.RestaurantId);

            var restaurant = await _restaurantsRepository.GetByIdAsync(request.RestaurantId);

            if (restaurant is null)
            {
                throw new NotFoundException(nameof(Restaurant), request.RestaurantId.ToString());
            }

            var dish = await _dishesRepository.GetDishByIdForRestaurant(request.RestaurantId, request.DishId);

            if (dish is null)
            {
                throw new NotFoundException(nameof(Dish), request.DishId.ToString());
            }

            if (!_restaurantAuthoirzationService.Authorize(restaurant, ResourceOperation.Update))
            {
                throw new ForbidException();
            }

            _mapper.Map(request, dish);

            await _restaurantsRepository.SaveChangesAsync();
        }
    }
}
