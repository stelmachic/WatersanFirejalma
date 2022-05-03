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
        Personagem edjalma = new Edjalma();

 
        public Form1()
        {
            InitializeComponent();
            tm.Interval = 25;

            tm.Tick += delegate 
            {          
                if (edjalma.IsJumping)
                {
                    edjalma.Jump();
                    edjalma.IsGrounded = false;
                }
                if (edjalma.IsMoving)
                {                 
                    edjalma.Move();
                }


                frame++;
                if(frame%frameRate == 0)
                {
                    pb.Image = edjalma.Animate();
                }
                






                // COLISÕES TEMPORARIAS
                if (edjalma.PosY + 200 > pb.Height) // chão
                {
                    edjalma.IsGrounded = true;
                    edjalma.IsJumping = false;
                    

                    edjalma.SpeedY = 0;
                    edjalma.PosY = pb.Height - 200;
                }
                if (edjalma.PosX + 200 > pb.Width) // parede direita
                {
                    edjalma.SpeedX = 0;
                    edjalma.PosX = pb.Width - 200;
                }
                if (edjalma.PosX < 0) // parede esquerda
                {
                    edjalma.SpeedX = 0;
                    edjalma.PosX = 0;
                }
            };
        }



        private void Form1_Load(object sender, EventArgs e)
        {

            edjalma.Bmp = new Bitmap(pb.Width, pb.Height);
            edjalma.Graphics = Graphics.FromImage(edjalma.Bmp);

            edjalma.PosY = pb.Height - 200; // Define a altura inicial do personagem
            edjalma.Fatiar(8,5);
            tm.Start();

        }



        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    Application.Exit();
                    break;


                case Keys.Left:

                    edjalma.Orientar(-1);
                    edjalma.IsMoving = true;
                    
                    break;

                case Keys.Right:

                    edjalma.Orientar(1);
                    edjalma.IsMoving = true;
                    
                    break;



                case Keys.Up:

                    edjalma.IsJumping = true;

                    break;
            }
        }

        

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:

                    edjalma.IsMoving = false;
             
                    break;
                case Keys.Right:

                    edjalma.IsMoving = false;

                    break;
            }
        }
    }

}







