using Microsoft.AspNetCore.Mvc.Rendering;
using PizzaBox_Lib.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MockPizzaStore.Models
{
    public class PizzaFormViewModel
    {
        [Required]
        public string PizzaName { get; set; }
        public IEnumerable<OurPizzas> Pizzas { get; set; }

        [Required]
        [Display(Name = "Choose a Crust Type")]
        public string SelectedCrustType { get; set; }
        public IEnumerable<SelectListItem> CrustTypes { get; set; }

        [Required]
        [Display(Name = "Choose a Pan Size")]
        public string SelectedPanSize { get; set; }
        public IEnumerable<SelectListItem> PanSizes { get; set; }
    }
}
