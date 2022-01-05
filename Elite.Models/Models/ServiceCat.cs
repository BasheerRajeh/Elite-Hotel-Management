using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled. If
// you have enabled NRTs for your project, then un-comment the following line: #nullable disable

namespace Elite.AppDbContext
{
    public partial class ServiceCat
    {
        public ServiceCat()
        {
            SpecialService = new HashSet<SpecialService>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Category Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Service")]
        public int ServiceId { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public bool? SoftDel { get; set; }

        public virtual Category Category { get; set; }
        public virtual Service Service { get; set; }
        public virtual ICollection<SpecialService> SpecialService { get; set; }
    }
}