namespace Watersan_e_Firejalma
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.pb = new System.Windows.Forms.PictureBox();
            this.fff = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PosX = new System.Windows.Forms.Label();
            this.PosY = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pb)).BeginInit();
            this.SuspendLayout();
            // 
            // pb
            // 
            this.pb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb.Location = new System.Drawing.Point(0, 0);
            this.pb.Name = "pb";
            this.pb.Size = new System.Drawing.Size(800, 450);
            this.pb.TabIndex = 0;
            this.pb.TabStop = false;
            // 
            // fff
            // 
            this.fff.AutoSize = true;
            this.fff.Location = new System.Drawing.Point(638, 28);
            this.fff.Name = "fff";
            this.fff.Size = new System.Drawing.Size(35, 13);
            this.fff.TabIndex = 1;
            this.fff.Text = "PosX:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(638, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "PosY:";
            // 
            // PosX
            // 
            this.PosX.AutoSize = true;
            this.PosX.Location = new System.Drawing.Point(679, 28);
            this.PosX.Name = "PosX";
            this.PosX.Size = new System.Drawing.Size(35, 13);
            this.PosX.TabIndex = 3;
            this.PosX.Text = "PosX:";
            // 
            // PosY
            // 
            this.PosY.AutoSize = true;
            this.PosY.Location = new System.Drawing.Point(679, 56);
            this.PosY.Name = "PosY";
            this.PosY.Size = new System.Drawing.Size(35, 13);
            this.PosY.TabIndex = 4;
            this.PosY.Text = "PosX:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PosY);
            this.Controls.Add(this.PosX);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fff);
            this.Controls.Add(this.pb);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pb;
        private System.Windows.Forms.Label fff;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label PosX;
        private System.Windows.Forms.Label PosY;
    }
}

