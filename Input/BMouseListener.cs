using System.Numerics;

namespace BEngine2D.Input
{
    public class BMouseListener
    {
        private static BMouseClickInfo[] ButtonStates;

        public static void Initialize()
        {
            ButtonStates = new BMouseClickInfo[15];
            for (int i = 0; i < ButtonStates.Length; i++) ButtonStates[i] = new BMouseClickInfo();
        }

        public static BMouseClickInfo GetButtonState(BMouseButton button) => ButtonStates[(int)button];

        public static BMouseClickInfo GetButtonStateNow(BMouseButton button)
        {
            BMouseClickInfo result = new BMouseClickInfo() { IsPressed = ButtonStates[(int)button].IsPressed, Location = ButtonStates[(int)button].Location };
            if (result.IsPressed)
            {
                ButtonStates[(int)button].IsPressed = false;
                return result;
            }
            else return result;
        }

        public static void UpdateButton(BMouseButton button, Vector2 location, bool state)
        {
            if (ButtonStates[(int)button].IsPressed == state) return;
            ButtonStates[(int)button].IsPressed = state;
            ButtonStates[(int)button].Location = location;
        }
    }

    public enum BMouseButton
    {
        Left = 0,
        Middle = 1,
        Right = 2,
        Button1 = 3,
        Button2 = 4,
        Button3 = 5,
        Button4 = 6,
        Button5 = 7,
        Button6 = 8,
        Button7 = 9,
        Button8 = 10,
        Button9 = 11,
        LastButton = 12
    }
}
