using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    internal class Entity : Item
    {
        Random generator = new Random();
        public Coordinates position = new Coordinates(0, 0);
        Coordinates initialPosition;
        char symbol;
        public char Symbol
        {
            get { return symbol; } 
            set { symbol = value; }
        }

        public Entity(char[][] map, char initialSymbol)
        {
            symbol = initialSymbol;
            SetInitialPosition(map);
        }

        public Entity(GameState.SimpleEntity loadedEntity, char[][] map)
        {
            symbol = loadedEntity.Symbol;
            position = loadedEntity.Position;
            initialPosition = loadedEntity.InitialPosition;
            this.NewPosition(map, position, symbol);
        }

        
    protected override void SetInitialPosition(char[][] map)
        {
            int height = map.Length;

            if (height < 6)
            {
                throw new ArgumentException("Height must be 6 or greater");
            }

            int maxAttempts = (height - 2) * (height - 2);
            int rowIndex;
            int colIndex;

            //generate random position and check if it's free
            for (int attempt = 0; attempt < maxAttempts; attempt++)
            {
                do
                {
                    rowIndex = generator.nextInt(height - 1);
                } while (rowIndex == 0);

                do
                {
                    colIndex = generator.nextInt(height - 1);
                } while (colIndex == 0);

                position.X = rowIndex;
                position.Y = colIndex;

                //check if the place is free
                if (map[position.X][position.Y] == ' ' || map[position.X][position.Y] == '\0')
                {
                    break;
                }
            }

            //throw exception if the place is not free after n (maxAttempts) attempts
            if (map[position.X][position.Y] != ' ' && map[position.X][position.Y] != '\0')
            {
                throw new InvalidOperationException("Unable to find a free position after" + maxAttempts + " attempts");
            }

            //place token's symbol on the free position and remember it
            map[position.X][position.Y] = symbol;
            this.initialPosition = new Coordinates(position.X, position.Y);

        }


        public void Move(char command, char[][] map)
        {
            this.ClearPosition(map, position);

            int numRows = map.Length;
            int numCols = map[0].Length;

            switch (command)
            {
                case 'w':
                    if (position.X > 0)
                        position.X -= 1;
                    break;
                case 's':
                    if (position.X < numRows - 1)
                        position.X += 1;
                    break;
                case 'a':
                    if (position.Y > 0)
                        position.Y -= 1;
                    break;
                case 'd':
                    if (position.Y < numCols - 1)
                        position.Y += 1;
                    break;
                default:
                    throw new ArgumentException("Invalid command passed to checkRoad method");
            }


            this.NewPosition(map, this.position, this.symbol);
        }
    }
}
