using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PizzaBox_Lib.Interfaces;
using PizzaBox_Web.Models;

namespace PizzaBox_Web.Controllers
{
    public class StoresController : Controller
    {
        private readonly IStoreRepository<PizzaBox_Lib.Models.Stores> _repository;
        public StoresController(IStoreRepository<PizzaBox_Lib.Models.Stores> repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var stores = _repository.GetStores();

            List<Stores> storeModel = new List<Stores>();
            foreach (var item in stores)
            {
                Stores store = new Stores
                {
                    id = item.Id,
                    StoreAddress = item.StoreAddress
                };
                storeModel.Add(store);
            }

            return View(storeModel);
        }
    }
}