namespace ConsoleApp.Behavioral.Interpreter;

public static class InterpreterExample
{
    public static void Run()
    {
        Context context = new(
            ("A", false), 
            ("B", true)
        );

        NotExpression expression = new(
            new AndExpression(
                new TerminalVariableExpression("A"),
                new TerminalVariableExpression("B")
            )
        );

        Console.WriteLine(expression.Interpret(context));
    }
}

public class Context
{
    private Dictionary<string, bool> _variables { get; init; } = new();

    public Context(params (string name, bool value)[] variables)
    {
        foreach (var (name, value) in variables)
        {
            if (!_variables.TryAdd(name, value))
            {
                throw new InvalidOperationException("Setting variable has failed");
            }
        }
    }

    public bool GetVariable(string name)
    {
        if (!_variables.TryGetValue(name, out bool value)) 
        {
            throw new InvalidOperationException("Variable does not exists in the given context");
        }
        return value;
    }
}

public interface IBoolExpression
{
    bool Interpret(Context ctx);
}

public interface IUnaryExpression : IBoolExpression
{
    IBoolExpression Expression { get; set; }
}

public interface IBinaryExpression : IBoolExpression
{
    IBoolExpression LeftExpression { get; set; }
    IBoolExpression RightExpression { get; set; }
}

public class TerminalVariableExpression : IBoolExpression
{
    public string VariableName { get; set; }

    public TerminalVariableExpression(string variableName)
    {
        VariableName = variableName;
    }

    public bool Interpret(Context ctx)
    {
        return ctx.GetVariable(VariableName);
    }
}

public class TerminalValueExpression : IBoolExpression
{
    public bool Value { get; set; }

    public TerminalValueExpression(bool value)
    {
        Value = value;
    }

    public bool Interpret(Context _)
    {
        return Value;
    }
}

public class NotExpression : IUnaryExpression
{
    public IBoolExpression Expression { get; set; }

    public NotExpression(IBoolExpression expression)
    {
        Expression = expression;
    }

    public bool Interpret(Context ctx)
    {
        return !Expression.Interpret(ctx);
    }
}

public class AndExpression : IBinaryExpression
{
    public IBoolExpression LeftExpression { get; set; }
    public IBoolExpression RightExpression { get; set; }

    public AndExpression(IBoolExpression leftExpression, IBoolExpression rightExpression)
    {
        LeftExpression = leftExpression;
        RightExpression = rightExpression;
    }

    public bool Interpret(Context ctx)
    {
        return LeftExpression.Interpret(ctx) && RightExpression.Interpret(ctx);
    }
}

public class OrExpression : IBinaryExpression
{
    public IBoolExpression LeftExpression { get; set; }
    public IBoolExpression RightExpression { get; set; }

    public OrExpression(IBoolExpression leftExpression, IBoolExpression rightExpression)
    {
        LeftExpression = leftExpression;
        RightExpression = rightExpression;
    }

    public bool Interpret(Context ctx)
    {
        return LeftExpression.Interpret(ctx) || RightExpression.Interpret(ctx);
    }
}