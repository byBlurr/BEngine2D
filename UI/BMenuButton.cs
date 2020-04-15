using BEngine2D.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEngine2D.UI
{
    public class BMenuButton
    {
        protected Action<Object> action;
        public float X, Y, X1, Y1, WIDTH, HEIGHT;

        public BMenuButton(Action<Object> action, float x, float y, float width, float height)
        {
            this.action = action;
            X = x;
            Y = y;
            WIDTH = width;
            HEIGHT = height;
            X1 = x + -width;
            Y1 = y + -height;
        }

        public float ScreenX { get => X - (AppSettings.SETTING_WIDTH / 2); }
        public float ScreenX1 { get => X1 - (AppSettings.SETTING_WIDTH / 2); }
        public float ScreenY { get => Y - (AppSettings.SETTING_HEIGHT / 2); }
        public float ScreenY1 { get => Y1 - (AppSettings.SETTING_HEIGHT / 2); }

        public virtual void Pressed(Object obj)
        {
            this.action.Invoke(obj);
        }
    }
}
