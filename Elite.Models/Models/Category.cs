using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled. If
// you have enabled NRTs for your project, then un-comment the following line: #nullable disable

namespace Elite.AppDbContext
{
    public partial class Category
    {
        public Category()
        {
            Room = new HashSet<Room>();
            ServiceCat = new HashSet<ServiceCat>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Category Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Max Capacity")]
        public int MaxCap { get; set; }

        [Required]
        [Display(Name = "Price Per Night")]
        public decimal PricePerNight { get; set; }

        [DataType(DataType.ImageUrl)]
        [Display(Name = "Image")]
        public string ImageUrl { get; set; }

        public bool? SoftDel { get; set; }

        public virtual ICollection<Room> Room { get; set; }
        public virtual ICollection<ServiceCat> ServiceCat { get; set; }
    }
}