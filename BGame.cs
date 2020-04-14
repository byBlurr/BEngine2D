using BEngine2D.Input;
using BEngine2D.Util;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Graphics;
using OpenTK.Input;
using System;
using BEngine2D.Render;
using System.Drawing;
using BEngine2D.World.Blocks;

namespace BEngine2D
{
    public class BGame
    {
        protected GameWindow Window;
        protected BView Camera;

        protected int Width, Height;

        public BGame(string title, double fps, double ups, int width = 1280, int height = 720)
        {
            // Setup window
            Window = new GameWindow(width, height);
            Window.Title = title + " - BEngine2D";
            Width = Window.Width;
            Height = Window.Height;

            // Graphics Stuff
            GL.Enable(EnableCap.Texture2D);
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);
            Camera = new BView(System.Numerics.Vector2.Zero, 1.0, 0.0);

            // Frames
            Window.Load += (object obj, EventArgs e) => { OnLoad(); };
            Window.UpdateFrame += (object obj, FrameEventArgs args) => { Tick(args.Time); };
            Window.RenderFrame += (object obj, FrameEventArgs args) => { Render(); };

            // Input
            BKeyboardListener.Initialize();
            BMouseListener.Initialize();
            Window.KeyDown += (object sender, KeyboardKeyEventArgs e) => BKeyboardListener.UpdateKey((BKey)e.Key, true);
            Window.KeyUp += (object sender, KeyboardKeyEventArgs e) => BKeyboardListener.UpdateKey((BKey)e.Key, false);
            Window.MouseDown += (object sender, MouseButtonEventArgs e) => BMouseListener.UpdateButton((BMouseButton)e.Button, new System.Numerics.Vector2(e.X, e.Y), true);
            Window.MouseUp += (object sender, MouseButtonEventArgs e) => BMouseListener.UpdateButton((BMouseButton)e.Button, new System.Numerics.Vector2(e.X, e.Y), false);
            //TODO: Window.MouseWheel

            // Run the window
            Window.Run(ups, fps);
        }

        public virtual void OnLoad()
        {
            BBlocks.Initialise();
        }

        public virtual void Tick(double delta)
        {
            Camera.Update();
        }

        public void Render()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.ClearColor(Color.Green);

            BGraphics.Begin(Window.Width, Window.Height);
            Camera.ApplyTransform();

            Draw();

            Window.SwapBuffers();
        }

        public virtual void Draw()
        {

        }
    }
}
