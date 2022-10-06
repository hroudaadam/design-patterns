namespace ConsoleApp;

class Program
{
    static void Main()
    {
        SingletonExample.Run();
        AbstractFactoryExample.Run();
        FactoryExample.Run();
        BuilderExample.Run();
        PrototypeExample.Run();
        AdapterExample.Run();
        DecoratorExample.Run();
        ProxyExample.Run();
        ObjectPoolExample.Run();
        ObserverExample.Run();
        StateExample.Run();
        StrategyExample.Run();
        FacadeExample.Run();
        CompositeExample.Run();

        Console.ReadKey();
    }
}
