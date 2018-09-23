using System;

namespace Projectr
{
    struct Point
    {
        private double x;
        private double y;

        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public double X
        {
            get
            {
                return this.x;
            }
        }

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
