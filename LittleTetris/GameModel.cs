﻿using System;

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
                case 0: figure = new int[,] { { 2, 3, 4, 5 }, { 7, 7, 7, 7 } }; break; //Палка --
                case 1: figure = new int[,] { { 2, 3, 2, 3 }, { 7, 7, 8, 8 } }; break; //Квадрат []
                case 2: figure = new int[,] { { 2, 3, 4, 4 }, { 7, 7, 7, 8 } }; break; //Угол слева |___
                case 3: figure = new int[,] { { 2, 3, 4, 4 }, { 7, 7, 7, 6 } }; break; //Угол справа ___|
                case 4: figure = new int[,] { { 3, 3, 4, 4 }, { 6, 7, 7, 8 } }; break; //Зигзаг слева
                case 5: figure = new int[,] { { 3, 3, 4, 4 }, { 8, 7, 7, 6 } }; break; //Зигзаг справа
                case 6: figure = new int[,] { { 3, 4, 4, 4 }, { 7, 6, 7, 8 } }; break; // Т-образная __|__
            }
            return figure;
        }
    }
}
