using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled. If
// you have enabled NRTs for your project, then un-comment the following line: #nullable disable

namespace Elite.AppDbContext
{
    public partial class HotelImage
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Hotel")]
        public int HotelId { get; set; }

        [Required]
        [Display(Name = "File Name")]
        public string FileName { get; set; }

        public bool? SoftDel { get; set; }

        public virtual Hotel Hotel { get; set; }
    }
}