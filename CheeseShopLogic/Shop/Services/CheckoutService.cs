using CheeseShopLogic.Shop.Models;
using CheeseShopLogic.Shop.Services.Interfaces;

namespace CheeseShopLogic.Shop.Services
{
    public class CheckoutService : ICheckoutService
    {
        private readonly StockService _stockService;
        public CheckoutService(StockService stockService)
        {
            _stockService = stockService;
        }
        public void Checkout(Cart cart)
        {
            foreach (var item in cart.Cheeses)
            {
                _stockService.RemoveItemFromStock(item);
            }
        }
    }
}