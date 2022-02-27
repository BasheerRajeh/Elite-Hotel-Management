using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DomainLayer.Dtos
{
    public class CategoryDto
    {
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

    }
}