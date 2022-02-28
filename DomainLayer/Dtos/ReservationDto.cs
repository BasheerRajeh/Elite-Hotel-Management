using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DomainLayer.Dtos
{
    public class ReservationDto
    {
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
    }
}
