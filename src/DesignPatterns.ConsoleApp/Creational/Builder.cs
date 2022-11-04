namespace DesignPatterns.ConsoleApp.Creational.Builder;

public static class BuilderExample
{
    public static void Run()
    {
        SandwichBuilder builder = new();
        var fullSandwich = builder.SetType("Rustic").WithBeef().WithCheese().Build();
        // reset builder
        builder = new();
        var simpleSandwich = builder.Build();

        Console.WriteLine(fullSandwich);
        Console.WriteLine(simpleSandwich);
    }
}

// product
public class Sandwich
{
    public string Type { get; set; }
    public bool Beef { get; set; }
    public bool Cheese { get; set; }

    public override string ToString()
    {
        string beefString = Beef ? "beef " : "";
        string cheeseString = Cheese ? " with cheese" : "";
        return $"{Type} {beefString}sandwich{cheeseString}";
    }
}

// builder
public class SandwichBuilder
{
    private readonly Sandwich _product = new();

    public SandwichBuilder SetType(string type)
    {
        _product.Type = type;
        return this;
    }

    public SandwichBuilder WithBeef()
    {
        _product.Beef = true;
        return this;
    }

    public SandwichBuilder WithCheese()
    {
        _product.Cheese = true;
        return this;
    }

    public Sandwich Build()
    {
        return _product;
    }
}
