using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEngine2D.World.Blocks
{
    public class BBlocks
    {
        public static BBlock[] Blocks;

        public static void Initialise()
        {
            Blocks = new BBlock[]
            {
                new BBlock("OutsideBounds", BBlockType.Empty),
                new BBlock("Air", BBlockType.Empty),
                new BBlock("Grass", BBlockType.Ground),
                new BBlock("Tree", BBlockType.Solid),
            };

        }
    }
}
