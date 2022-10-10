using System;

namespace ConsoleApp.Structural.Bridge;

public static class BridgeExample
{
    public static void Run()
    {
        var neapolitanResaurant = new NeapolitanRestaurant(new MozzarelaPizza());
        var newYorkResaurant = new NewYorkRestaurant(new GoudaPizza());

        Console.WriteLine(neapolitanResaurant.DeliverPizza().ToString());
        Console.WriteLine(newYorkResaurant.DeliverPizza().ToString());
    }
}

// abstraction
public abstract class Restaurant
{
    protected Pizza _pizza;
    protected Restaurant(Pizza pizza)
    {
        _pizza = pizza;
    }

    protected abstract void MakeCrust();

    public Pizza DeliverPizza()
    {
        MakeCrust();
        return _pizza;
    } 
}

// refined abstraction 1
public class NeapolitanRestaurant : Restaurant
{
    public NeapolitanRestaurant(Pizza pizza) : base(pizza)
    {
    }

    protected override void MakeCrust()
    {
        _pizza.Crust = "thick";
    }
}

// refined abstraction 2
public class NewYorkRestaurant : Restaurant
{
    public NewYorkRestaurant(Pizza pizza) : base(pizza)
    {
    }

    protected override void MakeCrust()
    {
        _pizza.Crust = "thin";
    }
}

// implementation
public abstract class Pizza
{
    public string Crust { get; set; }
    public string Cheese { get; init; }

    public override string ToString()
    {
        return $"{Cheese} pizza with {Crust} crust";
    }
}

// concrete implementation 1
public class MozzarelaPizza : Pizza
{
    public MozzarelaPizza()
    {
        Cheese = "mozzarela";
    }
}

// concrete implementation 2
public class GoudaPizza : Pizza
{
    public GoudaPizza()
    {
        Cheese = "gouda";
    }
}
