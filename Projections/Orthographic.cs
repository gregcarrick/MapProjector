using System;

namespace MapProjector.Projections
{
    /// <summary>
    /// The sphere is projected onto a tangent plane, such that the point of
    /// perspective is at infinity.
    /// </summary>
    /// <remarks>
    /// See Wikipedia: <see cref="https://en.wikipedia.org/wiki/Orthographic_projection_in_cartography"/>
    /// </remarks>
    class Orthographic : IProjection
    {
        /// <inheritdoc/>
        public Point Origin { get; set; }

        public string Description
        {
            get
            {
                return "Orthographic";
            }
        }

        /// <summary>
        /// The orthographic projection does not use standard parallels.
        /// </summary>
        public int StandardParallel
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        /// <inheritdoc/>
        public Point ConvertToCart(Point geo)
        {
            // Wikipedia uses lambda and phi to represent longitude and latitude.
            // Don't forget to convert to radians! T.T
            double lambda = Helpers.DegToRad(geo.Lambda);
            double phi = Helpers.DegToRad(geo.Phi);
            double lambda_0 = Helpers.DegToRad(this.Origin.Lambda);
            double phi_0 = Helpers.DegToRad(this.Origin.Phi);

            return new Point(
                Math.Cos(phi) * Math.Sin(lambda - lambda_0),
                (Math.Cos(phi_0) * Math.Sin(phi)) - (Math.Sin(phi_0) * Math.Cos(phi) * Math.Cos(lambda - lambda_0))
                );
        }

        /// <inheritdoc/>
        public Point ConvertToGeo(Point cart)
        {
            double x = Helpers.DegToRad(cart.X);
            double y = Helpers.DegToRad(cart.Y);
            double lambda_0 = Helpers.DegToRad(this.Origin.Lambda);
            double phi_0 = Helpers.DegToRad(this.Origin.Phi);

            double rho = Math.Sqrt(x * x + y * y);
            double c = Math.Asin(rho);
            double cosC = Math.Cos(c);
            double sinC = Math.Sin(c);
            double cosPhi_0 = Math.Cos(phi_0);
            double sinPhi_0 = Math.Cos(phi_0);

            double phi = Math.Asin(cosC * sinPhi_0 + y * sinC * cosPhi_0 / rho);
            double lambda = lambda_0 + Arctan(
                x * sinC,
                rho * cosC * cosPhi_0 - y * sinC * sinPhi_0
                );

            return new Point(phi, lambda);
        }

        /// <summary>
        /// Calculates the arctangent of y/x by converting from the
        /// <see cref="Math.Atan2(double, double)"/> function.
        /// </summary>
        private double Arctan(double y, double x)
        {
            if (x == 0)
            {
                throw new ArgumentException(
                    "Cannot calculate arctan(y/x) when x is 0.",
                    "x"
                    );
            }
            else if (x > 0)
            {
                return Math.Atan2(y, x);
            }
            else
            {
                if (y < 0)
                {
                    return Math.Atan2(y, x) + Math.PI;
                }
                else
                {
                    return Math.Atan2(y, x) - Math.PI;
                }
            }
        }
    }
}
