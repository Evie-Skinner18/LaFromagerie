using CheeseShopLogic;
using CheeseShopLogic.CheeseBoxes;
using CheeseShopLogic.Infrastructure;
using CheeseShopLogic.Orders;
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
            Console.WriteLine("Bienvenue a la fromagerie! We're your friendly Cheese-as-a-service (ChaaS). Let's show you the subscriptions in action.");

            // OBSERVER
            // I have subscribers/customers       
            //  when a subscription changes
            // the users of that subscription need to be notified
            // so they can update themselves and keep their cheese preferences relevant
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

            // STRATEGY
            // users can order individual cheese boxes
            // inside an order, the behaviour for assembling a cheese box is deferrred to an ICheeseBoxAssembly
            // all orders assemble cheese boxes but an order has nothing to do with how its cheese box gets assembled
            Console.WriteLine("Time to show you the other side of La Fromagerie: the cheese shop! Order a specially selected one-off cheese box and we will send it to you right away :->");

            var cheddarTypes = new List<CheeseType>()
            {
                CheeseType.Create("Strong Welsh Cheddar", "Wales", 5),
                CheeseType.Create("Mild but Wild", "USA", 2),
                CheeseType.Create("Da Orginal 1 from Cheddar Gorge", "England", 3)
            };

            CheeseBox cheddarSelectionBox = CheeseBox.Create("Cheddar Selection", cheddarTypes);
            // this order is going to our French user so we need to give it the NorthernEuropeCheeseAssembly
            // from the family of CheeseAssembly algorithms at runtime
            NorthernEuropeCheeseAssembly cheeseAssemblyMethodForFrance = new NorthernEuropeCheeseAssembly();
            Order yoannsCheddarSelectionOrder = Order.Create(new Guid(), DateTime.Now, cheeseAssemblyMethodForFrance, frenchUser, cheddarSelectionBox, DeliveryMethod.Standard);

            Console.WriteLine(yoannsCheddarSelectionOrder.GetStatusMessage());
            Console.WriteLine($"The total cost of your order is {yoannsCheddarSelectionOrder.GetTotalCost()}.");

            // an order delegates the action of assembling the cheese box to a CheeseAssembly
            // behaviour is encapsulated
            var assemblyMessageForFrenchUsersOrder = yoannsCheddarSelectionOrder.PerformCheeseBoxAssembly();
            Console.WriteLine(assemblyMessageForFrenchUsersOrder);

            yoannsCheddarSelectionOrder.Dispatch();
            Console.WriteLine(yoannsCheddarSelectionOrder.GetStatusMessage());

            yoannsCheddarSelectionOrder.MarkAsDelivered();
            Console.WriteLine(yoannsCheddarSelectionOrder.GetStatusMessage());

            // now send the same cheese box to Gaddafi in Libya
            NorthAfricaCheeseBoxAssembly cheeseAssemblyMethodForLibya = new NorthAfricaCheeseBoxAssembly();
            Order gaddafisCheddarSelectionOrder = Order.Create(new Guid(), DateTime.Now, cheeseAssemblyMethodForLibya, moammarqadhafi, cheddarSelectionBox, DeliveryMethod.Free);

            Console.WriteLine(gaddafisCheddarSelectionOrder.GetStatusMessage());
            Console.WriteLine($"The total cost of your order is {gaddafisCheddarSelectionOrder.GetTotalCost()}.");

            var assemblyMessageForGaddafisOrder = gaddafisCheddarSelectionOrder.PerformCheeseBoxAssembly();
            Console.WriteLine(assemblyMessageForGaddafisOrder);

            gaddafisCheddarSelectionOrder.Dispatch();
            Console.WriteLine(gaddafisCheddarSelectionOrder.GetStatusMessage());
        }
    }
}
