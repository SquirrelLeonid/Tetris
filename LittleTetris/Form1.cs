using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace LittleTetris
{
    
    public partial class TetrisForm : Form
    {
        private int currentIteration = 0;
        public Bitmap background;

        public TetrisForm()
        {
            InitializeComponent();
            background = new Bitmap(GameModel.cellSize * (GameModel.width + 1), GameModel.cellSize * (GameModel.height + 1));
        }

        private void TickTimer_Tick(object sender, EventArgs e)
        {
            IterationCounter.Text = currentIteration++.ToString();
            GameModel.figure.MoveDown(); // Вызываем метод, в результате которого фигура опускается
            GameModel.lineChecker.FindFilledLines(); //Находим и уничтожаем заполненные линии если такие есть
            FillField(); //После падения и уничтожения заполненных линий перерисовываем           
            GameModel.lineChecker.IsTooHigh();
        }

        public void FillField()
        {
            Graphics graphics = Graphics.FromImage(background);
            graphics.Clear(Color.Black);
            graphics.DrawRectangle(
                Pens.Red,
                GameModel.cellSize - 1,
                GameModel.cellSize,
                (GameModel.width - 1) * GameModel.cellSize,
                (GameModel.height - 1) * GameModel.cellSize);
            //Покраска приземлившихся фигур
            for (int i = 0; i < GameModel.width; i++)
                for (int j = 0; j < GameModel.height; j++)
                    if (GameModel.field[i, j] == true) // избавляет от проблемы с закрашиванием всего поля
                        graphics.FillRectangle(
                            Brushes.Green,
                            i * GameModel.cellSize,
                            j * GameModel.cellSize,
                            GameModel.cellSize - 1, //Для зазоров
                            GameModel.cellSize - 1);
            //Покраска падающих фигур
            for (int i = 0; i < 4; i++)
            {
                Point cell = GameModel.figure.CellsCoordinates[i];
                graphics.FillRectangle(
                    Brushes.Red,
                    cell.X * GameModel.cellSize,
                    cell.Y * GameModel.cellSize,
                    GameModel.cellSize - 1, //Для зазоров
                    GameModel.cellSize - 1); //Для зазоров
            }

            FieldPictureBox.Image = background; // Обновление состояния окна после отрисовки фигур
        }
      
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.S: TickTimer.Interval = 50; break;               
            }
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e) => TickTimer.Interval = 250;             
    }
}