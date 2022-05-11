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
    public class Character : Entity
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



        public bool isCollided { get; set; } = false;
        public bool isMoving { get;  set; } = false;
        public bool isJumping { get;  set; } = false;
        public bool isGrounded { get;  set; } = false;
        public int width { get; set; } = (16 * 8);
        public int height { get; set; } = (32 * 8);
        public Rectangle hitbox { get; set; }



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
        }



        public void Move()
        {
            posX += speedX * orientation;
        }
     
        public void Jump()
        {
            speedY = jumpForce * -1;
        }

        public void Gravity()
        {
            posY += speedY;
            speedY += mass;
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

        public void KeyCheck(Keys key, bool moving)
        {

            if(key == Keys.Escape)
            {
                Application.Exit();
            }



            if(this is Edjalma)
            {
                switch (key)
                {
                    case Keys.Left:
                        Orientate(-1);
                        isMoving = moving;
                        break;

                    case Keys.Right:
                        Orientate(1);
                        isMoving = moving;
                        break;

                    case Keys.Up:
                        isJumping = true;
                        break;
                }
            }
            else if(this is Trevisan)
            {
                switch (key)
                {
                    case Keys.A:
                            Orientate(-1);
                            isMoving = moving;
                        break;

                    case Keys.D:
                            Orientate(1);
                            isMoving = moving;
                        break;

                    case Keys.W:
                            isJumping = true;
                        break;
                }
            } 
        }

        public override void DrawHitBox(Graphics g)
        {
            List<Point> pontos = new List<Point>();
            
            hitbox = new Rectangle(posX + (width / 2), posY, width, height);

            g.DrawRectangle(Pens.Black, hitbox);
        }

        public void CheckCollission(Box entity)
        {

            Rectangle box = entity.box;
            float x;

            if(orientation < 0)
                x = hitbox.X;
            else
                x = (hitbox.X + width);




            bool collided = false;

            if((x >= box.X) && (x <= (box.X + box.Width)) && (hitbox.Y >= box.Y) && (hitbox.Y <= (box.Y + box.Height)))
            {
                collided = true;
            }
            else if((x >= box.X) && (x <= (box.X + box.Width)) && ((hitbox.Y + height) >= box.Y) && ((hitbox.Y + height) <= (box.Y + box.Height)))
            {
                collided = true;
            }

            

            if (collided)
            {
                isCollided = true;
            }

            if (collided)
            {

                float distXL, distXR, distYT, distYB;
                
                distXL = x - box.X;
                distXR = (box.X + box.Width) - x;
                distYT = (posY + height) - box.Y;

                if ((distYT < distXL) && (distYT < distXR))
                {
                    isGrounded = true;
                    isJumping = false;
                    speedX = 20;
                    speedY = 0;
                    posY = box.Y - height;
                }
                else if ((distXL<distYT) && (distXL<distXR))
                {
                    speedX = 0;
                    posX = box.X - (width) - (width / 2);
                }
                else if((distXR < distYT) && (distXR < distXL))
                {
                    speedX = 0;
                    posX = (box.X + box.Width) - (width / 2);
                }
                else
                {
                    speedX = 20;
                }
            }
        }
    }
}
