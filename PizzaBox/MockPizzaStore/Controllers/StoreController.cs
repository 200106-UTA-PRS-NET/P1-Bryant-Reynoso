using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PizzaBox_Lib.Interfaces;

namespace MockPizzaStore.Controllers
{
    public class StoreController : Controller
    {
        private IPizzaBoxRepository _repository;
        public StoreController(IPizzaBoxRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            var stores = _repository.GetStores();

            ViewBag.stores = stores;

            return View();
        }
    }
}