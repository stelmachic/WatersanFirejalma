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
        objeto bloco = new objeto();
        //objeto chao = new objeto();
        //objeto paredeEsquerda = new objeto();
        //objeto paredeDireita = new objeto();


        

        public Form1()
        {
            InitializeComponent();
            tm.Interval = 25;

            

            tm.Tick += delegate 
            {
                frame++;

               

                if (frame % frameRate == 0)
                {
                    g.Clear(Color.White);
                }

                bloco.DrawObject(g);
              
                foreach (Personagem personagem in personagens)
                {
           

                    if (personagem.IsJumping)
                    {
                        personagem.Jump();
                        personagem.IsGrounded = false;
                    }
                    if (personagem.IsMoving)
                    {
                        personagem.checkCollission(bloco);
                        
                        personagem.Move();
                    }

                    

                    if (frame % frameRate == 0)
                    {
                        personagem.Animate(g);
                    }

                    personagem.drawHitBox(g);



                    // ---------------------------------------------- GAMBIARRAS ATE CRIAR SISTEMA DE COLISÃO -----------------------------------------------

                    // COLISÕES TEMPORARIAS EDJALMA
                    if (personagem.PosY + personagem.Resolucaoy > pb.Height) // chão
                    {
                        personagem.IsGrounded = true;
                        personagem.IsJumping = false;

                        personagem.SpeedY = 0;
                        personagem.PosY = pb.Height - personagem.Resolucaoy;
                    }
                    if (personagem.PosX + personagem.Resolucaox > pb.Width) // parede direita
                    {
                        personagem.SpeedX = 0;
                        personagem.PosX = pb.Width - personagem.Resolucaox;
                    }
                    else if (personagem.PosX+(personagem.HitBoxX1/2) < 0) // parede esquerda
                    {
                        personagem.SpeedX = 0;
                        personagem.PosX = 0-(personagem.HitBoxX1/2);
                    }
                    else
                    {
                        personagem.SpeedX = 20;
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


            List<Point> coordenadasObjeto = new List<Point>();
            coordenadasObjeto.Add( new Point(400, 300));
            coordenadasObjeto.Add(new Point(400, 450));
            coordenadasObjeto.Add(new Point(550, 450));
            coordenadasObjeto.Add(new Point(550, 300));
            bloco.CriarObjeto(coordenadasObjeto);

            //coordenadasObjeto.Clear();
            //coordenadasObjeto.Add(new Point(0, pb.Height));
            //coordenadasObjeto.Add(new Point(pb.Width, pb.Height));
            //chao.CriarObjeto(coordenadasObjeto);

            //coordenadasObjeto.Clear();
            //coordenadasObjeto.Add(new Point(0, 0));
            //coordenadasObjeto.Add(new Point(0, pb.Height));
            //paredeEsquerda.CriarObjeto(coordenadasObjeto);

            //coordenadasObjeto.Clear();
            //coordenadasObjeto.Add(new Point(pb.Width, 0));
            //coordenadasObjeto.Add(new Point(pb.Width, pb.Height));
            //paredeDireita.CriarObjeto(coordenadasObjeto);

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







