using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BEngine2D.Util;

namespace BEngine2D.World.Blocks
{
    public class BBlocks
    {
        public static BBlock[] Blocks;

        public static void Initialise()
        {
            Blocks = new BBlock[]
            {
                new BBlock("OutsideBounds", BBlockType.Empty, new RectangleF(0, 0, AppInfo.TILESIZE, AppInfo.TILESIZE)),
                new BBlock("Water", BBlockType.Solid, new RectangleF(0, 0, AppInfo.TILESIZE, AppInfo.TILESIZE)),
                new BBlock("Grass", BBlockType.Ground, new RectangleF(AppInfo.TILESIZE, 0, AppInfo.TILESIZE, AppInfo.TILESIZE)),
                new BBlock("TestSolid", BBlockType.Solid, new RectangleF(AppInfo.TILESIZE * 2, 0, AppInfo.TILESIZE, AppInfo.TILESIZE)),
            };

        }
    }
}
