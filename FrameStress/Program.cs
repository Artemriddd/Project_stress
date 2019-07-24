using System;

namespace FrameStress
{
    class Program
    {
        static void Main(string[] args)
        {
            FrameGeom frame = new FrameGeom();
            frame.GetFrGeom();
            Console.WriteLine(frame.SetinsideBelt);
            Console.WriteLine(frame.SetticknessinsideBelt);
            Console.WriteLine(frame.SetframeWall);
            Console.WriteLine(frame.SetticknessframeWall);
            Console.WriteLine(frame.SetoutsideBelt);
            Console.WriteLine(frame.SetticknessoutsideBelt);
            SkinGeom skin = new SkinGeom();
            skin.GetSkingGeom();
            Console.WriteLine(skin.SetSkinTickness);
            Property prop = new Property();
            prop.GetProperty();
            Console.WriteLine(prop.SetskinElasticModule);
            Console.WriteLine(prop.SetskinSigma02);
            Console.WriteLine(prop.SetskinSigmaB);
            Console.WriteLine(prop.SetframeElasticModule);
            Console.WriteLine(prop.SetframeSigma02);
            Console.WriteLine(prop.SetframeSigmaB);
            Load load = new Load();
            load.GetLoad();
            Console.WriteLine(load.SetskinNormalForce);
            Console.WriteLine(load.SetframeNormalForce);
            Console.WriteLine(load.SetframeShearForce);
            Console.WriteLine(load.SetframeMoment);
        }
    }
}
