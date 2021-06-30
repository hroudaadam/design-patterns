using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Prototype
{
    public class Stormtrooper
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public Weapon Weapon { get; set; }

        public Stormtrooper Clone()
        {
            Stormtrooper newStormtrooper = (Stormtrooper)this.MemberwiseClone();
            newStormtrooper.Weapon = this.Weapon.Clone();
            
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
            return (Weapon)this.MemberwiseClone();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
