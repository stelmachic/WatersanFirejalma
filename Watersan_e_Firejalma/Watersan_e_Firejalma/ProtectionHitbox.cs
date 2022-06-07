using System.Drawing;

namespace Watersan_e_Firejalma
{
    public class ProtectionHitbox : HitBox
    {
        public Rectangle rect { get; }
       
        public ProtectionHitbox(Rectangle rect)
        {
            this.rect = rect;
        
        }
           

        public override PointF[] Points
        {
            get => new PointF[]
            {
                new PointF(rect.X, rect.Y),
                new PointF(rect.X + rect.Width / 4, rect.Y),
                new PointF(rect.X + rect.Width / 2, rect.Y),
                 new PointF(rect.X + (3*rect.Width) / 4, rect.Y),
                new PointF(rect.X + rect.Width, rect.Y),
                new PointF(rect.X + rect.Width, rect.Y + 5),
                new PointF(rect.X + rect.Width, rect.Y + 10),
                new PointF(rect.X + (3*rect.Width) / 4, rect.Y + 10),
                new PointF(rect.X + rect.Width/2, rect.Y + 10),
                new PointF(rect.X + rect.Width/4, rect.Y + 10),
                new PointF(rect.X, rect.Y + 10),
                new PointF(rect.X, rect.Y + 5),


                new PointF(rect.X, rect.Y)

        
            };

        }

    }
}
