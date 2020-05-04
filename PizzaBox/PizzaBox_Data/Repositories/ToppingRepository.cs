using System;
using System.Collections.Generic;
using PizzaBox_Lib.Interfaces;
using PizzaBox_Data.Entities;
using System.Linq;

namespace PizzaBox_Data.Repositories
{
    public class ToppingRepository: IToppingRepository<PizzaBox_Lib.Models.Toppings>
    {

        PizzaDbContext db;

        public ToppingRepository()
        {
            db = new PizzaDbContext();
        }

        public ToppingRepository(PizzaDbContext db)
        {
            this.db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public void AddTopping(PizzaBox_Lib.Models.Toppings toppings)
        {
            if (db.Toppings.Any(t => t.ToppingName == toppings.ToppingName) || toppings.ToppingName == null)
            {
                Console.WriteLine($"A topping with the name '{toppings.ToppingName}' already exists and cannot be added");
                return;
            }
            else
            {
                db.Toppings.Add(Mapper.Map(toppings));
                db.SaveChanges();
            }
        }

        public void DeleteTopping(int id)
        {
            var topping = db.Toppings.FirstOrDefault(c => c.Id == id);
            if (topping.Id == id)
            {
                db.Remove(topping);
                db.SaveChanges();
            }
            else
            {
                Console.WriteLine($"Topping with this Id {id} does not exist");
                return;
            }
        }

        public IEnumerable<PizzaBox_Lib.Models.Toppings> GetToppings()
        {
            var query = from o in db.Toppings
                        select Mapper.Map(o);

            return query;
        }

        public PizzaBox_Lib.Models.Toppings GetToppingsById(int id)
        {
            var query = from o in db.Toppings.Where(o => o.Id == id)
                        select Mapper.Map(o);

            return query.FirstOrDefault();
        }

        public void UpdateTopping(PizzaBox_Lib.Models.Toppings toppings)
        {
            if (db.Toppings.Any(t => t.Id == toppings.Id))
            {
                var t = db.Toppings.FirstOrDefault(t => t.Id == toppings.Id);
                t.ToppingName = toppings.ToppingName;
                t.Price = toppings.Price;

                db.Toppings.Update(t);
                db.SaveChanges();
            }
            else
            {
                Console.WriteLine($"A topping with the Id {toppings.Id} does not exist");
                return;
            }
        }
    }
}
