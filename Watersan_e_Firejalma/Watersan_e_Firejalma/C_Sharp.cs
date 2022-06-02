using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace Watersan_e_Firejalma
{
    public class C_Sharp : Asset
    {
        public C_Sharp(int posX, int posY, int BlockType) : base((Properties.Assets.CSharpMove), posX, posY, BlockType)
        {
            characterInteraction = CharacterInteraction.trevisan;
            assetType = AssetType.collectible;
        }

        
    }
}
