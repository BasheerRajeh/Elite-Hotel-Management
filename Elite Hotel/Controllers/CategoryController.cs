using DomainLayer.Pool;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Elite.AppDbContext;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Elite_Hotel.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IServicePool _servicePool;
        private readonly HotelContext _context;
        public CategoryController(IServicePool servicePool, HotelContext context)
        {

            _servicePool = servicePool;
            _context = context;
        }
        public IActionResult Index()
        {
            var item = _servicePool.CategoryService.GetAll();
            return View(item);
        }
        public IActionResult Showcat(int id)
        {
            ViewModel model = new ViewModel();
            model.Categories = _servicePool.CategoryService.GetAll(model => model.Id == id);
            model.Servicecats = _servicePool.ServiceCatService.GetAll(model => model.CategoryId == id);
            return View(model);
        }

    }
}
