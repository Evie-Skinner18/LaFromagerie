using CheeseShopLogic.Shop.Models;

namespace CheeseShopLogic.Shop.Services.Interfaces
{
    public interface ICheckoutService
    {
        void Checkout(Cart cart);
    }
}