using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.State
{
    public class WriterContext
    {
        private IWriter _writer;
        public WriterContext()
        {
            _writer = new LowerCaseWriter();
        }
        public void SetWriter(IWriter newWriter)
        {
            _writer = newWriter;
        }

        public void Write(string message)
        {
            _writer.Write(message);
        }
    }

    public interface IWriter
    {
        void Write(string message);
    }

    public class LowerCaseWriter : IWriter
    {
        public void Write(string message)
        {
            Console.WriteLine(message.ToLower());
        }
    }

    public class UpperCaseWriter : IWriter
    {
        public void Write(string message)
        {
            Console.WriteLine(message.ToUpper());
        }
    }
}
