using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEngine2D.Util
{
    public class Maths
    {
        public static float Clamp(float var, float min, float max)
        {
            if (var < min) var = min;
            if (var > max) var = max;
            return var;
        }
    }
}
