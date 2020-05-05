using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PizzaBox_Lib.Interfaces; 
using PizzaBox_Web.Models;


namespace PizzaBox_Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IPizzaBoxRepository _repository;
        public List<PizzaModel> pizzaList = new List<PizzaModel>();
        private OrderViewModel OVM = new OrderViewModel();
        public OrderController(IPizzaBoxRepository repository)
        {
            _repository = repository;  
        }

        [HttpGet]
        // GET: Order
        public ActionResult Index()
        {
            OVM.Stores = from s in _repository.GetStores()
                         select new Stores()
                         {
                             id = s.Id,
                             StoreAddress = s.StoreAddress
                         };

            return View(OVM);
        }
        
        [HttpPost]
        public ActionResult Index(int? store, int? pan, int? crust, string pizza)
        {
            var stores = _repository.GetStores();
            List<Stores> storeModel = new List<Stores>();

            ViewBag.StoreId = store;
            ViewBag.PanId = pan;
            ViewBag.CrustId = crust;
            ViewBag.PizzaId = pizza;


            foreach (var item in stores)
            {
                Stores newStore = new Stores
                {
                    id = item.Id,
                    StoreAddress = item.StoreAddress
                };
                storeModel.Add(newStore);
            }

            PizzaModel pm = new PizzaModel
            {
                pizzaId = ViewBag.PizzaId,
                crustId = ViewBag.CrustId,
                panId = ViewBag.PanId,
                PanSize = _repository.GetPanSizeById(ViewBag.PanId).Size,
                PanPrice = _repository.GetPanSizeById(ViewBag.PanId).Price,
                CrustName = _repository.GetCrustTypeById(ViewBag.CrustId).CrustName,
                CrustPrice = _repository.GetCrustTypeById(ViewBag.CrustId).Price,
                PizzaName = _repository.OurPizzaById(ViewBag.PizzaId).PizzaName,
                PizzaPrice = _repository.OurPizzaById(ViewBag.PizzaId).Price
            };

            pizzaList.Add(pm);

            OrderViewModel OrderVM = new OrderViewModel
            {
                Storeid = ViewBag.StoreId,
                PizzasOrdered = pizzaList,
                Stores = storeModel
            };

            return View();
        }

        public ActionResult PanSize(int id)
        {
            ViewBag.StoreId = id;
            ViewBag.StoreName = _repository.GetStoreById(id).StoreAddress;

            var PanSizes = _repository.GetPanSizes();

            List<PanSizes> sizeList = new List<PanSizes>();

            foreach (var item in PanSizes)
            {
                PanSizes size = new PanSizes
                {
                    Id = item.Id,
                    Size = item.Size,
                    Price = item.Price
                };
                sizeList.Add(size);
            }

            OrderViewModel OrderVM = new OrderViewModel
            {
                PanSizes = sizeList
            };

            return View(OrderVM);
        }
        
        public ActionResult CrustType(int? store, int? pan)
        {
            ViewBag.StoreId = store;
            ViewBag.PanId = pan;

            var CrustTypes = _repository.GetCrustTypes();

            List<CrustTypes> crustList = new List<CrustTypes>();

            foreach (var item in CrustTypes)
            {
                CrustTypes crust = new CrustTypes
                {
                    Id = item.Id,
                    CrustName = item.CrustName,
                    Price = item.Price
                };
                crustList.Add(crust);
            }

            OrderViewModel OrderVM = new OrderViewModel
            {
                CrustTypes = crustList
            };

            return View(OrderVM);
        }

        public ActionResult OurPizzas(int? store, int? pan, int? crust) 
        {
            ViewBag.StoreId = store;
            ViewBag.PanId = pan;
            ViewBag.CrustId = crust;

            var OurPizzas = _repository.GetOurPizzas();

            List<OurPizzas> pizzaList = new List<OurPizzas>();

            foreach (var item in OurPizzas)
            {
                OurPizzas pizza = new OurPizzas
                {
                    Id = item.Id,
                    PizzaName = item.PizzaName,
                    Price = item.Price
                };

                pizzaList.Add(pizza);
            }

            OrderViewModel OrderVM = new OrderViewModel
            {
                OurPizzas = pizzaList
            };

            return View(OrderVM);
        }

        [HttpGet]
        public ActionResult ConfirmPizza(int? store, int? pan, int? crust, int? pizza) 
        {
            ViewBag.StoreId = store;
            ViewBag.PanId = pan;
            ViewBag.CrustId = crust;
            ViewBag.PizzaId = pizza;

            PizzaModel pm = new PizzaModel
            {
                pizzaId = ViewBag.PizzaId,
                crustId = ViewBag.CrustId,
                panId = ViewBag.PanId,
                PanSize = _repository.GetPanSizeById(ViewBag.PanId).Size,
                PanPrice = _repository.GetPanSizeById(ViewBag.PanId).Price,
                CrustName = _repository.GetCrustTypeById(ViewBag.CrustId).CrustName,
                CrustPrice = _repository.GetCrustTypeById(ViewBag.CrustId).Price,
                PizzaName = _repository.OurPizzaById(ViewBag.PizzaId).PizzaName,
                PizzaPrice = _repository.OurPizzaById(ViewBag.PizzaId).Price
            };

            pizzaList.Add(pm);
            
            OrderViewModel orderVM = new OrderViewModel
            {
                Storeid = ViewBag.StoreId,
                PizzasOrdered = pizzaList

            };

            return View(orderVM);
        }
 
        [HttpPost]
        public ActionResult ConfirmOrder(int store, int pan, int crust, string pizza, decimal total)
        { 
            PizzaBox_Lib.Models.Orders newOrder = new PizzaBox_Lib.Models.Orders()
            {
                Pizzas = pizza,
                Userid = 1,
                Storeid = store,
                TimeOrdered = DateTime.Now,
                Total = total
            };

            _repository.AddOrder(newOrder);

            return View();
        }

    }
}