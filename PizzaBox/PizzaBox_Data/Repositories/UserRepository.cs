using System;
using System.Collections.Generic;
using PizzaBox_Lib.Interfaces;
using PizzaBox_Data.Entities;
using System.Linq;

namespace PizzaBox_Data.Repositories
{
    public class UserRepository: IUserRepository<PizzaBox_Lib.Models.Users>
    {

        PizzaDbContext db;

        public UserRepository()
        {
            db = new PizzaDbContext();
        }

        public UserRepository(PizzaDbContext db)
        {
            this.db = db ?? throw new ArgumentNullException(nameof(db));
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

        public void DeleteUser(int id)
        {
            var user = db.Users.FirstOrDefault(u => u.Id == id);
            if (user.Id == id)
            {
                db.Remove(user);
                db.SaveChanges();
            }
            else
            {
                Console.WriteLine($"User with this Id {id} does not exist");
                return;
            }
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

        public void UpdateUser(PizzaBox_Lib.Models.Users users)
        {
            if (db.Users.Any(u => u.Id == users.Id))
            {
                var u = db.Users.FirstOrDefault(u => u.Id == users.Id);
                u.Username = users.Username;
                u.Pass = users.Pass;
                db.Users.Update(u);
                db.SaveChanges();
            }
            else
            {
                Console.WriteLine($"A user with the Id {users.Id} does not exist");
                return;
            }
        }
    }
}
