using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
