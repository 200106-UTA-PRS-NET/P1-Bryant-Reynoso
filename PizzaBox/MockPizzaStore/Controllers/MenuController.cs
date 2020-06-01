using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MockPizzaStore.Models;
using Newtonsoft.Json;
using PizzaBox_Lib.Interfaces;
using PizzaBox_Lib.Models;

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

        [HttpGet]
        public IActionResult Index()
        {
            TempData["Store"] = "s";

            //if tempdata["store"] is empty then redirect back to store page,
            //if not display menu
            if (TempData["Store"].ToString() == "")
            {
                return RedirectToAction("Index", "Store");
            }
            else
            {
                var model = new PizzaFormViewModel()
                {
                    Pizzas = _repository.GetOurPizzas().ToList(),
                    PanSizes = from p in _repository.GetPanSizes()
                               select new SelectListItem(p.Size, p.Size),
                    CrustTypes = from c in _repository.GetCrustTypes()
                                 select new SelectListItem(c.CrustName, c.CrustName)
                };
                                
                return View(model);
            }
        }

        //Form submission action
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Index(PizzaFormViewModel Form)
        {
            //deserialize using a custom extension method that calls a json deserializer
            var Order = TempData.Peek<OrderViewModel>("Cart");

            //add pizza retrieved from pizza form to list
            Order.Pizzas.Add(new Pizza()
            {
                PizzaName = Form.PizzaName,
                CrustType = Form.SelectedCrustType,
                PanSize = Form.SelectedPanSize
            });

            TempData.Put("Cart",Order);
  
            return Content(
                $"You have added a '{Form.SelectedPanSize} {Form.SelectedCrustType} {Form.PizzaName}' to your cart," +
                $"\nYour pizzas: {TempData.Peek("Cart")}"
                );
        }
    }
}