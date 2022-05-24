using System;
using System.Drawing;
using System.Windows.Forms;
using System.Media;

namespace Watersan_e_Firejalma
{
    public abstract class Character : Entity
    {
        public float posX { get; set; } = 100;
        public float posY { get; set; }
        public int mass { get; set; } = 1;
        public int speedX { get; set; } = 15;
        public int speedY { get; set; } = 0;
        public int jumpForce { get; set; } = 20;
        public int resolutionX { get; set; } = (32 * 8);
        public int resolutionY { get; set; } = (32 * 8);
        public int orientation { get; set; } = 1;
        public PointF Center => new PointF(posX, posY) + new SizeF(resolutionX / 2f, resolutionY / 2f);


        public bool gravityOn { get; set; } = true;
        public bool isMoving { get; set; } = false;
        public bool isJumping { get; set; } = false;
        public bool isGrounded { get; set; } = false;
        public int width { get; set; } = (16 * 8);
        public int height { get; set; } = (32 * 8);



        public Image spriteSheet;
        public int spriteX { get; set; }
        public int spriteY { get; set; }
        public Image[,] sprites = new Image[8, 5];
        Random rnd = new Random();
        public int animChoice { get; set; }
        public bool animChosen = false;
        public int frame { get; set; }

        public SoundPlayer walkSound;



        public Character(Image spriteSheet, SoundPlayer walkSound) : base(null)
        {
            this.HitBox = HitBox.FromCharacter(this);
            this.spriteSheet = spriteSheet;
            this.walkSound = walkSound;


            for (int i = 0; i < (spriteSheet.Width / resolutionX); i++)
            {
                for (int j = 0; j < (spriteSheet.Height / resolutionY); j++)
                {
                    sprites[i, j] = (spriteSheet as Bitmap).Clone(new Rectangle(i * resolutionX, j * resolutionY, resolutionX, resolutionY), spriteSheet.PixelFormat);
                }
            }

        }

        public override void OnCollision(CollisionInfo info, Graphics g)
        {
            bool isHorizontal = info.PointA.Y == info.PointB.Y;
            bool isVertical = info.PointA.X == info.PointB.X;
            PointF center = this.Center;
            PointF collision = info.CollisionPoints[0];

            g.DrawLine(new Pen(Color.Cyan, 10f), info.PointA, info.PointB);
            foreach (var coll in info.CollisionPoints)
                g.FillEllipse(Brushes.DarkGreen, coll.X - 3, coll.Y - 3, 6, 6);
            g.FillEllipse(Brushes.Pink, center.X - 3, center.Y - 3, 6, 6);
            //
            if (center.X < collision.X && center.Y > collision.Y)
            {
                if (orientation > 0)
                    speedX = 0;
            }
            if (center.X > collision.X && center.Y > collision.Y)
            {
                if (orientation < 0)
                    speedX = 0;
            }
            if (center.Y < collision.Y)
            {
                speedY = 0;
                isGrounded = true;
            }
        }



        public void Move()
        {
            if (isMoving)
            {
                posX += speedX * orientation;
            }

            if (isJumping)
            {
                if (isGrounded)
                {
                    speedY = jumpForce * -1;
                }
                isJumping = false;
            }

            if (gravityOn && !isGrounded)
            {
                speedY += mass;
            }
            posY += speedY;
            isGrounded = false;
            speedX = 15;
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

                spriteX++;
                if (spriteX == 8)
                    spriteX = 0;
            }

            else
            {
                if (!animChosen)
                {
                    animChoice = rnd.Next(1, 100);
                }

                if (animChoice < 80)
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


                }
                else if (animChoice < 90)
                {
                    spriteY = 2;
                    animChosen = true;

                    spriteX++;
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

                    spriteX++;
                    if (spriteX == 8)
                    {
                        spriteX = 0;
                        animChosen = false;
                    }
                }
            }

            graphics.DrawImage(sprites[spriteX, spriteY], new Rectangle((int)posX, (int)posY, resolutionX, resolutionY));
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



        public abstract void KeyCheck(Keys key, bool moving);
    }
}
