using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Adapter
{
    public interface IUsbConnection
    {
        void ConnectUsb();
        void Recharge();
    }

    public interface ILightningConnection
    {
        void ConnectLightning();
        void Recharge();
    }

    public class AndroidPhone : IUsbConnection
    {
        private bool _isConnected = false;

        public void ConnectUsb()
        {
            Console.WriteLine("USB cable is connected");
            _isConnected = true;
        }

        public void Recharge()
        {
            if (_isConnected)
            {
                Console.WriteLine("Android phone is recharging...");
            }
            else
            {
                Console.WriteLine("Connect USB cable first");
            }
        }
    }

    public class ApplePhone : ILightningConnection
    {
        private bool _isConnected = false;

        public void ConnectLightning()
        {
            Console.WriteLine("Lightning cable is connected");
            _isConnected = true;
        }

        public void Recharge()
        {
            if (_isConnected)
            {
                Console.WriteLine("Apple phone is recharging...");
            }
            else
            {
                Console.WriteLine("Connect Lightning cable first");
            }
        }
    }

    public class LightningToUsbAdapter : IUsbConnection
    {
        private readonly ILightningConnection _lightningConnection;
        private bool _isConnected = false;

        public LightningToUsbAdapter(ILightningConnection lightningConnection)
        {
            _lightningConnection = lightningConnection;
            _lightningConnection.ConnectLightning();
        }

        public void ConnectUsb()
        {
            _isConnected = true;
            Console.WriteLine("USB cable is connected");
        }

        public void Recharge()
        {
            if (_isConnected)
            {
                _lightningConnection.Recharge();
            }
            else
            {
                Console.WriteLine("Connect USB cable first.");
            }
        }
    }
}
