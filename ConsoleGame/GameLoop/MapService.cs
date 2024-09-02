using ConsoleGame.Entities;
using ConsoleGame.Helpers;
using ConsoleGame.Interfaces;
using ConsoleGame.World;

namespace ConsoleGame.GameLoop;

public class MapService : IMapService {

    IConsoleHandler console;
    public MapService(IConsoleHandler console) {
        this.console = console;
    }

    public void HandleCommand(string input, Level level, Game game) {

        var map = level.map;
        Entity hero = level.hero;
        Entity stone = level.stone;
        Entity hole = level.hole;
        Entity trap = level.trap;
        Walls walls = level.walls;

        char command = char.ToLower(input[0]);
        if (!ValidateCommand(command)) return;

        Coordinates futureMove = hero.CheckRoad(command, hero.Position);
        char onHeroWay = map[futureMove.X, futureMove.Y];

        //nothing
        if (onHeroWay == ' ' || onHeroWay == '\0') {
            hero.Move(command, map);
        }

        //stone
        else if (onHeroWay == stone.Symbol) {
            Coordinates futureStoneMove = stone.CheckRoad(command, stone.Position);
            char onStoneWay = map[futureStoneMove.X,futureStoneMove.Y];

            if (onStoneWay == hole.Symbol) {
                stone.Move(command, map);
                hero.Move(command, map);
                level.completed = true;

            } else if (onStoneWay == trap.Symbol) {
                stone.Move(command, map);
                hero.Move(command, map);
                game.gameOver = true;

            } else if (onStoneWay == walls.Symbol) {
                // no action needed in this case
            } else {
                stone.Move(command, map);
                hero.Move(command, map);
                //tutaj jest potencjalny bug case, jeśli nie będzie ramki.
                // Wtedy stone się nie przesunie (bo taka jest logika "Move"), ale hero się przesunie i nadpisze jego pozycję.
            }
        }

        //hole or trap
        else if (onHeroWay == hole.Symbol || onHeroWay == trap.Symbol) {
            hero.Move(command, map);
            game.gameOver = true;
        }

        //wall
        else if (onHeroWay == walls.Symbol) {
            // no action needed in this case
        }

        //unknown
        else {
            throw new ArgumentException("Unrecognized character on the map");
        }
    }

    public void PrintControlsMessage() {
        console.DisplayOutputLn("Command not recognized.");
        console.DisplayOutputLn("Use W, S, A, D to Move around.");
        console.DisplayOutputLn("Type QUIT to quit the game or RESET to reset the level.");
    }

    public bool ValidateCommand(char commandInput) {
        char command = char.ToLower(commandInput);
        if (command != 'w' && command != 's' && command != 'a' && command != 'd') {
            PrintControlsMessage();
            return false;
        } else {
            return true;
        }
    }
}