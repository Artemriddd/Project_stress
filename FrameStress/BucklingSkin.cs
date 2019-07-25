using System;
using System.Collections.Generic;
using System.Text;

namespace FrameStress
{
    class BucklingSkin
    {

        public static float Buckling(float k, int e, int b, int delta)
        {
            float critical =  k * e / (b / delta * b / delta);
            return critical;
        }
    }
}
