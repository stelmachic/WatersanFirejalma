using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Watersan_e_Firejalma
{
    public class Wall
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


        public Wall(Image spriteSheet, int posX, int posY)
        {

       
            this.spriteSheet = spriteSheet;
            this.posX = posX;
            this.posY = posY;


            this.collumns = (spriteSheet.Width / resolutionX);
            this.lines = (spriteSheet.Height / resolutionY);

            SplitSprites();
        }


        public void Draw(Graphics g)
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
