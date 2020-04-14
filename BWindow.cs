using BEngine2D.GameStates;
using BEngine2D.Input;
using BEngine2D.Util;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEngine2D
{
    public class BWindow
    {
        public GameWindow Window;
        protected BState CurrentState;

        public void Launch(BState startState)
        {
            CurrentState = startState;

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
            Window.MouseMove += (object sender, MouseMoveEventArgs e) => BMouseListener.UpdateLocation(e.Position);


            // Run the window
            Window.Run(AppSettings.SETTING_UPS, AppSettings.SETTING_FPS);
        }
        private void OnLoad()
        {
            CurrentState.OnLoad(this);
        }

        private void Render()
        {
            CurrentState.Render();
        }

        private void Tick(double delta)
        {
            CurrentState.Tick(delta);
        }

    }
}
