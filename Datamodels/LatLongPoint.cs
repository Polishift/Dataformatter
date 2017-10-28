using System;
using System.Net.NetworkInformation;

namespace Dataformatter.Datamodels
{
    public class LatLongPoint : AbstractPoint
    {
        public float X { get; set; } //latitude
        public float Y { get; set; } //longitude

        public XYPoint ToXYPoint()
        {
            return new XYPoint(){ X = DegreesToRadians(Y), Y = DegreesToRadians(X)};  
        }
        
        public override string ToString()
        {
            return X + " <> " + Y;
        }
    }
}