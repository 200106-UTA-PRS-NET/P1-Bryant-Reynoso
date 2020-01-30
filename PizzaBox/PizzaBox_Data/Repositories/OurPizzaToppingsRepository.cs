using System;
using System.Collections.Generic;
using System.Text;
using PizzaBox_Data.Entities;
using PizzaBox_Lib.Interfaces;
using PizzaBox_Lib.Models;

namespace PizzaBox_Data.Repositories
{
    class OurPizzaToppingsRepository : IOurPizzaToppingsRepository<PizzaBox_Lib.Models.OurPizzaToppings>
    {
        PizzaDbContext db;

        public OurPizzaToppingsRepository()
        {
            db = new PizzaDbContext();
        }

        public OurPizzaToppingsRepository(PizzaDbContext db)
        {
            this.db = db ?? throw new ArgumentNullException(nameof(db));
        }

        IEnumerable<PizzaBox_Lib.Models.OurPizzaToppings> IOurPizzaToppingsRepository<PizzaBox_Lib.Models.OurPizzaToppings>.GetOurPizzaToppings()
        {
            throw new NotImplementedException();
        }

        PizzaBox_Lib.Models.OurPizzaToppings IOurPizzaToppingsRepository<PizzaBox_Lib.Models.OurPizzaToppings>.GetToppingsByPizzaId(int pizzaId)
        {
            throw new NotImplementedException();
        }
    }
}
