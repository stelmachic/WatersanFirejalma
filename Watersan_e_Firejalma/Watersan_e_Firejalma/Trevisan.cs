using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Watersan_e_Firejalma
{
    public class Trevisan : Character
    {
        public Trevisan() : base(Properties.Characters.Trevisharp_sheet, new System.Media.SoundPlayer(Properties.Audios.trevWalk))
        {
        }

        public override void KeyCheck(Keys key, bool moving)
        {

            if (!moving)
            {
                walkSound.Stop();
            }
            else
            {
                if (!isMoving)
                {
                    walkSound.PlayLooping();
                }
            }

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

                case Keys.Escape:
                    Application.Exit();
                    break;
            }
        }
    }
}