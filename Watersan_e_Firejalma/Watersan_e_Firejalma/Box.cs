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
        public Rectangle box;



        public Box(int X, int Y, int width, int height)
            => this.box = new Rectangle(X, Y, width, height);
        

        public override void Draw(Graphics g)
            => g.DrawRectangle(Pens.Black, box);



    }
}


