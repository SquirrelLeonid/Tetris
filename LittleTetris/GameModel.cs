using System;
using System.Collections.Generic;
using System.Linq;

namespace LittleTetris
{
    
    public static class GameModel
    { 
        public static readonly bool[,] field = new bool[Constants.width, Constants.height];
        public static Figure figure = new Figure();
        public static LineChecker lineChecker = new LineChecker();
        public static int gameScore = 0; //очки за игру
        public static int destroyedLines = 0;


        public class Figure
        {
            private enum Figures
            {
                O = 0, //Квадрат
                I = 1, //Палка
                J = 2, //Углы
                L = 3,
                Z = 4, //Зиг-заги
                S = 5,
                T = 6 // Т-образная
            }
            public List<Point> CellsCoordinates;

            public Figure()
            {
                CellsCoordinates = new List<Point>(4);
                Figures type = (Figures)new Random().Next(7);
                #region Блок If-ов
                if (type == Figures.O)
                {
                    CellsCoordinates.Add(new Point(7, 2));
                    CellsCoordinates.Add(new Point(7, 3));
                    CellsCoordinates.Add(new Point(8, 2));
                    CellsCoordinates.Add(new Point(8, 3));
                }
                if (type == Figures.I)
                {
                    CellsCoordinates.Add(new Point(7, 2));
                    CellsCoordinates.Add(new Point(7, 3));
                    CellsCoordinates.Add(new Point(7, 4));
                    CellsCoordinates.Add(new Point(7, 5));
                }
                if (type == Figures.J)
                {
                    CellsCoordinates.Add(new Point(7, 2));
                    CellsCoordinates.Add(new Point(7, 3));
                    CellsCoordinates.Add(new Point(7, 4));
                    CellsCoordinates.Add(new Point(6, 4));
                }
                if (type == Figures.L)
                {
                    CellsCoordinates.Add(new Point(7, 2));
                    CellsCoordinates.Add(new Point(7, 3));
                    CellsCoordinates.Add(new Point(7, 4));
                    CellsCoordinates.Add(new Point(8, 4));
                }
                if (type == Figures.Z)
                {
                    CellsCoordinates.Add(new Point(6, 3));
                    CellsCoordinates.Add(new Point(7, 3));
                    CellsCoordinates.Add(new Point(7, 4));
                    CellsCoordinates.Add(new Point(8, 4));
                }
                if (type == Figures.S)
                {
                    CellsCoordinates.Add(new Point(8, 3));
                    CellsCoordinates.Add(new Point(7, 3));
                    CellsCoordinates.Add(new Point(7, 4));
                    CellsCoordinates.Add(new Point(6, 4));
                }
                if (type == Figures.T)
                {
                    CellsCoordinates.Add(new Point(7, 3));
                    CellsCoordinates.Add(new Point(6, 4));
                    CellsCoordinates.Add(new Point(7, 4));
                    CellsCoordinates.Add(new Point(8, 4));
                }
                #endregion
            }

            //Обновляет состояние поля после падения
            private void UpdateFieldState()
            {
                for (int i = 0; i < 4; i++) //Все фигуры из 4 клеток
                {
                    Point cell = CellsCoordinates[i];
                    field[cell.X, cell.Y] = true; // Там где стоит фигура после появления ставим true
                    figure = new Figure();
                }
            }

            public void MoveDown()
            {
                if (IsFigureFall())
                    UpdateFieldState();
                else
                {
                    Point cell;
                    for (int i = 0; i < 4; i++) //Все фигуры из 4 клеток
                    {
                        cell = CellsCoordinates[i];
                        CellsCoordinates[i] = new Point(cell.X, cell.Y + 1);
                    }
                }
            }

            public void MoveSide(int dx)
            {
                if (!AbleToSide(dx))
                    return;
                Point cell;
                for (int i = 0; i < 4; i++)
                {
                    cell = CellsCoordinates[i];
                    cell.X += dx;
                }
            }

            //Проверяем пространство слева и справа
            private bool AbleToSide(int dx)
            {
                Point cell;
                for (int i = 0; i < 4; i++)
                {
                    cell = CellsCoordinates[i];
                    if (cell.X + dx < 1
                        || cell.X + dx == Constants.width
                        || field[cell.X + dx, cell.Y])
                        return false;
                }
                return true;
            }
           
            //Проверяем упала ли фигура
            private bool IsFigureFall()
            {
                Point cell;
                for (int i = 0; i < 4; i++) //Все фигуры из 4 клеток
                {
                    cell = CellsCoordinates[i];
                    if (cell.Y == Constants.height - 1
                        || field[cell.X, cell.Y + 1])
                        return true; //фигура упала
                }
                return false;
            }
        }

        public class LineChecker
        {
            //Сложность N^2
            public void IsTooHigh()
            {
                for (int i = 0; i < Constants.width; i++)
                {
                    if (field[i, 3])
                        Environment.Exit(0);
                }
            }

            public void FindFilledLines()
            {
                List<int> filledLines = new List<int>(4);
                bool lineIsFilled;
                for (int i = 0; i < Constants.height; i++)
                {
                    lineIsFilled = true;
                    for (int j = 1; j < Constants.width; j++)
                    {
                        if (!field[j, i]) // Если встречается хоть одна пустая клетка
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
            private void DestroyFilledLines(List<int> filledLines) 
            {
                if (filledLines.Count == 0)
                    return;
                int multiple = 1;
                foreach (int line in filledLines)
                {
                    //Смещаем игровое поле до конкретной линии
                    for (int i = line; i > 0; i--)
                        for (int j = 1; j < Constants.width; j++)
                            field[j, i] = field[j, i - 1];
                    gameScore += Constants.scoreCount * multiple;
                    destroyedLines++;
                    multiple++;
                }
                
            }
        }
        
    }
}
