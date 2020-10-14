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
            
        }
    }
}