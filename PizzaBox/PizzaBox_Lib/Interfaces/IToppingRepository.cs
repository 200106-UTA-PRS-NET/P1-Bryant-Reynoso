using System.Collections.Generic;

namespace PizzaBox_Lib.Interfaces
{
    public interface IToppingRepository<T>
    {
        IEnumerable<T> GetToppings();

        //get by id
        T GetToppingsById(int id);

        //add
        void AddTopping(T toppings);

        //update
        void UpdateTopping(T toppings);

        //delete
        void DeleteTopping(int id);
    }
}
