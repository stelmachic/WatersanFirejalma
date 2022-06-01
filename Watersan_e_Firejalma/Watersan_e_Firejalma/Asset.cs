﻿using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace Watersan_e_Firejalma
{
    public class Asset : Entity
    {
        public Rectangle hitboxBox;
        public float posX { get; set; }
        public float posY { get; set; }

        public Image spriteSheet;
        public int resolutionX { get; set; } = 32;
        public int resolutionY { get; set; } = 32;

        public Image[,] sprites;
        public int spriteX { get; set; }
        public int spriteY { get; set; }

        public int collumns;
        public int lines;


        public Asset(Image spriteSheet, int posX, int posY) 
            : base(null)
        {

            this.hitboxBox = new Rectangle(posX, posY, resolutionX, resolutionX);
            this.HitBox = HitBox.FromAsset(hitboxBox);

            this.spriteSheet = spriteSheet;
            this.posX = posX;
            this.posY = posY;

            this.collumns = (spriteSheet.Width / resolutionX);
            this.lines = (spriteSheet.Height / resolutionY);

            SplitSprites();
        }







        public override void Draw(Graphics g)
        {
            spriteY = 0;

            spriteX++;
            if (spriteX == collumns)
                spriteX = 0;

            g.DrawImage(sprites[spriteX, spriteY], new Rectangle((int)posX, (int)posY, resolutionX, resolutionY));
        }






        public void SplitSprites()
        {
            

            sprites = new Image[collumns, lines];

            for (int i = 0; i < collumns; i++)
            {
                for (int j = 0; j < lines; j++)
                {
                    sprites[i, j] = (spriteSheet as Bitmap).Clone(new Rectangle(i * resolutionX, j * resolutionY, resolutionX, resolutionY), spriteSheet.PixelFormat);
                }
            }
        }


    }
}