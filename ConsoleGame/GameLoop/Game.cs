using ConsoleGame.Interfaces;

namespace ConsoleGame.GameLoop;
public class Game {
    IConsoleHandler _console;
    IMapService _mapService;
    ILevelFactory _levelFactory;
    bool _victory = false;
    public bool gameOver = false;
    int _levelCount;
    int _mapHeight;

    public Game(int levelCount, int mapHeight, IConsoleHandler console, IMapService mapService, ILevelFactory levelFactory) {
        this._console = console;
        this._mapService = mapService;
        this._levelFactory = levelFactory;
        this._levelCount = levelCount;
        this._mapHeight = mapHeight;
    }

    public void Start() {
        String input;
        
        //game loop
        outerLoop:
        for (int i = 1; i <= _levelCount; i++) {
            Level actualLevel = _levelFactory.CreateLevel("Level" + i, _mapHeight);

            while (true) {
                ClearConsole();
                PrintLevelLabel(actualLevel);
                PrintMap(actualLevel);

                if (i == _levelCount && actualLevel.completed) {
                    _victory = true; //just for clarity
                    PrintVictory();
                    break outerLoop;
                } else if (actualLevel.completed) {
                    continue outerLoop;
                } else if (_gameOver) {
                    PrintGameOver();
                    break outerLoop;
                }

                PrintInputMessage();
                input = _console.readInput();
                if (input.equalsIgnoreCase("reset")) {
                    actualLevel.resetLevel();
                    continue;
                }
                if (input.equalsIgnoreCase("quit")) {
                    break outerLoop;
                }
                _mapService.handleCommand(input, actualLevel,this);
            }
        }
    }
    

    public void PrintMap(Level level) {
        for (char[] row : level.map) {
            for (char element : row) {
                _console.displayOutput(element + "  ");
            }
            _console.displayOutputEmptyLn();
        }
    }

    public void PrintInputMessage() {
        _console.displayOutput("Enter command: ");
    }


    public void PrintVictory() {
        _console.displayOutput("------VICTORY!--------");
    }

    public void PrintGameOver() {
        _console.displayOutputLn("------YOU-LOST--------");
        _console.displayOutputLn("------BUT-STILL--------");
        _console.displayOutputLn("----ENJOY-GOBLIN-SONG-----");
        _console.displayOutputEmptyLn();
        _console.displayOutputLn("\"Even though you had a map...\n You stupidly fell into our trap. \n Don't cry don't cry \n You'll be our pie\"");
    }

    public void PrintLevelLabel(Level level) {
        _console.displayOutputLn(level.label);
    }

    public void ClearConsole() {
        int linesToClear = 50;
        for (int i = 0; i < linesToClear; i++) {
            _console.displayOutputEmptyLn();
        }
    }
}