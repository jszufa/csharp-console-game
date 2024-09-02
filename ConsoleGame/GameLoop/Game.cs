using ConsoleGame.Interfaces;

namespace ConsoleGame.GameLoop;
using System;
using System.Linq;

public class Game
{
    private readonly IConsoleHandler _console;
    private readonly IMapService _mapService;
    private readonly ILevelFactory _levelFactory;
    private readonly IGameService _gameService;
    private bool _victory = false;
    private bool _gameOver = false;
    private int _levelCount;
    private int _actualLevelNum;
    private int _mapHeight;

    public Game(int levelCount, int mapHeight, IConsoleHandler console, IMapService mapService, ILevelFactory levelFactory, IGameService gameService)
    {
        _console = console;
        _mapService = mapService;
        _levelFactory = levelFactory;
        _gameService = gameService;
        _levelCount = levelCount;
        _mapHeight = mapHeight;
    }

    public void Start()
    {
        string input;
        
        // Game loop
        outerLoop:
        for (_actualLevelNum = 1; _actualLevelNum <= _levelCount; _actualLevelNum++)
        {
            Level actualLevel = _levelFactory.CreateLevel($"Level{_actualLevelNum}", _mapHeight);

            while (true)
            {
                ClearConsole();
                PrintLevelLabel(actualLevel);
                PrintMap(actualLevel);

                if (_actualLevelNum == _levelCount && actualLevel.Completed)
                {
                    _victory = true; // just for clarity
                    PrintVictory();
                    break;
                }
                else if (actualLevel.Completed)
                {
                    continue;
                }
                else if (_gameOver)
                {
                    PrintGameOver();
                    break;
                }

                PrintInputMessage();
                input = _console.ReadInput();
                if (string.Equals(input, "reset", StringComparison.OrdinalIgnoreCase))
                {
                    actualLevel.ResetLevel();
                    continue;
                }
                if (string.Equals(input, "quit", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }
                if (string.Equals(input, "save", StringComparison.OrdinalIgnoreCase))
                {
                    SaveGame(actualLevel);
                    continue;
                }
                if (string.Equals(input, "load", StringComparison.OrdinalIgnoreCase))
                {
                    actualLevel = LoadGame();
                    continue;
                }
                _mapService.HandleCommand(input, actualLevel, this);
            }
        }
    }

    public void PrintMap(Level level)
    {
        foreach (var row in level.Map)
        {
            foreach (var element in row)
            {
                _console.DisplayOutput(element + "  ");
            }
            _console.DisplayOutputEmptyLn();
        }
    }

    public void PrintInputMessage()
    {
        _console.DisplayOutput("Enter command: ");
    }

    public void PrintVictory()
    {
        _console.DisplayOutput("------VICTORY!--------");
    }

    public void PrintGameOver()
    {
        _console.DisplayOutputLn("------YOU-LOST--------");
        _console.DisplayOutputLn("------BUT-STILL--------");
        _console.DisplayOutputLn("----ENJOY-GOBLIN-SONG-----");
        _console.DisplayOutputEmptyLn();
        _console.DisplayOutputLn("\"Even though you had a map...\n You stupidly fell into our trap. \n Don't cry don't cry \n You'll be our pie\"");
    }

    public void PrintLevelLabel(Level level)
    {
        _console.DisplayOutputLn(level.Label);
    }

    public void ClearConsole()
    {
        const int linesToClear = 50;
        for (int i = 0; i < linesToClear; i++)
        {
            _console.DisplayOutputEmptyLn();
        }
    }

    public void SaveGame(Level level)
    {
        var gameState = new GameState(this, level);
        _gameService.Save(gameState);
    }

    public Level LoadGame()
    {
        // Reading data from the file
        var gameState = _gameService.Load();

        // Load saved game fields
        _levelCount = gameState.LevelCount;
        _actualLevelNum = gameState.ActualLevelNum;
        _mapHeight = gameState.MapHeight;

        // Return saved level
        return _levelFactory.LoadLevel(gameState.Level, _mapHeight);
    }
}
