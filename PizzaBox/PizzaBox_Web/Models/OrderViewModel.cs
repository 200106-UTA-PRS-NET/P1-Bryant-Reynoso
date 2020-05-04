using PizzaBox_Lib.Models;
using System;
using System.Collections.Generic;

namespace PizzaBox_Web.Models
{
    public class OrderViewModel
    {
        //[Display(Name ="Address")]
        public int Id { get; set; }
        public string Pizzas { get; set; }
        public decimal Total { get; set; }
        public int Userid { get; set; }
        public int Storeid { get; set; }
        public DateTime TimeOrdered { get; set; }

        public List<Orders> Orders { get; set; }

        public List<PanSizes> PanSizes { get; set; }

        public List<OurPizzas> OurPizzas { get; set; }

        public List<CrustTypes> CrustTypes { get; set; }

        public List<PizzaModel> PizzasOrdered { get; set; }

        public List<Stores> Stores { get; set; }
        public Users User { get; set; }





        //public string PizzaDescription(PanSizes pan, )
        //{
        //    return $"{PanSize}  {CrustName}  {PizzaName}";
        //}

        //public decimal CalculatePizza()
        //{
        //    Total = PizzaPrice + CrustPrice + PanPrice;

        //    return Total;
        //}

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
            //Total = pizza.Price + crust.Price + pan.Price;

            return Total;
        }
    }
}
