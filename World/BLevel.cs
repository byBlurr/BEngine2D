using BEngine2D.Util;
using BEngine2D.World.Blocks;
using System;
using System.Drawing;
using System.IO;

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
            playerStartPos = new Point((int)(width / AppInfo.TILESIZE), (int)(height / AppInfo.TILESIZE));

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (x == 0 || y == 0 || x == width - 1 || y == height - 1)
                    {
                        BBlockTemplate block = BBlocks.GetBlock(1);
                        grid[x, y] = new BBlock(block.Name, block.Type, block.TexturePosition, x, y);
                    }
                    else
                    {
                        BBlockTemplate block = BBlocks.GetBlock(2);
                        grid[x, y] = new BBlock(block.Name, block.Type, block.TexturePosition, x, y);
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
                    BBlockTemplate block = BBlocks.GetBlock(Tiles[i]);
                    grid[x, y] = new BBlock(block.Name, block.Type, block.TexturePosition, x, y);

                    x++;
                    if (x >= width)
                    {
                        x = 0;
                        y++;
                    }
                }

                playerStartPos = new Point(width / 2, height / 2);
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
                            BBlockTemplate block = BBlocks.GetBlock(1);
                            grid[x, y] = new BBlock(block.Name, block.Type, block.TexturePosition, x, y);
                        }
                        else
                        {
                            BBlockTemplate block = BBlocks.GetBlock(2);
                            grid[x, y] = new BBlock(block.Name, block.Type, block.TexturePosition, x, y);
                        }
                    }
                }
            }
        }
    }
}
