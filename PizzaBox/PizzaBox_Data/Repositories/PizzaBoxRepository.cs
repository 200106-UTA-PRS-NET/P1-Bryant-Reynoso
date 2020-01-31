using System;
using System.Collections.Generic;
using System.Text;
using PizzaBox_Data.Entities;
using PizzaBox_Lib.Interfaces;
using PizzaBox_Lib.Models;
using System.Linq;

namespace PizzaBox_Data.Repositories
{
    public class PizzaBoxRepository : IPizzaBoxRepository
    { 
        PizzaDbContext db;

        public PizzaBoxRepository()
        {
            db = new PizzaDbContext();
        }

        public PizzaBoxRepository(PizzaDbContext db)
        {
            this.db = db ?? throw new ArgumentNullException(nameof(db));
        }


        public void AddOrder(PizzaBox_Lib.Models.Orders orders)
        {
            db.Orders.Add(Mapper.Map(orders));
            db.SaveChanges();
        }

        public void AddUser(PizzaBox_Lib.Models.Users users)
        {
            if (db.Users.Any(u => u.Username == users.Username) || users.Username == null)
            {
                Console.WriteLine($"A user with username '{users.Username}' already exists and cannot be added");
                return;
            }
            else
            {
                db.Users.Add(Mapper.Map(users));
                db.SaveChanges();
            }
        }


        public void DeleteOrder(int id)
        {
            var order = db.Orders.FirstOrDefault(o => o.Id == id);
            if (order.Id == id)
            {
                db.Remove(order);
                db.SaveChanges();
            }
            else
            {
                Console.WriteLine($"Order with this Id {id} does not exist");
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

        public IEnumerable<PizzaBox_Lib.Models.Orders> GetOrders()
        {
            var query = from o in db.Orders
                        select Mapper.Map(o);

            return query;
        }


        public PizzaBox_Lib.Models.Orders GetOrdersById(int id)
        {
            var query = from o in db.Orders.Where(o => o.Id == id)
                        select Mapper.Map(o);

            return query.FirstOrDefault();
        }


        public IEnumerable<PizzaBox_Lib.Models.OurPizzas> GetOurPizzas()
        {
            var query = from o in db.OurPizzas
                        select Mapper.Map(o);

            return query;
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


        public IEnumerable<PizzaBox_Lib.Models.Stores> GetStores()
        {
            var query = from o in db.Stores
                        select Mapper.Map(o);

            return query;
        }

        public PizzaBox_Lib.Models.Stores GetStoreById(int id)
        {
            var query = from o in db.Stores.Where(o => o.Id == id)
                        select Mapper.Map(o);

            return query.FirstOrDefault();
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


        public IEnumerable<PizzaBox_Lib.Models.Users> GetUsers()
        {
            var query = from o in db.Users
                        select Mapper.Map(o);

            return query;
        }

        public PizzaBox_Lib.Models.Users GetUsersById(int id)
        {
            var query = from o in db.Users.Where(o => o.Id == id)
                        select Mapper.Map(o);

            return query.FirstOrDefault();
        }


        public PizzaBox_Lib.Models.OurPizzas OurPizzaById(int id)
        {
            var query = from o in db.OurPizzas.Where(o => o.Id == id)
                        select Mapper.Map(o);

            return query.FirstOrDefault();
        }


        public void UpdateOrder(PizzaBox_Lib.Models.Orders orders)
        {
            if (db.Orders.Any(o => o.Id == orders.Id))
            {
                var o = db.Orders.FirstOrDefault(o => o.Id == orders.Id);
                o.Pizzas = orders.Pizzas;
                o.Total = orders.Total;
                db.Orders.Update(o);
                db.SaveChanges();
            }
            else
            {
                Console.WriteLine($"Order with the Id {orders.Id} does not exist");
                return;
            }
        }

        public int GetIdByUserName(string username)
        {
            var query = from o in db.Users.Where(o => o.Username == username)
                        select Mapper.Map(o);

            return query.FirstOrDefault().Id;
        }
    }
}
