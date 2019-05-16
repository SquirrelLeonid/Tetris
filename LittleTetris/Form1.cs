using System;
using System.Drawing;
using System.Windows.Forms;

namespace LittleTetris
{  
    public partial class TetrisForm : Form
    {
        private int currentIteration = 0;
        private Bitmap gameField;
        public SoundMaster soundMaster; 
        
       
        public TetrisForm()
        {
            InitializeComponent();        
            gameField = new Bitmap(Constants.cellSize * (Constants.width + 1), Constants.cellSize * (Constants.height + 1));
            soundMaster = new SoundMaster();          
        }

        private void TickTimer_Tick(object sender, EventArgs e)
        {
            IterationCounter.Text = currentIteration++.ToString();
            LineChecker.IsTooHigh();            
            LineChecker.FindFilledLines(); //Находим и уничтожаем заполненные линии если такие есть            
            GameModel.figure.MoveDown();
            UpdateData();
            FillField(); //После падения и уничтожения заполненных линий перерисовываем             
        }

        private void FillField()
        {
            Graphics graphics = Graphics.FromImage(gameField);
            graphics.Clear(Color.Black);
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

            GameField.Image = gameField; // Обновление состояния окна после отрисовки фигур
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