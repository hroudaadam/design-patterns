using System.Collections.ObjectModel;

namespace ConsoleApp.Structural.Composite;

public static class CompositeExample
{
    public static void Run()
    {
        IHasPrice newOrder = new Box(new IHasPrice[] {
            new Product("Banana", 4.2m),
            new Product("Onion", 2.4m),
            new Box(new IHasPrice[] {
                new Product("Apple", 2.7m),
                new Product("Potato", 3.1m),
                new Box(new IHasPrice[]
                {
                    new Product("Cheese", 3.3m)
                }),
                new Box(new IHasPrice[]
                {
                    new Product("Milk", 3.9m)
                }),
            })
        });

        Console.WriteLine($"Total price of the order = {newOrder.GetPrice()}");
    }
}

// component
public interface IHasPrice
{
    decimal GetPrice();
}

// leaf
public class Product : IHasPrice
{
    public string Name { get; init; }
    public decimal Price { get; init; }

    public Product(string name, decimal price)
    {
        Name = name;
        Price = price;
    }

    public decimal GetPrice() => Price;
}

// composite
public class Box : IHasPrice
{
    public IReadOnlyList<IHasPrice> Items { get; init; }

    public Box(IList<IHasPrice> items)
    {
        Items = new ReadOnlyCollection<IHasPrice>(items);
    }

    public decimal GetPrice() => Items.Sum(hp => hp.GetPrice());
}
