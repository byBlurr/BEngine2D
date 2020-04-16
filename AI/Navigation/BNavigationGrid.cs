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
        protected float[,] grid;

        public BNavigationGrid(int x, int y, int width, int height, int tileSize)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.tileSize = tileSize;
            this.grid = new float[width, height];
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
                        if (level[levelX, levelY].IsSolid) this[x, y] = float.MaxValue;
                        else this[x, y] = 0f;
                    }

                    RectangleF gridTile = new RectangleF(x * tileSize, y * tileSize, tileSize, tileSize);
                    foreach (BEntity entity in level.Entities)
                    {
                        if (entity != null)
                        {
                            if (gridTile.IntersectsWith(new RectangleF(entity.CollisionBox.X + entity.position.X, entity.CollisionBox.Y + entity.position.Y, entity.CollisionBox.Width, entity.CollisionBox.Height)))
                            {
                                this[x, y] = float.MaxValue;
                            }
                        }
                    }
                }
            }
        }

        public void FindPathTo(Vector2 from, Vector2 destination)
        {
            // Get our navmesh tile equiv to the coords
            int destX = (int)(destination.X / tileSize);
            int destY = (int)(destination.Y / tileSize);
            int fromX = (int)(from.X / tileSize);
            int fromY = (int)(from.Y / tileSize);

            // Make sure we arent trying to go to where we already are
            if (destX != fromX || destY != fromY)
            {
                // Make sure the destination is inside the nav mesh bounds
                if (destX >= 0 && destX < width && destY >= 0 && destY < height)
                {
                    // Make sure we can go to our destination
                    if (grid[destX, destY] < float.MaxValue)
                    {
                        // Set our starting point as max float
                        grid[fromX, fromY] = float.MaxValue;

                        // Set our destination location to 0
                        float currentScore = 0f;
                        grid[destX, destY] = currentScore;
                        currentScore++;

                        // Algorithm to find fastest path
                    }
                }
            }
        }

        // Getters and Setters
        public float this[int x, int y]
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
}
