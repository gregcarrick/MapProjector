namespace MapProjector.Projections
{
    public interface IProjection
    {
        /// <summary>
        /// The point at which the sphere and tangent plane intersect.
        /// </summary>
        Point Origin { get; set; }

        /// <summary>
        /// The variable standard parallel used by some projections, such as
        /// equirectangular.
        /// </summary>
        int StandardParallel { get; }

        /// <summary>
        /// Takes geographical longitude/latitude coordinates and projects them
        /// orthographically.
        /// </summary>
        Point ConvertToCart(Point geo);

        /// <summary>
        /// Takes a point from the map and projects it back onto the sphere.
        /// </summary>
        Point ConvertToGeo(Point cart);
    }
}
