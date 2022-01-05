using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled. If
// you have enabled NRTs for your project, then un-comment the following line: #nullable disable

namespace Elite.AppDbContext
{
    public partial class SpecialService
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Service Category")]
        public int ServiceCatId { get; set; }

        [Required]
        [Display(Name = "Reservation")]
        public int ReservationId { get; set; }

        public bool? SoftDel { get; set; }

        public virtual Reservation Reservation { get; set; }
        public virtual ServiceCat ServiceCat { get; set; }
    }
}