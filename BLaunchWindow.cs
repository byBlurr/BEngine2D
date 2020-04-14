using BEngine2D.GameStates;
using BEngine2D.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BEngine2D
{
    public partial class BLaunchWindow : Form
    {
        private string SETTINGS_PATH = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BEngine2D/Settings");
        private LaunchSettings settings;
        private BState game;
        private bool close = false;

        public BLaunchWindow(BState game)
        {
            InitializeComponent();
            this.game = game;

            if (!Directory.Exists(SETTINGS_PATH)) Directory.CreateDirectory(SETTINGS_PATH);

            if (!File.Exists(Path.Combine(SETTINGS_PATH, $"{AppInfo.APP_FILESAFENAME}.json")))
            {
                this.CloseBox.Checked = this.close;
                this.FullscreenBox.Checked = AppSettings.SETTING_FULLSCREEN;
                this.VsyncBox.Checked = AppSettings.SETTING_VSYNC;
                this.VsyncBox.Enabled = AppSettings.SETTING_FULLSCREEN;
                this.FpsBox.Text = AppSettings.SETTING_FPS.ToString();
                this.WidthBox.Text = AppSettings.SETTING_WIDTH.ToString();
                this.HeightBox.Text = AppSettings.SETTING_HEIGHT.ToString();

                settings = new LaunchSettings(false, AppSettings.SETTING_FULLSCREEN, AppSettings.SETTING_VSYNC, AppSettings.SETTING_FPS, AppSettings.SETTING_WIDTH, AppSettings.SETTING_HEIGHT);
                settings.Save(Path.Combine(SETTINGS_PATH, $"{AppInfo.APP_FILESAFENAME}.json"));
            }
            else
            {
                settings = LaunchSettings.Load(Path.Combine(SETTINGS_PATH, $"{AppInfo.APP_FILESAFENAME}.json"));
                this.close = settings.CloseOnLaunch;
                this.CloseBox.Checked = settings.CloseOnLaunch;
                this.FullscreenBox.Checked = settings.Fullscreen;
                this.VsyncBox.Checked = settings.Vsync;
                this.VsyncBox.Enabled = settings.Fullscreen;
                this.FpsBox.Text = settings.Fps.ToString();
                this.WidthBox.Text = settings.WindowWidth.ToString();
                this.HeightBox.Text = settings.WindowHeight.ToString();
            }

            this.Text = $"Made with BEngine2D - {AppInfo.APP_NAME}";
        }

        private void LaunchGame(object sender, EventArgs e)
        {
            if (this.close) this.Close();
            else this.LaunchButton.Enabled = false;
            game.Launch();
        }

        private void SaveSettings(object sender, EventArgs e)
        {
            ApplySettings(sender, e);
            settings.Save(Path.Combine(SETTINGS_PATH, $"{AppInfo.APP_FILESAFENAME}.json"));
        }

        private void ApplySettings(object sender, EventArgs e)
        {
            settings.CloseOnLaunch = this.CloseBox.Checked;
            this.close = this.CloseBox.Checked;

            settings.Fullscreen = this.FullscreenBox.Checked;
            AppSettings.SETTING_FULLSCREEN = this.FullscreenBox.Checked;

            settings.Vsync = this.VsyncBox.Checked;
            AppSettings.SETTING_VSYNC = this.VsyncBox.Checked;

            settings.Fps = Convert.ToInt32(this.FpsBox.Text);
            AppSettings.SETTING_FPS = Convert.ToInt32(this.FpsBox.Text);

            settings.WindowWidth = Convert.ToInt32(this.WidthBox.Text);
            AppSettings.SETTING_WIDTH = Convert.ToInt32(this.WidthBox.Text);

            settings.WindowHeight = Convert.ToInt32(this.HeightBox.Text);
            AppSettings.SETTING_HEIGHT = Convert.ToInt32(this.HeightBox.Text);
        }

        private void EnableVsync(object sender, EventArgs e)
        {
            if (FullscreenBox.Checked) VsyncBox.Enabled = true;
            else VsyncBox.Enabled = false;
        }
    }
}
