using DomainLayer.Pool;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elite_Hotel.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IServicePool _servicePool;
        public CategoryController( IServicePool servicePool)
        {

            _servicePool = servicePool;
        }
        public IActionResult Index()
        {
            var item = _servicePool.CategoryService.GetAll();
            return View(item);
        }
    }
}
