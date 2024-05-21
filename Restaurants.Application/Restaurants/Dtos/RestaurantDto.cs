using Restaurants.Application.Dishes.Dtos;
using Restaurants.Domain.Constants;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.Restaurants.Dtos
{
    public class RestaurantDto
    {

        public int RestaurantId { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public Category Category { get; set; }
        public bool HasDelivery { get; set; } = default!;
        public string ContactEmail { get; set; } = default!;
        public string ContactNumber { get; set; } = default!;
        public string City { get; set; } = default!;
        public string Street { get; set; } = default!;
        public string PostalCode { get; set; } = default!;
        public List<DishDto> Dishes { get; set; } = [];
    }
}
