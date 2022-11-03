namespace ConsoleApp.Behavioral.TemplateMethod;

public static class TemplateMethodExample
{
    public static void Run()
    {
        new Button().LifeCycle();
    }
}

// template method
public abstract class Component
{
    protected string _definition = "";

    public void LifeCycle()
    {
        Create();
        OnCreated();
        Render();
        BeforeDestroy();
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

    protected abstract void BeforeDestroy();
    protected abstract void OnCreated();
}

public class Button : Component
{
    public Button()
    {
    }

    protected override void OnCreated()
    {
        Console.WriteLine("OnCreated hook fired");
    }

    protected override void BeforeDestroy()
    {
        Console.WriteLine("BeforeDestroy hook fired");
    }
}
