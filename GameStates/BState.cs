using BEngine2D.Input;
using BEngine2D.Render;
using BEngine2D.Util;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System;
using System.Drawing;

namespace BEngine2D.GameStates
{
    public class BState
    {
        protected BWindow Window;

        public virtual void OnLoad(BWindow Window)
        {
            this.Window = Window;
        }

        public virtual void Tick(double delta)
        {
        }

        public void Render()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.ClearColor(Color.Black);
            BGraphics.Begin(Window.Window.Width, Window.Window.Height);
            Draw();
            Window.Window.SwapBuffers();
        }

        public virtual void Draw()
        {
        }
    }
}
