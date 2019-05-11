using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;

namespace LittleTetris
{
    
    public partial class TetrisForm : Form
    {
        public const int horCellsCount = 15, vertCellsCount = 25, cellSize = 15;
        //Помещается 14 клеток    
        // Массив для хранения падающей фигурки. Клетка представляется парой координат
        public int[,] figure = new int[2, 4];   
        public int[,] field = new int[horCellsCount, vertCellsCount];
        public Bitmap background = new Bitmap(cellSize * (horCellsCount + 1), cellSize * (vertCellsCount + 1));
        public readonly GameModel gameModel = new GameModel();

        public TetrisForm()
        {
            InitializeComponent();            
            figure = gameModel.CreateFigure();
        }

        public void FillField()
        {
            Graphics graphics = Graphics.FromImage(background);
            //Заливка цветом
            graphics.Clear(Color.Black);
            //Окантовка
            graphics.DrawRectangle(Pens.Red, cellSize - 1, cellSize, (horCellsCount - 1) * cellSize, (vertCellsCount - 1) * cellSize);
            //Покраска приземлившихся фигур
            for (int i = 0; i < horCellsCount; i++)
                for (int j = 0; j < vertCellsCount; j++)                    
                    graphics.FillRectangle(
                        Brushes.Green,
                        i * cellSize,
                        j * cellSize,
                        (cellSize - 1) * field[i, j], //Для зазоров
                        (cellSize - 1) * field[i, j]); // Для зазоров

            //Покраска падающих фигур
            for (int i = 0; i < 4; i++)
                graphics.FillRectangle(
                    Brushes.Red,
                    figure[1, i] * cellSize,
                    figure[0, i] * cellSize,
                    cellSize - 1, //Для зазоров
                    cellSize - 1); //Для зазоров

            FieldPictureBox.Image = background; // Обновление состояния окна после отрисовки фигур
        }

        //С этим я разберусь думаю, куда совать потом разберемся
        private void TickTimer_Tick(object sender, EventArgs e)
        {
            if (field[8, 4] == 1)
                Environment.Exit(0);              
            foreach(int i in (from i in Enumerable.Range(0, field.GetLength(1))
                              where (Enumerable.Range(0, field.GetLength(0))
                              .Select(j => field[j, i]).Sum() >= horCellsCount - 1) select i)
                              .ToArray().Take(1)) 
                for (int k = i; k > 1; k--)
                    for (int l = 1; l < horCellsCount; l++)
                        field[l, k] = field[l, k - 1];
            Move(0, 1);
        }

        //Вызывается при нажатии кнопки
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //Тут у меня че то с табуляцией 
            switch (e.KeyCode)
            {
                case Keys.A: Move(-1, 0); break;
                case Keys.D: Move(1, 0); break;
                case Keys.S: TickTimer.Interval = 50; break;
                
                //Опиши как у тебя действует поворот
                case Keys.W:               
                int[,] shapeT = new int[2, 4];
                //Копируем текущую фигуру
                Array.Copy(figure, shapeT, figure.Length);
                //Тут ты определяешь положение фигуры??
                int maxX = Enumerable.Range(0, 4).Select(j => figure[1, j]).ToArray().Max();
                int maxY = Enumerable.Range(0, 4).Select(j => figure[0, j]).ToArray().Max();

                for (int i = 0; i < 4; i++)
                { 
                    int temp = figure[0, i];
                    figure[0, i] = maxY - (maxX - figure[1, i]) - 1;
                    figure[1, i] = maxX - (3 - (maxY - temp)) + 1;
                }
                //Если после поворота залезли куда не надо
                if (FindMistake())
                    Array.Copy(shapeT, figure, figure.Length);
                break;
            }
        }

        //TickTimer.Interval - скорость падения при отжатой клавише
        //Вроде можно тут оставить?
        private void Form1_KeyUp(object sender, KeyEventArgs e) => TickTimer.Interval = 250;
   
        //Возможно вынести в модель?
        public new void Move(int xSpeed, int ySpeed)
        {        
            for (int i = 0; i < 4; i++)
            {
                figure[1, i] += xSpeed;
                figure[0, i] += ySpeed;
            }

            if (FindMistake())
            { 
                Move(-xSpeed, -ySpeed);
                //Что делает эта часть?
                if (ySpeed != 0)
                {
                    for (int i = 0; i < 4; i++)
                        field[figure[1, i], figure[0, i]]++;
                    figure = gameModel.CreateFigure(); 
                }
            }
            //Перерисовка поля
            FillField();
        }

        public bool FindMistake()
        {
            for (int i = 0; i < 4; i++)
                //Первые четыре строки - выход за границы, последняя - наложение
                if (figure[1, i] == horCellsCount
                    || figure[0, i] == vertCellsCount
                    || figure[1, i] == 0
                    || figure[0, i] == 0
                    || field[figure[1, i], figure[0, i]] == 1)
                    return true;          
            return false;
        }
    }
}