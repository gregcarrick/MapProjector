namespace Projectr.Projections
{
    public interface IProjection
    {
        Point ConvertToCart(Point geo);

        Point Origin { get; set; }
    }
}
