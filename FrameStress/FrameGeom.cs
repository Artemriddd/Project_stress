using System;
using System.Collections.Generic;
using System.Text;

namespace FrameStress
{
    class FrameGeom
    {
        private int insideBelt;
        private int outsideBelt;
        private int frameWall;
        private int ticknessinsideBelt;
        private int ticknessoutsideBelt;
        private int ticknessframeWall;
        public int SetinsideBelt
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
        public int SetoutsideBelt
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
        public int SetframeWall
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
        public int SetticknessinsideBelt
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
        public int SetticknessoutsideBelt
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
        public int SetticknessframeWall
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

        public void GetFrGeom()
        {
            Console.WriteLine("Введите ширину внутреннего пояса шпангоута");
            SetinsideBelt = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите толщину внутреннего пояса шпангоута");
            SetticknessinsideBelt = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите высоту стенки пояса шпангоута");
            SetframeWall = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите толщину стенки шпангоута");
            SetticknessframeWall = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите ширину внешнего пояса шпангоута");
            SetoutsideBelt = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите толщину внешнего пояса шпангоута");
            SetticknessoutsideBelt = int.Parse(Console.ReadLine());
        }
    }
}

