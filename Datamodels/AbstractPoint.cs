using System;

namespace Dataformatter.Datamodels
{
    public abstract class AbstractPoint 
    {
        float X { get; set; }
        float Y { get; set; }        
        
        public static float DegreesToRadians(double degrees)
        {
            return (float) (degrees * Math.PI) / 180;
        }
    }
}