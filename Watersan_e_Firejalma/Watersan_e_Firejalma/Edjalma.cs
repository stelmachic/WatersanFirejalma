using System.Windows.Forms;
using System.Media;

namespace Watersan_e_Firejalma
{
    public class Edjalma : Character
    {
        public Edjalma() : base(Properties.Resources.Edjalma_Sheet, new System.Media.SoundPlayer(Properties.Resources.EdWalk))
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

            if (moving)
                walkSound.Play();
            else
                walkSound.Stop();
            
        }
    }
}
