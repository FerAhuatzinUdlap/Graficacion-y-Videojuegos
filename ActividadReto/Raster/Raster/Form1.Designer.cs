namespace Raster
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            PCT_CANVAS = new PictureBox();
            TIMER = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)PCT_CANVAS).BeginInit();
            SuspendLayout();
            // 
            // PCT_CANVAS
            // 
            PCT_CANVAS.Location = new Point(46, 28);
            PCT_CANVAS.Margin = new Padding(2);
            PCT_CANVAS.Name = "PCT_CANVAS";
            PCT_CANVAS.Size = new Size(1530, 919);
            PCT_CANVAS.TabIndex = 0;
            PCT_CANVAS.TabStop = false;
            PCT_CANVAS.Click += pictureBox1_Click;
            // 
            // TIMER
            // 
            TIMER.Enabled = true;
            TIMER.Tick += TIMER_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(1587, 958);
            Controls.Add(PCT_CANVAS);
            Margin = new Padding(2);
            Name = "Form1";
            Text = "Form1";
            WindowState = FormWindowState.Maximized;
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)PCT_CANVAS).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox PCT_CANVAS;
        private System.Windows.Forms.Timer TIMER;
    }
}
