using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace LittleTetris
{
    
    public partial class TetrisForm : Form
    {
        #region Объявление полей, задание размеров и прочее
        public const int width = 15, height = 25, cellSize = 15;
        private int currentIteration = 0;
        public int[,] figure = new int[2, 4];   
        public int[,] field = new int[width, height];
        public Bitmap background = new Bitmap(cellSize * (width + 1), cellSize * (height + 1));
        public readonly GameModel gameModel = new GameModel();
        #endregion

        public static bool[,] field2 = new bool[width, height]; //Изначально заполненно false-ми, static для доступа извне
        public TetrisForm()
        {
            InitializeComponent();            
            figure = gameModel.CreateFigure();
        } //Самая первая фигура создается здесь

        //Пусть остается как есть
        public void FillField()
        {
            Graphics graphics = Graphics.FromImage(background);
            graphics.Clear(Color.Black);
            graphics.DrawRectangle(Pens.Red, cellSize - 1, cellSize, (width - 1) * cellSize, (height - 1) * cellSize);
            //Покраска приземлившихся фигур
            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                    if (field[i,j] == 1) // избавляет от проблемы с закрашиванием всего поля
                    graphics.FillRectangle(
                        Brushes.Green,
                        i * cellSize,
                        j * cellSize,
                        (cellSize - 1) * 1, //Для зазоров
                        (cellSize - 1) * 1); // пофакту, оно красит все поле, но там где
            //клеток нет, получаются зеленые вырожденные квадраты. Если заменить на просто 1, то закрасится все

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

        private void TickTimer_Tick(object sender, EventArgs e)
        {
            if (field[8, 4] == 1)
                Environment.Exit(0);
            DestroyFilledLines();
            Move(0, 1);
            IterationCounter.Text = currentIteration++.ToString();
            
        }

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
        private void Form1_KeyUp(object sender, KeyEventArgs e) => TickTimer.Interval = 250;
   

        public void DestroyFilledLines()
        {
            IEnumerable<int> lines = Enumerable.Range(0, height);
            IEnumerable<int> columns = Enumerable.Range(0, width);
            //Проходит по всему полю и проверяет заполненность каждой строки, если она заполнена
            //То добавляется в Enumerable и затем строки с этими индексами смещаются
            IEnumerable<int> linqCall = from i in lines
                                        where columns.Select(j => field[j, i]).Sum() >= width - 1
                                        select i;
            foreach (int i in linqCall)
            {
                for (int k = i; k > 1; k--)
                    for (int l = 1; l < width; l++)
                        field[l, k] = field[l, k - 1];
            }
        }
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
            FillField();
        }

        public bool FindMistake()
        {
            for (int i = 0; i < 4; i++)
                //Первые четыре строки - выход за границы, последняя - наложение
                if (figure[1, i] == width
                    || figure[0, i] == height
                    || figure[1, i] == 0
                    || figure[0, i] == 0
                    || field[figure[1, i], figure[0, i]] == 1)
                    return true;          
            return false;
        }
    }
}