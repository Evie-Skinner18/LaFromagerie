using System;
using System.Collections.Generic;
using System.Text;

namespace CheeseShopLogic.Subscriptions
{
    public interface ISubscription
    {
        string Subscribe();
    }

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


        public string Subscribe()
        {
            return $"You have successfully signed up to the premium subscription {_name} for £{_monthlyPrice} per month.";
        }
    }
}
