namespace Watersan_e_Firejalma
{
    partial class Game
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Game));
            this.EdPoints = new System.Windows.Forms.Label();
            this.TrevPoints = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.Menu_Voltar = new System.Windows.Forms.Panel();
            this.Voltar_Button = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pb = new System.Windows.Forms.PictureBox();
            this.tutorial = new System.Windows.Forms.Panel();
            this.labelTutorial = new System.Windows.Forms.Label();
            this.buttonTutorial = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.Menu_Voltar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb)).BeginInit();
            this.tutorial.SuspendLayout();
            this.SuspendLayout();
            // 
            // EdPoints
            // 
            this.EdPoints.AutoSize = true;
            this.EdPoints.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(86)))));
            this.EdPoints.Font = new System.Drawing.Font("MingLiU-ExtB", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EdPoints.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.EdPoints.Location = new System.Drawing.Point(220, 28);
            this.EdPoints.Name = "EdPoints";
            this.EdPoints.Size = new System.Drawing.Size(45, 48);
            this.EdPoints.TabIndex = 1;
            this.EdPoints.Text = "0";
            // 
            // TrevPoints
            // 
            this.TrevPoints.AutoSize = true;
            this.TrevPoints.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(14)))), ((int)(((byte)(25)))));
            this.TrevPoints.Font = new System.Drawing.Font("MingLiU_HKSCS-ExtB", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TrevPoints.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.TrevPoints.Location = new System.Drawing.Point(71, 28);
            this.TrevPoints.Name = "TrevPoints";
            this.TrevPoints.Size = new System.Drawing.Size(45, 48);
            this.TrevPoints.TabIndex = 2;
            this.TrevPoints.Text = "0";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Bisque;
            this.panel1.Controls.Add(this.TrevPoints);
            this.panel1.Controls.Add(this.EdPoints);
            this.panel1.Controls.Add(this.pictureBox4);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(285, 85);
            this.panel1.TabIndex = 6;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::Watersan_e_Firejalma.Properties.Resources.Design_sem_nome;
            this.pictureBox4.Location = new System.Drawing.Point(0, 0);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(285, 85);
            this.pictureBox4.TabIndex = 5;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(55, 55);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(185, 6);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(55, 55);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // Menu_Voltar
            // 
            this.Menu_Voltar.BackColor = System.Drawing.Color.Silver;
            this.Menu_Voltar.BackgroundImage = global::Watersan_e_Firejalma.Properties.Resources.Voltar_fundo;
            this.Menu_Voltar.Controls.Add(this.Voltar_Button);
            this.Menu_Voltar.Controls.Add(this.pictureBox3);
            this.Menu_Voltar.Controls.Add(this.pictureBox5);
            this.Menu_Voltar.Controls.Add(this.label3);
            this.Menu_Voltar.Location = new System.Drawing.Point(767, 0);
            this.Menu_Voltar.Name = "Menu_Voltar";
            this.Menu_Voltar.Size = new System.Drawing.Size(501, 349);
            this.Menu_Voltar.TabIndex = 5;
            // 
            // Voltar_Button
            // 
            this.Voltar_Button.BackColor = System.Drawing.Color.Maroon;
            this.Voltar_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Voltar_Button.Font = new System.Drawing.Font("Thayer Street NDP", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Voltar_Button.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Voltar_Button.Location = new System.Drawing.Point(127, 245);
            this.Voltar_Button.Name = "Voltar_Button";
            this.Voltar_Button.Size = new System.Drawing.Size(227, 64);
            this.Voltar_Button.TabIndex = 7;
            this.Voltar_Button.Text = "Voltar";
            this.Voltar_Button.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Voltar_Button.Click += new System.EventHandler(this.Voltar_Button_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(134)))), ((int)(((byte)(119)))));
            this.pictureBox3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox3.Image = global::Watersan_e_Firejalma.Properties.Resources.close_icon;
            this.pictureBox3.Location = new System.Drawing.Point(446, 3);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(60, 60);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 8;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::Watersan_e_Firejalma.Properties.Resources.Fechar;
            this.pictureBox5.Location = new System.Drawing.Point(0, -3);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(512, 352);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 9;
            this.pictureBox5.TabStop = false;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("MingLiU-ExtB", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Location = new System.Drawing.Point(0, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(512, 163);
            this.label3.TabIndex = 6;
            this.label3.Text = "Deseja Voltar para o menu?";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pb
            // 
            this.pb.BackColor = System.Drawing.Color.Transparent;
            this.pb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb.Location = new System.Drawing.Point(0, 0);
            this.pb.Name = "pb";
            this.pb.Size = new System.Drawing.Size(1345, 744);
            this.pb.TabIndex = 0;
            this.pb.TabStop = false;
            // 
            // tutorial
            // 
            this.tutorial.BackColor = System.Drawing.Color.Transparent;
            this.tutorial.Controls.Add(this.buttonTutorial);
            this.tutorial.Controls.Add(this.labelTutorial);
            this.tutorial.Location = new System.Drawing.Point(102, 317);
            this.tutorial.Name = "tutorial";
            this.tutorial.Size = new System.Drawing.Size(604, 281);
            this.tutorial.TabIndex = 7;
            // 
            // labelTutorial
            // 
            this.labelTutorial.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTutorial.Location = new System.Drawing.Point(22, 31);
            this.labelTutorial.Name = "labelTutorial";
            this.labelTutorial.Size = new System.Drawing.Size(560, 177);
            this.labelTutorial.TabIndex = 0;
            this.labelTutorial.Text = resources.GetString("labelTutorial.Text");
            // 
            // buttonTutorial
            // 
            this.buttonTutorial.Location = new System.Drawing.Point(216, 223);
            this.buttonTutorial.Name = "buttonTutorial";
            this.buttonTutorial.Size = new System.Drawing.Size(157, 32);
            this.buttonTutorial.TabIndex = 1;
            this.buttonTutorial.Text = "Próximo";
            this.buttonTutorial.UseVisualStyleBackColor = true;
            this.buttonTutorial.Click += new System.EventHandler(this.buttonTutorial_Click);
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1345, 744);
            this.Controls.Add(this.tutorial);
            this.Controls.Add(this.Menu_Voltar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pb);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "Game";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.Menu_Voltar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb)).EndInit();
            this.tutorial.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pb;
        private System.Windows.Forms.Label EdPoints;
        private System.Windows.Forms.Label TrevPoints;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel Menu_Voltar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label Voltar_Button;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Panel tutorial;
        private System.Windows.Forms.Label labelTutorial;
        private System.Windows.Forms.Button buttonTutorial;
    }
}

