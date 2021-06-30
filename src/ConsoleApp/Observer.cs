using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Observer
{
    public class Event
    {
        public string Message { get; set; }
        public Event(string message)
        {
            Message = message;
        }
    }

    public interface IObserver
    {
        void Update(Event @event);
    }

    public class ConsoleWriter : IObserver
    {
        private System.ConsoleColor _color;

        public ConsoleWriter(System.ConsoleColor color)
        {
            _color = color;
        }

        public void Update(Event @event)
        {
            var defaultColor = System.Console.ForegroundColor;
            System.Console.ForegroundColor = _color;
            System.Console.WriteLine(@event.Message);
            System.Console.ForegroundColor = defaultColor;
        }
    }

    public class EventSource
    {
        public List<IObserver> Observers { get; set; } = new List<IObserver>();

        public void RegisterObserver(IObserver observer)
        {
            if (!Observers.Contains(observer))
            {
                Observers.Add(observer);
            }
        }

        public void NotifyObservers(Event @event)
        {
            foreach (var observer in Observers)
            {
                observer.Update(@event);
            }
        }
    }
}
