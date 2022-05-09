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
        private int spriteX;
        private int spriteY;
        private Image[,] sprites = new Image[8,5];
        Random rnd = new Random();
        private int animChoice;
        private bool animChosen = false;
        private int frame;
        private int HitBoxX = (16 * 8);
        private int HitBoxY = (32 * 8);

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
        public int SpriteX { get => spriteX; set => spriteX = value; }
        public int SpriteY { get => spriteY; set => spriteY = value; }
        public Image[,] Sprites { get => sprites; set => sprites = value; }
        public int HitBoxX1 { get => HitBoxX; set => HitBoxX = value; }
        public int HitBoxY1 { get => HitBoxY; set => HitBoxY = value; }

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

        public override void Draw(Graphics graphics)
        {

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

            graphics.DrawImage(Sprites[SpriteX, SpriteY], new Rectangle(PosX, PosY, resolucaox, resolucaoy));
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
                            IsMoving = moving;
                        break;

                    case Keys.Right:
                            Orientar(1);
                            IsMoving = moving;
                        break;

                    case Keys.Up:
                        IsJumping = true;
                        break;
                }
            }
            else if(this is Trevisan)
            {
                switch (key)
                {
                    case Keys.A:
                            Orientar(-1);
                            IsMoving = moving;
                        break;

                    case Keys.D:
                            Orientar(1);
                            IsMoving = moving;
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

            pontos.Add(new Point(posX + (HitBoxX1 / 2), posY));
            pontos.Add(new Point(posX + (HitBoxX1 / 2), posY + HitBoxY1));
            pontos.Add(new Point(posX + HitBoxX1 + (HitBoxX1 / 2), posY + HitBoxY1));
            pontos.Add(new Point(posX + HitBoxX1 + (HitBoxX1 / 2), posY));

            g.DrawPolygon(new Pen(Color.Black), pontos.ToArray());
        }

        public void checkCollission(Box objeto)
        {

            bool direita = false;
            bool esquerda = false;
            bool emCima = false;
            bool emBaixo = false;

            List<List<Point>> listaRetas = new List<List<Point>>
            {
                new List<Point>
                {
                    objeto.Points[0],
                    objeto.Points[1]
                },
                new List<Point>
                {
                    objeto.Points[1],
                    objeto.Points[2]
                },
                new List<Point>
                {
                    objeto.Points[2],
                    objeto.Points[3]
                },
                new List<Point>
                {
                    objeto.Points[3],
                    objeto.Points[0]
                }
            };
            

            if(listaRetas[0][0].X > posX)
            {
                esquerda = true;
            }
            if(listaRetas[2][0].X < posX + (PosX + HitBoxX))
            {
                direita = true;
            }
            if(listaRetas[3][0].Y > (posY+HitBoxY))
            {
                emCima = true;
            }
            if(listaRetas[1][0].Y < posY)
            {
                emBaixo = true;
            }



            if (!emCima && !emBaixo && esquerda)
            {
                if ((PosX + HitBoxX1 + (HitBoxX1 / 2)) > listaRetas[0][0].X)
                {
                    SpeedX = 0;
                    PosX = listaRetas[0][0].X - (HitBoxX1) - (HitBoxX1 / 2);
                }

            }
            else if (!emCima && !emBaixo && direita)
            {
                if ((PosX + (HitBoxX / 2)) < listaRetas[2][0].X)
                {
                    SpeedX = 0;
                    PosX = listaRetas[2][0].X - (HitBoxX / 2);
                }
            }
            else
            {
                SpeedX = 20;
            }     
        }
    }
}
