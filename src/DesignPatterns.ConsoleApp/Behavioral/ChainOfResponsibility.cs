namespace DesignPatterns.ConsoleApp.Behavioral.ChainOfResponsibility;

public class ChainOfResponsibilityExample
{
    public static void Run()
    {
        IHandlerPipeline pipeline = new HandlerPipeline();
        pipeline.AddHandler(new LoggerHandler());
        pipeline.AddHandler(new GlobalErrorHandler());
        pipeline.AddHandler(new ActionHandler());

        pipeline.Run(new HandlerContext(""));
        pipeline.Run(new HandlerContext("hello"));
    }
}

public interface IHandlerContext
{
    string Message { get; set; }
}

public class HandlerContext : IHandlerContext
{
    public string Message { get; set; }

    public HandlerContext(string message)
    {
        Message = message;
    }
}

public interface IHandler
{
    IHandlerContext Handle(IHandlerContext handlerContext);
    void SetNext(IHandler handler);
}

public abstract class Handler : IHandler
{
    private IHandler _next;
    protected IHandlerContext _handlerContext;

    protected IHandlerContext Next()
    {
        if (_next == null)
        {
            return _handlerContext;
        }
        return _next.Handle(_handlerContext);
    }

    public IHandlerContext Handle(IHandlerContext handlerContext)
    {
        _handlerContext = handlerContext;
        Handle();
        return _handlerContext;
    }

    protected abstract void Handle();

    public void SetNext(IHandler handler)
    {
        _next = handler;
    }
}

public class GlobalErrorHandler : Handler
{
    protected override void Handle()
    {
        try
        {
            Next();
        }
        catch (Exception ex)
        {
            _handlerContext.Message = $"ERROR: {ex.Message}";
        }
    }
}

public class LoggerHandler : Handler
{
    protected override void Handle()
    {
        Next();
        Console.WriteLine(_handlerContext.Message);
    }
}

public class ActionHandler : Handler
{
    protected override void Handle()
    {
        if (string.IsNullOrWhiteSpace(_handlerContext.Message))
        {
            throw new Exception("Received message is empty");
        }
        _handlerContext.Message = $"Received message is: {_handlerContext.Message}";

        Next();
    }
}

public interface IHandlerPipeline
{
    IHandlerPipeline AddHandler(IHandler handler);
    IHandlerContext Run(IHandlerContext handlerContext);
}

public class HandlerPipeline : IHandlerPipeline
{
    private IHandler _firstHandler;
    private IHandler _lastHandler;

    public IHandlerPipeline AddHandler(IHandler handler)
    {
        if (_firstHandler == null)
        {
            _firstHandler = handler;
            _lastHandler = handler;
        }
        _lastHandler.SetNext(handler);
        _lastHandler = handler;

        return this;
    }

    public IHandlerContext Run(IHandlerContext handlerContext)
    {
        return _firstHandler.Handle(handlerContext);
    }
}