namespace PizzaBox_Web.Models
{
    public class PizzaModel
    { 
        public int pizzaId { get; set; }
        public int crustId { get; set; }
        public int panId { get; set; }
        public string CrustName { get; set; }
        public decimal CrustPrice { get; set; }
        public string PanSize { get; set; }
        public decimal PanPrice { get; set; }
        public string PizzaName{ get; set; }
        public decimal PizzaPrice { get; set; }
        public decimal Total  { get; set; }
         
        public string PizzaDescription()
        {
            return $"{PanSize}  {CrustName}  {PizzaName}";
        }

        public decimal CalculatePizza()
        {
            Total = PizzaPrice + CrustPrice + PanPrice;

            return Total;
        } 
    }
}
