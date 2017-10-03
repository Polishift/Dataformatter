using System.Collections.Generic;

namespace Dataformatter.Datamodels
{
    public class Polygon
    {
        public List<IPoint> Points = new List<IPoint>();

        public Polygon()
        {
        }

        public Polygon(List<IPoint> points)
        {
            Points = points;
        }
    }
}