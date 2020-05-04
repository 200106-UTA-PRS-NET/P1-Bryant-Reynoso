using System.ComponentModel.DataAnnotations;

namespace PizzaBox_Web.Models
{
    public class Stores
    {

        [Display(Name = "Store Id")]
        public int id { get; set; }
        [Display(Name = "Address")]
        public string StoreAddress { get; set; }
    }
}
