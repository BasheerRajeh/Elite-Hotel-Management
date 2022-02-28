using DomainLayer.Pool;
using Elite_Hotel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.IO;

namespace Elite_Hotel.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IServicePool _servicePool;

        public HomeController(ILogger<HomeController> logger,IServicePool servicePool)
        {
           
            _logger = logger;
            _servicePool = servicePool;
        }



        public IActionResult Index()
        {
            var items = _servicePool.CategoryService.GetAll();   
            return View(items);
        }



        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}