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
    public class Personagem
    {
        private int posX = 20;
        private int posY = 20;
        private int gravity = 1;
        private int speedX = 15;
        private int speedY = 0;
        private int jumpForce = -20;
        private int resolucaox = (32 * 8);
        private int resolucaoy = (32 * 8);
        private int orientacao = 1;
        private bool isMoving = false;
        private bool isJumping = false;
        private bool isGrounded = false;
        private Image spriteSheet;
        private Graphics graphics = null;
        private Bitmap bmp = null;
        private int spriteX;
        private int spriteY;
        private Image[,] sprites = new Image[8,5];
        Random rnd = new Random();
        private int animChoice;
        private bool animChosen = false;
        private int frame;

        public int PosX { get => posX; set => posX = value; }
        public int PosY { get => posY; set => posY = value; }
        public int Gravity { get => gravity; set => gravity = value; }
        public int SpeedX { get => speedX; set => speedX = value; }
        public int SpeedY { get => speedY; set => speedY = value; }
        public int JumpForce { get => jumpForce; set => jumpForce = value; }
        public int Resolucaox { get => resolucaox; set => resolucaox = value; }
        public int Resolucaoy { get => resolucaoy; set => resolucaoy = value; }
        public int Orientacao { get => orientacao; set => orientacao = value; }
        public bool IsMoving { get => isMoving; set => isMoving = value; }
        public bool IsJumping { get => isJumping; set => isJumping = value; }
        public bool IsGrounded { get => isGrounded; set => isGrounded = value; }
        public Image SpriteSheet { get => spriteSheet; set => spriteSheet = value; }
        public Graphics Graphics { get => graphics; set => graphics = value; }
        public Bitmap Bmp { get => bmp; set => bmp = value; }
        public int SpriteX { get => spriteX; set => spriteX = value; }
        public int SpriteY { get => spriteY; set => spriteY = value; }
        public Image[,] Sprites { get => sprites; set => sprites = value; }

        public Personagem(int posX, int posY, int gravity, int speedX, int speedY, Image spriteSheet)
        {
            this.PosX = posX;
            this.PosY = posY;
            this.Gravity = gravity;
            this.SpeedX = speedX;
            this.SpeedY = speedY;
            this.SpriteSheet = spriteSheet;
        }

        public Personagem(Image spriteSheet) 
        {
            this.SpriteSheet = spriteSheet;
        }





        public void Move()
        {
            if(Orientacao == 1)
            {
                PosX += SpeedX;
            }
            else
            {
                PosX -= SpeedX;
            }
        }
     

        public void Jump()
        {
            if (IsGrounded)
            {
                SpeedY = JumpForce;
            }
            
            PosY += SpeedY;
            SpeedY += Gravity;
        }




        public Bitmap Animate()
        {
            Graphics.Clear(Color.White);
         
            
            if (IsJumping)
            {
                SpriteY = 4;
                SpriteX = 1;
            }
            else if (IsMoving)
            {
                SpriteY = 0;

                SpriteX ++;
                if (SpriteX == 8)
                    SpriteX = 0;
            }
            else
            {
                if (!animChosen)
                {
                    animChoice = rnd.Next(1, 100);
                }

                if(animChoice < 80)
                {
                    SpriteY = 1;
                    SpriteX = 0;
                    animChosen = true;

                    frame++;
                    if (frame == 8)
                    {
                        animChosen = false;
                        frame = 0;
                    }


                }else if (animChoice < 90)
                {
                    SpriteY = 2;
                    animChosen = true;

                    SpriteX ++;
                    if (SpriteX == 8)
                    {
                        SpriteX = 0;
                        animChosen = false;
                    }
                }
                else
                {
                    SpriteY = 3;

                    animChosen = true;

                    SpriteX ++;
                    if (SpriteX == 8)
                    {
                        SpriteX = 0;
                        animChosen = false;
                    }
                }
            }

            Graphics.DrawImage(Sprites[SpriteX, SpriteY], new Rectangle(PosX, PosY, 200, 200));

            return Bmp;
        }




        public void Orientar(int direcao)
        {
            if (direcao != orientacao)
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        Sprites[i, j].RotateFlip(RotateFlipType.Rotate180FlipY);
                    }
                }
       
            }
            Orientacao = direcao;
        }




        public void Fatiar(int x, int y)
        {
            for(int i = 0; i<x; i++)
            {
                for(int j = 0; j < y; j++)
                {
                    Sprites[i,j] = (SpriteSheet as Bitmap).Clone(new Rectangle(i * Resolucaox, j * Resolucaoy, Resolucaox, Resolucaoy), SpriteSheet.PixelFormat);
                }
            }
        }
    }
}
