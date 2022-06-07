using System.Windows.Forms;
using System.Media;
using System.Threading;

namespace Watersan_e_Firejalma
{
    public class Edjalma : Character
    {
        public Edjalma(int posX, int posY) : base(Properties.Characters.Edjalma_sheet, posX, posY){}


        public override bool Kill(int blockType)
        { 
            if (blockType == 2)
                return true;
            
            if (blockType == 3)
                return true;

            return false;
        }

        private bool flag = true;
        private Thread thread = null;
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
            }
        }
    }
}
