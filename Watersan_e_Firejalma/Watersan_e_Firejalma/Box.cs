using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace Watersan_e_Firejalma
{
    public class Box : Entity
    {
        public Rectangle box;
        Image sprite;
        ImageAttributes attributes;

        public Box(int X, int Y, int width, int height, Image sprite) 
            : base(HitBox.FromRectangle(new Rectangle(X, Y, width, height)))
        {
            this.box = new Rectangle(X, Y, width, height);
            this.sprite = sprite;

            //Generate Map with the txt
            
            ImageAttributes attributes = new ImageAttributes();
            attributes.SetWrapMode(WrapMode.TileFlipY);
        }

        public override void Draw(Graphics g)
        {
            g.InterpolationMode = InterpolationMode.NearestNeighbor;
            g.DrawImage(sprite, box, 0, 0, (16 * 8), (16 * 8), GraphicsUnit.Pixel, attributes);
        }
          

    }
}