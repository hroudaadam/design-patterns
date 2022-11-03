namespace ConsoleApp.Behavioral.Visitor;
public static class VisitorExample
{
    public static void Run()
    {
        IComputerPartVisitor visitor = new ComputerPartVisitor();
        IVisitableComputerPart computer = new Computer();
        computer.Accept(visitor);
    }
}

// visitor
public interface IComputerPartVisitor
{
    public void Visit(IVisitableComputerPart computerPart);
}

// elemment
public interface IVisitableComputerPart
{
    public void Accept(IComputerPartVisitor visitor);  
}

// concrete visitor
public class ComputerPartVisitor : IComputerPartVisitor
{
    public void Visit(IVisitableComputerPart computerPart)
    {
        string message = computerPart switch
        {
            Computer => "Visiting computer",
            Memory => "Visiting memory",
            Processor => "Visiting processor",
            _ => ""
        };

        Console.WriteLine(message);
    }
}

public class Computer : IVisitableComputerPart
{
    private readonly Memory _memory = new();
    private readonly Processor _processor = new();

    public void Accept(IComputerPartVisitor visitor)
    {
        visitor.Visit(this);
        visitor.Visit(_memory);
        visitor.Visit(_processor);
    }
}

public class Memory : IVisitableComputerPart
{
    public void Accept(IComputerPartVisitor visitor)
    {
        visitor.Visit(this);
    }
}

public class Processor : IVisitableComputerPart
{
    public void Accept(IComputerPartVisitor visitor)
    {
        visitor.Visit(this);
    }
}