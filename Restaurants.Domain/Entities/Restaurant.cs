namespace Restaurants.Domain.Entities
{
    public class Restaurant
    {
        public int RestaurantId { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Category { get; set; } = default!;
        public bool HasDelivery { get; set; } = default!;
        public string ContactEmail { get; set; } = default!;
        public string ContactNumber { get; set; } = default!;
        public Address Address { get; set; } = default!;
        public List<Dish> Dishes { get; set; } = new();

    }
}
