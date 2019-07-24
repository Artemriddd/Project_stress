using System;
using System.Collections.Generic;
using System.Text;

namespace FrameStress
{
    class SkinGeom
    {
        private int skinTickness;

        public int SetSkinTickness
        {
            get
            {
                return skinTickness;
            }
            set
            {
                if (value>0)
                {
                    skinTickness = value;
                }
            }
        }
        public void GetSkingGeom()
        {
            Console.WriteLine("Введите толщину обшивки");
            SetSkinTickness = int.Parse(Console.ReadLine());
        }

    }
}
