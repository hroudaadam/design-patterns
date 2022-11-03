namespace ConsoleApp.Structural.Proxy;

public static class ProxyExample
{
    public static void Run()
    {
        List<string> banned = new() { "www.seznam.cz" };
        ProxyInternet internet = new(banned);
        internet.Connect("www.google.com");
        internet.Connect("www.seznam.cz");
    }
}

// subject
public interface IInternet
{
    void Connect(string host);
}

// real subject
public class RealInternet : IInternet
{
    public string MyIp { get; set; }

    public void Connect(string host)
    {
        Console.WriteLine($"Connecting to {host}");
    }
}

// proxy subject
public class ProxyInternet : IInternet
{
    private readonly IInternet _internet;
    private readonly IEnumerable<string> _bannedHosts;

    public ProxyInternet(IEnumerable<string> bannedHosts)
    {
        _bannedHosts = bannedHosts;
        _internet = new RealInternet();
    }

    public void Connect(string host)
    {
        if (_bannedHosts.Contains(host))
        {
            Console.WriteLine($"Host {host} is banned");
        }
        else
        {
            _internet.Connect(host);
        }
    }
}
