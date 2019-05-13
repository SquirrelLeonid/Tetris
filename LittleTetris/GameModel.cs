using System;
using System.Drawing;
using System.Collections.Generic;

namespace LittleTetris
{
    
    public class GameModel
    {
        public readonly int ScoreCount = 10;
        //Этот метод потом уберется. Пока что он нужен для того чтобы код запускался
        public int[,] CreateFigure()
        {
            Random x = new Random();
            int[,] figure = null;
            switch (x.Next(7)) // Рандомно выбираем 1 из 7 возможных фигур
            {
                //Первые скобки - Y, Вторые - Х
                case 0: figure = new int[,] { { 2, 3, 4, 5 }, { 7, 7, 7, 7 } }; break; //I
                case 1: figure = new int[,] { { 2, 3, 2, 3 }, { 7, 7, 8, 8 } }; break; //O
                case 2: figure = new int[,] { { 2, 3, 4, 4 }, { 7, 7, 7, 8 } }; break; //J
                case 3: figure = new int[,] { { 2, 3, 4, 4 }, { 7, 7, 7, 6 } }; break; //L
                case 4: figure = new int[,] { { 3, 3, 4, 4 }, { 6, 7, 7, 8 } }; break; //Z
                case 5: figure = new int[,] { { 3, 3, 4, 4 }, { 8, 7, 7, 6 } }; break; //S
                case 6: figure = new int[,] { { 3, 4, 4, 4 }, { 7, 6, 7, 8 } }; break; //Т
            }
            return figure;
        }
    }

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
            CellsCoordinates = new List<Point>(4);
            Figures type = (Figures)new Random().Next(7);
            #region Блок If-ов
            if (type == Figures.O)
            {
                CellsCoordinates.Add(new Point(7,3));
                CellsCoordinates.Add(new Point(7,3));
                CellsCoordinates.Add(new Point(8,2));
                CellsCoordinates.Add(new Point(8,3));              
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
                CellsCoordinates.Add(new Point(8, 4));
            }
            if (type == Figures.L)
            {
                CellsCoordinates.Add(new Point(7, 2));
                CellsCoordinates.Add(new Point(7, 3));
                CellsCoordinates.Add(new Point(7, 4));
                CellsCoordinates.Add(new Point(6, 4));
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
                CellsCoordinates.Add(new Point(8, 4 ));
            }
            #endregion
        }

        //Здесь не будет проверки на столкновение с другой фигурой
        //Метод выполняет только 2 функции: двигает фигуру вниз если она не упала.
        //Проверка на то, что фигура достигла дна будет в другом месте. Если условие этой проверки
        //Соблюдается (Фигура достигла дна), то полю IsFallen присваивается True
        public void MoveDown()
        {
            if (!IsFallen) //Если фигура не упала
            {               
                for (int i = 0; i < 4; i++) //Все фигуры из 4 клеток
                {
                    Point cell = CellsCoordinates[i];
                    CellsCoordinates[i] = new Point(cell.X, cell.Y + 1);
                }
            }
        }
    }
}
