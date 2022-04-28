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
        private int resolucaox = 32;
        private int resolucaoy = 32;
        private int orientacao = 1;
        private Image spriteSheet;

        public int PosX { get => posX; set => posX = value; }
        public int PosY { get => posY; set => posY = value; }
        public int Gravity { get => gravity; set => gravity = value; }
        public int SpeedX { get => speedX; set => speedX = value; }
        public int SpeedY { get => speedY; set => speedY = value; }
        public int Resolucaox { get => resolucaox; set => resolucaox = value; }
        public int Resolucaoy { get => resolucaoy; set => resolucaoy = value; }
        public int Orientacao { get => orientacao; set => orientacao = value; }
        public Image SpriteSheet { get => spriteSheet; set => spriteSheet = value; }

        public Personagem(int posX, int posY, int gravity, int speedX, int speedY, Image spriteSheet)
        {
            this.posX = posX;
            this.posY = posY;
            this.gravity = gravity;
            this.speedX = speedX;
            this.speedY = speedY;
            this.spriteSheet = spriteSheet;
        }


        public Personagem(Image spriteSheet) 
        {
            this.spriteSheet = spriteSheet;
        }


        public void MoveRight()
        {
            if (orientacao == -1)
            {
                spriteSheet.RotateFlip(RotateFlipType.Rotate180FlipY);
            }

            posX += speedX;
            orientacao = 1;
        }
        public void MoveLeft()
        {
            if (orientacao == 1)
            {
                spriteSheet.RotateFlip(RotateFlipType.Rotate180FlipY);
            }

            posX += -speedX;
            orientacao = -1;
        }

        public void Jump()
        {
            for(speedY = jumpForce; speedY >= -jumpForce; speedY += gravity)
            {
                posY += speedY;
            }
            
        }


    }
}
