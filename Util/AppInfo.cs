namespace BEngine2D.Util
{
    public static class AppInfo
    {
        // Information
        public static string APP_FILESAFENAME = "";
        public static string APP_NAME = "";
        public static string APP_VERSION = "0.1";
        public static Release APP_RELEASE = Release.Alpha;
        public static string APP_TITLE = "";
        public static string APP_UPDATE_DATE = "";
        public static string APP_DEVELOPER = "";

        // Development Info
        public static bool DISPLAY_APP_WATERMARK = false;
        public static string APP_WATERMARK = "";

        // Rendering Constants
        public static int GRIDSIZE = 32; // Size of each block
        public static int TILESIZE = 256; // Size of each block sprite
    }

    public enum Release
    {
        Alpha, Beta, Release
    }
}
