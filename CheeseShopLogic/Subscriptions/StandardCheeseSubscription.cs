using CheeseShopLogic.Users;

namespace CheeseShopLogic.Subscriptions
{
    // OBSERVER PATTERN:
    // StandardCheeseSubscription implements the the subject interface (ISubscription) and also has another implmentation of  ISubscription inside it ,e.g subject Subscription
    // subject Subscription has a list of observers inside (e.g list of users)
    public class StandardCheeseSubscription : ISubscription
    {
        public StandardCheeseSubscription(string name, decimal monthlyPrice, ISubscription subjectSubscription)
        {
            // these pieces of data will be observed
            _name = name;
            _monthlyPrice = monthlyPrice;
            _subjectSubscription = subjectSubscription;
        }

        private string _name { get; set; }
        private decimal _monthlyPrice { get; set; }
        private ISubscription _subjectSubscription;


        public string Subscribe()
        {
            return $"You have successfully signed up to the standard subscription {_name} for £{_monthlyPrice} per month.";
        }

        public void ChangeName(string newName)
        {
            _name = newName;
        }

        public void ChangePrice(decimal newPrice)
        {
            _monthlyPrice = newPrice;
        }

        public string GetName()
        {
            return _name;
        }

        public decimal GetPrice()
        {
            return _monthlyPrice;
        }

        public void Attach(IObserver user)
        {
            _subjectSubscription.Attach(user);
        }

        public void Detach(IObserver user)
        {
            _subjectSubscription.Detach(user);
        }

        public void NotifyObservers()
        {
            _subjectSubscription.NotifyObservers();
        }
    }
}
