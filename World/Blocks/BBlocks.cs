using BEngine2D.Util;
using System.Drawing;

namespace BEngine2D.World.Blocks
{
    public class BBlocks
    {
        private static BBlockTemplate[] Blocks;
        public static void Initialise()
        {
            Blocks = new BBlockTemplate[255];
            Blocks[0] = new BBlockTemplate("OutsideBounds", BBlockType.Empty, new RectangleF(0, 0, AppInfo.TILESIZE, AppInfo.TILESIZE));
        }

        public static void AddBlock(int id, BBlockTemplate block)
        {
            if (id >= 255) throw new System.Exception("The max block id is 254.");
            Blocks[id] = block;
        }

        public static BBlockTemplate GetBlock(int id) => Blocks[id];
    }

    public class BBlockTemplate
    {
        private string name;
        private BBlockType type;
        private RectangleF texturePosition;

        public BBlockTemplate(string name, BBlockType type, RectangleF texturePosition)
        {
            this.name = name;
            this.type = type;
            this.texturePosition = texturePosition;
        }

        public string Name { get => name; }
        public BBlockType Type { get => type; }
        public RectangleF TexturePosition { get => texturePosition; }
    }
}
