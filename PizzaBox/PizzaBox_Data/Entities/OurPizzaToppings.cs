﻿namespace PizzaBox_Data.Entities
{
    public partial class OurPizzaToppings
    {
        public int PizzaId { get; set; }
        public int ToppingId { get; set; }

        public virtual OurPizzas Pizza { get; set; }
        public virtual Toppings Topping { get; set; }
    }
}
