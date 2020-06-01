using PizzaBox_Lib.Models;
using System;
using System.Collections.Generic;

namespace MockPizzaStore.Models
{
    public class OrderViewModel
    { 
        public List<Pizza> Pizzas = new List<Pizza>();
        public string StoreId { get; set; }
        public double Total { get; set; }
    }
}
