using System;
using System.Collections.Generic;
using System.Text;

namespace Wild_Farm
{
    public abstract class Food : IFood
    {
        protected Food(double quantity)
        {
            Quantity = quantity;
        }
        public double Quantity { get; protected set; }
    }
}
