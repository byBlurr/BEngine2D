using BEngine2D.Entities;
using BEngine2D.Render;
using BEngine2D.Util;
using BEngine2D.World;
using BEngine2D.World.Blocks;
using System.Drawing;
using System.Numerics;

namespace BEngine2D.GameStates
{
    public abstract class BGameState : BState
    {
        protected BLevel Level;
        protected BCamera Camera;
        protected BPlayableCharacter Player;
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

            if (Player != null) Player.Draw();

            foreach (BEntity entity in Level.Entities)
            {
                if (entity == null) return;
                entity.Draw();
            }
        }
    }
}
