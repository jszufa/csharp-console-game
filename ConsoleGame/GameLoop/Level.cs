﻿using ConsoleGame.Entities;
using ConsoleGame.States;
using ConsoleGame.World;

namespace ConsoleGame.GameLoop
{
    public class Level
    {
        internal string label;
        public char[,] map;
        internal Walls walls;
        internal Entity hero;
        internal Entity stone;
        internal Entity hole;
        internal Entity trap;

        public bool completed = false;

        public Level(string label, int mapHeight)
        {
            this.label = label;
            this.map = createEmptyMap(mapHeight);
            this.hero = new Hero(map, 'H');
            this.stone = new Stone(map, 'O');
            this.hole = new Hole(map, 'X');
            this.trap = new Trap(map, '8');

            //walls need to be placed on the map at the end, because random walls checks space availability with respect to other items
            //random walls appear on maps bigger than 6
            this.walls = new Walls(map, '+');
        }

        public Level(GameState.SimpleLevel loadedLevel, int mapHeight)
        {
            this.label = loadedLevel.label;
            this.map = createEmptyMap(mapHeight);
            this.hero = new Entity(loadedLevel.hero, map);
            this.stone = new Entity(loadedLevel.stone, map);
            this.hole = new Entity(loadedLevel.hole, map);
            this.trap = new Entity(loadedLevel.trap, map);
            this.walls = new Walls(loadedLevel.walls, map);
        }

        public void resetLevel()
        {

            Entity[] entities = { hero, stone, hole, trap };

            foreach (Entity entity in entities)
            {
                entity.clearPosition(map, entity.Position);
                //assigns values (not the reference)
                entity.Position.x = entity.initialPosition.x;
                entity.Position.y = entity.initialPosition.y;
                entity.newPosition(map, entity.Position, entity.symbol);
            }

            //póki co pozycja walls się nie zmienia, więc nie trzeba ich resetować
        }

        public static char[][] createEmptyMap(int height)
        {

            if (height < 6 || height > 20)
            {
                throw new IllegalArgumentException("Height must be greater than 5 and smaller than 21");
            }

            char[][] map = new char[height][height];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    map[i][j] = ' ';
                }
            }
            return map;
        }
    }
}
