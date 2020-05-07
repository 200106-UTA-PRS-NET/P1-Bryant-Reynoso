using PizzaBox_Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MockPizzaStore.Models
{
    public class OrderViewModel
    {
        public List<OurPizzas> pizzas = new List<OurPizzas>();
        public string StoreId { get; set; }
        public double Total { get; set; }
    }
}
