namespace Dataformatter.Misc
{
    public class Tuple<T, J>
    {
        public Tuple(T item1, J item2)
        {
            Item1 = item1;
            Item2 = item2;
        }

        public T Item1 { get; set; }
        public J Item2 { get; set; }

        public override string ToString()
        {
            return "{" + Item1 + "," + Item2 + "}";
        }

        public override int GetHashCode()
        {
            return Item1.GetHashCode() ^ Item2.GetHashCode();
        }


        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            return Equals((Tuple<T, J>) obj);
        }

        private bool Equals(Tuple<T, J> other)
        {
            return other.Item1.Equals(Item1) && other.Item2.Equals(Item2);
        }
    }
}