using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Watersan_e_Firejalma
{
    public class objeto
    {

        public List<Point> pontos = new List<Point>();
        Pen pen = new Pen(Color.Black);



        public void CriarObjeto(List<Point> pontos)
        {
            this.pontos = pontos;
        }

        public void DrawObject(Graphics g)
        {
            g.DrawPolygon(pen, pontos.ToArray());
        } 

    }
}
