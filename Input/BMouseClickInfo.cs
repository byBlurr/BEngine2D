using OpenTK;

namespace BEngine2D.Input
{
    public class BMouseClickInfo
    {
        public bool IsPressed { get; set; }
        public Vector2 Location { get; set; }

        public BMouseClickInfo()
        {
            IsPressed = false;
            Location = new Vector2();
        }
    }
}
