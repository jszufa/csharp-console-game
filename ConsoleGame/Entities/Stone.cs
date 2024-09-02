using ConsoleGame.Helpers;

namespace ConsoleGame.Entities;

public class Stone(char[,] map, char initialSymbol) : Entity(map, initialSymbol)
{
    // Stone needs a distance from the wall frame
    // Maybe change to: "adjust stone Position if it's too close to the wall" - or make the logic different
    protected override void SetInitialPosition(char[,] map)
    {
        int height = map.Length;

        int maxAttempts = (height - 2) * (height - 2);
        int rowIndex;
        int colIndex;

        // Generate random Position and check if it's free
        for (int attempt = 0; attempt < maxAttempts; attempt++)
        {
            do
            {
                rowIndex = generator.Next(height - 2);
            } while (rowIndex <= 1);

            do
            {
                colIndex = generator.Next(height - 2);
            } while (colIndex <= 1);

            Position.X = rowIndex;
            Position.Y = colIndex;

            // Check if the field is free
            if (map[Position.X,Position.Y] == ' ' || map[Position.X,Position.Y] == '\0')
            {
                break;
            }
        }

        // Throw exception if the place is not free after maxAttempts
        if (map[Position.X,Position.Y] != ' ' && map[Position.X,Position.Y] != '\0')
        {
            throw new InvalidOperationException($"Unable to find a free Position after {maxAttempts} attempts");
        }

        // Place stone's symbol on the free Position and remember it
        map[Position.X,Position.Y] = Symbol;
        this.InitialPosition = new Coordinates(Position.X, Position.Y);
    }
}
