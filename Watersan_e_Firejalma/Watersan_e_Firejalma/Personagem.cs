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
    public class Personagem : Entity
    {
        public int posX { get;  set; } = 20;
        public int posY { get;  set; } = 20;
        public int gravity { get;  set; } = 1;
        public int speedX { get;  set; } = 15;
        public int speedY { get;  set; } = 0;
        public int jumpForce { get;  set; } = -20;
        public int resolucaox { get;  set; } = (32 * 8);
        public int resolucaoy { get;  set; } = (32 * 8);
        public int orientacao { get;  set; } = 1;
        public bool isMoving { get;  set; } = false;
        public bool isJumping { get;  set; } = false;
        public bool isGrounded { get;  set; } = false;
        public Image spriteSheet;
        public int spriteX { get;  set; }
        public int spriteY { get;  set; }
        public Image[,] sprites = new Image[8,5];
        Random rnd = new Random();
        public int animChoice { get;  set; }
        public bool animChosen = false;
        public int frame { get;  set; }
        public int width { get;  set; } = (16 * 8);
        public int height { get;  set; } = (32 * 8);
        public Rectangle hitbox { get; set; }

        public Personagem(Image spriteSheet) 
        {
            this.spriteSheet = spriteSheet;
        }



        public void Move()
        {
            if(orientacao == 1)
            {
                posX += speedX;
            }
            else
            {
                posX -= speedX;
            }
        }
     
        public void Jump()
        {
            if (isGrounded)
            {
                speedY = jumpForce;
            }
            
            posY += speedY;
            speedY += gravity;
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

            graphics.DrawImage(sprites[spriteX, spriteY], new Rectangle(posX, posY, resolucaox, resolucaoy));
        }

        public void Orientar(int direcao)
        {
            if (direcao != orientacao)
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        sprites[i, j].RotateFlip(RotateFlipType.Rotate180FlipY);
                    }
                }
       
            }
            orientacao = direcao;
        }

        public void Fatiar(int x, int y)
        {
            for(int i = 0; i<x; i++)
            {
                for(int j = 0; j < y; j++)
                {
                    sprites[i,j] = (spriteSheet as Bitmap).Clone(new Rectangle(i * resolucaox, j * resolucaoy, resolucaox, resolucaoy), spriteSheet.PixelFormat);
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
                        Orientar(-1);
                        isMoving = moving;
                        break;

                    case Keys.Right:
                        Orientar(1);
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
                            Orientar(-1);
                            isMoving = moving;
                        break;

                    case Keys.D:
                            Orientar(1);
                            isMoving = moving;
                        break;

                    case Keys.W:
                            isJumping = true;
                        break;
                }
            } 
        }

        public void DrawHitBox(Graphics g)
        {
            List<Point> pontos = new List<Point>();
            
            hitbox = new Rectangle(posX + (width / 2), posY, width, height);

            g.DrawRectangle(Pens.Black, hitbox);
        }

        public void checkCollission(Box entity)
        {

            Rectangle box = entity.box; 


            bool direita = false;
            bool esquerda = false;
            bool emCima = false;
            bool emBaixo = false;
            bool collided = false;




            if ((hitbox.X >= box.X) && (hitbox.X <= (box.X + box.Width)) && (hitbox.Y >= box.Y) && (hitbox.Y <= (box.Y + box.Height)))
                collided = true;

            if((((hitbox.X + width) >= box.X) && ((hitbox.X + width) <= (box.X + box.Width)) && (hitbox.Y >= box.Y) && (hitbox.Y <= (box.Y + box.Height))))
                collided = true;

            if ((((hitbox.X + width) >= box.X) && ((hitbox.X + width) <= (box.X + box.Width)) && ((hitbox.Y + width) >= box.Y) && ((hitbox.Y + width) <= (box.Y + box.Height))))
                collided = true;

            if ((hitbox.X >= box.X) && (posX <= (box.X + box.Width)) && ((hitbox.Y + width) >= box.Y) && ((hitbox.Y + width) <= (box.Y + box.Height)))
                collided = true;





            if (collided)
            {
                if (box.X > posX)
                {
                    esquerda = true;
                }
                if (box.X < posX + (posX + width))
                {
                    direita = true;
                }
                if (box.Y > (posY + height))
                {
                    emCima = true;
                }
                if (box.Y < posY)
                {
                    emBaixo = true;
                }



                if (emCima && !isGrounded)
                {
                    if (posY + height > box.Y)
                    {
                        isGrounded = true;
                        isJumping = false;

                        speedY = 0;
                        posY = box.Y - height;
                    }
                }
                else if (!emCima && !emBaixo && esquerda)
                {
                    if ((posX + width + (width / 2)) > box.X)
                    {
                        speedX = 0;
                        posX = box.X - (width) - (width / 2);
                    }

                }
                else if (!emCima && !emBaixo && direita)
                {
                    if ((posX + (width / 2)) < box.X)
                    {
                        speedX = 0;
                        posX = box.X - (width / 2);
                    }
                }
                else
                {
                    speedX = 20;
                }
            }


            
        }
    }
}
