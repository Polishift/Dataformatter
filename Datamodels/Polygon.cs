using System.Collections.Generic;
using System.Linq;

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

        public override string ToString()
        {
            var listString = Points.Aggregate("", (current, point) => current + "\n" + point.ToString());

            return listString;
        }
    }
}