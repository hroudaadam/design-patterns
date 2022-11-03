namespace ConsoleApp.Behavioral.Mediator;

public static class MediatorExample
{
    public static void Run()
    {
        IPerson _person1 = new Person("John");
        IPerson _person2 = new Person("Jane");
        new MessageMediator(_person1, _person2);

        _person1.SendMessage(MessageType.Hello);
        _person2.SendMessage(MessageType.Bye);
        _person1.SendMessage(MessageType.HowAreYou);
}
}

public enum MessageType
{
    Hello,
    HowAreYou,
    Bye
}

// mediator
public interface IMessageMediator
{
    void Send(MessageType messageType, IPerson sender);
}

// concrete mediator
public class MessageMediator : IMessageMediator
{
    private readonly IPerson _person1;
    private readonly IPerson _person2;

    public MessageMediator(IPerson person1, IPerson person2)
    {
        _person1 = person1;
        _person1.SetMessageMediator(this);
        _person2 = person2;
        _person2.SetMessageMediator(this);
    }

    public void Send(MessageType messageType, IPerson sender)
    {
        IPerson receiver = sender == _person1 ? _person2 : _person1;

        string message = messageType switch
        {
            MessageType.Hello => "Hey",
            MessageType.HowAreYou => "How you doin\'",
            MessageType.Bye => "See ya",
            _ => "Unknown"
        };

        receiver.ReceiveMessage(message, sender);
    }
}


// component
public interface IPerson
{
    string Name { get; }

    void SetMessageMediator(IMessageMediator messageMediator);
    void SendMessage(MessageType messageType);
    void ReceiveMessage(string message, IPerson sender);
}

// concrete component
public class Person : IPerson
{
    public string Name { get; init; }
    private IMessageMediator _messageMediator;

    public Person(string name)
    {
        Name = name;
    }

    public void SendMessage(MessageType messageType)
    {
        if (_messageMediator == null)
        {
            throw new ArgumentNullException(nameof(_messageMediator));
        }

        _messageMediator.Send(messageType, this);
    }

    public void SetMessageMediator(IMessageMediator messageMediator)
    {
        _messageMediator = messageMediator;
    }

    public void ReceiveMessage(string message, IPerson sender)
    {
        Console.WriteLine($"{this.Name} recieved message: '{message}' from {sender.Name}");
    }
}