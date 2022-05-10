using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SampleEF.Data;
using SampleEF.Models;

namespace SampleEF.Controllers
{
    public class RestaurantsController : Controller
    {
        private readonly ILogger<RestaurantsController> _logger;
        private readonly IRestaurantData _restaurants;

        public RestaurantsController(ILogger<RestaurantsController> logger,
            IRestaurantData restaurants)
        {
            _logger = logger;
            _restaurants = restaurants;
        }

        public IActionResult Index()
        {
            var model = _restaurants.GetAll();

            ViewData["username"] = "Erick Kurniawan";
            ViewBag.Role = "Admin";
          
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}