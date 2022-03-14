using Elite.AppDbContext;
using Elite.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Elite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ServiceReference.WeatherServiceClient weatherService;

        public HomeController(ILogger<HomeController> logger, ServiceReference.WeatherServiceClient service)
        {
            weatherService = service;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var so = weatherService.GetWeather(SD.APIKEY, "34.32132", "34.3213");

            var weather = so.Result;
            dynamic s = JObject.Parse(weather);
            ViewBag.Main = (string)(s.weather[0].main);
            ViewBag.Description = (string)(s.weather[0].description);

            var fjdslk = "fjdsl";
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

        public IActionResult ChangeLanguage(string culture)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions() { Expires = DateTimeOffset.UtcNow.AddYears(1) });

            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}