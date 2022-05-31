using System.Drawing;

namespace Watersan_e_Firejalma
{
    public class LiquidHitbox : HitBox
    {
        public Rectangle rect { get; }
        public int step { get; set; }
       
        public LiquidHitbox(Rectangle rect)
        {
            this.rect = rect;
            step = rect.Height / 2;
        }
           

        public override PointF[] Points
        {
            get => new PointF[]
            {
                new PointF(rect.X, rect.Y + step),
                new PointF(rect.X + rect.Width / 4, rect.Y + step),
                new PointF(rect.X + rect.Width / 2, rect.Y + step),
                new PointF(rect.X + (3*rect.Width) / 4, rect.Y + step),
                new PointF(rect.X + rect.Width, rect.Y + step),
                new PointF(rect.X + rect.Width, rect.Y + rect.Height/2),
                new PointF(rect.X + rect.Width, rect.Y + rect.Height),
                new PointF(rect.X + (3*rect.Width) / 4, rect.Y + rect.Height),
                new PointF(rect.X + rect.Width/2, rect.Y + rect.Height),
                new PointF(rect.X + rect.Width/4, rect.Y + rect.Height),
                new PointF(rect.X, rect.Y + rect.Height),
                new PointF(rect.X, rect.Y + rect.Height/2),
                new PointF(rect.X, rect.Y + step)
            };
        }
    }
}
