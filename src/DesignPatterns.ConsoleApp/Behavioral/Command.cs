namespace DesignPatterns.ConsoleApp.Behavioral.Command;
public static class CommandExample
{
    public static void Run()
    {
        new Button().LifeCycle();
    }
}

// command
public interface ICommand
{
    void Execute();
}

// concrete command 1
public class OnCreatedCommand : ICommand
{
    private readonly string _name;

    public OnCreatedCommand(string name)
    {
        _name = name;
    }

    public void Execute()
    {
        Console.WriteLine($"{_name} was created");
    }
}

// concrete command 2
public class BeforeDestroyCommand : ICommand
{
    private readonly string _name;

    public BeforeDestroyCommand(string name)
    {
        _name = name;
    }

    public void Execute()
    {
        Console.WriteLine($"{_name} is going to be destroyed");
    }
}

// ivoker
public abstract class Component
{
    protected string _definition = "";
    protected ICommand _onCreated;
    protected ICommand _beforeDestroy;


    public void LifeCycle()
    {
        Create();
        if (_onCreated != null) _onCreated.Execute();
        Render();
        if (_beforeDestroy != null) _beforeDestroy.Execute(); 
        Destroy();
    }

    protected void Create()
    {
        Console.WriteLine($"Creating {GetType().Name}");
    }

    private void Render()
    {
        Console.WriteLine($"Rendering {GetType().Name}");
    }

    private void Destroy()
    {
        Console.WriteLine($"Destroying {GetType().Name}");
    }
}

// concrete invoker
public class Button : Component
{
    public Button()
    {
        _onCreated = new OnCreatedCommand(GetType().Name);
        _beforeDestroy = new BeforeDestroyCommand(GetType().Name);
    }
}
