using System.Drawing;

namespace Watersan_e_Firejalma
{
    public class Box : Entity
    {
        public Rectangle box;

        public Box(int X, int Y, int width, int height) 
            : base(HitBox.FromRectangle(new Rectangle(X, Y, width, height)))
        {
            this.box = new Rectangle(X, Y, width, height);
        }

        public override void Draw(Graphics g)
            => g.FillRectangle(Brushes.Black, box);

    }
}