using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEngine2D.Util
{
    public class VectorDouble
    {
        public double X { get; set; }
        public double Y { get; set; }

        public VectorDouble(double x, double y)
        {
            X = x;
            Y = y;
        }

        public VectorDouble()
        {
            X = 0.0;
            Y = 0.0;
        }
    }

    public class VectorFloat
    {
        public float X { get; set; }
        public float Y { get; set; }

        public VectorFloat(float x, float y)
        {
            X = x;
            Y = y;
        }

        public VectorFloat()
        {
            X = 0.0f;
            Y = 0.0f;
        }
    }

    public class VectorInt
    {
        public int X { get; set; }
        public int Y { get; set; }

        public VectorInt(int x, int y)
        {
            X = x;
            Y = y;
        }

        public VectorInt()
        {
            X = 0;
            Y = 0;
        }
    }
}
