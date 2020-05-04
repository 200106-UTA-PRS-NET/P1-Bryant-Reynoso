using System.Collections.Generic;

namespace PizzaBox_Lib.Interfaces
{
    public interface IStoreRepository<T>
    {
        IEnumerable<T> GetStores();

        //get by id
        T GetStoresById(int id);

        //add
        void AddStore(T stores);

        //update
        void UpdateStore(T stores);

        //delete
        void DeleteStores(int id);
    }
}
