using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.VisualBasic.FileIO;
using Restaurants.Domain.Constants;
using Restaurants.Domain.Entities;
namespace Restaurants.Infrastructure.Persistance
{
    internal class RestaurantsDbContext(DbContextOptions<RestaurantsDbContext> options) : DbContext(options)
    {
        internal DbSet<Restaurant> Restaurants { get; set; }
        internal DbSet<Dish> Dishes { get; set; }
     

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Restaurant>()
                .OwnsOne(r => r.Address);
                
            modelBuilder.Entity<Restaurant>()
                .Property(r => r.Category).HasConversion(new EnumToStringConverter<Category>());
        }
    }
}
