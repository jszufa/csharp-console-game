using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    internal interface IMapService
    {
        public void HandleCommand(string input, Level level, Game game);
        public void PrintControlsMessage();
        public bool ValidateCommand(char commandInput);
    }
}
