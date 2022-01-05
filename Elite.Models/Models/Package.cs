using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled. If
// you have enabled NRTs for your project, then un-comment the following line: #nullable disable

namespace Elite.AppDbContext
{
    public partial class Package
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Package Name")]
        public string Name { get; set; }

        public int RoomId { get; set; }
        public int FeatureId { get; set; }
        public bool? SoftDel { get; set; }

        public virtual Feature Feature { get; set; }
        public virtual Room Room { get; set; }
    }
}