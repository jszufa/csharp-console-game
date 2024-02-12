using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    internal class Coordinates
    {
        int x;
        int y;

        public Coordinates(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        //copy constructor
        public Coordinates(Coordinates coordinatesToCopy)
        {
            x = coordinatesToCopy.x;
            y = coordinatesToCopy.y;
        }
    }
}
