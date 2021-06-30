//using ConsoleApp.Factory;
//using ConsoleApp.Singleton;
//using ConsoleApp.AbstractFactory;
//using ConsoleApp.Decorator;
//using ConsoleApp.Builder;
//using ConsoleApp.Prototype;
//using ConsoleApp.ObjectPool;
//using ConsoleApp.Adapter;
//using ConsoleApp.Proxy;
//using ConsoleApp.Observer;
//using ConsoleApp.State;
using ConsoleApp.Strategy;

using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Singleton
            //Singleton singleton = Singleton.GetInstance();
            //Singleton singleton1 = Singleton.GetInstance();

            //Console.Write("singleton  ID: ");
            //Console.WriteLine(singleton.Id);

            //Console.Write("singleton1 ID: ");
            //Console.WriteLine(singleton1.Id);
            #endregion

            #region Decorator
            //RusticSandwich rusticSandwich = new RusticSandwich();
            //BeefSandwich beefSandwich = new BeefSandwich(rusticSandwich);
            //MozzarelaSandwich mozzarelaSandwich = new MozzarelaSandwich(beefSandwich);
            //TomatoSandwich tomatoSandwich = new TomatoSandwich(mozzarelaSandwich);

            //Console.Write("Ingredients: ");
            //Console.WriteLine(tomatoSandwich.GetIngredients());
            //Console.Write("Price: ");
            //Console.WriteLine(tomatoSandwich.GetPrice());
            #endregion

            #region Abstract Factory
            //string systemType = "Windows";
            //IUIFactory uIFactory;

            //switch (systemType)
            //{
            //    case "Windows":
            //        uIFactory = new WinUIFactory();
            //        break;
            //    case "Linux":
            //        uIFactory = new LinuxUIFactory();
            //        break;
            //    default:
            //        throw new InvalidOperationException("Unsupported system type");
            //}

            //uIFactory.CreateButton().Render();

            #endregion

            #region Factory
            //IButton button = ButtonFactory.Create(SystemType.Linux);
            //button.Render();
            #endregion

            #region Builder
            //SandwichBuilder builder = new();
            //var fullSandwich = builder.SetType(SandwichType.Rustic)
            //                          .WithBeef()
            //                          .WithCheese()
            //                          .Build();
            //// reset builder
            //builder = new();
            //var simpleSandwich = builder.Build();

            //Console.WriteLine(fullSandwich);
            //Console.WriteLine(simpleSandwich);

            #endregion

            #region Prototype
            //Stormtrooper stormtrooperPrototype = new()
            //{
            //    Name = "FN2001",
            //    Level = 20,
            //    Weapon = new() { Name = "Blaster" }
            //};

            //Stormtrooper stormtrooper2 = stormtrooperPrototype.Clone();

            //Console.WriteLine(stormtrooperPrototype);
            //Console.WriteLine(stormtrooper2);

            //stormtrooperPrototype.Weapon.Name = "Laser gun";
            //Console.WriteLine("\nAfter changes");

            //Console.WriteLine(stormtrooperPrototype);
            //Console.WriteLine(stormtrooper2);
            #endregion

            #region ObjectPool
            //Connection connection1 = Pool.Get();
            //Connection connection2 = Pool.Get();
            //Connection connection3;
            //try
            //{
            //     connection3 = Pool.Get();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            //// set temp data
            //connection2.TempData = "Hello world";
            //Pool.Release(connection2);
            //connection3 = Pool.Get();

            //// null again
            //Console.WriteLine(connection3.TempData);

            #endregion

            #region Adapter
            //ApplePhone applePhone = new ApplePhone();
            //LightningToUsbAdapter lightningToUsb = new(applePhone);
            //lightningToUsb.ConnectUsb();
            //lightningToUsb.Recharge();
            #endregion

            #region Proxy
            //List<string> banned = new List<string>() { "www.seznam.cz" };
            //ProxyInternet internet = new(banned);
            //internet.Connect("www.google.com");
            //internet.Connect("www.seznam.cz");
            #endregion

            #region Observer
            //EventSource eventSource = new();
            //eventSource.RegisterObserver(new ConsoleWriter(ConsoleColor.Red));
            //eventSource.RegisterObserver(new ConsoleWriter(ConsoleColor.Blue));
            //eventSource.RegisterObserver(new ConsoleWriter(ConsoleColor.Yellow));


            //Console.Write("Pass message: ");
            //string message = Console.ReadLine();
            //Console.Clear();
            //eventSource.NotifyObservers(new Event(message));
            #endregion

            #region State
            //WriterContext ctx = new();
            //ctx.Write("Hello");
            //ctx.SetWriter(new UpperCaseWriter());
            //ctx.Write("bye");
            #endregion

            #region Strategy
            //Cart cart = new(new CashPayment());
            //cart.Pay();
            //cart.Payment = new DebitCardPayment("4556-8554-2134-7546", DateTimeOffset.UtcNow.AddDays(365));
            //cart.Pay();
            #endregion

            Console.ReadKey();
        }
    }
}
