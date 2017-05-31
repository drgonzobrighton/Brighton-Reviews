using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BrightonReviews.Models
{
    public class Review
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string ReviewTitle { get; set; }

        [Required]
        [Range(1,5)]
        public int Rating { get; set; }

        [Required]
        [Display(Name = "Review")]
        public string ReviewBody { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string ReviewerName { get; set; }

        public int VenueId { get; set; }
    }
}