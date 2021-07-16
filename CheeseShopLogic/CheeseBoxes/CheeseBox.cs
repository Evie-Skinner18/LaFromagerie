using System.Collections.Generic;

namespace CheeseShopLogic.CheeseBoxes
{
    public class CheeseBox
    {
        private CheeseBox(string name, List<CheeseType> cheesesInside)
        {
            Name = name;
            CheesesInside = cheesesInside;
        }

        public string Name { get; set; }
        public List<CheeseType> CheesesInside { get; set; }

        public static CheeseBox Create(string name, List<CheeseType> cheesesInside)
        {
            var cheeseBox = new CheeseBox(name, cheesesInside);
            return cheeseBox;
        }
    }
}
