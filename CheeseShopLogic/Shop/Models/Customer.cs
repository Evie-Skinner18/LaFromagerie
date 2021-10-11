namespace CheeseShopLogic.Shop.Models
{
    public class Customer
    {
        public string Name { get; set; }
        public Cart Cart { get; set; }

        public Customer(string name)
        {
            Name = name;
            Cart = new Cart();
        }

        public void AddCheeseToCart(CheeseType type, int number)
        {
            for (var i = 0; i < number; i++)
            {
                Cart.Cheeses.Add(type);
            }
        }
    }
}