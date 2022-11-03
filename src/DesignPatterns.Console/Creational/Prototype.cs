namespace ConsoleApp.Creational.Prototype;

public static class PrototypeExample
{
    public static void Run()
    {
        Stormtrooper stormtrooperPrototype = new()
        {
            Name = "FN2001",
            Level = 20,
            Weapon = new() { Name = "Blaster" }
        };

        Stormtrooper stormtrooper2 = stormtrooperPrototype.Clone();

        Console.WriteLine(stormtrooperPrototype);
        Console.WriteLine(stormtrooper2);

        stormtrooperPrototype.Weapon.Name = "Laser gun";
        Console.WriteLine("\nAfter changes");

        Console.WriteLine(stormtrooperPrototype);
        Console.WriteLine(stormtrooper2);
    }
}

public class Stormtrooper
{
    public string Name { get; set; }
    public int Level { get; set; }
    public Weapon Weapon { get; set; }

    public Stormtrooper Clone()
    {
        Stormtrooper newStormtrooper = (Stormtrooper)MemberwiseClone();
        newStormtrooper.Weapon = Weapon.Clone();

        return newStormtrooper;
    }

    public override string ToString()
    {
        return $"{Name} : {Level} with {Weapon}";
    }
}

public class Weapon
{
    public string Name { get; set; }

    public Weapon Clone()
    {
        return (Weapon)MemberwiseClone();
    }

    public override string ToString()
    {
        return Name;
    }
}
