using System;
using System.Collections.Generic;
using System.Text;

namespace FrameStress
{
    class FrameGeom
    {
        private double insideBelt;
        private double outsideBelt;
        private double frameWall;
        private double ticknessinsideBelt;
        private double ticknessoutsideBelt;
        private double ticknessframeWall;
        private double skinTickness;
        private float skinCoef;
        private double skinWidth;
        private double skinHeight;
        private double area;
        public double SetinsideBelt
        {
            get
            {
                return insideBelt;
            }
            set
            {
                if (value > 0)
                {
                    insideBelt = value;
                }
            }
        }
        public double SetoutsideBelt
        {
            get
            {
                return outsideBelt;
            }
            set
            {
                if (value > 0)
                {
                    outsideBelt = value;
                }
            }
        }
        public double SetframeWall
        {
            get
            {
                return frameWall;
            }
            set
            {
                if (value > 0)
                {
                    frameWall = value;
                }
            }
        }
        public double SetticknessinsideBelt
        {
            get
            {
                return ticknessinsideBelt;
            }
            set
            {
                if (value > 0)
                {
                    ticknessinsideBelt = value;
                }
            }
        }
        public double SetticknessoutsideBelt
        {
            get
            {
                return ticknessoutsideBelt;
            }
            set
            {
                if (value > 0)
                {
                    ticknessoutsideBelt = value;
                }
            }
        }
        public double SetticknessframeWall
        {
            get
            {
                return ticknessframeWall;
            }
            set
            {
                if (value > 0)
                {
                    ticknessframeWall = value;
                }
            }
        }

        public double SetSkinTickness
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

        public double SetskinWidth
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
        public double SetskinHeight
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

        public double SetArea
        {
            get
            {
                return area;
            }
            private set
            {
                if (value > 0)
                {
                    area = value;
                }
            }
        }

        public void GetFrGeom()
        {
            Console.WriteLine("Введите ширину внутреннего пояса шпангоута");
            SetinsideBelt = double.Parse(Console.ReadLine());

            Console.WriteLine("Введите толщину внутреннего пояса шпангоута");
            SetticknessinsideBelt = double.Parse(Console.ReadLine());

            Console.WriteLine("Введите высоту стенки пояса шпангоута");
            SetframeWall = double.Parse(Console.ReadLine());

            Console.WriteLine("Введите толщину стенки шпангоута");
            SetticknessframeWall = double.Parse(Console.ReadLine());

            Console.WriteLine("Введите ширину внешнего пояса шпангоута");
            SetoutsideBelt = double.Parse(Console.ReadLine());

            Console.WriteLine("Введите толщину внешнего пояса шпангоута");
            SetticknessoutsideBelt = double.Parse(Console.ReadLine());

            Console.WriteLine("Введите толщину обшивки");
            SetSkinTickness = double.Parse(Console.ReadLine());

            Console.WriteLine("Введите ширину клетки обшивки");
            SetskinWidth = double.Parse(Console.ReadLine());

            Console.WriteLine("Введите высоту клетки обшивки");
            SetskinHeight = double.Parse(Console.ReadLine());

            Console.WriteLine("Введите коэффициент граничных условий для клетки обшивки");
            SetskinCoef = float.Parse(Console.ReadLine());
        }
        public double GetInertion()
        {
            double inertion = Math.Pow(SetticknessinsideBelt, 3) * SetinsideBelt / 12 + (SetinsideBelt * SetticknessinsideBelt * Math.Pow(SetframeWall - GetCenterOrigin() - SetticknessinsideBelt / 2, 2)) + Math.Pow(SetticknessoutsideBelt, 3) * SetoutsideBelt / 12 + (SetoutsideBelt * SetticknessoutsideBelt * Math.Pow(GetCenterOrigin() - SetticknessoutsideBelt / 2, 2)) + Math.Pow(SetframeWall, 3) * SetticknessframeWall / 12 + (SetframeWall * SetticknessframeWall * Math.Pow(GetCenterOrigin() - SetframeWall / 2, 2));
            return inertion;
        }
        public double GetCenterOrigin()
        {
            SetArea = SetinsideBelt * SetticknessinsideBelt + SetoutsideBelt * SetticknessoutsideBelt + SetticknessframeWall * SetframeWall;
            double statInertion = (SetinsideBelt * SetticknessinsideBelt) * (SetframeWall - SetticknessinsideBelt / 2) + (SetticknessframeWall * SetframeWall) * SetframeWall / 2 + (SetoutsideBelt * SetticknessoutsideBelt) * SetticknessoutsideBelt / 2;
            double centerOrigin = statInertion / area;
            return centerOrigin;
        }
        public double GetInertionSkin()
        {
            double inertion = 30 * SetSkinTickness * Math.Pow(SetSkinTickness, 3) / 12 + 30 * SetSkinTickness * SetSkinTickness * Math.Pow(GetCenterOriginSkin() - SetSkinTickness / 2,2) + Math.Pow(SetticknessinsideBelt, 3) * SetinsideBelt / 12 + (SetinsideBelt * SetticknessinsideBelt * Math.Pow(SetframeWall + SetSkinTickness - GetCenterOriginSkin() - (SetticknessinsideBelt / 2), 2)) + Math.Pow(SetticknessoutsideBelt, 3) * SetoutsideBelt / 12 + (SetoutsideBelt * SetticknessoutsideBelt * Math.Pow(SetSkinTickness + (SetticknessoutsideBelt / 2) - GetCenterOriginSkin(), 2)) + Math.Pow(SetframeWall, 3) * SetticknessframeWall / 12 + (SetframeWall * SetticknessframeWall * Math.Pow((SetframeWall / 2) + SetSkinTickness - GetCenterOriginSkin(), 2));
            return inertion;
        }
        public double GetCenterOriginSkin()
        {
            SetArea = SetinsideBelt * SetticknessinsideBelt + SetoutsideBelt * SetticknessoutsideBelt + SetticknessframeWall * SetframeWall + 30 * SetSkinTickness * SetSkinTickness;
            double statInertion = SetinsideBelt * SetticknessinsideBelt * (SetframeWall - SetticknessinsideBelt / 2) + (SetticknessframeWall * SetframeWall) * SetframeWall / 2 + (SetoutsideBelt * SetticknessoutsideBelt) * SetticknessoutsideBelt / 2 - 30 * SetSkinTickness * SetSkinTickness * SetSkinTickness / 2;
            double centerOrigin = SetSkinTickness + statInertion / area;
            return centerOrigin;
        }
    }
}


