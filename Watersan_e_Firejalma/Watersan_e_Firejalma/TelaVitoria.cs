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
    public partial class TelaVitoria : Form
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



        public TelaVitoria()
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
                    g.DrawString("Voltar", new Font("Thayer Street NDP", 70f), Brushes.Goldenrod, buttonPos, sf);

                    if (down)
                    {
                        this.Close();
                        tm.Stop();
                        TelaInicial telanova = new TelaInicial();
                        telanova.Show();
                        return;
                    }
                }
                else
                {
                    g.DrawString("Voltar", new Font("Thayer Street NDP", 70f), Brushes.Black, buttonPos, sf);
                }


                FundoPb.Image = bmp;
            };
        }

        private void TelaVitoria_Load(object sender, EventArgs e)
        {
            bmp = new Bitmap(this.Width, this.Height);
            g = Graphics.FromImage(bmp);


            buttonSize = new Size(300, 125);
            buttonPos = new RectangleF((this.Width / 2) - (buttonSize.Width / 2) - 30, (this.Height / 2) - (buttonSize.Height / 2) + 100, buttonSize.Width, buttonSize.Height);

            tela = new RectangleF(0, 0, FundoPb.Width, FundoPb.Height);

            fundo = Properties.Resources.TelaVitoria;

            tm.Start();
        }

        private void FundoPb_MouseUp(object sender, MouseEventArgs e)
        {
            down = false;
        }

        private void FundoPb_MouseMove(object sender, MouseEventArgs e)
        {
            cursor = e.Location;
        }

        private void FundoPb_MouseDown(object sender, MouseEventArgs e)
        {
            down = true;
        }

        private void TelaVitoria_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {

                case Keys.NumPad9:
                    Application.Exit();
                    break;
            }
        }
    }
}
