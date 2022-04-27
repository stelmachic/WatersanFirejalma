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


        public Form1()
        {
            InitializeComponent();
            tm.Interval = 25;
            anim.Interval = 50;
            idle.Interval = 50;

            int sx = 0;

            tm.Tick += delegate
            {

                x += dx;
                dy += dg;
                y += dy;

                if (y + 200 > pb.Height)
                {
                    dy = 0;
                    y = pb.Height - 200;
                }
            };

            anim.Tick += delegate
            {
                g.Clear(Color.White);
                sx += 32;
                if (sx == 32 * 8)
                    sx = 0;

                g.DrawImage(img, new Rectangle(x, y, 200, 200), new Rectangle(sx, 0, 32, 32), GraphicsUnit.Pixel);
                pb.Image = bmp;


            };

            idle.Tick += delegate
            {
                g.Clear(Color.White);
                g.DrawImage(img, new Rectangle(x, y, 200, 200), new Rectangle(0, 0, 32, 32), GraphicsUnit.Pixel);
                pb.Image = bmp;
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
                    anim.Start();
                    idle.Stop();
                    dx = -15;
                    break;
                case Keys.Right:
                    anim.Start();
                    idle.Stop();
                    dx = 15;
                    break;
                case Keys.Up:
                    if (y == bmp.Height - 200)
                    {
                        dy = -20;
                    }
                    break;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            tm.Start();
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







