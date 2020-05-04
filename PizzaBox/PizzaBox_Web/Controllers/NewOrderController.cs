using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PizzaBox_Lib.Interfaces;
using PizzaBox_Web.Models;

namespace PizzaBox_Web.Controllers
{
    public class NewOrderController : Controller
    {
        private readonly IPizzaBoxRepository _repository;
        private OrderViewModel OVM = new OrderViewModel();

        public NewOrderController(IPizzaBoxRepository repository) 
        {
            _repository = repository;
        }

        public IActionResult Index([FromBody] OrderViewModel ovm)
        {
            OVM.Stores = from s in _repository.GetStores()
                          select new Stores()
                          {
                              id = s.Id,
                              StoreAddress = s.StoreAddress
                          };

            return View(OVM);
        }
    }
}