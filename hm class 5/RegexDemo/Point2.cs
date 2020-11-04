namespace RegexDemo
{
    public class Point2
    {
        public int X { get; set; }
        public int Y { get; set; }

        public override string ToString()
        {
            return $"({X},{Y})";
        }

    }

    public class Point3: Point2
    {
        public int Z { get; set; }

        public override string ToString()
        {
            return $"({X},{Y},{Z})";
        }
    }
}