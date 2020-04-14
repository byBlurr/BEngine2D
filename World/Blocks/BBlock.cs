using BEngine2D.Util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEngine2D.World.Blocks
{
    public struct BBlock
    {
        private string name;
        private BBlockType type;
        private int posX, posY;
        private bool solid, ground;
        private RectangleF texturePosition;

        public string Name
        {
            get
            {
                return name;
            }
        }
        public BBlockType Type
        {
            get
            {
                return type;
            }
        }
        public RectangleF TexturePosition
        {
            get
            {
                return texturePosition;
            }
        }
        public int PosX
        {
            get
            {
                return posX;
            }
        }
        public int PosY
        {
            get
            {
                return posY;
            }
        }
        public bool IsSolid
        {
            get
            {
                return solid;
            }
        }
        public bool IsGround
        {
            get
            {
                return ground;
            }
        }

        public BBlock(string name, BBlockType type, RectangleF texturePosition, int x, int y)
        {
            this.name = name;
            this.type = type;
            this.texturePosition = texturePosition;
            posX = x;
            posY = y;

            solid = false;
            ground = false;

            switch (type)
            {
                case BBlockType.Empty:
                    solid = true;
                    break;
                case BBlockType.Ground:
                    ground = true;
                    break;
                case BBlockType.Solid:
                    solid = true;
                    break;
                default:
                    solid = false;
                    ground = false;
                    break;
            }
        }

        public BBlock(string name, BBlockType type, RectangleF texturePosition)
        {
            this.name = name;
            this.type = type;
            this.texturePosition = texturePosition;
            posX = 0;
            posY = 0;

            solid = false;
            ground = false;

            switch (type)
            {
                case BBlockType.Empty:
                    solid = true;
                    break;
                case BBlockType.Ground:
                    ground = true;
                    break;
                case BBlockType.Solid:
                    solid = true;
                    break;
                default:
                    solid = false;
                    ground = false;
                    break;
            }
        }
    }
}
