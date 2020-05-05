using System.Collections.Generic;
using PizzaBox_Lib.Models;
using System.Linq;

namespace PizzaBox_Data
{
    public class Mapper
    {
        //CRUST TYPE
        public static PizzaBox_Lib.Models.CrustTypes Map(Entities.CrustTypes crustTypes)
        {
            return new PizzaBox_Lib.Models.CrustTypes()
            {
                Id = crustTypes.Id,
                CrustName = crustTypes.CrustName,
                Price = crustTypes.Price
            };
        }

        public static Entities.CrustTypes Map(PizzaBox_Lib.Models.CrustTypes crustTypes)
        {
            return new Entities.CrustTypes()
            {
                Id = crustTypes.Id,
                CrustName = crustTypes.CrustName,
                Price = crustTypes.Price
            };
        }

        //PAN SIZES     
        public static PizzaBox_Lib.Models.PanSizes Map(Entities.PanSizes panSizes)
        {
            return new PizzaBox_Lib.Models.PanSizes()
            {
                Id = panSizes.Id,
                Size = panSizes.Size,
                Price = panSizes.Price
            };
        }

        public static Entities.PanSizes Map(PizzaBox_Lib.Models.PanSizes panSizes)
        {
            return new Entities.PanSizes()
            {
                Id = panSizes.Id,
                Size = panSizes.Size,
                Price = panSizes.Price
            };
        }

        //TOPPINGS
        public static PizzaBox_Lib.Models.Toppings Map(Entities.Toppings toppings)
        {
            return new PizzaBox_Lib.Models.Toppings()
            {
                Id = toppings.Id,
                ToppingName = toppings.ToppingName,
                Price = toppings.Price
            };
        }

        public static Entities.Toppings Map(PizzaBox_Lib.Models.Toppings toppings)
        {
            return new Entities.Toppings()
            {
                Id = toppings.Id,
                ToppingName = toppings.ToppingName,
                Price = toppings.Price
            };
        }

        //OUR PIZZAS
        public static PizzaBox_Lib.Models.OurPizzas Map(Entities.OurPizzas ourPizzas)
        {
            return new PizzaBox_Lib.Models.OurPizzas()
            {
                Id = ourPizzas.Id,
                PizzaName = ourPizzas.PizzaName,
                Price = ourPizzas.Price
            };
        }

        public static Entities.OurPizzas Map(PizzaBox_Lib.Models.OurPizzas ourPizzas)
        {
            return new Entities.OurPizzas()
            {
                Id = ourPizzas.Id,
                PizzaName = ourPizzas.PizzaName,
                Price = ourPizzas.Price
            };
        }

        //ORDERS
        public static PizzaBox_Lib.Models.Orders Map(Entities.Orders orders)
        {
            return new PizzaBox_Lib.Models.Orders()
            {
                Id = orders.Id,
                Pizzas = orders.Pizzas,
                Total = orders.Total,
                Userid = orders.Userid,
                Storeid = orders.Storeid,
                TimeOrdered = orders.TimeOrdered
            };
        }

        public static Entities.Orders Map(PizzaBox_Lib.Models.Orders orders)
        {
            return new Entities.Orders()
            {
                Id = orders.Id,
                Pizzas = orders.Pizzas,
                Total = orders.Total,
                Userid = orders.Userid,
                Storeid = orders.Storeid,
                TimeOrdered = orders.TimeOrdered
            };
        }


        //STORES
        public static PizzaBox_Lib.Models.Stores Map(Entities.Stores stores)
        {
            return new PizzaBox_Lib.Models.Stores()
            {
                Id = stores.Id,
                StoreAddress = stores.StoreAddress,
                Inventory = stores.Inventory,
                Sales = stores.Sales
            };
        }

        public static Entities.Stores Map(PizzaBox_Lib.Models.Stores stores)
        {
            return new Entities.Stores()
            {
                Id = stores.Id,
                StoreAddress = stores.StoreAddress,
                Inventory = stores.Inventory,
                Sales = stores.Sales
            };
        }

         
        private static ICollection<PizzaBox_Lib.Models.Orders> Map(ICollection<Entities.Orders> orders)
        {
            var map = orders.Select(x => Map(x)); 
            return map.ToList();
        }


        private static ICollection<Entities.Orders> Map(ICollection<Orders> orders)
        {

            var map = orders.Select(x => Map(x)); 
            return map.ToList();
        } 


        //USERS
        public static PizzaBox_Lib.Models.Users Map(Entities.Users users)
        {
            return new PizzaBox_Lib.Models.Users()
            {
                Id = users.Id,
                Username = users.Username,
                Pass = users.Pass,
                IsEmployee = users.IsEmployee
            };
        }
         
        public static Entities.Users Map(PizzaBox_Lib.Models.Users users)
        {
            return new Entities.Users()
            {
                Id = users.Id,
                Username = users.Username,
                Pass = users.Pass,
                IsEmployee = users.IsEmployee
            };
        }


        //OUR PIZZA TOPPINGS
        public static PizzaBox_Lib.Models.OurPizzaToppings Map(Entities.OurPizzaToppings ourPizzaToppings)
        {
            return new PizzaBox_Lib.Models.OurPizzaToppings()
            {
                PizzaId = ourPizzaToppings.PizzaId,
                ToppingId = ourPizzaToppings.ToppingId
            };
        }

        public static Entities.OurPizzaToppings Map(PizzaBox_Lib.Models.OurPizzaToppings ourPizzaToppings)
        {
            return new Entities.OurPizzaToppings()
            {
                PizzaId = ourPizzaToppings.PizzaId,
                ToppingId = ourPizzaToppings.ToppingId
            };
        }
    }
}
