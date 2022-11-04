namespace DesignPatterns.ConsoleApp.Creational.Factory;

public static class FactoryExample
{
    public static void Run()
    {
        IButton button = ButtonFactory.Create(SystemType.Linux);
        button.Render();
    }
}

// abstract product
public interface IButton
{
    void Render();
}

// concrete product 1
public class WindowsButton : IButton
{
    public void Render()
    {
        Console.WriteLine("Rendering Windows button");
    }
}

// concrete product 2
public class LinuxButton : IButton
{
    public void Render()
    {
        Console.WriteLine("Rendering Linux button");
    }
}

public enum SystemType
{
    Windows,
    Linux
}

// factory
public static class ButtonFactory
{
    public static IButton Create(SystemType systemType)
    {
        return systemType switch
        {
            SystemType.Windows => new WindowsButton(),
            SystemType.Linux => new LinuxButton(),
            _ => throw new InvalidOperationException("Unsupported system type"),
        };
    }
}
