using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore2_v1
{
    public class Item
    {
        #region Instance fields

        string _name;
        int _price;
        int _itemId;

        #endregion

        public Item (string name, int price, int itemId)
        {
            _name = name;
            _price = price;
            _itemId = itemId;
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Price
        {
            get { return _price; }
            set { _price = value; }
        }
        public int ItemId
        {
            get { return _itemId; }
            set { _itemId = value; }
        }
        public override string ToString()
        {
            return $"{Name}";
        }

    }
}
