using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    public interface IConsoleHandler
    {
        string ReadInput();

        void DisplayOutput(string output);

        void DisplayOutputLn(string output);

        void DisplayOutputEmptyLn();
    }
}
