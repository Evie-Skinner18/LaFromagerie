using CheeseShopLogic.Shop.Services.Interfaces;

namespace CheeseShopLogic.Shop.Services
{
    public class StockService : IStockService
    {
        private readonly Dictionary<CheeseType, int> _stock;
        public StockService(Dictionary<CheeseType, int> stock)
        {
            _stock = stock;
        }

        public int CheckStockForCheeseType(CheeseType type)
        {
            _stock.TryGetValue(type, out var totalStock);
            return totalStock;
        }

        public Dictionary<CheeseType, int> GetStock()
        {
            return _stock;
        }

        public void RemoveItemFromStock(CheeseType type)
        {
            if (_stock.ContainsKey(type) && _stock.TryGetValue(type, out var numberLeft) && numberLeft > 0)
            {
                _stock[type]--;
            }
            else
            {
                throw new Exception($"{type.Name} is out of stock!");
            }
        }

        public Dictionary<CheeseType, int> Restock(CheeseType type, int totalCheeses)
        {
            if (_stock.ContainsKey(type))
            {
                _stock[type] = totalCheeses;
            }
            else
            {
                _stock.Add(type, totalCheeses);
            }
            return _stock;
        }

    }
}