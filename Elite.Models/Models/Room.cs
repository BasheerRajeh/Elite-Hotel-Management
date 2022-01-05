using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled. If
// you have enabled NRTs for your project, then un-comment the following line: #nullable disable

namespace Elite.AppDbContext
{
    public partial class Room
    {
        public Room()
        {
            Package = new HashSet<Package>();
            Reservation = new HashSet<Reservation>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Room Number")]
        public string Num { get; set; }

        [Required]
        [Display(Name = "Hotel")]
        public int HotelId { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [Required]
        [Display(Name = "Status")]
        public int RoomStatusId { get; set; }

        [DataType(DataType.ImageUrl)]
        [Display(Name = "Image")]
        public string ImageUrl { get; set; }

        public bool? SoftDel { get; set; }

        public virtual Category Category { get; set; }
        public virtual Hotel Hotel { get; set; }
        public virtual RoomStatus RoomStatus { get; set; }
        public virtual ICollection<Package> Package { get; set; }
        public virtual ICollection<Reservation> Reservation { get; set; }
    }
}