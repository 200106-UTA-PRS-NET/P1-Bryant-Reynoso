using System.Collections.Generic;
using PizzaBox_Lib.Models;

namespace PizzaBox_Lib.Interfaces
{
    public interface IPizzaBoxRepository 
    {

        #region: order methods
        //Order
        //=============
        //get all
        IEnumerable<Orders> GetOrders();

        //get by id
        Orders GetOrdersById(int id);

        //add
        void AddOrder(Orders orders);

        //update
        void UpdateOrder(Orders orders);

        //delete
        void DeleteOrder(int id);
        #endregion

        #region: stores methods
        ////Stores
        ////============
        //get all
        IEnumerable<Stores> GetStores();

        //get by id
        Stores GetStoreById(int id);
        #endregion

        #region: users methods
        //Users
        //============
        //get all
        IEnumerable<Users> GetUsers();

        //get by id
        Users GetUsersById(int id);

        int GetIdByUserName(string username);
        //add
        void AddUser(Users users);

        #endregion

        #region: pan size methods
        //get all
        IEnumerable<PanSizes> GetPanSizes();

        //get by id
        PanSizes GetPanSizeById(int id);

        #endregion

        #region: crust type methods

        //Crust
        //============

        //get all
        IEnumerable<CrustTypes> GetCrustTypes();

        //get by id
        CrustTypes GetCrustTypeById(int id);

        #endregion

        #region: our pizzas methods
        //get all
        IEnumerable<OurPizzas> GetOurPizzas();

        //get by id
        OurPizzas OurPizzaById(int id);

        #endregion

        #region: topping methods
        //Toppings
        //============

        //get all 
        IEnumerable<Toppings> GetToppings();

        //get by id
        Toppings GetToppingsById(int id);

        #endregion

        #region:our pizza toppings methods
        //OurPizzaToppings GetToppingsByPizzaId(int pizzaId);

        //IEnumerable<OurPizzaToppings> GetOurPizzaToppings();
        #endregion


    }
}
