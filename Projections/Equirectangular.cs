using System;

namespace MapProjector.Projections
{
    /// <summary>
    /// A simple rectangular projection that maps latitudes to constantly-spaced
    /// horizontal lines, and longitudes to constantly-spaced vertical lines.
    /// </summary>
    /// <remarks>
    /// The special case of the equirectangular projection where the standard
    /// is 0 is known as the plate carrée (flat square) projection.
    /// See wikipedia: <see cref="https://en.wikipedia.org/wiki/Equirectangular_projection"/>.
    /// </remarks>
    public class Equirectangular : IProjection
    {
        private int phi_1 = 0;

        /// <inheritdoc/>
        public Point ConvertToCart(Point geo)
        {
            // Wikipedia uses lambda and phi for longitude and latitude.
            double lambda = geo.X;
            double phi = geo.Y;
            double lambda_0 = this.Origin.X;
            double phi_0 = this.Origin.Y;

            return new Point(
                Math.Cos(this.phi_1) * (lambda - lambda_0),
                phi - phi_0
                );
        }

        /// <inheritdoc/>
        public Point Origin { get; set; }

        /// <summary>
        /// The standard parallel of the equirectangular projection.
        /// 0 by default.
        /// </summary>
        public int StandardParallel
        {
            get
            {
                return this.phi_1;
            }
            set
            {
                this.phi_1 = value;
            }
        }
    }
}
