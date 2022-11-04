namespace DesignPatterns.ConsoleApp.Creational.Singleton;

public static class SingletonExample
{
    public static void Run()
    {
        Singleton singleton = Singleton.GetInstance();
        Singleton singleton1 = Singleton.GetInstance();

        Console.Write("singleton  ID: ");
        Console.WriteLine(singleton.Id);

        Console.Write("singleton1 ID: ");
        Console.WriteLine(singleton1.Id);
    }
}

public class Singleton
{
    public Guid Id { get; }
    private Singleton()
    {
        Id = Guid.NewGuid();
    }

    private static Singleton _instance;

    public static Singleton GetInstance()
    {
        if (_instance == null)
        {
            _instance = new Singleton();
        }
        return _instance;
    }
}
