using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Restaurants.Commands.CreateRestaurant;
using Restaurants.Application.Restaurants.Commands.DeleteRestaurant;
using Restaurants.Application.Restaurants.Commands.UpdateRestaurant;
using Restaurants.Application.Restaurants.Queries.GetAllRestaurants;
using Restaurants.Application.Restaurants.Queries.GetRestaurantById;


namespace Restaurants.API.Controllers
{
    [ApiController]
    [Route("api/restaurants")]
    public class RestaurantsController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var restaurants = await _mediator.Send(new GetAllRestaurantsQuery());
            return Ok(restaurants);
        }
        [HttpGet("{restaurantId}")]
        public async Task<IActionResult> GetById([FromRoute] int restaurantId)
        {
            var restaurant = await _mediator.Send(new GetRestaurantByIdQuery(restaurantId));
            return Ok(restaurant);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateRestaurantCommand command)
        {
            int id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id }, null);
        }
        [HttpDelete("{restaurantId}")]
        public async Task<IActionResult> DeleteById([FromRoute] int restaurantId)
        {
            await _mediator.Send(new DeleteRestaurantCommand(restaurantId));

            return NoContent();
        }
        [HttpPut("{restaurantId}")]
        public async Task<IActionResult> Update([FromRoute] int restaurantId, UpdateRestaurantCommand command)
        {
            command.Id = restaurantId;
            await _mediator.Send(command);


            return NoContent();
        }
    }
}
