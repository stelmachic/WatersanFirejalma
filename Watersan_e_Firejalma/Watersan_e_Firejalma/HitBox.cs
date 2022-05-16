using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watersan_e_Firejalma
{
    public class HitBox
    {
        protected virtual PointF[] pts { get; set; }
        public void Draw(Graphics g)
        {
            g.DrawPolygon(Pens.Red, pts);
        }
        public bool IsColliding(HitBox hitBox)
        {
            return true;
        }

        public static HitBox FromRectangle(Rectangle rect)
        {
            HitBox hitBox = new HitBox();
            hitBox.pts = new PointF[]
            {
                new PointF(rect.X, rect.Y),
                new PointF(rect.X + rect.Width, rect.Y),
                new PointF(rect.X + rect.Width, rect.Y + rect.Height),
                new PointF(rect.X, rect.Y + rect.Height)
            };
            return hitBox;
        }

        public static HitBox FromCharacter(Character character)
        {
            return new CharacterHitBox()
            {
                Character = character
            };
        }

    }
}
