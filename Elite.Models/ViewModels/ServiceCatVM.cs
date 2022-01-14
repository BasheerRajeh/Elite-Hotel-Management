using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Elite.AppDbContext.ViewModels
{
    public class ServiceCatVM
    {
        public ServiceCat ServiceCat { get; set; }

        public IEnumerable<SelectListItem> CategoryList { get; set; }
    }
}