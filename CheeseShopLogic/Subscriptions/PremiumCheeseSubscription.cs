namespace CheeseShopLogic.Subscriptions
{
    public class PremiumCheeseSubscription : ISubscription
    {
        public PremiumCheeseSubscription(string name, decimal monthlyPrice)
        {
            // something like Ultimate Smelly Bundle
            _name = name;
            _monthlyPrice = monthlyPrice;
        }

        private string _name { get; set; }
        private decimal _monthlyPrice { get; set; }

        public void ChangeName(string newName)
        {
            throw new System.NotImplementedException();
        }

        public void ChangePrice(decimal newPrice)
        {
            throw new System.NotImplementedException();
        }

        public string GetName()
        {
            throw new System.NotImplementedException();
        }

        public decimal GetPrice()
        {
            throw new System.NotImplementedException();
        }

        public string Subscribe()
        {
            return $"You have successfully signed up to the premium subscription {_name} for £{_monthlyPrice} per month.";
        }
    }
}
