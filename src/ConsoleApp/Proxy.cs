using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Proxy
{
    public interface IInternet
    {
        void Connect(string host);
    }

    public class RealInternet : IInternet
    {
        public string MyIp { get; set; }

        public void Connect(string host)
        {
            Console.WriteLine($"Connecting to {host}");
        }
    }

    public class ProxyInternet : IInternet
    {
        private readonly RealInternet _internet;
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
}
