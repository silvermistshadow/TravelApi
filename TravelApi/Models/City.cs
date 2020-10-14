using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace TravelApi.Models
{
  public class City
  {
      public int CityId { get; set; }
      [Required]
      [StringLength(20)]
      public string Name { get; set; }
      public int CountryId { get; set; }
      public virtual Country Country { get; set; }
      public virtual ICollection<Review> Reviews { get; set; }

      public City()
      {
        this.Reviews = new HashSet<Review>();
      }
  }
}