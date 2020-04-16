using BEngine2D.Entities;
using BEngine2D.Render;
using BEngine2D.Util;
using BEngine2D.World;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BEngine2D.AI.Navigation
{
    public class BNavigationGrid
    {
        protected int x, y, width, height, tileSize;
        protected BPathNode[,] grid;

        public BNavigationGrid(int x, int y, int width, int height, int tileSize)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.tileSize = tileSize;

            // Initiate the nodes
            this.grid = new BPathNode[width, height];
            for (int x2 = 0; x2 < width; x2++)
            {
                for (int y2 = 0; y2 < height; y2++)
                {
                    grid[x2, y2] = new BPathNode(x2, y2, false, null, false);
                }
            }

            // Set up neighbours
            for (int x2 = 0; x2 < width; x2++)
            {
                for (int y2 = 0; y2 < height; y2++)
                {
                    grid[x2, y2].Neighbours.Clear();
                    if (x2 + 1 < width) grid[x2, y2].Neighbours.Add(grid[x2+1, y2]);
                    if (y2 + 1 < height) grid[x2, y2].Neighbours.Add(grid[x2, y2+1]);
                    if (x2 - 1 >= 0) grid[x2, y2].Neighbours.Add(grid[x2-1, y2]);
                    if (y2 - 1 >= 0) grid[x2, y2].Neighbours.Add(grid[x2, y2-1]);
                }
            }
        }

        public void Update(BLevel level)
        {
            float xScale = ((float)width / (float)level.Width);
            float yScale = ((float)height / (float)level.Height);

            for (int x = 0; x < this.Width; x++)
            {
                for (int y = 0; y < this.Height; y++)
                {
                    // Handle entities
                    int levelX = (int)Math.Floor(x / xScale);
                    int levelY = (int)Math.Floor(y / yScale);
                    if (levelX < level.Width && levelY < level.Height)
                    {
                        if (level[levelX, levelY].IsSolid) this[x, y].Obstructed = true;
                        else this[x, y].Obstructed = false;
                    }

                    RectangleF gridTile = new RectangleF(x * tileSize, y * tileSize, tileSize, tileSize);
                    foreach (BEntity entity in level.Entities)
                    {
                        if (entity != null)
                        {
                            if (gridTile.IntersectsWith(new RectangleF(entity.CollisionBox.X + entity.position.X, entity.CollisionBox.Y + entity.position.Y, entity.CollisionBox.Width, entity.CollisionBox.Height)))
                            {
                                this[x, y].Obstructed = true;
                            }
                        }
                    }
                }
            }
        }

        public void FindPathTo(Vector2 start, Vector2 destination)
        {
            if (start == destination) return;

            for (int x2 = 0; x2 < width; x2++)
            {
                for (int y2 = 0; y2 < height; y2++)
                {
                    grid[x2, y2].GlobalGoal = float.MaxValue;
                    grid[x2, y2].LocalGoal = float.MaxValue;
                    grid[x2, y2].Parent = null;
                    grid[x2, y2].Visited = false;
                    grid[x2, y2].Destination = false;
                }
            }

            bool pathFound = false;

            int startX = (int)(start.X / tileSize);
            int startY = (int)(start.Y / tileSize);
            int destX = (int)(destination.X / tileSize);
            int destY = (int)(destination.Y / tileSize);

            if (startX >= 0 && startX < width && destX >= 0&& destX < width && startY >= 0 && startY < height && destY >= 0 && destY < height)
            {
                List<BPathNode> nodes = new List<BPathNode>();
                var destNode = grid[destX, destY];
                destNode.Destination = true;

                var startNode = grid[startX, startY];
                startNode.Visited = true;
                startNode.GlobalGoal = (int)Vector2.Distance(new Vector2(startX, startY), new Vector2(destX, destY));
                nodes.Add(startNode);
            }
        }

        // Getters and Setters
        public BPathNode this[int x, int y]
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

        public float X { get => x; }
        public float Y { get => y; }
        public float Width { get => width; }
        public float Height { get => height; }
        public float TileSize { get => tileSize; }
    }

    public class BPathNode
    {
        public bool Obstructed;
        public bool Visited;
        public float GlobalGoal;
        public float LocalGoal;
        public int X, Y;
        public bool Destination;

        public List<BPathNode> Neighbours;
        public BPathNode Parent;

        public BPathNode(int x, int y, bool obstructed, BPathNode parent, bool visited)
        {
            X = x;
            Y = y;
            Obstructed = obstructed;
            Parent = parent;
            Visited = visited;
            Neighbours = new List<BPathNode>();
            Destination = false;
        }
    }
}
