namespace SleepHunter.Interop.Mouse
{
    public readonly struct MousePoint
    {
        public static MousePoint Zero => new MousePoint(0, 0);
        
        public int X { get; }
        public int Y { get; }

        public MousePoint(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override bool Equals(object obj)
        {
            if (obj is MousePoint point)
            {
                return point.X == X && point.Y == Y;
            }

            return false;
        }

        public override int GetHashCode()
        {
            var hash = 13;
            hash = (hash * 7) + X.GetHashCode();
            hash = (hash * 7) + Y.GetHashCode();
            return hash;
        }

        public override string ToString() => $"{X}, {Y}";
    }
}