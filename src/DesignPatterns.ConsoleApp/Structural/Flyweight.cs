namespace DesignPatterns.ConsoleApp.Structural.Flyweight;

public static class FlyweightExample
{
    public static void Run()
    {
        List<SettingsButton> settingsButtons = new();
        for (int i = 0; i < 100000; i++)
        {
            settingsButtons.Add(new SettingsButton());
        }

        List<CloseButton> closeButtons = new();
        for (int i = 0; i < 100000; i++)
        {
            closeButtons.Add(new CloseButton());
        }
    }
}

public static class IconProvider
{
    private static Dictionary<string, Icon> _cache = new();

    public static Icon GetIcon(string name)
    {
        if (_cache.TryGetValue(name, out var icon))
        {
            return icon;
        }
        icon = new Icon(name);
        _cache.Add(name, icon);
        return icon;
    }
}

public class Icon
{
    static Random Randomizer = new Random();

    private readonly string _name;
    private readonly byte[] _data = new byte[256];

    public Icon(string name)
    {
        _name = name;
    }
}

public abstract class Button
{
    protected readonly Icon _icon;

    protected Button(Icon icon)
    {
        _icon = icon;
    }
}

public class CloseButton : Button
{
    public CloseButton() : base(IconProvider.GetIcon("close"))
    {

    }
}

public class SettingsButton : Button
{
    public SettingsButton() : base(IconProvider.GetIcon("settings"))
    {
    }
}