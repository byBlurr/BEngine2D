using BEngine2D.Entities;
using BEngine2D.Util;
using BEngine2D.World.Blocks;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Numerics;

namespace BEngine2D.World
{
    public struct BLevel
    {
        private BBlock[,] grid;
        private List<BEntity> entities;
        private string mapname;
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

        public List<BEntity> Entities
        {
            get
            {
                return entities;
            }
        }

        public string Mapname
        {
            get
            {
                return mapname;
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
            entities = new List<BEntity>();
            mapname = "none";
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
        public BLevel(string mapname, string savename)
        {
            try
            {
                if (!Directory.Exists("Content/Maps")) Directory.CreateDirectory("Content/Maps");
                if (!File.Exists($"Content/Maps/{mapname}.ls")) throw new FileNotFoundException($"No map found with name '{mapname}'.");
                var Map = BLevelFile.FromJson(File.ReadAllText($"Content/Maps/{mapname}.ls"));

                if (!Directory.Exists("Content/Saves")) Directory.CreateDirectory("Content/Saves");
                if (!File.Exists($"Content/Saves/{savename}.ws")) new BGameSave().Save(savename);
                var Save = BGameSave.Load(savename);

                int width = Map.Width;
                int height = Map.Height;

                grid = new BBlock[width, height];
                entities = Save.Entities;
                this.mapname = mapname;
                playerStartPos = new Point(1, 1);

                int[] Tiles = Map.Layers[0].Data;
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
                entities = new List<BEntity>();
                this.mapname = "none";
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

        public void CreateEntity(BEntity entity)
        {
            entities.Add(entity);
            entities = entities.OrderBy(e => e.position.Y).ToList<BEntity>();
        }

        public BEntity GetEntity(Vector2 pos, float range = 2000f)
        {
            BEntity result = null;
            float distance = range;

            for (int i = 0; i < entities.Count; i++)
            {
                float dis = Vector2.Distance(entities[i].position, pos);
                if (dis < distance)
                {
                    distance = dis;
                    result = entities[i];
                }
            }
            return result;
        }

        public void DisposeEntity(BEntity entity)
        {
            entities.Remove(entity);
        }
    }
}
