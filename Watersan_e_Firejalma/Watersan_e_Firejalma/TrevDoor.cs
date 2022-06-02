using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace Watersan_e_Firejalma
{
    public class TrevDoor : Asset
    {
        public TrevDoor(int posX, int posY, int BlockType) : base((Properties.Assets.PortaTrevinho), posX, posY, BlockType)
        {
            characterInteraction = CharacterInteraction.trevisan;
            assetType = AssetType.door;
            resolutionX = 32;
            resolutionY = 64;
        }

        public override void SplitSprites()
        {
            sprites = new Image[collumns, lines];

            for (int i = 0; i < collumns; i++)
            {
                for (int j = 0; j < lines; j++)
                {
                    sprites[i, j] = (spriteSheet as Bitmap).Clone(new Rectangle(0, 0, 32, 64), spriteSheet.PixelFormat);
                }
            }
        }
    }
}
