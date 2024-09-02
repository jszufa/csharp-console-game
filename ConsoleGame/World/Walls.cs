using ConsoleGame.Entities;
using ConsoleGame.Helpers;

namespace ConsoleGame.World;

public class Walls
{
    public Coordinates[] Positions;
    Coordinates[] initialPositions;
    public char Symbol;
    int randomWallsNumber;

    public Walls(char[,] map, char initialSymbol) {
        Symbol = initialSymbol;
        randomWallsNumber = map.GetLength(0) > 6 ? map.GetLength(0) - 6 : 0; //maybe to be modified
        Positions = new Coordinates[CalculateExpectedWallCount(map)];
        initialPositions = new Coordinates[Positions.Length];
        SetInitialPositions(map);
    }

    public void SetInitialPositions(char[,] map) {
        var height = map.GetLength(0);;

        //Frame
        var wallCounter = 0;

        for (var i = 0; i < height; i++) {
            for (var j = 0; j < height; j++) {

                if (i == 0 || i == height - 1 || j == 0 || j == height - 1) {

                    Positions[wallCounter++] = new Coordinates(i, j);
                    map[i,j] = this.Symbol;
                }
            }
        }

        //random Walls
        for (var i = 0; i < randomWallsNumber; i++) {
            var randomWall = new Wall(map, Symbol);
            Positions[wallCounter++] = new Coordinates(randomWall.initialPosition);
        }

        //Saving initial positions
        for (var i = 0; i < Positions.Length; i++) {
            initialPositions[i] = new Coordinates(Positions[i]);
        }
    }

    private int CalculateExpectedWallCount(char[,] map) {
        var height = map.GetLength(0);
        var frame = (height - 1) * 4;
        return frame + randomWallsNumber;
    }
}