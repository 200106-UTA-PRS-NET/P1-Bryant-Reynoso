using System.Linq; 
using Microsoft.AspNetCore.Mvc;
using PizzaBox_Lib.Interfaces;

namespace PizzaBox_Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly IPizzaBoxRepository _repository;
        public LoginController(IPizzaBoxRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string username, string password)
        {
            //var query = _repository.GetIdByUserName(username);

            foreach (var user in _repository.GetUsers().ToList()) 
            {
                if (user.Username == username && user.Pass == password)
                {
                    ViewBag.success = "Login successful";
                    TempData["user"] = _repository.GetIdByUserName(username);

                    return Redirect("~/");
                } 
            }
            ViewBag.fail = "Login failed, try again";
            return View();
        }
    }
}