using System.Collections.Generic;

namespace PizzaBox_Lib.Interfaces
{
    public interface IOurPizzaToppingsRepository<T>
    {
        //get all pizzas with all their toppings
        IEnumerable<T> GetOurPizzaToppings();

        //get by id
        T GetToppingsByPizzaId(int pizzaId);

        //add
        //void AddToppingToOurPizza(T topping);

        ////update
        //void UpdateToppingForOurPizza(T ourPizzas);

        //////delete
        //void DeleteToppingFromOurPizza(int id);
    }
}
