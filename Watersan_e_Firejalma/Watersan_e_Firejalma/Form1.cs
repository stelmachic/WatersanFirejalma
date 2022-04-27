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


        Image img = new Bitmap(@"C:\Users\Aluno\Documents\a\Arte\Sprite Sheet Edjalma.png");
 
        public Form1()
        {
            InitializeComponent();
            tm.Interval = 25;
            anim.Interval = 50;
            idle.Interval = 25;
            int sx = 0;


            Personagem edjalma = new Edjalma();

            

            

            tm.Tick += delegate // MOVIMENTACAO
            {
                edjalma.PosX += edjalma.SpeedX;
                edjalma.SpeedY += edjalma.Gravity;
                edjalma.PosY += edjalma.SpeedY;

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
            };

            anim.Tick += delegate // ANIMACAO MOVIMENTO
            {
                g.Clear(Color.White);     

                sx += resolucaox;
                if (sx == resolucaox * 8)
                    sx = 0;
                
                g.DrawImage(img, new Rectangle(x, y, 200, 200), new Rectangle(sx, 0, resolucaox, resolucaoy), GraphicsUnit.Pixel);
                pb.Image = bmp;
                
            };

            idle.Tick += delegate
            {
                g.Clear(Color.White);

                g.DrawImage(img, new Rectangle(x, y, 200, 200), new Rectangle(0, 0, resolucaox, resolucaoy), GraphicsUnit.Pixel);
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
                    idle.Stop();
                    anim.Start();
                    if (orientacao == 1)
                    {
                        img.RotateFlip(RotateFlipType.Rotate180FlipY);
                    }
                    dx = -15;
                    orientacao = -1;
                    break;

                case Keys.Right: 
                    idle.Stop();
                    anim.Start();
                    dx = 15;
                    if (orientacao == -1)
                    {
                        img.RotateFlip(RotateFlipType.Rotate180FlipY);
                    }
                    orientacao = 1;
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
            y = pb.Height-200;
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







