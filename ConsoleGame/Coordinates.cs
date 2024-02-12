using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    internal class Coordinates
    {
        //pola są domyślnie private
        int x;
        int y;

        public int X
        {
            get { return x; }
            set { x = value; }
        }
        public int Y 
        {
            get { return y; }
            set { y = value; }
        }


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
