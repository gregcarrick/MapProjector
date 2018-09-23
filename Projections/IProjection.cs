namespace Projectr.Projections
{
    interface IProjection
    {
        Point ConvertToCart(Point geo);

        Point Origin { get; set; }
    }
}
