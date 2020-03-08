namespace MapProjector.Projections
{
    /// <summary>
    /// The special case of the <see cref="Equirectangular"/> projection where
    /// the equator is the standard parallel. Lines of longitude and latitude
    /// form a simple square grid.
    /// </summary>
    public class PlateCarree : IProjection
    {
        /// <inheritdoc/>
        public Point Origin { get; set; }

        public string Description
        {
            get
            {
                return "Plate Carrée";
            }
        }

        /// <summary>
        /// The standard parallel of the plate carrée projection is 0.
        /// </summary>
        public int StandardParallel
        {
            get
            {
                return 0;
            }
        }

        public Point ConvertToCart(Point geo)
        {
            // Wikipedia uses lambda and phi for longitude and latitude.
            double lambda = geo.Lambda;
            double phi = geo.Phi;
            double lambda_0 = this.Origin.Lambda;
            double phi_0 = this.Origin.Phi;

            return new Point(
                lambda - lambda_0,
                phi - phi_0
                );
        }

        /// <inheritdoc/>
        public Point ConvertToGeo(Point cart)
        {
            double x = cart.X;
            double y = cart.Y;
            double lambda_0 = this.Origin.Lambda;
            double phi_0 = this.Origin.Phi;

            return new Point(
                x + lambda_0,
                y + phi_0
                );
        }
    }
}
