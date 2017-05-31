using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BrightonReviews.Models
{
    public class Venue
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Display(Name = "Image URL")]
        [Required]
        public string ImgURL { get; set; }

        [Display(Name = "Venue Type")]
        public VenueType VenueType { get; set; }

        [Display(Name = "Venue Type")]
        public int VenueTypeId { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]      
        public string Description { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
    }

}