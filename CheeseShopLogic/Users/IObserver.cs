namespace CheeseShopLogic.Users;

public interface IObserver
{
    string Name {get; set;}

    void Update(string latestUpdateMessage);
    string GetUpdateMessage();
}
