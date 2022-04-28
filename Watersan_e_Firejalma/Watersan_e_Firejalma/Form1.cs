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

        Personagem edjalma = new Edjalma();

       
 
        public Form1()
        {
            InitializeComponent();
            tm.Interval = 25;
            anim.Interval = 50;
            idle.Interval = 25;
            int sx = 0;


    
            

            tm.Tick += delegate // MOVIMENTACAO
            {


                if (edjalma.PosY + 200 > bmp.Height) // chão
                {
                    edjalma.SpeedY = 0;
                    edjalma.PosY = bmp.Height - 200;
                }
                if (edjalma.PosX + 200 > bmp.Width) // parede direita
                {
                    edjalma.SpeedX = 0;
                    edjalma.PosX = bmp.Width - 200;
                }
                if (edjalma.PosX < 0) // parede esquerda
                {
                    edjalma.SpeedX = 0;
                    edjalma.PosX = 0;
                }
            };

            anim.Tick += delegate // ANIMACAO MOVIMENTO
            {
                g.Clear(Color.White);     

                sx += edjalma.Resolucaox;
                if (sx == edjalma.Resolucaox * 8)
                    sx = 0;
                
                g.DrawImage(edjalma.SpriteSheet, new Rectangle(edjalma.PosX, edjalma.PosY, 200, 200), new Rectangle(sx, 0, edjalma.Resolucaox, edjalma.Resolucaoy), GraphicsUnit.Pixel);
                pb.Image = bmp;
                
            };

            idle.Tick += delegate
            {
                g.Clear(Color.White);

                g.DrawImage(edjalma.SpriteSheet, new Rectangle(edjalma.PosX, edjalma.PosY, 200, 200), new Rectangle(0, 0, edjalma.Resolucaox, edjalma.Resolucaoy), GraphicsUnit.Pixel);
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
                    edjalma.MoveLeft();  
                   
                    break;



                case Keys.Right: 
                    idle.Stop();
                    anim.Start();
                    edjalma.MoveRight();
                  
                    break;



                case Keys.Up:
                    
                        idle.Start();
                        edjalma.Jump();
                    
                    break;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bmp = new Bitmap(pb.Width, pb.Height);
            g = Graphics.FromImage(bmp);
            edjalma.PosY = pb.Height-200;
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
             
                    break;
                case Keys.Right:
                    anim.Stop();
                    idle.Start();
              
                    break;
            }
        }
    }

}







