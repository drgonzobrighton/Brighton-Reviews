using System.ComponentModel.DataAnnotations;

namespace BrightonReviews.Models
{
    public class VenueType
    {
        public int Id { get; set; }

        [Required]
        public string Cathegory { get; set; }
    }
}