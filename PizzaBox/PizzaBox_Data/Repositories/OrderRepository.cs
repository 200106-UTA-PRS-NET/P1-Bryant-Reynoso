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
    public class OrderRepository : IOrderRepository<PizzaBox_Lib.Models.Orders>
    {

        PizzaDbContext db;

        public OrderRepository() 
        {
            db = new PizzaDbContext();
        }

        public OrderRepository(PizzaDbContext db)
        {
            this.db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public void AddOrder(PizzaBox_Lib.Models.Orders orders)
        {
            db.Orders.Add(Mapper.Map(orders));
            db.SaveChanges();
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
    }
}
