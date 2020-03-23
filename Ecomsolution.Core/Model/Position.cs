using Ecomsolutions.Core.Enum;

namespace Ecomsolutions.Core.Model
{
    /// <summary>
    /// Defines a position on a map, including X, Y coordinates as well as the Orientation (North, East, South, West)
    /// </summary>
    public sealed class Position
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Orientation Orientation { get; set; }

        public Position(int x, int y, Orientation orientation)
        {
            X = x;
            Y = y;
            Orientation = orientation;
        }

        public Position Clone()
            => new Position(X, Y, Orientation);

        public override bool Equals(object obj)
        {
            if (!(obj is Position rPosition))
                return false;

            return
                this.X.Equals(rPosition.X)
                &&
                this.Y.Equals(rPosition.Y)
                &&
                this.Orientation.Equals(rPosition.Orientation);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + X.GetHashCode();
                hash = hash * 23 + Y.GetHashCode();
                hash = hash * 23 + Orientation.GetHashCode();
                return hash;
            }
        }
    }
}
