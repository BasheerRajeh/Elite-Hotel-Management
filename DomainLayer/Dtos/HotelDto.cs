using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DomainLayer.Dtos
{
    public class HotelDto
    {
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
    }
}
