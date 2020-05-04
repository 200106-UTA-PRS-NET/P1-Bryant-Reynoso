using PizzaBox_Lib.Models;
using System;
using System.Collections.Generic; 

namespace PizzaBox_Web.Models
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public string Pizzas { get; set; }
        public decimal Total { get; set; }
        public int Userid { get; set; }
        public int Storeid { get; set; }
        public DateTime TimeOrdered { get; set; }

        public IEnumerable<Orders> Orders { get; set; }

        public IEnumerable<PanSizes> PanSizes { get; set; }

        public IEnumerable<OurPizzas> OurPizzas { get; set; }

        public IEnumerable<CrustTypes> CrustTypes { get; set; }

        public IEnumerable<PizzaModel> PizzasOrdered { get; set; }

        public IEnumerable<Stores> Stores { get; set; }
        public Users User { get; set; }
        public string PizzaNamesList()
        {
            List<string> pizzaNames = new List<string>();
            string combinedString;

            foreach (var p in PizzasOrdered)
            {
                pizzaNames.Add(p.PizzaName);
            }
            combinedString = string.Join(",", pizzaNames);

            return combinedString;
        }

        public decimal CalculateOrder()
        {
            Total = 0;
            foreach (var pizza in PizzasOrdered)
            {
                Total += pizza.CalculatePizza();
            }

            return Total;
        }
    }
}
