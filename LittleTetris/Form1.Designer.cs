namespace LittleTetris
{
    partial class TetrisForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TetrisForm));
            this.GameField = new System.Windows.Forms.PictureBox();
            this.TickTimer = new System.Windows.Forms.Timer(this.components);
            this.IterationCounter = new System.Windows.Forms.TextBox();
            this.IterationLabel = new System.Windows.Forms.Label();
            this.ScoreCount = new System.Windows.Forms.Label();
            this.Score = new System.Windows.Forms.TextBox();
            this.LinesCount = new System.Windows.Forms.Label();
            this.Lines = new System.Windows.Forms.TextBox();
            this.BackGround = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.GameField)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BackGround)).BeginInit();
            this.SuspendLayout();
            // 
            // GameField
            // 
            this.GameField.Location = new System.Drawing.Point(74, 41);
            this.GameField.Margin = new System.Windows.Forms.Padding(2);
            this.GameField.Name = "GameField";
            this.GameField.Size = new System.Drawing.Size(225, 375);
            this.GameField.TabIndex = 0;
            this.GameField.TabStop = false;
            // 
            // TickTimer
            // 
            this.TickTimer.Enabled = true;
            this.TickTimer.Interval = 250;
            this.TickTimer.Tick += new System.EventHandler(this.TickTimer_Tick);
            // 
            // IterationCounter
            // 
            this.IterationCounter.Enabled = false;
            this.IterationCounter.Location = new System.Drawing.Point(89, 520);
            this.IterationCounter.Name = "IterationCounter";
            this.IterationCounter.Size = new System.Drawing.Size(58, 20);
            this.IterationCounter.TabIndex = 2;
            // 
            // IterationLabel
            // 
            this.IterationLabel.AutoSize = true;
            this.IterationLabel.Location = new System.Drawing.Point(13, 523);
            this.IterationLabel.Name = "IterationLabel";
            this.IterationLabel.Size = new System.Drawing.Size(70, 13);
            this.IterationLabel.TabIndex = 3;
            this.IterationLabel.Text = "Итерация №";
            // 
            // ScoreCount
            // 
            this.ScoreCount.AutoSize = true;
            this.ScoreCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ScoreCount.Location = new System.Drawing.Point(11, 450);
            this.ScoreCount.Name = "ScoreCount";
            this.ScoreCount.Size = new System.Drawing.Size(198, 29);
            this.ScoreCount.TabIndex = 4;
            this.ScoreCount.Text = "Набрано очков: ";
            // 
            // Score
            // 
            this.Score.Enabled = false;
            this.Score.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Score.Location = new System.Drawing.Point(215, 453);
            this.Score.Name = "Score";
            this.Score.Size = new System.Drawing.Size(84, 32);
            this.Score.TabIndex = 5;
            // 
            // LinesCount
            // 
            this.LinesCount.AutoSize = true;
            this.LinesCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LinesCount.Location = new System.Drawing.Point(11, 488);
            this.LinesCount.Name = "LinesCount";
            this.LinesCount.Size = new System.Drawing.Size(242, 29);
            this.LinesCount.TabIndex = 6;
            this.LinesCount.Text = "Линий уничтожено:";
            // 
            // Lines
            // 
            this.Lines.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Lines.Enabled = false;
            this.Lines.Location = new System.Drawing.Point(259, 497);
            this.Lines.Name = "Lines";
            this.Lines.Size = new System.Drawing.Size(40, 20);
            this.Lines.TabIndex = 7;
            // 
            // BackGround
            // 
            this.BackGround.Image = global::LittleTetris.Properties.Resources.BackGround;
            this.BackGround.Location = new System.Drawing.Point(42, 12);
            this.BackGround.Name = "BackGround";
            this.BackGround.Size = new System.Drawing.Size(290, 435);
            this.BackGround.TabIndex = 8;
            this.BackGround.TabStop = false;
            // 
            // TetrisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 561);
            this.Controls.Add(this.Lines);
            this.Controls.Add(this.LinesCount);
            this.Controls.Add(this.Score);
            this.Controls.Add(this.ScoreCount);
            this.Controls.Add(this.IterationLabel);
            this.Controls.Add(this.IterationCounter);
            this.Controls.Add(this.GameField);
            this.Controls.Add(this.BackGround);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "TetrisForm";
            this.Text = "Tetris";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.GameField)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BackGround)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox GameField;
        private System.Windows.Forms.Timer TickTimer;
        private System.Windows.Forms.TextBox IterationCounter;
        private System.Windows.Forms.Label IterationLabel;
        private System.Windows.Forms.Label ScoreCount;
        private System.Windows.Forms.TextBox Score;
        private System.Windows.Forms.Label LinesCount;
        private System.Windows.Forms.TextBox Lines;
        private System.Windows.Forms.PictureBox BackGround;
    }
}

