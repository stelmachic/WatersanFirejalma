using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace Watersan_e_Firejalma
{
    public class C_Sharp : Asset
    {
        public C_Sharp(int posX, int posY, int BlockType) : base((Properties.Assets.CSharpMove), posX, posY, BlockType)
        {
 
        }

        public override void OnCollision(CollisionInfo info, Graphics g, int blockType)
        {
            if (blockType == 1)
                disappear = true;
            else if (blockType == 0)
                disappear = false;
        }
    }
}
