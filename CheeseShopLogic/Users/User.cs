using CheeseShopLogic.Subscriptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CheeseShopLogic.Users
{
    public class User : IObserver
    {
        // OBSERVER PATTERN:
        // an observer object who is interested in the subject
        public User(string name, string language)
        {
            Name = name;
            Language = language;
        }

        public string Name { get; set; }
        public string Language { get; set; }
        // we can recommend a cheese box subscription based on user's preferences
        private List<string> _flavourPreferences { get; set; }
        private CheeseType _favouriteCheese { get; set; }


        public static User Create(string name, string language)
        {
            var user = new User(name, language);
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

        public void Update()
        {
            // e.g update their monthly billing amount we will email them
            // update their loyalty points/discounts
            throw new NotImplementedException();
        }
    }
}
