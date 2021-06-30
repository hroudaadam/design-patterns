using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.ObjectPool
{
    public static class Pool
    {
        private static List<Connection> _available = CreateConnections().ToList();
        private static List<Connection> _inUse = new List<Connection>();

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


}
