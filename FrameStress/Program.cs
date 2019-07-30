using System;

namespace FrameStress
{
    class Program
    {
        static void Main(string[] args)
        {
            FrameGeom frame = new FrameGeom();
            frame.GetFrGeom();
            Property prop = new Property();
            prop.GetProperty();
            Load load = new Load();
            load.GetLoad();

            double criticalSkinSigma = BucklingSkin.Buckling(frame.SetskinCoef, prop.SetskinElasticModule, frame.SetskinHeight, frame.SetSkinTickness);
            double criticalForce;

            if (criticalSkinSigma > prop.SetskinSigma02)
            {
                criticalForce = prop.SetskinSigma02 * frame.SetSkinTickness * frame.SetskinWidth;
            }
            else
            {
                criticalForce = criticalSkinSigma * frame.SetSkinTickness * frame.SetskinWidth;
            }

            //criticalForce = criticalSkinSigma > prop.SetskinSigma02 ? prop.SetskinSigma02 * frame.SetSkinTickness * frame.SetskinWidth : criticalSkinSigma * frame.SetSkinTickness * frame.SetskinWidth;

            if (-criticalForce < load.SetskinNormalForce)
            {
                Console.WriteLine("Обшивка устойчивость не теряет");
                Console.WriteLine("Момент инерции = " + frame.GetInertion());
                Console.WriteLine("Центр тяжести сечения = " + frame.GetCenterOrigin());

                double tau = load.SetframeShearForce / (frame.SetticknessframeWall * frame.SetframeWall);
                double sigmaMomentInsideBelt = load.SetframeMoment * (frame.GetCenterOrigin() - frame.SetframeWall) / frame.GetInertion();
                double sigmaMomentOutsideBelt = load.SetframeMoment * frame.GetCenterOrigin() / frame.GetInertion();
                double sigmaN = load.SetframeNormalForce / frame.SetArea;

                Console.WriteLine("Сдвиговые напряжения = " + Math.Round(tau, 2));
                Console.WriteLine("Нормальные напряжения от момента внутр пояса = " + Math.Round(sigmaMomentInsideBelt, 2));
                Console.WriteLine("Нормальные напряжения от момента внеш пояса = " + Math.Round(sigmaMomentOutsideBelt, 2));
                Console.WriteLine("Нормальные напряжения = " + Math.Round(sigmaN,2));

                double sigmaInsideBelt = sigmaMomentInsideBelt + sigmaN;
                double sigmaOutsideBelt = sigmaMomentOutsideBelt + sigmaN;
                double sigmaVonMis = Math.Sqrt(Math.Pow(Math.Max(Math.Abs(sigmaInsideBelt), Math.Abs(sigmaOutsideBelt)), 2) + 3 * Math.Pow(tau, 2));

                Console.WriteLine("Нормальные напряжения внутреннего пояса = " + Math.Round(sigmaInsideBelt, 2));
                Console.WriteLine("Нормальные напряжения внешнего пояса = " + Math.Round(sigmaOutsideBelt, 2));
                Console.WriteLine("Эквивалентные напряжения  = " + Math.Round(sigmaVonMis, 2));

                double safetyInsideBelt = prop.SetskinSigmaB / sigmaInsideBelt;
                double safetyOutsideBelt = prop.SetskinSigmaB / sigmaOutsideBelt;
                double safetyVonMis = prop.SetskinSigmaB / sigmaVonMis;

                Console.WriteLine("Коэффициент запаса прочности внутреннего пояса = " + Math.Round(Math.Abs(safetyInsideBelt), 2));
                Console.WriteLine("Коэффициент запаса прочности внешнего пояса = " + Math.Round(Math.Abs(safetyOutsideBelt), 2));
                Console.WriteLine("Коэффициент запаса прочности по Мизесу = " + Math.Round(safetyVonMis, 2));

                if (sigmaInsideBelt < 0)
                {
                    Console.WriteLine("Устойчивость внутреннего пояса: ");
                    double criticalInsideBeltSigma = BucklingSkin.Buckling(0.4, prop.SetframeElasticModule, frame.SetinsideBelt, frame.SetticknessinsideBelt);
                    
                    if (criticalInsideBeltSigma > prop.SetskinSigma02)
                    {
                        Console.WriteLine("Критические напряжения для внутреннего пояса: " + prop.SetskinSigma02);
                        Console.WriteLine("Коэффициент запаса местной потери устойчивости внутренного пояса = " + Math.Round(prop.SetskinSigma02 / Math.Abs(sigmaInsideBelt), 2));
                    }
                    else
                    {
                        Console.WriteLine("Критические напряжения для внутреннего пояса: " + Math.Round(criticalInsideBeltSigma, 2));
                        Console.WriteLine("Коэффициент запаса местной потери устойчивости внутренного пояса = " + Math.Round(criticalInsideBeltSigma / Math.Abs(sigmaInsideBelt), 2));
                    }
                }
            }
            else
            {
                Console.WriteLine("\nОбшивка теряет устойчивость");
                Console.WriteLine("Критические усилия для клетки обшивки = " + criticalForce);
                load.SetframeNormalForce += 2 * (load.SetskinNormalForce + (int)criticalForce);
                Console.WriteLine("Нормальные усилия на сечение с присоединенной обшивкой = " + load.SetframeNormalForce);
                Console.WriteLine("Момент инерции = " + frame.GetInertionSkin());
                Console.WriteLine("Центр тяжести сечения = " + frame.GetCenterOriginSkin());

                double tau = load.SetframeShearForce / (frame.SetticknessframeWall * frame.SetframeWall);
                double sigmaMomentInsideBelt = load.SetframeMoment * (frame.GetCenterOriginSkin() - frame.SetframeWall - frame.SetSkinTickness) / frame.GetInertionSkin();
                double sigmaMomentOutsideBelt = load.SetframeMoment * frame.GetCenterOriginSkin() / frame.GetInertionSkin();
                double sigmaN = load.SetframeNormalForce / frame.SetArea;

                Console.WriteLine("Сдвиговые напряжения = " + Math.Round(tau, 2));
                Console.WriteLine("Нормальные напряжения от момента внутр пояса = " + Math.Round(sigmaMomentInsideBelt, 2));
                Console.WriteLine("Нормальные напряжения от момента внеш пояса = " + Math.Round(sigmaMomentOutsideBelt, 2));
                Console.WriteLine("Нормальные напряжения = " + Math.Round(sigmaN, 2));

                double sigmaInsideBelt = sigmaMomentInsideBelt + sigmaN;
                double sigmaOutsideBelt = sigmaMomentOutsideBelt + sigmaN;
                double sigmaVonMis = Math.Sqrt(Math.Pow(Math.Max(Math.Abs(sigmaInsideBelt), Math.Abs(sigmaOutsideBelt)), 2) + 3 * Math.Pow(tau, 2));

                Console.WriteLine("Нормальные напряжения внутреннего пояса = " + Math.Round(sigmaInsideBelt, 2));
                Console.WriteLine("Нормальные напряжения внешнего пояса = " + Math.Round(sigmaOutsideBelt, 2));
                Console.WriteLine("Эквивалентные напряжения = " + Math.Round(sigmaVonMis, 2));

                double safetyInsideBelt = prop.SetskinSigmaB / sigmaInsideBelt;
                double safetyOutsideBelt = prop.SetskinSigmaB / sigmaOutsideBelt;
                double safetyVonMis = prop.SetskinSigmaB / sigmaVonMis;

                Console.WriteLine("Коэффициент запаса прочности внутреннего пояса = " + Math.Round(Math.Abs(safetyInsideBelt), 2));
                Console.WriteLine("Коэффициент запаса прочности внешнего пояса = " + Math.Round(Math.Abs(safetyOutsideBelt), 2));
                Console.WriteLine("Коэффициент запаса прочности по Мизесу = " + Math.Round(safetyVonMis, 2));

                if (sigmaInsideBelt < 0)
                {
                    Console.WriteLine("Устойчивость внутреннего пояса: ");
                    double criticalInsideBeltSigma = BucklingSkin.Buckling(0.4, prop.SetframeElasticModule, frame.SetinsideBelt, frame.SetticknessinsideBelt);

                    if (criticalInsideBeltSigma > prop.SetskinSigma02)
                    {
                        Console.WriteLine("Критические напряжения для внутреннего пояса: " + prop.SetskinSigma02);
                        Console.WriteLine("Коэффициент запаса местной потери устойчивости внутренного пояса = " + Math.Round(prop.SetskinSigma02 / Math.Abs(sigmaInsideBelt), 2));
                    }
                    else
                    {
                        Console.WriteLine("Критические напряжения для внутреннего пояса: " + Math.Round(criticalInsideBeltSigma, 2));
                        Console.WriteLine("Коэффициент запаса местной потери устойчивости внутренного пояса = " + Math.Round(criticalInsideBeltSigma / Math.Abs(sigmaInsideBelt), 2));
                    }

                }
                if (sigmaN < 0)
                {
                    Console.WriteLine("Общая потеря устойчивости шпангоута с присоединенной обшивкой: ");
                    double criticalSigma = 2 * Math.PI * prop.SetframeElasticModule * frame.GetInertionSkin() / (frame.SetArea * frame.SetskinHeight);

                    if (criticalSigma > prop.SetframeSigma02)
                    {
                        Console.WriteLine("Критические напряжения общей потери устойчивости: " + prop.SetframeSigma02);
                        Console.WriteLine("Коэффициент запаса общей потери устойчивости = " + Math.Round(prop.SetskinSigma02 / Math.Abs(sigmaN), 2));
                    }
                    else
                    {
                        Console.WriteLine("Критические напряжения общей потери устойчивости: " + Math.Round(criticalSigma, 2));
                        Console.WriteLine("Коэффициент запаса общей потери устойчивости = " + Math.Round(criticalSigma / Math.Abs(sigmaN), 2));
                    }
                }
            }
        }
    }
}
