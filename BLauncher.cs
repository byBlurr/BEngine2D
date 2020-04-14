using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEngine2D
{
    public class BLauncher
    {
        private BGame startState;

        public BLauncher(BGame startState)
        {
            this.startState = startState;
        }

        public void LaunchGame()
        {
            startState.Launch();
        }
    }
}
