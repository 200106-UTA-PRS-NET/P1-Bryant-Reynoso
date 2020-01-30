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
    public class PanSizeRepository : IPanSizeRepository<PizzaBox_Lib.Models.PanSizes>
    {

        PizzaDbContext db;

        public PanSizeRepository() 
        {
            db = new PizzaDbContext();
        }

        public PanSizeRepository(PizzaDbContext db)
        {
            this.db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public void AddPanSize(PizzaBox_Lib.Models.PanSizes panSizes)
        {
            if (db.PanSizes.Any(p => p.Size == panSizes.Size) || panSizes.Size == null)
            {
                Console.WriteLine($"A pan with the size '{panSizes.Size}' already exists and cannot be added");
                return;
            }
            else
            {
                db.PanSizes.Add(Mapper.Map(panSizes));
                db.SaveChanges();
            }
        }

        public void DeletePanSize(int id)
        {
            var size = db.CrustTypes.FirstOrDefault(s => s.Id == id);
            if (size.Id == id)
            {
                db.Remove(size);
                db.SaveChanges();
            }
            else
            {
                Console.WriteLine($"Pan size with this Id {id} does not exist");
                return;
            }
        }

        public PizzaBox_Lib.Models.PanSizes GetPanSizeById(int id)
        {
            var query = from o in db.PanSizes.Where(o => o.Id == id)
                        select Mapper.Map(o);

            return query.FirstOrDefault();
        }

        public IEnumerable<PizzaBox_Lib.Models.PanSizes> GetPanSizes()
        {
            var query = from o in db.PanSizes
                        select Mapper.Map(o);

            return query;
        }

        public void UpdatePanSize(PizzaBox_Lib.Models.PanSizes panSizes)
        {
            if (db.PanSizes.Any(p => p.Id == panSizes.Id))
            {
                var size = db.PanSizes.FirstOrDefault(p => p.Id == panSizes.Id);
                size.Size = panSizes.Size;
                size.Price = panSizes.Price;
                db.PanSizes.Update(size);
                db.SaveChanges();
            }
            else
            {
                Console.WriteLine($"Crust with the Id {panSizes.Id} does not exist");
                return;
            }
        }
    }
}
