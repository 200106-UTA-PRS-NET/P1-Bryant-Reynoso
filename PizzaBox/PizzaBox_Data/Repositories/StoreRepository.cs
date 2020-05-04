using System;
using System.Collections.Generic;
using PizzaBox_Lib.Interfaces;
using PizzaBox_Data.Entities;
using System.Linq;

namespace PizzaBox_Data.Repositories
{
    public class StoreRepository:IStoreRepository<PizzaBox_Lib.Models.Stores>
    {

        PizzaDbContext db;

        public StoreRepository()
        {
            db = new PizzaDbContext();
        }

        public StoreRepository(PizzaDbContext db)
        {
            this.db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public void AddStore(PizzaBox_Lib.Models.Stores stores)
        {
            if (db.Stores.Any(s => s.StoreAddress == stores.StoreAddress) || stores.StoreAddress == null)
            {
                Console.WriteLine($"A store with the address '{stores.StoreAddress}' already exists and cannot be added");
                return;
            }
            else
            {
                db.Stores.Add(Mapper.Map(stores));
                db.SaveChanges();
            }
        }

        public void DeleteStores(int id)
        {
            var store = db.Stores.FirstOrDefault(c => c.Id == id);
            if (store.Id == id)
            {
                db.Remove(store);
                db.SaveChanges();
            }
            else
            {
                Console.WriteLine($"Store with this Id {id} does not exist");
                return;
            }
        }

        public IEnumerable<PizzaBox_Lib.Models.Stores> GetStores()
        {
            var query = from o in db.Stores
                        select Mapper.Map(o);

            return query;
        }

        public PizzaBox_Lib.Models.Stores GetStoresById(int id)
        {
            var query = from o in db.Stores.Where(o => o.Id == id)
                        select Mapper.Map(o);

            return query.FirstOrDefault();
        }

        public void UpdateStore(PizzaBox_Lib.Models.Stores stores)
        {
            if (db.Stores.Any(s => s.Id == stores.Id))
            {
                var s = db.Stores.FirstOrDefault(s => s.Id == stores.Id);
                s.StoreAddress = stores.StoreAddress;
                s.Inventory = stores.Inventory;
                s.Sales = stores.Sales; 
                db.Stores.Update(s);
                db.SaveChanges();
            }
            else
            {
                Console.WriteLine($"A store with the Id {stores.Id} does not exist");
                return;
            }
        }
    }
}
