using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace TravelApi.Models
{
  public class Country
  {
      public int CountryId { get; set; }
      [Required]
      [StringLength(20)]
      public string Name { get; set; }
      public virtual ICollection<City> Cities { get; set; }

      public Country()
      {
        this.Cities = new HashSet<City>();
      }
  }
}