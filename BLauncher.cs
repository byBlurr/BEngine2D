using System.Windows.Forms;

namespace BEngine2D
{
    public class BLauncher
    {
        public BLauncher(BGame startState)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new BLaunchWindow(startState));
        }
    }
}
