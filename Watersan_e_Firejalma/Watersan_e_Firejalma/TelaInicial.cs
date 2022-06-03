using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Watersan_e_Firejalma
{
    public partial class TelaInicial : Form
    {

        Graphics g = null;
        Bitmap bmp = null;
        Timer tm = new Timer();
        Image fundo = null;
        RectangleF tela;
        RectangleF buttonPos;
        Size buttonSize;

        Point cursor = Point.Empty;
        bool down = false;

        public TelaInicial()
        {
            InitializeComponent();
            tm.Interval = 25;


            tm.Tick += delegate
            {

                g.DrawImage(fundo, tela);

                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Center;

                if (buttonPos.Contains(cursor))
                {
                    g.DrawString("Play", new Font("Thayer Street NDP", 70f), Brushes.Goldenrod, buttonPos, sf);
                
                    if (down)
                    {
                        Game telanova = new Game();
                        telanova.Show();
                        if (Application.OpenForms[0] == this)
                            this.Hide();
                        else this.Close();
                        tm.Stop();
                        return;
                    }
                }
                else
                {
                    g.DrawString("Play", new Font("Thayer Street NDP", 70f), Brushes.Black, buttonPos, sf);
                }


                FundoPb.Image = bmp;
            };
        }

       

        private void TelaInicial_Load(object sender, EventArgs e)
        {
            bmp = new Bitmap(this.Width, this.Height);
            g = Graphics.FromImage(bmp);


            buttonSize = new Size(300, 125);
            buttonPos = new RectangleF((this.Width / 2) - (buttonSize.Width / 2) - 30, (this.Height / 2) - (buttonSize.Height / 2) + 100, buttonSize.Width, buttonSize.Height);

            tela = new RectangleF(0, 0, FundoPb.Width, FundoPb.Height);

            fundo = Properties.Resources.TelaInicio;

            tm.Start();
        }

        private void TelaInicial_KeyUp_1(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {

                case Keys.Escape:
                    Application.Exit();
                    break;
            }
        }
        
        private void fundo_MouseDown(object sender, MouseEventArgs e)
        {
            down = true;
        }

        private void fundo_MouseMove(object sender, MouseEventArgs e)
        {
            cursor = e.Location;
        }

        private void fundo_MouseUp(object sender, MouseEventArgs e)
        {
            down = false;
        }

    }
}
