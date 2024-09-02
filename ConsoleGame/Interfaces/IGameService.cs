using ConsoleGame.States;

namespace ConsoleGame.Interfaces
{
    internal interface IGameService
    {
        void Save(GameState gameState);
        GameState Load();
    }
}
