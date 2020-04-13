using System;

namespace BEngine2D.Input
{
    public class BKeyboardListener
    {
        private static bool[] KeyStates;
        private static bool[] KeyStatesNow;

        public static void Initialize()
        {
            KeyStates = new bool[140];
            KeyStatesNow = new bool[140];
        }

        public static bool IsKeyPressed(BKey key) => KeyStates[(int)key];

        public static bool IsKeyJustPressed(BKey key)
        {
            if (KeyStatesNow[(int)key])
            {
                KeyStatesNow[(int)key] = false;
                return true;
            }
            else return false;
        }
        public static void UpdateKey(BKey key, bool state)
        {
            if (KeyStates[(int)key] == state) return;
            KeyStates[(int)key] = state;
            KeyStatesNow[(int)key] = state;
        }
    }
}
