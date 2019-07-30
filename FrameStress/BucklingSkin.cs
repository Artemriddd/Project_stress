using System;
using System.Collections.Generic;
using System.Text;

namespace FrameStress
{
    class BucklingSkin
    {

        public static double Buckling(double k, double e, double b, double delta)
        {
            double critical =  k * e / (b / delta * b / delta);
            return critical;
        }
    }
}
