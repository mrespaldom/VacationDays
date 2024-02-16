using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VacationsDays.Models;
using System.Collections.Generic;

namespace VacationsDays.Controllers
{


    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {

            return View();

        }


    }
    
}
