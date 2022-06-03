namespace Watersan_e_Firejalma
{
    partial class TelaVitoria
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.FundoPb = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.FundoPb)).BeginInit();
            this.SuspendLayout();
            // 
            // FundoPb
            // 
            this.FundoPb.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.FundoPb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FundoPb.Location = new System.Drawing.Point(0, 0);
            this.FundoPb.Name = "FundoPb";
            this.FundoPb.Size = new System.Drawing.Size(1057, 596);
            this.FundoPb.TabIndex = 0;
            this.FundoPb.TabStop = false;
            this.FundoPb.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FundoPb_MouseDown);
            this.FundoPb.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FundoPb_MouseMove);
            this.FundoPb.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FundoPb_MouseUp);
            // 
            // TelaVitoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1057, 596);
            this.Controls.Add(this.FundoPb);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TelaVitoria";
            this.Text = "TelaVitoria";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TelaVitoria_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TelaVitoria_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.FundoPb)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox FundoPb;
    }
}