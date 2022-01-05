using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Elite.AppDbContext.ViewModels
{
    public class HotelViewModel
    {
        public Hotel Hotel { get; set; }

        public IEnumerable<SelectListItem> LocationList { get; set; }
    }
}