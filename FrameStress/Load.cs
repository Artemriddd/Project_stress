using System;
using System.Collections.Generic;
using System.Text;

namespace FrameStress
{
    class Load
    {
        public int SetskinNormalForce { get; set; }
        
        public int SetframeNormalForce { get; set; }

        public int SetframeShearForce { get; set; }

        public int SetframeMoment { get; set; }

        public void GetLoad()
        {
            Console.WriteLine("Введите нормальную силу действующую на обшивку");
            SetskinNormalForce = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите нормальную силу действующую на сечение шпангоута");
            SetframeNormalForce = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите перерезывающую силу действующую на сечение шпангоута");
            SetframeShearForce = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите изгибающий момент дейсвтующий на сечение шпангоута");
            SetframeMoment = int.Parse(Console.ReadLine());
        }
    }
}
