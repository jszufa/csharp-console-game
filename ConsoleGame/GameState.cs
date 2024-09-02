using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    internal class GameState
    {
        int _levelCount;
        int _actualLevelNum;
        int _mapHeight;
        SimpleLevel _level;

        public GameState(Game game, Level actualLevel)
        {

            this._levelCount = game._levelCount;
            this._actualLevelNum = game.actualLevelNum;
            this._mapHeight = game._mapHeight;
            this._level = new SimpleLevel(actualLevel);
        }

        class SimpleLevel
        {
            public string Label;
            public SimpleEntity Hero;
            public SimpleEntity Stone;
            public SimpleEntity Hole;
            public SimpleEntity Trap;
            public SimpleWalls Walls;


            public SimpleLevel(Level level)
            {
                this.Label = level.label;
                this.Hero = new SimpleEntity(level.hero);
                this.Stone = new SimpleEntity(level.stone);
                this.Hole = new SimpleEntity(level.hole);
                this.Trap = new SimpleEntity(level.trap);
                this.Walls = new SimpleWalls(level.walls);
            }
        }

        class SimpleEntity
        {
            public Coordinates Position;
            public Coordinates InitialPosition;
            public char Symbol;

            public SimpleEntity(Entity entity)
            {
                this.Position = entity.Position;
                this.InitialPosition = entity.initialPosition;
                this.Symbol = entity.symbol;
            }
        }

        class SimpleWalls
        {
            public Coordinates[] Positions;
            public Coordinates[] InitialPositions;
            public char Symbol;
            public int RandomWallsNumber;

            public SimpleWalls(Walls walls)
            {
                this.Positions = walls.positions;
                this.InitialPositions = walls.initialPositions;
                this.Symbol = walls.symbol;
                this.RandomWallsNumber = walls.randomWallsNumber;
            }
        }
    }
}
