using System;

namespace Dataformatter.Datamodels
{
    public class XYPoint : AbstractPoint
    {
        public float X { get; set; }
        public float Y { get; set; }

        public double EuclideanDistance(XYPoint otherPoint)
        {
            return Math.Sqrt(Math.Pow(X - otherPoint.X, 2) + Math.Pow(Y - otherPoint.Y, 2));
        }

        public override string ToString()
        {
            return X + " <> " + Y;
        }
    }
}