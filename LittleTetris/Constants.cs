using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleTetris
{
    //Возможно стоит хранить все константы здесь и обращаться к ним отсюда
    public static class Constants
    {        
        public const int width = 15, height = 25, cellSize = 15; //Количество клеток по горизонтали, вертикали, и их размер
        public const int scoreCount = 10; // Количество начисляемых очков
    }
}
