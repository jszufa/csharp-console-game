using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    public abstract class Item : IItem
    {
        public Coordinates CheckRoad(char command, Coordinates position)
        {
            var tempX = position.X;
            var tempY = position.Y;

            switch (command)
            {
                case 'w':
                    tempX -= 1;
                    break;
                case 's':
                    tempX += 1;
                    break;
                case 'a':
                    tempY -= 1;
                    break;
                case 'd':
                    tempY += 1;
                    break;
                default:
                {
                    throw new ArgumentException("Invalid command passed to checkRoad method");
                }
            }

            if (tempX < 0 || tempY < 0) return position;

            return new Coordinates(tempX, tempY);
        }

        public void ClearPosition(char[,] map, Coordinates position)
        {
            ValidatePosition(map, position);
            map[position.X, position.Y] = ' ';
        }

        public void NewPosition(char[,] map, Coordinates position, char symbol)
        {
            ValidatePosition(map, position);
            map[position.X, position.Y] = symbol;
        }
        static void ValidatePosition(char[,] map, Coordinates position)
        {
            var numRows = map.Length;
            var numCols = map[0].Length;
            if (position.X > numRows || position.Y > numCols || position.X < 0 || position.Y < 0)
            {
                throw new ArgumentException("New position cannot be outside of a map");
            }
        }

        protected abstract void SetInitialPosition(char[][] map);
    }
}
