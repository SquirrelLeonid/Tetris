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
            this.ScoreBox = new System.Windows.Forms.TextBox();
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
            // ScoreBox
            // 
            this.ScoreBox.Enabled = false;
            this.ScoreBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ScoreBox.Location = new System.Drawing.Point(260, 12);
            this.ScoreBox.Multiline = true;
            this.ScoreBox.Name = "ScoreBox";
            this.ScoreBox.Size = new System.Drawing.Size(190, 60);
            this.ScoreBox.TabIndex = 1;
            this.ScoreBox.Text = "Ваш счет: ";
            // 
            // TetrisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 511);
            this.Controls.Add(this.ScoreBox);
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
        private System.Windows.Forms.TextBox ScoreBox;
    }
}

