using System.Drawing;

namespace Watersan_e_Firejalma
{
    public class CollisionInfo
    {
        public bool IsColliding { get; set; } = false;
        public PointF SideA { get; set; }
        public PointF SideB { get; set; }
    }
}