using System.Collections.Generic;

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
