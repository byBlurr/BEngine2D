using BEngine2D.Util;

namespace BEngine2D.Input
{
    public class BMouseClickInfo
    {
        public bool IsPressed { get; set; }
        public VectorInt Location { get; set; }

        public BMouseClickInfo()
        {
            IsPressed = false;
            Location = new VectorInt();
        }
    }
}
