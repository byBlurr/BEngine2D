using BEngine2D.Input;
using BEngine2D.UI;
using System;
using OpenTK.Graphics.OpenGL;
using BEngine2D.Util;

namespace BEngine2D.GameStates
{
    public abstract class BMenuState : BState
    {
        private BMenuButton[] buttons;

        public override void OnLoad(BWindow Window)
        {
            base.OnLoad(Window);
        }

        public void InitialiseMenu(BMenuButton[] buttons)
        {
            this.buttons = buttons;
        }

        public override void Tick(double delta)
        {
            base.Tick(delta);
            MenuPress();
        }

        public void MenuPress()
        {
            var LeftClick = BMouseListener.GetButtonStateNow(BMouseButton.Left);
            if (LeftClick.IsPressed)
            {
                for (int i = 0; i < buttons.Length; i++)
                {
                    if (LeftClick.Location.X <= buttons[i].X && LeftClick.Location.X >= buttons[i].X1)
                    {
                        if (LeftClick.Location.Y <= buttons[i].Y && LeftClick.Location.Y >= buttons[i].Y1)
                        {
                            buttons[i].Pressed(Window);
                        }
                    }
                }
            }
        }

        public override void Draw()
        {
            base.Draw();
            foreach (BMenuButton button in buttons) button.Draw();
        }
    }
}
