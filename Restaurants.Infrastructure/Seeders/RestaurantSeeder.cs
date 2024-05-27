using Microsoft.AspNetCore.Identity;
using Restaurants.Domain.Constants;
using Restaurants.Domain.Entities;
using Restaurants.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Infrastructure.Seeders
{
    internal class RestaurantSeeder(RestaurantsDbContext dbContext) : IRestaurantSeeder
    {
        public async Task Seed()
        {
            if (await dbContext.Database.CanConnectAsync())
            {
                if (!dbContext.Restaurants.Any())
                {
                    var restaurants = GetRestaurants();
                    dbContext.AddRange(restaurants);
                    await dbContext.SaveChangesAsync();
                }
                if (!dbContext.Roles.Any())
                {
                    var roles = GetRoles();
                    dbContext.Roles.AddRange(roles);
                    await dbContext.SaveChangesAsync();
                }
            }
        }

        private IEnumerable<IdentityRole> GetRoles()
        {
            List<IdentityRole> roles =
                [
                    new(UserRoles.User)
                    {
                        NormalizedName = UserRoles.User.ToUpper()
                    },
                    new(UserRoles.Owner)
                    {
                        NormalizedName = UserRoles.Owner.ToUpper()
                    },
                    new(UserRoles.Admin)
                    {
                        NormalizedName = UserRoles.Admin.ToUpper()
                    },
                ];

            return roles;
        }
        private IEnumerable<Restaurant> GetRestaurants()
        {
            var restaurants = new List<Restaurant>()
            {
                new Restaurant()
                {
                    Name = "BurgersTOP",
                    Category = Category.FastFood,
                    Description = "Best burgers are here. Check it out right now",
                    HasDelivery = true,
                    ContactEmail = "burgers@example.com",
                    ContactNumber = "123 456 789",
                    Address = new Address()
                    {
                        City = "London",
                        Street = "Rose 129",
                        PostalCode ="EC1A 1AL"
                    }
                },
                new Restaurant()
                {
                    Name = "Italiano Pizza",
                    Category = Category.Pizzeria,
                    Description = "Best pizzas are here. Check it out right now",
                    HasDelivery = true,
                    ContactEmail = "pizzas@example.com",
                    ContactNumber = "987 654 321",
                    Address = new Address()
                    {
                        City = "Milan",
                        Street = "Rose 129",
                        PostalCode ="20057"
                    }
                }
            };

            return restaurants;
        }
    }
}
