using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled. If
// you have enabled NRTs for your project, then un-comment the following line: #nullable disable

namespace Elite.AppDbContext
{
    public partial class Reservation
    {
        public Reservation()
        {
            Order = new HashSet<Order>();
            SpecialService = new HashSet<SpecialService>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Reservation Number")]
        public string ReservationNum { get; set; }

        [Required]
        [Display(Name = "Status")]
        public int RequestStatusId { get; set; }

        [Required]
        [Display(Name = "Customer")]
        public string CustomerId { get; set; }

        [Required]
        [Display(Name = "Room")]
        public int RoomId { get; set; }

        [Required]
        public decimal Checkout { get; set; }

        [Required]
        public DateTime RequestDate { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }
        public bool? SoftDel { get; set; }

        public virtual Room Room { get; set; }
        public virtual ICollection<Order> Order { get; set; }
        public virtual ICollection<SpecialService> SpecialService { get; set; }
    }
}