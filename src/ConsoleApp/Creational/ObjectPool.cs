namespace ConsoleApp.Creational.ObjectPool;

public static class ObjectPoolExample
{
    public static void Run()
    {
        Connection connection1 = Pool.Get();
        Connection connection2 = Pool.Get();
        Connection connection3;
        try
        {
            connection3 = Pool.Get();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        // set temp data
        connection2.TempData = "Hello world";
        Pool.Release(connection2);
        connection3 = Pool.Get();

        // null again
        Console.WriteLine(connection3.TempData);
    }
}


public static class Pool
{
    private static readonly List<Connection> _available = CreateConnections().ToList();
    private static readonly List<Connection> _inUse = new();

    public static Connection Get()
    {
        if (_available.Count > 0)
        {
            var pooledObject = _available[0];
            _available.RemoveAt(0);
            _inUse.Add(pooledObject);

            return pooledObject;
        }
        else
        {
            throw new InvalidOperationException("Object pool is empty");
        }
    }

    public static void Release(Connection connection)
    {
        _inUse.Remove(connection);
        CleanUp(connection);
        _available.Add(connection);
    }

    private static void CleanUp(Connection connection)
    {
        connection.TempData = null;
    }

    private static IEnumerable<Connection> CreateConnections()
    {
        for (int i = 0; i < 2; i++)
        {
            yield return new Connection();
        }
    }
}

public class Connection
{
    public Guid ConnectionId { get; set; } = Guid.NewGuid();
    public DateTimeOffset Created { get; } = DateTimeOffset.UtcNow;
    public string TempData { get; set; }
}
