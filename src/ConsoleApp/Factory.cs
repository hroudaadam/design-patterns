using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Factory
{
    public interface IButton
    {
        void Render();
    }

    public class WinButton : IButton
    {
        public void Render()
        {
            Console.WriteLine("Rendering Windows button");
        }
    }

    public class LinuxButton : IButton
    {
        public void Render()
        {
            Console.WriteLine("Rendering Linux button");
        }
    }

    public enum SystemType
    {
        Windows, 
        Linux
    }

    public static class ButtonFactory
    {
        public static IButton Create(SystemType systemType)
        {
            switch (systemType)
            {
                case SystemType.Windows:
                    return new WinButton();
                case SystemType.Linux:
                    return new LinuxButton();
                default:
                    throw new InvalidOperationException("Unsupported system type");
            }
        }
    }
}
