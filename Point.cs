using System;
using System.Collections.Generic;
using System.Text;

namespace DivAddMining
{
    class Point
    {
        double x, y;

        public void SetXY(double px, double py)
        {
            x = px;
            y = py;
        }

        public double X
        {
            get { return x; }
            set { x = value; }
        }

        public double Y
        {
            get { return y; }
            set { y = value; }
        }
    }
}
