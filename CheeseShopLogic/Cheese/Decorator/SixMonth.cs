using System;
using System.Collections.Generic;
using System.Text;

namespace CheeseShopLogic.Cheese
{
    public class SixMonth : DecorateurCheese
    {
        Cheese cheese;

        public SixMonth(Cheese cheese)
        {
            this.cheese = cheese;
        }

        public override string GetDescription()
        {
            return cheese.GetDescription() + ", six month affinated";
        }

        public override double GetPrice()
        {
            return cheese.GetPrice() + 10;
        }
    }
}
