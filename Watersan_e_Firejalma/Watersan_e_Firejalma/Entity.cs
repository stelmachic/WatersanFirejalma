using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watersan_e_Firejalma
{

    public abstract class Entity
    {



        public abstract void Draw(Graphics g);
        public abstract void DrawHitBox(Graphics g);
        
    }
}
