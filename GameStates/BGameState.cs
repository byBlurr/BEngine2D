using BEngine2D.Render;
using BEngine2D.World.Blocks;

namespace BEngine2D.GameStates
{
    public class BGameState : BState
    {
        protected BCamera Camera;

        public override void OnLoad()
        {
            base.OnLoad();
            Camera = new BCamera(System.Numerics.Vector2.Zero, 1.0, 0.0);
            BBlocks.Initialise();
        }

        public override void Tick(double delta)
        {
            base.Tick(delta);
            Camera.Update();
        }

        public override void Draw()
        {
            Camera.ApplyTransform();
            // draw the mouse icon
            base.Draw();
        }
    }
}
