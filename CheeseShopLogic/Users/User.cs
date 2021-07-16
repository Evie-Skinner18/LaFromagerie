using CheeseShopLogic.Subscriptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CheeseShopLogic.Users
{
    public class User
    {
        public User(string name, ISubscription subscription, string language)
        {
            Name = name;
            Subscription = subscription;
            Language = language;
        }

        public string Name { get; set; }
        public ISubscription Subscription { get; set; }
        public string Language { get; set; }
        // we can recommend a cheese box subscription based on user's preferences
        private List<string> _flavourPreferences { get; set; }
        private CheeseType _favouriteCheese { get; set; }


        public static User Create(string name, ISubscription subscription, string country)
        {
            var user = new User(name, subscription, country);
            return user;
        }

        public void AddFlavourPreference(string flavourPreference)
        {
            _flavourPreferences.Add(flavourPreference);
        }

        public List<string> GetFlavourPreferences()
        {
            return _flavourPreferences;
        }

        public void AddFavouriteCheese(CheeseType cheese)
        {
            _favouriteCheese = cheese;
        }

        public CheeseType GetFavouriteCheese()
        {
            return _favouriteCheese;
        }
    }
}
