using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled. If
// you have enabled NRTs for your project, then un-comment the following line: #nullable disable

namespace Elite.AppDbContext
{
    public partial class Service
    {
        public Service()
        {
            //ServiceCat = new HashSet<ServiceCat>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Service Name")]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [DataType(DataType.ImageUrl)]
        [Display(Name = "Image")]
        public string ImageUrl { get; set; }

        public int ServiceCatId { get; set; }

        public bool? SoftDel { get; set; }

        public virtual ServiceCat ServiceCat { get; set; }
    }
}