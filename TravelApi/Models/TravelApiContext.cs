using Microsoft.EntityFrameworkCore;

namespace TravelApi.Models
{
    public class TravelApiContext : DbContext
    {
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<User> Users { get; set; }

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
            builder.Entity<Review>()
                .HasData(
                new Review { ReviewId = 1, ReviewScore = 10, ReviewText = "Wonderful city, a lot to do and see!", CityId = 3, UserName = "Kurokeh"},
                new Review { ReviewId = 2, ReviewScore = 5, ReviewText = "Okay but it smelled like weed everywhere", CityId = 1, UserName = "Bmead"},
                new Review { ReviewId = 3, ReviewScore = 7, ReviewText = "Lovely city, some of the people weren't nice though", CityId = 5, UserName = "Bmead"}
            );
        }
    }
}