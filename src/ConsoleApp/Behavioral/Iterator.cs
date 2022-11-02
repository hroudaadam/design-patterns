namespace ConsoleApp.Behavioral.Iterator;
internal static class IteratorExample
{
    public static void Run()
    {
        Container<int> container = new();
        for (int i = 1; i <= 10; i++)
        {
            container.Add(i);
        }
        var iterator = container.GetIterator();
        while (iterator.HasMore())
        {
            Console.WriteLine(iterator.GetNext());
        }
    }
}

// iterable structure
public interface IIterableContainer<T>
{
    IIterator<T> GetIterator();
}

// iterator
public interface IIterator<T>
{
    T GetNext();
    bool HasMore();
}

// concrete iterable structure 
public class Container<T> : IIterableContainer<T>
{
    private readonly IList<T> _values = new List<T>();

    public void Add(T value)
    {
        _values.Add(value);
    }

    public IIterator<T> GetIterator()
    {
        return new ContainerIterator(this);
    }

    // concrete iterator
    private class ContainerIterator : IIterator<T>
    {
        private readonly Container<T> _container;
        private int _index = 0;

        public ContainerIterator(Container<T> container)
        {
            _container = container;
        }

        public T GetNext()
        {
            if (HasMore())
            {
                return _container._values[_index++];
            }
            throw new InvalidOperationException("Container has no more items");
        }

        public bool HasMore()
        {
            return _index < _container._values.Count();
        }
    }
}
