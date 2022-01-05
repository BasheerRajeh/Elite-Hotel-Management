using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled. If
// you have enabled NRTs for your project, then un-comment the following line: #nullable disable

namespace Elite.AppDbContext
{
    public partial class RoomStatus
    {
        public RoomStatus()
        {
            Room = new HashSet<Room>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Status Name")]
        public string Name { get; set; }

        public string Value { get; set; }
        public bool? SoftDel { get; set; }

        public virtual ICollection<Room> Room { get; set; }
    }
}