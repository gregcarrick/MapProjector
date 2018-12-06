using System;

namespace Projectr
{
    public struct Point
    {
        private double x;
        private double y;

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
        /// The y-coordinate. This is tha latitude in geographical coordinates.
        /// </summary>
        public double Y
        {
            get
            {
                return this.y;
            }
        }

        public double DistanceFrom(Point other)
        {
            double xDist = other.X - this.X;
            double yDist = other.Y - this.Y;
            return Math.Sqrt((xDist * xDist) + (yDist * yDist));
        }
    }
}
