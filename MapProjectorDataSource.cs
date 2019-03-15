using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;
using MapProjector.Projections;

namespace MapProjector
{
    /// <summary>
    /// Allows the user to choose from pre-set paper sizes or set custom side lengths.
    /// </summary>
    public enum PaperSize
    {
        /// <summary>
        /// Standard size A2.
        /// </summary>
        A2,

        /// <summary>
        /// Standard size A3.
        /// </summary>
        A3,

        /// <summary>
        /// Standard size A4.
        /// </summary>
        A4,

        /// <summary>
        /// Custom width and length.
        /// </summary>
        Custom,
    }

    /// <summary>
    /// Paper orientation: Landscape or Portrait.
    /// </summary>
    public enum Orientation
    {
        /// <summary>
        /// Landscape.
        /// </summary>
        Landscape,

        /// <summary>
        /// Portrait.
        /// </summary>
        Portrait,
    }

    /// <summary>
    /// The data source bound to the <see cref="MapProjectorWindow"/>.
    /// </summary>
    public class MapProjectorDataSource : Component, INotifyPropertyChanged
    {
        private const string placeholder = "         ";

        private double north;
        private double south;
        private double east;
        private double west;
        private double interval;
        private PaperSize paperSize;
        private Orientation orientation;
        private int customPaperSizeDim1;
        private int customPaperSizeDim2;
        private List<double> lats;
        private List<double> longs;
        private Dictionary<double, Dictionary<double, Point>> cartCoords;
        private double scale;
        private string cartCoordsOutput;

        /// <inheritdoc/>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Constructs a new instance of <see cref="MapProjectorDataSource"/>.
        /// </summary>
        public MapProjectorDataSource()
        {
            this.Interval = 1;
            this.PaperSize = PaperSize.A3;
            this.Orientation = Orientation.Landscape;
        }

        #region Properties

        /// <summary>
        /// Northernmost geographical coordinate.
        /// </summary>
        public double North
        {
            get
            {
                return this.north;
            }
            set
            {
                if (value != this.north)
                {
                    this.north = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Southernmost geographical coordinate.
        /// </summary>
        public double South
        {
            get
            {
                return this.south;
            }
            set
            {
                if (value != this.south)
                {
                    this.south = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Easternmost geographical coordinate.
        /// </summary>
        public double East
        {
            get
            {
                return this.east;
            }
            set
            {
                if (value != this.east)
                {
                    this.east = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Westernmost geographical coordinate.
        /// </summary>
        public double West
        {
            get
            {
                return this.west;
            }
            set
            {
                if (value != this.west)
                {
                    this.west = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Interval of the coordinate gridlines.
        /// </summary>
        public double Interval
        {
            get
            {
                return this.interval;
            }
            set
            {
                if (value != this.interval)
                {
                    this.interval = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// One parameter for the custom paper size, the other being <see cref="CustomPaperSizeDim2"/>.
        /// </summary>
        public double CustomPaperSizeDim1
        {
            get
            {
                return this.customPaperSizeDim1;
            }
            set
            {
                if (value != this.CustomPaperSizeDim1)
                {
                    this.customPaperSizeDim1 = (int)value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// One parameter for the custom paper size, the other being <see cref="CustomPaperSizeDim1"/>.
        /// </summary>
        public double CustomPaperSizeDim2
        {
            get
            {
                return this.customPaperSizeDim2;
            }
            set
            {
                if (value != this.CustomPaperSizeDim2)
                {
                    this.customPaperSizeDim2 = (int)value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// The chosen paper size.
        /// </summary>
        public PaperSize PaperSize
        {
            get
            {
                return this.paperSize;
            }
            set
            {
                if (value != this.paperSize)
                {
                    this.paperSize = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// The orientation of the paper.
        /// </summary>
        public Orientation Orientation
        {
            get
            {
                return this.orientation;
            }
            set
            {
                if (value != this.orientation)
                {
                    this.orientation = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// The projection in use.
        /// </summary>
        public IProjection Projection { get; set; }

        /// <summary>
        /// Text output displaying the projected coordinates.
        /// </summary>
        public string CartCoordsOutput
        {
            get
            {
                return this.cartCoordsOutput;
            }
            set
            {
                this.cartCoordsOutput = value;
                OnPropertyChanged();
            }
        }

        #endregion

        private void Reset()
        {
            this.lats = new List<double>();
            this.longs = new List<double>();
            this.cartCoords = new Dictionary<double, Dictionary<double, Point>>();
        }

        /// <summary>
        /// Called when the Calculate button is clicked to project the coordinates.
        /// </summary>
        public void Calculate()
        {
            if (!CanCalculate())
            {
                MessageBox.Show(
                    "Invalid inputs.\r\n\r\nThe north-south and west-east ranges must be integer multiples of the selected interval. Please edit your bounds and try again.",
                    "Error", 
                    MessageBoxButtons.OK);

                return;
            }

            Reset();

            int rows = (int)Math.Ceiling((this.north - this.south) / this.interval + 1);
            for (int j = 0; j < rows; j++)
            {
                this.lats.Add(this.north - j * this.interval);
            }

            int cols = (int)Math.Ceiling((this.east - this.west) / this.interval) + 1;
            for (int i = 0; i < cols; i++)
            {
                this.longs.Add(this.west + i * this.interval);
            }

            this.Projection.Origin = new Point(
                (this.west + this.east) / 2,
                (this.north + this.south) / 2
                );

            double s = 0;
            double n = 0;
            double w = 0;
            double e = 0;
            Point cartCoord;

            foreach (int j in this.lats)
            {
                // Start at the top.
                Dictionary<double, Point> cartRow = new Dictionary<double, Point>();
                this.cartCoords.Add(j, cartRow);

                foreach (int i in this.longs)
                {
                    // Go from left to right.
                    cartCoord = this.Projection.ConvertToCart(new Point(i, j));
                    cartRow.Add(i, cartCoord);

                    // Keep track of the extremes in each cardinal direction.
                    if ((i == 0 && j == 0) || cartCoord.Y < s)
                    {
                        s = cartCoord.Y;
                    }
                    if ((i == 0 && j == 0) || cartCoord.Y > n)
                    {
                        n = cartCoord.Y;
                    }
                    if ((i == 0 && j == 0) || cartCoord.X < w)
                    {
                        w = cartCoord.X;
                    }
                    if ((i == 0 && j == 0) || cartCoord.X > e)
                    {
                        e = cartCoord.X;
                    }
                }
            }

            // The converted, but unscaled, west-east and north-south ranges.
            double we = e - w;
            double sn = n - s;

            // Set paper orientation and get the scaling factor.
            this.Orientation = (sn > we) ? Orientation.Portrait : Orientation.Landscape;
            this.scale = Math.Min(GetPaperHeight() / sn, GetPaperWidth() / we);

            // Scale the grid to fit the paper.
            Dictionary<double, Dictionary<double, Point>> newDict = new Dictionary<double, Dictionary<double, Point>>();
            foreach (double key in this.cartCoords.Keys)
            {
                Dictionary<double, Point> newRow = new Dictionary<double, Point>();
                foreach (KeyValuePair<double, Point> kvp in this.cartCoords[key])
                {
                    Point point = kvp.Value;
                    newRow[kvp.Key] = ScalePoint(point);
                }
                newDict.Add(key, newRow);
            }

            this.cartCoords = newDict;

            FillPaper();

            DumpOutput();
        }

        private bool CanCalculate()
        {
            bool result = true;

            double vertSpan = this.north - this.south;
            double horiSpan = this.east - this.west;
            result &= vertSpan > 0 && vertSpan % this.interval == 0;
            result &= horiSpan > 0 && horiSpan % this.interval == 0;

            return result;
        }

        private Point ScalePoint(Point point)
        {
            return new Point(
                this.scale * point.X + GetPaperWidth() / 2, // left to right
                GetPaperHeight() / 2 - this.scale * point.Y // top to bottom
                );
        }

        private void FillPaper()
        {
            // First, try to add points along the existing lines of latitude.
            foreach (KeyValuePair<double, Dictionary<double, Point>> kvp in this.cartCoords)
            {
                FillRow(kvp.Key, kvp.Value);
            }

            // Next, add rows to the top.
            Dictionary<double, Point> newRow = new Dictionary<double, Point>();
            Point newPoint;

            double northernmost = this.north;
            Dictionary<double, Point> topRow = this.cartCoords[northernmost];

            while (true)
            {
                northernmost += this.interval;
                foreach (double colLong in this.longs)
                {
                    newPoint = ScalePoint(
                        this.Projection.ConvertToCart(
                            new Point(colLong, northernmost)
                            ));
                    if (newPoint.X >= 0 && newPoint.X <= GetPaperWidth()
                        && newPoint.Y >= 0 && newPoint.Y <= GetPaperHeight())
                    {
                        newRow.Add(colLong, newPoint);
                    }
                }

                FillRow(northernmost, newRow);

                topRow = newRow;
                newRow = new Dictionary<double, Point>();

                if (topRow.Count == 0)
                {
                    break;
                }
                else
                {
                    this.lats.Add(northernmost);
                    this.cartCoords.Add(northernmost, topRow);
                }
            }

            // Finally, add rows to the bottom.
            double southernmost = this.south;
            Dictionary<double, Point> bottomRow = this.cartCoords[southernmost];

            while (true)
            {
                southernmost -= this.interval;
                foreach (double colLong in topRow.Keys)
                {
                    newPoint = ScalePoint(
                        this.Projection.ConvertToCart(
                            new Point(colLong, southernmost)
                            ));
                    if (newPoint.X >= 0 && newPoint.X <= GetPaperWidth()
                        && newPoint.Y >= 0 && newPoint.Y <= GetPaperHeight())
                    {
                        newRow.Add(colLong, newPoint);
                    }
                }

                FillRow(southernmost, newRow);

                bottomRow = newRow;
                newRow = new Dictionary<double, Point>();

                if (bottomRow.Count == 0)
                {
                    break;
                }
                else
                {
                    this.lats.Add(southernmost);
                    this.cartCoords.Add(southernmost, bottomRow);
                }
            }

            // Sort top-to-bottom.
            this.lats = this.lats.OrderByDescending(d => d).ToList();
            this.cartCoords.SortDictionaryByKeyDescending();
        }

        private void FillRow(double rowLat, Dictionary<double, Point> row)
        {
            double westernmost = this.longs.First();
            double easternmost = this.longs.Last();
            Point newPoint;

            // Add points until we reach the edge of the paper.
            // We assume horizontal symmetry.
            while (true)
            {
                westernmost -= this.interval;
                newPoint = ScalePoint(
                        this.Projection.ConvertToCart(
                            new Point(westernmost, rowLat)
                            ));

                if (newPoint.X < 0
                    || newPoint.Y < 0
                    || newPoint.Y > GetPaperHeight())
                {
                    // The new point is off the left, top, or bottom of the
                    // paper, so we're done with this row.
                    break;
                }

                // Add the points to each end of the row.
                if (!this.longs.Contains(westernmost))
                {
                    this.longs.Add(westernmost);
                    this.longs = this.longs.OrderBy(d => d).ToList();
                }
                row.Add(westernmost, newPoint);

                easternmost += this.interval;
                if (!this.longs.Contains(easternmost))
                {
                    this.longs.Add(easternmost);
                    this.longs = this.longs.OrderBy(d => d).ToList();
                }
                row.Add(easternmost, ScalePoint(
                        this.Projection.ConvertToCart(
                            new Point(easternmost, rowLat)
                            )));
            }

            // Sort left-to-right.
            row.SortDictionaryByKeyAscending();
        }

        private void DumpOutput()
        {
            StringBuilder output = new StringBuilder();

            string longs = "      "
                + string.Join(
                    " ",
                    this.longs.Select(d => d.ToString().PadLeft(9)).ToList()
                    );
            output.AppendLine(longs);

            if (this.cartCoords != null)
            {
                this.lats = this.lats.OrderByDescending(d => d).ToList();
                this.cartCoords = this.cartCoords.SortDictionaryByKeyDescending();

                foreach (double rowLat in this.lats)
                {
                    output.AppendLine(GetOutputLine(rowLat));
                }
            }

            this.CartCoordsOutput = output.ToString();
        }

        private string GetOutputLine(double rowLat)
        {
            List<string> outputLine = new List<string>();
            Dictionary<double, Point> row = this.cartCoords[rowLat];

            foreach (double colLong in this.longs)
            {
                if (row.Keys.Contains(colLong))
                {
                    outputLine.Add(row[colLong].ToString());
                }
                else
                {
                    outputLine.Add(placeholder);
                }
            }

            return rowLat.ToString().PadLeft(3) + " | " + string.Join(" ", outputLine);
        }

        #region Paper orientation

        private int GetPaperHeight()
        {
            switch (this.Orientation)
            {
                case Orientation.Landscape:
                    return GetPaperShortSide();
                case Orientation.Portrait:
                default:
                    return GetPaperLongSide();
            }
        }

        private int GetPaperWidth()
        {
            switch (this.Orientation)
            {
                case Orientation.Landscape:
                    return GetPaperLongSide();
                case Orientation.Portrait:
                default:
                    return GetPaperShortSide();
            }
        }

        private int GetPaperLongSide()
        {
            switch (this.PaperSize)
            {
                case PaperSize.A2:
                    return 594;
                case PaperSize.A3:
                    return 420;
                case PaperSize.A4:
                    return 297;
                case PaperSize.Custom:
                default:
                    return Math.Max(this.customPaperSizeDim1, this.customPaperSizeDim2);
            }
        }

        private int GetPaperShortSide()
        {
            switch (this.PaperSize)
            {
                case PaperSize.A2:
                    return 420;
                case PaperSize.A3:
                    return 297;
                case PaperSize.A4:
                    return 210;
                case PaperSize.Custom:
                default:
                    return Math.Min(this.customPaperSizeDim1, this.customPaperSizeDim2);
            }
        }

        #endregion

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
