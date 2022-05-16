using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watersan_e_Firejalma
{
    public class CharacterHitBox : HitBox
    {
        public Character Character { get; set; }

        protected override PointF[] pts
        {
            get => new PointF[]
            {
                new PointF(Character.posX + Character.width / 2, Character.posY),
                new PointF(Character.posX + Character.width / 2 + Character.width, Character.posY),
                new PointF(Character.posX + Character.width / 2 + Character.width, Character.posY + Character.height),
                new PointF(Character.posX + Character.width / 2, Character.posY + Character.height)
            };
            set => throw new InvalidOperationException();
        }
    }
}
