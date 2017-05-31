using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BrightonReviews.Models
{
    public class VenueViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImgURL { get; set; }

        public VenueType VenueType { get; set; }

        public int VenueTypeId { get; set; }

        public string Address { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }

        public double? AvarageScore { get; set; }

        public int? ReviewCount { get; set; }
    }
}