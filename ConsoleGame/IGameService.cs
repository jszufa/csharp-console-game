﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    internal interface IGameService
    {
        void save(GameState gameState);
        GameState load();
    }
}
