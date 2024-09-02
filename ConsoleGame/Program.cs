using ConsoleGame.GameLoop;
using ConsoleGame.Helpers;
using ConsoleGame.Interfaces;

namespace ConsoleGame;

internal class Program
{
    public static void Main(string[] args)
    {
        ILevelFactory defaultLevelFactory = new DefaultLevelFactory();
        IConsoleHandler console = new ConsoleHandlerImpl();
        IMapService mapService = new MapService(console);
        IGameService gameService = new GameService();
        Game game = new Game(3, 8, console, mapService, defaultLevelFactory, gameService);
        game.Start();
    }
}