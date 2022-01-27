
// Console.WriteLine("Bienvenue a la fromagerie! We're your friendly Cheese-as-a-service (ChaaS). Let's show you the subscriptions in action.");

// // OBSERVER
// // I have observers/customers
// // when a subscription changes
// // the users of that subscription need to be notified by the subject
// // so they can update themselves and keep their cheese preferences relevant
SubjectSubscription subjectSubscription = new();
StandardCheeseSubscription frenchFavesSubscription = new("French Faves", 10.0m, subjectSubscription);

// var subscribeMessage = frenchFavesSubscription.Subscribe();
var frenchFavesStartingPrice = frenchFavesSubscription.GetPrice();

// // all three users will have the same cheese subscription
var frenchUser = User.Create("Yoann", "francais", frenchFavesStartingPrice);
var italianUser = User.Create("Marco Farrugia", "Italian", frenchFavesStartingPrice);
var nileRodgers = User.Create("Nile Rodgers", "English", frenchFavesStartingPrice);

// List<User> users = new() { frenchUser, italianUser, nileRodgers };

// foreach (var user in users)
//     Console.WriteLine($"Hiya {user.Name}! We have set up your initial billing price. {subscribeMessage}");

// // who are the ones to notify about changes? who's observing?
// Console.WriteLine("Attaching users to the list of observers...");
// foreach (var user in users)
//     frenchFavesSubscription.Attach(user);

// // oh no, the price it takes for the business to produce this cheese box has gone up! Bloody Brexit.
// frenchFavesSubscription.ChangeCostToProduce(12.0m);

// List<IObserver> subscribedUsers = frenchFavesSubscription.GetObservers();

// Console.WriteLine("Sending the update...");
// // subscribers receive the notification behind the scenes
// foreach (var user in subscribedUsers)
// {
//     var notification = user.GetUpdateMessage();
//     Console.WriteLine($"Hey {user.Name}! Your subscription has changed. {notification}");
// }

// Console.WriteLine("Nile has unsubscribed");
// // Nile no longer wants to use our cheese subscription
// frenchFavesSubscription.Detach(nileRodgers);

// Console.WriteLine("Sending another update...");

// frenchFavesSubscription.ChangeName("Frenchie Fancies");

// foreach (var user in subscribedUsers)
// {
//     var notification = user.GetUpdateMessage();
//     Console.WriteLine($"Hey {user.Name}! Your subscription has changed. {notification}");
// }


// STRATEGY
// users can order individual cheese boxes
// inside an order, the behaviour for assembling a cheese box is deferrred to an ICheeseBoxAssembly
// all orders assemble cheese boxes but an order has nothing to do with how its cheese box gets assembled
// Console.WriteLine("Time to show you the other side of La Fromagerie: the cheese shop! Order a specially selected one-off cheese box and we will send it to you right away :->");

var cheddarTypes = new List<CheeseType>()
            {
                CheeseType.Create("Strong Welsh Cheddar", "Wales", 5),
                CheeseType.Create("Mild but Wild", "USA", 2),
                CheeseType.Create("Da Orginal 1 from Cheddar Gorge", "England", 3)
            };

var cheddarSelectionBox = CheeseBox.Create("Cheddar Selection", cheddarTypes);
// this order is going to our French user so we need to give it the NorthernEuropeCheeseAssembly
// from the family of CheeseAssembly algorithms at runtime
NorthernEuropeCheeseAssembly cheeseAssemblyMethodForFrance = new();
var yoannsCheddarSelectionOrder = Order.Create(new Guid(), DateTime.Now, cheeseAssemblyMethodForFrance, frenchUser, cheddarSelectionBox, DeliveryMethod.Standard);

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

// now send the same cheese box to Nile on tour in Libya
NorthAfricaCheeseBoxAssembly cheeseAssemblyMethodForLibya = new();
var nilesCheddarSelectionOrder = Order.Create(new Guid(), DateTime.Now, cheeseAssemblyMethodForLibya, nileRodgers, cheddarSelectionBox, DeliveryMethod.Free);

Console.WriteLine(nilesCheddarSelectionOrder.GetStatusMessage());
Console.WriteLine($"The total cost of your order is {nilesCheddarSelectionOrder.GetTotalCost()}.");

var assemblyMessageForNilessOrder = nilesCheddarSelectionOrder.PerformCheeseBoxAssembly();
Console.WriteLine(assemblyMessageForNilessOrder);

nilesCheddarSelectionOrder.Dispatch();
Console.WriteLine(nilesCheddarSelectionOrder.GetStatusMessage());

// // DECORATOR PATTERN
// Cheese cheese = new CheeseShopLogic.Cheese.SaintNectaire();
// Console.WriteLine("Saint Nectaire: " + cheese.GetPrice());
// cheese = new SixMonth(cheese);
// Console.WriteLine("Saint Nectaire affiné 6 mois " + cheese.GetPrice());



// // FACADE PATTERN USING A BRICK AND MORTAR STORE
// var store = new Store("Cheese Emporium", "USA");
// // Cheese needs to be delivered.
// var cheddar = CheeseType.Create("Wisconsin Cheddar", "USA", 10);
// var brie = CheeseType.Create("Wisconsin Brie", "USA", 2);
// var muenster = CheeseType.Create("Marvelous Muenster", "USA", 1);
// var cheeses = new Dictionary<CheeseType, int>
// {
//     {
//        cheddar, 20
//     },
//     {
//         brie, 10
//     },
//     {
//         muenster, 20
//     },
// };
// store.RestockCheese(cheeses);
// //some customers came in!
// var john = new Customer("Joaquin");
// var mary = new Customer("Mary");

// store.CustomerEnter(john);
// store.CustomerEnter(mary);

// Console.WriteLine($"{john.Name} has {john.Cart.Cheeses?.Count} items in his cart.");
// Console.WriteLine($"{mary.Name} has {mary.Cart.Cheeses?.Count} items in his cart.");

// try
// {
//     john.AddCheeseToCart(cheddar, 2);
//     mary.AddCheeseToCart(brie, 9);
// }
// catch (Exception ex)
// {
//     Console.WriteLine(ex.Message);
// }

// store.PrintStock();
// store.CheckoutCustomer(john);
// Console.WriteLine($"Customers in store: {store.GetCustomerCount()}");
// store.CheckoutCustomer(mary);
// Console.WriteLine($"Customers in store: {store.GetCustomerCount()}");
// store.PrintStock();