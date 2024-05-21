Tester.Test();

public interface Channel
{
    public void Attach(INotifiable notifiable);
    public void Detach(INotifiable notifiable);
    public void Notify(string message);
}

public interface INotifiable
{
    void PushNotification(string message);
}

public class User : INotifiable
{
    private string Name { get; set; }
    public User(string name) { Name = name; }
    public void PushNotification(string message)
    {
        Console.WriteLine(message);
    }
}

public class Creator : Channel
{
    List<INotifiable> notifiables;
    public Creator()
    {
        notifiables = new List<INotifiable>();
    }
    public void Attach(INotifiable notifiable) => notifiables.Add(notifiable);
    public void Detach(INotifiable notifiable) => notifiables.Remove(notifiable);
    public void Notify(string message)
    {
        foreach (INotifiable notifiable in notifiables) 
            notifiable.PushNotification(message);
    }
}

public static class Tester
{
    public static void Test()
    {
        Creator creator = new Creator();

        User user1 = new User("Alice");
        User user2 = new User("Bob");

        creator.Attach(user1);
        creator.Attach(user2);

        creator.Notify("New video uploaded!");

        creator.Detach(user1);

        creator.Notify("New live stream starting soon!");
    }
} 