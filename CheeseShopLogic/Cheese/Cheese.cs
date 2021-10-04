using System;
using System.Collections.Generic;
using System.Text;

namespace CheeseShopLogic.Cheese
{
    public abstract class Cheese
    {
        protected string description = "Fromage incoonu";

        public string GetDescription()
        {
            return description;
        }

        public abstract double GetPrice();
    }
}
