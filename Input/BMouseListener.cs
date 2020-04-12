using BEngine2D.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEngine2D.Input
{
    public class BMouseListener
    {
        private BMouseClickInfo[] ButtonStates;

        public BMouseListener()
        {
            ButtonStates = new BMouseClickInfo[15];
            for (int i = 0; i < ButtonStates.Length; i++) ButtonStates[i] = new BMouseClickInfo();
        }

        public BMouseClickInfo GetButtonState(BMouseButton button) => ButtonStates[(int)button];

        public BMouseClickInfo GetButtonStateNow(BMouseButton button)
        {
            BMouseClickInfo result = new BMouseClickInfo() { IsPressed = ButtonStates[(int)button].IsPressed, Location = ButtonStates[(int)button].Location };
            if (result.IsPressed)
            {
                ButtonStates[(int)button].IsPressed = false;
                return result;
            }
            else return result;
        }

        public void UpdateButton(BMouseButton button, VectorInt location, bool state)
        {
            if (ButtonStates[(int)button].IsPressed == state) return;
            ButtonStates[(int)button].IsPressed = state;
            ButtonStates[(int)button].Location = location;
        }
    }
}
