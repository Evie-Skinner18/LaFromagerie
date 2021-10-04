using System;
using System.Collections.Generic;
using System.Text;

namespace CheeseShopLogic.Cheese
{
    class SaintNectaire : Cheese
    {
        public SaintNectaire()
        {
            description = "Fromage d'Auvergne";
        }

        public override double GetPrice()
        {
            return 21;
        }
    }
}
