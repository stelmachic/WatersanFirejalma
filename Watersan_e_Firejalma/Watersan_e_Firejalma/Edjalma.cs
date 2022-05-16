using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Watersan_e_Firejalma
{
    public class Edjalma : Character
    {
        public Edjalma() : base(Properties.Resources.Edjalma_Sheet)
        {
        }

        public override void KeyCheck(Keys key, bool moving)
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

                case Keys.Escape:
                    Application.Exit();
                    break;
            }
        }
    }
}
