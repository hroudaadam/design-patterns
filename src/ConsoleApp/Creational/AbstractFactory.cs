namespace ConsoleApp.Creational.AbstractFactory;

public static class AbstractFactoryExample
{
    public static void Run()
    {
        string systemType = "Windows";

        IUIFactory uIFactory = systemType switch
        {
            "Windows" => new WinUIFactory(),
            "Linux" => new LinuxUIFactory(),
            _ => throw new InvalidOperationException("Unsupported system type"),
        };

        IButton button;
        button = uIFactory.CreateButton();
        button.Render();
    }
}

// abstract factory
public interface IUIFactory
{
    IButton CreateButton();
}

// concrete factory 1
public class LinuxUIFactory : IUIFactory
{
    public IButton CreateButton()
    {
        return new LinuxButton();
    }
}

// concrete factory 2
public class WinUIFactory : IUIFactory
{
    public IButton CreateButton()
    {
        return new WinButton();
    }
}

// abstract product
public interface IButton
{
    void Render();
}

// concrete product 1
public class LinuxButton : IButton
{
    public void Render()
    {
        Console.WriteLine("Rendering Linux button...");
    }
}

// concrete product 2
public class WinButton : IButton
{
    public void Render()
    {
        Console.WriteLine("Rendering Windows button...");
    }
}
