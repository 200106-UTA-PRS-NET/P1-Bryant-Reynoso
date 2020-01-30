using System;
using System.Collections.Generic;
using System.Text;
using PizzaBox_Lib.Interfaces;
using PizzaBox_Lib.Models;
using Microsoft.EntityFrameworkCore;
using PizzaBox_Data.Entities;
using System.Linq;

namespace PizzaBox_Data.Repositories
{
    public class OurPizzaRepository : IOurPizzasRepository<PizzaBox_Lib.Models.OurPizzas>
    {

        PizzaDbContext db;

        public OurPizzaRepository() 
        {
            db = new PizzaDbContext();
        }

        public OurPizzaRepository(PizzaDbContext db)
        {
            this.db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public void AddToOurPizzas(PizzaBox_Lib.Models.OurPizzas ourPizzas)
        {
            if (db.OurPizzas.Any(p => p.PizzaName == ourPizzas.PizzaName) || ourPizzas.PizzaName == null)
            {
                Console.WriteLine($"A pizza with the name {ourPizzas.PizzaName} already exists and cannot be added");
                return;
            }
            else
            { 
                db.OurPizzas.Add(Mapper.Map(ourPizzas));
                db.SaveChanges();
            }
        }

        public void DeleteFromOurPizzas(int id)
        {
            var ourPizza = db.OurPizzas.FirstOrDefault(p => p.Id == id);
            if (ourPizza.Id == id)
            {
                db.Remove(ourPizza);
                db.SaveChanges();
            }
            else
            {
                Console.WriteLine($"Pizza with this Id {id} does not exist");
                return;
            }
        }

        public IEnumerable<PizzaBox_Lib.Models.OurPizzas> GetOurPizzas()
        {
            var query = from o in db.OurPizzas
                        select Mapper.Map(o);

            return query;
        }

        public PizzaBox_Lib.Models.OurPizzas OurPizzaById(int id)
        {
            var query = from o in db.OurPizzas.Where(o => o.Id == id)
                        select Mapper.Map(o);

            return query.FirstOrDefault();
        }

        public void UpdateOurPizzas(PizzaBox_Lib.Models.OurPizzas ourPizzas)
        {
            if (db.OurPizzas.Any(p => p.Id == ourPizzas.Id))
            {
                var pizza = db.OurPizzas.FirstOrDefault(p => p.Id == ourPizzas.Id);
                pizza.PizzaName = ourPizzas.PizzaName;
                pizza.Price = ourPizzas.Price;
                db.OurPizzas.Update(pizza);
                db.SaveChanges();
            }
            else
            {
                Console.WriteLine($"Pizza with the Id {ourPizzas.Id} does not exist");
                return;
            }
        }
    }
}
