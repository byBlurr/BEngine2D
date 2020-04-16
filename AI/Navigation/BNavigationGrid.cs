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
        protected int x, y, width, height, tileSizeX, tileSizeY;
        protected BPathNode[,] grid;
        protected BPathNode destNode, startNode;

        public BNavigationGrid(int x, int y, int levelWidth, int levelHeight, int levelTileSize, int tileSizeX, int tileSizeY)
        {
            this.x = x;
            this.y = y;
            this.width = (levelWidth * levelTileSize) / tileSizeX;
            this.height = (levelHeight * levelTileSize) / tileSizeY;
            this.tileSizeX = tileSizeX;
            this.tileSizeY = tileSizeY;
            this.destNode = null;
            this.startNode = null;

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

                    RectangleF gridTile = new RectangleF(x * tileSizeX, y * tileSizeY, tileSizeX, tileSizeY);
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

            if (destNode != null && startNode != null)
            {
                // Update the path
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

            int startX = (int)(destination.X / tileSizeX);
            int startY = (int)(destination.Y / tileSizeY);
            int destX = (int)(start.X / tileSizeX);
            int destY = (int)(start.Y / tileSizeY);

            if (startX >= 0 && startX < width && destX >= 0&& destX < width && startY >= 0 && startY < height && destY >= 0 && destY < height)
            {
                destNode = grid[destX, destY];
                destNode.Destination = true;

                startNode = grid[startX, startY];
                startNode.LocalGoal = 0.0f;
                startNode.GlobalGoal = DistanceBetweenNodes(startNode, destNode);

                BPathNode nodeCurrent = startNode;
                nodeCurrent = startNode;

                List<BPathNode> notTestedNodes = new List<BPathNode>();
                notTestedNodes.Add(startNode);

                while (notTestedNodes.Count != 0)
                {
                    notTestedNodes = notTestedNodes.OrderBy(j => j.GlobalGoal).ToList<BPathNode>();

                    while (notTestedNodes.Count != 0 && notTestedNodes[0].Visited) notTestedNodes.RemoveAt(0);

                    if (notTestedNodes.Count == 0) break;

                    nodeCurrent = notTestedNodes[0];
                    nodeCurrent.Visited = true;

                    foreach (var neighbour in nodeCurrent.Neighbours)
                    {
                        if (!neighbour.Obstructed && !neighbour.Visited) notTestedNodes.Add(neighbour);

                        float possiblyLowerGoal = nodeCurrent.LocalGoal + DistanceBetweenNodes(nodeCurrent, neighbour);

                        if (possiblyLowerGoal < neighbour.LocalGoal)
                        {
                            neighbour.Parent = nodeCurrent;
                            neighbour.LocalGoal = possiblyLowerGoal;
                            neighbour.GlobalGoal = neighbour.LocalGoal + DistanceBetweenNodes(neighbour, destNode);
                        }
                    }
                }
            }
        }

        private float DistanceBetweenNodes(BPathNode node1, BPathNode node2)
        {
            return Vector2.Distance(new Vector2(node1.X, node1.Y), new Vector2(node2.X, node2.Y));
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
        public float TileSizeX { get => tileSizeX; }
        public float TileSizeY { get => tileSizeY; }
        public BPathNode DestNode { get => destNode; set => destNode = value; }
        public BPathNode StartNode { get => startNode; set => startNode = value; }
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
