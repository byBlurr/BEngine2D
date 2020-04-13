using BEngine2D.Input;
using BEngine2D.Util;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Graphics;
using OpenTK.Input;
using System;
using BEngine2D.Render;
using System.Drawing;

namespace BEngine2D
{
    public class BGame
    {
        protected GameWindow Window;
        protected BView Camera;

        protected int Width, Height;

        protected BKeyboardListener KeyboardListener;
        protected BMouseListener MouseListener;

        public BGame(string title, double fps, double ups, int width = 1280, int height = 720)
        {
            // Setup window
            Window = new GameWindow(width, height);
            Window.Title = title + " - BEngine2D";
            Width = Window.Width;
            Height = Window.Height;

            // Graphics Stuff
            GL.Enable(EnableCap.Texture2D);
            Camera = new BView(System.Numerics.Vector2.Zero, 1.0, 0.0);

            // Frames
            Window.Load += (object obj, EventArgs e) => { OnLoad(); };
            Window.UpdateFrame += (object obj, FrameEventArgs args) => { Tick(args.Time); };
            Window.RenderFrame += (object obj, FrameEventArgs args) => { Render(); };

            // Input
            KeyboardListener = new BKeyboardListener();
            Window.KeyDown += (object sender, KeyboardKeyEventArgs e) => KeyboardListener.UpdateKey((BKey)e.Key, true);
            Window.KeyUp += (object sender, KeyboardKeyEventArgs e) => KeyboardListener.UpdateKey((BKey)e.Key, false);
            MouseListener = new BMouseListener();
            Window.MouseDown += (object sender, MouseButtonEventArgs e) => MouseListener.UpdateButton((BMouseButton)e.Button, new System.Numerics.Vector2(e.X, e.Y), true);
            Window.MouseDown += (object sender, MouseButtonEventArgs e) => { OnMouseDown((BMouseButton)e.Button, new System.Numerics.Vector2(e.X, e.Y)); };
            Window.MouseUp += (object sender, MouseButtonEventArgs e) => MouseListener.UpdateButton((BMouseButton)e.Button, new System.Numerics.Vector2(e.X, e.Y), false);
            //TODO: Window.MouseWheel

            // Run the window
            Window.Run(ups, fps);
        }

        public virtual void OnLoad()
        {

        }

        public virtual void Tick(double delta)
        {

            Camera.Update();
        }

        public void Render()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.ClearColor(Color.White);

            BGraphics.Begin(Window.Width, Window.Height);
            Camera.ApplyTransform();

            Draw();

            Window.SwapBuffers();
        }

        public virtual void Draw()
        {

        }
        public virtual void OnMouseDown(BMouseButton button, System.Numerics.Vector2 position)
        {

        }
    }
}
