using CheeseShopLogic.Shop.Models;
using CheeseShopLogic.Shop.Services;

namespace CheeseShopLogic.Shop
{
    public class Store
    {
        public string ShopName { get; set; }
        public string ShopCountry { get; set; }
        private List<Customer> Customers { get; set; } = new List<Customer>();

        private readonly StockService _stockService;
        private readonly CheckoutService _checkoutService;
        public Store(string shopName, string shopCountry)
        {
            ShopCountry = shopCountry;
            ShopName = shopName;
            _stockService = new StockService(new Dictionary<CheeseType, int>());
            _checkoutService = new CheckoutService(_stockService);
        }

        public void CustomerEnter(Customer customer)
        {
            Customers.Add(customer);
        }

        public bool CustomerExit(Customer customer)
        {
            return Customers.Remove(customer);
        }

        public void RestockCheese(Dictionary<CheeseType, int> delivery)
        {
            foreach (var kvp in delivery)
            {
                _stockService.Restock(kvp.Key, kvp.Value);
            }
        }

        public void CheckoutCustomer(Customer customer)
        {
            if (customer.Cart.Cheeses.Any())
            {
                _checkoutService.Checkout(customer.Cart);
                CustomerExit(customer);
            }
            else
            {
                throw new Exception("Can't check out customer because their cart is empty!");
            }
        }

        public void PrintStock()
        {
            foreach (var kvp in _stockService.GetStock())
            {
                Console.WriteLine($"{kvp.Key.Name}: {kvp.Value}");
            }
        }
    }
}