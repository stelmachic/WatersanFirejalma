﻿namespace Watersan_e_Firejalma
{
    partial class TelaInicial
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
            this.fundo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.fundo)).BeginInit();
            this.SuspendLayout();
            // 
            // fundo
            // 
            this.fundo.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.fundo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fundo.Image = global::Watersan_e_Firejalma.Properties.Resources.Design_sem_nome__2_;
            this.fundo.Location = new System.Drawing.Point(0, 0);
            this.fundo.Name = "fundo";
            this.fundo.Size = new System.Drawing.Size(800, 450);
            this.fundo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.fundo.TabIndex = 0;
            this.fundo.TabStop = false;
            this.fundo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.fundo_MouseDown);
            this.fundo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.fundo_MouseMove);
            this.fundo.MouseUp += new System.Windows.Forms.MouseEventHandler(this.fundo_MouseUp);
            // 
            // TelaInicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.fundo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TelaInicial";
            this.Text = "TelaInicial";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TelaInicial_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TelaInicial_KeyUp_1);
            ((System.ComponentModel.ISupportInitialize)(this.fundo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox fundo;
    }
}