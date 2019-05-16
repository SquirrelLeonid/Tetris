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
            this.FieldPictureBox = new System.Windows.Forms.PictureBox();
            this.TickTimer = new System.Windows.Forms.Timer(this.components);
            this.IterationCounter = new System.Windows.Forms.TextBox();
            this.IterationLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Score = new System.Windows.Forms.TextBox();
            this.LinesCount = new System.Windows.Forms.Label();
            this.Lines = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.FieldPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // FieldPictureBox
            // 
            this.FieldPictureBox.Location = new System.Drawing.Point(0, 0);
            this.FieldPictureBox.Margin = new System.Windows.Forms.Padding(2);
            this.FieldPictureBox.Name = "FieldPictureBox";
            this.FieldPictureBox.Size = new System.Drawing.Size(255, 390);
            this.FieldPictureBox.TabIndex = 0;
            this.FieldPictureBox.TabStop = false;
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
            this.IterationCounter.Location = new System.Drawing.Point(89, 483);
            this.IterationCounter.Name = "IterationCounter";
            this.IterationCounter.Size = new System.Drawing.Size(58, 20);
            this.IterationCounter.TabIndex = 2;
            // 
            // IterationLabel
            // 
            this.IterationLabel.AutoSize = true;
            this.IterationLabel.Location = new System.Drawing.Point(13, 486);
            this.IterationLabel.Name = "IterationLabel";
            this.IterationLabel.Size = new System.Drawing.Size(70, 13);
            this.IterationLabel.TabIndex = 3;
            this.IterationLabel.Text = "Итерация №";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(11, 413);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 29);
            this.label1.TabIndex = 4;
            this.label1.Text = "Набрано очков: ";
            // 
            // Score
            // 
            this.Score.Enabled = false;
            this.Score.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Score.Location = new System.Drawing.Point(215, 416);
            this.Score.Name = "Score";
            this.Score.Size = new System.Drawing.Size(84, 32);
            this.Score.TabIndex = 5;
            // 
            // LinesCount
            // 
            this.LinesCount.AutoSize = true;
            this.LinesCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LinesCount.Location = new System.Drawing.Point(11, 451);
            this.LinesCount.Name = "LinesCount";
            this.LinesCount.Size = new System.Drawing.Size(242, 29);
            this.LinesCount.TabIndex = 6;
            this.LinesCount.Text = "Линий уничтожено:";
            // 
            // Lines
            // 
            this.Lines.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Lines.Enabled = false;
            this.Lines.Location = new System.Drawing.Point(259, 460);
            this.Lines.Name = "Lines";
            this.Lines.Size = new System.Drawing.Size(40, 20);
            this.Lines.TabIndex = 7;
            // 
            // TetrisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 511);
            this.Controls.Add(this.Lines);
            this.Controls.Add(this.LinesCount);
            this.Controls.Add(this.Score);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.IterationLabel);
            this.Controls.Add(this.IterationCounter);
            this.Controls.Add(this.FieldPictureBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "TetrisForm";
            this.Text = "Tetris";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.FieldPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox FieldPictureBox;
        private System.Windows.Forms.Timer TickTimer;
        private System.Windows.Forms.TextBox IterationCounter;
        private System.Windows.Forms.Label IterationLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Score;
        private System.Windows.Forms.Label LinesCount;
        private System.Windows.Forms.TextBox Lines;
    }
}

