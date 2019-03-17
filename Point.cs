using System;
using System.Globalization;

namespace MapProjector
{
    /// <summary>
    /// A point on a plane, expressed as a coordinate pair.
    /// </summary>
    /// <remarks>
    /// For syntactic convenience, the longtiude and latitude may be returned as either
    /// (<see cref="Point.X"/>, <see cref="Point.Y"/>) or
    /// (<see cref="Point.Lambda"/>, <see cref="Point.Phi"/>).
    /// </remarks>
    public struct Point
    {
        private readonly double x;
        private readonly double y;

        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// The x-coordinate. This is the longitude in geographical coordinates.
        /// </summary>
        public double X
        {
            get
            {
                return this.x;
            }
        }

        /// <summary>
        /// The y-coordinate. This is the latitude in geographical coordinates.
        /// </summary>
        public double Y
        {
            get
            {
                return this.y;
            }
        }

        /// <summary>
        /// The lambda coordinate. This is the longitude in cartographic coordinates.
        /// </summary>
        public double Lambda
        {
            get
            {
                return this.x;
            }
        }

        /// <summary>
        /// The phi coordinate. This is the latitude in cartographic coordinates.
        /// </summary>
        public double Phi
        {
            get
            {
                return this.y;
            }
        }

        /// <summary>
        /// Get the Euclidean distance betwwen this point and another.
        /// </summary>
        public double DistanceFrom(Point other)
        {
            double xDist = other.x - this.x;
            double yDist = other.y - this.y;
            return Math.Sqrt((xDist * xDist) + (yDist * yDist));
        }

        public override string ToString()
        {
            string first = String.Format(
                CultureInfo.InvariantCulture,
                "{0:0.0}",
                this.x
                ).PadLeft(5);
            string second = String.Format(
                CultureInfo.InvariantCulture,
                "{0:0.0}",
                this.y
                ).PadLeft(5);
            return "(" + first + "," + second + ")";
        }
    }
}
