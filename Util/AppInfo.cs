using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEngine2D.Util
{
    public class AppInfo
    {
        public static string APP_NAME = "";
        public static string APP_VERSION = "0.1";
        public static Release APP_RELEASE = Release.Alpha;
        public static string APP_UPDATE_DATE = "";
        public static string APP_DEVELOPER = "";

        public static bool DISPLAY_APP_WATERMARK = false;
        public static string APP_WATERMARK = "";
    }

    public enum Release
    {
        Alpha, Beta, Release
    }
}
