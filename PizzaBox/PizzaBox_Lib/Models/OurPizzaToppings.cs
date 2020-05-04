
namespace PizzaBox_Lib.Models
{
    public class OurPizzaToppings
    {
        public int PizzaId { get; set; }
        public int ToppingId { get; set; }

        public virtual OurPizzas Pizza { get; set; }
        public virtual Toppings Topping { get; set; }
    }
}
