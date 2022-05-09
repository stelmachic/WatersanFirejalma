using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Watersan_e_Firejalma
{
    public class Box : Entity
    {
        public List<Point> Points { get; private set; } = new List<Point>();
        public Pen Pen { get; set; } = Pens.Black;

        public Box(List<Point> points)
            => this.Points = points;
        
        public override void Draw(Graphics g)
        {
            g.DrawPolygon(Pen, Points.ToArray());

        } 
    }
}


