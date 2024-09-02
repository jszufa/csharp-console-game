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
        public Coordinates Position = new Coordinates(0, 0);
        Coordinates initialPosition;
        char _symbol;
        public char Symbol
        {
            get => _symbol;
            set => _symbol = value;
        }

        public Entity(char[][] map, char initialSymbol)
        {
            _symbol = initialSymbol;
            SetInitialPosition(map);
        }

        public Entity(GameState.SimpleEntity loadedEntity, char[][] map)
        {
            _symbol = loadedEntity.Symbol;
            Position = loadedEntity.Position;
            initialPosition = loadedEntity.InitialPosition;
            this.NewPosition(map, Position, _symbol);
        }

        
    protected override void SetInitialPosition(char[][] map)
        {
            var height = map.Length;

            if (height < 6)
            {
                throw new ArgumentException("Height must be 6 or greater");
            }

            var maxAttempts = (height - 2) * (height - 2);

            //generate random position and check if it's free
            for (var attempt = 0; attempt < maxAttempts; attempt++)
            {
                int rowIndex;
                do
                {
                    rowIndex = generator.nextInt(height - 1);
                } while (rowIndex == 0);

                int colIndex;
                do
                {
                    colIndex = generator.nextInt(height - 1);
                } while (colIndex == 0);

                Position.X = rowIndex;
                Position.Y = colIndex;

                //check if the place is free
                if (map[Position.X][Position.Y] == ' ' || map[Position.X][Position.Y] == '\0')
                {
                    break;
                }
            }

            //throw exception if the place is not free after n (maxAttempts) attempts
            if (map[Position.X][Position.Y] != ' ' && map[Position.X][Position.Y] != '\0')
            {
                throw new InvalidOperationException("Unable to find a free position after" + maxAttempts + " attempts");
            }

            //place token's symbol on the free position and remember it
            map[Position.X][Position.Y] = _symbol;
            this.initialPosition = new Coordinates(Position.X, Position.Y);

        }


        public void Move(char command, char[][] map)
        {
            this.ClearPosition(map, Position);

            var numRows = map.Length;
            var numCols = map[0].Length;

            switch (command)
            {
                case 'w':
                    if (Position.X > 0)
                        Position.X -= 1;
                    break;
                case 's':
                    if (Position.X < numRows - 1)
                        Position.X += 1;
                    break;
                case 'a':
                    if (Position.Y > 0)
                        Position.Y -= 1;
                    break;
                case 'd':
                    if (Position.Y < numCols - 1)
                        Position.Y += 1;
                    break;
                default:
                    throw new ArgumentException("Invalid command passed to checkRoad method");
            }


            this.NewPosition(map, this.Position, this._symbol);
        }
    }
}
