using BEngine2D.Render;
using BEngine2D.World.Blocks;

namespace BEngine2D.GameStates
{
    public class BGameState : BState
    {
        protected BView Camera;

        public override void OnLoad()
        {
            base.OnLoad();
            Camera = new BView(System.Numerics.Vector2.Zero, 1.0, 0.0);
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
