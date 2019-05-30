using System;
using System.Collections.Generic;

namespace LittleTetris
{
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
        private readonly Figures type;
        public Figure()
        {
            CellsCoordinates = new List<Point>(4);
            type = (Figures)new Random().Next(7);
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
                CellsCoordinates.Add(new Point(7, 4));
                CellsCoordinates.Add(new Point(6, 4));
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
                GameModel.field[cell.X, cell.Y] = true; // Там где стоит фигура после появления ставим true
                GameModel.figure = new Figure();
            }
        }

        public void Rotate()
        {
            //Если это не квадрат
            if (GameModel.figure.type != 0)
            {
                Point center = CellsCoordinates[1];
                Point cell;
                for (int i = 0; i < 4; i++)
                {
                    cell = CellsCoordinates[i];
                    int dx = center.X - cell.Y + center.Y;
                    int dy = center.Y + cell.X - center.X;
                    if (dx < 0 || dx >= Constants.width || dy >= Constants.height)
                        return;
                    else if (GameModel.field[dx, dy])
                        return;
                    cell.X = dx;
                    cell.Y = dy;
                }
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
            for (int i = 0; i < 4; i++)
                CellsCoordinates[i].X += dx;
        }

        //Проверяем пространство слева и справа
        private bool AbleToSide(int dx)
        {
            Point cell;
            for (int i = 0; i < 4; i++)
            {
                cell = CellsCoordinates[i];
                if (cell.X + dx < 0
                    || cell.X + dx == Constants.width
                    || GameModel.field[cell.X + dx, cell.Y])
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
                    || GameModel.field[cell.X, cell.Y + 1])
                    return true; //фигура упала
            }
            return false;
        }
    }
}
