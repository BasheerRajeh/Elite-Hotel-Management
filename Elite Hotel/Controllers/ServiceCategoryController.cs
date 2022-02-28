using DomainLayer.Pool;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elite_Hotel.Controllers
{
    public class ServiceCategoryController : Controller
    {
        private readonly IServicePool _servicePool;
        public ServiceCategoryController(IServicePool servicePool)
        {

            _servicePool = servicePool;
        }
        public IActionResult Index()
        {
            var item = _servicePool.ServiceCatService.GetAll();
            return View(item);
        }
    }
}
