using System.Drawing;

namespace Watersan_e_Firejalma
{
    public class RectangleHitbox : HitBox
    {
        public Rectangle rect { get; }

        public RectangleHitbox(Rectangle rect)
            => this.rect = rect;

        public override PointF[] Points
        {
            get => new PointF[]
            {
                new PointF(rect.X, rect.Y),
                new PointF(rect.X + rect.Width / 2, rect.Y),
                new PointF(rect.X + rect.Width, rect.Y),
                new PointF(rect.X + rect.Width, rect.Y + rect.Height),
                new PointF(rect.X, rect.Y + rect.Height),
                new PointF(rect.X, rect.Y)
            };

        }

    }
}
