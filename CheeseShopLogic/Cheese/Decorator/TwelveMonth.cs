using System;
using System.Collections.Generic;
using System.Text;

namespace CheeseShopLogic.Cheese.Decorator
{
    class TwelveMonth : DecorateurCheese
    {
        Cheese cheese;

        public TwelveMonth(Cheese cheese)
        {
            this.cheese = cheese;
        }

        public override string GetDescription()
        {
            return cheese.GetDescription() + ", twelve month affinated";
        }

        public override double GetPrice()
        {
            return cheese.GetPrice() + 20;
        }
    }
}
