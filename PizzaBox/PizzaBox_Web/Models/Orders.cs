using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaBox_Web.Models
{
    public class Orders
    {
        public int Id { get; set; }
        public string Pizzas { get; set; }
        public decimal Total { get; set; }
        public int? Userid { get; set; }
        public int? Storeid { get; set; }
        public DateTime TimeOrdered { get; set; }
    }
}
