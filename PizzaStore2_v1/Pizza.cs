using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore2_v1
{
    public class Pizza
    {
        

        #region Instance Fields

        private string _name;
        private int _price;
        private int _id;        
        #endregion

        #region Constructor
        public Pizza (int id, string name, int price)
        {
            _name = name;
            _price = price;
            _id = id;

        }
        #endregion

        #region Properties

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
        public int PizzaId
        {
            get { return _id; }
            set { _id = value; }
        }        

        #endregion

        #region Methods

        public override string ToString()
        {
            return $"{Name}";
        }

        #endregion

    }
}
