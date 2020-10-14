using System.ComponentModel.DataAnnotations;

namespace TravelApi.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        [Required]
        [Range(1, 10, ErrorMessage = "Review score must be between 1 and 10.")]
        public int ReviewScore { get; set; }
        public string UserName { get; set; }
    }
}