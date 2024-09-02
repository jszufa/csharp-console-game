namespace ConsoleGame.Entities;

public class Wall(char[,] map, char initialSymbol) : Entity(map, initialSymbol)
{
    //needs to be placed on the map at the end, because it checks space availability with respect to other items

    protected override void SetInitialPosition(char[,] map)
    {
        var height = map.GetLength(0);

        var maxAttempts = (height - 1) * (height - 1);

        //generate random position and check if it's free
        for (var attempt = 0; attempt < maxAttempts; attempt++)
        {
            int rowIndex;
            do
            {
                rowIndex = generator.Next(height - 1);
            } while (rowIndex == 0);

            int colIndex;
            do
            {
                colIndex = generator.Next(height - 1);
            } while (colIndex == 0);

            Position.X = rowIndex;
            Position.Y = colIndex;

            //check if the field is free and if the surrounding fields are free or are walls
            if (
                (map[Position.X, Position.Y] == ' ' || map[Position.X, Position.Y] == '\0') &&
                (map[Position.X + 1, Position.Y] == ' ' || map[Position.X + 1, Position.Y] == '\0' ||
                 map[Position.X + 1, Position.Y] == this.Symbol) &&
                (map[Position.X - 1, Position.Y] == ' ' || map[Position.X - 1, Position.Y] == '\0' ||
                 map[Position.X - 1, Position.Y] == this.Symbol) &&
                (map[Position.X, Position.Y + 1] == ' ' || map[Position.X, Position.Y + 1] == '\0' ||
                 map[Position.X, Position.Y + 1] == this.Symbol) &&
                (map[Position.X, Position.Y - 1] == ' ' || map[Position.X, Position.Y - 1] == '\0' ||
                 map[Position.X, Position.Y - 1] == this.Symbol) &&
                (map[Position.X + 1, Position.Y + 1] == ' ' || map[Position.X + 1, Position.Y + 1] == '\0' ||
                 map[Position.X + 1, Position.Y + 1] == this.Symbol) &&
                (map[Position.X + 1, Position.Y - 1] == ' ' || map[Position.X - 1, Position.Y - 1] == '\0' ||
                 map[Position.X - 1, Position.Y - 1] == this.Symbol) &&
                (map[Position.X - 1, Position.Y + 1] == ' ' || map[Position.X - 1, Position.Y + 1] == '\0' ||
                 map[Position.X - 1, Position.Y + 1] == this.Symbol) &&
                (map[Position.X - 1, Position.Y - 1] == ' ' || map[Position.X - 1, Position.Y - 1] == '\0' ||
                 map[Position.X - 1, Position.Y - 1] == this.Symbol)
            )
            {
                break;
            }
        }

        //throw exception if the place is not found after n (maxAttempts) attempts
        if (
            !((map[Position.X, Position.Y] == ' ' || map[Position.X, Position.Y] == '\0')
              && (map[Position.X + 1, Position.Y] == ' ' || map[Position.X + 1, Position.Y] == '\0' ||
                  map[Position.X + 1, Position.Y] == this.Symbol)
              && (map[Position.X - 1, Position.Y] == ' ' || map[Position.X - 1, Position.Y] == '\0' ||
                  map[Position.X - 1, Position.Y] == this.Symbol)
              && (map[Position.X, Position.Y + 1] == ' ' || map[Position.X, Position.Y + 1] == '\0' ||
                  map[Position.X, Position.Y + 1] == this.Symbol)
              && (map[Position.X, Position.Y - 1] == ' ' || map[Position.X, Position.Y - 1] == '\0' ||
                  map[Position.X, Position.Y - 1] == this.Symbol)
              && (map[Position.X + 1, Position.Y + 1] == ' ' || map[Position.X + 1, Position.Y + 1] == '\0' ||
                  map[Position.X + 1, Position.Y + 1] == this.Symbol)
              && (map[Position.X + 1, Position.Y - 1] == ' ' || map[Position.X - 1, Position.Y - 1] == '\0' ||
                  map[Position.X - 1, Position.Y - 1] == this.Symbol)
              && (map[Position.X - 1, Position.Y + 1] == ' ' || map[Position.X - 1, Position.Y + 1] == '\0' ||
                  map[Position.X - 1, Position.Y + 1] == this.Symbol)
              && (map[Position.X - 1, Position.Y - 1] == ' ' || map[Position.X - 1, Position.Y - 1] == '\0' ||
                  map[Position.X - 1, Position.Y - 1] == this.Symbol)
            ))
        {
            throw new InvalidOperationException($"Unable to find a free position for random wall after {maxAttempts} attempts");
        }

        //place wall's Symbol on the free position and remember it
        map[Position.X, Position.Y] = Symbol;
        this.initialPosition = new Coordinates(Position.X, Position.Y);
    }
}