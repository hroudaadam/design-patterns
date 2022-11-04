namespace DesignPatterns.ConsoleApp.Structural.Decorator;

public static class DecoratorExample
{
    public static void Run()
    {
        var rusticSandwich = new RusticSandwich();
        var beefSandwich = new BeefSandwich(rusticSandwich);
        var mozzarelaSandwich = new MozzarelaSandwich(beefSandwich);
        var tomatoSandwich = new TomatoSandwich(mozzarelaSandwich);

        Console.Write("Ingredients: ");
        Console.WriteLine(tomatoSandwich.GetIngredients());
        Console.Write("Price: ");
        Console.WriteLine(tomatoSandwich.GetPrice());
    }
}

public interface ISandwich
{
    string GetIngredients();
    double GetPrice();
}

// concrete component 1
public class BasicSandwich : ISandwich
{
    public string GetIngredients()
    {
        return "Basic sandwich";
    }

    public double GetPrice()
    {
        return 50d;
    }
}

// concrete component 2
public class RusticSandwich : ISandwich
{
    public string GetIngredients()
    {
        return "Rustic sandwich";
    }

    public double GetPrice()
    {
        return 60d;
    }
}

// decorator 1
public class BeefSandwich : ISandwich
{
    private readonly ISandwich _sandwich;

    public BeefSandwich(ISandwich sandwich)
    {
        _sandwich = sandwich;
    }

    public string GetIngredients()
    {
        return _sandwich.GetIngredients() + " + Beef";
    }

    public double GetPrice()
    {
        return _sandwich.GetPrice() + 10;
    }
}

// decorator 2
public class MozzarelaSandwich : ISandwich
{
    private readonly ISandwich _sandwich;

    public MozzarelaSandwich(ISandwich sandwich)
    {
        _sandwich = sandwich;
    }

    public string GetIngredients()
    {
        return _sandwich.GetIngredients() + " + Mozzarela";
    }

    public double GetPrice()
    {
        return _sandwich.GetPrice() + 5;
    }
}

// decorator 3
public class TomatoSandwich : ISandwich
{
    private readonly ISandwich _sandwich;

    public TomatoSandwich(ISandwich sandwich)
    {
        _sandwich = sandwich;
    }

    public string GetIngredients()
    {
        return _sandwich.GetIngredients() + " + Tomatoes";
    }

    public double GetPrice()
    {
        return _sandwich.GetPrice() + 7;
    }
}
