using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MockPizzaStore.Models;
using PizzaBox_Lib.Interfaces;

namespace MockPizzaStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IPizzaBoxRepository _repository;
        private int Items { get; set; }

        //[TempData]
        public OrderViewModel Cart { get; set; }

        public HomeController(ILogger<HomeController> logger, IPizzaBoxRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public IActionResult Index()
        {
           // Items = 0;

            Cart = new OrderViewModel()
            {
                StoreId = null,
                Total = 0
            };

            //serialize using a custom extension method that calls a json serializer
            TempData.Put("Cart", Cart);

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
