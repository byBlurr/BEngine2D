using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEngine2D.Util
{
    public class LaunchSettings
    {
        public bool CloseOnLaunch { get; set; }
        public bool Fullscreen { get; set; }
        public bool Vsync { get; set; }
        public float Fps { get; set; }
        public int WindowWidth { get; set; }
        public int WindowHeight { get; set; }

        public LaunchSettings(bool close, bool fullscreen, bool vsync, float fps, int width, int height)
        {
            CloseOnLaunch = close;
            Fullscreen = fullscreen;
            Vsync = vsync;
            Fps = fps;
            WindowWidth = width;
            WindowHeight = height;
        }

        public void Save(string path)
        {
            File.WriteAllText(path, ToJson());
        }

        public static LaunchSettings Load(string path)
        {
            return JsonConvert.DeserializeObject<LaunchSettings>(File.ReadAllText(path));
        }

        public string ToJson() => JsonConvert.SerializeObject(this, Formatting.Indented);
    }
}
