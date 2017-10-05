namespace Dataformatter.Datamodels
{
    public class XYPoint : IPoint
    {
        public float X { get; set; }
        public float Y { get; set; }
        
        public override string ToString()
        {
            return X + " <> " + Y;
        }
    }
}