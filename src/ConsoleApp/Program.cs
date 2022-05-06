using ConsoleApp.Behavioral.Observer;
using ConsoleApp.Behavioral.State;
using ConsoleApp.Behavioral.Strategy;
using ConsoleApp.Creational.AbstractFactory;
using ConsoleApp.Creational.Builder;
using ConsoleApp.Creational.Factory;
using ConsoleApp.Creational.ObjectPool;
using ConsoleApp.Creational.Prototype;
using ConsoleApp.Creational.Singleton;
using ConsoleApp.Structural.Adapter;
using ConsoleApp.Structural.Decorator;
using ConsoleApp.Structural.Facade;
using ConsoleApp.Structural.Proxy;

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

        Console.ReadKey();
    }
}
