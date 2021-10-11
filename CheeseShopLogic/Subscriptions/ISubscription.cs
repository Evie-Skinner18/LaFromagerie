namespace CheeseShopLogic.Subscriptions;

public interface ISubscription
{
    string Subscribe();

    /// <exception cref="System.NotImplementedException"></exception>
    void Attach(IObserver observer);

    /// <exception cref="System.NotImplementedException"></exception>
    void Detach(IObserver observer);

    /// <exception cref="System.NotImplementedException"></exception>
    void NotifyObservers();
}