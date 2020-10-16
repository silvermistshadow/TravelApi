using Microsoft.EntityFrameworkCore;

namespace TravelApi.Models
{
    public class TravelApiContext : DbContext
    {
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<User> Users { get; set; }

        public TravelApiContext(DbContextOptions<TravelApiContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Country>()
                .HasData(
                new Country { CountryId = 1, Name = "Canada" },
                new Country { CountryId = 2, Name = "Japan" },
                new Country { CountryId = 3, Name = "France" },
                new Country { CountryId = 4, Name = "Australia" },
                new Country { CountryId = 5, Name = "UK" }
            );
            builder.Entity<City>()
                .HasData(
                new City { CityId = 1, Name = "Vancouver", CountryId = 1 },
                new City { CityId = 2, Name = "London", CountryId = 5 },
                new City { CityId = 3, Name = "Tokyo", CountryId = 2 },
                new City { CityId = 4, Name = "Sydney", CountryId = 4 },
                new City { CityId = 5, Name = "Paris", CountryId = 3 },
                new City { CityId = 6, Name = "Montreal", CountryId = 1 }
            );
        }
    }
}