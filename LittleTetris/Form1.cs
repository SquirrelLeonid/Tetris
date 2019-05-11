using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;

namespace LittleTetris
{
    
    public partial class TetrisForm : Form
    {
        public const int horizontalCellsCount = 15, verticalCellsCount = 25, cellSize = 15;
        //Помещается 14 клеток
        //Width и height Это количество клеток, которое вмещает в себя поле
        //Думаю их стоит высчитывать исходя из размера окна
        
        // Надо еще раз подумать над тем, как реализовать фигуру, возможно как то получиться улучшить
        // Массив для хранения падающей фигурки (для каждого блока 2 координаты [0, i] и [1, i]
        public int[,] figure = new int[2, 4];
        public int[,] field = new int[horizontalCellsCount, verticalCellsCount]; // Массив для хранения поля
        public Bitmap background = new Bitmap(cellSize * (horizontalCellsCount + 1), cellSize * (verticalCellsCount + 1));
        public GameModel gameModel = new GameModel();

        //Остается тут
        public TetrisForm()
        {
            InitializeComponent();            
            figure = gameModel.CreateFigure();
        }

        //ЭТО ЧИСТО ОТРИСОВКА. ТУТ НЕЧЕГО МЕНЯТЬ.
        //Вызывается, когда фигура приземляется
        public void FillField()
        {
            Graphics graphics = Graphics.FromImage(background);
            //Очистка поля путем закрашивания background <выбранным> цветом
            graphics.Clear(Color.Black);
            //Окантовка в пределах backgound. Выделяет игровую область
            graphics.DrawRectangle(Pens.Red, cellSize-1, cellSize, (horizontalCellsCount - 1) * cellSize + 1, (verticalCellsCount - 1) * cellSize);

            for (int i = 0; i < horizontalCellsCount; i++)
                for (int j = 0; j < verticalCellsCount; j++)
                    //Покраска фигур, которые приземлились
                    graphics.FillRectangle(
                        Brushes.Green,
                        i * cellSize, //*/Вершина прямоугольника
                        j * cellSize, //*/
                        (cellSize - 1) * field[i, j], //*/ -1 для того, чтобы был зазор между фигурами
                        (cellSize - 1) * field[i, j]);//*/

            //В цикле покраска фигуры до тех пор пока она падает.
            for (int i = 0; i < 4; i++)
                graphics.FillRectangle(
                    Brushes.Red,
                    figure[1, i] * cellSize,
                    figure[0, i] * cellSize,
                    cellSize - 1,
                    cellSize - 1);

            FieldPictureBox.Image = background; // Обновление состояния окна после отрисовки фигур
        }

        //С этим я разберусь думаю, куда совать потом разберемся
        private void TickTimer_Tick(object sender, EventArgs e)
        {
            if (field[8, 4] == 1)
                Environment.Exit(0);              
            foreach(int i in (from i in Enumerable.Range(0, field.GetLength(1))
                              where (Enumerable.Range(0, field.GetLength(0))
                              .Select(j => field[j, i]).Sum() >= horizontalCellsCount - 1) select i)
                              .ToArray().Take(1)) 
                for (int k = i; k > 1; k--)
                    for (int l = 1; l < horizontalCellsCount; l++)
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
   
        //По стандарту падает только вниз, т.е скорость (0,1)
        //Возможно вынести в модель?
        public new void Move(int xSpeed, int ySpeed)
        {        
            //Опиши подробней, как проходит смещение фигуры вниз?
            //Не совсем понимаю Что тут меняется из-за индексов 1 и 0

            for (int i = 0; i < 4; i++) //Потому что все фигуры состоят из 4 клеток
            {
                figure[1, i] += xSpeed;
                figure[0, i] += ySpeed;
            }

            //Если нашлась ошибка
            if (FindMistake())
            { 
                //ПЕРЕПИШИ ТАК, ЧТОБЫ СНАЧАЛА БЫЛА ПРОВЕРКА, А ПОТОМ СДВИг
                //Двигаем обратно вверх
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
                if (figure[1, i] >= horizontalCellsCount
                    || figure[0, i] >= verticalCellsCount
                    || figure[1, i] <= 0
                    || figure[0, i] <= 0
                    || field[figure[1, i], figure[0, i]] == 1)
                    return true;
            return false;
        }
    }
}