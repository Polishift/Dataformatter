using System;

namespace Dataformatter.Datamodels
{
    public abstract class AbstractPoint
    {
        private float X { get; set; }
        private float Y { get; set; }

        public static float DegreesToRadians(double degrees)
        {
            return (float) (degrees * Math.PI) / 180;
        }
    }
}