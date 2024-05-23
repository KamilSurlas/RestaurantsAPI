using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Commands.CreateRestaurant;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Commands.DeleteRestaurant
{
    public class DeleteRestaurantCommandHandler(ILogger<CreateRestaurantCommandHandler> _logger,
       IRestaurantsRepository _restaurantsRepository) : IRequestHandler<DeleteRestaurantCommand>
    {
        public async Task Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Deleting restaurant with id: {RestaurantId}",request.Id);

            var restaurant = await _restaurantsRepository.GetByIdAsync(request.Id);

            if(restaurant is null)
            {
                throw new NotFoundException(nameof(Restaurant),request.Id.ToString());
            }

            await _restaurantsRepository.Delete(restaurant);
        }
    }
}
