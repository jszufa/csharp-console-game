using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    internal class ConsoleHandlerImpl : IConsoleHandler
    {
        public void DisplayOutput(string output)
        {
            Console.Write(output);
        }

        public void DisplayOutputEmptyLn()
        {
            Console.WriteLine();
        }

        public void DisplayOutputLn(string output)
        {
            Console.WriteLine(output);
        }

        public string ReadInput()
        {
            var input = Console.ReadLine();
            return input ?? "";
        }
    }

}
