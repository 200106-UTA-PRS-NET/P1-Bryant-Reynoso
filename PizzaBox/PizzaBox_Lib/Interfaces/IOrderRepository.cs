using System;
using System.Collections.Generic;
using System.Text;
using PizzaBox_Lib.Models;

namespace PizzaBox_Lib.Interfaces
{
    public interface IOrderRepository<T>
    {
        //Order,Store,Users

        #region: order
        //Order
        //=============
        //get all
        IEnumerable<T> GetOrders();

        //get by id
        T GetOrdersById(int id);

        //add
        void AddOrder(T orders);

        //update
        void UpdateOrder(T orders);

        //delete
        void DeleteOrder(int id);
        #endregion

        #region: stores
        ////Stores
        ////============
        ////get all
        IEnumerable<Stores> GetStores(string search = null);

        ////get by id
        //Stores GetStoresById(int id);

        ////add
        //void AddStore(Stores stores);

        ////update
        //void UpdateStore(Stores stores);

        ////delete
        //void DeleteStores(int storeId);

        #endregion

        #region: users
        //Users
        //============
        //get all
        //IEnumerable<Users> GetUsers(string search = null);

        ////get by id
        //Users GetUsersById(int id);

        ////add
        //void AddUser(Users users);

        ////update
        //void UpdateUser(Users users);

        ////delete
        //void DeleteUser(int storeId);
        #endregion
         
    }
}
