using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled. If
// you have enabled NRTs for your project, then un-comment the following line: #nullable disable

namespace Elite.AppDbContext
{
    public partial class FoodItem
    {
        public FoodItem()
        {
            Order = new HashSet<Order>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Item Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Item Price")]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "Feed")]
        public int FeedNum { get; set; }

        public int FoodCatId { get; set; }

        [Display(Name = "Details")]
        public string Detail { get; set; }

        public bool? SoftDel { get; set; }

        public virtual FoodCat FoodCat { get; set; }
        public virtual ICollection<Order> Order { get; set; }
    }
}