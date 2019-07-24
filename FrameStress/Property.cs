using System;
using System.Collections.Generic;
using System.Text;

namespace FrameStress
{
    class Property
    {
        private int skinElasticModule;
        private int skinSigma02;
        private int skinSigmaB;

        private int frameElasticModule;
        private int frameSigma02;
        private int frameSigmaB;

        public int SetskinElasticModule
        {
            get
            {
                return skinElasticModule;
            }
            set
            {
                if (value > 0)
                {
                    skinElasticModule = value;
                }
            }
        }
        public int SetskinSigma02
        {
            get
            {
                return skinSigma02;
            }
            set
            {
                if (value > 0)
                {
                    skinSigma02 = value;
                }
            }
        }
        public int SetskinSigmaB
        {
            get
            {
                return skinSigmaB;
            }
            set
            {
                if (value > 0)
                {
                    skinSigmaB = value;
                }
            }
        }
        public int SetframeElasticModule
        {
            get
            {
                return frameElasticModule;
            }
            set
            {
                if (value > 0)
                {
                    frameElasticModule = value;
                }
            }
        }
        public int SetframeSigma02
        {
            get
            {
                return frameSigma02;
            }
            set
            {
                if (value > 0)
                {
                    frameSigma02 = value;
                }
            }
        }
        public int SetframeSigmaB
        {
            get
            {
                return frameSigmaB;
            }
            set
            {
                if (value > 0)
                {
                    frameSigmaB = value;
                }
            }
        }

        public void GetProperty()
        {
            Console.WriteLine("Введите модуль упругости материала обшивки");
            SetskinElasticModule = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите предел текучести материала обшивки (G02)");
            SetskinSigma02 = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите предел прочности материала обшивки (Gb)");
            SetskinSigmaB = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите модуль упругости материала шпангоута");
            SetframeElasticModule = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите предел текучести материала шпангоута (G02)");
            SetframeSigma02 = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите предел прочности материала шпангоута (GB)");
            SetframeSigmaB = int.Parse(Console.ReadLine());
        }
    }
}
