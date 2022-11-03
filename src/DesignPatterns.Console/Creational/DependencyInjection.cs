namespace ConsoleApp.Creational.DependencyInjection;

public static class DependencyInjectionExample
{
    public static void Run()
    {
        var container = new Container();
        container.Register<IService1, Service1>();
        container.Register<IService2, Service2>();
        container.Register<IService3, Service3>();

        var service1 = container.GetService<IService1>();
        service1.Foo1();
    }
}

// DI container
public class Container
{
    private readonly Dictionary<Type, Func<object>> _registeredTypes = new();

    public void Register<TService, TImpl>() where TImpl: TService
    {
        _registeredTypes.Add(typeof(TService), () => GetService<TImpl>());
    }

    public void Register<TService>(Func<TService> factory)
    {
        _registeredTypes.Add(typeof(TService), () => factory());
    }

    public void RegisterSingleton<TService, TImpl>() where TImpl : TService
    {
        RegisterSingleton<TService>(() => GetService<TImpl>());
    }

    public void RegisterSingleton<TService>(Func<TService> factory)
    {
        var lazy = new System.Lazy<TService>(factory);
        Register(factory);
    }

    public TService GetService<TService>()
    {
        return (TService)GetService(typeof(TService));
    }

    public object GetService(Type serviceType)
    {
        if (_registeredTypes.TryGetValue(serviceType, out var serviceFactory))
        {
            return serviceFactory();
        }

        if (!serviceType.IsAbstract)
        {
            return CreateInstance(serviceType);
        }

        throw new InvalidOperationException($"No registration for type: {serviceType}");
    }

    private object CreateInstance(Type implementationType)
    {
        var ctor = implementationType.GetConstructors().Single();
        var ctorParamsTypes = ctor.GetParameters().Select(p => p.ParameterType);
        var ctorDependencies = ctorParamsTypes.Select(p => GetService(p)).ToArray();
        return Activator.CreateInstance(implementationType, ctorDependencies);
    }
}

public interface IService1
{
    void Foo1();
    void Foo2();
}
public interface IService2
{
    void Foo1();
    void Foo2();
}

public interface IService3
{
    void Foo1();
    void Foo2();
}

public class Service1 : IService1
{
    private readonly IService2 _service2;
    private readonly IService3 _service3;

    public Service1(IService2 service2, IService3 service3)
    {
        _service2 = service2;
        _service3 = service3;
    }

    public void Foo1()
    {
        Console.WriteLine($"{GetType().Name} - Foo1");
        Console.WriteLine("With dependencies");
        _service2.Foo1();
        _service3.Foo1();
    }

    public void Foo2()
    {
        Console.WriteLine($"{GetType().Name} - Foo2");
        Console.WriteLine("With dependencies");
        _service2.Foo2();
        _service3.Foo2();
    }
}

public class Service2 : IService2
{
    private readonly IService3 _service3;

    public Service2(IService3 service3)
    {
        _service3 = service3;
    }

    public void Foo1()
    {
        Console.WriteLine($"{GetType().Name} - Foo1");
        Console.WriteLine("With dependencies");
        _service3.Foo1();
    }

    public void Foo2()
    {
        Console.WriteLine($"{GetType().Name} - Foo2");
        Console.WriteLine("With dependencies");
        _service3.Foo2();
    }
}

public class Service3 : IService3
{
    public void Foo1()
    {
        Console.WriteLine($"{GetType().Name} - Foo1");
    }

    public void Foo2()
    {
        Console.WriteLine($"{GetType().Name} - Foo2");
    }
}