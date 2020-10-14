using System.ComponentModel.DataAnnotations;

namespace TravelApi.Models
{
    public class User
    {
        public int UserId { get; set; }
        [Required]
        [StringLength(20)]
        public string Name { get; set; }
    }
}