using PizzaBox_Lib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox_Lib.Interfaces
{
    //there's no table for custom pizzas
    //so add a model for pizza in general

    public interface IOurPizzasRepository<T>
    { 

        #region: of course
        //PanSize
        //=============
        //get all
        //IEnumerable<PanSizes> GetPanSizes(string search = null);

        ////get by id
        //PanSizes GetPanSizeById(int id);

        ////add
        //void AddPanSize(PanSizes panSizes);

        ////update
        //void UpdatePanSize(PanSizes panSizes);

        ////delete
        //void DeletePanSize(int panSizeId);

        //Crust
        //============

        ////get all
        //IEnumerable<CrustTypes> GetCrustTypes(string search = null);

        ////get by id
        //CrustTypes GetCrustTypeById(int id);

        ////add
        //void AddCrustType(CrustTypes crustTypes);

        ////update
        //void UpdateCrustType(CrustTypes crustTypes);

        ////delete
        //void DeleteCrustType(int crustTypeId);

        //Toppings
        //============

        //get all

        //IEnumerable<Toppings> GetToppings(string search = null);

        ////get by id
        //Toppings GetToppingsById(int id);

        ////add
        //void AddTopping(Toppings toppings);

        ////update
        //void UpdateTopping(Toppings toppings);

        ////delete
        //void DeleteTopping(int toppingtId);

        #endregion
             
        //get all
        IEnumerable<T> GetOurPizzas();

        //get by id
        T OurPizzaById(int id);

        //add
        void AddToOurPizzas(T ourPizzas);

        //update
        void UpdateOurPizzas(T ourPizzas);

        //delete
        void DeleteFromOurPizzas(int id);
       
    }
}
