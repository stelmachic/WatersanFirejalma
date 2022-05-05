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
        Timer tm = new Timer();
        int frameRate = 2;
        int frame = 0;
        Bitmap bmp = null;
        Graphics g = null;
        Personagem edjalma = new Edjalma();
        Personagem trevisan = new Trevisan();
        List<Personagem> personagens = new List<Personagem>();


        public Form1()
        {
            InitializeComponent();
            tm.Interval = 25;

            

            tm.Tick += delegate 
            {
                frame++;
                foreach (Personagem personagem in personagens)
                {
                    if (personagem.IsJumping)
                    {
                        personagem.Jump();
                        personagem.IsGrounded = false;
                    }
                    if (personagem.IsMoving)
                    {
                        personagem.Move();
                    }

                    personagem.Animate(g);

                    if (frame % frameRate == 0)
                    {
                        
                    }


                    // ---------------------------------------------- GAMBIARRAS ATE CRIAR SISTEMA DE COLISÃO -----------------------------------------------

                    // COLISÕES TEMPORARIAS EDJALMA
                    if (personagem.PosY + 200 > pb.Height) // chão
                    {
                        personagem.IsGrounded = true;
                        personagem.IsJumping = false;

                        personagem.SpeedY = 0;
                        personagem.PosY = pb.Height - 200;
                    }
                    if (personagem.PosX + 200 > pb.Width) // parede direita
                    {
                        personagem.SpeedX = 0;
                        personagem.PosX = pb.Width - 200;
                    }
                    if (personagem.PosX < 0) // parede esquerda
                    {
                        personagem.SpeedX = 0;
                        personagem.PosX = 0;
                    }
                }


                pb.Image = bmp;
            };
        }



        private void Form1_Load(object sender, EventArgs e)
        {

            bmp = new Bitmap(pb.Width, pb.Height);
            g = Graphics.FromImage(bmp);


            //personagens.Add(trevisan);
            personagens.Add(edjalma);

            edjalma.PosY = pb.Height - 200;

            trevisan.PosY = pb.Height - 200; 
            trevisan.PosX = 150;

            foreach(Personagem personagem in personagens)
            {
                personagem.Fatiar(8, 5);
            }

            tm.Start();

        }



        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            foreach (Personagem personagem in personagens)
            {
                personagem.KeyCheck(e.KeyCode, true);
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            foreach (Personagem personagem in personagens)
            {
                personagem.KeyCheck(e.KeyCode, false);
            }
        }
    }

}







