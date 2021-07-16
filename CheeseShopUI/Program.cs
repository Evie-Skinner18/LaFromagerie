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

            // set up the subscription
            SubjectSubscription subjectSubscription = new SubjectSubscription();
            StandardCheeseSubscription frenchFavesSubscription = new StandardCheeseSubscription("French Faves", 10.0m, subjectSubscription);

            var subscribeMessage = frenchFavesSubscription.Subscribe();
            var frenchUser = User.Create("Yoann", "francais");

            // who are the ones to notify about changes? who's observing?
            frenchFavesSubscription.Attach(frenchUser);

            Console.WriteLine($"Bonjour {frenchUser.Name}. {subscribeMessage}");
            
            // change the price of subscription


            // subscribers pay £10 a month for a box of assorted cheese

            // OBSERVER
            // I have subscribers/customers       
            //  when a subscription changes
            // the users need to be notified
            // so they can update themselves and keep their cheese preferences relevant

        }
    }
}
