using System.Collections.Generic;

namespace PizzaBox_Lib.Interfaces
{
    public interface IUserRepository<T>
    {
        IEnumerable<T> GetUsers();

        //get by id
        T GetUsersById(int id);

        //add
        void AddUser(T users);

        //update
        void UpdateUser(T userss);

        //delete
        void DeleteUser(int id);
    }
}
