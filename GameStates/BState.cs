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
        protected GameWindow Window;

        public void Launch()
        {
            // Setup window
            Window = new GameWindow(AppSettings.SETTING_WIDTH, AppSettings.SETTING_HEIGHT);
            Window.Title = AppInfo.APP_TITLE;

            if (AppSettings.SETTING_FULLSCREEN)
            {
                Window.WindowState = WindowState.Fullscreen;

                if (AppSettings.SETTING_VSYNC) Window.VSync = VSyncMode.Adaptive;
                else Window.VSync = VSyncMode.Off;
            }
            else Window.WindowState = WindowState.Normal;

            // Graphics Stuff
            GL.Enable(EnableCap.Texture2D);
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);

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
            Window.Run(AppSettings.SETTING_UPS, AppSettings.SETTING_FPS);
        }

        public virtual void OnLoad()
        {
        }

        public virtual void Tick(double delta)
        {
        }

        public void Render()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.ClearColor(Color.Black);
            BGraphics.Begin(Window.Width, Window.Height);
            Draw();
            Window.SwapBuffers();
        }

        public virtual void Draw()
        {
        }
    }
}
