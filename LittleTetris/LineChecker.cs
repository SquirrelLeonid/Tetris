using System;
using System.Collections.Generic;

namespace LittleTetris
{
    public static class LineChecker
    {
        //Сложность N^2
        public static void IsTooHigh()
        {
            for (int i = 0; i < Constants.width; i++)
                if (GameModel.field[i, 3])             
                    Environment.Exit(0);
        }

        public static void FindFilledLines()
        {
            List<int> filledLines = new List<int>(4);
            bool lineIsFilled;
            for (int i = 0; i < Constants.height; i++)
            {
                lineIsFilled = true;
                for (int j = 1; j < Constants.width; j++)
                {
                    if (!GameModel.field[j, i]) // Если встречается хоть одна пустая клетка
                    {
                        lineIsFilled = false; // Линия не заполнена
                        break;
                    }
                }
                if (lineIsFilled) //Если линия все таки заполнена
                    filledLines.Add(i); //Возвращаем индекс строки
            }
            DestroyFilledLines(filledLines);
        }

        //Сложность N^2
        private static void DestroyFilledLines(List<int> filledLines)
        {
            if (filledLines.Count == 0)
                return;
            int multiple = 1;
            foreach (int line in filledLines)
            {
                //Смещаем игровое поле до конкретной линии
                for (int i = line; i > 0; i--)
                    for (int j = 1; j < Constants.width; j++)
                        GameModel.field[j, i] = GameModel.field[j, i - 1];
                GameModel.gameScore += Constants.scoreCount * multiple;
                GameModel.destroyedLines++;
                multiple++;
            }

        }
    }
}
