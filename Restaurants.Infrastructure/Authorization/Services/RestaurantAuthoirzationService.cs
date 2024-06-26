using Microsoft.Extensions.Logging;
using Restaurants.Application.Users;
using Restaurants.Domain.Constants;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Interfaces;

namespace Restaurants.Infrastructure.Authorization.Services
{
    public class RestaurantAuthoirzationService(ILogger<RestaurantAuthoirzationService> _logger,
        IUserContext _userContext) : IRestaurantAuthoirzationService
    {
        public bool Authorize(Restaurant restaurant, ResourceOperation resourceOperation)
        {
            var user = _userContext.GetCurrentUser();

            _logger.LogInformation("Authorizing user [{UserEmail}], to {Operation} for restaurant {RestaurantName}",
                user.Email,
                resourceOperation,
                restaurant.Name);

            if (resourceOperation == ResourceOperation.Create || resourceOperation == ResourceOperation.Read)
            {
                _logger.LogInformation("Create/Read operation - authorization successful");
                return true;
            }
            if (resourceOperation == ResourceOperation.Delete && user.IsInRole(UserRoles.Admin))
            {
                _logger.LogInformation("Admin user, {Operation} - authorization successful ", resourceOperation);
                return true;
            }
            if ((resourceOperation == ResourceOperation.Delete || resourceOperation == ResourceOperation.Update)
                && user.Id == restaurant.OwnerId)
            {
                _logger.LogInformation("Restaurant owner, {Operation} - authorization successful ", resourceOperation);
                return true;
            }

            return false;
        }
    }
}
