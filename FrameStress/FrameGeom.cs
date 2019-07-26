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
        }
        public double GetInertion()
        {
            double inertion = Math.Pow(SetinsideBelt,3) * SetticknessinsideBelt + Math.Pow(SetoutsideBelt, 3) * SetticknessoutsideBelt + Math.Pow(SetticknessframeWall, 3) * SetframeWall;
            return inertion;
        }
        public double GetCenterOrigin()
        {
            SetArea = SetinsideBelt * SetticknessinsideBelt + SetoutsideBelt * SetticknessoutsideBelt + SetticknessframeWall * SetframeWall;
            double statInertion = (SetinsideBelt * SetticknessinsideBelt) * (SetframeWall + SetticknessinsideBelt / 2) + (SetticknessframeWall * SetframeWall) * SetframeWall / 2 + (SetoutsideBelt * SetticknessoutsideBelt) * SetticknessoutsideBelt / 2;
            double centerOrigin = statInertion / area;
            return centerOrigin;
        }



    }
}

