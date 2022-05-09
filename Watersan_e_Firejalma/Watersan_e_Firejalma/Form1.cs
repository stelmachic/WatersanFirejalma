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
        Box bloco = null;
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

                bloco.Draw(g);
              
                foreach (Personagem personagem in personagens)
                {
           

                    if (personagem.isJumping)
                    {
                        personagem.Jump();
                        personagem.isGrounded = false;
                    }
                    if (personagem.isMoving)
                    {
                        personagem.checkCollission(bloco);
                        
                        personagem.Move();
                    }

                    

                    if (frame % frameRate == 0)
                    {
                        personagem.Draw(g);
                    }

                    personagem.DrawHitBox(g);



                    // ---------------------------------------------- GAMBIARRAS ATE CRIAR SISTEMA DE COLISÃO -----------------------------------------------

                    // COLISÕES TEMPORARIAS EDJALMA
                    if (personagem.posY + personagem.resolucaoy > pb.Height) // chão
                    {
                        personagem.isGrounded = true;
                        personagem.isJumping = false;

                        personagem.speedY = 0;
                        personagem.posY = pb.Height - personagem.resolucaoy;
                    }
                    if (personagem.posX + personagem.resolucaox > pb.Width) // parede direita
                    {
                        personagem.speedX = 0;
                        personagem.posX = pb.Width - personagem.resolucaox;
                    }
                    else if (personagem.posX+(personagem.width/2) < 0) // parede esquerda
                    {
                        personagem.speedX = 0;
                        personagem.posX = 0-(personagem.width/2);
                    }
                    else
                    {
                        personagem.speedX = 20;
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

            edjalma.posY = pb.Height - 200;

            trevisan.posY = pb.Height - 200; 
            trevisan.posX = 150;

            foreach(Personagem personagem in personagens)
            {
                personagem.Fatiar(8, 5);
            }


            bloco = new Box(400,300, 150, 150);

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







