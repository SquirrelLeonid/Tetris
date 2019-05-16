using System;
using System.Collections.Generic;
using System.Linq;

namespace LittleTetris
{
    
    public static class GameModel
    { 
        public static readonly bool[,] field = new bool[Constants.width, Constants.height];
        public static Figure figure = new Figure();
        public static int gameScore = 0;
        public static int destroyedLines = 0;
    }
}
