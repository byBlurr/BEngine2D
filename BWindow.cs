using BEngine2D.GameStates;
using BEngine2D.Input;
using BEngine2D.Util;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System;

namespace BEngine2D
{
    public class BWindow
    {
        private BLaunchWindow Launcher;
        public GameWindow GameWindow;
        protected BState CurrentState;

        public void Launch(BLaunchWindow launcher, BState startState)
        {
            Launcher  = launcher;
            CurrentState = startState;

            // Setup window
            GameWindow = new GameWindow(AppSettings.SETTING_WIDTH, AppSettings.SETTING_HEIGHT);
            GameWindow.Title = AppInfo.APP_TITLE;

            if (AppSettings.SETTING_FULLSCREEN)
            {
                GameWindow.WindowState = WindowState.Fullscreen;

                if (AppSettings.SETTING_VSYNC) GameWindow.VSync = VSyncMode.Adaptive;
                else GameWindow.VSync = VSyncMode.Off;
            }
            else GameWindow.WindowState = WindowState.Normal;

            // Graphics Stuff
            GL.Enable(EnableCap.Texture2D);
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);

            // Frames
            GameWindow.Load += (object obj, EventArgs e) => { OnLoad(); };
            GameWindow.UpdateFrame += (object obj, FrameEventArgs args) => { Tick(args.Time); };
            GameWindow.RenderFrame += (object obj, FrameEventArgs args) => { Render(); };

            // Input
            BKeyboardListener.Initialize();
            BMouseListener.Initialize();
            GameWindow.KeyDown += (object sender, KeyboardKeyEventArgs e) => BKeyboardListener.UpdateKey((BKey)e.Key, true);
            GameWindow.KeyUp += (object sender, KeyboardKeyEventArgs e) => BKeyboardListener.UpdateKey((BKey)e.Key, false);
            GameWindow.MouseDown += (object sender, MouseButtonEventArgs e) => BMouseListener.UpdateButton((BMouseButton)e.Button, new System.Numerics.Vector2(e.X, e.Y), true);
            GameWindow.MouseUp += (object sender, MouseButtonEventArgs e) => BMouseListener.UpdateButton((BMouseButton)e.Button, new System.Numerics.Vector2(e.X, e.Y), false);
            GameWindow.MouseMove += (object sender, MouseMoveEventArgs e) => BMouseListener.UpdateLocation(e.Position);


            // Run the window
            GameWindow.Run(AppSettings.SETTING_UPS, AppSettings.SETTING_FPS);
        }

        public void ExitWindow(object obj)
        {
            GameWindow.Close();
            if (Launcher != null)
            {
                Launcher.GameClosed();
            }
        }

        public void SwitchState(BState newState)
        {
            CurrentState = newState;
            CurrentState.OnLoad(this);
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
