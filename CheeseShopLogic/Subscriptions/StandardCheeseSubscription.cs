namespace CheeseShopLogic.Subscriptions
{
    public class StandardCheeseSubscription : ISubscription
    {
        public StandardCheeseSubscription(string name, decimal monthlyPrice)
        {
            // e.g French Faves
            _name = name;
            _monthlyPrice = monthlyPrice;
        }

        private string _name { get; set; }
        private decimal _monthlyPrice { get; set; }


        public string Subscribe()
        {
            return $"You have successfully signed up to the standard subscription {_name} for £{_monthlyPrice} per month.";
        }
    }
}
