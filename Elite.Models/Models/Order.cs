using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled. If
// you have enabled NRTs for your project, then un-comment the following line: #nullable disable

namespace Elite.AppDbContext
{
    public partial class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Order Number")]
        public string OrderNum { get; set; }

        [Required]
        [Display(Name = "Reservation")]
        public int ReservationId { get; set; }

        [Required]
        [Display(Name = "Food Item")]
        public int FoodItemId { get; set; }

        [Required]
        public DateTime Time { get; set; }

        [Required]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }

        public bool? SoftDel { get; set; }

        public virtual FoodItem FoodItem { get; set; }
        public virtual Reservation Reservation { get; set; }
    }
}