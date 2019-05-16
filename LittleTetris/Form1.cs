using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Media;

namespace LittleTetris
{
    
    public partial class TetrisForm : Form
    {
        //SoundPlayer sound = new SoundPlayer(@"C:\Tetris.wav");
        private int currentIteration = 0;
        public Bitmap background;
        public TetrisForm()
        {
            InitializeComponent();
            //sound.Load();
            //sound.Play();
            background = new Bitmap(Constants.cellSize * (Constants.width + 1), Constants.cellSize * (Constants.height + 1));
        }

        private void TickTimer_Tick(object sender, EventArgs e)
        {
            IterationCounter.Text = currentIteration++.ToString();
            GameModel.lineChecker.IsTooHigh();            
            GameModel.lineChecker.FindFilledLines(); //Находим и уничтожаем заполненные линии если такие есть
            UpdateData();
            GameModel.figure.MoveDown();
            FillField(); //После падения и уничтожения заполненных линий перерисовываем             
        }

        private void FillField()
        {
            Graphics graphics = Graphics.FromImage(background);
            graphics.Clear(Color.Black);
            graphics.DrawRectangle(
                Pens.Red,
                Constants.cellSize - 1,
                Constants.cellSize,
                (Constants.width- 1) * Constants.cellSize,
                (Constants.height - 1) * Constants.cellSize);
            //Покраска приземлившихся фигур
            for (int i = 0; i < Constants.width; i++)
                for (int j = 0; j < Constants.height; j++)
                    if (GameModel.field[i, j] == true) // избавляет от проблемы с закрашиванием всего поля
                        graphics.FillRectangle(
                            Brushes.Green,
                            i * Constants.cellSize,
                            j * Constants.cellSize,
                            Constants.cellSize - 1, //Для зазоров
                            Constants.cellSize - 1);
            //Покраска падающих фигур
            for (int i = 0; i < 4; i++)
            {
                Point cell = GameModel.figure.CellsCoordinates[i];
                graphics.FillRectangle(
                    Brushes.Red,
                    cell.X * Constants.cellSize,
                    cell.Y * Constants.cellSize,
                    Constants.cellSize - 1, //Для зазоров
                    Constants.cellSize - 1); //Для зазоров
            }

            FieldPictureBox.Image = background; // Обновление состояния окна после отрисовки фигур
        }

        private void UpdateData()
        {
            Score.Text = GameModel.gameScore.ToString();
            Lines.Text = GameModel.destroyedLines.ToString();
        }
      
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.S: TickTimer.Interval = 50; break;
                case Keys.A: GameModel.figure.MoveSide(-1); break;
                case Keys.D: GameModel.figure.MoveSide(1); break;
                case Keys.W: GameModel.figure.Rotate(); break;
            }
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e) => TickTimer.Interval = 250;             
    }
}