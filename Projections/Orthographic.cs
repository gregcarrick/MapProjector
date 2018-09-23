using System;

namespace Projectr.Projections
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
        /// <summary>
        /// Takes geographical longitude/latitude coordinates and projects them
        /// orthographically.
        /// </summary>
        /// <param name="geo"></param>
        /// <returns></returns>
        public Point ConvertToCart(Point geo)
        {
            // Wikipedia uses lambda and phi for longitude and latitude.
            double lambda = geo.X;
            double phi = geo.Y;
            double lambda_0 = this.Origin.X;
            double phi_0 = this.Origin.Y;

            return new Point(
                Math.Cos(phi) * Math.Sin(lambda - lambda_0),
                (Math.Cos(phi_0) * Math.Sin(phi)) - (Math.Sin(phi_0) * Math.Cos(phi) * Math.Cos(lambda - lambda_0))
                );
        }

        /// <summary>
        /// The point at which the sphere and tangent plane intersect.
        /// </summary>
        public Point Origin { get; set; }
    }
}
