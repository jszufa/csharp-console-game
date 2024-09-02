
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    public interface ILevelFactory
    {
        Level CreateLevel(string label, int mapHeight);
        Level LoadLevel(GameState.SimpleLevel loadedLevel, int mapHeight);
    }
}
