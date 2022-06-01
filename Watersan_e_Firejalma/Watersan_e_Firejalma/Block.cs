using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace Watersan_e_Firejalma
{
    public class Block : Entity
    {
        public Rectangle box;
        Image sprite;
        ImageAttributes attributes;
        int blockWidht;
        int blockHeight;
        public int blockType;

        public Block(int X, int Y, int blockWidht, int blockHeight, Image sprite, int blockType) 
            : base(HitBox.FromBlock(new Rectangle(X, Y, blockWidht, blockHeight), blockType))
        {
            this.blockWidht = blockWidht;
            this.blockHeight = blockHeight;

            this.blockType = blockType;

            this.box = new Rectangle(X, Y, 32, 32);

            this.sprite = sprite;

            //Generate Map with the txt
            
            ImageAttributes attributes = new ImageAttributes();
            attributes.SetWrapMode(WrapMode.TileFlipY);
        }

        public override void Draw(Graphics g)
        {
            g.InterpolationMode = InterpolationMode.NearestNeighbor;
            ImageAttributes attributes = new ImageAttributes();
            attributes.SetWrapMode(WrapMode.TileFlipY);
            g.DrawImage(sprite, box, 0, 0, blockWidht, blockHeight, GraphicsUnit.Pixel, attributes);
        }
          

    }
}