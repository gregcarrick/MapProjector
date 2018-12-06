namespace Projectr.Projections
{
    public interface IProjection
    {
        /// <summary>
        /// Takes geographical longitude/latitude coordinates and projects them
        /// orthographically.
        /// </summary>
        Point ConvertToCart(Point geo);

        /// <summary>
        /// The point at which the sphere and tangent plane intersect.
        /// </summary>
        Point Origin { get; set; }

        int StandardParallel { get; }
    }
}
