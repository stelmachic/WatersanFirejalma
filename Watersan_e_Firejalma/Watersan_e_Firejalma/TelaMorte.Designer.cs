namespace Watersan_e_Firejalma
{
    partial class TelaMorte
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
            this.FundoPb.BackColor = System.Drawing.Color.Transparent;
            this.FundoPb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FundoPb.Location = new System.Drawing.Point(0, 0);
            this.FundoPb.Name = "FundoPb";
            this.FundoPb.Size = new System.Drawing.Size(736, 423);
            this.FundoPb.TabIndex = 1;
            this.FundoPb.TabStop = false;
            this.FundoPb.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FundoPb_MouseDown);
            this.FundoPb.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FundoPb_MouseMove);
            this.FundoPb.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FundoPb_MouseUp);
            // 
            // TelaMorte
            // 
            this.ClientSize = new System.Drawing.Size(736, 423);
            this.Controls.Add(this.FundoPb);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TelaMorte";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TelaMorte_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TelaMorte_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.FundoPb)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox FundoPb;
    }
}