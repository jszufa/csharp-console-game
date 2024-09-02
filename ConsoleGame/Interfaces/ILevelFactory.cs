using ConsoleGame.GameLoop;
using ConsoleGame.States;

namespace ConsoleGame.Interfaces
{
    public interface ILevelFactory
    {
        Level CreateLevel(string label, int mapHeight);
        Level LoadLevel(GameState.SimpleLevel loadedLevel, int mapHeight);
    }
}
