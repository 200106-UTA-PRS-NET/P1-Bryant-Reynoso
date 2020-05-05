using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PizzaBox_Lib.Interfaces;

namespace PizzaBox_Web.Controllers
{
    public class OrderHistoryController : Controller
    {
        private readonly IPizzaBoxRepository _repository;
        public OrderHistoryController(IPizzaBoxRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var orders = _repository.GetOrders();

            return View(orders.ToList());
        }
    }
}