using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Restaurants;
using Restaurants.Application.Restaurants.Dtos;


namespace Restaurants.API.Controllers
{
    [ApiController]
    [Route("api/restaurants")]
    public class RestaurantsController(IRestaurantsService _restaurantsService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var restaurants = await _restaurantsService.GetAllRestaurants();
            return Ok(restaurants);
        }
        [HttpGet("{restaurantId}")]
        public async Task<IActionResult> GetById([FromRoute] int restaurantId)
        {
            var restaurant = await _restaurantsService.GetById(restaurantId);
            return Ok(restaurant);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateRestaurantDto createRestaurantDto)
        {
            int id = await _restaurantsService.Create(createRestaurantDto);
            return CreatedAtAction(nameof(GetById), new { id }, null);
        }
    }
}
