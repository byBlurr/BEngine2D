using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using System.Drawing;
using System.IO;
using System.Numerics;
using Newtonsoft.Json.Serialization;

namespace BEngine2D.World
{
    public struct BLevel
    {
        private BBlock[,] grid;
        private string filename;
        public Point playerStartPos;

        public BBlock this[int x, int y]
        {
            get
            {
                return grid[x, y];
            }
            set
            {
                grid[x, y] = value;
            }
        }

        public string Filename
        {
            get
            {
                return filename;
            }
        }

        public int Width
        {
            get
            {
                return grid.GetLength(0);
            }
        }
        public int Height
        {
            get
            {
                return grid.GetLength(1);
            }
        }

        public BLevel(int width, int height)
        {
            grid = new BBlock[width, height];
            filename = "none";
            playerStartPos = new Point(1,1);

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (x == 0 || y == 0 || x == width - 1 || y == height - 1)
                    {
                        grid[x, y] = new BBlock(BBlockType.Solid, x, y);
                    }
                    else
                    {
                        grid[x, y] = new BBlock(BBlockType.Floor, x, y);
                    }
                }
            }
        }
        public BLevel(string filePath)
        {
            try
            {
                if (!File.Exists(filePath)) throw new FileNotFoundException($"File not found at '{filePath}'.");
                var Doc = BLevelFile.FromJson(File.ReadAllText(filePath));

                int width = Doc.Width;
                int height = Doc.Height;

                grid = new BBlock[width, height];
                filename = filePath;
                playerStartPos = new Point(1, 1);

                int[] Tiles = Doc.Layers[0].Data;
                int x = 0;
                int y = 0;
                for (int i = 0; i < Tiles.Length; i++)
                {
                    switch (Tiles[i])
                    {
                        case 2:
                            grid[x, y] = new BBlock(BBlockType.Floor, x, y);
                            break;
                        case 3:
                            grid[x, y] = new BBlock(BBlockType.Solid, x, y);
                            break;
                        default:
                            grid[x, y] = new BBlock(BBlockType.Empty, x, y);
                            break;
                    }

                    x++;
                    if (x >= width)
                    {
                        x = 0;
                        y++;
                    }
                }

                playerStartPos = new Point(width/2, height/2);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                int width = 20;
                int height = 20;
                grid = new BBlock[width, height];
                filename = "none";
                playerStartPos = new Point(1, 1);

                for (int x = 0; x < width; x++)
                {
                    for (int y = 0; y < height; y++)
                    {
                        if (x == 0 || y == 0 || x == width - 1 || y == height - 1)
                        {
                            grid[x, y] = new BBlock(BBlockType.Solid, x, y);
                        }
                        else
                        {
                            grid[x, y] = new BBlock(BBlockType.Floor, x, y);
                        }
                    }
                }
            }
        }
    }

    public enum BBlockType
    {
        Empty,
        Floor,
        Solid,
    }

    public struct BBlock
    {
        private BBlockType type;
        private int posX, posY;
        private bool solid, floor;

        public BBlockType Type
        {
            get
            {
                return type;
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
        public bool IsFloor
        {
            get
            {
                return floor;
            }
        }

        public BBlock(BBlockType type, int x, int y)
        {
            this.type = type;
            posX = x;
            posY = y;

            solid = false;
            floor = false;

            switch (this.type)
            {
                case BBlockType.Floor:
                    floor = true;
                    break;
                case BBlockType.Solid:
                    solid = true;
                    break;
                default:
                    solid = false;
                    floor = false;
                    break;
            }
        }
    }
}
