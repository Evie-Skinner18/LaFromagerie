using CheeseShopLogic;
using CheeseShopLogic.Subscriptions;
using CheeseShopLogic.Users;
using System;

namespace CheeseShopUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenue a la fromagerie! We're your friendly Cheese-as-a-service (ChaaS).");

            StandardCheeseSubscription frenchFavesSubscription = new StandardCheeseSubscription("French Faves", 10.0m);
            var subscribeMessage = frenchFavesSubscription.Subscribe();
            var frenchUser = User.Create("Yoann", frenchFavesSubscription, "francais");

            Console.WriteLine($"Bonjour {frenchUser.Name}. {subscribeMessage}");
            Console.WriteLine("What is your fave cheese?");

            CheeseType cheese = new CheeseType();

            var faveCheeseName = Console.ReadLine();
            cheese.Name = faveCheeseName.Trim();
            Console.WriteLine("What is its strength out of 5?");
            var strength = Console.ReadLine();
            int convertedStrength = Int32.Parse(strength.Trim());
            cheese.Strength = convertedStrength;
            Console.WriteLine("What is its country of origin?");
            var country = Console.ReadLine();
            cheese.CountryOfOrigin = country.Trim();

            cheese.SetPrice();

            frenchUser.AddFavouriteCheese(cheese);
            CheeseType faveCheeseAdded = frenchUser.GetFavouriteCheese();
            Console.WriteLine($"Thank you! We have added {faveCheeseAdded.Name} as your fave. It costs £{faveCheeseAdded.GetPrice()}.");



            // subscribers pay £10 a month for a box of assorted cheese

            // OBSERVER
            // I have subscribers/customers
            // when the flavour/smell/price of a cheese type changes, the subscription plans need to be notified of that change
            // so they can update themselves
            // this ensures that they keep their prices relevant
            // or when a subscription changes
            // the users need to be notified
            // so they can update themselves and keep their cheese preferences relevant

        }
    }
}
