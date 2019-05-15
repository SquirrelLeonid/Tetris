using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;

namespace LittleTetris
{
    
    public static class GameModel
    {
        //public readonly int ScoreCount = 10;       
        public const int width = 15, height = 25, cellSize = 15;
        public static readonly bool[,] field = new bool[width, height];
        public static Figure figure = new Figure();
        public static LineChecker lineChecker = new LineChecker();
        public static int scores = 0; //очки за игру


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
            public bool IsFallen;
            public List<Point> CellsCoordinates;

            public Figure()
            {
                IsFallen = false;
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

            //Обновляет состояние поля после создания новой фигуры.
            //Вызывается единожды для каждой новой фигуры

            //**
            private void UpdateFieldState()
            {
                for (int i = 0; i < 4; i++) //Все фигуры из 4 клеток
                {
                    Point cell = CellsCoordinates[i];
                    field[cell.X, cell.Y] = true; // Там где стоит фигура после появления ставим true
                    figure = new Figure();
                }
            }

            //РАБОТАЕТ
            public void MoveDown()
            {
                if (!IsFallen) //Если фигура еще не упала
                {
                    //Сначала проверяем возможность падения
                    if (!CheckDown())
                    {
                        IsFallen = true;
                        UpdateFieldState();
                    }
                    //Если фигура не упала и есть возможность двигаться вниз
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
            }

            //РАБОТАЕТ
            //Проверяем пространство под фигурой
            private bool CheckDown() //Сложность N
            {
                Point cell;
                for (int i = 0; i < 4; i++) //Все фигуры из 4 клеток
                {
                    cell = CellsCoordinates[i];
                    #region Пояснения к проверке
                    //Если клетка под фигурой уже занята или фигура достигла дна
                    //Условие должно быть верным, потому что сначала идет проверка на корректность,
                    //А уже потом происходит падение. Т.Е ситуации, когда фигура упала за поле, или залезла в другую
                    //Фигуру быть не может.
                    //Кроме того, мне не нужно проверять принадлежит ли новая координата одной из клеток фигуры,
                    //Потому что нет необходимость обозначать на поле true/false места, где находится
                    //ПАДАЮЩАЯ фигура
                    #endregion
                    if (CellsCoordinates[i].Y == height - 1
                        || field[cell.X, cell.Y + 1] == true)
                        return false; //фигура упала
                }
                return true;
            }
        }

        public class LineChecker
        {
            //Сложность N^2
            public void IsTooHigh()
            {
                for (int i = 0; i < width; i++)
                {
                    if (field[i, 3])
                        Environment.Exit(0);
                }
            }
            public IEnumerable<int> FindFilledLines()
            {
                bool lineIsFilled;
                for (int i = 5; i < height; i++)
                {
                    lineIsFilled = true;
                    for (int j = 0; j < width; j++)
                    {
                        if (!field[i, j]) // Если встречается хоть одна пустая клетка
                        {
                            lineIsFilled = false; // Линия не заполнена
                            break;
                        }
                    }
                    if (lineIsFilled) //Если линия все таки заполнена
                        yield return i; //Возвращаем индекс строки
                }
            }

            //Сложность N^2
            private void DestroyFilledLines(IEnumerable<int> filledLines) 
            {
                if (filledLines.Count() == 0)
                    return;
                filledLines.Reverse(); //Устанавливаем порядок по убыванию (т.е. начинаем с низа)
                foreach (int line in filledLines)
                {
                    for (int i = 0; i < width; i++)
                        field[line, i] = field[line - 1, i]; //Нижнюю строку заменяем верхней поэлементно.
                }
                scores += 100;
            }
        }
        
    }
}
