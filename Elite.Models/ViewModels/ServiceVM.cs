using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Elite.AppDbContext.ViewModels
{
    public class ServiceVM
    {
        public Service Service { get; set; }

        public IEnumerable<SelectListItem> ServiceCatList { get; set; }
    }
}