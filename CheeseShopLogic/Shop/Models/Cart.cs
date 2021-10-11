using CheeseShopLogic;

namespace CheeseShopLogic.Shop.Models
{
    public class Cart
    {
        public List<CheeseType> Cheeses { get; set; } = new List<CheeseType>();
    }
}