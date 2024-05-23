using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Commands.CreateRestaurant;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Commands.UpdateRestaurant
{
    public class UpdateRestaurantCommandHandler(ILogger<CreateRestaurantCommandHandler> _logger,
       IRestaurantsRepository _restaurantsRepository, IMapper _mapper) : IRequestHandler<UpdateRestaurantCommand>
    {
        public async Task Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Updating restaurant with id: {RestaurantId}", request.Id);

            var restaurant = await _restaurantsRepository.GetByIdAsync(request.Id);

            if (restaurant is null)
            {
                throw new NotFoundException(nameof(Restaurant), request.Id.ToString());
            }

            _mapper.Map(request, restaurant);

            await _restaurantsRepository.SaveChangesAsync();
        }
    }
}
