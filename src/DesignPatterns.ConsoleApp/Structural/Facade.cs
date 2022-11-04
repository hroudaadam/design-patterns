namespace DesignPatterns.ConsoleApp.Structural.Facade;

public static class FacadeExample
{
    public static void Run()
    {
        FacadeSystem facadeSystem = new();
        Console.WriteLine(facadeSystem.Method1());
        Console.WriteLine(facadeSystem.Method2());
        Console.WriteLine(facadeSystem.Method3());
        Console.WriteLine(facadeSystem.Method4());
    }
}

// facade
public class FacadeSystem
{
    private readonly SystemA _systemA = new();
    private readonly SystemB _systemB = new();

    public string Method1() => _systemA.Method1();
    public string Method2() => _systemA.Method2();
    public string Method3() => _systemB.Method3();
    public string Method4() => _systemB.Method4();
}

// subsystem
public class SystemA
{
    public string Method1()
    {
        return "Doing method 1";
    }

    public string Method2()
    {
        return "Doing method 2";
    }
}

// subsystem
public class SystemB
{
    public string Method3()
    {
        return "Doing method 3";
    }

    public string Method4()
    {
        return "Doing method 4";
    }
}
