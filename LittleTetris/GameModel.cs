using System;
using System.Drawing;
using System.Collections.Generic;

namespace LittleTetris
{
    
    public class GameModel
    {
        public readonly int ScoreCount = 10;
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
        public List<Point> Coordinates;
        public Figure()
        {
            Coordinates = new List<Point>(4);
            Figures type = (Figures)new Random().Next(7);
            #region Блок If-ов
            if (type == Figures.O)
            {
                Coordinates.Add(new Point(7,3));
                Coordinates.Add(new Point(7,3));
                Coordinates.Add(new Point(8,2));
                Coordinates.Add(new Point(8,3));              
            }             
            if (type == Figures.I)
            {
                Coordinates.Add(new Point(7, 2));
                Coordinates.Add(new Point(7, 3));
                Coordinates.Add(new Point(7, 4));
                Coordinates.Add(new Point(7, 5));
            }
            if (type == Figures.J)
            {
                Coordinates.Add(new Point(7, 2));
                Coordinates.Add(new Point(7, 3));
                Coordinates.Add(new Point(7, 4));
                Coordinates.Add(new Point(8, 4));
            }
            if (type == Figures.L)
            {
                Coordinates.Add(new Point(7, 2));
                Coordinates.Add(new Point(7, 3));
                Coordinates.Add(new Point(7, 4));
                Coordinates.Add(new Point(6, 4));
            }
            if (type == Figures.Z)
            {
                Coordinates.Add(new Point(6, 3));
                Coordinates.Add(new Point(7, 3));
                Coordinates.Add(new Point(7, 4));
                Coordinates.Add(new Point(8, 4));
            }
            if (type == Figures.S)
            {
                Coordinates.Add(new Point(8, 3));
                Coordinates.Add(new Point(7, 3));
                Coordinates.Add(new Point(7, 4));
                Coordinates.Add(new Point(6, 4));
            }
            if (type == Figures.T)
            {
                Coordinates.Add(new Point(7, 3));
                Coordinates.Add(new Point(6, 4));
                Coordinates.Add(new Point(7, 4));
                Coordinates.Add(new Point(8, 4 ));
            }
            #endregion
        }
    }
}
