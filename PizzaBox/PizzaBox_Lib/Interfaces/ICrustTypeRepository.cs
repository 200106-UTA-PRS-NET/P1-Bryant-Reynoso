using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox_Lib.Interfaces
{
    public interface ICrustTypeRepository<T>
    {
        //get all
        IEnumerable<T> GetCrustTypes();

        //get by id
        T GetCrustTypeById(int id);

        //add
        void AddCrustType(T crustTypes);

        //update
        void UpdateCrustType(T crustTypes);

        //delete
        void DeleteCrustType(int id);

    }
}
