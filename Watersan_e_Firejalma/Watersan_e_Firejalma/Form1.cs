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
    public partial class Form1 : Form
    {

        Bitmap bmp = null;
        Graphics g = null;
        Timer tm = new Timer();
        Timer anim = new Timer();
        Timer idle = new Timer();
  

        Image img = new Bitmap(@"C:\Users\Aluno\Documents\a\Arte\Sprite Sheet trevisharp.png");
        int x = 20;
        int y = 20;
        int dg = 1;
        int dx = 0;
        int dy = 0;
        int resolucaox = 32;
        int resolucaoy = 32;

        public Form1()
        {
            InitializeComponent();
            tm.Interval = 25;
            anim.Interval = 50;
            idle.Interval = 25;

            int sx = 0;


            tm.Tick += delegate
            {
                x += dx;
                dy += dg;
                y += dy;

                if (y + 200 > bmp.Height) // chão
                {
                    dy = 0;
                    y = bmp.Height - 200;
                }
                if (x + 200 > bmp.Width) // parede direita
                {
                    dx = 0;
                    x = bmp.Width - 200;
                }
                if (x < 0) // parede esquerda
                {
                    dx = 0;
                    x = 0;
                }

                pb.Image = bmp;
            };

            anim.Tick += delegate
            {
                g.Clear(Color.White);

                sx += 32;
                if (sx == 32 * 8)
                    sx = 0;

                g.DrawImage(img, new Rectangle(x, y, 200, 200), new Rectangle(sx, 0, resolucaox, resolucaoy), GraphicsUnit.Pixel);
            };

            idle.Tick += delegate
            {
                g.Clear(Color.White);

                g.DrawImage(img, new Rectangle(x, y, 200, 200), new Rectangle(0, 0, resolucaox, resolucaoy), GraphicsUnit.Pixel);
            };
        }



        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    Application.Exit();
                    break;
                case Keys.Left:
                    idle.Stop();
                    anim.Start();
                    dx = -15;
                    break;
                case Keys.Right:
                    idle.Stop();
                    anim.Start();
                    dx = 15;
                    break;
                case Keys.Up:
                    if (y == bmp.Height - 200)
                    {
                        idle.Start();
                        dy = -20;
                    }
                    break;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bmp = new Bitmap(pb.Width, pb.Height);
            g = Graphics.FromImage(bmp);
            tm.Start();
            idle.Start();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    anim.Stop();
                    idle.Start();
                    dx = 0;
                    break;
                case Keys.Right:
                    anim.Stop();
                    idle.Start();
                    dx = 0;
                    break;
            }
        }
    }

}







