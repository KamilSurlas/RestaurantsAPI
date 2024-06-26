using Restaurants.Domain.Entities;
using Restaurants.Domain.Constants;
namespace Restaurants.Domain.Interfaces
{
    public interface IRestaurantAuthoirzationService
    {
        bool Authorize(Restaurant restaurant, ResourceOperation resourceOperation);
    }
}