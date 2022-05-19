using System.Drawing;

namespace Watersan_e_Firejalma
{
    public class CollisionInfo
    {
        public bool IsColliding { get; set; } = false;
        public PointF PointA { get; set; }
        public PointF PointB { get; set; }
        public float distMin { get; set; } 
    }
}