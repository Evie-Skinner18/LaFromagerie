namespace CheeseShopLogic.Subscriptions;

/// <summary>
/// OBSERVER PATTERN:
/// StandardCheeseSubscription implements the the subject interface (ISubscription) and also has another implmentation of  ISubscription inside it ,e.g subject Subscription
/// subject Subscription has a list of observers inside (e.g list of users)
/// </summary>
public class StandardCheeseSubscription : ISubscription
{
    public StandardCheeseSubscription(string name, decimal monthlyPrice, ISubscription subjectSubscription)
    {
        // these pieces of data will be observed
        _name = name;
        _monthlyPrice = monthlyPrice;
        _costToProduce = 8.0m;
        _subjectSubscription = subjectSubscription;
    }

    private string _name { get; set; }
    private decimal _monthlyPrice { get; set; }
    private decimal _costToProduce { get; set; }
    private ISubscription _subjectSubscription;


    public string Subscribe()
    {
        return $"You have successfully signed up to the standard subscription {_name} for £{_monthlyPrice} per month. La Fromagerie will notify you if this price changes.";
    }

    public void ChangeName(string newName)
    {
        _name = newName;
        NotifyObservers($"The new name of your subscription is {newName}");
    }

    public void ChangeCostToProduce(decimal newCost)
    {
        _costToProduce = _costToProduce;
        _monthlyPrice += 1.50m;
        NotifyObservers($"Your new monthly price is {_monthlyPrice}");
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

    public void NotifyObservers(string latestUpdateMessage)
    {
        _subjectSubscription.NotifyObservers(latestUpdateMessage);
    }

    public List<IObserver> GetObservers()
    {
        return _subjectSubscription.GetObservers();
    }
}
