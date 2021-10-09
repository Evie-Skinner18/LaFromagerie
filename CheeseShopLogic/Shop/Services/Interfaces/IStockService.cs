namespace CheeseShopLogic.Shop.Services.Interfaces
{
    public interface IStockService
    {
        Dictionary<CheeseType, int> Restock(CheeseType type, int totalCheeses);
        Dictionary<CheeseType, int> GetStock();
        int CheckStockForCheeseType(CheeseType type);
        void RemoveItemFromStock(CheeseType type);
    }
}