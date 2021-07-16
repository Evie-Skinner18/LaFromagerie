using System.Collections.Generic;

namespace CheeseShopLogic.CheeseBoxes
{
    public class CheeseBox
    {
        private CheeseBox(string name, List<CheeseType> cheesesInside)
        {
            Name = name;
            _cheesesInside = cheesesInside;
        }

        public string Name { get; set; }
        private List<CheeseType> _cheesesInside { get; set; }
        private decimal _price { get; set; }

        public static CheeseBox Create(string name, List<CheeseType> cheesesInside)
        {
            var cheeseBox = new CheeseBox(name, cheesesInside);
            return cheeseBox;
        }

        public decimal CalculateTotalPrice()
        {
            decimal totalPrice = 0m;
            foreach (var cheese in _cheesesInside)
            {
                totalPrice += cheese.GetPrice();
            }

            return totalPrice;
        }
    }
}
