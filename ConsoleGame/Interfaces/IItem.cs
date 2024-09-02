using ConsoleGame.Helpers;

namespace ConsoleGame.Interfaces
{
    internal interface IItem
    {
        void NewPosition(char[][] map, Coordinates position, char symbol);
        void ClearPosition(char[][] map, Coordinates position);
        Coordinates CheckRoad(char command, Coordinates position);

    }
}
