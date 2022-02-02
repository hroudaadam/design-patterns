namespace ConsoleApp.Behavioral.Observer;

public static class ObserverExample
{
    public static void Run()
    {
        EventSource eventSource = new();
        eventSource.RegisterObserver(new ConsoleWriter(ConsoleColor.Red));
        eventSource.RegisterObserver(new ConsoleWriter(ConsoleColor.Blue));
        eventSource.RegisterObserver(new ConsoleWriter(ConsoleColor.Yellow));

        Console.Write("Pass message: ");
        string message = Console.ReadLine();
        Console.Clear();
        eventSource.NotifyObservers(new Event(message));
    }
}

public class Event
{
    public string Message { get; set; }
    public Event(string message)
    {
        Message = message;
    }
}

// abstract observer
public interface IObserver
{
    void Update(Event @event);
}

// concrete observer
public class ConsoleWriter : IObserver
{
    private readonly ConsoleColor _color;

    public ConsoleWriter(ConsoleColor color)
    {
        _color = color;
    }

    public void Update(Event @event)
    {
        var defaultColor = Console.ForegroundColor;
        Console.ForegroundColor = _color;
        Console.WriteLine(@event.Message);
        Console.ForegroundColor = defaultColor;
    }
}

// subject
public class EventSource
{
    public List<IObserver> Observers { get; set; } = new List<IObserver>();

    public void RegisterObserver(IObserver observer)
    {
        if (!Observers.Contains(observer))
        {
            Observers.Add(observer);
        }
    }

    public void NotifyObservers(Event @event)
    {
        foreach (var observer in Observers)
        {
            observer.Update(@event);
        }
    }
}
