using BEngine2D.AI.Navigation;
using BEngine2D.Entities;
using BEngine2D.Render;
using BEngine2D.Util;
using BEngine2D.World;
using BEngine2D.World.Blocks;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;

namespace BEngine2D.GameStates
{
    public abstract class BGameState : BState
    {
        protected BLevel Level;
        protected BCamera Camera;
        protected BPlayableCharacter Player;
        protected BNavigationGrid NavMesh;

        protected BTexture[] Textures = new BTexture[255];

        public override void OnLoad(BWindow Window)
        {
            base.OnLoad(Window);
            Camera = new BCamera(Vector2.Zero, 1.0, 0.0);
            InitialiseTextures();
            BBlocks.Initialise();
            InitialiseBlocks();
            InitialiseLevel();
        }
        public virtual void InitialiseTextures() { }

        public virtual void InitialiseBlocks() { }

        public virtual void InitialiseLevel() { }

        public override void Tick(double delta)
        {
            base.Tick(delta);
            Camera.Update();

            if (Player != null) Player.Update(delta, Level);
        }

        public override void Draw()
        {
            Camera.ApplyTransform();
            base.Draw();

            for (int x = 0; x < Level.Width; x++)
            {
                for (int y = 0; y < Level.Height; y++)
                {
                    RectangleF source = Level[x, y].TexturePosition;
                    BGraphics.Draw(Textures[0], new Vector2(x * AppInfo.GRIDSIZE, y * AppInfo.GRIDSIZE), new Vector2((float)AppInfo.GRIDSIZE / AppInfo.TILESIZE), Color.Transparent, Vector2.Zero, source);
                }
            }

            List<BEntity> renderOrder = new List<BEntity>();
            renderOrder.AddRange(Level.Entities);
            if (Player != null) renderOrder.Add(Player);
            renderOrder = renderOrder.OrderBy(x => x.GroundLevel).ToList<BEntity>();

            foreach (BEntity entity in renderOrder)
            {
                if (entity == null) return;
                entity.Draw();
            }

            if (AppSettings.SETTING_NAVIGATION_DEBUG)
            {
                for (int x = 0; x < NavMesh.Width; x++)
                {
                    for (int y = 0; y < NavMesh.Height; y++)
                    {
                        var color = Color.Green;
                        if (NavMesh[x, y].Obstructed) color = Color.Red;
                        BGraphics.DrawRec(new Vector2(x * NavMesh.TileSizeX, y * NavMesh.TileSizeY), new RectangleF(x * NavMesh.TileSizeX, y * NavMesh.TileSizeY, NavMesh.TileSizeX, NavMesh.TileSizeY), color);
                    }
                }
            }

            if (AppSettings.SETTING_PATHFINDING_DEBUG)
            {
                if (NavMesh.DestNode != null)
                {
                    BPathNode pathNode = NavMesh.DestNode;
                    BGraphics.DrawRec(new Vector2(pathNode.X * NavMesh.TileSizeX, pathNode.Y * NavMesh.TileSizeY), new RectangleF(pathNode.X * NavMesh.TileSizeX, pathNode.Y * NavMesh.TileSizeY, NavMesh.TileSizeX, NavMesh.TileSizeY), Color.Orange);

                    while (pathNode.Parent != null)
                    {
                        BGraphics.DrawRec(new Vector2(pathNode.X * NavMesh.TileSizeX, pathNode.Y * NavMesh.TileSizeY), new RectangleF(pathNode.X * NavMesh.TileSizeX, pathNode.Y * NavMesh.TileSizeY, NavMesh.TileSizeX, NavMesh.TileSizeY), Color.Yellow);
                        pathNode = pathNode.Parent;
                    }
                }
            }
        }
    }
}
