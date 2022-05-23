using System;
using System.Drawing;


namespace Watersan_e_Firejalma
{
    public abstract class HitBox
    {
        public abstract PointF[] Points { get;}
        
        

        public static HitBox FromRectangle(Rectangle rect)
            => new RectangleHitbox(rect);
        
        public static HitBox FromCharacter(Character character)
            => new CharacterHitBox(character);
        



        public virtual CollisionInfo IsColliding(HitBox hitBox)
        {
            CollisionInfo info = new CollisionInfo();
            info.IsColliding = false;

            foreach (var p in hitBox.Points)
            {
                if (inpolygon(p, this.Points))
                {
                    info.IsColliding = true;
                    (info.PointA, info.PointB) = bestside(this.Points, p);

                    return info;
                }
            }

            return info;
        }

        private bool linecollision(PointF p1, PointF q1, PointF p2, PointF q2)
        {
            float a1 = (q1.Y - p1.Y) / (q1.X - p1.X),
                  a2 = (q2.Y - p2.Y) / (q2.X - p2.X),
                  b1 = q1.Y - a1 * q1.X,
                  b2 = q2.Y - a2 * q2.X;
            float x = 0, y = 0;
            x = -(b1 - b2) / (a1 - a2);
            y = a1 * x + b1;
            if (a1 - a2 >= -float.Epsilon && a1 - a2 <= float.Epsilon)
                return false;
            if (float.IsNaN(x))
            {
                if (float.IsInfinity(a1))
                {
                    x = q1.X;
                    y = a2 * x + b2;
                }
                else
                {
                    x = q2.X;
                    y = a1 * x + b1;
                }
            }


            float maxx1 = p1.X > q1.X ? p1.X : q1.X,
                  minx1 = p1.X < q1.X ? p1.X : q1.X,
                  maxx2 = p2.X > q2.X ? p2.X : q2.X,
                  minx2 = p2.X < q2.X ? p2.X : q2.X,
                  maxy1 = p1.Y > q1.Y ? p1.Y : q1.Y,
                  miny1 = p1.Y < q1.Y ? p1.Y : q1.Y,
                  maxy2 = p2.Y > q2.Y ? p2.Y : q2.Y,
                  miny2 = p2.Y < q2.Y ? p2.Y : q2.Y;

            return minx1 <= x && x <= maxx1 && minx2 <= x && x <= maxx2 &&
                   miny1 <= y && y <= maxy1 && miny2 <= y && y <= maxy2;
        }

        private bool inpolygon(PointF p, PointF[] pts)
        {
            PointF q = new PointF(float.MaxValue, p.Y);
            int count = 0;
            for (int i = 0; i < pts.Length - 1; i++)
            {
                if (linecollision(p, q, pts[i], pts[i + 1]))
                    count++;
            }
            return count % 2 == 1;
        }

        private float distance(PointF p, PointF q, PointF r)
            => (float)(Math.Abs((q.X - p.X) * (p.Y - r.Y) - (p.X - r.X) * (q.Y - p.Y)) /
                Math.Sqrt((q.X - p.X) * (q.X - p.X) + (q.Y - p.Y) * (q.Y - p.Y)));

        private (PointF, PointF) bestside(PointF[] polygon, PointF p)
        {
            float min = float.MaxValue;
            int index = -1;
            for (int i = 0; i < polygon.Length - 1; i++)
            {
                float newdist = distance(polygon[i], polygon[i + 1], p);
                if (newdist < min)
                {
                    min = newdist;
                    index = i;
                }
            }
            return (polygon[index], polygon[index + 1]);
        }

        public void Draw(Graphics g)
            => g.DrawPolygon(Pens.Red, Points);
    }
}
