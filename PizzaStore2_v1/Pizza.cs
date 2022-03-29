using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore2_v1
{
    public class Pizza : Item
    {

        #region Instance fields

        #endregion

        #region Lists

        public List<Topping> ToppingList = new List<Topping>();

        #endregion

        #region Constructor
        public Pizza(int itemId, string name, int price) : base (name, price, itemId)
        {
            ToppingList = new List<Topping>();
        }
        #endregion

        #region Methods

       

        #endregion

    }
}
