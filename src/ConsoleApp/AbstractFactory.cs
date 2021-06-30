using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.AbstractFactory
{
    public interface IUIFactory
    {
        IButton CreateButton();
    }

    public interface IButton
    {
        void Render();
    }

    public class WinButton : IButton
    {
        public void Render()
        {
            Console.WriteLine("Rendering Windows button...");
        }
    }

    public class LinuxButton : IButton
    {
        public void Render()
        {
            Console.WriteLine("Rendering Linux button...");
        }
    }

    public class LinuxUIFactory : IUIFactory
    {
        public IButton CreateButton()
        {
            return new LinuxButton();
        }
    }

    public class WinUIFactory : IUIFactory
    {
        public IButton CreateButton()
        {
            return new WinButton();
        }
    }
}
