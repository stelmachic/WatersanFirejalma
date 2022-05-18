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
    public abstract class Character : Entity
    {
        public int posX { get;  set; } = 100;
        public int posY { get;  set; }
        public int mass { get;  set; } = 1;
        public int speedX { get;  set; } = 15;
        public int speedY { get;  set; } = 0;
        public int jumpForce { get;  set; } = 20;
        public int resolutionX { get;  set; } = (32 * 8);
        public int resolutionY { get;  set; } = (32 * 8);
        public int orientation { get;  set; } = 1;

        public bool gravityOn { get; set; } = true;
        public bool isMoving { get;  set; } = false;
        public bool isJumping { get;  set; } = false;
        public bool isGrounded { get;  set; } = false;
        public int width { get; set; } = (16 * 8);
        public int height { get; set; } = (32 * 8);



        public Image spriteSheet;
        public int spriteX { get;  set; }
        public int spriteY { get;  set; }
        public Image[,] sprites = new Image[8,5];
        Random rnd = new Random();
        public int animChoice { get;  set; }
        public bool animChosen = false;
        public int frame { get;  set; }

        public Character(Image spriteSheet) 
        {
            this.spriteSheet = spriteSheet;
            this.HitBox = HitBox.FromCharacter(this);
        }

        public void Move()
        {
            if(isMoving)
                posX += speedX * orientation;
            if (isJumping)
            {
                if (isGrounded)
                    speedY = jumpForce * -1;

                isGrounded = false;
            }
            if (gravityOn)
            {
                speedY += mass;
                posY += speedY;
            }
        }
     

        public override void Draw(Graphics graphics)
        {

            if (isJumping)
            {
                spriteY = 4;
                spriteX = 1;
            }

            else if (isMoving)
            {
                spriteY = 0;

                spriteX ++;
                if (spriteX == 8)
                    spriteX = 0;
            }

            else
            {
                if (!animChosen)
                {
                    animChoice = rnd.Next(1, 100);
                }

                if(animChoice < 80)
                {
                    spriteY = 1;
                    spriteX = 0;
                    animChosen = true;

                    frame++;
                    if (frame == 8)
                    {
                        animChosen = false;
                        frame = 0;
                    }


                }else if (animChoice < 90)
                {
                    spriteY = 2;
                    animChosen = true;

                    spriteX ++;
                    if (spriteX == 8)
                    {
                        spriteX = 0;
                        animChosen = false;
                    }
                }
                else
                {
                    spriteY = 3;

                    animChosen = true;

                    spriteX ++;
                    if (spriteX == 8)
                    {
                        spriteX = 0;
                        animChosen = false;
                    }
                }
            }

            graphics.DrawImage(sprites[spriteX, spriteY], new Rectangle(posX, posY, resolutionX, resolutionY));
        }

        public void Orientate(int direcao)
        {
            if (direcao != orientation)
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        sprites[i, j].RotateFlip(RotateFlipType.Rotate180FlipY);
                    }
                }
       
            }
            orientation = direcao;
        }

        public void SplitSprites(int x, int y)
        {
            for(int i = 0; i<x; i++)
            {
                for(int j = 0; j < y; j++)
                {
                    sprites[i,j] = (spriteSheet as Bitmap).Clone(new Rectangle(i * resolutionX, j * resolutionY, resolutionX, resolutionY), spriteSheet.PixelFormat);
                }
            }
        }

        public abstract void KeyCheck(Keys key, bool moving);
    }
}
