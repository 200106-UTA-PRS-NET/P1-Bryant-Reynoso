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
    public class CrustTypeRepository : ICrustTypeRepository<PizzaBox_Lib.Models.CrustTypes>
    {

        PizzaDbContext db;

        public CrustTypeRepository() 
        {
            db = new PizzaDbContext();
        }

        public CrustTypeRepository(PizzaDbContext db)
        {
            this.db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public void AddCrustType(PizzaBox_Lib.Models.CrustTypes crustTypes)
        {
            if (db.CrustTypes.Any(c => c.CrustName == crustTypes.CrustName) || crustTypes.CrustName == null)
            {
                Console.WriteLine($"A crust type with name '{crustTypes.CrustName}' already exists and cannot be added");
                return;
            }
            else
            {
                db.CrustTypes.Add(Mapper.Map(crustTypes));
                db.SaveChanges();
            }
        }

        public void DeleteCrustType(int id)
        {
            var crust = db.CrustTypes.FirstOrDefault(c => c.Id == id);
            if (crust.Id == id)
            {
                db.Remove(crust);
                db.SaveChanges();
            }
            else
            {
                Console.WriteLine($"Crust with this Id {id} does not exist");
                return;
            }
        }

        public PizzaBox_Lib.Models.CrustTypes GetCrustTypeById(int id)
        {
            var query = from c in db.CrustTypes.Where(c => c.Id == id)
                        select Mapper.Map(c);

            return query.FirstOrDefault();
        }

        public IEnumerable<PizzaBox_Lib.Models.CrustTypes> GetCrustTypes()
        {
            var query = from c in db.CrustTypes 
                        select Mapper.Map(c);

            return query;
        }

        public void UpdateCrustType(PizzaBox_Lib.Models.CrustTypes crustTypes)
        {
            if (db.CrustTypes.Any(c => c.Id == crustTypes.Id))
            {
                var crust = db.CrustTypes.FirstOrDefault(e => e.Id == crustTypes.Id);
                crust.CrustName = crustTypes.CrustName;
                crust.Price = crustTypes.Price;
                db.CrustTypes.Update(crust);
                db.SaveChanges();
            }
            else
            {
                Console.WriteLine($"Crust with the Id {crustTypes.Id} does not exist");
                return;
            }
        }
    }
}
