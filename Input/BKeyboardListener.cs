using System;

namespace BEngine2D.Input
{
    public class BKeyboardListener
    {
        private bool[] KeyStates = new bool[140];
        private bool[] KeyStatesNow = new bool[140];

        public bool IsKeyPressed(BKey key) => KeyStates[(int)key];

        public bool IsKeyJustPressed(BKey key)
        {
            if (KeyStatesNow[(int)key])
            {
                KeyStatesNow[(int)key] = false;
                return true;
            }
            else return false;
        }
        public void UpdateKey(BKey key, bool state)
        {
            if (KeyStates[(int)key] == state) return;
            KeyStates[(int)key] = state;
            KeyStatesNow[(int)key] = state;
        }
    }
}
