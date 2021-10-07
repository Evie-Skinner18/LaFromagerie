namespace CheeseShopLogic.Subscriptions;

public interface ISubscription
{
    string Subscribe();
    void Attach(IObserver observer);
    void Detach(IObserver observer);
    void NotifyObservers();
}