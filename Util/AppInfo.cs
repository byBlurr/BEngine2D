using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEngine2D.Util
{
    public static class AppInfo
    {
        // Information
        public static string APP_NAME = "";
        public static string APP_VERSION = "0.1";
        public static Release APP_RELEASE = Release.Alpha;
        public static string APP_UPDATE_DATE = "";
        public static string APP_DEVELOPER = "";

        // Development Info
        public static bool DISPLAY_APP_WATERMARK = false;
        public static string APP_WATERMARK = "";

        // Rendering Constants
        public static readonly int GRIDSIZE = 32; // Size of each tile/block
        public static readonly int TILESIZE = 256; // Size of each sprite
    }

    public enum Release
    {
        Alpha, Beta, Release
    }
}
