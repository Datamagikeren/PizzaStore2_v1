using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore2_v1
{
    public class Topping : Item
    {
        public List<Topping> toppingList = new List<Topping>();

        public Topping (int itemId, string name, int price) : base (name, price, itemId)
        {
            

        }
       
    }
}
