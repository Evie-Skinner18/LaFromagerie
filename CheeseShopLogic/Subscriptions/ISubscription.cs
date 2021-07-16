using CheeseShopLogic.Users;
using System;
using System.Text;

namespace CheeseShopLogic.Subscriptions
{
    public interface ISubscription
    {
        string Subscribe();
        void Attach(IObserver observer);
        void Detach(IObserver observer);
        void NotifyObservers();
    }
}
