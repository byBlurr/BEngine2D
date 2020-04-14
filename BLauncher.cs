using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
