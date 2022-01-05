using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled. If
// you have enabled NRTs for your project, then un-comment the following line: #nullable disable

namespace Elite.AppDbContext
{
    public partial class Hotel
    {
        public Hotel()
        {
            Room = new HashSet<Room>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Hotel Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "City")]
        public string City { get; set; }

        public bool? SoftDel { get; set; }

        [DataType(DataType.ImageUrl)]
        [Display(Name = "Image")]
        public string ImageUrl { get; set; }

        public virtual ICollection<Room> Room { get; set; }
    }
}