namespace DesignPatterns.ConsoleApp.Behavioral.State;

public static class StateExample
{
    public static void Run()
    {
        WriterContext ctx = new();
        ctx.Write("Hello");
        ctx.SetWriter(new UpperCaseWriter());
        ctx.Write("bye");
    }
}

// context
public class WriterContext
{
    private IWriter _writer;
    public WriterContext()
    {
        _writer = new LowerCaseWriter();
    }
    public void SetWriter(IWriter newWriter)
    {
        _writer = newWriter;
    }

    public void Write(string message)
    {
        _writer.Write(message);
    }
}

// abstract state
public interface IWriter
{
    void Write(string message);
}

// concrete state
public class LowerCaseWriter : IWriter
{
    public void Write(string message)
    {
        Console.WriteLine(message.ToLower());
    }
}

// concrete state
public class UpperCaseWriter : IWriter
{
    public void Write(string message)
    {
        Console.WriteLine(message.ToUpper());
    }
}
