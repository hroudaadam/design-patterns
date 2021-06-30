using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Builder
{
    public enum SandwichType
    {
        Basic,
        Rustic
    }

    public class Sandwich
    {
        public SandwichType Type { get; set; }
        public bool Beef { get; set; }
        public bool Cheese { get; set; }

        public override string ToString()
        {
            string beefString = Beef ? "beef " : "";
            string cheeseString = Cheese ? "with cheese" : "";
            return $"{Type.ToString()} {beefString}sandwich {cheeseString}";
        }
    }

    public class SandwichBuilder
    {
        private SandwichType _type = SandwichType.Basic;
        private bool _beef = false;
        private bool _cheese = false;

        public SandwichBuilder SetType(SandwichType type)
        {
            _type = type;
            return this;
        }

        public SandwichBuilder WithBeef()
        {
            _beef = true;
            return this;
        }

        public SandwichBuilder WithCheese()
        {
            _cheese = true;
            return this;
        }

        public Sandwich Build()
        {
            return new Sandwich()
            {
                Type = _type,
                Beef = _beef,
                Cheese = _cheese
            };
        }
    }
}
