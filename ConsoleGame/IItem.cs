using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    internal interface IItem
    {
        void NewPosition(char[][] map, Coordinates position, char symbol);
        void ClearPosition(char[][] map, Coordinates position);
        Coordinates CheckRoad(char command, Coordinates position);

    }
}
