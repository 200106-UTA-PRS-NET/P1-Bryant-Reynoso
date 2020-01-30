using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox_Lib.Interfaces
{
    public interface IPanSizeRepository<T>
    {
        IEnumerable<T> GetPanSizes();

        //get by id
        T GetPanSizeById(int id);

        //add
        void AddPanSize(T panSizes);

        //update
        void UpdatePanSize(T panSizes);

        //delete
        void DeletePanSize(int id);
    }
}
