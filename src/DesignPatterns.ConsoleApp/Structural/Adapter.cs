namespace DesignPatterns.ConsoleApp.Structural.Adapter;

public static class AdapterExample
{
    public static void Run()
    {
        ApplePhone applePhone = new();
        IUsbConnection lightningToUsb = new LightningToUsbAdapter(applePhone);
        lightningToUsb.ConnectUsb();
        lightningToUsb.Recharge();
    }
}

// target interface
public interface IUsbConnection
{
    void ConnectUsb();
    void Recharge();
}

// adaptee interface
public interface ILightningConnection
{
    void ConnectLightning();
    void Recharge();
}

// adaptee concrete class
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

// adapter
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
