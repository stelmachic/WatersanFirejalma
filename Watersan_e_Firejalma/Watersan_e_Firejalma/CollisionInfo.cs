using System.Collections.Generic;
using System.Drawing;

namespace Watersan_e_Firejalma
{
    public class CollisionInfo
    {
        public bool IsColliding { get; set; } = false;
        public PointF PointA { get; set; }
        public PointF PointB { get; set; }
        public List<PointF> CollisionPoints { get; private set; } = new List<PointF>();

        public int blockType;
        
    }
}