namespace ConsoleApp.Creational.Lazy;
public static class LazyExample
{
    public static void Run()
    {
        Lazy<int> lazyValue = new(GetNumber);
        Console.WriteLine("Lazy declared");
        Console.WriteLine("Accessing lazy value");
        Console.WriteLine(lazyValue.Value);
    }

    private static int GetNumber()
    {
        Console.WriteLine("Generating number");
        return new Random().Next(1, 100);
    }
}

public class Lazy<T>
{
    private readonly Func<T> _provider;
    private T _value;
    private bool _initialized = false;

    public Lazy(Func<T> provider)
    {
        _provider = provider;
    }

    public T Value
    {
        get 
        { 
            if (!_initialized)
            {
                _value = _provider();
                _initialized = true;
            }
            return _value;
        }
    }
}