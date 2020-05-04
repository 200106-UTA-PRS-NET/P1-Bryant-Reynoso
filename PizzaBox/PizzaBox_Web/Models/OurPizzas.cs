namespace PizzaBox_Web.Models
{
    public class OurPizzas
    {
        public OurPizzas()
        {
           // OurPizzaToppings = new HashSet<OurPizzaToppings>();
        }

        public int Id { get; set; }
        public string PizzaName { get; set; }
        public decimal Price { get; set; }

       // public virtual ICollection<OurPizzaToppings> OurPizzaToppings { get; set; }
    }
}
