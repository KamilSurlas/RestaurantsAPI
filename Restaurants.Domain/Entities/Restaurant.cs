using Restaurants.Domain.Constants;
using System.ComponentModel.DataAnnotations;

namespace Restaurants.Domain.Entities
{
    public class Restaurant
    {
        [Key]
        public int RestaurantId { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public Category Category { get; set; }
        public bool HasDelivery { get; set; } = default!;
        public string ContactEmail { get; set; } = default!;
        public string ContactNumber { get; set; } = default!;
        public Address Address { get; set; } = default!;
        public List<Dish> Dishes { get; set; } = [];
        public User Owner { get; set; } = default!;
        public string OwnerId { get; set; } = default!;

    }
}
