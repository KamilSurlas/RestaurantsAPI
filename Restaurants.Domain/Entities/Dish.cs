using System.ComponentModel.DataAnnotations;

namespace Restaurants.Domain.Entities
{
    public class Dish
    {
        [Key]
        public int DishId { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public decimal Price { get; set; }
        public int KiloCalories { get; set; }
        public int RestaurantId { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }
}