using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MockPizzaStore.Models;
using PizzaBox_Lib.Interfaces;

namespace MockPizzaStore.Controllers
{
    public class MenuController : Controller
    {
        private IPizzaBoxRepository _repository;
        public OrderViewModel customerOrder = new OrderViewModel()
        {
            Total = 0
        };
        public int Items { get; set; }

        public MenuController(IPizzaBoxRepository repository) 
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            Items = 1;
            TempData["Cart"] = Items+ " item in your cart";

            string store = "some store";
            //string store = "";

            if (store == "")
            {
                return RedirectToAction("Index", "Store");
            }
            else
            {
                var pizzas = _repository.GetOurPizzas();

                foreach (var pizza in pizzas)
                {
                    customerOrder.pizzas.Add(pizza);
                }

                return View(customerOrder);
            }
        }
    }
}