using BEngine2D.GameStates;
using System;
using System.Windows.Forms;

namespace BEngine2D
{
    public class BLauncher
    {
        public BLauncher(BState startState)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new BLaunchWindow(startState));
        }
    }
}
