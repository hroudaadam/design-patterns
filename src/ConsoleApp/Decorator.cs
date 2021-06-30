using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Decorator
{
    public interface ISandwich
    {
        string GetIngredients();
        double GetPrice();
    }

    public class BasicSandwich : ISandwich
    {
        public string GetIngredients()
        {
            return "Basic sandwich";
        }

        public double GetPrice()
        {
            return 50d;
        }
    }

    public class RusticSandwich : ISandwich
    {
        public string GetIngredients()
        {
            return "Rustic sandwich";
        }

        public double GetPrice()
        {
            return 60d;
        }
    }

    public class BeefSandwich : ISandwich
    {
        private readonly ISandwich _sandwich;

        public BeefSandwich(ISandwich sandwich)
        {
            _sandwich = sandwich;
        }

        public string GetIngredients()
        {
            return _sandwich.GetIngredients() + " + Beef";
        }

        public double GetPrice()
        {
            return _sandwich.GetPrice() + 10;
        }
    }

    public class MozzarelaSandwich : ISandwich
    {
        private readonly ISandwich _sandwich;

        public MozzarelaSandwich(ISandwich sandwich)
        {
            _sandwich = sandwich;
        }

        public string GetIngredients()
        {
            return _sandwich.GetIngredients() + " + Mozzarela";
        }

        public double GetPrice()
        {
            return _sandwich.GetPrice() + 5;
        }
    }

    public class TomatoSandwich : ISandwich
    {
        private readonly ISandwich _sandwich;

        public TomatoSandwich(ISandwich sandwich)
        {
            _sandwich = sandwich;
        }

        public string GetIngredients()
        {
            return _sandwich.GetIngredients() + " + Tomatoes";
        }

        public double GetPrice()
        {
            return _sandwich.GetPrice() + 7;
        }
    }
}
