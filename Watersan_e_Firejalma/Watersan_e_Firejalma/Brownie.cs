﻿using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace Watersan_e_Firejalma
{
    public class Brownie : Asset
    {
        public Brownie(int posX, int posY, int BlockType) : base((Properties.Assets.BrownieMove), posX, posY, BlockType)
        {
 
        }

        public override void OnCollision(CollisionInfo info, Graphics g, int blockType)
        {
            if (blockType == 0)
                disappear = true;
            else if (blockType == 1)
                disappear = false;
        }
    }
}
