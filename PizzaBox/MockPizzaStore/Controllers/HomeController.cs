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
        public OrderViewModel customerOrder = new OrderViewModel()
        {
            Total = 0
        };

        public HomeController(ILogger<HomeController> logger, IPizzaBoxRepository repository)
        {
            _logger = logger;

            _repository = repository;
        }

        public IActionResult Index()
        {
            var pizzas = _repository.GetOurPizzas();
            //ViewBag.stores = _repository.GetStores();
            TempData["pizzas"] = "MyTemp";
            ViewBag.test = "MyViewBag";

            var stores = _repository.GetStores();

            foreach (var pizza in pizzas) 
            {
                customerOrder.pizzas.Add(pizza);
            }

            return View(customerOrder);
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
