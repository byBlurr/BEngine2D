using BEngine2D.Input;
using BEngine2D.Util;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.ES20;
using OpenTK.Input;
using System;

namespace BEngine2D
{
    public class BGame
    {
        protected GameWindow Window;
        protected BKeyboardListener KeyboardListener;
        protected BMouseListener MouseListener;

        public BGame(string title, double fps, double ups)
        {
            // Setup window
            Window = new GameWindow();
            Window.Title = title;
            Window.WindowState = WindowState.Fullscreen;

            // Frames
            Window.UpdateFrame += (object obj, FrameEventArgs args) => { Tick(args.Time); };
            Window.RenderFrame += (object obj, FrameEventArgs args) => { Render(); };

            // Input
            KeyboardListener = new BKeyboardListener();
            Window.KeyDown += (object sender, KeyboardKeyEventArgs e) => KeyboardListener.UpdateKey((BKey)e.Key, true);
            Window.KeyUp += (object sender, KeyboardKeyEventArgs e) => KeyboardListener.UpdateKey((BKey)e.Key, false);
            MouseListener = new BMouseListener();
            Window.MouseDown += (object sender, MouseButtonEventArgs e) => MouseListener.UpdateButton((BMouseButton)e.Button, new VectorInt(e.X, e.Y), true);
            Window.MouseUp += (object sender, MouseButtonEventArgs e) => MouseListener.UpdateButton((BMouseButton)e.Button, new VectorInt(e.X, e.Y), false);
            //TODO: Window.MouseWheel

            GL.ClearColor(Color4.White);

            Window.Run(ups, fps);
        }

        public virtual void Tick(double delta)
        {
        }

        public virtual void Render()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);
            Window.SwapBuffers();
        }
    }
}
