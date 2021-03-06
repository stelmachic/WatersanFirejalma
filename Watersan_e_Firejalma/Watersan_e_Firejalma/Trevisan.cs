using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.DirectX.AudioVideoPlayback;


namespace Watersan_e_Firejalma
{
    public class Trevisan : Character
    {
        public Trevisan(int posX, int posY) : base(Properties.Characters.Trevisharp_sheet, posX, posY)
        {
        }

        
        public override bool Kill(int blockType)
        {
            if (blockType == 1)
                return true;

            if (blockType == 3)
                return true;

            return false;
        }

        public override void KeyCheck(Keys key, bool moving)
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
}