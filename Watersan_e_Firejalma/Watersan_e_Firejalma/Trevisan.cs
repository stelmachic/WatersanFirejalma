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
        public Trevisan() : base(Properties.Resources.Trevisharp_Sheet)
        {
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

                case Keys.Escape:
                    Application.Exit();
                    break;
            }
        }
    }
}