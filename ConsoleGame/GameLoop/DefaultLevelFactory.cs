using ConsoleGame.Interfaces;
using ConsoleGame.States;

namespace ConsoleGame.GameLoop;

public class DefaultLevelFactory : ILevelFactory {

public Level CreateLevel(string label, int mapHeight) {
    return new Level(label, mapHeight);
}

public Level LoadLevel(GameState.SimpleLevel loadedLevel, int mapHeight)
{
    throw new NotImplementedException();
}
}