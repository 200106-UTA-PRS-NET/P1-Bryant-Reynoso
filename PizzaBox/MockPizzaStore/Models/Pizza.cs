using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MockPizzaStore.Models
{
    public class Pizza
    {
        public int Id { get; set; }
        public string PizzaName { get; set; }
        public string CrustType { get; set; }
        public string PanSize { get; set; }
        public decimal Price { get; set; }
    }
}
