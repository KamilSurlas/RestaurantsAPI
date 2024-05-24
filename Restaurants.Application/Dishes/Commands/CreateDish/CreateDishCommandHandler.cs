using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Dishes.Commands.CreateDish
{
    public class CreateDishCommandHandler(ILogger<CreateDishCommandHandler> _logger
        ,IRestaurantsRepository _restaurantsRepository
        ,IDishesRepository _dishesRepository
        ,IMapper _mapper) : IRequestHandler<CreateDishCommand,int>
    {
        public async Task<int> Handle(CreateDishCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Creating new dish: {@DishRequest}", request);
            var restaurant = await _restaurantsRepository.GetByIdAsync(request.RestaurantId);
            if (restaurant is null) 
            {
                throw new NotFoundException(nameof(Restaurant), request.RestaurantId.ToString());
            }
            var dish = _mapper.Map<Dish>(request);
            return await _dishesRepository.Create(dish);


        }
    }
}
