using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled. If
// you have enabled NRTs for your project, then un-comment the following line: #nullable disable

namespace Elite.AppDbContext
{
    public partial class Location
    {
        public Location()
        {
            Hotel = new HashSet<Hotel>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required]
        public decimal? Latitude { get; set; }

        [Required]
        public decimal? Longitude { get; set; }

        public bool? SoftDel { get; set; }

        public virtual ICollection<Hotel> Hotel { get; set; }
    }
}