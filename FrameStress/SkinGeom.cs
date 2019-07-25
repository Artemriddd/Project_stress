using System;
using System.Collections.Generic;
using System.Text;

namespace FrameStress
{
    class SkinGeom
    {
        private int skinTickness;
        private float skinCoef;
        private int skinWidth;
        private int skinHeight;
        public int SetSkinTickness
        {
            get
            {
                return skinTickness;
            }
            set
            {
                if (value > 0)
                {
                    skinTickness = value;
                }
            }
        }
        public float SetskinCoef
        {
            get
            {
                return skinCoef;
            }
            set
            {
                if (value > 0)
                {
                    skinCoef = value;
                }
            }
        }

        public int SetskinWidth
        {
            get
            {
                return skinWidth;
            }
            set
            {
                if (value > 0)
                {
                    skinWidth = value;
                }
            }
        }
        public int SetskinHeight
        {
            get
            {
                return skinHeight;
            }
            set
            {
                if (value > 0)
                {
                    skinHeight = value;
                }
            }
        }

        public void GetSkingGeom()
        {
            Console.WriteLine("Введите толщину обшивки");
            SetSkinTickness = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите ширину клетки обшивки");
            SetskinWidth = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите высоту клетки обшивки");
            SetskinHeight = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите коэффициент граничных условий для клетки обшивки");
            SetskinCoef = float.Parse(Console.ReadLine());
        }
    }
}
