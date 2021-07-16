using CheeseShopLogic;
using CheeseShopLogic.Subscriptions;
using CheeseShopLogic.Users;
using System;
using System.Collections.Generic;

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
            var frenchFavesStartingPrice = frenchFavesSubscription.GetPrice();

            // all three users will have the same cheese subscription
            var frenchUser = User.Create("Yoann", "francais", frenchFavesStartingPrice);
            var moammarqadhafi = User.Create("Moammar Qadhafi", "Arabic", frenchFavesStartingPrice);
            var nileRodgers = User.Create("Nile Rodgers", "English", frenchFavesStartingPrice);

            var users = new List<User>() { frenchUser, moammarqadhafi, nileRodgers };

            foreach (var user in users)
            {
                Console.WriteLine($"Hiya {user.Name}! We have set up your initial billing price. {subscribeMessage}");
            }

            // who are the ones to notify about changes? who's observing?
            Console.WriteLine("Attaching users to the list of observers...");
            foreach (var user in users)
            {
                frenchFavesSubscription.Attach(user);
            }

            // oh no, the price it takes for the business to produce this cheese box has gone up! Bloody Brexit.
            frenchFavesSubscription.ChangeCostToProduce(12.0m);

            // subscribers receive the notification behind the scenes
            foreach (var user in users)
            {
                var notification = user.GetUpdateMessage();
                Console.WriteLine($"Hey {user.Name}! Your {frenchFavesSubscription.GetName()} has changed. {notification}");
            }

            // OBSERVER
            // I have subscribers/customers       
            //  when a subscription changes
            // the users need to be notified
            // so they can update themselves and keep their cheese preferences relevant

            // STRATEGY
            // users can order individual cheese boxes
            // inside an order, the behaviour for assembling a cheese box is deferrred to an ICheeseBoxAssembly
            // all orders assemble cheese boxes but an order has nothing to do with how its cheese box gets assembled
            Console.WriteLine("Time to show you the other side of La Fromagerie: the cheese shop! Order a specially selected one-off cheese box and we will send it to you right away :->");
            Order cheddarSelectionBox = 


            // Yoann's order for the Creamy Delights cheese box will go to a cooler country: France. This means we need a 
            // cheese box assembly algorithm that will assemble it in the normal packaging
            // Gaddafi wants his Paneer Selection cheese box delivered to Libya so he will need a cheese assembly algorithm that will
            // assemble it with a special cooling layer

        }
    }
}
