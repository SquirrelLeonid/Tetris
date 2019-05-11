namespace Tetris
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
            this.FieldPictureBox = new System.Windows.Forms.PictureBox();
            this.TickTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.FieldPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // FieldPictureBox
            // 
            this.FieldPictureBox.Location = new System.Drawing.Point(13, 13);
            this.FieldPictureBox.Name = "FieldPictureBox";
            this.FieldPictureBox.Size = new System.Drawing.Size(403, 476);
            this.FieldPictureBox.TabIndex = 0;
            this.FieldPictureBox.TabStop = false;
            // 
            // TickTimer
            // 
            this.TickTimer.Enabled = true;
            this.TickTimer.Interval = 250;////********/////
            this.TickTimer.Tick += new System.EventHandler(this.TickTimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 619);
            this.Controls.Add(this.FieldPictureBox);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Tetris";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.FieldPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox FieldPictureBox;
        private System.Windows.Forms.Timer TickTimer;
    }
}

