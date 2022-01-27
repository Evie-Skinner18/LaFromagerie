namespace CheeseShopLogic.Subscriptions;

public class SubjectSubscription : ISubscription
{
    private List<IObserver> _observers = new();

    public void Attach(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        _observers.Remove(observer);
    }

    public void NotifyObservers(string latestUpdateMessage)
    {
        foreach (var observer in _observers)
        {
            observer.Update(latestUpdateMessage);
        }
    }

    public string Subscribe()
    {
        return "Hello from the Subject Subscription!";
    }

    public List<IObserver> GetObservers()
    {
        return _observers;
    }
}